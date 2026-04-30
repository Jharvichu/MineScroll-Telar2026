using Player;
using System.Collections;
using UnityEngine;

public class TrigeerLetra : MonoBehaviour
{
    public GameObject triggerSalidaPrefab;
    public Transform spawnSalidaPoint;

    public GameObject popup;          // UI W
    public KeyCode tecla = KeyCode.W;

    public TrigeerMoto triggerMoto;

    private bool esperando = false;
    private bool yaInicioEvento = false;

    private PlayerController controller;

    private void Start()
    {
        // Escuchar cuando terminan las motos
        if (triggerMoto != null)
            triggerMoto.OnFinishedMotos += FinalizarEvento;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character") && !yaInicioEvento)
        {
            controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.canControl = false;
                controller.Rigidbody2D.linearVelocity = Vector2.zero;
            }

            popup.SetActive(true);
            esperando = true;
        }
    }

    void Update()
    {
        if (esperando && Input.GetKeyDown(tecla))
        {
            popup.SetActive(false);
            esperando = false;

            if (controller != null) controller.canControl = true;

            StartCoroutine(IniciarEvento());
        }
    }

    IEnumerator IniciarEvento()
    {
        yaInicioEvento = true;

        yield return new WaitForSeconds(0.1f);

        if (controller != null)
        {
            controller.canControl = false;
            Input.ResetInputAxes();
        }

        if (triggerMoto != null)
        {
            triggerMoto.ActivarMotos(controller);
        }
    }

    // 🔥 SE EJECUTA CUANDO TERMINAN LAS MOTOS
    void FinalizarEvento()
    {
        if (controller != null)
        {
            controller.canControl = true;
        }
        if (triggerSalidaPrefab != null && spawnSalidaPoint != null)
        {
            GameObject obj = Instantiate(triggerSalidaPrefab, spawnSalidaPoint.position, Quaternion.identity);

            TriggerPopupS s = obj.GetComponent<TriggerPopupS>();

            if (s != null)
            {
                s.Activar(controller); // 🔥 activación directa
            }
        }
        Destroy(gameObject); // elimina el trigger
    }

    private void OnDestroy()
    {
        if (triggerMoto != null)
            triggerMoto.OnFinishedMotos -= FinalizarEvento;
    }

}