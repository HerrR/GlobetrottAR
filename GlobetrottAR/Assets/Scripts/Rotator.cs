using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public Vector3 rotation;
    public float rotationSpeed = 5;

	// Use this for initialization
	void Start () {
        rotation *= rotationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
