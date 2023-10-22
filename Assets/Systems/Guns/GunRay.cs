using System.Collections;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class GunRay : MonoBehaviour
{
    [SerializeField] private Transform leftGunMuzzle;
    [SerializeField] private Transform rightGunMuzzle;

    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;

    [Range(0.1f, 1f)] [SerializeField] private float shotDelay;

    private Animation gunShotLeftAnim;
    private Animation gunShotRightAnim;

    private AudioSource gunShotSound;

    private Vector3 lastRayHitLeft;
    private Vector3 lastRayHitRight;

    private int targetsHit = 0;


    private void Start()
    {
        gunShotLeftAnim = leftGun.GetComponent<Animation>();
        gunShotRightAnim = rightGun.GetComponent<Animation>();
        gunShotSound = leftGun.GetComponent<AudioSource>();    
    }

    private void Update()
    {
        Debug.Log("Number of targets hit " + targetsHit);

        // Add shoot delay
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
            if (hit.collider != null && 
                hit.collider.gameObject.GetComponent<Target1Tag>())
            {
                lastRayHitLeft = hit.point;
                Debug.Log("Left gun hit " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject, .1f);
                targetsHit++;
            }
        }
    }

    private void CastRayRightGun()
    {
        RaycastHit hit;
        Ray gunRay = new Ray(rightGunMuzzle.position, Vector3.forward);
  
        if (Physics.Raycast(gunRay, out hit))
        {
            if (hit.collider != null &&
                hit.collider.gameObject.GetComponent<Target2Tag>())
            {
                lastRayHitRight = hit.point;
                Debug.Log("Right gun hit " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject, .1f);
                targetsHit ++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
  
        if (lastRayHitLeft != Vector3.zero)
        {
            Gizmos.DrawLine(leftGunMuzzle.position, lastRayHitLeft);
        }
        if (lastRayHitRight != Vector3.zero)
        {
            Gizmos.DrawLine(rightGunMuzzle.position, lastRayHitRight);
        }
        
    }
}
