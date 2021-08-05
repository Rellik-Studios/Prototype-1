using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    public float mouseSensitivity;

    private Camera _camera;
    
    public GameObject inspectableObject;

    [SerializeField] private GameObject inspecting;

    float xRotation = 0f;

    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Begin()
    {
        Instantiate(inspectableObject, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
    }

    public void End()
    {
        Destroy(inspecting);        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;
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
