using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameRound : ScriptableObject {

	public int clientsPerRound = 8;
	
	public decimal regularPrice = 200;
	public decimal higherPrice = 300;
	public decimal lowerPrice = 150;
	public decimal businessCosts = 600;
	
	public float highPriceInsanityAdjustment = 0.1f;
	public float lowPriceInsanityAdjustment = -0.1f;
	
	
}
