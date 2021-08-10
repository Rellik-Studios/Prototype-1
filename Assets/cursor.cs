using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorHover;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
