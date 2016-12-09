Shader "Custom/Atmosphere" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_RimPower ("Rim", Range(0, 10)) = 0.0
	}
	SubShader {
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
		};

		half _RimPower; 
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			//fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			//o.Emission = _Color * pow(rim, _RimPower);
			o.Albedo = _Color.rgb * pow(rim, _RimPower);
			o.Alpha = _Color.a * rim;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
