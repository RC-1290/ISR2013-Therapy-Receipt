using UnityEngine;
using System.Collections;

public class ReceiptGUI : MonoBehaviour {
	
	public Rect windowLocation = new Rect(100,100,100,100);
	public Client currentClient;
	public BudgetScreen budget; 
	
	private GameRound currentRound;
	
	
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		GUILayout.TextArea("Current Twitchyness: " + currentClient.Insanity);
		
		
		if (GUILayout.Button("Higher Cost")){
			budget.availableFunds += currentRound.higherPrice;
			currentClient.Insanity += currentRound.highPriceInsanityAdjustment;
			CloseScreen();
		}
		else if (GUILayout.Button("Regular Cost")){
			budget.availableFunds += currentRound.regularPrice;
			CloseScreen();
		}
		else if (GUILayout.Button("Lower Cost")){
			budget.availableFunds += currentRound.lowerPrice;
			currentClient.Insanity += currentRound.lowPriceInsanityAdjustment;
			CloseScreen();
		}
		
		
		
		
		GUILayout.EndArea();
	}
	
	public void SetupClientReceipt(Client targetClient, GameRound currentRound){
		Debug.Log("Setup Client Receipt");
		this.currentRound = currentRound;
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
