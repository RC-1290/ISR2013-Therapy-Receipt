using UnityEngine;
using System.Collections;

public delegate void ClientEventHandler(Client targetClient);

public enum ClientGoal{
	GetTherapy,
	PayForTherapy
}

public class Client : MonoBehaviour {
	public ClientGoal currentGoal;
	
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
	
	public void checkInsanity(){
		if (m_insanity > maximumInsanity){Debug.Log("Head Explodes");}//TODO: Exploding head
		if (m_insanity < minimumInsanity){Debug.Log("Client no longer needs clinic");}//TODO: Stop visiting the clinic
	}
		
}
