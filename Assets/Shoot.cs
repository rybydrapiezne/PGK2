using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float maxDistance = 10f;
    private float actDistance = float.MaxValue;
    public int dmgAmount = 11;
    public float shootingSpeed = 0.5f;
    private List<GameObject> robots;
    private GameObject closestRobot;
    public GameObject particleSystemPrefab;
    public GameObject particleStart;

    void Start()
    {
        StartCoroutine(ShootingCoroutine());
    }

    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            robots = GameObject.Find("Spawner").GetComponent<Spawn>().robotsObjectsQueue;
            closestRobot = null;
            actDistance = float.MaxValue;

            if (robots != null && robots.Count > 0)
            {
                foreach (GameObject robot in robots)
                {
                    float distance = Vector3.Distance(robot.transform.position, transform.position);
                    if (distance < actDistance && distance <= maxDistance)
                    {
                        closestRobot = robot;
                        actDistance = distance;
                    }
                }

                if (closestRobot != null)
                {
                    // Inflict damage
                    closestRobot.GetComponent<HealthRobot>().getHit(dmgAmount);
                    this.GetComponent<AudioSource>().Play();
                    // Rotate particle start to face the closest robot
                    Vector3 directionToTarget = closestRobot.transform.position - particleStart.transform.position;
                    directionToTarget.y = 0; // Ignore vertical rotation
                    particleStart.transform.rotation = Quaternion.LookRotation(directionToTarget);

                    // Spawn the particle system
                    Instantiate(particleSystemPrefab, particleStart.transform.position, particleStart.transform.rotation);
                }

                yield return new WaitForSecondsRealtime(shootingSpeed);
            }
            else
            {
                yield return new WaitForSeconds(1); // Wait before retrying if no robots are found
            }
        }
    }
}
