using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitingRoom : MonoBehaviour {
	
	public bool hasEmptySeats{
		get { return availableSeats > waitingRoom.Count; }
	}
	
	public event ClientEventHandler ClientEnteredWaitingRoom;
	
	private Queue<Client> waitingRoom = new Queue<Client>();
	
	public uint availableSeats = 6;
	
	
	public void SendClientToWaitingRoom(Client targetClient){
		this.waitingRoom.Enqueue(targetClient);
		Debug.Log(this.waitingRoom.Count + " people waiting in the waiting room");
		
		OnClientEnteredWaitingRoom(targetClient);
	}
	
	public Client TakeClient(){
		return this.waitingRoom.Dequeue();
	}
	
	public void OnClientEnteredWaitingRoom(Client currentClient){
		if (this.ClientEnteredWaitingRoom != null){
			ClientEnteredWaitingRoom(currentClient);
		}
	}
	
}
