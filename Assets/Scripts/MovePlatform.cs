using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float width = 1f;
    public float height = 1f;
    public float speed = 1f;
    Vector2 _initialPosition;
    void Start()
    {
        _initialPosition = transform.position;
    }
    void FixedUpdate()
    {
        float x = width * Mathf.Cos(speed * Time.timeSinceLevelLoad);
        float y = height * Mathf.Cos(speed * Time.timeSinceLevelLoad);
        Vector2 pos = transform.position;
        pos.x = pos.x + x;
        pos.y = pos.y + y;
        transform.position = pos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            collision.transform.SetParent(null);
        }
    }
}
