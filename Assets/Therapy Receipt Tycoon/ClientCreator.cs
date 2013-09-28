using UnityEngine;
using System.Collections;

public class ClientCreator : MonoBehaviour {
	
	public Client clientPrefab;
	
	protected void OnGUI(){
		
		
	}
	
	
	public Client CreateClient(){
		if (clientPrefab == null) throw new MissingReferenceException("You need to assign a Client Prefab");
		
		Debug.Log("Client Created");
		
		Client randomClient = Instantiate(clientPrefab) as Client;
		randomClient.insanity = Random.value;
		
		
		return randomClient;
	}
	
}
