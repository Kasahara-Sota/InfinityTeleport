using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    bool load = false;
    
    int w;
    int count;
    static int _starCount;
    [SerializeField] PlaterCollision _playerCollision;
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
            _starCount = _playerCollision._count;
            count++;
            SceneManager.LoadScene($"{w}-{count}");
            
            load = true;
            
        }
    }
    public void SelectStage()
    {
        _starCount = 0;
        SceneManager.LoadScene("SelectStage");
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
