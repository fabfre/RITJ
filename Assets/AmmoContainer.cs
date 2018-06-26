using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoContainer : Photon.PunBehaviour, IPunObservable {

	public int ammo;
	public TextMesh ammoText3D;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(ammo);
        }
        else
        {
            ammo = (int)stream.ReceiveNext();
        }
    }

    // Use this for initialization
    void Start () {
		ammo = 5;
		ammoText3D.text = "Ammo: " + ammo.ToString ();
	}

	// Update is called once per frame
	void Update () {
        ammoText3D.text = "Ammo: " + ammo.ToString();
	}
}
