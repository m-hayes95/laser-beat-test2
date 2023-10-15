using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// README: This is the TargetArea, created by Robin Pound 14/10/2023
// TIP: The y values are used in their negative form as a perminant quickfix
public class TargetArea : MonoBehaviour
{
    [Header("Step 1: Distance")]
    [Tooltip("Minimum distance from center.")]
    [SerializeField] private float dmin; 
    [Tooltip("Maximum distance from center.")]
    [SerializeField] private float dmax;

    [Header("Step 2: X-Angle")]
    [Tooltip("Minimum X angle.")]
    [SerializeField] private float xmin;
    [Tooltip("Maximum X angle.")]
    [SerializeField] private float xmax;

    [Header("Step 3: Y-Angle")]
    [Tooltip("Minimum Y angle.")]
    [SerializeField] private float ymin;
    [Tooltip("Maximum Y angle.")]
    [SerializeField] private float ymax;

    [Header("SET-ALREADY")]
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

    public float Dmin { get => dmin; }
    public float Dmax { get => dmax; }
    public float Xmin { get => xmin; }
    public float Xmax { get => xmax; }
    public float Ymin { get => ymin; }
    public float Ymax { get => ymax; }
}
