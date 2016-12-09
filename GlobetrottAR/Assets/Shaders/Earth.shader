Shader "Custom/Earth" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Day Texture", 2D) = "white" {}
		_MapTex ("Night Texture", 2D) = "white" {}
		_SpecMap("Specular Map", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Transition ("Transition", Range(0,10)) = 0.0
		_HighlightTransition("Highlight Transition", Range(0,10)) = 0.0
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

		struct Input {
			float2 uv_MainTex;
			float2 uv_MapTex;
			float2 uv_SpecMap;
			float3 worldNormal;
			/*float3 bitangent;
			float3 tangent;
			INTERNAL_DATA*/
		};

		half _Glossiness;
		half _Metallic;
		half _Transition;
		half _HighlightTransition;
		fixed4 _Color;

		/*void vert(inout appdata_tan i, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.bitangent = normalize(cross(i.normal, i.tangent.xyz) * i.tangent.w);
			o.tangent = i.tangent;
		}*/

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 mainColor = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 mapColor = tex2D(_MapTex, IN.uv_MapTex);
			fixed4 specColor = tex2D(_SpecMap, IN.uv_SpecMap);
			float3 n = IN.worldNormal;
			float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
			half blend = dot(n, lightDir);
			blend *= _Transition;
			blend = clamp(blend, 0.0, 1.0);

			//float3x3 tangentTransform = float3x3(IN.tangent, IN.bitangent, n); 
			//o.Normal = normalize(mul(UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap)), tangentTransform)) * 0.1;

			//o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));

			o.Albedo = mainColor * blend + mapColor * (1 - blend);
			o.Metallic = _Metallic * specColor;
			o.Smoothness = _Glossiness * specColor;
			o.Alpha = mainColor.a * blend + mapColor.a * (1 - blend);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
