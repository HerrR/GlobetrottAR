using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EventNode : MonoBehaviour {

	public Coordinator coordinator;

	public Button eventBlurb;
	public Text blurbTitle;
	public Text blurbDate;
	public Text blurbYear;
	public Vector3 eventPos;

	public Image eventImage;
	public Text title;
	public Text date;
	public Text year;
	public Text description;

	public GameObject globeEventPrefab;
	public GlobeEvent globeEvent;

	public bool clickable = true;

	// Use this for initialization
	void Start () {
		// Initialize blurb text fields
		GameObject tEvents = GameObject.Find("TravelEvents");
		EventInfo eInfo = tEvents.transform.GetChild (0).GetComponent<EventInfo>();


		blurbTitle = GameObject.Find ("blurbTitle").GetComponent<Text>();
		blurbDate = GameObject.Find ("blurbDate").GetComponent<Text>();
		blurbYear = GameObject.Find ("blurbYear").GetComponent<Text> ();
		// Initialize popup text fields
		title = GameObject.Find("Title").GetComponent<Text>();
		date = GameObject.Find("Date").GetComponent<Text>();
		year = GameObject.Find("Year").GetComponent<Text>();
		description = GameObject.Find ("Description").GetComponent<Text>();
		eventPos = eInfo.eventPos;

		// Set blurb and popup opacity to 0
		crossfadeBlurb (0f, 0f);
		crossfadePopup (0f, 0f);
		//eventText = eventImage.GetComponentInChildren<Text> ();
	}


	// Crossfade sets opacity of Graphics object to value between 0-1 over duration seconds
	public void crossfadeBlurb(float value, float duration) {
		clickable = !clickable;
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

	public void runInstantiateGo() {
		GameObject go = (GameObject)Instantiate (globeEventPrefab);
		globeEvent = go.GetComponent<GlobeEvent> ();
		globeEvent.SetPosition (coordinator.GetGlobePosition(eventPos));
	}

	public void onClick() {
		// Hide blurb, Make popup visible
		if (clickable) {
			crossfadeBlurb (0f, 0.5f);
			crossfadePopup (1f, 0.5f);
			// Pause time
			Timeline timeline = GameObject.Find ("Content").GetComponent<Timeline> ();
			if (timeline.running == true) {
				timeline.PlayPause ();
			}
		}
	}
}
