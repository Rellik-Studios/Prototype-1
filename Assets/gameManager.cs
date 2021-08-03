using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    [Header("Dialogue")]
    [SerializeField] GameObject sceneController;

    [SerializeField] private BasicInkExample ink;

    [SerializeField] private TextAsset story;
    public void StartStory(TextAsset _story)
    {
        ink.m_inkJsonAsset = _story; 
        sceneController.SetActive(true);
       
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var vEvidence in collectedEvidences)
            {
               vEvidence.Value.Information();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (var vEvidence in collectedEvidences)
            {
                modifyEvidence(vEvidence.Value, 1);
            } 
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartStory(story);
        }
    }

    private void Start()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        collectedEvidences = new Dictionary<string, EvidenceInfo>();

    }

    public Dictionary<string, EvidenceInfo> collectedEvidences;

    public void addEvidence(EvidenceInfo _evidence)
    {
        if(!collectedEvidences.ContainsKey(_evidence.evidenceName))
            collectedEvidences.Add(_evidence.evidenceName, _evidence);
    }

    public void modifyEvidence(EvidenceInfo _evidence, int append)
    {
        foreach (var evidence in collectedEvidences)
        {
            if (evidence.Value == _evidence)
            {
                evidence.Value.pointer++;
            }
        }
    }
    
    
}
