namespace DynamicDrive
{

    public partial class Form1 : Form
    {
        MusicHandler player;
        CANInterface myCar;
        String BackingTrack, First, Second, Third, Fourth, Fifth, Sixth;
        String FolderPath;
        SoundObject[] testObjects;
        int counter = 1;

        List<SoundObject> currentPlaying;
        public Form1()
        {
            InitializeComponent();
            FolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            BackingTrack = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "StartCar.wav"));
            First = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "FirstGear.wav"));
            Second = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "SecondGear.wav"));
            Third = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "ThirdGear.wav"));
            Fourth = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "FourthGear.wav"));
            Fifth = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "FifthGear.wav"));
            Sixth = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "SixthGear.wav"));
            Console.WriteLine("Backing Track Path {0}\n Folder Path {1}", BackingTrack, FolderPath);
            testObjects = new SoundObject[7];
            String[] tracks = { BackingTrack, First, Second, Third, Fourth, Fifth, Sixth };
            String[] trackNames = { "StartCar.wav", "FirstGear.wav", "SecondGear.wav", "ThirdGear.wav", "FourthGear.wav", "FifthGear.wav", "SixthGear.wav" };
            currentPlaying = new List<SoundObject>();

            for (int i = 0; i < 7; i++)
            {
                testObjects[i] = new SoundObject(i, tracks[i], trackNames[i]);
                allNamesTb.AppendText(trackNames[i] + "\n");
            }

            currentPlaying.Add(testObjects[0]);
            nowPlayingTB.AppendText(testObjects[0].trackName + "\n");

            player = new MusicHandler(testObjects);
            myCar = new CANInterface();
            PlayQueue(currentPlaying);

            CarLoop();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        public void CarLoop()
        {
            if (myCar == null)
            {
                return;
            }
            else
            {
                myCar.CANMonitor();
                car_tb.AppendText(myCar.carData.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (counter < 7)
            {
                AddToQueue(currentPlaying, testObjects[counter]);
                counter++;
            }

        }

        public void AddToQueue(List<SoundObject> queue, SoundObject additional)
        {
            player.StopAll(queue);
            queue.Add(additional);
            player.PlaySelect(queue);
            UpdateNowPlayingTB(queue);

        }

        public void UpdateNowPlayingTB(List<SoundObject> queue)
        {
            nowPlayingTB.Clear();
            for (int i = 0; i < queue.Count; i++)
            {
                nowPlayingTB.AppendText(queue[i].trackName + "\n");
            }
        }

        public void RemoveFromQueue(List<SoundObject> queue, SoundObject removal)
        {
            if (queue.Contains(removal))
            {
                player.StopAll(queue);
                queue.Remove(removal);
                player.PlaySelect(queue);
                UpdateNowPlayingTB(queue);

            }
        }

        public void PlayQueue(List<SoundObject> queue)
        {

            //player.PlayAll();
            player.PlaySelect(currentPlaying);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (counter <= 7 && counter > 0)
            {
                counter--;
                RemoveFromQueue(currentPlaying, testObjects[counter]);
                
            }
            if (counter > 7)
                counter--;
        }
    }
}
