using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


namespace UIScripts
{
    public class HighScoreUIController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;

        private void OnEnable()
        {
            var root = gameObject.GetComponent<UIDocument>().rootVisualElement;
            root.Q<Button>("Main-Menu").clicked += () =>
            {
                mainMenu.SetActive(true);
                gameObject.SetActive(false);
            };
            root.Q<Label>("Time-Level-0").text = PlayerPrefs.GetString("Level-0", "DNF");
            root.Q<Label>("Time-Level-1").text = PlayerPrefs.GetString("Level-1", "DNF");
            root.Q<Label>("Time-Level-2").text = PlayerPrefs.GetString("Level-2", "DNF");
            root.Q<Label>("Time-Level-3").text = PlayerPrefs.GetString("Level-3", "DNF");
            root.Q<Label>("Time-Level-4").text = PlayerPrefs.GetString("Level-4", "DNF");
        }
    }
}