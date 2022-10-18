using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAlignment : MonoBehaviour
{
    public GameObject pickup;
    private PickUp Player;
    private RaycastHit hit;
    private GameObject goalPad;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Player = pickup.GetComponent<PickUp>(); // accessing Player.isHolding by creating the object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame (200)
    
    // 50 times a second, independant from frames.
    void FixedUpdate()
    {
        
        if (transform.parent != null  && transform.parent.name == "Destination"){
            //casting a ray down to check if the goalpad is directly below the box
            if(Physics.Raycast(transform.position,-transform.up,out hit,1)){ //no transform.position.down.. so - 
                if(hit.collider.gameObject.tag=="goalPad"){
                    transform.parent=null;
                    rb.useGravity = true;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    goalPad=hit.collider.gameObject; 
                    transform.position = goalPad.transform.position;
                    transform.position = new Vector3(transform.position.x,transform.position.y + 0.75f,transform.position.z); //cant directlt edit transform.position.y
                    Player.isHolding = false;
                }
            
            }
        }
        
    }
}

