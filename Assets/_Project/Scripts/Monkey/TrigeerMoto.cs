using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigeerMoto : MonoBehaviour
{
    public List<MotoMove> motos = new List<MotoMove>();
    public float duracionEscena = 2f;
    

    private PlayerController controller;
    public System.Action OnFinishedMotos;

    public void ActivarMotos(PlayerController controller)
    {
        this.controller = controller;
        StartCoroutine(SecuenciaMotos());
    }

    IEnumerator SecuenciaMotos()
    {
        // 🔒 bloquear jugador
        if (controller != null)
        {
            controller.canControl = false;
            controller.Rigidbody2D.linearVelocity = Vector2.zero;
            controller.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            Input.ResetInputAxes();
        }

        foreach (MotoMove moto in motos)
        {
            moto.ActivateMoto(controller);
        }

        yield return new WaitForSeconds(duracionEscena);

        OnFinishedMotos?.Invoke();
    }


    }