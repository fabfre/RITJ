using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletController : Photon.MonoBehaviour {

	public ScoreValues scoreValues;
    public int zeppelinAimScore;
	public int luftballonAimScore;

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
            //SetCounterText(other.gameObject.GetPhotonView().viewID);
            scoreValues.score = scoreValues.score + luftballonAimScore;
            Destroy(this.gameObject);
            PhotonNetwork.Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("ZeppelinAim"))
        {
            //SetCounterText(other.gameObject.GetPhotonView().viewID);
            scoreValues.score = scoreValues.score + zeppelinAimScore;
            Destroy(this.gameObject);
            PhotonNetwork.Destroy(other.gameObject);
        }

		if (other.gameObject.CompareTag("Krokodil"))
		{
			//SetCounterText(other.gameObject.GetPhotonView().viewID);
            scoreValues.score = scoreValues.score + KrokodilAimScore;
            Destroy(this.gameObject);
            PhotonNetwork.Destroy(other.gameObject);
		}
    }

  //  public void SetCounterText(int other)
  //  {
  //      if (PhotonView.Find(other).gameObject.CompareTag("ZeppelinAim"))
  //      {
  //          scoreValues.score = scoreValues.score + zeppelinAimScore;
  //      }
  //      if (PhotonView.Find(other).gameObject.CompareTag("LuftballonAim"))
  //      {
  //          scoreValues.score = scoreValues.score + luftballonAimScore;
  //      }
		//if (PhotonView.Find(other).gameObject.CompareTag("Krokodil"))
		//{
		//	scoreValues.score = scoreValues.score + KrokodilAimScore;
		//}

		////PhotonNetwork.RaiseEvent(0, text3D.text, true, null);
    //}
}