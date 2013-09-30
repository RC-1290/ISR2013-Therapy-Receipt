using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitingRoom : MonoBehaviour {
	
	public bool hasEmptySeats{
		get { return availableSeats > waitingRoom.Count; }
	}
	
	public event ClientEventHandler ClientEnteredWaitingRoom;
	
	public uint availableSeats = 6;
	
	private Queue<Client> waitingRoom = new Queue<Client>();
	private Client[] orderedClients = new Client[6];	
	public Transform[] SeatPosition = new Transform[6];

	
	public void SendClientToWaitingRoom(Client targetClient){
		this.waitingRoom.Enqueue(targetClient);
		for (int i = 0; i < availableSeats; i++)
		{
			if (orderedClients[i] == null)
			{
				//targetClient.transform.position = Entrance.position;
				//targetClient.GetComponent<NavMeshAgent>().destination = SeatPosition[i].position;
				orderedClients[i] = targetClient;
				break;
			}
		}
		Debug.Log(this.waitingRoom.Count + " people waiting in the waiting room");
		
		OnClientEnteredWaitingRoom(targetClient);
	}
	
	public Client TakeClient(){
		Client NextClient = this.waitingRoom.Dequeue();
		for (int i = 0; i < availableSeats; i++)
		{
			if 	(NextClient == orderedClients[i])
			{
				orderedClients[i] = null;
				break;
			}
		}
		return NextClient;
	}
	
	public void OnClientEnteredWaitingRoom(Client currentClient){
		if (this.ClientEnteredWaitingRoom != null){
			ClientEnteredWaitingRoom(currentClient);
		}
	}
	
}
