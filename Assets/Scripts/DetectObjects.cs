<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{

    [SerializeField] private LayerMask objects;
    private Camera _camera;
    [SerializeField] TextAsset story;
    public GameObject Inventory;
    public GameObject Dialogue;

    [CanBeNull] public GameObject inspectCamera;

    [CanBeNull] private Renderer m_revert;
    private List<Color> defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        defaultColor = new List<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        //Clicking down on a object 
        if (Inventory.activeSelf || Dialogue.activeSelf) return;
        if(inspectCamera is { })
            if(inspectCamera.activeSelf) return;
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        //checking if its a evidence object
        if (Physics.Raycast(ray, out RaycastHit hit, objects))
        {
            //Select stage    
                
            if (hit.collider.TryGetComponent<EvidenceInfo>(out EvidenceInfo evidence))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gameManager.Instance.addEvidence(evidence);
                    if(m_revert != null)
                        for (var index = 0; index < m_revert.materials.Length; index++)
                        {
                            var mat = m_revert.materials[index];
                            mat.color = defaultColor[index];
                        }
                }
                else if (!gameManager.Instance.collectedEvidences.ContainsValue(evidence))
                {
                    if(m_revert != null)
                        for (var index = 0; index < m_revert.materials.Length; index++)
                        {
                            var mat = m_revert.materials[index];
                            mat.color = defaultColor[index];
                        }

                    m_revert = (hit.collider.gameObject.GetComponent<Renderer>());
                    //     defaultColor.Capacity = m_revert.materials.Length;
                    foreach (var mat in m_revert.materials)
                    {
                        if(defaultColor.Count < m_revert.materials.Length)
                            defaultColor.Add(mat.color);
                        mat.color = Color.red;
                       
                    }
                }


            }
            else if (hit.collider.TryGetComponent<SuspectsStories>(out SuspectsStories suspects))
            {
                if (Input.GetMouseButtonDown(0))
                    gameManager.Instance.StartStory(suspects.GetStory());
            }
            else
            {

                if (m_revert != null && defaultColor != null)
                    for (var index = 0; index < m_revert.materials.Length; index++)
                    {
                        var mat = m_revert.materials[index];
                        mat.color = defaultColor[index];
                    }
                //m_revert = null;
                //defaultColor = null;

            }



            /*
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Suspect"))
                {
                    gameManager.Instance.StartStory(story);
                }
                */
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{

    [SerializeField] private LayerMask objects;
    private Camera _camera;
    [SerializeField] TextAsset story;
    public GameObject Inventory;
    public GameObject Dialogue;

    [CanBeNull] private Renderer m_revert;
    private List<Color> defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        defaultColor = new List<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        //Clicking down on a object
        if (!Inventory.activeSelf && !Dialogue.activeSelf)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //checking if its a evidence object
            if (Physics.Raycast(ray, out RaycastHit hit, objects))
            {
                //Select stage

                if (hit.collider.TryGetComponent<EvidenceInfo>(out EvidenceInfo evidence))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        gameManager.Instance.addEvidence(evidence);
                        if(m_revert != null)
                            for (var index = 0; index < m_revert.materials.Length; index++)
                            {
                                var mat = m_revert.materials[index];
                                mat.color = defaultColor[index];
                            }
                    }
                    else if (!gameManager.Instance.collectedEvidences.ContainsValue(evidence))
                    {
                        if(m_revert != null)
                            for (var index = 0; index < m_revert.materials.Length; index++)
                            {
                                var mat = m_revert.materials[index];
                                mat.color = defaultColor[index];
                            }

                        m_revert = (hit.collider.gameObject.GetComponent<Renderer>());
                   //     defaultColor.Capacity = m_revert.materials.Length;
                   foreach (var mat in m_revert.materials)
                   {
                       if(defaultColor.Count < m_revert.materials.Length)
                        defaultColor.Add(mat.color);
                       mat.color = Color.red;

                   }
                    }


                }
                else if (hit.collider.TryGetComponent<SuspectsStories>(out SuspectsStories suspects))
                {
                    if (Input.GetMouseButtonDown(0))
                        gameManager.Instance.StartStory(suspects.GetStory());
                }
                else
                {

                    if (m_revert != null && defaultColor != null)
                        for (var index = 0; index < m_revert.materials.Length; index++)
                        {
                            var mat = m_revert.materials[index];
                            mat.color = defaultColor[index];
                        }
                    //m_revert = null;
                    //defaultColor = null;

                }



                /*
                else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Suspect"))
                {
                    gameManager.Instance.StartStory(story);
                }
                */
            }
        }
    }
}
>>>>>>> 69b0d7118452f21d94d01afe9e895d73288cddbf
