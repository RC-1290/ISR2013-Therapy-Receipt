using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour {

	public Somscript victim;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			victim.velocity = new Vector3(0,10,0);
		}
	}
	
}
