using UnityEngine;
using System.Collections;

public class PathWalker : MonoBehaviour {

	public PathManager pathManager;
	public TimeSync timeSync;

	private float time;
	private PathSystem path;

	// Use this for initialization
	void Start () {
		time = 0f;
		path = pathManager.activePath;
	}
	
	// Update is called once per frame
	void Update () {
		time = timeSync.time;
		transform.position = path.GetPosition (time * 1000f);
	}
}
