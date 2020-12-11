using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator anim; // This is to give reference to the animations under the Animator tab


    // This will allow us to trigger events when we run into trigger objects
     void OnTriggerEnter(Collider obj)
    {
        anim.SetBool("isOpening",true);
    }

   /* void OnTriggerExit(Collider obj)
    {
        anim.SetBool("isOpening", false);
    }*/


    // Start is called before the first frame update
    // Getting hold of the Animator that is attached to the parent of this particular Game Object that the script will be attached to
    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
