using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DeadMenuController : MonoBehaviour
{
    private VisualElement _deadMenuRoot; 

    private void OnEnable()
    {
        BindDeadMenuButtons();
    }

    private void BindDeadMenuButtons()
    {
        _deadMenuRoot = GetComponent<UIDocument>().rootVisualElement;
        _deadMenuRoot.Q<Button>("Restart").clicked += () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _deadMenuRoot.Q<Button>("MainMenu").clicked += () => SceneManager.LoadScene("MainMenu");
    }
}
