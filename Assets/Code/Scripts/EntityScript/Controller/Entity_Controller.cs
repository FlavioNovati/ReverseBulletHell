namespace Entity_System.Entity
{
    public abstract class Entity_Controller
    {
        public Entity_Controller(Entity_Model model, Entity_View view)
        {

        }

        public abstract void Enable();
        public abstract void Disable();
        public abstract void TickController();
    }

}