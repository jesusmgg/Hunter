using System.Collections.Generic;

namespace Hunter.ECS
{
    public abstract class Entity
    {
        public string name;

        public List<Component> components;
        public List<Entity> children;

        Queue<Component> componentsToAdd;
        Queue<Component> componentsToRemove;
        
        Queue<Entity> entitiesToAdd;
        Queue<Entity> entitiesToRemove;

        public Entity parent;

        public MainGame game;

        protected Entity()
        {
            name = "";
            
            components = new List<Component>();
            children = new List<Entity>();
            
            componentsToAdd = new Queue<Component>();
            componentsToRemove = new Queue<Component>();
            entitiesToAdd = new Queue<Entity>();
            entitiesToRemove = new Queue<Entity>();

            parent = null;
        }

        public T GetComponent<T>(string name=null) where T : Component
        {
            if (name != null)
            {
                foreach (var component in components)
                {
                    if (component.name == name)
                    {
                        return (T) component;
                    }
                }

                return null;
            }
            
            foreach (var component in components)
            {
                if (component.GetType() == typeof(T))
                {
                    return (T) component;
                }
            }

            return null;
        }
        
        public void AddComponent(Component component)
        {
            componentsToAdd.Enqueue(component);
            component.entity = this;
        }

        public void RemoveComponent(Component component)
        {
            componentsToRemove.Enqueue(component);
            component.entity = null;
        }

        public void AddChild(Entity entity)
        {
            entitiesToAdd.Enqueue(entity);
            entity.game = game;
            entity.parent = this;
        }
        
        public void RemoveChild(Entity entity)
        {
            entitiesToRemove.Enqueue(entity);
            entity.game = null;
            entity.parent = null;
        }

        void ProcessQueues()
        {
            while (componentsToAdd.Count > 0)
            {
                components.Add(componentsToAdd.Dequeue());
            }
            while (componentsToRemove.Count > 0)
            {
                components.Remove(componentsToAdd.Dequeue());
            }
            while (entitiesToAdd.Count > 0)
            {
                children.Add(entitiesToAdd.Dequeue());
            }
            while (entitiesToRemove.Count > 0)
            {
                children.Remove(entitiesToRemove.Dequeue());
            }
        }

        public void Start()
        {
            foreach (var component in components)
            {
                if (component.enabled && !component.started)
                {
                    component.Start();
                    component.started = true;
                }
            }

            foreach (Entity entity in children)
            {
                entity.Start();
            }
            
            ProcessQueues();
        }
        
        public void Update()
        {
            foreach (var component in components)
            {
                if (component.enabled && !component.started)
                {
                    component.Start();
                    component.started = true;
                }
                
                if (component.enabled)
                {
                    component.Update();
                }
            }

            foreach (Entity entity in children)
            {
                entity.Update();
            }
            
            ProcessQueues();
        }

        public void Draw()
        {
            foreach (var component in components)
            {
                if (component.enabled)
                {
                    component.Draw();
                }
            }

            foreach (Entity entity in children)
            {
                entity.Draw();
            }
        }
    }
}
