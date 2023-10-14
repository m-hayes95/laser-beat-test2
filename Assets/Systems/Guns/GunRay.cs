using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunRay : MonoBehaviour
{
    //[Range(1f, 5000f)] [SerializeField] private float rayLength = 10f;
    [SerializeField] private Transform leftGunMuzzle;
    [SerializeField] private Transform rightGunMuzzle;

    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;

    private Animation gunShotLeftAnim;
    private Animation gunShotRightAnim;

    private AudioSource gunShotSound;

    private Vector3 latestRayHitLeft;
    private Vector3 latestRayHitRight;

    private void Start()
    {
        gunShotLeftAnim = leftGun.GetComponent<Animation>();
        gunShotRightAnim = rightGun.GetComponent<Animation>();
        gunShotSound = leftGun.GetComponent<AudioSource>();    
    }
    private void Update()
    {
 

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Gun Shot");
            CastRayLeftGun();
            gunShotLeftAnim.Play();
            gunShotSound.Play();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Gun Shot");
            CastRayRightGun();
            gunShotRightAnim.Play();
            gunShotSound.Play();
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
                latestRayHitLeft = hit.point;
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
                latestRayHitRight = hit.point;
                Debug.Log("Right gun hit " + hit.collider.gameObject.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
  
        if (latestRayHitLeft != null)
        {
            Gizmos.DrawLine(leftGunMuzzle.position, latestRayHitLeft);
        }
        if (latestRayHitRight != null)
        {
            Gizmos.DrawLine(rightGunMuzzle.position, latestRayHitRight);
        }
        
    }
}
