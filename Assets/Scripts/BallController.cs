using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 700.0f;
    private Rigidbody _rigidbody;
    private Sound _ballRollSound;
    
    private void Start()
    {
        _ballRollSound = GameObject.Find("AudioManager").GetComponent<AudioManager>().GetAudioReference("BallRolling");
        _ballRollSound.Source.Play();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var addedForce = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        _rigidbody.AddForce(addedForce);
        var topVelocity = ((addedForce.magnitude / _rigidbody.drag) - Time.fixedDeltaTime * addedForce.magnitude) / _rigidbody.mass;
        //var vol = Mathf.Abs(_rigidbody.velocity.x / topVelocity) + Mathf.Abs(_rigidbody.velocity.z / topVelocity);
        //_ballRollSound.Source.volume = Mathf.Clamp(_rigidbody.velocity.magnitude / topVelocity, 0f, 0.25f);
        _ballRollSound.Source.volume = Mathf.InverseLerp(0, topVelocity, _rigidbody.velocity.magnitude) * 0.25f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.gameObject.transform, true);
        }
        else
        {
            transform.SetParent(null, true);
        }
    }

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.CompareTag("MovingPlatform"))
    //    {
    //        transform.SetParent(null, true);
    //    }
    //}
}
