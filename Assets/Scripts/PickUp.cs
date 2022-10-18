using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private RaycastHit hit;
    GameObject pickedUpObject;
    public bool isHolding = false;
    public Transform theDest;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update(){ // every frame.. 200 frames per second. 
       if(Input.GetKey("e") && isHolding == false){

            Vector3 altered_transform = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);// lower the height of the ray casted out.
            
            if(Physics.Raycast(altered_transform,transform.forward,out hit,1)){
            
            if(hit.collider.gameObject.tag=="goal"){ //add collider reference otherwise you can't access gameObject!
                
                pickedUpObject=hit.collider.gameObject; 
                pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                pickedUpObject.GetComponent<Rigidbody>().position = theDest.position; 
                pickedUpObject.transform.parent = theDest.transform; 
                isHolding = true;
                
                }
            }
        } 

        if (Input.GetKey("r") && isHolding == true) {  //i made this a seperate key because update renders every frame and it captures e like... 20 times when you click it.
            pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
            
            pickedUpObject.transform.parent=null; 
            //pickedUpObject=null;
            isHolding = false;
        
        }

        if(isHolding == true){
           pickedUpObject.transform.position = theDest.position; 
        }
    

    
    }

    
    
    void FixedUpdate () {
        
    }   

}


