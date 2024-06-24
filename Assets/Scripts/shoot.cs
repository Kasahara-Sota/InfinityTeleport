using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shoot : MonoBehaviour
{
    [SerializeField] Transform m_muzzle = default;
    public int speed;
    public GameObject prefabToSpawn;
    BallController ball;
    public float timer = 0;
    public float interval = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&&timer>=interval)
        {
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);

            newObject.transform.position = m_muzzle.transform.position;
            newObject.GetComponent<Rigidbody2D>().AddForce((m_muzzle.position-transform.position).normalized*speed);
            timer = 0;
        }
        timer += Time.deltaTime;
        //transform.Translate(0f,-0.01f,0f);
    }
}
