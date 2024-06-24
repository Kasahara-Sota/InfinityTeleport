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
    //static int _starCount = 0;
    [SerializeField] Text _starCountText;
    [SerializeField] Text _ClearTimeText;

    MyCollisionDetector _playerCollision;

    private void Start()
    {
        string stage = SceneManager.GetActiveScene().name;
        string[] stageNumber = stage.Split('-');
        w = int.Parse(stageNumber[0]);
        count = int.Parse(stageNumber[1]);

        _playerCollision = GameObject.FindObjectOfType<MyCollisionDetector>();
        int time = (int)MyCollisionDetector._timer;
        if (_starCountText != null)
            _starCountText.text = $"{Star.StarCount}�̃L���[�u���W�߂܂���";
        if (_ClearTimeText != null)
            _ClearTimeText.GetComponent<Text>().text = $"�N���A�^�C�� {time/60}:{time%60}";
    }
    //private void Update()
    //{
    //    if (_playerCollision is not null)
    //        Debug.Log($"�ǉ����鐯�̐�{_playerCollision.Count}");
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && load == false)
        {

            Debug.Log($"�ǉ����鐯�̐�{_playerCollision.Count}");
            Star.StarCount += _playerCollision.Count;
            Debug.Log($"�X�e�[�W���ŏW�߂����̐�{Star.StarCount}");
            count++;
            SceneManager.LoadScene($"{w}-{count}");

            load = true;

        }
    }
    public void SelectStage()
    {
        Star.StarCount = 0;
        SceneManager.LoadScene("SelectStage");
    }
    public void SceneLoad1()
    {
        MyCollisionDetector._timer = 0;
        SceneManager.LoadScene("1-1");
    }
    public void SceneLoad2()
    {
        MyCollisionDetector._timer = 0;
        SceneManager.LoadScene("2-1");
    }
}
