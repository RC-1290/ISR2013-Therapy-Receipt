using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ClientWelcomeScreen : MonoBehaviour {
	
	public event ClientEventHandler clientWelcomed;
	
	public Rect windowLocation = new Rect(100,100, 100,100);
	
	public Client currentClient;
	
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		
		if (this.currentClient == null){
			GUILayout.TextArea("It's currently quite calm");
		}
		else if (currentClient != null){
			GUILayout.TextArea("Insanity level: " + currentClient.Insanity);
				
			if (GUILayout.Button("Take a seat")){
				Client targetClient = this.currentClient;
				OnClientWelcomed(targetClient);
				currentClient = null;
				this.enabled = false;
			}
		}
		GUILayout.EndArea();
		
	}
	
	public void WelcomeClient(Client targetClient){
		this.enabled = true;
		Debug.Log("Welcoming client: " + targetClient);
		if (this.currentClient == null){
			this.currentClient = targetClient;
		}
	}

	
	
	private void OnClientWelcomed(Client targetClient){
		if (clientWelcomed != null){
			clientWelcomed(targetClient);
		}
	}
	
}
