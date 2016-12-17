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
        protected Vector2 _origin;
        protected Vector2 _scale;
        protected TimeSpan _animationTime;
        protected TimeSpan _elapsedTime;
        protected SpriteEffects _effects;
        protected AnimationType _animType;
        protected AnimationType _lastAnimation;
        protected Dictionary<AnimationType, List<Rectangle>> _animations;
        protected int Gamespeed = 5;
        private int frameDifference = 1;

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

        protected void AnimationUpdate(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime >= _animationTime)
            {
                _currentFrame += frameDifference;

                if (_currentFrame >= _animations[_animType].Count)
                {
                    frameDifference *= -1;
                    _currentFrame += frameDifference;
                }
                else if (_currentFrame <= 0)
                {
                    frameDifference *= -1;
                    _currentFrame += frameDifference;
                }

                _elapsedTime = TimeSpan.Zero;
            }
        }

        public void Update(KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.A))
            {
                _position.X -= Gamespeed;
                _effects = SpriteEffects.FlipHorizontally;
                _animType = AnimationType.Walking;

                if (_lastAnimation != _animType)
                {
                    _currentFrame = 0;
                }
            }
            else if (ks.IsKeyDown(Keys.D))
            {
                if (_effects == SpriteEffects.FlipHorizontally)
                {
                    _effects = SpriteEffects.None;
                }
                //set moving animation
                _position.X += Gamespeed;
                _animType = AnimationType.Walking;

                if (_lastAnimation != _animType)
                {                    
                    _currentFrame = 0;
                }
            }
            else
            {
                _animType = AnimationType.Idle;

                if (_lastAnimation != _animType)
                {                    
                    _currentFrame = 0;
                }
            }

            _lastAnimation = _animType;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _animations[_animType][_currentFrame], Color.White, 0, _origin, _scale, _effects, 0);
        }
    }
}
