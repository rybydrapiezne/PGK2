using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject robot;
    [SerializeField]
    GameObject robot2;
    [SerializeField]
    GameObject robot3;
    [SerializeField]
    GameObject robot4;
    [SerializeField]
    GameObject pathPoint1;
    [SerializeField]
    GameObject endPoint;
    [SerializeField]
    GameObject pathPoint2;
    [SerializeField]
    GameObject queuePanel;
    [SerializeField]
    GameObject castle;
    [SerializeField]
    GameObject robotCounter;
    [SerializeField]
    Button startButton;
    [SerializeField]
    TMP_Text coinamount;
    public int coins = 20;
    private int cost = 0;
    private string text;
    public bool turnOn = false;


    public List<string> robotsQueue = new List<string>();
    public List<GameObject> robotsObjectsQueue = new List<GameObject>();
    public List<string> lastRobotsObjectsQueue = new List<string>();

    private Image[] images;

    void Start()
    {
        images = queuePanel.GetComponentsInChildren<Image>();


    }

    void updateQueue()
    {

        for (int i = 0; i < robotsQueue.Count; i++)
        {
            if (robotsQueue[i] == "gray")
                images[i].color = Color.gray;
            else if (robotsQueue[i] == "electric")
                images[i].color = Color.yellow;
            else if (robotsQueue[i] == "blue")
                images[i].color = Color.blue;
            else if (robotsQueue[i] == "red")
                images[i].color = Color.red;

        }
    }
    public void clearQueue()
    {
        robotsQueue.Clear();
        cost = 0;
        for(int i=0;i<images.Length;i++)
        {
            images[i].color = Color.white;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(robotsObjectsQueue.Count()==0)
        {
            startButton.enabled = true;
            turnOn = false;
        }
        text = (coins - cost).ToString();
        coinamount.text = text;
    }


    public void AddGrayAlly()
    {
        if (robotsQueue.Count < 6)
        {
            if (coins - 1 -cost >= 0)
            {
                cost += 1;
                robotsQueue.Add("gray");
                Debug.Log("Gray ally added");
                updateQueue();
            }
        }
    }
    public void AddRedAlly()
    {
        if (robotsQueue.Count < 6)
        {
            if (coins - 2 - cost>= 0)
            {
                cost += 2;
                robotsQueue.Add("red");
                Debug.Log("Red ally added");
                updateQueue();
            }
        }
    }

    public void AddRBluelly()
    {
        if (robotsQueue.Count < 6)
        {
            if (coins - 3 - cost>= 0)
            {
                cost += 3;
                robotsQueue.Add("blue");
                Debug.Log("Blue ally added");
                updateQueue();
            }
        }
    }

    public void AddElectricAlly()
    {
        if (robotsQueue.Count < 6)
        {
            if (coins - 4 - cost>= 0)
            {
                cost += 4;
                robotsQueue.Add("electric");
                Debug.Log("Electric ally added");
                updateQueue();
            }
        }
    }

    public void StartQueue()
    {
        GameObject temp = pathPoint1;
        startButton.enabled = false;
        robotCounter.GetComponent<countRobots>().robots = robotsQueue.Count;

        turnOn = true;
        if (pathPoint1.GetComponent<IsPath>().isActive == true)
            temp = pathPoint1;
        if (pathPoint2.GetComponent<IsPath>().isActive == true)
            temp = pathPoint2;

        foreach (string rodzajR in robotsQueue)
        {
            if (rodzajR == "gray")
            {
                GameObject Unit = GameObject.Instantiate(robot, transform.position, transform.rotation);
                robotsObjectsQueue.Add(Unit);
                Unit.GetComponent<Move>().endPoint = endPoint;
                Unit.GetComponent<Move>().pathPoint = temp;
                Unit.GetComponent<Move>().castle = castle;
                Unit.GetComponent<Move>().robotCounter = robotCounter;
            }
            else if (rodzajR == "red")
            {
                GameObject Unit = GameObject.Instantiate(robot2, transform.position, transform.rotation);
                robotsObjectsQueue.Add(Unit);

                Unit.GetComponent<Move>().endPoint = endPoint;
                Unit.GetComponent<Move>().pathPoint = temp;
                Unit.GetComponent<Move>().castle = castle;
                Unit.GetComponent<Move>().robotCounter = robotCounter;



            }
            else if (rodzajR == "blue")
            {
                GameObject Unit = GameObject.Instantiate(robot3, transform.position, transform.rotation);
                robotsObjectsQueue.Add(Unit);

                Unit.GetComponent<Move>().endPoint = endPoint;
                Unit.GetComponent<Move>().pathPoint = temp;
                Unit.GetComponent<Move>().castle = castle;
                Unit.GetComponent<Move>().robotCounter = robotCounter;



            }
            else if (rodzajR == "electric")
            {
                GameObject Unit = GameObject.Instantiate(robot4, transform.position, transform.rotation);
                robotsObjectsQueue.Add(Unit);

                Unit.GetComponent<Move>().endPoint = endPoint;
                Unit.GetComponent<Move>().pathPoint = temp;
                Unit.GetComponent<Move>().castle = castle;
                Unit.GetComponent<Move>().robotCounter = robotCounter;



            }
        }
        lastRobotsObjectsQueue.Clear();
        coins = coins - cost;
        cost = 0;
        foreach(GameObject robot in robotsObjectsQueue)
        {
            lastRobotsObjectsQueue.Add(robot.gameObject.name);
        }
        robotsQueue.Clear();
        for(int i=0;i<images.Count();i++)
        {
            images[i].color= Color.white;
        }
    }
}
