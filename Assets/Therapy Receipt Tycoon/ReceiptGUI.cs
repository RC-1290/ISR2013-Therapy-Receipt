using UnityEngine;
using System.Collections;

public class ReceiptGUI : MonoBehaviour {
	
	public Rect windowLocation = new Rect(100,100,100,100);
	public Client currentClient;
	public BudgetScreen budget; 
	
	
	public float insanityIncrease = 0.1f;
	public float insanityDecrease = -0.1f;
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		GUILayout.TextArea("Current Twitchyness: " + currentClient.Insanity);
		
		if (GUILayout.Button("Regular Cost")){
			budget.funds += GlobalData.AveragePrice;
			CloseScreen();
		}
		else if (GUILayout.Button("Higher Cost")){
			budget.funds += GlobalData.HigherPrice;
			currentClient.Insanity += insanityIncrease;
			CloseScreen();
		}
		else if (GUILayout.Button("Lower Cost")){
			budget.funds += GlobalData.LowerPrice;
			currentClient.Insanity =- insanityDecrease;
			CloseScreen();
		}
		
		
		
		
		GUILayout.EndArea();
	}
	
	public void SetupClientReceipt(Client targetClient){
		Debug.Log("Setup Client Receipt");
		this.currentClient = targetClient;
		this.enabled = true;
	}
	
	private void CloseScreen(){
		GlobalData.passedClients++;
		this.enabled = false;
		Destroy(this.currentClient);
		this.currentClient = null;
	}
	
}
