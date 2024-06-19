using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaterCollision : MonoBehaviour
{
    [SerializeField] Vector2 SpawnPosition;
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Enemy")
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = SpawnPosition;
        }
        if(collision.gameObject.tag =="Star")
        {
            Destroy(collision.gameObject);
        }
    }
}
