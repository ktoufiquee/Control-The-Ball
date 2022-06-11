using UnityEngine;

namespace UIScripts
{
    public class TutorialTextSetter : MonoBehaviour
    {
        [SerializeField] private string tutorialText;
        [SerializeField] private GameObject tutorialUI;
        private TutorialUIController _tutorialUIController;
        
        private void Start()
        {
            _tutorialUIController = tutorialUI.GetComponent<TutorialUIController>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                tutorialUI.SetActive(true);
                _tutorialUIController.SetTutorialText(tutorialText);
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                tutorialUI.SetActive(false);
            }
        }
    }
}
