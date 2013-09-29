using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour {
	
	public static float MinSpawnDelay = 4f;
	public static float MaxSpawnDelay = 12f;
	public static int MaxClientsPerRound = 10;
	
	public static decimal AveragePrice = 200;
	public static decimal HigherPrice = 300;
	public static decimal LowerPrice = 150;
	public static decimal Cost = MaxClientsPerRound*LowerPrice;
	public static decimal CostIncrease = 100;
	public static int round = 0;
	
	
	//Statistics
	public static int passedClients = 0;
	public static int healedClients = 0;
	public static int deadClients = 0;
	public static decimal totalIncome = 0;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
