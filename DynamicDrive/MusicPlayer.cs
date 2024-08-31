using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;


using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
namespace DynamicDrive
{
  
    internal class MusicPlayer
    {
               
        public bool isBeingPlayed = false;
        private bool isLooping = false;
        public String FileName;
        public String TrackName;
        private long volLng = 500; // 0->1000
        
        int counter = 0;
        public bool hasEnded = true;
       
        private String[] musicTracks;


        public MusicPlayer(SoundObject sounds)
        {
            this.TrackName = sounds.trackName;
            this.FileName = sounds.track;
            
        }

        public int GetVolume()
        {
            return (int)this.volLng/100;
        }

        public void SetVolume(int volume)
        {
            if(volume <= 10 && volume >=0)
                this.volLng = volume*100;
        }


        public void PlayFunction()
        {
            StringBuilder sb = new StringBuilder();
            int result = mciSendString("open \"" + FileName + "\" type waveaudio  alias " + this.TrackName, sb, 0, IntPtr.Zero);
            mciSendString("play "+ this.TrackName,sb,0,IntPtr.Zero);
            isBeingPlayed=true;
            sb.Clear();

            sb = new StringBuilder();
            mciSendString("status " + this.TrackName + " length", sb, 255, IntPtr.Zero);
            int length = Convert.ToInt32(sb.ToString());
            int pos = 0;
            long oldvol = volLng;

            while (isBeingPlayed)
            {
                sb.Clear();
                sb = new StringBuilder();
                mciSendString("status " + this.TrackName + " position", sb, 255, IntPtr.Zero);
                pos = Convert.ToInt32(sb.ToString());
                if(pos >= length)
                {
                    if (!isLooping)
                    {
                        isBeingPlayed = false;
                        hasEnded = true;
                    break;
                    }
                    else
                    {
  
                        hasEnded = true;
                        mciSendString("play " + this.TrackName + " from 0", sb, 0, IntPtr.Zero);

                    }
                }
                else
                {
                    hasEnded = false;
                }

                if (oldvol != volLng) //volume is changed by user
                {
                    //set new volume - Changed by Prahlad for phase-2
                    sb.Clear();
                    sb = new StringBuilder("................................................................................................................................");
                    string cmd = "setaudio " + this.TrackName + " volume to " + volLng.ToString();
                    long err = mciSendString(cmd, sb, sb.Length, IntPtr.Zero);
                    System.Diagnostics.Debug.Print(cmd);
                    if (err != 0)
                    {
                        System.Diagnostics.Debug.Print("ERror " + err);
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print("No errors!");
                    }
                    oldvol = volLng;
                }


            }
            mciSendString("stop " + this.TrackName, sb, 0, IntPtr.Zero);
            mciSendString("close " + this.TrackName, sb, 0, IntPtr.Zero);

        }

        public void Play(bool loop)
        {
            try
            {
                if (isBeingPlayed)
                    return;
                if(!File.Exists(FileName))
                {
                    isBeingPlayed=true;
                    System.Diagnostics.Debug.WriteLine("File Does Not Exist");
                    return;
                }
                this.isLooping=loop;

                ThreadStart ts = new ThreadStart(PlayFunction);
                Thread WorkerThread = new Thread(ts);
                WorkerThread.Start();   
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());   
                
            }
        }

        public void Stop()
        {
            isBeingPlayed = false;
            //StringBuilder sb = new StringBuilder();
            //mciSendString("stop " + this.TrackName, sb, 0, IntPtr.Zero);
            //System.Diagnostics.Debug.WriteLine("Stopping" + this.TrackName);
           
        }



        //sound api functions
        [DllImport("winmm.dll")]
        public static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        static extern bool PlaySound(
            string pszSound,
            IntPtr hMod,
            SoundFlags sf);

        // Flags for playing sounds.  For this example, we are reading 
        // the sound from a filename, so we need only specify 
        // SND_FILENAME | SND_ASYNC

        [Flags]
        public enum SoundFlags : int
        {
            SND_SYNC = 0x0000,  // play synchronously (default) 
            SND_ASYNC = 0x0001,  // play asynchronously 
            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
            SND_MEMORY = 0x0004,  // pszSound points to a memory file
            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
            SND_PURGE = 0x40, // <summary>Stop Playing Wave</summary>
            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
            SND_ALIAS = 0x00010000, // name is a registry alias 
            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
            SND_FILENAME = 0x00020000, // name is file name 
            SND_RESOURCE = 0x00040004  // name is resource name or atom 
        }



    }

    internal class MusicHandler
    { 
        
        String SoundName;
       
        MusicPlayer[] music;
        SoundObject[] array;
        public MusicHandler(SoundObject[] needed )
        {
           array = needed;
            music = new MusicPlayer[7];
            for(int i = 0; i < 7; i++)
            {
                music[i] = new MusicPlayer(array[i]);

            }
            // PlayAll(testObjects);

        }




        /// <summary>
        /// TODO Add Functionality to add/remove tracks from the list
        /// </summary>
        public void PlayAll()
        {
           
            for(int i=0; i<7; i++)
            {
                music[i].Play(true);
            }
            
            System.Diagnostics.Debug.WriteLine("Playing Music");
        }

        public void StopAll(List<SoundObject> applicable)
        {
            for (int i = 0; i < applicable.Count; i++)
            {
                music[i].Stop();

            }
        }

        /// <summary>
        /// TODO call on playback end
        /// </summary>
        /// <param name="applicable"></param>
        public void PlaySelect(List<SoundObject> applicable)
        {
            for (int i=0; i < applicable.Count; i++)
            {
                music[i] = new MusicPlayer(applicable[i]);
                music[i].Play(true);

            }
        }

    }

    public class SoundObject
    {
        public string track { get; set; }
        public string trackName { get; set; }
        public int id { get; set; }

        public SoundObject(int ident, string track, string trackName)
        {
            this.id = ident;
            
            this.track = track;
            this.trackName = trackName;
        }
    }
}
