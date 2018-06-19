using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	public float power;
	public Transform firepoint;
	private SteamVR_TrackedController trackedController;

	//public Valve.VR.EVRButtonId shootButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (SteamVR_Controller. .GetPressDown(shootButton)) {
			GameObject proj = (GameObject)Instantiate (projectile, firepoint.position, firepoint.rotation);
			proj.GetComponent<Rigidbody> ().velocity = firepoint.forward * power;
		//}
	}
}
