using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ‚ ‚½‚è”»’è‚ð‚·‚é‚¨
/// </summary>
public class MyCollisionDetector : MonoBehaviour
{
    public int Count;
    [SerializeField] Vector2 SpawnPosition;
    public static float _timer = 0;
    void Update()
    {
        _timer += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            Count++;
            Destroy(collision.gameObject);
            Debug.Log($"GetStar:{Count}");
        }
    }
}
