using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Star
{
    private static int _count;

    public static int StarCount
    {
        get { return _count; }
        set
        {

            _count = value;
            Debug.Log($"static count {_count}");
        }
    }
}
