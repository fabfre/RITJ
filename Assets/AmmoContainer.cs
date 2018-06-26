using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoContainer : MonoBehaviour {

	public int ammo;
	public TextMesh ammoText3D;

	// Use this for initialization
	void Start () {
		ammo = 30;
		ammoText3D.text = "Ammo: " + ammo.ToString ();
	}

	// Update is called once per frame
	void Update () {

	}
}
