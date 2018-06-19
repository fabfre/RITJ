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
            photonView.RPC("SetCounterText", PhotonTargets.AllBuffered);
			Destroy (other.gameObject);
		}
	}

    [PunRPC]
	public void SetCounterText (){
        
		scoreValues.score = scoreValues.score - Bird;
		scoreText.text = "Score: " + scoreValues.score.ToString ();
	}

    //[PunRPC]
    //public void UpdateScore()
    //{
    //    setCounterText();
    //}
}