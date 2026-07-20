using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class GameOverAtras : MonoBehaviour

{
    public GameObject transition;
    public float transitionTime = 1f;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Botón Try Again
        root.Q<Button>("tryagain-button").clicked += () =>
        {
            string lastLevel = PlayerPrefs.GetString("LastLevel");
            StartCoroutine(Transicion(lastLevel));
        };
        
        // Botón exit Menu
        root.Q<Button>("menu-button").clicked += () =>
        {
            string lastLevel = "MainMenu";
            StartCoroutine(Transicion(lastLevel));
        };
        
        // Botón siguiente nivel
        root.Q<Button>("next-button").clicked += () =>
        {
            string lastLevel = "Intermedio1";
            StartCoroutine(Transicion(lastLevel));
        };
    }
    IEnumerator Transicion(string escena)
    {
        transition.SetActive(true);

        CanvasGroup canvasGroup = transition.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = transition.AddComponent<CanvasGroup>();

        float elapsed = 0f;
        canvasGroup.alpha = 0f;

        // FADE IN
        while (elapsed < transitionTime)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / transitionTime);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        SceneManager.LoadScene(escena);
    }
}
