using UnityEngine;
using UnityEditor;
using System.Collections;

public class GameRoundMenuItem : ScriptableObject {

	[MenuItem("Assets/Create/Round")]
	public static void CreateSimTextureSettingsAsset(){
		var asset = CreateInstance<GameRound>();
		
		string assetPath = createFullPath("Game Round");
		
		AssetDatabase.CreateAsset(asset, assetPath);
		
		EditorUtility.FocusProjectWindow();
		EditorGUIUtility.PingObject(asset);
		Selection.activeObject = asset;		
	}
	
	/// <summary>
	/// Creates a path string to the given asset, based on the selected object or folder.
	/// </summary>
	/// <returns>
	/// A string containing the path based on the selected object or folder.
	/// </returns>
	/// <param name='assetName'>
	/// Name of the asset the path is for.
	/// </param>
	private static string createFullPath(string assetName){
		string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (assetPath == "") assetPath = "Assets";
		else if (System.IO.Path.GetExtension(assetPath) != ""){
			assetPath = assetPath.Replace(System.IO.Path.GetFileName(assetPath), "");	
		}
		string fullPath = AssetDatabase.GenerateUniqueAssetPath(assetPath + "/" + assetName + ".asset");
		
		return fullPath;
	}
}
