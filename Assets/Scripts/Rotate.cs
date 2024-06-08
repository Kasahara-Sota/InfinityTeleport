using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed;
    float rotatez;
    private void Start()
    {
        rotatez = GetComponent<Transform>().transform.rotation.z;
    }
    
    void Update()
    {
        
        
        rotatez += speed;
        transform.rotation = Quaternion.Euler(0, 0, rotatez);
        Debug.Log(rotatez);
    }
}
