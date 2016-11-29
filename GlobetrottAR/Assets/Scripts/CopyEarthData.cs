using UnityEngine;
using System.Collections;
//using UnityEditor;


public class CopyEarthData : MonoBehaviour {
	public Vector3 pos;
	public Vector3 rot;

	public void CopyData() {
		pos = gameObject.transform.FindChild ("Earth").gameObject.transform.position;
		rot = gameObject.transform.FindChild ("Earth").gameObject.transform.rotation.eulerAngles;
	}
}


//[CustomEditor(typeof(CopyEarthData))]
//public class ObjectBuilderEditor : Editor
//{
//	public override void OnInspectorGUI()
//	{
//		DrawDefaultInspector();
//
//		CopyEarthData myScript = (CopyEarthData)target;
//		if(GUILayout.Button("Copy earth data"))
//		{
//			myScript.CopyData();
//		}
//	}
//}