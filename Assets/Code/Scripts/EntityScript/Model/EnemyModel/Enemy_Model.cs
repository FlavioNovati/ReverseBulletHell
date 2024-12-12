namespace Entity_System.Entity.Enemy
{
    public class Enemy_Model : Entity_Model
    {
        private bool _inView;

        private float _attackDistance;
        private float _attackDamage;
        private float _attackDelay;

        private float _distanceFromTarget;

        public Enemy_Model(Enemy_SO enemySO): base(enemySO)
        {
            _attackDistance = enemySO.AttackDistance;
            _attackDamage = enemySO.AttackDamage;
            _attackDelay = enemySO.AttackDelay;
        }

        public float DistanceFromTarget
        {
            get => _distanceFromTarget;
            set => _distanceFromTarget = value;
        }

        public float AttackDelay => _attackDelay;
        public float AttackDamage => _attackDamage;
        public float AttackDistance => _attackDistance;

        public bool InView
        {
            get => _inView;
            set => _inView = value;
        }
    }
}
