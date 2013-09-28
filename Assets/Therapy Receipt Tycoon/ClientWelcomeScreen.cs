using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ClientWelcomeScreen : MonoBehaviour {
	
	public event ClientEventHandler clientWelcomed;
	
	public Rect windowLocation = new Rect(100,100, 100,100);
	
	public Client currentClient;
	public ClientCreator clientBuilder;
	
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		
		if (this.currentClient == null){
			if (GUILayout.Button("Invite next client")){
				if (clientBuilder == null) throw new MissingReferenceException("You need to assign a client Builder");
				currentClient = clientBuilder.CreateClient();
			}
		}
		else if (currentClient != null){
			GUILayout.TextArea("Insanity level: " + currentClient.insanity);
				
			if (GUILayout.Button("Take a seat")){
				OnClientWelcomed();
			}
		}
		GUILayout.EndArea();
		
	}
	
	

	
	
	private void OnClientWelcomed(){
		currentClient = null;
		this.enabled = false;
		if (clientWelcomed != null){
			clientWelcomed(currentClient);
		}
	}
	
}
