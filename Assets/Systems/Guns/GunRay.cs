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
        var avatar = VRAvatar.Active;
        if (avatar == null)
            return;

        var rightInput = GetInput(VRInputDeviceHand.Right);
        var leftInput = GetInput(VRInputDeviceHand.Left);


        //if (Input.GetMouseButtonDown(0)) 
        if (leftInput != null)
        {
            if (leftInput.GetButtonDown(VRButton.Trigger))
            {
                Debug.Log("Left Gun Shot");
                CastRayLeftGun();
                gunShotLeftAnim.Play();
                gunShotSound.Play();
            }
        }
        
        
        //if (Input.GetMouseButtonDown(1))
        if (rightInput != null)
        {
            if (rightInput.GetButtonDown(VRButton.Trigger))
            {
                Debug.Log("Right Gun Shot");
                CastRayRightGun();
                gunShotRightAnim.Play();
                gunShotSound.Play();
            }
        }
        
    }

    private IVRInputDevice GetInput(VRInputDeviceHand hand)
    {
        var device = VRDevice.Device;
        return hand == VRInputDeviceHand.Left ? 
            device.SecondaryInputDevice : device.PrimaryInputDevice;
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
