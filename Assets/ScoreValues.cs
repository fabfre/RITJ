using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreValues : Photon.PunBehaviour, IPunObservable {

	public int score;
	public TextMesh text3D;

	private int syncScore;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!photonView.isMine) {
			score = syncScore;
		}
		if (photonView.isMine) {
			syncScore = score;
		}

		text3D.text = "Score: " + score.ToString ();
	}

	void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (syncScore);
		} else {
			syncScore = (int)stream.ReceiveNext ();
		}
	}

}
