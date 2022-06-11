using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIScripts
{
    public class TutorialUIController : MonoBehaviour
    {
        private VisualElement _tutorialUIRoot;

        private void OnEnable()
        {
            _tutorialUIRoot = GetComponent<UIDocument>().rootVisualElement;
        }

        public void SetTutorialText(string text)
        {
            _tutorialUIRoot.Q<Label>("Tutorial-text").text = text;
        }
    }
}