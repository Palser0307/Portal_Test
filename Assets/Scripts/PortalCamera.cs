using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PortalCamera : MonoBehaviour
{   
    //CemterEye in VR
    public Camera VrEye;

    RenderTexture _leftEyeRenderTexture;
    RenderTexture _rightEyeRenderTexture;
    //portals's view
    Camera _cameraForPortal;
    Vector3 _eyeOffset;

    protected void Awake()
    {
        _cameraForPortal = GetComponent<Camera>();
       // _cameraForPortal.enabled = false;
        

        //RenderTextureの生成
        _leftEyeRenderTexture = new RenderTexture((int)XRSettings.eyeTextureWidth, (int)XRSettings.eyeTextureHeight, 24);
        _rightEyeRenderTexture = new RenderTexture((int)XRSettings.eyeTextureWidth, (int)XRSettings.eyeTextureHeight, 24);

        int aa = QualitySettings.antiAliasing == 0 ? 1 : QualitySettings.antiAliasing;
        _leftEyeRenderTexture.antiAliasing = aa;
        _rightEyeRenderTexture.antiAliasing = aa;
    }


    public void RenderIntoMaterial(Material material)
    {
        // Left eye.
       var v = _cameraForPortal.transform.localPosition;
       //VrEye.stereoSeparation：両目の距離
       _cameraForPortal.transform.localPosition = v + new Vector3(-VrEye.stereoSeparation/2f, 0f, 0f);

        //projectionMatrixの設定
        _cameraForPortal.projectionMatrix =VrEye.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
        _cameraForPortal.targetTexture = _leftEyeRenderTexture;
        //Offset付きでレンダリングしてしまう
        _cameraForPortal.Render();
        //そいつをMaterialにつける
        material.SetTexture("_LeftEyeTexture", _leftEyeRenderTexture);

        // Right eye.
        v = _cameraForPortal.transform.localPosition;
        _cameraForPortal.transform.localPosition = v + new Vector3(VrEye.stereoSeparation/2f, 0f, 0f);

        _cameraForPortal.projectionMatrix = VrEye.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
        _cameraForPortal.targetTexture = _rightEyeRenderTexture;
        //Offset付きでレンダリングする
        _cameraForPortal.Render();
        //Material へ出力
        material.SetTexture("_RightEyeTexture", _rightEyeRenderTexture);
    }
}
