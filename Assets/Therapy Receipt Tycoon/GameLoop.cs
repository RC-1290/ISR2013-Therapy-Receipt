using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour {
	
	public gameScreen currentScreen;
	
	
	
	public enum gameScreen{
		ClientWelcome,
		ClientMovingToWaitingRoom,
		ClientMovingToPaymentCounter,
		ReceiptGUI,
		BudgetBalance,
		GameOver
	}
	
	
	
	// Update is called once per frame
	void Update () {
		switch(currentScreen){
		
		case gameScreen.ClientWelcome:
			WelcomeClient();
			break;
		case gameScreen.ClientMovingToWaitingRoom:
			MoveClientToWaitingroom();
			break;
		case gameScreen.ClientMovingToPaymentCounter:
			
			MoveClientToPaymentCounter();
			break;
		case gameScreen.ReceiptGUI:
			MoveClientToPaymentCounter();
			break;
		case gameScreen.BudgetBalance:
			ShowBudgetBalance();
			break;
		case gameScreen.GameOver:
			ShowGameOverScreen();
			break;
			
			
		}
		
		MoveClientToTherapy();
		
		
		
		
		
		

		
		
	}
	
	public void WelcomeClient(){
		
		
	}
	
	public void MoveClientToWaitingroom(){
//		waitingRoom.Enqueue(
	}
	
	public void MoveClientToTherapy(){
		
	}
	
	public void MoveClientToPaymentCounter(){
		
	}
	
	public void ShowReceiptGUI(){
		
	}
	
	public void ShowBudgetBalance(){
		float budget = 10f;
		
		if ( GUILayout.Button("Continue")){
			if (budget <  0){
				currentScreen = gameScreen.GameOver;
			}
		}
		
		
	}
	
	public void ShowGameOverScreen(){
		
		// Display stats
		// Number of clients
		// total income
		
	}
	
}
