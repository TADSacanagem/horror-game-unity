using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    [SerializeField]private Light flashLight;
    [SerializeField]private AudioClip flashClick;

    private Vector3 entradaJogador;
    private CharacterController characterController;
    public float Speed = 4f;
    private Transform myCamera;

    private bool estaNoChao;
    [SerializeField]private Transform verificadorChao;
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

        estaNoChao = Physics.CheckSphere(verificadorChao.position, 1f, cenarioMask);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(entradaJogador * Time.deltaTime * Speed * 2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocidadeVertical = Mathf.Sqrt(alturaPulo *  -30f * gravidade);
        }

        if (estaNoChao && velocidadeVertical < 0)
        {
            velocidadeVertical = -1f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.enabled = !flashLight.enabled;
            GetComponent<AudioSource>().PlayOneShot(flashClick, 1f);
        }

        velocidadeVertical += gravidade + Time.deltaTime;

        characterController.Move(new Vector3(0, velocidadeVertical, 0) * Time.deltaTime);


    }
}
