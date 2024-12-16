using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBattery : MonoBehaviour
{
    [SerializeField]
    GameObject batteryTiles;
    [SerializeField]
    GameObject battery;
    [SerializeField]
    GameObject spawner;
    private bool batterySet = true;
    private List<GameObject> tilesForBattery = new List<GameObject>();
    private bool possibleBatterySet = true;
    // Start is called before the first frame update
    void Start()
    {
        tilesForBattery.Clear();
        for (int i = 0; i < batteryTiles.transform.childCount; i++)
        {
            tilesForBattery.Add(batteryTiles.transform.GetChild(i).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawner.GetComponent<Spawn>().turnOn)
        {
            if (!batterySet)
            {
                batterySet = true;
                int howmuchbatteries = howMuchBatteries();
                for (int j = 0; j < howmuchbatteries; j++)
                {
                    int rand = 0;
                    for (int i = 0; i < tilesForBattery.Count; i++)
                    {
                        if (tilesForBattery[i].GetComponent<IsOccupied>().isOccupied == false)
                        {
                            possibleBatterySet = true;
                            break;
                        }
                        else
                        {
                            possibleBatterySet = false;
                        }
                    }
                    if (!possibleBatterySet)
                    {
                        return;
                    }
                    do
                    {
                        rand = Random.Range(0, tilesForBattery.Count);
                    } while (tilesForBattery[rand].GetComponent<IsOccupied>().isOccupied == true);
                    Instantiate(battery, tilesForBattery[rand].transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            batterySet = false;
        }
    }
    private int howMuchBatteries()
    {
        return Random.Range(1, 3);
    }
}
