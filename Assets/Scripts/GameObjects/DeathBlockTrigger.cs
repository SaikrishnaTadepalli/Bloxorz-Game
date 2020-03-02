using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlockTrigger : MonoBehaviour
{
    public Collider collidedObj;
    private void OnTriggerEnter(Collider other)
    {
        collidedObj = other;
        transform.parent.GetComponent<DeathBlock>().CollisionDetected(this);
    }
}
