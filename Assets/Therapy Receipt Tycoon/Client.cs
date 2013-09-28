using UnityEngine;
using System.Collections;

public delegate void ClientEventHandler(Client targetClient);

public class Client : MonoBehaviour {
	
	public float insanity = 0.5f;
	public float lastTherapyInfluence = 0f;
	
	
}
