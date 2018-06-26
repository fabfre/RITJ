using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hitBird : Photon.MonoBehaviour {

	public ScoreValues scoreValues;
	public Text scoreText;
	public int Bird;
	public TextMesh text3D;

	void Start(){
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("HitBird"))
		{
			PhotonView photonView = PhotonView.Get (this);

			photonView.RPC("SetCounterText", PhotonTargets.All, other.gameObject.GetPhotonView().viewID);
		}
	}

    [PunRPC]
    public void SetCounterText(int other)
    {
        PhotonNetwork.Destroy(PhotonView.Find(other));

        scoreValues.score = scoreValues.score - Bird;
		text3D.text = "Score: " + scoreValues.score.ToString();
    }
}