Shader "Unlit/fade"
{
    Properties
    {
        _FadeTime("FadeTime",Range(0,1))=0.0
    }
    SubShader
    {
        Tags { "RenderType"="Overlay" 
                "Queue"="Overlay"
        }
        LOD 100
        ztest always
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            half _FadeTime;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
               float4 col=float4(0,0,0,0);
               col.w=_FadeTime;
              
                return col;
            }
            ENDCG
        }
    }
}
