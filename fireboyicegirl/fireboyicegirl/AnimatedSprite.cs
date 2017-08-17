using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    public abstract class AnimatedSprite : Sprite
    {
        protected int _currentFrame;
        protected TimeSpan _animationTime; 
        protected TimeSpan _elapsedTime;
        protected Rectangle _hitbox;
        protected AnimationType _animType;
        protected AnimationType _lastAnimation;
        protected Dictionary<AnimationType, List<Rectangle>> _animations; //future note: List<Frames>, Frame: rectangle, origin
        protected int Gamespeed = 5;

        public Rectangle Hitbox { get { return _hitbox; } }

        public AnimatedSprite(Texture2D image, Vector2 position)
            : base(image, position)
        {
            _currentFrame = 0;
            _elapsedTime = TimeSpan.Zero;
            _effects = SpriteEffects.None;
            _animType = AnimationType.Idle;
            _animations = new Dictionary<AnimationType, List<Rectangle>>();
        }

        protected void Initilize(TimeSpan frameTime, Vector2 origin, Vector2 scale)
        {
            _animationTime = frameTime;
            _origin = origin;
            _scale = scale;
        }

        protected virtual void AnimationUpdate(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime <= _animationTime)
            {
                _currentFrame++;
                _elapsedTime = TimeSpan.Zero;

                if (_currentFrame >= _animations[_animType].Count)
                {
                    _currentFrame = 0;
                }
            }
        }

        public override void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(_texture, _position, _animations[_animType][_currentFrame], Color.White, 0f, _origin, _scale, _effects, 0f);
        }
    }
}
