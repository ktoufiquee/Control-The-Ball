using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Vector3[] positionPoints;
    [SerializeField] private float interval = 1;
    private float _lerpPoint = 0;
    private float _pauseTime = 0;
    private int _currPoint = 0;


    private void Update()
    {
        _pauseTime += Time.deltaTime;
        if (_pauseTime < 2.0f)
        {
            return;
        }
        transform.position = Vector3.Lerp(positionPoints[_currPoint], positionPoints[(_currPoint + 1) % positionPoints.Length], _lerpPoint); ;
        _lerpPoint += (interval * Time.deltaTime);
        if (_lerpPoint >= 1.0f)
        {
            _currPoint = (_currPoint + 1) % positionPoints.Length;
            _lerpPoint = 0f;
            _pauseTime = 0f;
        }
    }
}
