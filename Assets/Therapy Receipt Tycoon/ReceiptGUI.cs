using UnityEngine;
using System.Collections;

public class ReceiptGUI : MonoBehaviour {
	
	public Rect windowLocation = new Rect(100,100,100,100);
	public Client currentClient;
	
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		if (GUILayout.Button("Close")){
			this.enabled = false;
			this.currentClient = null;
		}
		
		GUILayout.EndArea();
	}
	
	public void SetupClientReceipt(Client targetClient){
		Debug.Log("Setup Client Receipt");
		this.currentClient = targetClient;
		this.enabled = true;
	}
	
}
