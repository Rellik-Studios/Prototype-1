using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{

    [SerializeField] private LayerMask objects;
    private Camera _camera;


    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Clicking down on a object 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //checking if its a evidence object
            if (Physics.Raycast(ray, out RaycastHit hit, objects))
            {
                //Select stage    
                if (hit.collider.TryGetComponent<EvidenceInfo>(out EvidenceInfo evidence))
                {
                    gameManager.Instance.addEvidence(evidence);
                }
            }
        }
    }
}
