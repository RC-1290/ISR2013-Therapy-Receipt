using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GameRound))]
public class GameRoundInspector : Editor {
	
	private SerializedProperty clientCount;
	
	protected void OnEnable(){
//		this.clientCount = serializedObject.FindProperty("newClientCount");	
	}
	
	
	public override void OnInspectorGUI (){
		EditorGUIUtility.LookLikeInspector();
		base.OnInspectorGUI ();
		
//		EditorGUI.BeginChangeCheck();
//		
//		EditorGUILayout.PropertyField(clientCount);
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
