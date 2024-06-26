using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float width = 1f;
    public float height = 1f;
    [SerializeField] float speed = 1f;
    public bool circle = false;
    Vector2 _initialPosition;
    private float maxX;
    private float maxY;
    private float minX;
    private float minY;
    void Start()
    {
        _initialPosition = transform.position;
        maxX = transform.position.x;
        maxY = transform.position.y;
        minX = maxX;
        minY = maxY;
    }
    void FixedUpdate()
    {
        float x = width * Mathf.Cos(speed * Time.timeSinceLevelLoad);
        float y;
        if (circle)
        {
            y = height * Mathf.Sin(speed * Time.timeSinceLevelLoad);
        }
        else
        {
            y = height * Mathf.Cos(speed * Time.timeSinceLevelLoad);
        }
        Vector2 pos = transform.position;
        pos.x = pos.x + x;
        pos.y = pos.y + y;
        transform.position = pos;
        if(maxX<pos.x)
        {
            maxX = pos.x;
        }
        if(maxY<pos.y)
        {
            maxY = pos.y;
        }
        if (minX>pos.x)
        {
            minX = pos.x;
        }
        if(minY>pos.y)
        {
            minY = pos.y;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&this.gameObject.tag!="Star")
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
