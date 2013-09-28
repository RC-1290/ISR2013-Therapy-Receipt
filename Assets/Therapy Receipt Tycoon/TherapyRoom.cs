using UnityEngine;
using System.Collections;

public class TherapyRoom : MonoBehaviour {
	
	public event ClientEventHandler TherapyCompleted;
	private Client lastClient;
	
	public float maximumSuccess = -1f;
	public float minimumSuccess = 1f;
	
	public void ApplyTherapy(Client targetClient){
		this.lastClient = targetClient;
		float therapyInfluence = Random.value * (maximumSuccess - minimumSuccess) + minimumSuccess;
		targetClient.insanity += therapyInfluence;
		targetClient.lastTherapyInfluence = therapyInfluence;
		
		Debug.Log("Applying Therapy");
		
		//TODO: apply animations and timed delay.
		OnTherapyCompleted();
	}
	
	protected void OnTherapyCompleted(){
		if (this.TherapyCompleted != null){
			TherapyCompleted(this.lastClient);
		}
	}
}
