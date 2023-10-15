using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Google.ProtocolBuffers.DescriptorProtos.SourceCodeInfo.Types;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("SpawnRate is the number of targets spawning per second (Targets/s)")]
    [SerializeField] float SpawnRate;
    [Tooltip("A moving target lerps between two locations. 0% means none, 100% means all.")]
    [Range(0, 100)] [SerializeField] float PercentageMoving; // To-DO

    [Header("References")]
    [SerializeField] GameObject Target;
    [SerializeField] TargetArea Area;

    void Start()
    {
        StartCoroutine(StartSpawning());
    }
    private IEnumerator StartSpawning() {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            spawnRandomTarget();
        }
    }
    private void spawnRandomTarget()
    {
        Instantiate(Target, getRandomLocationInArea(), Quaternion.identity);
    }
    public Vector3 getRandomLocationInArea() {
        float randomDistance = Random.Range(Area.Dmin, Area.Dmax);
        float randomXAngle = Random.Range(Area.Xmin, Area.Xmax);
        float randomYAngle = Random.Range(Area.Ymin, Area.Ymax);
        Quaternion roation = Quaternion.Euler(-randomYAngle, randomXAngle, 0);
        return transform.position + roation * Vector3.forward * randomDistance;
    }
}