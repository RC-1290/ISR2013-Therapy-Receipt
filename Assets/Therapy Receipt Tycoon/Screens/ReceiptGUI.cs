using UnityEngine;
using System.Collections;

public class ReceiptGUI : MonoBehaviour {
	
	public event ClientEventHandler ClientPaidForTherapy;
	
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
		OnClientPaidForTherapy(this.currentClient);
		currentClient.currentGoal = ClientGoal.GetTherapy;
		this.currentClient = null;
	}
	
	private void OnClientPaidForTherapy(Client targetClient){
		if (ClientPaidForTherapy != null){
			ClientPaidForTherapy(targetClient);
		}
	}
	
}
