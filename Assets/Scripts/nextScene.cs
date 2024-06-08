using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public static int count = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            count++;
            SceneManager.LoadScene($"1-{count}");
        }
    }
}
