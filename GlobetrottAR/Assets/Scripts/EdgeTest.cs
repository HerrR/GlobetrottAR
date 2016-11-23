using UnityEngine;
using System.Collections;
using Vuforia;

public class EdgeTest : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour trackBehaviour;

	void Start () {
		trackBehaviour = GetComponent<TrackableBehaviour> ();
		if (trackBehaviour) {
			trackBehaviour.RegisterTrackableEventHandler (this);
		}

	}
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			Debug.Log ("OBJECT TRACKED OMGOMGOMG");
		} else {
			Debug.Log ("TRACK LOST OMGOMGOMG");
		}
	}
}