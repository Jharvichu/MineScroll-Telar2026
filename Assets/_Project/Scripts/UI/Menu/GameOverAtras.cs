using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
using FMODUnity;

public class GameOverAtras : MonoBehaviour

{
    public GameObject transition;
    [SerializeField] EventReference selectSound;
    [SerializeField] EventReference hoverSound;
    public float transitionTime = 1f;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Botón Try Again
        root.Q<Button>("tryagain-button").RegisterCallback<MouseEnterEvent>(_ => AudioManager.Instance.PlaySFX(hoverSound));
        root.Q<Button>("tryagain-button").clicked += () =>
        {
            AudioManager.Instance.PlaySFX(selectSound);
            string lastLevel = PlayerPrefs.GetString("LastLevel");
            StartCoroutine(Transicion(lastLevel));
        };
        
        // Botón exit Menu
        root.Q<Button>("menu-button").RegisterCallback<MouseEnterEvent>(_ => AudioManager.Instance.PlaySFX(hoverSound));
        root.Q<Button>("menu-button").clicked += () =>
        {
            AudioManager.Instance.PlaySFX(selectSound);
            string lastLevel = "MainMenu";
            StartCoroutine(Transicion(lastLevel));
        };
        
        // Botón siguiente nivel
        root.Q<Button>("next-button").RegisterCallback<MouseEnterEvent>(_ => AudioManager.Instance.PlaySFX(hoverSound));
        root.Q<Button>("next-button").clicked += () =>
        {
            AudioManager.Instance.PlaySFX(selectSound);
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
