using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    /// <summary>
    /// inherit from the sprite class
    /// add a rectangle
    /// create a platform in game1 at the bottom of the screen
    /// position sonic on top of the platform
    /// </summary>
    public class Platform : Sprite
    {
        Rectangle leftHitbox;
        Rectangle rightHitbox;
        Rectangle bottomHitbox;
        Rectangle topHitbox;

        private Rectangle _hitbox;
        private int smallBoxSize = 5;
        public Rectangle Hitbox { get { return _hitbox; } }

        public Platform(Vector2 Position, Texture2D Texture, Vector2 Scale)
            : base(Texture, Position, Scale)
        {
            _hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Texture.Width * Scale.X), (int)(Texture.Height * Scale.Y));
            leftHitbox = new Rectangle((int)Position.X, (int)Position.Y, smallBoxSize, Texture.Height);
            rightHitbox = new Rectangle((int)Position.X + Texture.Width - smallBoxSize, (int)Position.Y, smallBoxSize, Texture.Height);
            bottomHitbox = new Rectangle((int)Position.X, (int)Position.Y + Texture.Height - smallBoxSize, Texture.Width, smallBoxSize);
            topHitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, smallBoxSize);
        }

        public void Update()
        {
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, (int)(_texture.Width * _scale.X), (int)(_texture.Height * _scale.Y));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
