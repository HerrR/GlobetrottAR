using UnityEngine;
using System.Collections;

public class GlobeEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPosition(Vector3 pos) {
		transform.position = pos;
		transform.LookAt (Vector3.zero);
	}
}
