using UnityEngine;
using System.Collections;

public class Rotationer : MonoBehaviour {

	public Transform globe;
//	public Quaternion direction;
	public Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(lastPosition, transform.position - globe.position);
		lastPosition = transform.position;
	}
}
