using UnityEngine;

using Entity_System.Entity.UI;
using System;

namespace Entity_System.Entity
{
    public class Entity_View : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private HealthBar _healthBar;
        
        public void SetPosition(Vector2 position) => transform.position = position;
        public void SetDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _spriteRenderer.transform.localEulerAngles = new Vector3(0f, 0f, angle);
        }

        public void SetHealth(float percentage) => _healthBar.Progress = percentage;
    }
}
