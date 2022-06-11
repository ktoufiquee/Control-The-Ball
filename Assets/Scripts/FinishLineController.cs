using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishLineController : MonoBehaviour
{
    [SerializeField] private GameObject successMenu;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var recordTime = PlayerPrefs.GetString(SceneManager.GetActiveScene().name, "23:59:59");
        var currTime = GameManager.TimePassed;
        var tsRecordTime = TimeSpan.Parse(recordTime);
        var tsCurrTIme = TimeSpan.Parse(currTime);
        Debug.Log(recordTime + " : " + currTime);
        if(tsRecordTime > tsCurrTIme)
        {
            Debug.Log("Recorded");
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, currTime);
        }
        if (other.CompareTag("Player"))
        {
            successMenu.SetActive(true);
            _audioManager.SetVolume("Theme", 0.1f);
            _audioManager.PlaySound("Win");
            var hud = GameObject.Find("HUD");
            if(hud != null)
            {
                hud.SetActive(false);
            }
        }
    }
}
