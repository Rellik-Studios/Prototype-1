using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[SelectionBase]
public class EvidenceInfo : MonoBehaviour
{
    private Sprite evidenceImage;

    public string evidenceName;
    [TextArea]
    public List<string> descriptions;

    public int pointer;
    public bool Inspected = false;

    public bool InspectVisible = false;
    public bool SampleVisible = false;


    // Start is called before the first frame update
    void Start()
    {
        evidenceImage = Resources.Load<Sprite>("Images/" + gameObject.name.ToLower().Replace(" ", " "));

        if(evidenceImage == null)
        {
            evidenceImage = Resources.Load<Sprite>("Images/knife");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer > descriptions.Count - 1)
        {
            pointer = descriptions.Count - 1;
        }
    }

    public void ModifyAppend(int _append)
    {
        if(_append > pointer)
            pointer = _append;
    }
   

    public void Information()
    {
        Debug.Log(evidenceName);
        Debug.Log(descriptions[pointer]);
    }

    //when the inspect append is found set item to true as inspected
    //used for as a value for sampling to be used
    public void ItemInspected()
    {
        Inspected = true;
    }

    public Sprite GetImage()
    {
        return evidenceImage;
    }
}
