using System;
using UnityEngine;

namespace Entity_System.Entity
{
    public class Entity_Model
    {
        public Action<float> OnHpChanged;

        private Vector2 _position;
        private Vector2 _direction;

        private float _hp;
        private float _velocity;

        public Entity_Model(Entity_SO entitySO)
        {
            _hp = entitySO.HP;
            _velocity = entitySO.Velocity;
        }

        public virtual void Damage(float damage) => HP -= damage;
        public virtual void Heal(float amount) => HP += amount;

        public float HP
        {
            get => _hp;
            set
            {
                _hp = value;
                OnHpChanged?.Invoke(_hp);
            }
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector2 TargetPos
        {
            get => _direction;
            set => _direction = value;
        }

        public float Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }
    }
}
