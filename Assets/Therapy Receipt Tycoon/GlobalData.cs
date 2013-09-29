using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour {
	
	public static float MinSpawnDelay = 4f;
	public static float MaxSpawnDelay = 12f;
	public static int MaxClientsPerRound = 10;
	
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
