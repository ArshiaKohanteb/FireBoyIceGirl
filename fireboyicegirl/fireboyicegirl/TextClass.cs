using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fireboyicegirl
{
    public class TextClass
    {
        SpriteFont font;
        string text;
        Vector2 position;
        Color color = Color.White;
        public TextClass(SpriteFont font, string text, Vector2 position, Color color)
        {
            this.font = font;
            this.text = text;
            this.position = position;
            this.color = color;
        }

        public void DrawString(SpriteBatch spritebatch)
        {

        }
    }
}
