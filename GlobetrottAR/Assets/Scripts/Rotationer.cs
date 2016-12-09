using UnityEngine;
using System.Collections;

public class Rotationer : MonoBehaviour {

	public Transform globe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(globe.position);
	}
}
