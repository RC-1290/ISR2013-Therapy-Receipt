using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientCreator : MonoBehaviour {
	
	public Client clientPrefab;
	private List<Client> arrivingClients;
	private List<Client> returningClients;
	
	
//	public int clientsToCreateThisRound
	private float lastClientCreated;
	
	
	protected void Update(){
//		Time.time
	}
	
	
	protected void OnGUI(){
		
		
	}
	
	/// <summary>
	/// Sets up returning customers to visit.
	/// Should be called at the start of a round.
	/// </summary>
	public void InviteReturningClients(){
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
	
	public void ScheduleNextAppointment(Client targetClient){
		returningClients.Add(targetClient);
	}
	
}
