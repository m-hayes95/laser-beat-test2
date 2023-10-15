using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Target;
    private float dmin;
    private float dmax;
    private float xmin;
    private float xmax;
    private float ymin;
    private float ymax;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            spawnRandomTarget();
        }
    }
    private void spawnRandomTarget()
    {
        float randomDistance = Random.Range(dmin, dmax);
        float randomXAngle = Random.Range(xmin, xmax);
        float randomYAngle = Random.Range(ymin, ymax);
        Vector3 RandomPlace = transform.position + Quaternion.Euler(-randomYAngle, randomXAngle, 0) * Vector3.forward * randomDistance;
        spawnTarget(RandomPlace);
    }
    private void spawnTarget(Vector3 location)
    {
        Instantiate(Target, location, Quaternion.identity);
    }
}
