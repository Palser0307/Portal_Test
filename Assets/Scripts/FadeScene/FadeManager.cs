using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{   
    public Material material;
    [Range(0,1)]
    public float floatValue=1f;
    //設定したいShaderの変数
    private int  ValueId;

    // Start is called before the first frame update
    void Start()
    {
        ValueId=Shader.PropertyToID("_FadeTime");    
        floatValue=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //IDを取得するほうが早いのでIDで処理
        //material.SetFloat("_FloatValue",floatValue);
        material.SetFloat(ValueId,floatValue);
    }
}
