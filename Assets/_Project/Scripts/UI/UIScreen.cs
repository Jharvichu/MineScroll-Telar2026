using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Core
{
    /// <summary>
    /// Clase base abstracta para cualquier pantalla de la interfaz de usuario.
    /// </summary>
    [RequireComponent(typeof(UIDocument))]
    public abstract class BaseUIScreen : MonoBehaviour
    {
        protected UIDocument _doc;
        protected VisualElement _root;

        // [Header("UI Base Settings")]
        // Setting futuras

        protected virtual void Awake()
        {
            _doc = GetComponent<UIDocument>();
        }

        protected virtual void OnEnable()
        {
            _root = _doc.rootVisualElement;
            if (_root == null) return;

            FindUIElements();
            RegisterEvents();
        }

        protected virtual void OnDisable()
        {
            UnregisterEvents();
        }

        // Métodos que CUALQUIER pantalla debe implementar
        protected abstract void FindUIElements();
        protected abstract void RegisterEvents();
        protected abstract void UnregisterEvents();

    }
}
