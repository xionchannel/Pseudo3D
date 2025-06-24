using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GNearController : MonoBehaviour
{
    public Toggle toggleGNear;
    public Transform mainCamera;

    private bool updateClip;

    public void Start()
    {
        updateClip = toggleGNear.isOn;
    }
    
    public void Update()
    {
        if (updateClip)
        {
            // GlobalShaderParameterのNearClipを設定する
            Shader.SetGlobalFloat("_NearClip", Mathf.Abs(mainCamera.localPosition.z));
        }
        else
        {
            Shader.SetGlobalFloat("_NearClip", 0f);
        }
    }

    public void OnGNearChanged()
    {
        updateClip = toggleGNear.isOn;
    }
}
