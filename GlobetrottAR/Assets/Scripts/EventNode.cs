﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EventNode : MonoBehaviour {

	public Coordinator coordinator;

	public string eventTitle;
	public string eventDate;
	public string eventDescription;
	public Image eventImage;
	private Text title;
	private Text date;
	private Text description;

	public GameObject globeEventPrefab;
	private GlobeEvent globeEvent;

	// Use this for initialization
	void Start () {
		title = GameObject.Find ("Title").GetComponent<Text>();
		date = GameObject.Find ("Date").GetComponent<Text>();
		description = GameObject.Find ("Description").GetComponent<Text>(); 
		//eventText = eventImage.GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		eventImage.gameObject.SetActive (true);
		GameObject go = (GameObject)Instantiate (globeEventPrefab);
		globeEvent = go.GetComponent<GlobeEvent> ();
		globeEvent.SetPosition (coordinator.GetGlobePosition(transform.position));
		title.text = eventTitle;
		date.text = eventDate;
		description.text = eventDescription;
	}

	void OnTriggerExit() {
		description.text = "";
		Destroy (globeEvent.gameObject);
		eventImage.gameObject.SetActive (false);
	}
}