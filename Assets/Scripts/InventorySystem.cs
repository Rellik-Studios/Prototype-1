using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public Image[] slots;
    public GameObject Preview;
    public int current_index=-1;
    private EvidenceInfo[] evidList = new EvidenceInfo[12];

    private bool IsInvenOpen = false;
    private bool IsShowOpen = false;
    public GameObject InventoryUI;
    public GameObject showUI;

    //testing
    
    public GameObject SuspectScreen;

    public GameObject ShowButton;
    public GameObject InventoryButton;
    public GameObject InspectButton;
    public GameObject SampleButton;

    public Button inventory;
    public Text nameText;
    public Text nameDescript;
    public Image previewImage;
    


    private int SusNum = -1;
    private List<EvidenceInfo> evidSelect;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(IsInvenOpen);
        evidSelect = new List<EvidenceInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //for testing purposes on whether the inventory menu is opened
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.enabled = true;
            IsInvenOpen = !IsInvenOpen;
            InventoryUI.SetActive(IsInvenOpen);
            Preview.SetActive(false);
            current_index = -1;

            //update name
            nameText.text = "";

            //update description
            nameDescript.text = "";

            //update image
            previewImage.sprite = null;

            UpdateInventory();
        }
        //this function will update the Inventory items in there
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateInventory();
        }
    }
    //function used for the buttons in inventory 
    public void SelectEvidence(int index)
    {
        current_index = index;
        if (evidList[current_index] != null)
        {
            Preview.SetActive(true);
            UpdatePreview();
        }
        else
        {
            Preview.SetActive(false);
        }

        


    }
    public void OpenInventUI()
    {
        IsInvenOpen = !IsInvenOpen;
        InventoryUI.SetActive(IsInvenOpen);

        Preview = InventoryUI.transform.GetChild(0).gameObject;
        slots = InventoryUI.transform.GetChild(1).gameObject.GetComponentsInChildren<Image>();

        Preview.SetActive(false);



        current_index = -1;
        nameText = Preview.transform.GetChild(0).gameObject.GetComponent<Text>();
        nameDescript = Preview.transform.GetChild(1).gameObject.GetComponent<Text>();
        previewImage = Preview.transform.GetChild(2).gameObject.GetComponent<Image>();

        //update name
        nameText.text = "";

        //update description
        nameDescript.text = "";

        //update image
        previewImage.sprite = null;

        if(IsInvenOpen)
        {
            InventoryButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Briefcase_open");
        }
        else
        {
            InventoryButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Briefcase_closed");
        }
        InventoryButton.GetComponent<Image>().SetNativeSize();
        UpdateInventory();
    }
    public void OpenShowUI()
    {
        IsInvenOpen = !IsInvenOpen;
        showUI.SetActive(IsInvenOpen);

        Preview = showUI.transform.GetChild(0).gameObject;
        slots = showUI.transform.GetChild(1).gameObject.GetComponentsInChildren<Image>();

        Preview.SetActive(false);



        current_index = -1;
        nameText = Preview.transform.GetChild(0).gameObject.GetComponent<Text>();
        nameDescript = Preview.transform.GetChild(1).gameObject.GetComponent<Text>();
        previewImage = Preview.transform.GetChild(2).gameObject.GetComponent<Image>();

        //update name
        nameText.text = "";

        //update description
        nameDescript.text = "";

        //update image
        previewImage.sprite = null;

        UpdateInventory();
    }

    public void CloseInventory()
    {
        
        IsInvenOpen = false;
        IsShowOpen = false;
        showUI.SetActive(false);

    }
    /*
    public void OpenInventory()
    {
        IsInvenOpen = !IsInvenOpen;
        InventoryUI.SetActive(IsInvenOpen);
        Preview.SetActive(false);
        InspectButton.SetActive(true);
        current_index = -1;

        //update name
        nameText.text = "";

        //update description
        nameDescript.text = "";

        //update image
        previewImage.sprite = null;

        UpdateInventory();
    }
    public void OpenShow()
    {
        IsInvenOpen = true;
        InventoryUI.SetActive(IsInvenOpen);
        Preview.SetActive(false);
        InspectButton.SetActive(true);
        current_index = -1;

        //update name
        nameText.text = "";

        //update description
        nameDescript.text = "";

        //update image
        previewImage.sprite = null;

        UpdateInventory();
    }
    */




    public void UpdateInventory()
    {
        int index = -1;
        foreach (var vEvidence in gameManager.Instance.collectedEvidences)
        {
            index++;
            evidList[index] = vEvidence.Value;
            slots[index].sprite = evidList[index].GetImage();
        }
    }

   //update the preview shown in inventory system.
    void UpdatePreview()
    {
        InspectButton.SetActive(false);
        SampleButton.SetActive(false);

        if (Preview.activeSelf)
        {
         
            if (evidList[current_index].InspectVisible)
            {
                InspectButton.SetActive(true);
            }
            else if(evidList[current_index].SampleVisible)
            {
                SampleButton.SetActive(true);
            }
            else
            {
                InspectButton.SetActive(false);
                SampleButton.SetActive(false);
            }
        }

        if (evidList[current_index].Inspected && evidList[current_index].SampleVisible)
        {
            SampleButton.SetActive(true);
        }

        
            //update name
            nameText.text = evidList[current_index].evidenceName;

            //update description
            nameDescript.text = evidList[current_index].descriptions[evidList[current_index].pointer];

            //foreach (string sentence in evidList[current_index].descriptions)
            //{
            //    nameDescript.text += sentence;
            //}

            //update image
            previewImage.sprite = evidList[current_index].GetImage();
        

    }
    public void Sampling()
    {
        AppendModify(evidList[current_index].descriptions.Count - 1);
    }
    public void AppendModify(int num)
    {

        foreach (var vEvidence in gameManager.Instance.collectedEvidences)
        {
            if (vEvidence.Value == evidList[current_index])
            {
                if (num < evidList[current_index].descriptions.Count)
                {
                    evidList[current_index].ModifyAppend(num);
                }
                UpdateInventory();
                UpdatePreview();
            }
        }
    }
    public void PickSus(int num)
    {
        SusNum = num;
    }

    public void OpenSusList()
    {
        SuspectScreen.SetActive(!SuspectScreen.activeSelf);

    }
    public void ItemInspected()
    {
        if (evidList[current_index] != null)
        {
            evidList[current_index].ItemInspected();
            UpdatePreview();
        }
    }


    public void ConfirmSus()
    {
        Debug.Log("confirm to show evidence to suspect");
        OpenShowUI();
        IsShowOpen = true;
        SuspectScreen.SetActive(false);
        ShowButton.SetActive(true);

        
    }
    public void PickEvidence()
    {
        if(current_index ==-1)
        {
            
            return;
        }
        if (evidList[current_index] != null)
        {
            Debug.Log("you chose " + evidList[current_index].evidenceName);
            ConfirmEvidence();
        }

        //if (evidList[current_index] != null)
        //{
        //    if (!evidSelect.Contains(evidList[current_index]))
        //    {
        //        evidSelect.Add(evidList[current_index]);
        //        slots[current_index].color = Color.red;

            //    }
            //    else
            //    {
            //        evidSelect.Remove(evidList[current_index]);
            //        slots[current_index].color = Color.white;
            //    }
            //}
    }
    public void ConfirmEvidence()
    {
        Debug.Log("confirmed");
        //this section being whether or not the player is right
        //applying certain right evidence
    }
}
