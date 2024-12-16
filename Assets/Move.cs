using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    public GameObject pathPoint;
    [SerializeField]
    public GameObject endPoint;
    [SerializeField]
    public GameObject castle;
    public GameObject robotCounter;
    public LayerMask GroundLayer;
    public int castleDmg = 10;
    public int cost = 1;
    bool walkpointSet=false;
    int pointsWent=0;
    NavMeshAgent agent;
    Vector3 destPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!walkpointSet && pointsWent==0)
            setPoint();
        if(walkpointSet)
        {
            agent.SetDestination(destPoint);

        }
        if (Vector3.Distance(transform.position, destPoint) < 3)
            agent.SetDestination(endPoint.transform.position);
            walkpointSet = false;
        if (Vector3.Distance(transform.position, endPoint.transform.position) < 3)
        {
            castle.GetComponent<Health>().health -= castleDmg;
            robotCounter.GetComponent<countRobots>().robots -= 1;
            Destroy(this.gameObject);
        }

    }
    void setPoint()
    {
        destPoint = pathPoint.transform.position;
        if(Physics.Raycast(destPoint,Vector3.down,GroundLayer))
        {
            walkpointSet = true;
            pointsWent += 1;
        }
    }
    private void OnDestroy()
    {
        GameObject.Find("Spawner").GetComponent<Spawn>().robotsObjectsQueue.Remove(this.gameObject); 
    }
}
