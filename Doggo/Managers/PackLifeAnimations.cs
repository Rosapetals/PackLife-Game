using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace PackLife.Managers
{
    internal class PackLifeAnimations
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; set; }
        public int FrameHeight { get { return startupmenu.Height; } }

        public float FrameSpeed { get; set; }

        public int FrameWidth { get { return startupmenu.Width / FrameCount; } }

        public bool IsLooping { get; set; }

        public Texture2D startupmenu { get; private set; }

       // public Animation(Texture2D texture, int frameCount)
       // {
          //  texture = startupmenu;

            //FrameCount = frameCount;

           // IsLooping = true;
           //
           // FrameSpeed = 0.2f;
            
       // }



    }
}
