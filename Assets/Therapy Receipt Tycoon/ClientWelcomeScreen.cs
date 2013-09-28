using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ClientWelcomeScreen : MonoBehaviour {
	
	public Rect windowLocation = new Rect(100,100, 100,100);
	
	public Client currentClient;
	
	
	private Queue<Client> waitingRoom = new Queue<Client>();
	
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		
		if (this.currentClient != null){
		
			GUILayout.TextArea("Insanity level: " + currentClient.insanity);
			
			
			if (GUILayout.Button("Take a seat")){
				this.waitingRoom.Enqueue(currentClient);		
			}
		}
		else {
			GUILayout.TextArea("No more clients! D:");
			
			if (GUILayout.Button("Do whatever")){
				
			}
		}
		
		GUILayout.EndArea();
		
	}
}
