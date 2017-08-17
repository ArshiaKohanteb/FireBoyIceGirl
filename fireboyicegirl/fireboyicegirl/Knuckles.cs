using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    class Knuckles : Character
    {
        //public Knuckles()
        /// <summary>
        /// Walking Animation
        /// </summary>
        public Knuckles(Texture2D image, Vector2 position, Vector2 scale)
            : base(image, position, Keys.Left, Keys.Right, Keys.Up)
        {
            _animations.Add(AnimationType.Jumping, new List<Rectangle>());
            _animations[AnimationType.Jumping].Add(new Rectangle(12, 148, 23, 40));
            _animations[AnimationType.Jumping].Add(new Rectangle(37, 148, 22, 40));
            _animations[AnimationType.Jumping].Add(new Rectangle(61, 148, 23, 40));
            _animations[AnimationType.Jumping].Add(new Rectangle(86, 148, 22, 40));
            _animations[AnimationType.Jumping].Add(new Rectangle(110, 148, 23, 40));
            _animations[AnimationType.Jumping].Add(new Rectangle(135, 148, 25, 39));
            _animations.Add(AnimationType.Walking, new List<Rectangle>());
            _animations[AnimationType.Walking].Add(new Rectangle(2, 40, 23, 36));
            _animations[AnimationType.Walking].Add(new Rectangle(27, 41, 24, 35));
            _animations[AnimationType.Walking].Add(new Rectangle(53, 42, 26, 34));
            _animations[AnimationType.Walking].Add(new Rectangle(81, 42, 24, 34));
            _animations[AnimationType.Walking].Add(new Rectangle(107, 40, 23, 36));
            _animations[AnimationType.Walking].Add(new Rectangle(132, 42, 24, 34));
            _animations[AnimationType.Walking].Add(new Rectangle(158, 42, 26, 34));
            _animations[AnimationType.Walking].Add(new Rectangle(186, 41, 24, 35));
            _animations[AnimationType.Walking].Add(new Rectangle(213, 41, 26, 34));
            _animations[AnimationType.Walking].Add(new Rectangle(241, 40, 24, 35));
            _animations[AnimationType.Walking].Add(new Rectangle(268, 39, 27, 35));
            _animations.Add(AnimationType.Idle, new List<Rectangle>());
            _animations[AnimationType.Idle].Add(new Rectangle(0, 1, 26, 34));
            _animations[AnimationType.Idle].Add(new Rectangle(28, 1, 24, 34));
            _animations[AnimationType.Idle].Add(new Rectangle(54, 2, 23, 33));
            _animations[AnimationType.Idle].Add(new Rectangle(79, 2, 23, 33));
            _animations[AnimationType.Idle].Add(new Rectangle(104, 2, 24, 33));
            _animations[AnimationType.Idle].Add(new Rectangle(129, 1, 25, 34));
            _animations[AnimationType.Idle].Add(new Rectangle(161, 0, 25, 36));
            _animations[AnimationType.Idle].Add(new Rectangle(188, 2, 26, 36));
            _animations[AnimationType.Idle].Add(new Rectangle(220, 1, 23, 35));
            _animations[AnimationType.Idle].Add(new Rectangle(250, 1, 23, 35));
            _animations[AnimationType.Idle].Add(new Rectangle(275, 1, 23, 35));
            _animations[AnimationType.Idle].Add(new Rectangle(300, 1, 24, 35));
            Initilize(new TimeSpan(0, 0, 0, 0, 100), new Vector2(), scale);
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, (int)(30 * scale.X), (int)(38 * scale.Y));

        }

        public void Update(GameTime gameTime, KeyboardState ks, KeyboardState lastKs, List<Platform> platforms)
        {
            AnimationUpdate(gameTime);
            Update(ks, lastKs, platforms);
            if (facingRight)
            {
                if (AnimationType.Idle == _animType)
                {
                    _effects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    _effects = SpriteEffects.None;
                }
            }
            else
            {
                if (_animType == AnimationType.Idle)
                {
                    _effects = SpriteEffects.None;
                }
                else
                {
                    _effects = SpriteEffects.FlipHorizontally;
                }
            }
            _origin = new Vector2(0, _animations[_animType][_currentFrame].Height);
            _hitbox.X = (int)(_position.X - (_origin.X * _scale.X));
            _hitbox.Y = (int)(_position.Y - (_origin.Y * _scale.Y));

        }
        public void DrawRectangle(SpriteBatch spritebatch, GraphicsDevice graphicsDevice)
        {

        }
    }
}
