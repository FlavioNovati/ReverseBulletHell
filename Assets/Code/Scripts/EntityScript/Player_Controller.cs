using UnityEngine;

namespace Entity_System.Entity.Player
{
    public class Player_Controller
    {
        private Player_Model _model;
        private Entity_View _view;

        public Player_Controller(Player_Model model, Entity_View view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {

        }

        public void TickController()
        {

        }

        public void Disable()
        {

        }

        private void UpdateDirection(Vector3 direction) => _model.Direction = direction;
        private void UpdatePosition(Vector3 position) => _model.Position = position;
    }
}
