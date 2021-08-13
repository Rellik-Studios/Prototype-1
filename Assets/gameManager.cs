using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    [Header("Dialogue")]
    [SerializeField] GameObject sceneController;

    [SerializeField] private BasicInkExample ink;

    [SerializeField] private TextAsset story;
    
    public Dictionary<string, AudioClip> soundEffects { get; private set; }

    public AudioSource audioSource;

    void AddToDictionary<T>(Dictionary<string, T> _dictionary, string _path) where T : Object
    {
        var array = Resources.LoadAll<T>(_path);
        var list = array.ToList();

        if (_dictionary.Count == 0)
            foreach (var li in list)
            {
                _dictionary.Add(li.name.ToLower(), li);
            }
    }
    
    public void StartStory(TextAsset _story)
    {
        ink.m_inkJsonAsset = _story; 
        sceneController.SetActive(true);
       
    }

    public void playButtonSound()
    {
        if(soundEffects.TryGetValue("buttonsound", out AudioClip clip))
        {
            audioSource.PlayOneShot(clip);
        }
    }
    
    private void Update()
    {
        if( Health <=0)
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
        audioSource = GetComponent<AudioSource>();
        inkDialogeCanvas = GameObject.FindGameObjectWithTag("InkDialogue");
        soundEffects = new Dictionary<string, AudioClip>();
        AddToDictionary(soundEffects, "Effects");
        Instance = this;
        collectedEvidences = new Dictionary<string, EvidenceInfo>();

    }
    public int Health = 6;
    public Dictionary<string, EvidenceInfo> collectedEvidences;
    private GameObject inkDialogeCanvas;
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
        if (!collectedEvidences.ContainsKey(_evidence.evidenceName.ToLower().Replace(" ", "")))
        {
            if(soundEffects.TryGetValue("evidencepickup", out AudioClip clip))
            {
                audioSource.PlayOneShot(clip);
            }
            GameObject.FindGameObjectWithTag("Exclamation").GetComponent<Image>().enabled = true;
            GameObject.FindGameObjectWithTag("Exclamation").GetComponent<Animator>().SetBool("Trigger", true);
            collectedEvidences.Add(_evidence.evidenceName.ToLower().Replace(" ", ""), _evidence);
            inkDialogeCanvas.transform.parent.gameObject.SetActive(true);
            inkDialogeCanvas.transform.parent.GetChild(1).gameObject.SetActive(false);

            StartCoroutine(evidenceAddedText(_evidence.evidenceName));
        }
    }

    IEnumerator evidenceAddedText(string evidenceName)
    {
        var currentText = inkDialogeCanvas.transform.GetChild(3).GetComponent<TMP_Text>().text;
        inkDialogeCanvas.transform.GetChild(0).GetComponent<Image>().enabled = false;
        inkDialogeCanvas.transform.GetChild(3).GetComponent<TMP_Text>().text = evidenceName + " Has been added to the inventory";
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Exclamation").GetComponent<Animator>().SetBool("Trigger", false);
        yield return new WaitForSeconds(2);
        inkDialogeCanvas.transform.GetChild(3).GetComponent<TMP_Text>().text = currentText;
        inkDialogeCanvas.transform.parent.gameObject.SetActive(false);
        inkDialogeCanvas.transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    public void modifyEvidence(EvidenceInfo _evidence)
    {
        foreach (var evidence in collectedEvidences)
        {
            if (evidence.Value == _evidence)
            {
                evidence.Value.pointer++;
                if(soundEffects.TryGetValue("evidencepickup", out AudioClip clip))
                {
                    audioSource.PlayOneShot(clip);
                }
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
        GameObject.FindGameObjectWithTag("Exclamation").GetComponent<Image>().enabled = true;
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
                    if (itEvidence.Value.pointer < intAppend - 1)
                    {
                        itEvidence.Value.pointer = intAppend - 1;
                        if(soundEffects.TryGetValue("evidencepickup", out AudioClip clip))
                        {
                            audioSource.PlayOneShot(clip);
                        }
                    }
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
                
                var currentText = ink.transform.GetChild(3).GetComponent<TMP_Text>().text;
                ink.transform.GetChild(3).GetComponent<TMP_Text>().text = "<color=red>Huh? I don't Understand</color>";
                yield return new WaitForSeconds(3);
                ink.transform.GetChild(3).GetComponent<TMP_Text>().text = currentText;
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
