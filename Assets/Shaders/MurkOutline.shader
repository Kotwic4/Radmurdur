Shader "Outlined/MurkOutline" {
    Properties {
        _Color("Main Color", Color) = (0.5,0.5,0.5,1)
        _MainTex("Texture", 2D) = "white" {}
        
        _OutlineColor("Outline color", Color) = (0,0,0,0.8)
        _OutlineWidth("Outline width", Range(0.0, 2.0)) = 0.1
    }
    
    CGINCLUDE
	#include "UnityCG.cginc"
	ENDCG

	SubShader {
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }

		Pass {
			ZWrite Off
			Cull Back
			
			CGPROGRAM
        
            struct v2f {
                float4 pos : POSITION;
            };

            uniform float _OutlineWidth;
	        uniform float4 _OutlineColor;

			#pragma vertex vert
			#pragma fragment frag

			v2f vert(appdata_base v)
			{
				v.vertex.xyz += _OutlineWidth * normalize(v.vertex.xyz);

				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;

			}

			half4 frag(v2f i) : COLOR
			{
				return _OutlineColor;
			}

			ENDCG
		}
        
        Tags { "Queue" = "Transparent" }
        
        CGPROGRAM
        
        uniform sampler2D _MainTex;
	    uniform float4 _Color;
        
        #pragma surface surf NoLighting noshadow
        
        struct Input {
            float2 uv_MainTex;
            float4 color : COLOR;
        };
        
        void surf(Input IN, inout SurfaceOutput  o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        
        fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten) {
            return fixed4(s.Albedo, s.Alpha);
        }
        ENDCG
    }
    
    Fallback "Unlit/Color"
}
