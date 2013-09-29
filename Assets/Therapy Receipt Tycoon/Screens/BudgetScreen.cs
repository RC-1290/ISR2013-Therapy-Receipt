using UnityEngine;
using System.Collections;

public class BudgetScreen : MonoBehaviour {
	
	public GameLoop gameManager;
	
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
	
	public Rect screenArea = new Rect(200,200,100,100);
	
	public bool IsGameOver{
		get { return availableFunds < 0; }
	}
	
	protected void OnGUI(){
		GUILayout.BeginArea(this.screenArea);
		GUILayout.TextArea("Current Funds: €" + availableFunds);
		GUILayout.TextArea("Income: €" + (availableFunds - m_fundsAtStartofRound));
		GUILayout.TextArea("Costs: €" + currentCost);
		
		GUILayout.TextArea("Total: €" + (availableFunds - currentCost));
		
		if (GUILayout.Button("Close")){
			this.enabled = false;
			if (this.IsGameOver) gameManager.ShowGameOverScreen();
			else gameManager.NextLevel();
		}
		GUILayout.EndArea();
		
	}
	
	public void ShowScreen(){
		this.enabled = true;
	}
	
	public void applyCosts(){
		availableFunds -= currentCost;
	}
	
	public void ResetRoundFunds(){
		m_fundsAtStartofRound = availableFunds;
	}
	
	
	
}
