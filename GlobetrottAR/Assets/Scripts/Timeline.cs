using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timeline : MonoBehaviour {

	public TimeSync timeSync;

	public PathManager pathManager;
	private PathSystem path;
	public RectTransform bg;
	private PathNode[] nodes;

	public float scale = 10f;
	private float direction = -1f;

	private bool running = false;


	public GameObject datePrefab;

	private RectTransform rt;


	// Use this for initialization
	void Start () {

		path = pathManager.activePath;

		rt = GetComponent<RectTransform> ();
		Debug.Log (rt.rect);


		//nodes = new List<PathNode> ();
		nodes = path.GetNodes ();

		// Set width of content
		Vector3 lastPos = CalculateDatePos(nodes[nodes.Length - 1], nodes.Length - 1);
		float width = lastPos.x;
		rt.sizeDelta = new Vector2(width + 500f, rt.rect.height);
		bg.sizeDelta = new Vector2(width + 500f, bg.rect.height);

		// Add dates
		for (int i = 0; i < nodes.Length; i++) {
			if (nodes[i].showInTimeline) {
				AddDate (nodes[i], i);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			rt.localPosition = rt.localPosition + new Vector3 (timeSync.deltaTime * scale * direction, 0f, 0f);
		} else {
			UpdateTime ();
		}
	}

	void AddDate(PathNode node, int index) {
		GameObject go = (GameObject)Instantiate (datePrefab, transform);
		Vector3 pos = CalculateDatePos (node, index);
		RectTransform rect = go.GetComponent<RectTransform> ();
		rect.localPosition = pos;
		Text text = go.GetComponent<Text> ();
		text.text = node.dateText;
	}

	Vector3 CalculateDatePos(PathNode node, int index) {
		float totalTime = 0f;
		float totalLength = 0f;
		for (int i = 0; i < index; i++) {
			totalTime += nodes [i].timeInSek;
			totalLength += nodes [i].length;
		}
		return new Vector3 (totalTime * scale + 500f, 0f, 0f);
	}

	public void Stop() {
		running = false;
		timeSync.SetTimeMultiplier (0f);
	}

	public void Play() {
		running = true;
		timeSync.SetTimeMultiplier (1f);
	}

	void UpdateTime() {
		timeSync.SetTime((rt.localPosition.x * -1 - 500f) / scale);
	}
}
