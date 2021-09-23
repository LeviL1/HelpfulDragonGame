using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 20.0f;

    private Vector3 moverDirection = Vector3.zero;
    private CharacterController _cc;
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moverDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moverDirection = transform.TransformDirection(moverDirection);
        moverDirection *= speed;
    }
    controller.Move(moverDirection* Time.deltaTime);
}
