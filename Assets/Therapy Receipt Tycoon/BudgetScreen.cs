using UnityEngine;
using System.Collections;

public class BudgetScreen : MonoBehaviour {
	
	
	public decimal m_fundsAtStartofRound = 0;
	public decimal funds = 1000;
	public decimal costs = 600;
	
	public bool GameOver{
		get { return funds < 0; }
	}
	
	protected void OnGUI(){
		GUILayout.TextArea("Current Funds: €" + funds);
		GUILayout.TextArea("Income: €" + (funds - m_fundsAtStartofRound));
		GUILayout.TextArea("Costs: €" + costs);
		
		GUILayout.TextArea("Total: €" + (funds - costs));
		
		if (GUILayout.Button("Close")){
			this.enabled = false;
		}
		
	}
	
	public void ApplyCosts(){
		funds -= costs;
	}
	
	public void ResetRoundFunds(){
		m_fundsAtStartofRound = funds;
	}
	
	
	
}
