/*********************************************************************
    PROGRAMME	:	Blocxors Final Project: Bridge Move

    OUTLINE		:	This program controls the movement of the bridge such
                    that the bridge moves up and down when triggered by
                    the trigger using the "direction" variable which can
                    be referenced outside this program

    PROGRAMMER	:	Saikrishna Tadepalli, Poojiths Bejugama, Hazik Amin

    DATE		:	December 20th 2019
**********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMove : MonoBehaviour
{
    [SerializeField]
    public int direction;

    [SerializeField]
    private float heightMin;

    [SerializeField]
    private float heightMax;

    [SerializeField]
    private float speed = 50f;

    // the movement is controlled down below
    void Update()
    {
        if (direction == -1)
            this.GetComponentInChildren<BoxCollider>().enabled = false;
        else
            this.GetComponentInChildren<BoxCollider>().enabled = true;

        if ((direction == -1 && this.transform.position.y > heightMin) || (direction == 1 && this.transform.position.y < heightMax))
        {
            transform.position += new Vector3(0, direction * speed * Time.deltaTime, 0);
            if (this.transform.position.y > heightMax)
            {
                this.transform.position = new Vector3(this.transform.position.x, heightMax, this.transform.position.z);
            }
        }
    }
}
