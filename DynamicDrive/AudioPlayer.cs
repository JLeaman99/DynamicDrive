using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Media;
namespace DynamicDrive
{
    public class AudioPlayer
    {
        SoundPlayer soundPlayer;
        public AudioPlayer() { 
            soundPlayer = new SoundPlayer();
        }
        public void MyAudioCall(String filename)
        {
            soundPlayer.SoundLocation = filename;
            soundPlayer.PlayLooping();
        }


    }
}
