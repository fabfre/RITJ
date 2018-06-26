using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreValues : Photon.MonoBehaviour, IPunObservable {

	public int score;
	public TextMesh text3D;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		text3D.text = score.ToString ();
	}

	void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (score);
		} else {
			score = (int)stream.ReceiveNext ();
		}
	}

}
