using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveTheCase : MonoBehaviour
{

    private SuspectsStories[] suspects;
    public GameObject solvebutton;
    public GameObject[] Hearts;
    // Start is called before the first frame update
    void Start()
    {
        suspects = GetComponentsInChildren<SuspectsStories>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AllSuspectsTalked() && gameManager.Instance.collectedEvidences.Count == 12)
        {
            solvebutton.SetActive(true);
        }
        for(int i = 0; i<Hearts.Length; i++)
        {
            if(i<gameManager.Instance.Health)
            {
                Hearts[i].SetActive(true);
            }
            else
            {
                Hearts[i].SetActive(false);
            }
        }
    }
    public void IsCorect()
    {
        if(RequiredEvid())
        {
            Debug.Log("you are right");
        }
    }
    public bool EvidenceExist(string name)
    {
        return gameManager.Instance.collectedEvidences[name];
    }
    public EvidenceInfo GetEvidence(string name)
    {
        return gameManager.Instance.collectedEvidences[name];
    }
    public bool RequiredEvid()
    {
        return gameManager.Instance.collectedEvidences["Senior detective autopsy"].pointer == 0 &&
               gameManager.Instance.collectedEvidences["Standing glass"].pointer ==2 &&
               gameManager.Instance.collectedEvidences["Tipped-over glass"].pointer == 2 &&
               gameManager.Instance.collectedEvidences["Wine bottle"].pointer ==1;
    }
    public bool RequiredForSen()
    {
        return GetEvidence("Senior detective autopsy").pointer >= GetEvidence("Senior detective autopsy").descriptions.Count;
    }
    public bool AllSuspectsTalked()
    {
        foreach (var suspect in suspects)
        {
            if (!suspect.HasTalked())
            {
                return false;
            }
        }
        return true;
    }
}
