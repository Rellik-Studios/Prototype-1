using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class inspectAndAppend : MonoBehaviour
{
    public UnityEvent append;

    public Texture2D cursorDefault;
    public Texture2D cursorHover;

    private GameObject ink;
    [SerializeField] private string text;

    private void Start()
    {
        ink = GameObject.FindGameObjectWithTag("CanvasInspect");
        //ink.gameObject.SetActive(false);
        ink.transform.GetChild(0).gameObject.SetActive(false);
        //Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseEnter()
    {
        //Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        //Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    private IEnumerator OnMouseDown()
    {
        append?.Invoke();
        
        ink.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        var currentText = ink.transform.GetChild(2).GetComponent<TMP_Text>().text;
        ink.transform.GetChild(2).GetComponent<TMP_Text>().text = text;
        yield return new WaitForSeconds(3);
        ink.transform.GetChild(2).GetComponent<TMP_Text>().text = currentText;
        ink.transform.GetChild(0).gameObject.SetActive(false);
        //if (append is { }) Destroy(this.gameObject);
    }
}
