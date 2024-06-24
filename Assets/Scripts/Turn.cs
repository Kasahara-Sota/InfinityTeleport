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
    public float timer = 0;
    public float _interval = 0;
    AudioSource m_audio = default;
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
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

        if (Input.GetButtonDown("Fire1") &&timer >= _interval)
        {
            m_audio.Play();
            timer = 0;
        }

        timer += Time.deltaTime;
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
