using System;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform toFollow;
    [SerializeField] private Vector3 offset;
    

    private void Update()
    {
        if (toFollow == null)
        {
            var _playerObject = GameObject.FindGameObjectWithTag("Player");
            toFollow = _playerObject.transform;
        }
        transform.position = toFollow.position - offset;
    }
}
