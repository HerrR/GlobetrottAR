using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EventNode : MonoBehaviour {

	public Coordinator coordinator;

	public string information;
	public Image eventImage;
	private Text eventText;

	public GameObject globeEventPrefab;
	private GlobeEvent globeEvent;

	// Use this for initialization
	void Start () {
		eventText = eventImage.GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		eventImage.gameObject.SetActive (true);
		GameObject go = (GameObject)Instantiate (globeEventPrefab);
		globeEvent = go.GetComponent<GlobeEvent> ();
		globeEvent.SetPosition (coordinator.GetGlobePosition(transform.position));
		eventText.text = information;
	}

	void OnTriggerExit() {
		eventText.text = "";
		Destroy (globeEvent.gameObject);
		eventImage.gameObject.SetActive (false);
	}
}
