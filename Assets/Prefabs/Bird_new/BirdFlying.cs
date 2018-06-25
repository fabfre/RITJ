using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BirdFlying : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private bool moving = true;

    [SerializeField]
    private float carpetSurface;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
	{
        if (moving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed, Space.Self);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];   

        moving = false;
        animator.enabled = false;

        this.GetComponent<Rigidbody>().useGravity = true;
		this.GetComponent<VRTK_InteractableObject> ().enabled = true;
		this.GetComponent<VRTK_InteractableObject> ().isGrabbable = true;

        enabled = true;
    }

 
}
