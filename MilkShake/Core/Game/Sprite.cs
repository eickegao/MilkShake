﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilkShakeFramework.Render;
using MilkShakeFramework.Core.Content;
using Microsoft.Xna.Framework;

namespace MilkShakeFramework.Core.Game
{
    public class ParalaxSprite : Sprite
    {
        private Vector2 mOriginalPosition;
        private Vector2 mSpeed;

        public ParalaxSprite(string url, float xSpeed = 0.5f, float ySpeed = 1) : base(url)
        {
            mSpeed = new Vector2(xSpeed, ySpeed);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Position = mOriginalPosition + (Scene.Camera.Position * mSpeed);

            base.Update(gameTime);
        }

        public override float X
        {
            get { return base.X; }
            set { mOriginalPosition.X = value; base.X = value; }
        }

        public override float Y
        {
            get { return base.Y; }
            set { mOriginalPosition.Y = value; base.Y = value; }
        }

        public Vector2 Speed { get { return mSpeed; } set { mSpeed = value; } }
    }

    public class Sprite : GameEntity
    {
        private Image mImage;
        private int mWidth, mHeight;
        private float mRotation;
        private Vector2 mOrigin;
        private Vector2 mScale;
        private Color mColor;
        private bool mAutoCenter;

        public Sprite(string url)
        {
            Name = url;

            mImage = new Image(url);
            mColor = Color.White;
            mScale = new Vector2(1, 1);
            mAutoCenter = false;
        }

        public override void Setup()
        {
            AddNode(mImage);

            base.Setup();
        }

        public override void Load(LoadManager content)
        {
            base.Load(content);

            mWidth = SetValueOrDefault(mWidth, mImage.Texture.Width);
            mHeight = SetValueOrDefault(mHeight, mImage.Texture.Height);
        }

        public override void FixUp()
        {
            base.FixUp();

            if(AutoCenter)
            {
                Origin = new Vector2(Width / 2, Height / 2);
            }
        }      

        public override void Draw()
        {
            base.Draw();
            mImage.Draw(WorldPosition, mWidth, mHeight, mRotation, mOrigin, mColor, mScale.X, mScale.Y);
        }

        public Image Image { get { return mImage; } set { mImage = value; } }
        public Color Color { get { return mColor; } set { mColor = value; } }
        public float Alpha { get { return mColor.A; } set { mColor.A = (byte)(value * 255); } }

        public int Width { get { return mWidth; } set { mWidth = value; } }
        public int Height { get { return mHeight; } set { mHeight = value; } }

        public Vector2 Origin { get { return mOrigin; } set { mOrigin = value; } }
        public float Rotation { get { return mRotation; } set { mRotation = value; } }
        public Vector2 Scale { get { return mScale; } set { mScale = value; } }
        public bool AutoCenter { get { return mAutoCenter; } set { mAutoCenter = value; } }

        public Rectangle BoundingBox { get { return new Rectangle((int)Position.X, (int)Position.Y, Width, Height); } }
    }
}
