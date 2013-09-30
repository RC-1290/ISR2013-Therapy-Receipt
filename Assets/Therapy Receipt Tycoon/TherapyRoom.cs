using UnityEngine;
using System.Collections;

public class TherapyRoom : MonoBehaviour {
	
	public event ClientEventHandler TherapyCompleted;
	private Client lastClient;
	
	public float maximumSuccess = -.3f;
	public float minimumSuccess = .3f;
	
	public void ApplyTherapy(Client targetClient){
		this.lastClient = targetClient;
		float therapyInfluence = Random.value * (maximumSuccess - minimumSuccess) + minimumSuccess;
		targetClient.Insanity += therapyInfluence;
		
		Debug.Log("Applying Therapy. " + therapyInfluence);
		
		//TODO: apply animations and timed delay.
		OnTherapyCompleted();
	}
	
	protected void OnTherapyCompleted(){
		if (this.TherapyCompleted != null){
			TherapyCompleted(this.lastClient);
		}
	}
	
	protected void OnTriggerEnter(Collider collisionData){
		Client targetClient = collisionData.attachedRigidbody.GetComponent<Client>();
		//Client targetClient = collisionData.GetComponent<Client>();
		if (targetClient != null){
			
			// TODO: call this after a certain amount of time.
			ApplyTherapy(targetClient);
		}
		
	}
}
