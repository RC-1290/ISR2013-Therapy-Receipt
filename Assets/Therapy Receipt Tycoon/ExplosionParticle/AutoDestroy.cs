using UnityEngine;
using System.Collections;



public class AutoDestroy : MonoBehaviour {
	
	private ParticleSystem ps;
	
	// Use this for initialization
	void Start () {
		ps = this.particleSystem;
		Destroy(this.gameObject, ps.duration + ps.startLifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
