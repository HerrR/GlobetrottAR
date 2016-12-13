using UnityEngine;
using System.Collections;

public class Coordinator : MonoBehaviour {
	public float mapWidth;
	public float mapHeight;

    public float textureWidth;
    public float textureHeight;

    public float textureWidthPixels;
    public float textureHeightPixels;

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

	public Vector3 GetGlobePosition() {
		Vector2 lonLat = MapToLonLat (transform.position);
		return LonLatToWorld (lonLat.x, lonLat.y);
	}

	public Vector3 GetGlobePosition(Vector3 pos) {
		Vector2 lonLat = MapToLonLat (pos);
		return LonLatToWorld (lonLat.x, lonLat.y);
	}

    public Vector2 GetTexturePos() {
        float x = (transform.position.x + textureWidth / 2) / textureWidth;
        float y = (transform.position.y + textureHeight / 2) / textureHeight;
        x *= textureWidthPixels;
        y *= textureHeightPixels;

        return new Vector2(x, y);
    }

    public Vector2 GetTextureOffset() {
        Vector2 pos = -GetTexturePos();
        pos.x /= textureWidthPixels;
        pos.x -= 0.5f;
        pos.y /= textureHeightPixels;
        pos.y -= 0.5f;
        return pos;
    }
}
