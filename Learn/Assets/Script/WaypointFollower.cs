using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypiontIndex = 0;

    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypiontIndex].transform.position,transform.position)<.1f)
        {
            currentWaypiontIndex++;
            if(currentWaypiontIndex>=waypoints.Length)
            {
                currentWaypiontIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypiontIndex].transform.position, Time.deltaTime * speed);
    }
}
