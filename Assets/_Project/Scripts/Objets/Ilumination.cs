using UnityEngine;

public class Ilumination : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private SpriteRenderer illuminationSprite;
    [SerializeField, Range(0.1f, 10f)] private float maxDistance = 2.0f;

    private void Awake()
    {
        if(illuminationSprite == null) illuminationSprite = GetComponent<SpriteRenderer>();
        SetAlpha(0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            float distance = Vector2.Distance(transform.position, other.transform.position);
            
            float alpha = 1.0f - Mathf.Clamp01(distance / maxDistance);
            
            SetAlpha(alpha);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SetAlpha(0);
        }
    }

    private void SetAlpha(float alpha)
    {
        if (illuminationSprite != null)
        {
            Color color = illuminationSprite.color;
            color.a = alpha;
            illuminationSprite.color = color;
        }
    }
}
