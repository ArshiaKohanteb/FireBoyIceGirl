using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    public class Sonic : AnimatedSprite
    {
        /// <summary>
        /// 2 6 29 39
        /// 33 7 30 38
        /// 63 7 29 38
        /// 92 7 30 38
        /// </summary>
        

        public Sonic(Texture2D texture, Vector2 position, Vector2 scale)
            :base(texture, position)
        {
            _animations.Add(AnimationType.Idle, new List<Rectangle>());
            _animations[AnimationType.Idle].Add(new Rectangle(2, 6, 29, 39));
            _animations[AnimationType.Idle].Add(new Rectangle(33, 7, 30, 38));
            _animations[AnimationType.Idle].Add(new Rectangle(63,7,29,38));
            _animations[AnimationType.Idle].Add(new Rectangle(92,7,30,38));
            _animations.Add(AnimationType.Walking, new List<Rectangle>());
            _animations[AnimationType.Walking].Add(new Rectangle(4, 50, 24, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(32, 50, 36, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(71, 49, 29, 38));
            _animations[AnimationType.Walking].Add(new Rectangle(106, 50, 26, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(137, 50, 37, 37));
            _animations[AnimationType.Walking].Add(new Rectangle(179, 49, 32, 38));
            Initilize(new TimeSpan(0, 0, 0, 0, 100), new Vector2(), scale);
        }

        public void Update(GameTime gameTime, KeyboardState ks)
        {
            AnimationUpdate(gameTime);
            Update(ks);
        }
    }
}
