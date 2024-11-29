using UnityEngine;

namespace Entity_System.Entity
{
    public class Entity_SO : ScriptableObject
    {
        [Header("Entity")]
        [SerializeField, Min(0)] public float HP = 15f;
        [SerializeField] public float Velocity = 5f;
    }
}
