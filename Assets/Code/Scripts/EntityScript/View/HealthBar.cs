using UnityEngine;

namespace Entity_System.Entity.UI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HealthBar: MonoBehaviour
    {
        private Vector3 _initialScale;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _initialScale = _spriteRenderer.transform.localScale;
        }

        public float Progress
        {
            set
            {
                value = Mathf.Clamp01(value);
                Vector3 scale = _initialScale;
                scale.x *= value;
                _spriteRenderer.transform.localScale = scale;

                if(value >= 1f)
                    _spriteRenderer.gameObject.SetActive(false);
                else
                    _spriteRenderer.gameObject.SetActive(true);
            }
        }
    }

}
