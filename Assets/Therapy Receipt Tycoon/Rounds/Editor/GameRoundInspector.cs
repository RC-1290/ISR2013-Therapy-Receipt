using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GameRound))]
public class GameRoundInspector : Editor {
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
//		
//		EditorGUI.BeginChangeCheck();
//		
//
//		
//		if (EditorGUI.EndChangeCheck()){
//			int selectedObjectsCount = serializedObject.targetObjects.Length;
//			for (int i = 0; i < selectedObjectsCount; i++) {
//				EditorUtility.SetDirty(serializedObject.targetObjects[i]);
//			}
//			
//		}
				
	}
	
}
