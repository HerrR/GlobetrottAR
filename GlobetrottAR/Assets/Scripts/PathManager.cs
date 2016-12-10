using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour {

	public PathSystem activePath;

	public void SetPath(PathSystem path) {
		activePath = path;
	}
}
