using UnityEngine;
using System.Collections;

public class ModelChanger : MonoBehaviour {

	public PathSystem pathSystem;
	public GameObject waterModel;
	public GameObject landModel;
	private GameObject activeModel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (pathSystem.nextNode.travelToOnWater) {
			activeModel = waterModel;
		} else {
			activeModel = landModel;
		}

		if (activeModel == waterModel) {
			waterModel.SetActive (true);
			landModel.SetActive (false);
		} else {
			landModel.SetActive (true);
			waterModel.SetActive (false);
		}
	}
}
