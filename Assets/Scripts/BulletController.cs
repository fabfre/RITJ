using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	//public ScoreValues scoreValues;
	//public Text scoreText;
    public int zeppelinAimScore;
	public int luftballonAimScore;


	void Start(){
        
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("LuftballonAim"))
		{
			//setCounterText (other.gameObject);
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}

        if (other.gameObject.CompareTag("ZeppelinAim"))
        {
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

	//void setCounterText (GameObject other){

	//	if (other.CompareTag ("ZeppelinAim"))
	//	{
	//		scoreValues.score = scoreValues.score + zeppelinAimScore;
	//	}
	//	if (other.CompareTag ("LuftballonAim"))
	//	{
	//		scoreValues.score = scoreValues.score + luftballonAimScore;
	//	}
	//	scoreText.text = "Score: " + scoreValues.score.ToString ();
	//}
}