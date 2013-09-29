using UnityEngine;
using System.Collections;

public class BudgetScreen : MonoBehaviour {
	
	/// <summary>
	/// The amount of funds that were available at the start of the round, used for stat tracking.
	/// </summary>
	public float m_fundsAtStartofRound = 1000;
	/// <summary>
	/// Currently availableFunds
	/// </summary>
	public float availableFunds = 1000;
	/// <summary>
	/// The cost of running a therapy business. Should be set from round settings.
	/// </summary>
	public float currentCost;
	
	public bool IsGameOver{
		get { return availableFunds < 0; }
	}
	
	protected void OnGUI(){
		GUILayout.TextArea("Current Funds: €" + availableFunds);
		GUILayout.TextArea("Income: €" + (availableFunds - m_fundsAtStartofRound));
		GUILayout.TextArea("Costs: €" + currentCost);
		
		GUILayout.TextArea("Total: €" + (availableFunds - currentCost));
		
		if (GUILayout.Button("Close")){
			this.enabled = false;
		}
		
	}
	
	public void applyCosts(){
		availableFunds -= currentCost;
	}
	
	public void ResetRoundFunds(){
		m_fundsAtStartofRound = availableFunds;
	}
	
	
	
}
