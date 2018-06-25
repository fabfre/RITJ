using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : Photon.PunBehaviour, IPunObservable {

    [SerializeField]
    private bool selfTouch, partnerTouch;

    // Use this for initialization
    void Start () {
		PhotonNetwork.automaticallySyncScene = true;
		selfTouch = false;
		partnerTouch = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

		PhotonView view = other.GetComponentInParent<PhotonView> ();
		Debug.Log (view);
		//PhotonNetwork.LoadLevel("DesertScene"); // Wieder entfernen

		if (PhotonNetwork.isMasterClient && view != null) {
			if (view.isMine) {
				this.selfTouch = true;
			} else {
				this.partnerTouch = true;
			}
		}
    }

    private void OnTriggerExit(Collider other)
    {
		PhotonView view = other.GetComponentInParent<PhotonView> ();
		if (PhotonNetwork.isMasterClient && view != null) {
			if (view.isMine) {
				this.selfTouch = false;
			} else {
				this.partnerTouch = false;
			}
		}
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
		if (stream.isWriting) {
			stream.SendNext (selfTouch);
			stream.SendNext (partnerTouch);
		} else {
			selfTouch = (bool)stream.ReceiveNext ();
			partnerTouch = (bool)stream.ReceiveNext ();
		}

        if (selfTouch == true && partnerTouch == true && PhotonNetwork.isMasterClient)
		{
			Debug.Log ("Lade nächste Szene");
			PhotonNetwork.LoadLevel("DesertScene");
		}
    }
}
