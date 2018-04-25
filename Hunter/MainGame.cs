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
            graphicsDevice = new GraphicsDeviceManager(this) {PreferMultiSampling = true};
            
            mainScene = new MainScene(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            mainScene.Start();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
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