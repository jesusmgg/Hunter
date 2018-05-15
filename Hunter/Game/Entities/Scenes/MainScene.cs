using Hunter.Engine.Entities.Scenes;
using Hunter.Game.Components.Controllers;
using Hunter.Game.Entities.Controllers;

namespace Hunter.Game.Entities.Scenes
{
    public class MainScene : Scene
    {
        public MainScene(MainGame game) : base(game)
        {
            // Main game controller
            MainController mainController = new MainController();
            mainController.AddComponent(new GameController(), false);
            AddChild(mainController);
        }
    }
}