using UnityEngine;
using System.Collections;

public class ReceiptGUI : MonoBehaviour {
	
	public Rect windowLocation = new Rect(100,100,100,100);
	public Client currentClient;
	public BudgetScreen budget;
//	public 
	
	public decimal regularPrice = 200;
	public decimal reducedPrice = 150;
	public decimal increasedPrice = 300;
	
	
	public float insanityIncrease = 0.1f;
	public float insanityDecrease = -0.1f;
	
	protected void OnGUI(){
		GUILayout.BeginArea(windowLocation);
		
		GUILayout.TextArea("Current Twitchyness: " + currentClient.Insanity);
		
		if (GUILayout.Button("Regular Cost")){
			budget.funds -= regularPrice;
			CloseScreen();
		}
		else if (GUILayout.Button("Higher Cost")){
			budget.funds -= increasedPrice;
			currentClient.Insanity += insanityIncrease;
			CloseScreen();
		}
		else if (GUILayout.Button("Lower Cost")){
			budget.funds -= reducedPrice;
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
		this.enabled = false;
		this.currentClient = null;
	}
	
}
