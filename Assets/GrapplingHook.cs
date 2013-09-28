using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GrapplingHook : MonoBehaviour {
	
	public LayerMask hookableObjectsLayer;
	
	public float hitRange = 200;
	private float linkLength = 10;
	
	private bool anchored = false;
	private SpringJoint hook;
		
	
	// Update is called once per frame
	void Update () {
		if (anchored){
			if (Input.GetKey(KeyCode.Mouse1)) FireHook();
		}
		else{
			if (Input.GetKey(KeyCode.Mouse2)) Detach();
		}
	}
	
	public void FireHook(){
		RaycastHit hitData;
		bool hit = FireRayThroughMouse(out hitData);
		
		if (hit){
			AnchorTo(hitData.point);			
		}
	}
	
	public void AnchorTo(Vector3 location){
		if (anchored) throw new System.InvalidOperationException("Trying to anchor while already anchored");
		this.hook = gameObject.AddComponent<SpringJoint>();
		
		hook.anchor = location;
		anchored = true;
		
		hook.maxDistance = this.linkLength;
	}
	
	public void Detach(){
		anchored = false;
		Destroy(this.hook);
	}
	
	
	
	private bool FireRayThroughMouse(out RaycastHit hitData){
		Ray targetRay = camera.ScreenPointToRay( Input.mousePosition );
		return Physics.Raycast(targetRay, out hitData, this.hitRange, this.hookableObjectsLayer);
	}	
	
}
