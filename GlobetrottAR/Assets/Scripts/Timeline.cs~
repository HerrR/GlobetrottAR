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

	public float scale = 5f;
	private float direction = -1f;

	private bool running = false;


	public GameObject datePrefab;
	public GameObject bgStart;
	public GameObject bgTile1;
	public GameObject bgTile2;
	public GameObject bgEnd;
	public Sprite playSprite;
	public Sprite pauseSprite;

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

		// Add background tiles based on content width (tiles are 400 px wide)
		float tileWidth = bgTile1.GetComponent<RectTransform>().rect.width;
		int numTiles = (int)Mathf.Round(width / tileWidth);

		GameObject startTile = (GameObject)Instantiate (bgStart, transform);
		RectTransform startRect = startTile.GetComponent<RectTransform> ();
		startRect.localPosition = new Vector3 (0, startRect.localPosition.y + (startRect.sizeDelta.y/2), startRect.localPosition.z);

		for (int i = 0; i < numTiles; i++) {
			GameObject tile = (GameObject)Instantiate (bgTile1, transform);
			RectTransform rect = tile.GetComponent<RectTransform> ();
			rect.localPosition = new Vector3 (tileWidth + i * tileWidth, rect.localPosition.y + (rect.sizeDelta.y/2), rect.localPosition.z);
		}
		GameObject endTile = (GameObject)Instantiate (bgEnd, transform);
		RectTransform endRect = endTile.GetComponent<RectTransform> ();
		endRect.localPosition = new Vector3 (tileWidth + numTiles  * tileWidth, endRect.localPosition.y + (endRect.sizeDelta.y/2), endRect.localPosition.z);

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
		rect.localPosition = new Vector3(pos.x, pos.y + 20);
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


	public void PlayPause() {
		if (!running) {
			timeSync.SetTimeMultiplier (1f);
			running = true;
			GameObject.Find ("PlayButton").GetComponent<Image> ().sprite = pauseSprite;
			// Hide EventPopup and its children because it should never be shown while running
			GameObject.Find("EventPopup").GetComponent<Image>().CrossFadeAlpha(0f, 0.5f, false);
			GameObject.Find ("Title").GetComponent<Text> ().CrossFadeAlpha (0f, 0.5f, false);
			GameObject.Find ("Date").GetComponent<Text> ().CrossFadeAlpha (0f, 0.5f, false);
			GameObject.Find ("Year").GetComponent<Text> ().CrossFadeAlpha (0f, 0.5f, false);
			GameObject.Find ("Description").GetComponent<Text> ().CrossFadeAlpha (0f, 0.5f, false);
		} else {
			timeSync.SetTimeMultiplier (0f);
			running = false;
			GameObject.Find ("PlayButton").GetComponent<Image> ().sprite = playSprite;
		}
	}

	void UpdateTime() {
		timeSync.SetTime((rt.localPosition.x * -1 - 500f) / scale);
	}
}
