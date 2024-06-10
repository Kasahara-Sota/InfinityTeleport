using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    bool load = false;
    
    int w;
    int count;
    private void Start()
    {
        string stage = SceneManager.GetActiveScene().name;
        string[] stageNumber = stage.Split('-');
         w = int.Parse(stageNumber[0]);
         count = int.Parse(stageNumber[1]);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player"&&load==false)
        {
            count++;
            if (w == 1 && count == 4)
            {
                w++;
                count = 1;
            }
            SceneManager.LoadScene($"{w}-{count}");
            load = true;
            
        }
    }
}
