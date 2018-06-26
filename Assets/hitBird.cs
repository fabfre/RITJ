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
			scoreValues.score = scoreValues.score - Bird;
		}

		if (other.gameObject.CompareTag ("Coconut"))
		{
			scoreValues.score = scoreValues.score - Bird;
		}

		if (other.gameObject.CompareTag ("Kroko"))
		{
			scoreValues.score = scoreValues.score - Bird;
		}
	}
}