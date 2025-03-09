using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Flightspeed;
    public float MaxFlightSpeed;
    public float YawAmount;

    private float Yaw;

    public Rigidbody Rigi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input flight speed

        /*if (Input.GetMouseButton(0))
        {
            transform.position += transform.forward * Flightspeed * Time.deltaTime;

        }*/

        if (Input.GetMouseButton(0))
        { Rigi.AddRelativeForce(Vector3.forward * Flightspeed * Time.deltaTime, ForceMode.Acceleration);
            Rigi.linearVelocity = Vector3.ClampMagnitude(Rigi.linearVelocity,MaxFlightSpeed);
        }

            // input arrow controls

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Yaw 

        Yaw += horizontalInput * YawAmount * Time.deltaTime;

        //Pitch 
        float pitch = Mathf.Lerp(0,20,Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);

        //Roll
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        //apply rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right*pitch + Vector3.forward* roll);
       

    }

}
