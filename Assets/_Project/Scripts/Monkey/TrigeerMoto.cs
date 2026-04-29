using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigeerMoto : MonoBehaviour
{
    public List<MotoMove> motos = new List<MotoMove>();
    public float duracionEscena = 2f; // ajusta esto

    public void ActivarMotos(PlayerController controller)
    {
        StartCoroutine(SecuenciaMotos(controller));
    }

    IEnumerator SecuenciaMotos(PlayerController controller)
    {
        // 🔒 Bloquear jugador
        if (controller != null)
        {
            controller.canControl = false;
            
           
            controller.Rigidbody2D.linearVelocity = Vector2.zero;
            controller.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }

        // 🚀 Activar motos
        foreach (MotoMove moto in motos)
        {
            moto.ActivateMoto(controller);
        }

        // ⏳ Esperar a que termine la escena
        yield return new WaitForSeconds(duracionEscena);

        // 🔓 Devolver control
        if (controller != null)
        {
            controller.canControl = true;
        
         
            controller.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        Destroy(gameObject);
    }
}