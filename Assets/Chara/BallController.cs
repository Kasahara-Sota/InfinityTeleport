using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 pos;
    shoot shoot;
    Turn turn;
    [SerializeField] GameObject _spawnPrefav;
    void Start()
    {
        shoot = FindFirstObjectByType<shoot>();
        turn = FindFirstObjectByType<Turn>();
        pos = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map") || collision.gameObject.CompareTag("Door")||collision.gameObject.CompareTag("Star"))
        {
            Vector2 normal = collision.contacts[0].normal;
            this.pos = this.transform.position;
            GameObject player = GameObject.FindWithTag("Player");
            Instantiate(_spawnPrefav, pos, Quaternion.identity);
            if(player != null)
            {
                player.transform.position = pos + new Vector2(normal.x * 0.4f, normal.y * 0.4f);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            AudioSource audio = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audio.clip, Vector3.zero);
            Destroy(this.gameObject);
            shoot.timer +=shoot.interval;
            turn.timer += turn._interval;
        }
    }
}
