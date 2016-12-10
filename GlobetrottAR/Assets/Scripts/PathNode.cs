using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {

	public bool showInTimeline = false;
	public float length = 1f;
	public float timeInSek = 1f;
	[HideInInspector]
	public float time = 0f;
	public PathNode next = null;
	public string dateText = "2047";


	// Use this for initialization
	void Start () {
		// Get next node
		int index = transform.GetSiblingIndex();
		if (index + 1 < transform.parent.childCount) {
			next = (PathNode)transform.parent.GetChild (index + 1).transform.GetComponent<PathNode>();
		}

		time = timeInSek * 1000f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public Vector3 GetPosition(float t) {
		if (next == null) 
			return Vector3.zero;

		float diff = t / time;
		return Vector3.Lerp (transform.position, next.transform.position, diff);
	}

	public void SetLength(float l) {
		length = l;
	}

	void OnDrawGizmosSelected() {
		if (next != null) {
			Gizmos.color = Color.white;
			Gizmos.DrawLine(transform.position, next.transform.position);
		}
	}
}
