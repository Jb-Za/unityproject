using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 12.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float pushpower = 6.0f;
    private RaycastHit hit;
    //private Rigidbody rb;
    private Vector3 pushDir;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        
    }

    //every frame (200 times a second)
    void Update(){
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        

    }

    // 50 times a second (independant of frames.. this is used to update physics)
    void FixedUpdate()
    {    
        groundedPlayer = isGrounded();
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
           
        Rigidbody rb = hit.collider.attachedRigidbody;
        if(rb != null && rb.isKinematic == false){

            Vector3 pushDir = new Vector3(hit.moveDirection.x , 0, hit.moveDirection.z);
            rb.velocity = pushDir * pushpower;
        }
              
    }

    bool isGrounded(){
         if(Physics.Raycast(transform.position,-transform.up,out hit,1.0002f)){ //no transform.position.down.. so - 
                if(hit.collider){                                               // 1.0002f because raycast pushes the player and i'm too lazy to worry about layermasks so.. 
                    return true;                                                // shoot out a really small value past the player model
                }
                else{return false;}
        }
        else{
            return false;
        }
    }
    
}
