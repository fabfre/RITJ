using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoContainer : Photon.PunBehaviour, IPunObservable {

	public int ammo;
	public TextMesh ammoText3D;

	private int syncAmmo;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
			stream.SendNext(syncAmmo);
        }
        else
        {
			syncAmmo = (int)stream.ReceiveNext();
        }
    }

    // Use this for initialization
    void Start () {
		ammoText3D.text = "Ammo: " + ammo.ToString ();
	}

	// Update is called once per frame
	void Update () {
		if (!photonView.isMine) {
			ammo = syncAmmo;
		}
		if (photonView.isMine) {
			syncAmmo = ammo;
		}

        ammoText3D.text = "Ammo: " + ammo.ToString();
	}
}
