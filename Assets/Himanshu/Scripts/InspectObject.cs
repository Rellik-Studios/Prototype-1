using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    public float mouseSensitivity;

    private Camera _camera;
    private GameObject ink;
    public GameObject inspectableObject;

    [SerializeField] private GameObject inspecting;

    float xRotation = 0f;

    float yRotation = 0f;
    public Vector2 xRotationLimit = new Vector2(-180f,180f);
    public Vector2 yRotationLimit = new Vector2(-180f,180f);

    // Start is called before the first frame update
    void Start()
    {
        ink = GameObject.FindGameObjectWithTag("CanvasInspect");
        ink.gameObject.SetActive(false);
        
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Begin(string objectToInspect)
    {
        ink.gameObject.SetActive(true);
        ink.transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Camera>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true); 
        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.name.ToLower() == "pivot_" + objectToInspect.ToLower().Replace(" ", "")) 
            {
                child.gameObject.SetActive(true);
                inspecting = child.gameObject;
                if (objectToInspect.ToLower().Replace(" ", "") == "deadbody")
                {
                    xRotationLimit = new Vector2(-40f, 0f);
                    yRotationLimit = new Vector2(-20f, 20f);
                }
                
                else if (objectToInspect.ToLower().Replace(" ", "") == "rippedphoto")
                {
                    xRotationLimit = new Vector2(-180f, 0f);
                    yRotationLimit = new Vector2(-90f, 90f);
                }
                else
                {
                    xRotationLimit = new Vector2(-180f, 180f);
                    yRotationLimit = new Vector2(-180f, 180f);
                }
            }
        }
    }

    public void End()
    { 
        GetComponent<Camera>().enabled = false;
        GameObject.FindObjectOfType<InventorySystem>().UpdatePreview();
        transform.GetChild(0).gameObject.SetActive(false);
        inspecting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            End();
            
        }
        if (Input.GetMouseButton(1))
        {
            
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            
            
            xRotation -= mouseY;
            yRotation += mouseX;
           
            xRotation = Mathf.Clamp(xRotation, xRotationLimit.x, xRotationLimit.y);   
            
             yRotation = Mathf.Clamp(yRotation, yRotationLimit.x, yRotationLimit.y);   
            
            Debug.Log(yRotation);
            
            inspecting.transform.localRotation = (Quaternion.Euler(xRotation, yRotation, 0f));
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            // Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            // //checking if its a evidence object
            // if (Physics.Raycast(ray, out RaycastHit hit))
            // {
            //     if (hit.collider.CompareTag(""))
            //     {
            //         
            //     }
            // }
        }
        
    }
}
