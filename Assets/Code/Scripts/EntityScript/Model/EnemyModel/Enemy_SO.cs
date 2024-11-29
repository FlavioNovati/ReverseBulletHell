using UnityEngine;

namespace Entity_System.Entity.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "scriptable/Entity/Enemy")]
    public class Enemy_SO : Entity_SO
    {
        [Header("Enemy")]
        [SerializeField] private Enemy_View _enemy_View;
        [SerializeField] public float AttackDistance = 1f;
        [SerializeField] public float AttackDamage = 1f;
        [SerializeField] public float AttackDelay = 2f;

        public Enemy_View View => _enemy_View;
    }
}