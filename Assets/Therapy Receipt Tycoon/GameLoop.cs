using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour {
	
	public ClientWelcomeScreen welcomeScreen;
	public WaitingRoom mainWaitingRoom;
	public TherapyRoom therapy;
	public ReceiptGUI paymentCounter;
	
	
	protected void Start(){
		welcomeScreen.clientWelcomed += HandleWelcomeScreenclientWelcomed;
		mainWaitingRoom.ClientEnteredWaitingRoom += HandleClientEnteredWaitingRoom;
		therapy.TherapyCompleted += HandleTherapyTherapyCompleted;
	}

	private void HandleTherapyTherapyCompleted (Client targetClient){
		MoveClientToPaymentCounter(targetClient);
	}

	private void HandleWelcomeScreenclientWelcomed (Client targetClient){
		MoveClientToWaitingroom(targetClient);
	}
	
	private void HandleClientEnteredWaitingRoom(Client targetClient){
		MoveClientToTherapy();
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void WelcomeClient(){
		
		
	}
	
	public void MoveClientToWaitingroom(Client currentClient){
		mainWaitingRoom.SendClientToWaitingRoom(currentClient);
	}
	
	public void MoveClientToTherapy(){
		Client targetClient = mainWaitingRoom.TakeClient();
		
		therapy.ApplyTherapy(targetClient);
	}
	
	public void MoveClientToPaymentCounter(Client targetClient){
		paymentCounter.SetupClientReceipt(targetClient);
	}
	
	public void ShowBudgetBalance(){
		float budget = 10f;
		
		if ( GUILayout.Button("Continue")){
			if (budget <  0){
				ShowGameOverScreen();
			}
		}
		
		
	}
	
	public void ShowGameOverScreen(){
		
		// Display stats
		// Number of clients
		// total income
		
	}
	
}
