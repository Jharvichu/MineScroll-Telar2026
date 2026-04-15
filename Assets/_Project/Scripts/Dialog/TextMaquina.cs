using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TextMaquina : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI textoArriba;
    public TextMeshProUGUI textoAbajo;

    [Header("Ajustes Generales")]
    public float velocidadLetra = 0.05f;

    [Header("Lógica (Elementos 0 y 1)")]
    public float esperaEntre0y1 = 3f;
    public float esperaAmbosVisiblesPar1 = 3f;

    [Header("Lógica (Elementos 2, 3)")]
    public float esperaParaSegundoTexto = 3f;
    public float duracionTextoArriba = 3f;
    public float duracionTextoAbajo = 5f;

    [Header("Contenido")]
    public List<string> frases;

    [Header("Siguiente Paso")]
    public GameObject objetoDialogoOrilla;
    public bool activarSiguienteScript = false;

    void Start()
    {
        StartCoroutine(SecuenciaMaestra());
    }

    IEnumerator SecuenciaMaestra()
    {
        for (int i = 0; i < frases.Count; i += 2)
        {
            // --- CASO 1: ELEMENTOS 0 Y 1 (Desaparecen juntos) ---
            if (i == 0)
            {
                textoArriba.text = "";
                textoAbajo.text = "";

                yield return StartCoroutine(EscribirTexto(frases[i], textoArriba));
                yield return new WaitForSeconds(esperaEntre0y1);

                if (i + 1 < frases.Count)
                {
                    yield return StartCoroutine(EscribirTexto(frases[i + 1], textoAbajo));
                }

                yield return new WaitForSeconds(esperaAmbosVisiblesPar1);

                // Desaparecen juntos
                textoArriba.text = "";
                textoAbajo.text = "";
                yield return new WaitForSeconds(1f);
            }
            // --- CASO 2: ELEMENTOS 2 EN ADELANTE (Desaparecen individualmente) ---
            else
            {
                // Iniciar arriba
                StartCoroutine(ManejarTextoIndividual(frases[i], textoArriba, 0f, duracionTextoArriba));

                // Esperar para iniciar abajo
                yield return new WaitForSeconds(esperaParaSegundoTexto);

                if (i + 1 < frases.Count)
                {
                    StartCoroutine(ManejarTextoIndividual(frases[i + 1], textoAbajo, 0f, duracionTextoAbajo));
                }

                // Esperamos el tiempo suficiente para que el de abajo termine de borrarse antes de seguir
                yield return new WaitForSeconds(duracionTextoAbajo + 2f);
            }
        }

        // --- FINALIZACIÓN ---
        if (activarSiguienteScript && objetoDialogoOrilla != null)
        {
            yield return new WaitForSeconds(1f);
            objetoDialogoOrilla.SendMessage("IniciarDialogoOrilla", SendMessageOptions.DontRequireReceiver);
        }
    }

    // Corrutina para escritura simple (Lógica 1)
    IEnumerator EscribirTexto(string frase, TextMeshProUGUI componente)
    {
        componente.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            componente.text += letra;
            yield return new WaitForSeconds(velocidadLetra);
        }
    }

    // Corrutina para manejo independiente (Lógica 2)
    IEnumerator ManejarTextoIndividual(string contenido, TextMeshProUGUI componente, float retraso, float tiempoVisible)
    {
        yield return new WaitForSeconds(retraso);

        // Escribir
        componente.text = "";
        foreach (char letra in contenido.ToCharArray())
        {
            componente.text += letra;
            yield return new WaitForSeconds(velocidadLetra);
        }

        yield return new WaitForSeconds(tiempoVisible);

        // Borrar solo este componente
        componente.text = "";
    }
}