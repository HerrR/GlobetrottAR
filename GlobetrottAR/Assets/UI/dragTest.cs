using UnityEngine;
using System.Collections;

public class dragTest : MonoBehaviour {

	float offsetX;

	public void BeginDrag() {
		offsetX = transform.position.x - Input.mousePosition.x;
	}

	public void OnDrag() {
		float newPos = offsetX + Input.mousePosition.x;
		if (newPos >= -400 && newPos <= 1200) { // Hårdkodade positions för kanten på skärmen
			transform.position = new Vector3 (newPos, transform.position.y);
		}
	}

}
