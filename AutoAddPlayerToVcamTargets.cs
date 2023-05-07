using Cinemachine;
using UnityEngine;

public class AutoAddPlayerToVcamTargets : MonoBehaviour
{
    //Here we are just creating a tag field so that you can chose the gameObject the cinemachine should follow
    [TagField]
    public string Tag = string.Empty;

    //You can change the void update to start but it's preferable to put update 
    //Because you might have some problems with the void start
    //And also you can also modify this code so that the cinamchine should tag different gameObject depending on you..
    //... during gameplay
    void Start()
    {
        //Getting the CinemachineVirtualCameraBase
        var vcam = GetComponent<CinemachineVirtualCameraBase>();
        if (vcam != null && Tag.Length > 0)
        {
            var targets = GameObject.FindGameObjectsWithTag(Tag);
            //If we have choose a gameobject to tag then the 'LookAt' and "Follow" part of the cinemachine will tag the transform of this gameobject
            if (targets.Length > 0)
            {
                vcam.LookAt = vcam.Follow = targets[0].transform;
            }
        }
    }

    //This script should be place on the camera containing the CinemachineVirtualCameraBase
}
