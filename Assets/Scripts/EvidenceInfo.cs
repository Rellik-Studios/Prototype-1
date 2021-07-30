using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceInfo : MonoBehaviour
{
    public string evidenceName;
    [TextArea]
    public string description;
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CollectEvidence()
    {
        if(!isCollected)
        {
            Information();
            isCollected = true;

        }
    }

    public void Information()
    {
        Debug.Log(evidenceName);
        Debug.Log(description);
    }
}
