using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //Debug.Log(other.transform.tag);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            rb.velocity = new Vector3(0, -50, 0);
            pm.enabled = false;
            Debug.Log("PlayerMovementDisbaled");
        }
    }
}
