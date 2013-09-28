using UnityEngine;
using System.Collections;

public delegate void ClientEventHandler(Client targetClient);

public class Client : MonoBehaviour {
	
	public float Insanity{
		get { return m_insanity; }
		set {
			m_insanity = value;
			checkInsanity();
		}
	}
	
	public float maximumInsanity;
	public float minimumInsanity;
	
	
	private float m_insanity = 0.5f;
	public float lastTherapyInfluence = 0f;
	
	public void checkInsanity(){
		if (m_insanity > maximumInsanity){}//TODO: Exploding head
		if (m_insanity < minimumInsanity){}//TODO: Stop visiting the clinic
	}
		
}
