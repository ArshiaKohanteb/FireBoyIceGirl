using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    public class Sprite
    {
        protected Texture2D _texture;
        protected Vector2 _position;
        protected SpriteEffects _effects;
        protected Vector2 _origin;
        protected Vector2 _scale;

        public float Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }
        public float X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
            }
        }


        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            _origin = new Vector2(0, 0);
            _effects = SpriteEffects.None;
            _scale = new Vector2(1, 1);
        }

        public Sprite(Texture2D texture, Vector2 position, Vector2 scale)
        {
            _texture = texture;
            _position = position;
            _origin = new Vector2(0, 0);
            _effects = SpriteEffects.None;
            _scale = scale;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f, _origin, _scale, _effects, 0);
        }
    }
}
