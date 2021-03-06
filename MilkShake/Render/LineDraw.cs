﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilkShakeFramework.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MilkShakeFramework.Core.Scenes;

namespace MilkShakeFramework.Core.Game.Components.Misc
{
    public struct Line
    {
        public Line(Vector2 _a, Vector2 _b)
        {
            A = _a;
            B = _b;
            Color = Color.White;
        }

        public Line(Vector2 _a, Vector2 _b, Color _color)
        {
            A = _a;
            B = _b;
            Color = _color;
        }

        public Vector2 A;
        public Vector2 B;
        public Color Color;
    }

    public class LineDraw : Renderer
    {
        public static Image _lineImage;
        
        private Queue<Line> _lines;
        
        public LineDraw()
        {
            if (_lineImage == null)
            {
                _lineImage = new Image("linetexture");
                AddNode(_lineImage);
            }

            _lines = new Queue<Line>();
        }

        public override void FixUp()
        {
            base.FixUp();

            Scene.Listener.PostDraw[DrawLayer.Fourth] += new DrawEvent(PostDraw);
        }

        public void DrawLine(Vector2 _pointA, Vector2 _pointB, Color _color)
        {
            _lines.Enqueue(new Line(_pointA, _pointB, _color));
        }

        public void DrawRectangle(Rectangle _rectangle, Color _color)
        {
            _lines.Enqueue(new Line(new Vector2(_rectangle.X, _rectangle.Y), new Vector2(_rectangle.X + _rectangle.Width, _rectangle.Y), _color));
            _lines.Enqueue(new Line(new Vector2(_rectangle.X + _rectangle.Width, _rectangle.Y), new Vector2(_rectangle.X + _rectangle.Width, _rectangle.Y + _rectangle.Height), _color));
            _lines.Enqueue(new Line(new Vector2(_rectangle.X, _rectangle.Y + _rectangle.Height), new Vector2(_rectangle.X + _rectangle.Width, _rectangle.Y + _rectangle.Height), _color));
            _lines.Enqueue(new Line(new Vector2(_rectangle.X, _rectangle.Y), new Vector2(_rectangle.X, _rectangle.Y + _rectangle.Height), _color));
        }


        public void PostDraw()
        {
            while (_lines.Count > 0)
            {
                Line currentLine = _lines.Dequeue();

                RenderLines(currentLine.A, currentLine.B, currentLine.Color);
            }
        }

        private void RenderLines(Vector2 _pointA, Vector2 _pointB, Color color)
        {
            _pointA = (_pointA - Scene.Camera.Position);
            _pointB = (_pointB - Scene.Camera.Position);

            Scene.RenderManager.Begin();
            Scene.RenderManager.SpriteBatch.Draw(_lineImage.Texture, _pointA, null, color,
                             (float)Math.Atan2(_pointB.Y - _pointA.Y, _pointB.X - _pointA.X),
                             new Vector2(0f, (float)_lineImage.Texture.Height / 2),
                             new Vector2(Vector2.Distance(_pointA, _pointB), 1f),
                             SpriteEffects.None, 0f);

            Scene.RenderManager.End();
        }
    }
}
