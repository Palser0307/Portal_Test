using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveManager : MonoBehaviour
{   
    public Material material;
    [Range(0,1)]
    public float OpacityValue=1.0f;
    //設定したいShaderの変数
    private int  ValueId;

    // Start is called before the first frame update
    void Start()
    {
        ValueId=Shader.PropertyToID("_Opacity");    
    }

    // Update is called once per frame
    void Update()
    {
        //IDを取得するほうが早いのでIDで処理
        //material.SetFloat("_FloatValue",floatValue);
        material.SetFloat(ValueId,OpacityValue);
    }
}
