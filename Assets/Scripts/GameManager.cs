using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private GameObject _ball;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float deadZone;
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private int life;
    [SerializeField] private GameObject deadUI;
    [SerializeField] private GameObject hudUI;
    [SerializeField] private GameObject successUI;
    private Transform _ballTransform;
    private Rigidbody _ballRigidBody;
    private VisualElement _hudRoot;
    private Label _timePassedLabel;
    private VisualElement _lifeContainer;
    private DateTime _startingTime;
    public static string TimePassed { get; set; }
    private AudioManager _audioManager;


    private void OnEnable()
    {
        _hudRoot = hudUI.GetComponent<UIDocument>().rootVisualElement;
        _timePassedLabel = _hudRoot.Q<VisualElement>("Time-Container").Q<Label>("Time-Label");
        _lifeContainer = _hudRoot.Q<VisualElement>("Health-Container");
    }

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _audioManager.PlaySound("Theme");
        _ball = GameObject.FindGameObjectWithTag("Player");
        _startingTime = DateTime.Now;
        _ballTransform = _ball.GetComponent<Transform>();
    }

    private void Update()
    {
        if (_ballTransform.position.y < deadZone && !successUI.activeSelf)
        {
            if (life <= 0)
            {
                _ball.SetActive(false);
                deadUI.SetActive(true);
                hudUI.SetActive(false);
                Debug.Log("Dead UI Activated");
            }
            else
            {
                life -= 1;
                UpdateHUDLife();
                Destroy(_ball);
                _ball = Instantiate(ballPrefab, respawnPoint, Quaternion.identity);
                _ballTransform = _ball.transform;
            }
        }
        UpdateHUDTime();
    }

    private void UpdateHUDTime()
    {
        if (!hudUI.activeSelf) return;
        var timePassed = DateTime.Now - _startingTime;
        TimePassed = new TimeSpan(timePassed.Hours, timePassed.Minutes, timePassed.Seconds).ToString("c");
        _timePassedLabel.text = TimePassed;
    }

    private void UpdateHUDLife()
    {
        var lifeContainerName = "Life-" + life;
        _lifeContainer.Q<VisualElement>(lifeContainerName).visible = false;
    }
    
}
