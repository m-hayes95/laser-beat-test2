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

    [Header("Sphere Colours")]
    [SerializeField] Color dminColor;
    [SerializeField] Color dmaxColor;

    private void DrawLine(Vector3 centre, float z11, float z12, float z21, float z22, float d1, float d2) {
        Gizmos.DrawLine( // TOP RIGHT
            centre + Quaternion.Euler(z11, z12, 0) * Vector3.forward * d1,
            centre + Quaternion.Euler(z21, z22, 0) * Vector3.forward * d2
        );
    }
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
        DrawLine(centre, -ymax, xmax, -ymax, xmax, dmin, dmax);
        DrawLine(centre, -ymin, xmax, -ymin, xmax, dmin, dmax);
        DrawLine(centre, -ymin, xmin, -ymin, xmin, dmin, dmax);
        DrawLine(centre, -ymax, xmin, -ymax, xmin, dmin, dmax);

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

    // Getters
    public float Dmin { get => dmin; }
    public float Dmax { get => dmax; }
    public float Xmin { get => xmin; }
    public float Xmax { get => xmax; }
    public float Ymin { get => ymin; }
    public float Ymax { get => ymax; }
}
