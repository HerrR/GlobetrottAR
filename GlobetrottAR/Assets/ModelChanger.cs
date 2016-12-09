using UnityEngine;
using System.Collections;

public class ModelChanger : MonoBehaviour {

	public PathSystem pathSystem;
	public GameObject waterModel;
	public GameObject landModel;
	private GameObject activeModel;
	private const float ANIMATION_SPEED_MULTIPLIER = 10.0f;

	// Update is called once per frame
	void Update () {
		// change the model to match land/water
		if (pathSystem.previousNode.travelFromOnWater) {
			activeModel = waterModel;

			// Show and hide correct models
			waterModel.SetActive (true);
			landModel.SetActive (false);
		} else {
			activeModel = landModel;

			// Show and hide correct models
			landModel.SetActive (true);
			waterModel.SetActive (false);
		}
			
		// Set the animation speed of the active model
		SetAnimationSpeed (pathSystem.previousNode.animationSpeed);
	}

	void SetAnimationSpeed(float s){
		Animator animatorController = activeModel.GetComponent<Animator> ();

		// Change the animation speed parameter of the animator controller
		animatorController.SetFloat ("Speed", s * ANIMATION_SPEED_MULTIPLIER);
	}
}
