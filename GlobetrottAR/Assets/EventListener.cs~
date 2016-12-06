using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventListener : MonoBehaviour {

	public GameObject popup;

	// Use this for initialization
	void Start () {
		popup.GetComponent<Image>().CrossFadeAlpha(0f, 0f, false);
	}

	// Update is called once per frame
	void Update () {
		if (transform.hasChanged) {
			if (transform.position.x <= 930 && transform.position.x >= 910) {
				popup.GetComponent<Image>().CrossFadeAlpha(1f, 0.3f, false);
			} else {
				popup.GetComponent<Image>().CrossFadeAlpha(0f, 0.3f, false);
			}
			transform.hasChanged = false;
		}
	}

}