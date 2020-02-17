using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RecenterHmd : MonoBehaviour
{
    // Start is called before the first frame update
    public void RecenterDevice()
    {
        OVRManager.display.RecenterPose();
        InputTracking.Recenter();
    }
}
