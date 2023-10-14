using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawningSystem : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Minimum X angle.")]
    [SerializeField] private float xmin;
    [Tooltip("Maximum X angle.")]
    [SerializeField] private float xmax;

    [Tooltip("Minimum Y angle.")]
    [SerializeField] private float ymin;
    [Tooltip("Maximum Y angle.")]
    [SerializeField] private float ymax;

    [Tooltip("Minimum distance from center.")]
    [SerializeField] private float dmin;
    [Tooltip("Maximum distance from center.")]
    [SerializeField] private float dmax;

    [Header("Colours")]

    [SerializeField] Color xminColor;
    [SerializeField] Color xmaxColor;

    [SerializeField] Color yminColor;
    [SerializeField] Color ymaxColor;

    [SerializeField] Color dminColor;
    [SerializeField] Color dmaxColor;


    // This method is called when the gizmos are drawn in the Unity Editor.
    private void OnDrawGizmos()
    {
        Gizmos.color = dminColor;
        Gizmos.DrawSphere(transform.position, dmin);
        Gizmos.color = dmaxColor;
        Gizmos.DrawSphere(transform.position, dmax);

        Gizmos.color = Color.cyan;

 
        Vector3 centre = transform.position;
        /*
        Gizmos.DrawLine(
            centre + Quaternion.Euler(xmin, ymin, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(xmax, ymin, 0) * Vector3.forward * dmax

            );
        */

        Gizmos.DrawLine(
            centre + Quaternion.Euler(xmin, ymin, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(xmin, ymin, 0) * Vector3.forward * dmax
        );
        Gizmos.DrawLine(
            centre + Quaternion.Euler(xmax, ymin, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(xmax, ymin, 0) * Vector3.forward * dmax
        );
        Gizmos.DrawLine(
            centre + Quaternion.Euler(xmax, ymax, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(xmax, ymax, 0) * Vector3.forward * dmax
            
        );
        Gizmos.DrawLine(
            centre + Quaternion.Euler(xmin, ymax, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(xmin, ymax, 0) * Vector3.forward * dmax
        ); 
        
    }
}
