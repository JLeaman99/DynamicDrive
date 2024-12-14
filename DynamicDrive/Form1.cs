using System.Timers;

namespace DynamicDrive
{

    public partial class Form1 : Form
    {
        MusicHandler player;
        CANInterface myCar;
        String BackingTrack, First, Second, Third, Fourth, Fifth, Sixth;
        String FolderPath;
        SoundObject[] testObjects;
        int counter = 0;
        int test = 0, currentPlayingLevel=0;

        List<SoundObject> currentPlaying;
        System.Timers.Timer carloopTimer, musicTimer;
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
            //myCar = new CANInterface();

            carloopTimer = new System.Timers.Timer(50);
            carloopTimer.Elapsed += CarLoop;
            carloopTimer.AutoReset = true;
            carloopTimer.Start();

            //musicTimer = new System.Timers.Timer(500);
            ////musicTimer.Elapsed += CheckStatus;
            //musicTimer.AutoReset = true;
            //musicTimer.Start();

            PlayQueue(currentPlaying);

            //CarLoop();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        public void CarLoop(object sender, ElapsedEventArgs e)
        {
            if (myCar!=null) //myCar == null
            {
                return;
            }
            else
            {
                //myCar.CANMonitor(car_tb, engRPM_tb, carSpd_tb);
                //car_tb.AppendText(myCar.carData.ToString());
                //System.Diagnostics.Debug.WriteLine(test);
                int change = GetRangeLevel(test);
                if(change != currentPlayingLevel)
                {
                    currentPlayingLevel = change;
                    ChangeQueue(change);
                }
            }
        }

        private int GetRangeLevel(int range)
        {
            int level = range switch
            {
                int i when i == 0 => 0,
                int i when i > 0 && i <= 20 => 1,
                int i when i > 20 && i <= 40 => 2,
                int i when i > 40 && i <= 50 => 3,
                int i when i > 50 && i <= 60 => 4,
                int i when i > 60 && i <= 70 => 5,
                int i when i > 70 && i<= 80=> 6,
                int i when i >80 => 7,
             
                _ => 0
            };
            return level;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (counter < 7)
            {
                AddToQueue(currentPlaying, testObjects[counter]);
                counter++;
            }

        }

        public void ChangeQueue(int step)
        {
            if (counter <= 7 && counter >= 0)
            {
                if (counter > step)
                {
                    while (counter > step)
                    {
                        counter--;
                        RemoveFromQueue(currentPlaying, testObjects[counter]);
                    }
                }
                else
                {
                    while (counter < step)
                    {
                        AddToQueue(currentPlaying, testObjects[counter]);
                        counter++;
                    }
                }
            }
            else if (counter > 7)
            {
                counter = 7;
            }
            else
                counter = 0;
        }

        public void ChangeQueueO(int step)
        {
            if (counter > step)
            {
                while (counter >= step)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Counter Value: {0}, TestObjectsL: {1}, CurrentPlayingL {2}", counter, testObjects.Length, currentPlaying.Count));
                    RemoveFromQueue(currentPlaying, testObjects[counter]);
                    counter--;
                    if (counter < 0)
                        counter = 0;
                }
            }
            else if (counter == step)
            {
                AddToQueue(currentPlaying, testObjects[counter]);
            }
            else
            {
                while (counter <= step)
                {
                    AddToQueue(currentPlaying, testObjects[counter]);
                    counter++;
                    if (counter > 6)
                        counter = 6;
                }

            }
        }

        public void AddToQueue(List<SoundObject> queue, SoundObject additional)
        {

            if (!queue.Contains(additional))
            {
                player.StopAll(queue);
                queue.Add(additional);
                player.PlaySelect(queue);
                UpdateNowPlayingTB(queue);
            }


        }

        public void UpdateNowPlayingTB(List<SoundObject> queue)
        {
            try
            {
                if(nowPlayingTB.InvokeRequired)
                {
                    Action safeWrite = delegate { UpdateNowPlayingTB(queue);  };
                    nowPlayingTB.Invoke(safeWrite);
                }
                else
                {
                    nowPlayingTB.Clear();
                    for (int i = 0; i < queue.Count; i++)
                    {
                        nowPlayingTB.AppendText(queue[i].trackName + "\n");
                    }
                }
                
            }
            catch (Exception e)
            {

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

        //public void CheckStatus(object sender, ElapsedEventArgs e)
        //{

        //    if (player.music[0].checkStatus())
        //    {
        //        System.Diagnostics.Debug.WriteLine("WE OUT");
        //        Parallel.For(0, currentPlaying.Count, (i) =>
        //        {
        //            player.music[i].loopPlay();
        //        });
        //    }
        //}

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

        private void button3_Click(object sender, EventArgs e)
        {
            if(speedChange_tb.TextLength != 0)
                test = int.Parse(speedChange_tb.Text);
        }
    }
}
