using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    private Vector3 entradaJogador;
    private CharacterController characterController;
    public float Speed = 4f;
    private Transform myCamera;

    private bool estaNoChao;
    [SerializeField]private Transform verificarChao;
    [SerializeField]private LayerMask cenarioMask;

    [SerializeField]private float alturaPulo = 1f;
    [SerializeField]private float gravidade = -1f;
    private float velocidadeVertical;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);

        entradaJogador = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        entradaJogador = transform.TransformDirection(entradaJogador);

        characterController.Move(entradaJogador * Time.deltaTime * Speed);

        estaNoChao = Physics.CheckSphere(verificarChao.position, 1f, cenarioMask);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocidadeVertical = Mathf.Sqrt(alturaPulo *  -30f * gravidade);
        }

        if (estaNoChao && velocidadeVertical < 0)
        {
            velocidadeVertical = -1f;
        }

        velocidadeVertical += gravidade + Time.deltaTime;

        characterController.Move(new Vector3(0, velocidadeVertical, 0) * Time.deltaTime);


    }
}
