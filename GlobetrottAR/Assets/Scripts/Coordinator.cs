using UnityEngine;
using System.Collections;

public class Coordinator : MonoBehaviour {
	public float mapWidth;
	public float mapHeight;

	private Vector3 center;
	private float scale;

	// Use this for initialization
	void Start () {
		center = transform.position;
	}

	Vector2 MapToLonLat(Vector3 pos) {
		float lon = (pos.x / mapWidth) * 360f;
		float lat = (pos.y / mapHeight) * 180f;
		return new Vector2 (lat, lon);
	}

	Vector3 LonLatToWorld(float lat, float lon) {
		return Quaternion.AngleAxis(lon, -Vector3.up) * Quaternion.AngleAxis(lat, -Vector3.right) * new Vector3(0,0,1); 
	}

	public Vector3 getGlobePosition() {
		Vector2 lonLat = MapToLonLat (transform.position);
		return LonLatToWorld (lonLat.x, lonLat.y);
	}
}
