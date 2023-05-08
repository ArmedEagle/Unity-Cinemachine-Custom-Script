using Cinemachine;
using UnityEngine;

public class FOVController : MonoBehaviour
{
    //This scrpt will hlp you to control the verticalFOV of the cinemachine during gameplay using the mouse scroll wheel

    //minFOV and maxFOV defines the FOV min and max value;
    public float minFOV;
    public float maxFOV;
    //speed at which the FOV changes
    public float fovSpeed;

    private CinemachineVirtualCamera vcam;

    [SerializeField]
    private inputType input;

    internal enum inputType
    {
        mouseScrollWheel,
        verticalInput,
    }

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        //Get the current vertical FOV
        //float currentFOV = vcam.m_Lens.FieldOfView;

        float scrollDelta = Input.mouseScrollDelta.y;
        float inputDelta = Input.GetAxis("Vertical");

        //Calculate new FOV and choosing btw either using the vertical input or the mouse scroll wheel
        if (input == inputType.mouseScrollWheel)
        {
            float newFOV = Mathf.Lerp(vcam.m_Lens.FieldOfView, minFOV, scrollDelta * fovSpeed);
            vcam.m_Lens.FieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);
        }
        else if (input == inputType.verticalInput)
        {
            float newFOV = Mathf.Lerp(vcam.m_Lens.FieldOfView, minFOV, inputDelta * fovSpeed);
            vcam.m_Lens.FieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);
        }

        if (inputDelta < 0)
        {
            //Zoom in
            vcam.m_Lens.FieldOfView += fovSpeed;
        }

        if (inputDelta > 0)
        {
            //Zoom out
            vcam.m_Lens.FieldOfView -= fovSpeed;
        }

        if (inputDelta != 0)
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, minFOV, inputDelta * fovSpeed);
        }
        //Set the new FOV
        //vcam.m_Lens.FieldOfView = newFOV;
    }
}
