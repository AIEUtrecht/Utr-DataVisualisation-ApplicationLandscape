﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {
    private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device Controller {
		get {
			return SteamVR_Controller.Input((int)trackedObject.index);
		}
	}

	void Awake() {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}

	void Start () {
		
	}
	
	void Update () {
		if (Controller.GetAxis() != Vector2.zero) {
			Debug.Log(gameObject.name + Controller.GetAxis());
		}
		if (Controller.GetHairTriggerDown()) {
			Debug.Log(gameObject.name + " Trigger Press");
		}
		if (Controller.GetHairTriggerUp()) {
			Debug.Log(gameObject.name + " Trigger Release");
		}
		if(Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log(gameObject.name + " Grip Press");
		}
		if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log(gameObject.name + " Grip Release");
		}
	}
}