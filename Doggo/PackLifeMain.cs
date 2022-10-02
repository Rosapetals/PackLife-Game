using Cocos2D;
using CocosDenshion;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;


namespace PackGame
{
    public class PackLife : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player;
        Texture2D pawcursor;
        Texture2D startupmenu;
        Texture2D rosa;
        private string rosa2 = "no";
        private bool over = false;
        float timer;
        int threshold;
        Rectangle[] sourceRectangles;
        byte previousAnimationIndex;
        byte currentAnimationIndex;
        float delay = 0;
        bool trigger = false;
        private static readonly System.TimeSpan intervalBetweenAttack1 = System.TimeSpan.FromMilliseconds(3000);
        private System.TimeSpan lastTimeAttack;
        //Texture2D forest;


        public PackLife() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            System.Diagnostics.Debug.WriteLine("" + rosa2);


        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1700;
            graphics.ApplyChanges();
            this.IsMouseVisible = false;
            base.Initialize();
            rosa2 = "no";

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = Content.Load<Texture2D>("wolf");
            pawcursor = Content.Load<Texture2D>("cursor2");
            startupmenu = Content.Load<Texture2D>("agameby2");
            rosa = Content.Load<Texture2D>("rosa");
            timer = 0;
            threshold = 100;
            sourceRectangles = new Rectangle[3];
            sourceRectangles[0] = new Rectangle(5, 10, 86, 26);
            sourceRectangles[1] = new Rectangle(101, 11, 86, 23);
            sourceRectangles[2] = new Rectangle(197, 12, 86, 21);
            previousAnimationIndex = 2;
            currentAnimationIndex = 1;
            //forest = Content.Load<Texture2D>("Forest");
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (timer > threshold)
            {
                if (currentAnimationIndex == 1)
                {
                    if (previousAnimationIndex == 0)
                    {
                        currentAnimationIndex = 2;
                    }
                    else
                    {
                        currentAnimationIndex = 0;
                    }
                    previousAnimationIndex = currentAnimationIndex;
                }
                else
                {
                    currentAnimationIndex = 1;
                }
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            Vector2 scale = new Vector2(4f, 4f); // 64 to 32 == .5f
            if (rosa2.Contains("no") && (over == false)) spriteBatch.Draw(startupmenu, new Vector2(600, 200), sourceRectangles[currentAnimationIndex], Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
            scale = new Vector2(.5f, .5f); // 64 to 32 == .5f
            System.TimeSpan intervalBetweenAttack1 = System.TimeSpan.FromMilliseconds(3000);
            System.TimeSpan lastTimeAttack = System.TimeSpan.FromMilliseconds(1);
            if (lastTimeAttack + intervalBetweenAttack1 < gameTime.TotalGameTime)
            {
                rosa2 = "yes";
                if (over == false) spriteBatch.Draw(rosa, new Vector2(500, 400), null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
                lastTimeAttack = gameTime.TotalGameTime;
            }
            System.TimeSpan intervalBetweenAttack2 = System.TimeSpan.FromMilliseconds(6000);
            System.TimeSpan lastTimeAttack2 = System.TimeSpan.FromMilliseconds(1);
            if (lastTimeAttack2 + intervalBetweenAttack2 < gameTime.TotalGameTime)
            {
                rosa2 = "no";
                over = true;
            }
            spriteBatch.Draw(pawcursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);

        }

        private void ExitGame()
        {
            CCSimpleAudioEngine.SharedEngine.RestoreMediaState();
            Exit();
        }




    }
}
