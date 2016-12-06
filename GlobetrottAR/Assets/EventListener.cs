using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventListener : MonoBehaviour {

	public GameObject popup;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (transform.hasChanged) {
			if (transform.position.x <= 800 && transform.position.x >= 700) {
				popup.SetActive (true);
			} else {
				popup.SetActive (false);
			}
			transform.hasChanged = false;
		}
	}

}