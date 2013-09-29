using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour {
	
	public ClientCreator clientBuilder;
	public ClientWelcomeScreen welcomeScreen;
	public WaitingRoom mainWaitingRoom;
	public TherapyRoom therapy;
	public ReceiptGUI paymentCounter;
	public HiddenWaitingRoom hiddenRoom;
	public BudgetScreen BudgetOverview;
	
	private int ClientCount;
	private bool StartOfRound = true;
	private bool CreatingNewClient = false;
	
	
	protected void Start(){
		welcomeScreen.clientWelcomed += HandleWelcomeScreenclientWelcomed;
		mainWaitingRoom.ClientEnteredWaitingRoom += HandleClientEnteredWaitingRoom;
		therapy.TherapyCompleted += HandleTherapyTherapyCompleted;
	}
	
	protected void Update(){
		if (ClientCount < GlobalData.MaxClientsPerRound && !CreatingNewClient)
		{
			if (StartOfRound)
			{
				NewClient();
				ClientCount++;
				StartOfRound = false;
			}
			else
			{
				Invoke("NewClient", GlobalData.MinSpawnDelay + Random.value*(GlobalData.MaxSpawnDelay-GlobalData.MinSpawnDelay));
				CreatingNewClient = true;
				ClientCount++;
			}
		}
		if (!hiddenRoom.isEmpty && welcomeScreen.currentClient == null && paymentCounter.currentClient == null)
		{
			welcomeScreen.WelcomeClient(hiddenRoom.GetClient());
		}
		if (GlobalData.passedClients == GlobalData.MaxClientsPerRound*(GlobalData.round+1))
		{
			EndRound();	
		}
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
	
	public void NewClient()
	{
		Client targetClient = clientBuilder.CreateClient();
		hiddenRoom.AddClient(targetClient);
		CreatingNewClient = false;
	}
	
	public void EndRound()
	{
		BudgetOverview.applyCosts();
	 	if (BudgetOverview.GameOver)
		{
			ShowGameOverScreen();
			return;
		}
		BudgetOverview.ResetRoundFunds();
		ClientCount = 0;
		GlobalData.round++;
		StartOfRound = true;
	}
	
	public void ShowGameOverScreen(){
		
		// Display stats
		// Number of clients
		// total income
		
	}
	
}
