
Shader "Unlit/PortalShader"
{
    Properties
    {
        [NoScaleOffset]
        _LeftEyeTexture("Left Eye Texture",2D)="black"{}
        [NoScaleOffset]
        _RightEyeTexture("Right Eye Texture",2D)="white"{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile __ STEREO_RENDER

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
            };
            sampler2D _LeftEyeTexture;
            sampler2D _RightEyeTexture;
            

            v2f vert (appdata v,out float4 outpos :SV_POSITION)
            {
                v2f o;
                outpos=UnityObjectToClipPos(v.vertex);
                o.uv=v.uv;
                return o;
            }

            fixed4 frag (v2f i,UNITY_VPOS_TYPE screenPos: VPOS) : SV_Target
            {
                fixed2 sUV =screenPos.xy/_ScreenParams.xy;

                fixed4 col=fixed4(0.0,0.0,0.0,0.0);

                /*VRのディスプレイは，円状にくりぬかれるので，sUVにする必要があったんですねぇ～！*/
                if(unity_StereoEyeIndex==0){
                    col=tex2D(_LeftEyeTexture,fixed2(sUV.x,1.0-sUV.y));
                }
                else{
                    col=tex2D(_RightEyeTexture,fixed2(sUV.x,1.0-sUV.y));
                }
                return col;
               /* fixed4 col=fixed4(0,0,0,0);
                if(unity_StereoEyeIndex==0){
                    col=tex2D(_LeftEyeTexture,i.uv);
                }else{
                    col=tex2D(_RightEyeTexture,i.uv);
                }
                return col;*/
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}