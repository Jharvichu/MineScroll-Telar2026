using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalBlack : MonoBehaviour
{
    public SpriteRenderer imagen;
    public TextMeshProUGUI texto;

    [Header("Tiempos")]

    public float esperaAntesImagen = 1f;
    public float esperaAntesTexto = 2f;
    public float esperaFinal = 2f;
 

    [Header("Velocidades de Fade")]
    public float velocidadImagen = 1.5f;
    public float velocidadTexto = 1f;

    [Header("Escena")]
    public string nombreEscena;

    void Start()
    {
        StartCoroutine(Secuencia());
    }

    
    IEnumerator Secuencia()
    {
        // Estado inicial
        SetAlpha(imagen, 0);
        SetAlpha(texto, 0);

        // ⏳ Espera antes de la imagen
        yield return new WaitForSeconds(esperaAntesImagen);

        // 🖼️ Imagen aparece lentamente
        yield return StartCoroutine(FadeSprite(imagen, 0, 1, velocidadImagen));

        // ⏳ Espera antes del texto
        yield return new WaitForSeconds(esperaAntesTexto);

        // 📝 Texto aparece lentamente
        yield return StartCoroutine(FadeUI(texto, 0, 1, velocidadTexto));

        // ⏳ Espera final
        yield return new WaitForSeconds(esperaFinal);

        // 🌑 Desaparecen juntos
        StartCoroutine(FadeSprite(imagen, 1, 0, velocidadImagen));
        yield return StartCoroutine(FadeUI(texto, 1, 0, velocidadTexto));

        SceneManager.LoadScene(nombreEscena);
    }

    IEnumerator FadeUI(Graphic graphic, float a0, float a1, float velocidad)
    {
        float t = 0;
        Color c = graphic.color;

        while (t < 1)
        {
            t += Time.deltaTime * velocidad;
            c.a = Mathf.Lerp(a0, a1, t);
            graphic.color = c;
            yield return null;
        }

        c.a = a1;
        graphic.color = c;
    }

    IEnumerator FadeSprite(SpriteRenderer sprite, float a0, float a1, float velocidad)
    {
        float t = 0;
        Color c = sprite.color;

        while (t < 1)
        {
            t += Time.deltaTime * velocidad;
            c.a = Mathf.Lerp(a0, a1, t);
            sprite.color = c;
            yield return null;
        }

        c.a = a1;
        sprite.color = c;
    }

    void SetAlpha(SpriteRenderer s, float a)
    {
        Color c = s.color;
        c.a = a;
        s.color = c;
    }

    void SetAlpha(Graphic g, float a)
    {
        Color c = g.color;
        c.a = a;
        g.color = c;
    }
}