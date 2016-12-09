using UnityEngine;
using System.Collections;

public class Positioner : MonoBehaviour {

	public Coordinator coordinator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = coordinator.GetGlobePosition ();
	}
}
