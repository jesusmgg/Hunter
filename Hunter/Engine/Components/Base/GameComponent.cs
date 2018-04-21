using Hunter.ECS;
using Hunter.Engine.Entities.Base;

namespace Hunter.Engine.Components.Base
{
    public class GameComponent : Component
    {
        public GameObject gameObject;

        public GameComponent()
        {
            gameObject = (GameObject) entity;
        }
    }
}