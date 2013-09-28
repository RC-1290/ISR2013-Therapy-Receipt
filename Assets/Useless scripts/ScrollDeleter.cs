using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollDeleter : MonoBehaviour {
	
	public string scrollWheelInputName = "Mouse ScrollWheel";
	public LayerMask collectableObjectLayers;
	public float hitRange = 2000;
	
	private Stack<GameObject> capturedObjects = new Stack<GameObject>();
	
	// Update is called once per frame
	void Update () {
		float scrollDirection = Input.GetAxisRaw(scrollWheelInputName);
		if (scrollDirection > 0.1){
			CaptureUnderMouse();
		}
		else if (scrollDirection < -0.1){
				
		}
	}
	
	
	private void CaptureUnderMouse(){
		RaycastHit hitData;
		bool hit = FireRayThroughMouse(out hitData);
		
		if (hit){
		
			GameObject targetObject = hitData.collider.gameObject;
			Transform targetTransform = targetObject.transform;
			
			targetTransform.parent = this.transform;
			targetTransform.rigidbody.isKinematic = false;
			targetTransform.Translate( - targetTransform.position);
		}
		
	}
	
	private void PlaceUnderMouse(){
		if (capturedObjects.Count < 1) return;
		
		RaycastHit hitData;
		bool hit = FireRayThroughMouse(out hitData);
		
		if (hit){
			GameObject latestObject = capturedObjects.Pop();
			latestObject.transform.parent = null;
			latestObject.rigidbody.isKinematic = true;
			latestObject.transform.Translate(hitData.point);
		}
	}
	
	
	private bool FireRayThroughMouse(out RaycastHit hitData){
		Ray targetRay = camera.ScreenPointToRay( Input.mousePosition );
		return Physics.Raycast(targetRay, out hitData, this.hitRange, collectableObjectLayers);
	}	
	
	
}
