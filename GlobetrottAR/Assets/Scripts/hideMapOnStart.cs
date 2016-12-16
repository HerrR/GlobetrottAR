using UnityEngine;
using System.Collections;

public class hideMapOnStart : MonoBehaviour {
	public GameObject[] objectsToHide;

	void Start () {
		DisableMeshRenderers ();
	}

	void DisableMeshRenderers(){
		objectsToHide = GameObject.FindGameObjectsWithTag("hideOnStart");
		foreach (GameObject obj in objectsToHide) {
			obj.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}