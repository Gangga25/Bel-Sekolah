using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Audio
    {
        public string File = "";

        public Audio(string File = "")
        {
            this.File = File;
        }

        public void Play()
        {
            SoundPlayer simpleSound = new SoundPlayer(File);
            simpleSound.Play();
        }
    }
}
