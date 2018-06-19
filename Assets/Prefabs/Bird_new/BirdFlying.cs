using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //to improve performance, but Collision detection is necessary for umbrella etc.
        /*
        if (transform.position.y > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed, Space.Self);
        }
        else
        {
            transform.Translate(Vector3.forward * 0, Space.Self);
            animator.SetTrigger("Die");
        }
        */

    }

    
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        //Vector3 pos = contact.point;
        //transform.Translate(pos);     

        moving = false;
        animator.enabled = false;

        this.GetComponent<Rigidbody>().useGravity = true;
        enabled = true;

        /*
        if (transform.position.y > carpetSurface)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            enabled = true;
        }
        
        var rigidBooty = GetComponent<Rigidbody>();
        rigidBooty.velocity = Vector3.zero;
        rigidBooty.angularVelocity = Vector3.zero;
        */

    }

    //replaced by setting carpet isKinematic=true
    /*
    private void OnCollisionStay(Collision collision)
    {
        moving = false;
        enabled = true;
        if (transform.position.y > carpetSurface)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }else if (transform.position.y < -0.5)
        {
            this.GetComponent<Rigidbody>().useGravity = true;

        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            transform.Translate(Vector3.forward * 0, Space.Self);

        }
    }

    */

}
