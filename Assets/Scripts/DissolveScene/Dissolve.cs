using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissolve : MonoBehaviour
{
    // Start is called before the first frame update

    public PortalCamera portalCamera;
    private Material _portalMaterial;

    void Start()
    {   
        //sharedMaterial->materialは複製になる．sharedMaterialだと，そのRendererそのもののMaterialを変更できる．
        _portalMaterial=GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        portalCamera.RenderIntoMaterial(_portalMaterial);
    }
}
