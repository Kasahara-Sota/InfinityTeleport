using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopPlatform : MonoBehaviour
{
    [SerializeField] Vector2 pos1;
    [SerializeField] Vector2 pos2;
    [SerializeField] float speed_x;
    [SerializeField] float speed_y;
    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
        if (pos1.x > pos2.x)
        {
            float x = pos1.x;
            pos1.x = pos2.x;
            pos2.x = x;
        }
        if (pos1.y > pos2.y)
        {
            float y = pos1.y;
            pos1.y = pos2.y;
            pos2.y = y;
        }
        //pos2.x　右
        //pos1.x 左
        //pos2.y　上
        //pos1.y　下
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos.x += speed_x;
        pos.y += speed_y;
        if (pos.x < pos1.x-1)
        {
            pos.x = pos2.x - 1;
            Debug.Log("右に");
        }
        else if (pos.x > pos2.x+1)
        {
            pos.x = pos1.x + 1;
            Debug.Log("左に");
        }
        if (pos.y < pos1.y-1)
        {
            pos.y = pos2.y-1;
            Debug.Log("上に");
        }
        else if (pos.y > pos2.y+1)
        {
            pos.y = pos1.y+1;
            Debug.Log("下に");
        }
        transform.position = pos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
        Debug.Log("a");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
