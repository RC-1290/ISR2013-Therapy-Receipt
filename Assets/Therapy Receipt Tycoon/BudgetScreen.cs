using UnityEngine;
using System.Collections;

public class BudgetScreen : MonoBehaviour {
	
	
	public decimal m_fundsAtStartofRound = 1000;
	public decimal funds = 1000;
	public decimal currentCost = GlobalData.Cost + GlobalData.CostIncrease*GlobalData.round;
	
	public bool GameOver{
		get { return funds < 0; }
	}
	
	protected void OnGUI(){
		GUILayout.TextArea("Current Funds: €" + funds);
		GUILayout.TextArea("Income: €" + (funds - m_fundsAtStartofRound));
		GUILayout.TextArea("Costs: €" + currentCost);
		
		GUILayout.TextArea("Total: €" + (funds - currentCost));
		
		if (GUILayout.Button("Close")){
			this.enabled = false;
		}
		
	}
	
	public void applyCosts(){
		funds -= currentCost;
	}
	
	public void ResetRoundFunds(){
		m_fundsAtStartofRound = funds;
	}
	
	
	
}
