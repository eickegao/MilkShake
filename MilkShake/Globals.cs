﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MilkShakeFramework
{
    public static class Globals
    {
        // [Screen]
        public const int DefaultScreenHeight = 1280;
        public const int DefaultScreenWidth = 800;

        public static int ScreenWidth;
        public static int ScreenHeight;

        public static int ScreenWidthCenter { get { return (int)ScreenWidth / 2; } }
        public static int ScreenHeightCenter { get { return (int)ScreenHeight / 2; } }
        public static Vector2 SceenCenter { get { return new Vector2(ScreenWidthCenter, ScreenHeightCenter); } }

        // [Render]
        public static Color ScreenColour = new Color(20, 12,24);
        public static bool BackToFrontRender = true;
        public static bool EnabledVSync = true;
        public static int MultiSampleRate = 1;

        // [Physics]
        public static float DisplayUnitToSimUnitRatio = 24f;

        // [Other]
        public static string ContentDirectory = "Content";
        public static bool IsMouseVisible = true;

        // [Helpers]
        public static Random Random = new Random();

        public static RasterizerState WireframeState = new RasterizerState()
        {
            CullMode = CullMode.None,
            FillMode = FillMode.WireFrame
        };
    }
}
