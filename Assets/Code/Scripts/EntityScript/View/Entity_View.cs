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
        public void SetLookDirection(Vector2 lookDir)
        {
            lookDir = lookDir.normalized;
            _spriteRenderer.transform.up = lookDir;
        }

        public void SetHealth(float percentage) => _healthBar.Progress = percentage;
    }
}
