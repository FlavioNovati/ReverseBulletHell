using UnityEngine;

public class Entity_View : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private HealthBar _healthBar;
    
    public void SetPosition(Vector2 position) => transform.position = position;
    public void SetDirection(Vector2 direction) => _spriteRenderer.transform.localEulerAngles = direction;
    public void SetHealth(float percentage) => _healthBar.Progress = percentage;
}
