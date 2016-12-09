using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Vuforia;

//[RequireComponent(typeof (VuforiaBehaviour))]
public class GlobeSwitcher : MonoBehaviour {
	Canvas developerUI;

	// Use this for initialization
	void Start () {
		developerUI = GameObject.Find ("DeveloperFeedback").GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		StateManager sm = TrackerManager.Instance.GetStateManager ();

		// Query the StateManager to retrieve the list of
		// currently 'active' trackables 
		//(i.e. the ones currently being tracked by Vuforia)
		IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours ();

		TrackableBehaviour bestTrack = null;
		float closestTrack = 0f;

		string trackablesList = "";
		string bestTrackString = "No current tracks";

		foreach (TrackableBehaviour tb in activeTrackables) {
			GameObject earthChild = tb.gameObject.transform.FindChild ("Earth").gameObject;

			float diff = (earthChild.transform.position - transform.position).magnitude;

			Vector3 normalVector = tb.transform.TransformDirection(0,-1,0);
			Vector3 cameraFacingVector = gameObject.transform.TransformDirection(0,0,1);

			float diffAngle = Vector3.Angle (normalVector, cameraFacingVector);

			trackablesList += tb.TrackableName + " : "+diffAngle.ToString()+"\n";
			earthChild.SetActive (false);

			if(bestTrack == null){
				Debug.Log("Best track set because of null check to "+tb.name);
				bestTrack = tb;
				closestTrack = diffAngle;
				continue;
			}
				
			if (diffAngle < closestTrack) {
				Debug.Log ("New best track found because of distance, set to: "+tb.name);
				bestTrack = tb;
				closestTrack = diff;
			}
		}

		developerUI.gameObject.transform.FindChild ("Number of Tracks").GetComponent<Text> ().text = trackablesList;

		if (bestTrack != null) {
			Debug.Log ("Best track: "+bestTrack.gameObject.name);
			bestTrackString = bestTrack.gameObject.name;
			bestTrack.gameObject.transform.FindChild ("Earth").gameObject.SetActive (true);
			developerUI.gameObject.transform.FindChild ("Current Track").GetComponent<Text> ().text = bestTrack.gameObject.name;
		}


	}
}
