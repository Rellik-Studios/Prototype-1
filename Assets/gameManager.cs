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
                modifyEvidence(vEvidence.Value);
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

    public void modifyEvidence(EvidenceInfo _evidence)
    {
        foreach (var evidence in collectedEvidences)
        {
            if (evidence.Value == _evidence)
            {
                evidence.Value.pointer++;
            }
        }
    }


    public void handleInteractions(string interactName)
    {
        if (interactName == "Hurt")
        {
            //Add hurt here
            Debug.Log("Hurt");
            return;
        }

        var func = interactName.Substring(0, interactName.LastIndexOf('('));
        var val = interactName.Substring(interactName.LastIndexOf('(') + 1, interactName.LastIndexOf(')') - func.Length - 1);
        
        StartCoroutine(func, val);
    }


    IEnumerator addToInventory(string obect)
    {
        var evidences = GameObject.FindObjectsOfType<EvidenceInfo>();
        foreach (var evidence in evidences)
        {
            if (evidence.evidenceName.ToLower() == obect.ToLower() && !collectedEvidences.ContainsKey(evidence.evidenceName))
            {
                collectedEvidences.Add(evidence.evidenceName, evidence);
                break;
            }
        }
        yield return null;
    }

    IEnumerator modify(string obect)
    {
        var append = obect.Substring(obect.Length - 1);
        var evidence = obect.Substring(0, obect.Length - 1);

        foreach (var itEvidence in collectedEvidences)
        {
            if (string.Equals(itEvidence.Key, evidence, StringComparison.CurrentCultureIgnoreCase))
            {
                if (Int32.TryParse(append, out int intAppend))
                {
                    itEvidence.Value.pointer = intAppend - 1;
                }
            }
        }
        yield return null;
    }
    
}
