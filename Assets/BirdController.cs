using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : Photon.MonoBehaviour {

	private TextMesh ammoText3D;
	private ScoreValues ammoV;

	void Start(){

		GameObject d = GameObject.Find ("Texts/AmmoText3D");
		ammoText3D = d.GetComponent<TextMesh>();
	}

	public void loadAmmo(){
		Leaveblower lf = GameObject.Find ("Leaveblower").GetComponent ("Leaveblower") as Leaveblower;
		Vector3 lbpos = GameObject.Find ("Leaveblower").transform.position;
		float dis = Vector3.Magnitude (lbpos - transform.position);

		if (dis < 2){
			lf.Load ();
            //PhotonNetwork.RaiseEvent(0, this.gameObject.GetPhotonView().viewID, true, null);
			PhotonNetwork.Destroy (this.gameObject);
		}
	}

    //private void OnEnable()
    //{
    //    PhotonNetwork.OnEventCall += this.OnEvent;
    //}

    //private void OnDisable()
    //{
    //    PhotonNetwork.OnEventCall -= this.OnEvent;
    //}

    //void OnEvent(byte eventcode, object content, int senderid)
    //{
    //    Debug.Log("OnEvent CODE = 1: " + content);

    //    if (eventcode == 0)
    //    {
    //        if (PhotonNetwork.isMasterClient) {
    //            PhotonNetwork.Destroy(this.gameObject);
    //        }

    //    }
    //}

}
