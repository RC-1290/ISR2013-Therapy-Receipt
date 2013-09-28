using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitingRoom : MonoBehaviour {
	
	public event ClientEventHandler ClientEnteredWaitingRoom;
	
	private Queue<Client> waitingRoom = new Queue<Client>();
	
	
	public void SendClientToWaitingRoom(Client currentClient){
		this.waitingRoom.Enqueue(currentClient);
		Debug.Log(this.waitingRoom.Count + " people waiting in the waiting room");
		
		OnClientEnteredWaitingRoom(currentClient);
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
