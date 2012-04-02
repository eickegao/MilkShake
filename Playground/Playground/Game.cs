using MilkShakeFramework;
using MilkShakeFramework.Core.Scenes;
using Microsoft.Xna.Framework;
using System;
using MilkShakeFramework.Core.Game;
using Microsoft.Xna.Framework.Input;

namespace Playground
{
    public class Playground : MilkShake
    {
        public Playground() : base(1280, 720) 
        {
            
        }

        protected override void Initialize()
        {
            base.Initialize();

            SceneManager.AddScene("BasicScene", new BasicScene());
            SceneManager.ChangeScreen("BasicScene");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        
    }

    public class BasicScene : Scene
    {

        private GameEntity tileGroup;

        public BasicScene() : base()
        {

           
        }

        public override void Setup()
        {
            AddNode(new Sprite("background") { Width = Globals.ScreenWidth, Height = Globals.ScreenHeight });

            tileGroup = new GameEntity();           

            tileGroup.AddNode(new Sprite("Tiles/Dirt Block"));
            tileGroup.AddNode(new Sprite("Tiles/Grass Block") { Position = new Vector2(100, 0) });
            tileGroup.AddNode(new Sprite("Tiles/Grass Block") { Position = new Vector2(200, 0) });
            tileGroup.AddNode(new Sprite("Tiles/Grass Block") { Position = new Vector2(300, 0) });
            tileGroup.AddNode(new Sprite("Tiles/Grass Block") { Position = new Vector2(400, 0) });
            tileGroup.AddNode(new Sprite("Tiles/Dirt Block") { Position = new Vector2(500, 0) });

            AddNode(tileGroup);

            base.Setup();
        }

        public override void Update(GameTime gameTime)
        {            
            base.Update(gameTime);

            tileGroup.Position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            ControlCamera();
        }

        private void ControlCamera()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            Vector2 movementStash = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.D)) movementStash.X++;
            if (keyboardState.IsKeyDown(Keys.A)) movementStash.X--;
            if (keyboardState.IsKeyDown(Keys.W)) movementStash.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) movementStash.Y++;

            Camera.Position = (movementStash * 4) + Camera.Position;
        }
    }
}
