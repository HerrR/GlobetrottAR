using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Vuforia;

public class GlobePositionSynchronizer : MonoBehaviour {
	Canvas developerUI;
	GameObject earth;

	Text currentTrackText;
	Text listOfTracksText;

	string currentTrackString;
	string listOfTracksString;

	void Start () {
		developerUI = GameObject.Find ("DeveloperFeedback").GetComponent<Canvas> ();
		earth = GameObject.FindGameObjectWithTag ("Earth");

		if (earth == null) Debug.LogError ("No earth object found! Make sure to add the Earth tag.");

		currentTrackText = developerUI.gameObject.transform.FindChild ("Current Track").GetComponent<Text> ();
		listOfTracksText = developerUI.gameObject.transform.FindChild ("Number of Tracks").GetComponent<Text> ();

		currentTrackString = "Best tracks";
		listOfTracksString = "List of trackables";

	}

	void Update () {
		StateManager sm = TrackerManager.Instance.GetStateManager ();
		IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours ();

		if (activeTrackables.Count () == 0) {
			currentTrackString = "No trackables";
			listOfTracksString = "";
			earth.SetActive (false);
		} else {
			TrackableBehaviour bestTrack = getBestTrack (activeTrackables);
			CopyEarthData earthPositionData = bestTrack.GetComponent<CopyEarthData> ();
			earth.SetActive (true);
//			earth.transform.position = earthPositionData.pos;
			earth.transform.eulerAngles = earthPositionData.rot;
		}

		currentTrackText.text = currentTrackString;
		listOfTracksText.text = listOfTracksString;
	}


	TrackableBehaviour getBestTrack(IEnumerable<TrackableBehaviour> tracks){
		listOfTracksString = "List of tracks \n";
		TrackableBehaviour bestTrack = null;
		float bestTrackAngle = 0f;

		foreach (TrackableBehaviour track in tracks) {
			currentTrackString = track.gameObject.name;

			// Calculate angle diff
			Vector3 normalVector = track.transform.TransformDirection(0,-1,0);
			Vector3 cameraFacingVector = gameObject.transform.TransformDirection(0,0,1);

			float diffAngle = Vector3.Angle (normalVector, cameraFacingVector);

			// UI String Update
			listOfTracksString += track.gameObject.name + " : "+ diffAngle.ToString() +"\n";

			if (bestTrack == null) {
				bestTrack = track;
				bestTrackAngle = diffAngle;
				listOfTracksString += "Selected by NULL \n";
//				continue;
			}

//			listOfTracksString += "Continued after continue \n";
			if (diffAngle < bestTrackAngle) {
				bestTrack = track;
				bestTrackAngle = diffAngle;
				listOfTracksString += "Selected by angle \n";
			}

		}

		return bestTrack;
	}



}
