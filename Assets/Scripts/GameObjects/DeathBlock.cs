using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;
    [SerializeField] Vector3 startPosition;
    [SerializeField] float horDist;
    [SerializeField] float vertDist;
    [SerializeField] float speed = 8f;
    [SerializeField] float direction = 1;
    [SerializeField] int firstPointIndex = 0;
    private Vector3 toPoint;
    Vector3[] points = new Vector3[4];

    private void Start()
    {
        horDist *= 4;
        vertDist *= 4;
        GetPoints();
        toPoint = points[firstPointIndex];
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, toPoint, speed * Time.deltaTime);
        if (Mathf.Abs(this.transform.position.x - toPoint.x) < 0.1f && Mathf.Abs(this.transform.position.z - toPoint.z) < 0.1f)
        {
            this.transform.position = toPoint;
            UpdatePoint();
        }
    }
    public void CollisionDetected(DeathBlockTrigger childScript)
    {
        StartCoroutine(ResawnPlayer(childScript.collidedObj.gameObject));
    }

    private void UpdatePoint()
    {
        if (direction == 1)
        {
            if (toPoint == points[0])
            { toPoint = points[1]; }
            else if (toPoint == points[1])
            { toPoint = points[2]; }
            else if (toPoint == points[2])
            { toPoint = points[3]; }
            else if (toPoint == points[3])
            { toPoint = points[0]; }
        }
        else if (direction == -1)
        {
            if (toPoint == points[0])
            { toPoint = points[3]; }
            else if (toPoint == points[1])
            { toPoint = points[0]; }
            else if (toPoint == points[2])
            { toPoint = points[1]; }
            else if (toPoint == points[3])
            { toPoint = points[2]; }
        }
    }

    private void GetPoints()
    {
        points[0] = startPosition;
        points[1] = points[0] + new Vector3(0, 0, horDist);
        points[2] = points[1] + new Vector3(vertDist, 0, 0);
        points[3] = points[2] + new Vector3(0, 0, -horDist);
    }

    private IEnumerator ResawnPlayer(GameObject player)
    {
        player.transform.GetComponent<PlayerMovement>().enabled = false;
        player.transform.GetComponent<Rigidbody>().detectCollisions = false;
        DeathBlock db = this.transform.GetComponent<DeathBlock>();
        yield return new WaitForSeconds(3);
        //gm.PlayerDead();
    }
}
