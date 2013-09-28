using UnityEngine;
using System.Collections;

public class ScrollControl : MonoBehaviour {
	
	public string scrollWheelInputName = "Mouse ScrollWheel";
	public float unitsPerScrollTick = 20;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,0,Input.GetAxisRaw(this.scrollWheelInputName) * this.unitsPerScrollTick));
	}
}
