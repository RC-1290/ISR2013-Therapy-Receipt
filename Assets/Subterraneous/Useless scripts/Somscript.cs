using UnityEngine;
using System.Collections;

public class Somscript : MonoBehaviour {

	public Vector3 velocity = new Vector3(0,0,0);
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKey(KeyCode.A)){
		
		transform.Translate(this.velocity * Input.GetAxis("Horizontal"));
//		}
	}
}
