using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var vEvidence in collectedEvidences)
            {
               vEvidence.Information();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (var vEvidence in collectedEvidences)
            {
                modifyEvidence(vEvidence, 1);
            } 
        }
    }

    private void Start()
    {
        Instance = this;
        collectedEvidences = new HashSet<EvidenceInfo>();
    }

    private HashSet<EvidenceInfo> collectedEvidences;

    public void addEvidence(EvidenceInfo _evidence)
    {
        collectedEvidences.Add(_evidence);
    }

    public void modifyEvidence(EvidenceInfo _evidence, int append)
    {
        foreach (var evidence in collectedEvidences)
        {
            if (evidence == _evidence)
            {
                evidence.pointer++;
            }
        }
    }
    
    
}
