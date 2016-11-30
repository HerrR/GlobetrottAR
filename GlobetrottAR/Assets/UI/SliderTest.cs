using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour {

	public Slider mainSlider;
	public GameObject popup;

	// Use this for initialization
	void Start () {
		// Add listener for value changes in slider
		mainSlider.onValueChanged.AddListener (delegate {
			ValueChangeCheck (mainSlider.GetComponent<Slider>().value);
		});

		// Initialize popup and hide as default
		popup = GameObject.Find("Popup");
		popup.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ValueChangeCheck(float newValue) {

		if (newValue >= 0.5) {
			popup.SetActive (true);
		} else {
			popup.SetActive (false);
		}
	
	}
}
