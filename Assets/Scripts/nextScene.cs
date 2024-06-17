using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    string[] StageName = { "StageSelect","1-1","1-2","1-3","2-1","2-2","2-3","2-4" };
    bool load = false;
    
    int w;
    int count;
    int number;
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
            if ((w == 1 && count == 4)||(w==2&&count==5))
            {
                SceneManager.LoadScene("SelectStage");
            }
            else
            SceneManager.LoadScene($"{w}-{count}");
            
            load = true;
            
        }
    }
    public void SceneLoad1()
    {
        SceneManager.LoadScene("1-1");
    }
    public void SceneLoad2()
    {
        SceneManager.LoadScene("2-1");
    }
}
