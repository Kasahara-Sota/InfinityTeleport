using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.TextCore.Text;

public class Turn : MonoBehaviour
{
    //Transform transform;

    Vector3 mousePos;
    Vector3 target;
    private Vector3 position;

    void Start()
    {
        //transform = transform.GetComponent<Transform>();
    }

    
    void Update()
    {
        // プレイヤーのスクリーン座標を計算する
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // プレイヤーから見たマウスカーソルの方向を計算する
        var direction = Input.mousePosition - screenPos;

        // マウスカーソルが存在する方向の角度を取得する
        var angle = GetAngle(Vector3.zero, direction);

        // プレイヤーがマウスカーソルの方向を見るようにする
        var angles = transform.localEulerAngles;
        angles.z = angle;
        transform.localEulerAngles = angles;
    }

    public static float GetAngle(Vector2 from, Vector2 to)
    {
        // 指定された2つの一から角度を求める
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
