using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Google.ProtocolBuffers.DescriptorProtos.SourceCodeInfo.Types;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("This isn't the spawn rate, this is a number which influences the spawn rate. The spawn rate is calculated internally.")]
    [SerializeField] float SpawnRateMultiplier;
    [Tooltip("How much the spawner will adjust it's spawnrate compared to how many cubes there are")] // ??? How is this going to work, idk yet
    [SerializeField] float SpawnRateVarience;

    private float SpawnRate; 
    private float PercentageMoving; // To-DO

    [Header("References")]
    [SerializeField] GameObject Target;
    [SerializeField] TargetArea Area;

    void Start()
    {
        for (int i = 0; i < 100; i++){spawnRandomTarget();}
    }
    private void spawnRandomTarget()
    {
        float randomDistance = Random.Range(Area.Dmin, Area.Dmax);
        float randomXAngle = Random.Range(Area.Xmin, Area.Xmax);
        float randomYAngle = Random.Range(Area.Ymin, Area.Ymax);
        Vector3 Randomlocation = transform.position + Quaternion.Euler(-randomYAngle, randomXAngle, 0) * Vector3.forward * randomDistance;
        Instantiate(Target, Randomlocation, Quaternion.identity);
    }
}