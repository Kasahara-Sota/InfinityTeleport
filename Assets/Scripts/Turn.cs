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
        // �v���C���[�̃X�N���[�����W���v�Z����
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // �v���C���[���猩���}�E�X�J�[�\���̕������v�Z����
        var direction = Input.mousePosition - screenPos;

        // �}�E�X�J�[�\�������݂�������̊p�x���擾����
        var angle = GetAngle(Vector3.zero, direction);

        // �v���C���[���}�E�X�J�[�\���̕���������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle;
        transform.localEulerAngles = angles;
    }

    public static float GetAngle(Vector2 from, Vector2 to)
    {
        // �w�肳�ꂽ2�̈ꂩ��p�x�����߂�
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
