Shader "Custom/Clouds" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Transition("Transition", Range(0,10)) = 0.0
	}
	SubShader {
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		half _Transition;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			float3 viewDir = normalize(IN.viewDir);
			float3 n = normalize(o.Normal);
			half opacity = dot(viewDir, n);
			opacity *= _Transition;
			opacity = clamp(opacity, 0.2, 1.0);
			opacity -= 0.2;

			o.Albedo = _Color * opacity;
			o.Alpha = c * opacity;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
