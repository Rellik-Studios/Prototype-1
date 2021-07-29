using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{

    [SerializeField] private LayerMask objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Clicking down on a object 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //checking if its a evidence object
            if (Physics.Raycast(ray, out RaycastHit hit, objects))
            {

                //Select stage    
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Evidence"))
                {
                    Debug.Log("its a evudence");
                }
            }
        }
    }
}
