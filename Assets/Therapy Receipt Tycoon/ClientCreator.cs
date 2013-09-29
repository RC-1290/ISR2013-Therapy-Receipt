using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientCreator : MonoBehaviour {
	
	public int remainingArrivals{
		get { return arrivingClients.Count; }
	}
	
	public event ClientEventHandler ClientArrived;
	public event ClientEventHandler LastClientArrived;
	
	public Client clientPrefab;
	private List<Client> arrivingClients = new List<Client>();
	private List<Client> returningClients = new List<Client>();
	
	
//	public int clientsToCreateThisRound
	private float lastClientCreated;
	
	
	protected void Update(){
//		Time.time
	}
	
	
	protected void OnGUI(){
		
		
	}
	
	/// <summary>
	/// Should be called at the start of a round.
	/// </summary>
	public void HandleRoundStarted(){
		
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
	
	public void CreateNewClients(uint amount){
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
		if (arrivingClients.Count <= 0) OnLastClientArrived(arrivingClient);
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
