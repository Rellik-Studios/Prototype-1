using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        if( Health ==0)
        {
            GetComponent<MainMenu>().LoseButton();
        }
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            Health--;
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
    public int Health = 6;
    public Dictionary<string, EvidenceInfo> collectedEvidences;
    public EvidenceInfo selectedEvidence { get; set; }

    public int isOnAppend(string _evidenceName, string _append)
    {
        if (collectedEvidences.TryGetValue(_evidenceName, out EvidenceInfo evidenceInfo))
        {
            return (evidenceInfo.pointer >= Int32.Parse(_append) - 1)?1:0;
        }
        else return 0;
    }

    IEnumerator talked(string b)
    {
        GetComponent<DetectObjects>().talkingTo.talked = true;
        yield return null;
    }

    public void addEvidence(EvidenceInfo _evidence)
    {
        if(!collectedEvidences.ContainsKey(_evidence.evidenceName.ToLower().Replace(" ", "")))
            collectedEvidences.Add(_evidence.evidenceName.ToLower().Replace(" ", ""), _evidence);
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
            Health -=2;
            Debug.Log("Hurt");
            return;
        }
        if(interactName =="Win")
        {
            GetComponent<MainMenu>().WinButton();
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
            if (evidence.evidenceName.ToLower().Replace(" ", "") == obect.ToLower().Replace(" ", "") && !collectedEvidences.ContainsKey(evidence.evidenceName))
            {
                collectedEvidences.Add(evidence.evidenceName.ToLower().Replace(" ", ""), evidence);
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

    IEnumerator show(string obect)
    {
        var ink = GameObject.FindGameObjectWithTag("InkDialogue");
        var invSys =  GameObject.FindObjectOfType<InventorySystem>();
        while (selectedEvidence == null || selectedEvidence.evidenceName.ToLower().Replace(" ","") != obect.ToLower() )
        {
            if (selectedEvidence != null && selectedEvidence.evidenceName.ToLower().Replace(" ","") != obect.ToLower())
            {
                Debug.Log("Ya stupid");
                Health--;
                //Hurt here?
                //ink.transform.parent.gameObject.SetActive(true);
                ink.SetActive(true);
                
                var currentText = ink.transform.GetChild(5).GetComponent<TMP_Text>().text;
                ink.transform.GetChild(5).GetComponent<TMP_Text>().text = "<color=red>Huh? I don't Understand</color>";
                yield return new WaitForSeconds(3);
                ink.transform.GetChild(5).GetComponent<TMP_Text>().text = currentText;
                ink.gameObject.SetActive(false);
                selectedEvidence = null;
            }
            ink.gameObject.SetActive(false);
            if (!invSys.showUI.activeSelf)
            {
                invSys.ConfirmSus();
            }

            yield return null;

        }

        yield return new WaitForSeconds(2);
        selectedEvidence = null;
        ink.gameObject.SetActive(true);

        
    }
    
}
