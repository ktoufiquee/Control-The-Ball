using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private readonly Vector3 _upRight = new Vector3(1, 0, 1);
    
    private void Update()
    {
        transform.Rotate(_upRight * rotationSpeed * Time.deltaTime);
    }
}
