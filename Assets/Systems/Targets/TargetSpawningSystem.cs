using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// README: This is the Target Spawning System, created by Robin Pound
// TIP: The y values are used in their negative form as a perminant quickfix
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

    [SerializeField] Color dminColor;
    [SerializeField] Color dmaxColor;

    private void OnDrawGizmos()
    {
        // SETTINGS
        Vector3 centre = transform.position;
        const float LINELENGTH = 1;
        const float LINESPACE = 3;

        // Distance Representiation
        Gizmos.color = dminColor;
        Gizmos.DrawSphere(transform.position, dmin);
        Gizmos.color = dmaxColor;
        Gizmos.DrawSphere(transform.position, dmax);

        // 4 Lines
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine( // TOP RIGHT
            centre + Quaternion.Euler(-ymax, xmax, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(-ymax, xmax, 0) * Vector3.forward * dmax
        );
        Gizmos.DrawLine( // BOTTOM RIGHT
            centre + Quaternion.Euler(-ymin, xmax, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(-ymin, xmax, 0) * Vector3.forward * dmax
        );
        Gizmos.DrawLine( // BOTTOM LEFT
            centre + Quaternion.Euler(-ymin, xmin, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(-ymin, xmin, 0) * Vector3.forward * dmax 
        );
        Gizmos.DrawLine( // TOP Left
            centre + Quaternion.Euler(-ymax, xmin, 0) * Vector3.forward * dmin,
            centre + Quaternion.Euler(-ymax, xmin, 0) * Vector3.forward * dmax
        );

        // DOTTED LINES X-AXIS
        Gizmos.color = Color.cyan;
        for (float i = xmin; i < xmax; i += LINESPACE) 
        {
            Gizmos.DrawLine(
                centre + Quaternion.Euler(-ymax, i, 0) * Vector3.forward * dmax, 
                centre + Quaternion.Euler(-ymax, i + LINELENGTH, 0) * Vector3.forward * dmax
            );
            Gizmos.DrawLine(
                centre + Quaternion.Euler(-ymin, i, 0) * Vector3.forward * dmax,  
                centre + Quaternion.Euler(-ymin, i + LINELENGTH, 0) * Vector3.forward * dmax
            );
            Gizmos.DrawLine(
                centre + Quaternion.Euler(-ymax, i, 0) * Vector3.forward * dmin, 
                centre + Quaternion.Euler(-ymax, i + LINELENGTH, 0) * Vector3.forward * dmin
            );
            Gizmos.DrawLine(
                centre + Quaternion.Euler(-ymin, i, 0) * Vector3.forward * dmin, 
                centre + Quaternion.Euler(-ymin, i + LINELENGTH, 0) * Vector3.forward * dmin
            );
        }
        // DOTTED LINES Y-AXIS
        Gizmos.color = Color.cyan;
        for (float i = -ymax; i < -ymin; i += LINESPACE)
        {
            Gizmos.DrawLine(
                centre + Quaternion.Euler(i, xmax, 0) * Vector3.forward * dmax,
                centre + Quaternion.Euler(i + LINELENGTH, xmax, 0) * Vector3.forward * dmax
            );
            Gizmos.DrawLine(
                centre + Quaternion.Euler(i, xmin, 0) * Vector3.forward * dmax,
                centre + Quaternion.Euler(i + LINELENGTH, xmin, 0) * Vector3.forward * dmax
            );
            Gizmos.DrawLine(
                centre + Quaternion.Euler(i, xmax, 0) * Vector3.forward * dmin,
                centre + Quaternion.Euler(i + LINELENGTH, xmax, 0) * Vector3.forward * dmin
            );
            Gizmos.DrawLine(
                centre + Quaternion.Euler(i, xmin, 0) * Vector3.forward * dmin,
                centre + Quaternion.Euler(i + LINELENGTH, xmin, 0) * Vector3.forward * dmin
            );
        }
    }
}
