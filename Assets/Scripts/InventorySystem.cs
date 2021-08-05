<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public Image[] slots;
    public int current_index=-1;
    private EvidenceInfo[] evidList = new EvidenceInfo[12];
    private bool IsInvenOpen = false;
    public GameObject InventoryUI;
    public GameObject Preview;

    public Text nameText;
    public Text nameDescript;
    public Image previewImage;


    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(IsInvenOpen);
    }

    // Update is called once per frame
    void Update()
    {
        //for testing purposes on whether the inventory menu is opened
        if (Input.GetKeyDown(KeyCode.E))
        {

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
        
        


    }
    public void OpenInventory()
    {
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
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public Image[] slots;
    public int current_index=-1;
    private EvidenceInfo[] evidList = new EvidenceInfo[12];
    private bool IsInvenOpen = false;
    private bool IsShowOpen = false;
    public GameObject InventoryUI;
    public GameObject Preview;
    public GameObject SuspectScreen;

    public GameObject ShowButton;
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

        


    }
    public void CloseInventory()
    {
        IsInvenOpen = false;
        IsShowOpen = false;
        ShowButton.SetActive(false);
        InspectButton.SetActive(false);
        InventoryUI.SetActive(false);

    }
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

        if(evidList[current_index].Inspected && !IsShowOpen)
        {
            SampleButton.SetActive(true);
        }
        else
        {
            SampleButton.SetActive(false);
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
        /*
        foreach (var slot in slots)
        {
            slot.color = Color.white;
        }
        */
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
        OpenInventory();
        IsShowOpen = true;
        SuspectScreen.SetActive(false);
        ShowButton.SetActive(true);
        InspectButton.SetActive(false);

        
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
>>>>>>> 69b0d7118452f21d94d01afe9e895d73288cddbf
