using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace fireboyicegirl
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {


        //CORRECT ONE


        //fix issues
        TimeSpan GameSpawnTimer;
        bool DrawKnuckles = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sonic sonic;
        Knuckles knuckles;
        KeyboardState keyboardState;
        Texture2D PlatformImage;
        SpriteFont font;
        Random random = new Random();
        List<Platform> platforms;
        Texture2D pixel;
        Vector2 PositionOfFont;
        float Speed;
        TimeSpan scoreTimer;
        bool gameOver;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });
            PlatformImage = Content.Load<Texture2D>("Platform");
            Texture2D SonicImage = Content.Load<Texture2D>("sonic");
            Texture2D KnucklesImage = Content.Load<Texture2D>("knuckles");
            font = Content.Load<SpriteFont>("SpriteFont1");
            platforms = new List<Platform>();
            
            platforms.Add(new Platform(new Vector2(0, GraphicsDevice.Viewport.Height - PlatformImage.Height), PlatformImage, Vector2.One));
            platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 500), PlatformImage, new Vector2(0.1f, 1)));
            platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 200), PlatformImage, new Vector2(0.1f, 1)));
            platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 200), PlatformImage, new Vector2(0.1f, 1)));
            platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 500), PlatformImage, new Vector2(0.1f, 1)));
            platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 300), PlatformImage, new Vector2(0.1f, 1)));
            platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 100), PlatformImage, new Vector2(0.1f, 1)));
            sonic = new Sonic(SonicImage, new Vector2(0, 593), new Vector2(2f));
            knuckles = new Knuckles(KnucklesImage, new Vector2(20, 600), new Vector2(2f));
        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardState lastks = keyboardState;
            keyboardState = Keyboard.GetState();

            if (gameOver == true)
            {
                if (keyboardState.IsKeyDown(Keys.R) && lastks.IsKeyUp(Keys.R))
                {
                    platforms.Clear();
                    platforms.Add(new Platform(new Vector2(0, GraphicsDevice.Viewport.Height - PlatformImage.Height), PlatformImage, Vector2.One));
                    platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 500), PlatformImage, new Vector2(0.1f, 1)));
                    platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 200), PlatformImage, new Vector2(0.1f, 1)));
                    platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 200), PlatformImage, new Vector2(0.1f, 1)));
                    platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 500), PlatformImage, new Vector2(0.1f, 1)));
                    platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 300), PlatformImage, new Vector2(0.1f, 1)));
                    platforms.Add(new Platform(new Vector2(random.Next(0, 1000), 100), PlatformImage, new Vector2(0.1f, 1)));
                    sonic.Y = 593;
                    Speed = 0;
                    scoreTimer = TimeSpan.Zero;
                    gameOver = false;
                }
            }

            PositionOfFont.X = 0;
            PositionOfFont.Y = 0;
            if (!gameOver)
            { 
                scoreTimer += gameTime.ElapsedGameTime;
            }
            Speed += 0.001f;
            if (sonic.Hitbox.X < 0)
            {
                sonic.X = GraphicsDevice.Viewport.Width - sonic.Hitbox.Width;
            }
            if (sonic.Hitbox.X > GraphicsDevice.Viewport.Width)
            {
                sonic.X = 0;
            }
            sonic.Update(gameTime, keyboardState, lastks, platforms);
            knuckles.Update(gameTime, keyboardState, lastks, platforms);
            //have a timer to spawns platforms above the screen
            //update all platforms and move them down

           

            GameSpawnTimer += gameTime.ElapsedGameTime;
            if (GameSpawnTimer >= TimeSpan.FromMilliseconds(1000))
            {
                GameSpawnTimer = TimeSpan.Zero;
                platforms.Add(new Platform(new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0), PlatformImage, new Vector2(0.1f, 1)));
            }
            if (sonic.Y >= GraphicsDevice.Viewport.Height + sonic.Hitbox.Height)
            {
                gameOver = true;
            }

            for (int i = 0; i < platforms.Count; i++)
            {

                    platforms[i].Y += Speed;
                platforms[i].Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            sonic.Draw(spriteBatch);
            if (DrawKnuckles == true)
                knuckles.Draw(spriteBatch);
            //loop through platforms and draw
            for (int i = 0; i < platforms.Count; i++)
            {
                if (!gameOver)
                {
                    platforms[i].Draw(spriteBatch);
                }
            }


            spriteBatch.DrawString(font, scoreTimer.ToString(), PositionOfFont, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
