using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("transition", 1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {              
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("transition", 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("transition", 3);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("transition", 4);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("transition", 5);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("transition", 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("transition", 6);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("transition", 0);
        }





    }
}