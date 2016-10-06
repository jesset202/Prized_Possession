using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    public GameObject[] players;
    public float dampTime = 0.15f;
    public float yPos = 0;
    private Vector3 velocity = Vector3.zero;
    private Camera myCamera;

    void Start()
    {
        myCamera = GetComponent<Camera>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        FindTarget();
        if (target)
        {
            Vector3 point = myCamera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - myCamera.ViewportToWorldPoint(new Vector3(0.7f, 0.5f, point.z));
            Vector3 destination = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z) + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

    //Camera will follow who is first
    void FindTarget()
    {
        //if(players[0].transform.InverseTransformPoint(players[1].transform.position).x < 0)
        //{
        //    target = players[0].transform;
        //}
        //else
        //{
        //    target = players[1].transform;
        //}
    }
}
