using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField]
    GameObject coinTiles;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    GameObject spawner;
    private bool coinSet = false;
    private List<GameObject> tilesForCoins = new List<GameObject>();
    private bool possibleCoinSet = true;
    // Start is called before the first frame update
    void Start()
    {
        tilesForCoins.Clear();
        for (int i = 0; i < coinTiles.transform.childCount; i++)
        {
            tilesForCoins.Add(coinTiles.transform.GetChild(i).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawner.GetComponent<Spawn>().turnOn)
        {
            if (!coinSet)
            {
                coinSet = true;
                int howmuchcoins = howMuchCoins();
                for (int j = 0; j < howmuchcoins; j++)
                {
                    int rand = 0;
                    for (int i = 0; i < tilesForCoins.Count; i++)
                    {
                        if (tilesForCoins[i].GetComponent<IsOccupied>().isOccupied == false)
                        {
                            possibleCoinSet = true;
                            break;
                        }
                        else
                        {
                            possibleCoinSet = false;
                        }
                    }
                    if (!possibleCoinSet)
                    {
                        return;
                    }
                    do
                    {
                        rand = Random.Range(0, tilesForCoins.Count);
                    } while (tilesForCoins[rand].GetComponent<IsOccupied>().isOccupied == true);
                    Instantiate(coin, tilesForCoins[rand].transform.position, coin.transform.rotation);
                }
            }
        }
        else
        {
            coinSet = false;
        }
    }
    private int howMuchCoins()
    {
        return Random.Range(1, 3);
    }
}
