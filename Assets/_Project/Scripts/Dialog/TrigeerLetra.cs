using Player;
using System.Collections;
using UnityEngine;

public class TrigeerLetra : MonoBehaviour
{
    public GameObject popup;          // popup W
    public GameObject popupSalida;    // popup S

    public KeyCode tecla;

    public TrigeerMoto triggerMoto;
    public bool esSalidaEscondite;

    private bool esperando = false;
    private bool esperandoS = false;

    private bool yaPuedeSalir = false;

    private PlayerController controller;

    private void Start()
    {
        // 🔥 escuchar cuando terminan las motos
        if (triggerMoto != null)
            triggerMoto.OnFinishedMotos += ActivarPopupS;
    }

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

            popup.SetActive(true); // 🔥 aparece W
            esperando = true;
        }
    }

    void Update()
    {
        // 🔥 INPUT W
        if (esperando && Input.GetKeyDown(tecla))
        {
            popup.SetActive(false);

            if (controller != null)
                controller.canControl = true;

            StartCoroutine(ExecuteAction());
            esperando = false;
        }

        // 🔥 INPUT S (FINAL)
        if (esperandoS && Input.GetKeyDown(KeyCode.S))
        {
            if (!yaPuedeSalir) return;
            popupSalida.SetActive(false);

            if (controller != null)
            {
                controller.isHidden = false;
                controller.Animator.SetBool("isHidden", false);
                controller.canControl = true;
            }

            esperandoS = false;

            Destroy(gameObject); // 🔥 SOLO AQUÍ se elimina el trigger
        }
    }

    IEnumerator ExecuteAction()
    {
        yield return new WaitForSeconds(0.1f);

        if (controller != null)
        {
            controller.canControl = false;
            Input.ResetInputAxes();
        }

        // 🔥 CASO MOTOS
        if (triggerMoto != null)
        {
            triggerMoto.ActivarMotos(controller);
        }
    }

    // 🔥 SE LLAMA CUANDO TERMINAN LAS MOTOS
    void ActivarPopupS()
    {
        if (popupSalida != null)
            popupSalida.SetActive(true);

        esperandoS = true; // ahora puede presionar S
        yaPuedeSalir = true;
    }
}