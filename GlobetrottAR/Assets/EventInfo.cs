using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventInfo : MonoBehaviour {

	public string eventTitle;
	public string eventDate;
	public string eventYear;
	public string eventDescription;

	public Button eventBlurb;

	public Image eventImage;

	void OnTriggerEnter() {
		//on blurb zone enter
		EventNode eScript = this.transform.parent.GetComponent<EventNode>();
		eScript.runInstantiateGo ();
		eScript.blurbTitle.text = eventTitle;
		eScript.blurbDate.text = eventDate;
		eScript.blurbYear.text = eventYear;

		eScript.description.text = eventDescription;
		eScript.title.text = eventTitle;
		eScript.date.text = eventDate;
		eScript.year.text = eventYear;
		if (!eScript.clickable) {
			eScript.crossfadeBlurb (1f, 1f);
		}
	}

	void OnTriggerExit() {
		//on blurb zone exit
		EventNode eScript = this.transform.parent.GetComponent<EventNode>();
		Destroy (eScript.globeEvent.gameObject);
		if (eScript.clickable) {
			eScript.crossfadeBlurb (0f, 1f);
		}
	}
}
