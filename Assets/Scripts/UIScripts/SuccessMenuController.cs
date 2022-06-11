using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SuccessMenuController : MonoBehaviour
{

    [SerializeField] private string nextScene;
    private VisualElement _root;
    private void OnEnable()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        BindSuccessMenu();
    }

    private void BindSuccessMenu()
    {
        _root.Q<Label>("Time").text = GameManager.TimePassed;
        _root.Q<Button>("Replay").clicked += () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _root.Q<Button>("MainMenu").clicked += () => SceneManager.LoadScene("MainMenu");

        if(nextScene.CompareTo("-1") == 0)
        {
            _root.Q<Button>("Next-Level").visible = false;
        } 
        else
        {
            _root.Q<Button>("Next-Level").clicked += () => SceneManager.LoadScene(nextScene);

        }
    }
}
