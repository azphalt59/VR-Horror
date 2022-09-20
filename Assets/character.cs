using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 1f;
    public float addRotation = 30f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rot
        if(Input.GetKeyUp("joystick button 4"))
        {
            RotateCharacter(-1);
        }
        if (Input.GetKeyUp("joystick button 5"))
        {
            RotateCharacter(1);
        }
        
        //Input mvt
        float moveLeftAndRight = Input.GetAxisRaw("Horizontal");
        float moveForwardAndBackward = Input.GetAxisRaw("Vertical");

        //mvt
        Vector3 moveDirection = new Vector3(moveLeftAndRight, 0f, moveForwardAndBackward);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection*speed*Time.deltaTime);
    }

    public void RotateCharacter(float multiply)
    {
        transform.Rotate(0, multiply * addRotation, 0);   
    }
}
