using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunRay : MonoBehaviour
{
    //[Range(1f, 5000f)] [SerializeField] private float rayLength = 10f;
    [SerializeField] private Transform leftGunMuzzle;
    [SerializeField] private Transform rightGunMuzzle;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Gun Shot");
            CastRayLeftGun();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Gun Shot");
            CastRayRightGun();
        }
    }

    private void CastRayLeftGun()
    {
        RaycastHit hit;
        Ray gunRay = new Ray(leftGunMuzzle.position, Vector3.forward);
        
        if (Physics.Raycast(gunRay, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("Left gun hit " + hit.collider.gameObject.name);
            }
        }
    }

    private void CastRayRightGun()
    {
        RaycastHit hit;
        Ray gunRay = new Ray(rightGunMuzzle.position, Vector3.forward);
  
        if (Physics.Raycast(gunRay, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("Right gun hit " + hit.collider.gameObject.name);
            }
        }
    }

    
}
