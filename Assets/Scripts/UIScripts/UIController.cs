using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UIScripts
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject levelMenu;
    
        private void Start()
        {
            BindMainMenuScreen();
            BindLevelMenuScreen();
            levelMenu.SetActive(false);
        }

        private void BindMainMenuScreen()
        {
            var mainMenuRoot = mainMenu.GetComponent<UIDocument>().rootVisualElement;
            mainMenuRoot.Q<Button>("Play").clicked += () =>
            {
                mainMenu.SetActive(false);
                levelMenu.SetActive(true);
            };
            mainMenuRoot.Q<Button>("Exit").clicked += Application.Quit;
        }

        private void BindLevelMenuScreen()
        {
            var levelMenuRoot = levelMenu.GetComponent<UIDocument>().rootVisualElement;
                // .Q<VisualElement>("ScrollView").Q<ScrollView>("ScrollView")
                // .Q<VisualElement>("unity-content-and-vertical-scroll-container")
                // .Q<VisualElement>("unity-content-viewport")
                // .Q<VisualElement>("unity-content-container")
                // .Q<VisualElement>("ButtonContainer");
            levelMenuRoot.Q<Button>("MainMenu").clicked += () =>
            {
                mainMenu.SetActive(true);
                levelMenu.SetActive(false);
                Debug.Log("Here");
            };
            for (var i = 0; i < 11; ++i)
            {
                levelMenuRoot.Q<Button>("Level" + i).clicked += () => SceneManager.LoadScene("Level-" + i);
            }
            Debug.Log("Done");
        }
    }
}
