using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathSystem : MonoBehaviour {

	public PathNode root;
	public PathNode nextNode;

	private float totalLength = 0f;

	void Start () {
		// Calculate total length and set length on every node
		PathNode currentNode = root;
		while (currentNode.next != null) {
			float length = Vector3.Distance (currentNode.transform.position, currentNode.next.transform.position);
			currentNode.SetLength (length);
			totalLength += length;
			currentNode = currentNode.next;
		}
	}

	public Vector3 GetPosition(float time) {
		nextNode = root;
		PathNode parent = null;
		float timeCounter = 0f;
		while (timeCounter <= time) {
			timeCounter += nextNode.time;
			if (nextNode.next != null) {
				parent = nextNode;
				nextNode = nextNode.next;
			} else {
				// Just return last nodes position
				return nextNode.transform.position;
			}
		}
		float timeDiff = parent.time - (timeCounter - time);
		return parent.GetPosition (timeDiff);
	}

	float GetDistance(Vector3 pos1, Vector3 pos2) {
		return Vector3.Distance (pos1, pos2);
	}
}
