using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class inspectAndAppend : MonoBehaviour
{
    public UnityEvent append;
    private void OnMouseDown()
    {
        append?.Invoke();
    }
}
