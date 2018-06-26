using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Coconut : MonoBehaviour
{
    [SerializeField]
    private AudioClip _waterSplashSound;

    [SerializeField]
    private AudioClip _woodHitSound;

    private bool _inWater = false;

    private void Start()
    {
        this.GetComponent<VRTK_InteractableObject>().enabled = true;
        this.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
        GetComponent<AudioSource>().clip = _woodHitSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Raft")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Water" && !_inWater)
        {
            _inWater = true;
            GetComponent<AudioSource>().clip = _waterSplashSound;
            GetComponent<AudioSource>().Play();
        }
    }
}
