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
	
	private int therapiesPaidCount;
	private int totalVisitorsThisRound;
	
	public Rect statusScreenLocation = new Rect(100,100,100,100);
	
	public GUISkin skin;
	
	protected void Start(){
		clientBuilder.ClientArrived += HandleClientArrived;
		welcomeScreen.clientWelcomed += HandleWelcomeScreenclientWelcomed;
		mainWaitingRoom.ClientEnteredWaitingRoom += HandleClientEnteredWaitingRoom;
		therapy.TherapyCompleted += HandleTherapyTherapyCompleted;
		paymentCounter.ClientPaidForTherapy += HandleClientPaidForTherapy;
		
		StartRound();
	}
	
	protected void OnGUI(){
		GUISkin originalSkin = GUI.skin;
		GUI.skin = this.skin;
		
		GUILayout.BeginArea(this.statusScreenLocation);
		
		GUILayout.TextArea("Level " + (this.currentRoundId + 1));
		
		GUILayout.TextArea("Remaining Appointments: " + this.clientBuilder.RemainingAppointments);
		
		int clientsWaitingCount = this.clientsWaitingAtDesk.Count;
		if (this.welcomeScreen.currentClient != null) clientsWaitingCount++;
		GUILayout.TextArea("Number of Waiting Clients: " + clientsWaitingCount);
		
		GUILayout.EndArea();
		
		GUI.skin = originalSkin;
	}
	

	void HandleClientArrived (Client targetClient){
		clientsWaitingAtDesk.Enqueue(targetClient);
		Debug.Log("Client Arrived. " + clientsWaitingAtDesk.Count + " clients are waiting");
	}

	void HandleClientPaidForTherapy (Client targetClient){
		this.therapiesPaidCount++;
		if (targetClient.Insanity > 0){
			clientBuilder.ScheduleNextAppointment(targetClient);	
		}
		else Destroy(targetClient);// Client has recovered completely
	}
	
	protected void Update(){
		if (!IsAnyScreenVisible()) {
			if (clientsWaitingAtDesk.Count > 0){
				Client nextCustomer = this.clientsWaitingAtDesk.Dequeue();
				Debug.Log(nextCustomer.currentGoal);
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
				if (clientBuilder.RemainingAppointments <= 0 && totalVisitorsThisRound - therapiesPaidCount == 0) EndRound();
				// Otherwise, just wait for clients to show up.
			}
		}
		
		
	}
	
	private void StartRound(){
		GameRound currentRound = rounds[currentRoundId];
		
		clientBuilder.CreateNewClients(currentRound.newClientCount);
		clientBuilder.HandleRoundStarted(currentRound);
		
		this.totalVisitorsThisRound = clientBuilder.RemainingAppointments;
		this.therapiesPaidCount = 0;
		
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
		
		// Teleport client to therapy room:
		targetClient.transform.position = therapy.transform.position;
	}
	
	public void ShowBudgetBalance(){
		float budget = 10f;
		
		if ( GUILayout.Button("Continue")){
			if (budget <  0){
				ShowGameOverScreen();
			}
		}
		
		
	}
	
	public void EndRound(){
		BudgetOverview.applyCosts();
	 	if (BudgetOverview.IsGameOver)
		{
			ShowGameOverScreen();
			return;
		}
		else{
			BudgetOverview.ShowScreen();			
		}
	}
	
	public void NextLevel(){
		BudgetOverview.ResetRoundFunds();
			
		this.currentRoundId++;
		if (this.currentRoundId > this.rounds.Count - 1) this.currentRoundId = 0;// Loop back around.
		StartRound();
	}
	
	public void ShowGameOverScreen(){
		Debug.Log("Game Over");
		// Display stats
		// Number of clients
		// total income
		
	}
	
	private bool IsAnyScreenVisible(){
		return this.welcomeScreen.enabled || this.BudgetOverview.enabled || this.paymentCounter.enabled;
	}
	
}
