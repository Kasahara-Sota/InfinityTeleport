using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shoot : MonoBehaviour
{
    [SerializeField] Transform m_muzzle = default;
    [SerializeField] int speed;
    public GameObject prefabToSpawn;
    BallController ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position = m_muzzle.transform.position;
            newObject.GetComponent<Rigidbody2D>().AddForce((m_muzzle.position-transform.position).normalized*speed);
        }
        //transform.Translate(0f,-0.01f,0f);
    }
}
