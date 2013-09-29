using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour {
	
	public ClientCreator clientBuilder;
	public ClientWelcomeScreen welcomeScreen;
	public WaitingRoom mainWaitingRoom;
	public TherapyRoom therapy;
	public ReceiptGUI paymentCounter;
	public BudgetScreen BudgetOverview;
	
	private Queue<Client> clientsWaitingAtDesk = new Queue<Client>();
	
	public List<GameRound> rounds = new List<GameRound>();
	private int currentRoundId = 0;
	
	
	protected void Start(){
		welcomeScreen.clientWelcomed += HandleWelcomeScreenclientWelcomed;
		mainWaitingRoom.ClientEnteredWaitingRoom += HandleClientEnteredWaitingRoom;
		therapy.TherapyCompleted += HandleTherapyTherapyCompleted;
		paymentCounter.ClientPaidForTherapy += HandleClientPaidForTherapy;
		
		StartRound();
	}

	void HandleClientPaidForTherapy (Client targetClient){
		if (targetClient.Insanity > 0){
			clientBuilder.ScheduleNextAppointment(targetClient);	
		}
		else Destroy(targetClient);// Client has recovered completely
	}
	
	protected void Update(){
		if (!IsAnyScreenVisible()) {
			if (clientsWaitingAtDesk.Count > 0){
				Client nextCustomer = this.clientsWaitingAtDesk.Dequeue();
				
				switch(nextCustomer.currentGoal){
				case ClientGoal.GetTherapy:
					welcomeScreen.WelcomeClient(nextCustomer);
					break;
				case ClientGoal.PayForTherapy:
					paymentCounter.SetupClientReceipt(nextCustomer, rounds[currentRoundId]);
					break;
				}
			}
			else{
				//TODO: If no more clients will be coming, show end of round stuff.
				//Otherwise, just wait for clients to show up.
			}
		}
		
		
	}
	
	private void StartRound(){
		NewClient();
		BudgetOverview.currentCost = rounds[currentRoundId].businessCosts;
	}

	private void HandleTherapyTherapyCompleted (Client targetClient){
		targetClient.currentGoal = ClientGoal.PayForTherapy;
		clientsWaitingAtDesk.Enqueue(targetClient);
	}

	private void HandleWelcomeScreenclientWelcomed (Client targetClient){
		MoveClientToWaitingroom(targetClient);
	}
	
	private void HandleClientEnteredWaitingRoom(Client targetClient){
		MoveClientToTherapy();
	}

	
	public void MoveClientToWaitingroom(Client currentClient){
		mainWaitingRoom.SendClientToWaitingRoom(currentClient);
	}
	
	public void MoveClientToTherapy(){
		Client targetClient = mainWaitingRoom.TakeClient();
		
		therapy.ApplyTherapy(targetClient);
	}
	
	public void ShowBudgetBalance(){
		float budget = 10f;
		
		if ( GUILayout.Button("Continue")){
			if (budget <  0){
				ShowGameOverScreen();
			}
		}
		
		
	}
	
	public void NewClient(){
		Client targetClient = clientBuilder.CreateClient();
		clientsWaitingAtDesk.Enqueue(targetClient);
	}
	
	public void EndRound()
	{
		BudgetOverview.applyCosts();
	 	if (BudgetOverview.IsGameOver)
		{
			ShowGameOverScreen();
			return;
		}
		BudgetOverview.ResetRoundFunds();
		this.currentRoundId++;
	}
	
	public void ShowGameOverScreen(){
		
		// Display stats
		// Number of clients
		// total income
		
	}
	
	private bool IsAnyScreenVisible(){
		return this.welcomeScreen.enabled || this.BudgetOverview.enabled || this.paymentCounter.enabled;
	}
	
}
