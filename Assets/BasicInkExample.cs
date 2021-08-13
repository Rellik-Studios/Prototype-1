using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class BasicInkExample : MonoBehaviour
{
	private float textDialogueSize;
	
	[FormerlySerializedAs("tick")] public bool m_tick;
	public static event Action<Story> OnCreateStory;

	[FormerlySerializedAs("textBox")] [SerializeField]
	private TMP_Text m_textBox;


	[SerializeField] private Image m_talker;

	[FormerlySerializedAs("choices")] [SerializeField]
	private GameObject m_choices;

	private List<AudioClip> m_audioClips;
	private AudioSource m_audioSource;

	private string m_fullText;

	[FormerlySerializedAs("inkJSONAsset")] public TextAsset m_inkJsonAsset = null;
	public Story story;

	[FormerlySerializedAs("canvas")] [SerializeField]
	private Canvas m_canvas = null;

	// UI Prefabs
	[FormerlySerializedAs("textPrefab")] [SerializeField]
	private Text m_textPrefab = null;

	[FormerlySerializedAs("buttonPrefab")] [SerializeField]
	private Button m_buttonPrefab = null;

	private bool m_isPlaying = false;

	[FormerlySerializedAs("characterText")] [SerializeField]
	private TMP_Text m_characterText;

	public bool canProceed { get; set; }


	private Dictionary<string, AudioClip> m_clips = new Dictionary<string, AudioClip>();
	private Dictionary<string, Sprite> m_emotions = new Dictionary<string, Sprite>();

	private bool m_first = true;

	private void Start()
	{

	}

	private void OnDisable()
	{
		//clips = new Dictionary<string, AudioClip>();
	}

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

	void OnEnable()
	{
		textDialogueSize = transform.parent.GetChild(0).GetChild(1).GetComponent<RectTransform>().localScale.x;
		AddToDictionary<AudioClip>(m_clips, "Sounds");
		AddToDictionary(m_emotions, "Emotions");
		canProceed = true;
		m_audioSource = GetComponent<AudioSource>();


		// Remove the default message
		RemoveChildren();
		StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory()
	{
		story = new Story(m_inkJsonAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		StartCoroutine(RefreshView());
	}

	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	IEnumerator RefreshView()
	{
		// Remove all the UI on screen
		RemoveChildren();

		for (int i = 0; i < m_choices.transform.childCount; i++)
		{
			m_choices.transform.GetChild(i).gameObject.SetActive(false);
		}

// Read all the content until we can't continue any more
		while (story.canContinue)
		{
			// Continue gets the next line of the story
			while (m_audioSource.isPlaying)
			{
				yield return null;
			}

			while (!canProceed)
			{
				yield return null;
			}



			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();

			// Display the text on screen!
			CreateContentView(text);
			//canProceed = false;
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
            yield return new WaitWhile(()=> { return m_textBox.text != m_fullText; });
            
            {
                for (int i = 0; i < story.currentChoices.Count; i++)
                {

                    Choice choice = story.currentChoices[i];
                    var button = m_choices.transform.GetChild(i).gameObject.GetComponent<Button>();

                    CreateChoiceView(button, choice.text.Trim());
                    // Tell the button what to do when we press it
                    button.onClick.AddListener(delegate { OnClickChoiceButton(choice); });
                
                }
            }
            
        }
		// If we've read all the content and there's no choices, the story is finished!
		else if (!canProceed)
		{
			transform.parent.gameObject.SetActive(false);
		}



	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		StartCoroutine(RefreshView());
	}

	// Creates a textbox showing the the line of text
	void CreateContentView(string text)
	{
		var skip = false;
		foreach (var tag in story.currentTags)
		{
			if (tag.StartsWith("Character."))
			{
				
				var charName = tag.Substring("Character.".Length, tag.Length - "Character.".Length);
				var localScale = transform.parent.GetChild(0).GetChild(1).GetComponent<RectTransform>().localScale;
				m_characterText.text = charName;

				if (charName == "Rook")
				{
					var parentScale = transform.parent.GetChild(0).GetChild(1).GetComponent<RectTransform>().localScale;
					transform.parent.GetChild(0).GetChild(1).GetComponent<RectTransform>().localScale = new Vector3(textDialogueSize * -1, localScale.y,localScale.z);
					var scale = transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<RectTransform>().localScale;
					transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<RectTransform>().localScale =
						new Vector3(-0.12f, scale.y, scale.z);
				}
				else
				{
					var parentScale = transform.parent.GetChild(0).GetChild(1).GetComponent<RectTransform>().localScale;
					transform.parent.GetChild(0).GetChild(1).GetComponent<RectTransform>().localScale = new Vector3(textDialogueSize, localScale.y,localScale.z);
					var scale = transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<RectTransform>().localScale;
					transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<RectTransform>().localScale =
						new Vector3(0.12f, scale.y, scale.z);

				}
				Debug.Log(m_characterText.text);
			}

			if (tag.StartsWith("Clip."))
			{
				var clipName = tag.Substring("Clip.".Length, tag.Length - "Clip.".Length).ToLower();
				if (m_clips.TryGetValue(clipName, out AudioClip clip))
				{
					m_audioSource.PlayOneShot(clip);
					Debug.Log(m_characterText.text);
				}
			}

			if (tag.StartsWith("Emotion."))
			{
				var emoteName = tag.Substring("Emotion.".Length, tag.Length - "Emotion.".Length).ToLower();
				if (emoteName == "null")
					m_talker.enabled = false;
				
				else if (m_emotions.TryGetValue(emoteName, out Sprite sprite))
				{
					m_talker.enabled = true;
					m_talker.sprite = sprite;
				}
			}

			if (tag.StartsWith("Interaction."))
			{
				var interactName = tag.Substring("Interaction.".Length, tag.Length - "Interaction.".Length);

				gameManager.Instance.handleInteractions(interactName);
			}


			if (tag.StartsWith("Function."))
			{
				var functionName = tag.Substring("Function.".Length, tag.Length - "Function.".Length);
				story.EvaluateFunction(functionName, gameManager.Instance.isOnAppend(text.Substring(0, text.Length - 1), text.Substring(text.Length - 1)));
				skip = true;
			}


		}

		if (text.Contains(".0"))
		{
			text = text.Substring(0, (text.LastIndexOf('.')));
		}

		if (!skip)
		{
			StopCoroutine(TypeSentence(""));
			StartCoroutine(TypeSentence(text));
			canProceed = false;
		}
		else
		{
			canProceed = true;
		}
		
		//Text storyText = Instantiate(m_textPrefab) as Text;
		//storyText.text = text;
		//storyText.transform.SetParent(m_canvas.transform, true);


		m_isPlaying = true;

		//storyText.rectTransform.position = new Vector3(500, 200, 0);
		//storyText.enabled = false;
		//textBox.transform.SetParent(canvas.transform, true);

	}

	void CanProceed()
	{
		canProceed = true;
	}

	IEnumerator TypeSentence(string text)
	{
		m_fullText = text;
		m_textBox.text = "";
		bool isTag = false;
		foreach (var letter in text)
		{
			m_textBox.text += letter;
			if (letter == '<')
				isTag = true;
			if (letter == '>')
				isTag = false;

			if (!isTag)
				yield return new WaitForSeconds(0.0167f);
		}

		yield return new WaitForSeconds(3f);
		m_isPlaying = false;
		//textBox.SetText(text);
	}

void IsPlayingFalse()
	{
		m_isPlaying = false;
	}
	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (m_buttonPrefab) as Button;
		choice.transform.SetParent (m_canvas.transform, false);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	void CreateChoiceView(Button choice, string text)
	{
		choice.gameObject.SetActive(true);
		TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
		choiceText.text = text;

		if (text.Contains(".0"))
		{
			var check = choiceText.text.Substring(choiceText.text.LastIndexOf('.') + 2).ToLower();
			var append = check.Substring(check.Length - 1);
			check = check.Substring(0, check.Length - 1);
			if (gameManager.Instance.collectedEvidences.TryGetValue(check, out EvidenceInfo evidenceInfo))
			{
				if(Int32.TryParse(append, out int app))
					if(evidenceInfo.pointer < app - 1)
						choice.gameObject.SetActive(false);
					else
					{
						choiceText.text = choiceText.text.Substring(0, (choiceText.text.LastIndexOf('.')));
					}
			}
			else
			{
				choice.gameObject.SetActive(false);
			}
			
		}



		
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = m_canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (m_canvas.transform.GetChild (i).gameObject);
		}
	}

	private void Update()
	{
		if (!m_audioSource.isPlaying && Input.GetMouseButtonDown(0) && GameObject.FindGameObjectWithTag("InkDialogue").activeSelf)
		{
			if (m_textBox.text == m_fullText) canProceed = true;
		}
	}
		
	

	
	
}
