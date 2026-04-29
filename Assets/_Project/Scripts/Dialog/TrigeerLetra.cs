using Player;
using UnityEngine;

public class TrigeerLetra : MonoBehaviour
{
    public GameObject popupW;
    public TrigeerMoto triggerMoto; // 👈 referencia al script de motos

    private bool esperandoW = false;
    private PlayerController controller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.canControl = false;
                controller.Rigidbody2D.linearVelocity = Vector2.zero;
            }

            popupW.SetActive(true);

            if (AudioManager.Instance != null)
                AudioManager.Instance.SetBGMParameter("QuickTimeEvent", 1f);

            esperandoW = true;
        }
    }

    void Update()
    {
        if (esperandoW && Input.GetKeyDown(KeyCode.W))
        {
            popupW.SetActive(false);

            if (AudioManager.Instance != null)
                AudioManager.Instance.SetBGMParameter("QuickTimeEvent", 0f);

          
            if (triggerMoto != null)
            {
                triggerMoto.ActivarMotos(controller);
            }

           

            esperandoW = false;
            Destroy(gameObject);
        }
    }
}