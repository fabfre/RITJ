using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoconutController : Photon.MonoBehaviour {

	public ScoreValues scoreValues;
	public Text scoreText;
	public int zeppelinAimScore;
	public int luftballonAimScore;
	public int MonkeyAimScore;
	public int KrokodilAimScore;
	public TextMesh text3D;

	void Start()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("LuftballonAim"))
		{
			PhotonView photonView = this.photonView;
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

		if (other.gameObject.CompareTag("ZeppelinAim"))
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

		if (other.gameObject.CompareTag("Kroko"))
		{
            scoreValues.score = scoreValues.score + KrokodilAimScore;
			other.GetComponent<Schnappi>().Flee ();
			//Destroy(this.gameObject);
		}
		if (other.gameObject.CompareTag("Monkey"))
		{
            scoreValues.score = scoreValues.score + MonkeyAimScore;
            other.GetComponent<Monkey>().Flee();
			//Destroy(this.gameObject);
		}
	}
}