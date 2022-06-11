using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


namespace UIScripts
{
    public class LevelMenuUIController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;

        private void OnEnable()
        {
            var levelMenuRoot = gameObject.GetComponent<UIDocument>().rootVisualElement;
            levelMenuRoot.Q<Button>("MainMenu").clicked += () =>
            {
                mainMenu.SetActive(true);
                gameObject.SetActive(false);
            };
            levelMenuRoot.Q<Button>("Level0").clicked += () => SceneManager.LoadScene("Level-0");
            levelMenuRoot.Q<Button>("Level1").clicked += () => SceneManager.LoadScene("Level-1");
            levelMenuRoot.Q<Button>("Level2").clicked += () => SceneManager.LoadScene("Level-2");
            levelMenuRoot.Q<Button>("Level3").clicked += () => SceneManager.LoadScene("Level-3");
            levelMenuRoot.Q<Button>("Level4").clicked += () => SceneManager.LoadScene("Level-4");
        }

    }
}
