using UnityEngine;
using System.Collections;

public class PathWalker : MonoBehaviour {

	public PathSystem path;

	public float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (Time.deltaTime);
		if (time < 0) {
			time = 0f;
		}
        time += Time.deltaTime;
		transform.position = path.GetPosition (time * 1000f);
	}
}
