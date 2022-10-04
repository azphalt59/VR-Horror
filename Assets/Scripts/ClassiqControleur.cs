using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ClassiqControleur : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float mouseSensi;
    public float downlimit;
    public float uplimit;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Rotate();

    }

    void Move()
    {
        float horizontalM = Input.GetAxis("Horizontal");
        float verticalM = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalM + transform.right * horizontalM;
        characterController.Move(speed * Time.deltaTime * move);
    }

    void Rotate()
    {
        float hRot = Input.GetAxis("Mouse X");
        float vRot = Input.GetAxis("Mouse Y");

        transform.Rotate(0, hRot * mouseSensi, 0);
        transform.Rotate(-vRot * mouseSensi, 0, 0);

        Vector3 currentRotation = transform.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, uplimit, downlimit);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

}
