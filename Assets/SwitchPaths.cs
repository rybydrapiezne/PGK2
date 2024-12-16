using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPaths : MonoBehaviour
{
    [SerializeField]
    GameObject path1;
    [SerializeField]
    GameObject path2;
    [SerializeField]
    private GameObject path1Waypoint;
    [SerializeField]
    private GameObject path2Waypoint;
    [SerializeField]
    private GameObject arrow;
    private GameObject arrowReal;
    List<GameObject> listOfPaths;
    List<GameObject> listOfWaypoints;
    // Start is called before the first frame update
    void Start()
    {
        listOfPaths=new List<GameObject>();
        listOfWaypoints = new List<GameObject>();
        listOfPaths.Add(path1);
        listOfPaths.Add(path2);
        listOfWaypoints.Add(path1Waypoint);
        listOfWaypoints.Add(path2Waypoint);
        arrowReal=Instantiate(arrow, path1Waypoint.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0;i<listOfPaths.Count;i++)
            {
                if (listOfPaths[i].GetComponent<IsPath>().isActive == true)
                {
                    listOfPaths[i].GetComponent<IsPath>().isActive = false;
                }
                else
                {
                    listOfPaths[i].GetComponent<IsPath>().isActive = true;
                    arrowReal.transform.position = listOfWaypoints[i].transform.position;
                }
            }
        }
    }
}
