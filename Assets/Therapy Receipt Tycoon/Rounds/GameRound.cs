using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameRound : ScriptableObject {

	public int clientsPerRound = 8;
	
	public float regularPrice = 200;
	public float higherPrice = 300;
	public float lowerPrice = 150;
	public float businessCosts = 600;
	
	public float highPriceInsanityAdjustment = 0.1f;
	public float lowPriceInsanityAdjustment = -0.1f;
	
	
}
