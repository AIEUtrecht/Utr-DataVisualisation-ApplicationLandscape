using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	private GameObject collidingObject;
	private GameObject objectInHand;
	private SteamVR_Controller.Device Controller {
		get {
			return SteamVR_Controller.Input((int)trackedObject.index);
		}
	}

	void Awake() {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

	private void SetCollidingObject(Collider col) {
		if (!collidingObject && col.GetComponent<Rigidbody>()) {
			Debug.Log("test");
			collidingObject = col.gameObject;
		}
	}

	public void OnTriggerEnter(Collider other) {
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other) {
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other) {
		collidingObject = null;
	}

	private void GrabObject()
	{
		objectInHand = collidingObject;
		collidingObject = null;
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}

	private FixedJoint AddFixedJoint() {
		FixedJoint f = gameObject.AddComponent<FixedJoint>();
		f.breakForce = 20000;
		f.breakTorque = 20000;
		return f;
	}

	private void ReleaseObject() {
		FixedJoint fixedJoint = GetComponent<FixedJoint>();
		if (fixedJoint) {
			fixedJoint.connectedBody = null;
			Destroy(fixedJoint);
			Rigidbody rigidbody = objectInHand.GetComponent<Rigidbody>();
			rigidbody.velocity = Controller.velocity;
			rigidbody.angularVelocity = Controller.angularVelocity;
		}
		objectInHand = null;
	}

	void Start () {
		
	}

	void Update () {
		if (Controller.GetHairTriggerDown()) {
			if (collidingObject) {
				GrabObject();
			}
		}
		if (Controller.GetHairTriggerUp()) {
			if (objectInHand) {
				ReleaseObject();
			}
		}
	}
}
