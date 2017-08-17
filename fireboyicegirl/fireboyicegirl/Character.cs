using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    public class Character : AnimatedSprite
    {
        Keys leftKey;
        Keys rightKey;
        Keys jumpKey;
        private int frameDifference = 1;
        protected bool facingRight;
        bool inAir = false;
        float velocity = 0;
        const float gravity = 0.5f;
        const float jumpPower = -15;
        public float Ground;
        Rectangle feetHitbox;


        public Character(Texture2D image, Vector2 position, Keys leftKey, Keys rightKey, Keys jumpKey)
            : base(image, position)
        {
            Ground = position.Y;
            facingRight = true;
            this.leftKey = leftKey;
            this.rightKey = rightKey;
            this.jumpKey = jumpKey;

        }

        protected override void AnimationUpdate(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_animType == AnimationType.Idle)
            {
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
            else if (_animType == AnimationType.Walking || _animType == AnimationType.Jumping)
            {
                if (_elapsedTime >= _animationTime)
                {
                    _currentFrame += 1;
                    _elapsedTime = TimeSpan.Zero;

                    if (_currentFrame >= _animations[_animType].Count)
                    {
                        _currentFrame = 0;
                    }
                }
            }


        }

        public void Update(KeyboardState ks, KeyboardState lastKs, List<Platform> platforms) //pass in the list of platforms
        {
            //hitbox for the feet
            feetHitbox = new Rectangle(
                (int)(_position.X - _origin.X),
                (int)(_position.Y + (_animations[_animType][_currentFrame].Height * _scale.Y) - 20),
                (int)(_animations[_animType][_currentFrame].Width * _scale.X),
                25);

            _position.Y += velocity;
            if (inAir)
            {
                
                velocity += gravity;

                if (velocity > 0) //we are falling
                {
                    //loop through platforms
                    for (int i = 0; i < platforms.Count; i++)
                    {
                        if (feetHitbox.Intersects(platforms[i].Hitbox))
                        {
                            Ground = platforms[i].Y - Hitbox.Height;
                            _position.Y = Ground;   
                            velocity = 0;
                            break;
                        }
                    }
                }

                if (_position.Y >= Ground)
                {
                    _animType = AnimationType.Idle;
                    inAir = false;
                    _position.Y = Ground;
                }
            }
            else
            {
                 

                //loop through platforms
                bool onPlatform = false;
                for (int i = 0; i < platforms.Count; i++)
                {
                    if (feetHitbox.Intersects(platforms[i].Hitbox))
                    {
                        onPlatform = true;
                        _position.Y = platforms[i].Y - Hitbox.Height;
                        break;
                    }
                }

                if (onPlatform == false)
                {
                    inAir = true;
                    Ground = 1000;
                }
            }


            if (ks.IsKeyDown(leftKey))
            {
                _position.X -= Gamespeed;
                //_effects = SpriteEffects.FlipHorizontally;
                facingRight = false;
                if (!inAir)
                {
                    _animType = AnimationType.Walking;
                }
            }
            else if (ks.IsKeyDown(rightKey))
            {
                if (_effects == SpriteEffects.FlipHorizontally)
                {
                    //_effects = SpriteEffects.None;
                    facingRight = true;
                }
                // moving animation
                _position.X += Gamespeed;

                if (!inAir)
                {
                    _animType = AnimationType.Walking;
                }
            }
            else if (ks.IsKeyUp(rightKey) && ks.IsKeyUp(leftKey) && !inAir)
            {
                _animType = AnimationType.Idle;
            }


            if (ks.IsKeyDown(jumpKey) && lastKs.IsKeyUp(jumpKey) && !inAir)
            {
                _animType = AnimationType.Jumping;
                velocity = jumpPower;
                inAir = true;
                Ground = 1000;
         
            }

            if (_lastAnimation != _animType)
            {
                _currentFrame = 0;
            }

            _lastAnimation = _animType;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_effects == SpriteEffects.FlipHorizontally && _animType == AnimationType.Idle)
            {
                
            }

            spriteBatch.Draw(_texture, _position, _animations[_animType][_currentFrame], Color.White, 0, _origin, _scale, _effects, 0);
        }
    }
}
