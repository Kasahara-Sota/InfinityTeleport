using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraboundsChange : MonoBehaviour
{
    [SerializeField] CameraManager camManager;
    [SerializeField] private float changeTop;
    [SerializeField] private float changebottom;
    [SerializeField] private float changeleft;
    [SerializeField] private float changeright;
    [SerializeField] private bool topChange;
    [SerializeField] private bool bottomChange;
    [SerializeField] private bool leftChange;
    [SerializeField] private bool rightChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (topChange)
        {
            camManager.top = changeTop;
        }
        if (bottomChange)
        {
            camManager.bottom = changebottom;
        }
        if (leftChange)
        {
            camManager.left = changeleft;
        }
        if(rightChange)
        {
            camManager.right = changeright;
        }
    }
}
