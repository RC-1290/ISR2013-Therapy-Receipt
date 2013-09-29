using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HiddenWaitingRoom : MonoBehaviour {
	
	private Queue<Client> hiddenClients = new Queue<Client>();
	
	public bool isEmpty
	{
		get 
		{
			return (hiddenClients.Count == 0);
		}

	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public Client GetClient ()
	{
		return hiddenClients.Dequeue();
	}
	
	public void AddClient(Client newClient)
	{
		hiddenClients.Enqueue(newClient);
	}
	
}
