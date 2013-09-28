using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class ClientWelcomeScreen : MonoBehaviour {
	
	public Rect windowLocation = new Rect(100,100, 100,100);
	
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		if (GUILayout.Button("Take a seat")){
			//
			
			
		}
		
		
		GUILayout.EndArea();
		
	}
}
