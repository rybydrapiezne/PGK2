using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTowers : MonoBehaviour
{
    [SerializeField]
    GameObject towerTiles;
    [SerializeField]
    GameObject DefaultTower;
    [SerializeField]
    GameObject RedTower;
    [SerializeField]
    GameObject BlueTower;
    [SerializeField]
    GameObject ElectricTower;
    [SerializeField]
    GameObject spawner;
    private bool towerSet=true;
    private List<GameObject> tilesForTowers=new List<GameObject>();
    private bool possibleTowerSet=true;
    // Start is called before the first frame update
    void Start()
    {
        tilesForTowers.Clear();
        for (int i = 0; i < towerTiles.transform.childCount; i++)
        {
            tilesForTowers.Add(towerTiles.transform.GetChild(i).gameObject);
        }
    }
        // Update is called once per frame
        void Update()
    {
        if(!spawner.GetComponent<Spawn>().turnOn)
        {
            if(!towerSet)
            {
                towerSet = true;
                int rand=0;
                for(int i=0;i<tilesForTowers.Count;i++)
                {
                    if (tilesForTowers[i].GetComponent<IsOccupied>().isOccupied==false ) {
                        possibleTowerSet = true;
                        break;
                    }
                    else
                    {
                        possibleTowerSet=false;
                    }
                }
                if(!possibleTowerSet)
                {
                    return;
                }
                do
                {
                    rand = Random.Range(0, tilesForTowers.Count);
                }while(tilesForTowers[rand].GetComponent<IsOccupied>().isOccupied == true);
                Instantiate(determineWhichTower(), tilesForTowers[rand].transform.position, Quaternion.identity);
                tilesForTowers[rand].GetComponent<IsOccupied>().isOccupied = true;
            }
        }
        else
        {
            towerSet = false;
        }
    }
    private GameObject determineWhichTower()
    {
        int grays = 0;
        int reds = 0;
        int electro = 0;
        int blue = 0;
        List<string> lastQueue=spawner.GetComponent<Spawn>().lastRobotsObjectsQueue;
        foreach(string robot in lastQueue)
        {
            if(robot=="Robot(Clone)")
            {
                grays += 1;
            }
            else if(robot== "Robot 1(Clone)")
            {
                reds += 1;
            }
            else if(robot== "Robot 2(Clone)")
            {
                blue += 1;
            }
            else if(robot== "Robot 3(Clone)")
            {
                electro += 1;
            }
        }
        if (grays > reds && grays > electro && grays > blue)
            return DefaultTower;
        else if (reds > grays && reds > electro && reds > blue)
            return RedTower;
        else if (electro > grays && electro > reds && electro > blue)
            return ElectricTower;
        else if (blue > grays && blue > reds && blue > electro)
            return BlueTower;

        return DefaultTower;
    }
}
