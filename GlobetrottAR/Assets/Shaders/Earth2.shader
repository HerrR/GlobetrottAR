Shader "Custom/Earth2" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_MapTex ("Map Texture", 2D) = "white" {}
		_FoWTex("FoW Texture", 2D) = "white" {}
		_SpecMap("Specular Map", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows //vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MapTex;
		sampler2D _SpecMap;
		sampler2D _FoWTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MapTex;
			float2 uv_SpecMap;
			float2 uv_FoWTex;
			float3 worldNormal;
		};

		half _Glossiness;
		half _Metallic;
		half _Transition;
		half _HighlightTransition;
		fixed4 _Color;


		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 mainColor = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 mapColor = tex2D(_MapTex, IN.uv_MapTex);
			fixed4 specColor = tex2D(_SpecMap, IN.uv_SpecMap);
			half blend = tex2D(_FoWTex, IN.uv_FoWTex);

			o.Albedo = mainColor * blend + mapColor * (1 - blend);
			o.Metallic = _Metallic * specColor;
			o.Smoothness = _Glossiness * specColor;
			o.Alpha = mainColor.a * blend + mapColor.a * (1 - blend);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
