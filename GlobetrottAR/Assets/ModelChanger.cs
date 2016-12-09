using UnityEngine;
using System.Collections;

public class ModelChanger : MonoBehaviour {

	public PathSystem pathSystem;
	public GameObject waterModel;
	public GameObject landModel;
	private GameObject activeModel;
	private const float ANIMATION_SPEED_MULTIPLIER = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (pathSystem.lastNode.travelFromOnWater) {
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
		SetAnimationSpeed (pathSystem.lastNode.animationSpeed);
	}

	void SetAnimationSpeed(float s){
		Animator animatorController = activeModel.GetComponent<Animator> ();
		animatorController.SetFloat ("Speed", s * ANIMATION_SPEED_MULTIPLIER);
	}
}
