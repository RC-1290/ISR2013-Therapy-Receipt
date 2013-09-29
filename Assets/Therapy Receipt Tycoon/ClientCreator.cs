using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientCreator : MonoBehaviour {
	
	public int RemainingAppointments{
		get { return arrivingClients.Count; }
	}
	
	public event ClientEventHandler ClientArrived;
	public event ClientEventHandler LastClientArrived;
	
	public Client clientPrefab;
	private List<Client> arrivingClients = new List<Client>();
	private List<Client> returningClients = new List<Client>();
	
	private GameRound currentRound;
	public WaitingRoom waitingRoom;
	
	
//	public int clientsToCreateThisRound
	private float lastClientArrived;
	public float clientArrivalDelay = 0;
	
	
	protected void Update(){
		// Wait untill its time for another guest arrival:
		if (Time.time >  lastClientArrived + clientArrivalDelay){
			if (waitingRoom.hasEmptySeats) SendNextClient();
			lastClientArrived = Time.time;
			clientArrivalDelay = Random.value * (currentRound.customerArrivalDelayMax - currentRound.customerArrivalDelayMin) + currentRound.customerArrivalDelayMin;
		}
	}
	
	
	protected void OnGUI(){
		
		
	}
	
	/// <summary>
	/// Should be called at the start of a round.
	/// </summary>
	public void HandleRoundStarted(GameRound currentRound){
		this.enabled = true;
		this.clientArrivalDelay = 0;
		lastClientArrived = Time.time;
		this.currentRound = currentRound;
		
		// Invite Returning Customers:
		arrivingClients.AddRange(returningClients);
		returningClients.Clear();
	}
	
	
	public Client CreateClient(){
		if (clientPrefab == null) throw new MissingReferenceException("You need to assign a Client Prefab");
		
		Debug.Log("Client Created");
		
		Client randomClient = Instantiate(clientPrefab) as Client;
			
		randomClient.Insanity = Random.value;
		
		return randomClient;
	}
	
	public void CreateNewClients(int amount){
		if (amount <=0) throw new System.ArgumentOutOfRangeException("amount can not be 0 or lower");
		for (int i = 0; i < amount; i++) {
			Client targetClient = CreateClient();
			arrivingClients.Add(targetClient);
		}
	}
	
	public void ScheduleNextAppointment(Client targetClient){
		returningClients.Add(targetClient);
	}
	
	public void SendNextClient(){
		// TODO: randomize the order of arrivals
		Client arrivingClient = arrivingClients[0];
		arrivingClients.Remove(arrivingClient);
		OnClientArrived(arrivingClient);
		if (arrivingClients.Count <= 0){
			this.enabled = false;
			OnLastClientArrived(arrivingClient);
		}
	}
	
	public void OnClientArrived(Client targetClient){
		if (ClientArrived != null){
			ClientArrived(targetClient);
		}
	}
	
	public void OnLastClientArrived(Client targetClient){
		if (LastClientArrived != null){
			LastClientArrived(targetClient);
		}
	}
	
}
