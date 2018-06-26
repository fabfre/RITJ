using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaveblower : Photon.MonoBehaviour {
	
	public GameObject projectile;
	public float power;
	public Transform firepoint;
	public AmmoContainer ammocontainer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot()
	{
        photonView.RPC("NetworkShoot", PhotonTargets.All);
	}

	public void Load() {
		photonView.RPC ("NetworkLoad", PhotonTargets.All);
	}

    [PunRPC]
    void NetworkShoot()
    {
		if (ammocontainer.ammo > 0) {
			GameObject proj = (GameObject)Instantiate (projectile, firepoint.position, firepoint.rotation);
			proj.GetComponent<Rigidbody> ().velocity = firepoint.forward * power;
			ammocontainer.ammo = ammocontainer.ammo - 1;
		}
    }

	[PunRPC]
	void NetworkLoad()
	{
		ammocontainer.ammo++;
	}
}
