/*********************************************************************
    PROGRAMME	:	Blocxors Final Project: Bridge Trigger

    OUTLINE		:	This program allows for the bridge trigger to 
                    change the bridge objects direction variable. This
                    will make sure the bridge moves when triggered. 
                    the trigger will only respond when the player in 
                    the vertical position is directly above the trigger

    PROGRAMMER	:	Saikrishna Tadepalli, Poojiths Bejugama, Hazik Amin

    DATE		:	December 20th 2019
**********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] private Transform bridge;
    private BridgeMove bridgeScript;

    void Start()
    {
        bridgeScript = bridge.GetComponent<BridgeMove>();
    }
    // this method starts the check trigger method
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(checkTrigger(collision.transform));
    }
    // this method checks if the player is in a vertical position, and changes the bridge variable if it is in the vertical position
    private IEnumerator checkTrigger(Transform obj)
    {
        yield return new WaitForSeconds(0.15f);

        if (Mathf.Abs(this.transform.position.x - obj.position.x) < 0.4f && Mathf.Abs(this.transform.position.z - obj.position.z) < 0.4f)
            bridgeScript.direction *= -1;
    }
}