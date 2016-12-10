using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

	float offsetX;

	private int screenWidth, screenHeight;

	private RectTransform rect;

	void Start() {
		rect = gameObject.GetComponent<RectTransform> ();
		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}

	public void BeginDrag() {
		offsetX = transform.position.x - Input.mousePosition.x;
	}

	public void OnDrag() {
		float newPos = offsetX + Input.mousePosition.x;
		//if (newPos <= 0 && newPos >= -rect.rect.width + screenWidth) { // Hårdkodade positions för kanten på skärmen
			transform.position = new Vector3 (newPos, transform.position.y);
		//}
	}
}
