using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    public class Sonic : Character
    {   /// 2 6 29 39
        /// 33 7 30 38
        /// 63 7 29 38
        /// 92 7 30 38
        /// 122 9 29 36
        /// 184 2 24 43
        /// </summary>
        public Sonic(Texture2D texture, Vector2 position, Vector2 scale)
            : base(texture, position, Keys.A, Keys.D, Keys.W)
        {
            _animations.Add(AnimationType.Jumping, new List<Rectangle>());
            _animations[AnimationType.Jumping].Add(new Rectangle(122, 9, 29, 36));
            _animations[AnimationType.Jumping].Add(new Rectangle(184, 2, 24, 43));
            _animations.Add(AnimationType.Idle, new List<Rectangle>());
            _animations[AnimationType.Idle].Add(new Rectangle(2, 6, 29, 39));
            _animations[AnimationType.Idle].Add(new Rectangle(33, 7, 30, 38));
            _animations[AnimationType.Idle].Add(new Rectangle(63, 7, 29, 38));
            _animations[AnimationType.Idle].Add(new Rectangle(92, 7, 30, 38));
            _animations.Add(AnimationType.Walking, new List<Rectangle>());
            _animations[AnimationType.Walking].Add(new Rectangle(4, 50, 24, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(32, 50, 36, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(71, 49, 29, 38));
            _animations[AnimationType.Walking].Add(new Rectangle(106, 50, 26, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(137, 50, 37, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(179, 49, 32, 38));
            Initilize(new TimeSpan(0, 0, 0, 0, 100), new Vector2(), scale);
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, (int)(30 * scale.X), (int)(38 * scale.Y));
        }

        public void Update(GameTime gameTime, KeyboardState ks, KeyboardState lastks, List<Platform> platforms)
        {
            AnimationUpdate(gameTime);
            Update(ks, lastks, platforms);
            if (facingRight)
            {
                _effects = SpriteEffects.None;
            }
            else
            {
                _effects = SpriteEffects.FlipHorizontally;
            }
            _hitbox.X = (int)(_position.X - (_origin.X * _scale.X));
            _hitbox.Y = (int)(_position.Y - (_origin.Y * _scale.Y));
        }
        public void DrawRectangle(SpriteBatch spritebatch, GraphicsDevice graphicsDevice)
        {
            Texture2D thing;
            thing = new Texture2D(graphicsDevice, 1, 1);
            Color[] color = { Color.Red };
            thing.SetData(color);
            //spritebatch.Draw(thing, _hitbox, Color.White);
        }
    }
}