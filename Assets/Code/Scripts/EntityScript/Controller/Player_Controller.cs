using UnityEngine;

namespace Entity_System.Entity.Player
{
    public class Player_Controller: Entity_Controller
    {
        private Player_Model _model;
        private Entity_View _view;

        public Player_Controller(Player_Model model, Entity_View view): base(model, view)
        {
            _model = model;
            _view = view;
        }

        public override void Enable()
        {

        }

        public override void TickController()
        {
            UpdatePosition(_view.transform.position);
        }

        public override void Disable()
        {

        }

        private void UpdateDirection(Vector3 direction) => _model.TargetPos = direction;
        private void UpdatePosition(Vector3 position) => _model.Position = position;
    }
}
