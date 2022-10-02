using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace PackLife.Managers
{
    internal class PackLifeAnimationManager
    {
        private PackLifeAnimations packlifeanimation;

        private float anitimer;

        public Vector2 pos { get; set; }

       //public void Draw(SpriteBatch spritebatch)
       // {
           // SpriteBatch.Draw(packlifeanimation.Texture,
               // Position,
               // new Rectangle(packlifeanimation.CurrentFrame * packlifeanimation.FrameWidth,
               // 0,
               // packlifeanimation.FrameWidth,
               // packlifeanimation.FrameHeight),
                //Color.White);
        //}

        public PackLifeAnimationManager(PackLifeAnimations animation)
        {
            packlifeanimation = animation;
        }

        public void Play(PackLifeAnimations animation)
        {
            if (packlifeanimation == animation) return;
            packlifeanimation = animation;

            packlifeanimation.CurrentFrame = 0;

            anitimer = 0;
        }

        public void Stop()
        {
            anitimer = 0;

            packlifeanimation.CurrentFrame = 0;
        }

      //  public void Update(GameTime gametime)
      //  {
          //  anitimer += (float)GameTime.ElapsedGameTime.TotalSeconds;
          //  if (anitimer > packlifeanimation.FrameSpeed)
          //  {
              //  anitimer = 0f;

              //  packlifeanimation.CurrentFrame++;

               // if (packlifeanimation.CurrentFrame >= packlifeanimation.FrameCount) packlifeanimation.CurrentFrame = 0;
          // }
        }

    }

