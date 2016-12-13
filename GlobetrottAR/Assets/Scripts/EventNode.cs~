using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EventNode : MonoBehaviour {

	public Coordinator coordinator;

	public string eventTitle;
	public string eventDate;
	public string eventYear;
	public string eventDescription;

	public Button eventBlurb;
	private Text blurbTitle;
	private Text blurbDate;
	private Text blurbYear;

	public Image eventImage;
	private Text title;
	private Text date;
	private Text year;
	private Text description;

	public GameObject globeEventPrefab;
	private GlobeEvent globeEvent;

	// Use this for initialization
	void Start () {
		// Initialize blurb text fields
		blurbTitle = GameObject.Find ("blurbTitle").GetComponent<Text>();
		blurbDate = GameObject.Find ("blurbDate").GetComponent<Text>();
		blurbYear = GameObject.Find ("blurbYear").GetComponent<Text> ();
		// Initialize popup text fields
		title = GameObject.Find("Title").GetComponent<Text>();
		date = GameObject.Find("Date").GetComponent<Text>();
		year = GameObject.Find("Year").GetComponent<Text>();
		description = GameObject.Find ("Description").GetComponent<Text>();

		// Set blurb and popup opacity to 0
		crossfadeBlurb (0f, 0f);
		crossfadePopup (0f, 0f);
		//eventText = eventImage.GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		// Make blurb visible and set correct text
		crossfadeBlurb (1f, 1f);
		GameObject go = (GameObject)Instantiate (globeEventPrefab);
		globeEvent = go.GetComponent<GlobeEvent> ();
		globeEvent.SetPosition (coordinator.GetGlobePosition(transform.position));
		blurbTitle.text = eventTitle;
		blurbDate.text = eventDate;
		blurbYear.text = eventYear;
		//description.text = eventDescription;
	}

	void OnTriggerExit() {
		//description.text = "";
		Destroy (globeEvent.gameObject);
		crossfadeBlurb (0f, 1f);
	}

	// Crossfade sets opacity of Graphics object to value between 0-1 over duration seconds
	void crossfadeBlurb(float value, float duration) {
		eventBlurb.GetComponent<Image> ().CrossFadeAlpha (value, duration, false);
		blurbTitle.CrossFadeAlpha (value, duration, false);
		blurbDate.CrossFadeAlpha (value, duration, false);
		blurbYear.CrossFadeAlpha (value, duration, false);

	}

	void crossfadePopup(float value, float duration) {
		eventImage.GetComponent<Image> ().CrossFadeAlpha (value, duration, false);
		title.CrossFadeAlpha (value, duration, false);
		date.CrossFadeAlpha (value, duration, false);
		year.CrossFadeAlpha (value, duration, false);
		description.CrossFadeAlpha (value, duration, false);
	}

	public void onClick() {
		// Hide blurb, Make popup visible
		crossfadeBlurb(0f, 0.5f);
		crossfadePopup (1f, 0.5f);
		// Set correct info in popup
		title.text = eventTitle;
		date.text = eventDate;
		year.text = eventYear;
		description.text = eventDescription;
		// Pause time
		GameObject.Find("Content").GetComponent<Timeline>().PlayPause();
	}
}
