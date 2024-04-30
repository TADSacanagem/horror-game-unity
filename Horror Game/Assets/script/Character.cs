using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{

    private CharacterController characterController;

    public float Speed = 5f;

    public float JumpSpeed = 5f;

    public float gravity;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime * Speed);

        //tentando colocar gravidade
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection);

        if (characterController.isGrounded)
        {
            print("CharacterController is grounded");
        }
        

    }
}
