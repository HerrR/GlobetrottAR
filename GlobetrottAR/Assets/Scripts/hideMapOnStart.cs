using UnityEngine;
using System.Collections;

public class hideMapOnStart : MonoBehaviour {
	public GameObject[] objectsToHide;

	// Use this for initialization
	void Start () {
		objectsToHide = GameObject.FindGameObjectsWithTag("hideOnStart");
		foreach (GameObject obj in objectsToHide) {
			obj.GetComponent<MeshRenderer> ().enabled = false;
		}
	
	}
}