using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class inspectAndAppend : MonoBehaviour
{
    public UnityEvent append;

    public Texture2D cursorDefault;
    public Texture2D cursorHover;
    private void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDown()
    {
        append?.Invoke();
    }
}
