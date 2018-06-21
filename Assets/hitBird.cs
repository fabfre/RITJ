using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hitBird : Photon.MonoBehaviour {

	public ScoreValues scoreValues;
	public Text scoreText;
	public int Bird;


	void Start(){
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("HitBird"))
		{
            PhotonView photonView = this.photonView;

            photonView.RPC("SetCounterText", PhotonTargets.AllBuffered, other.gameObject.GetPhotonView().viewID);
		}
	}

    [PunRPC]
    public void SetCounterText(int other)
    {
        PhotonNetwork.Destroy(PhotonView.Find(other));

        scoreValues.score = scoreValues.score - Bird;
        scoreText.text = "Score: " + scoreValues.score.ToString();
    }
}