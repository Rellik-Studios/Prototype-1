using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class BasicInkExample : MonoBehaviour
{
	
	public static event Action<Story> OnCreateStory;

	[SerializeField] private TMP_Text textBox;
	[SerializeField] private GameObject choices;

	[SerializeField] private List<AudioClip> audioClips;
	private AudioSource audioSource;

	private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
	private void Start()
	{
		
	}

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();

		foreach (var clip in audioClips)
		{
			clips.Add(clip.name.ToLower(), clip);
		}
		
		// Remove the default message
		RemoveChildren();
		StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	void StartStory()
	{
		story = new Story(inkJSONAsset.text);
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

		for (int i = 0; i < choices.transform.childCount; i++)
		{
			choices.transform.GetChild(i).gameObject.SetActive(false);
		}


	// Read all the content until we can't continue any more
	while (story.canContinue)
		{
			// Continue gets the next line of the story
			while (audioSource.isPlaying)
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
			canProceed = false;
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				
				Choice choice = story.currentChoices[i];
				var button = choices.transform.GetChild(i).gameObject.GetComponent<Button>();
				button.gameObject.SetActive(true);
					CreateChoiceView(button, choice.text.Trim());
				// Tell the button what to do when we press it
				button.onClick.AddListener(delegate { OnClickChoiceButton(choice); });
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate { StartStory(); });
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

		foreach (var tag in story.currentTags)
		{
			if (tag.StartsWith("Character."))
			{
				characterText.text = tag.Substring("Character.".Length, tag.Length - "Character.".Length);
				Debug.Log(characterText.text);
			}
			
			if (tag.StartsWith("Clip."))
			{
				var clipName = tag.Substring("Clip.".Length, tag.Length - "Clip.".Length).ToLower();
				clips.TryGetValue(clipName, out AudioClip clip);
				audioSource.PlayOneShot(clip);
				Debug.Log(characterText.text);
			}

			
		}
		StartCoroutine(TypeSentence(text));
		Text storyText = Instantiate(textPrefab) as Text;
		//storyText.text = text;
		storyText.transform.SetParent(canvas.transform, true);
		
		
		isPlaying = true;

		//storyText.rectTransform.position = new Vector3(500, 200, 0);
		//storyText.enabled = false;
		//textBox.transform.SetParent(canvas.transform, true);

	}

	IEnumerator TypeSentence(string text)
	{
		textBox.text = "";
		foreach (var letter in text)
		{
			textBox.text += letter;
			yield return null;
		}

		yield return new WaitForSeconds(3f);
		isPlaying = false;
		//textBox.SetText(text);
	}

void isPlayingFalse()
	{
		isPlaying = false;
	}
	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (canvas.transform, false);
		
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
		TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
		choiceText.text = text;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
		}
	}

	private void Update()
	{
		if (!audioSource.isPlaying && Input.GetKeyDown(KeyCode.Space))
		{
			canProceed = true;
		}
	}

	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField]
	private Canvas canvas = null;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab = null;
	[SerializeField]
	private Button buttonPrefab = null;

	private bool isPlaying = false;
	[SerializeField] private TMP_Text characterText;
	private bool canProceed = true;
	
}
