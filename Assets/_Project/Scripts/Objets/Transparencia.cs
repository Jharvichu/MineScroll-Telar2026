using Player;
using UnityEngine;

public class Transparencia : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private SpriteRenderer transparenciaSprite;
    [SerializeField, Range(0.0f, 1f)] private float alpha;
    private PlayerController playerController;
    private void Awake()
    {
        if(transparenciaSprite == null) transparenciaSprite = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerController = other.gameObject.GetComponent<PlayerController>();
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerController != null && playerController.isHidden)
        {
            SetAlpha(alpha);
        }
        else if (playerController != null && !playerController.isHidden)
        {
            SetAlpha(1);
        }
    }
    
    private void SetAlpha(float alpha)
    {
        if (transparenciaSprite != null)
        {
            Color color = transparenciaSprite.color;
            color.a = alpha;
            transparenciaSprite.color = color;
        }
    }
}
