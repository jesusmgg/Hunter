using Hunter.ECS;
using Microsoft.Xna.Framework;
using GameComponent = Hunter.Engine.Components.Base.GameComponent;

namespace Hunter.Engine.Entities.Base
{
    public class GameObject : Entity
    {
        public GameTime gameTime;
        
        public GameObject(MainGame game=null)
        {
            if (game == null)
            {
                this.game = parent?.game;
            }
        }
        
        public void AddComponent(GameComponent component, bool startImmediately=true)
        {
            base.AddComponent(component);
            component.gameObject = this;

            if (startImmediately && !component.started)
            {
                component.Start();
                component.started = true;
            }
        }

        public void RemoveComponent(GameComponent component)
        {
            base.RemoveComponent(component);
            component.gameObject = null;
        }
        
        public void AddChild(GameObject gameObject)
        {
            base.AddChild(gameObject);
            gameObject.game = game;
        }

        public void RemoveChild(GameObject gameObject)
        {
            base.RemoveChild(gameObject);
            gameObject.game = null;
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            this.gameTime = gameTime;
        }
    }
}