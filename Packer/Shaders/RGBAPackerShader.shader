Shader "Unlit/RGBAPackerShader"
{
    Properties
    {
        _ChannelRedTex ("Channel Red Texture", 2D) = "white" {}
        _ChannelGreenTex ("Channel Green Texture", 2D) = "white" {}
        _ChannelBlueTex ("Channel Blue Texture", 2D) = "white" {}
        _ChannelAlphaTex ("Channel Alpha Texture", 2D) = "white" {}
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

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _ChannelRedTex;
            sampler2D _ChannelGreenTex;
            sampler2D _ChannelBlueTex;
            sampler2D _ChannelAlphaTex;
            int _IsChannelRedInverted;
            int _IsChannelGreenInverted;
            int _IsChannelBlueInverted;
            int _IsChannelAlphaInverted;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // get rgba
                fixed r = tex2D(_ChannelRedTex, i.uv).r;
                fixed g = tex2D(_ChannelGreenTex, i.uv).r;
                fixed b = tex2D(_ChannelBlueTex, i.uv).r;
                fixed a = tex2D(_ChannelAlphaTex, i.uv).r;

                // invert rgba if necessary
                r = _IsChannelRedInverted ? 1-r : r;
                g = _IsChannelGreenInverted ? 1-g : g;
                b = _IsChannelBlueInverted ? 1-b : b;
                a = _IsChannelAlphaInverted ? 1-a : a;

                return fixed4(r, g, b, a);
            }
            ENDCG
        }
    }
}
