using System.Collections;
using System.Collections.Generic;
using Apt.Unity.Projection;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    public Slider sliderFOV;
    public Text textFOV;
    public Slider sliderAngle;
    public Text textAngle;
    public Toggle toggleBox;
    public Toggle toggleNear;
    public Camera mainCamera;
    public ProjectionPlane projectionPlane;

    public void Start()
    {
        float fov = mainCamera.fieldOfView;
        sliderFOV.value = (fov - 20f) / 100f;
    }

    public void OnFOVChanged()
    {
        int fov = Mathf.RoundToInt(sliderFOV.value * 100f + 20f);
        textFOV.text = "FOV " + fov;
        mainCamera.fieldOfView = fov;
    }

    public void OnAngleChanged()
    {
        int angle = Mathf.RoundToInt(sliderAngle.value * 180f - 90f);
        textAngle.text = "Angle " + angle;
        var currentRot = projectionPlane.transform.localRotation.eulerAngles;
        projectionPlane.transform.localRotation = Quaternion.Euler(angle, currentRot.y, currentRot.z);
    }

    public void OnBoxChanged()
    {
        bool value = toggleBox.isOn;
        projectionPlane.ShowAlignmentCube = value;
    }

    public void OnNearChanged()
    {
        bool value = toggleNear.isOn;
        var pcam = mainCamera.GetComponent<ProjectionPlaneCamera>();
        pcam.ClampNearPlane = value;

        if (!value)
        {
            mainCamera.nearClipPlane = 0.01f;
        }
    }
}
