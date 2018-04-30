using Hunter.Game.Entities.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hunter
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        MainScene mainScene;
        
        public GraphicsDeviceManager graphicsDevice;
        public SpriteBatch spriteBatch;
        
        public MainGame()
        {
            System.Console.WriteLine("Starting game.");
            graphicsDevice = new GraphicsDeviceManager(this) {PreferMultiSampling = true};
            Content.RootDirectory = "Assets";
            
            mainScene = new MainScene(this);
        }

        protected override void Initialize()
        {
            System.Console.WriteLine("Calling main Start method.");
            base.Initialize();
            
            mainScene.Start();
        }

        protected override void LoadContent()
        {
            System.Console.WriteLine("Calling main LoadContent method.");
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            mainScene.LoadContent();
        }

        protected override void UnloadContent()
        {
            System.Console.WriteLine("Calling main UnloadContent method.");
            mainScene.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
            {
                Exit();
            }
            
            mainScene.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            mainScene.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}