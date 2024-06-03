using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("a");
        pos = this.transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = pos;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        Destroy(this.gameObject);
    }
}
