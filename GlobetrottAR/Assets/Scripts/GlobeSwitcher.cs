using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Vuforia;

//[RequireComponent(typeof (VuforiaBehaviour))]
public class GlobeSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StateManager sm = TrackerManager.Instance.GetStateManager ();

		// Query the StateManager to retrieve the list of
		// currently 'active' trackables 
		//(i.e. the ones currently being tracked by Vuforia)
		IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours ();

//		struct sortableTrackables;
		TrackableBehaviour bestTrack = null;
		float closestTrack = 0f;

		// Iterate through the list of active trackables
		Debug.Log ("List of trackables currently active (tracked): ");
		foreach (TrackableBehaviour tb in activeTrackables) {
			Debug.Log("Trackable: " + tb.TrackableName);


			GameObject earthChild = tb.gameObject.transform.FindChild ("Earth").gameObject;

			float diff = (earthChild.transform.position - transform.position).magnitude;

			earthChild.SetActive (false);

			if(bestTrack == null){
				Debug.Log("Best track set because of null check to "+tb.name);
				bestTrack = tb;
				closestTrack = diff;
				continue;
			}

			Debug.Log ("Multiple simultaneous trackers!");
			Debug.Log (diff < closestTrack);

			if (diff < closestTrack) {
				Debug.Log ("New best track found because of distance, set to: "+tb.name);
				bestTrack = tb;
				closestTrack = diff;
			}
		}

		if (bestTrack != null) {
			Debug.Log ("Best track: "+bestTrack.gameObject.name);
			bestTrack.gameObject.transform.FindChild ("Earth").gameObject.SetActive (true);
		}
		

	}
}
