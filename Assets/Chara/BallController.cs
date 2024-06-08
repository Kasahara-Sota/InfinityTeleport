using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 pos;
    shoot shoot;

    void Start()
    {
        shoot = FindFirstObjectByType<shoot>();
        pos = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map") || collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Door"))
        {
            Vector2 normal = collision.contacts[0].normal;
            this.pos = this.transform.position;
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = pos+new Vector2 (normal.x*0.4f,normal.y*0.4f);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(this.gameObject);
            shoot.timer +=shoot.interval;
        }
    }
}
