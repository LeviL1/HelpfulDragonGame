using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f; //speed of the player
    public float flightSpeed = 2.0f; //speed player can ascend and descend 
    public float gravity = 20.0f; //gravity 
  public Image pauseMenu;
    private Vector3 moverDirection = Vector3.zero; //direction to move the player
    private CharacterController _cc; // reference to character controller component on player
    
    void Start()
    {//get the character controller from the player
        _cc = GetComponent<CharacterController>();
        pauseMenu.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { //move the player in fixed update
        
            moverDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moverDirection = transform.TransformDirection(moverDirection);
            moverDirection *= speed;



    if (Input.GetKey(KeyCode.Tab)) 
    {
      Cursor.lockState = CursorLockMode.Confined;
      Cursor.visible = true;
      pauseMenu.gameObject.SetActive(true);
    }


        if (Input.GetKey(KeyCode.Space))
        {
            moverDirection = transform.TransformDirection(new Vector3(0f, -2f, 0f));
            moverDirection *= flightSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moverDirection = transform.TransformDirection(new Vector3(0f, 2f, 0f));
            moverDirection *= flightSpeed;
        }

        _cc.Move(moverDirection * Time.deltaTime);
    }


}
