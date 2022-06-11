using UnityEngine;
using UnityEngine.UIElements;

namespace UIScripts
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private GameObject levelMenu;
        [SerializeField] private GameObject scoreMenu;
        [SerializeField] private bool isWebCompile;

        private void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            root.Q<Button>("Play").clicked += () =>
            {
                gameObject.SetActive(false);
                levelMenu.SetActive(true);
            };
            root.Q<Button>("High-Scores").clicked += () =>
            {
                gameObject.SetActive(false);
                scoreMenu.SetActive(true);
            };

            if (isWebCompile)
            {
                root.Q<Button>("Exit").visible = false;
            }
            else
            {
                root.Q<Button>("Exit").clicked += Application.Quit;
            }

        }
    }
}
