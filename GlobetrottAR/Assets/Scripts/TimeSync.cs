using UnityEngine;
using System.Collections;

public class TimeSync : MonoBehaviour {

	public float time;
	public float deltaTime;
	public float timeMultiplier;

	// Use this for initialization
	void Start () {
		time = 0f;
		deltaTime = Time.deltaTime;
		timeMultiplier = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime = Time.deltaTime * timeMultiplier;
		time += deltaTime;
		if (time < 0) {
			time = 0f;
		}
	}

	public void SetTimeMultiplier(float t) {
		timeMultiplier = t;
	}

	public void SetTime(float t) {
		time = t;
	}
}
