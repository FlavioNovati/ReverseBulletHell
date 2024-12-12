using UnityEngine;

namespace Entity_System.Entity.Enemy
{
    public class Enemy_Controller : Entity_Controller
    {
        private Enemy_Model _model;
        private Enemy_View _view;

        public Enemy_Controller(Enemy_Model model, Enemy_View view) : base(model, view)
        {
            _model = model;
            _view = view;

            _view.gameObject.SetActive(true);
            _view.SetPosition(_model.Position);

            _model.OnViewModeChanged += _view.gameObject.SetActive;
        }

        public override void TickController()
        {
            //Move
            _model.Position = Vector2.MoveTowards(_model.Position, _model.TargetPos, _model.Velocity * Time.time);

            if (!_model.InView)
                return;
            
            UpdateView();
        }

        private void UpdateView()
        {
            _view.SetLookDirection(_model.TargetPos - _model.Position);
            _view.SetPosition(_model.Position);
            _view.SetHealth(_model.HP);
        }

        public override void Enable()
        {

        }

        public override void Disable()
        {
            _view.gameObject.SetActive(false);
        }

        public Vector2 Position
        {
            get => _model.Position;
            set => _model.Position = value;
        }

        public Enemy_Model Model
        {
            get => _model;
            set => _model = value;
        }
    }
}
