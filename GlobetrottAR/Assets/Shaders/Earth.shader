Shader "Custom/Earth" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_DayTex ("Day Texture", 2D) = "white" {}
		_NightTex ("Night Texture", 2D) = "white" {}
		_NormalMap ("Normal Map", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Transition ("Transition", Range(0,10)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows //vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _DayTex;
		sampler2D _NightTex;
		sampler2D _NormalMap;

		struct Input {
			float2 uv_DayTex;
			float2 uv_NightTex;
			float2 uv_NormalMap;
			float3 worldNormal;
			/*float3 bitangent;
			float3 tangent;
			INTERNAL_DATA*/
		};

		half _Glossiness;
		half _Metallic;
		half _Transition;
		fixed4 _Color;

		/*void vert(inout appdata_tan i, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.bitangent = normalize(cross(i.normal, i.tangent.xyz) * i.tangent.w);
			o.tangent = i.tangent;
		}*/

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 dayColor = tex2D(_DayTex, IN.uv_DayTex) * _Color;
			fixed4 nightColor = tex2D(_NightTex, IN.uv_NightTex) * _Color;
			float3 n = IN.worldNormal;
			float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
			half blend = dot(n, lightDir);
			blend *= _Transition;
			blend = clamp(blend, 0.0, 1.0);

			//float3x3 tangentTransform = float3x3(IN.tangent, IN.bitangent, n); 
			//o.Normal = normalize(mul(UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap)), tangentTransform)) * 0.1;

			//o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));

			//o.Albedo = _Color * blend;
			o.Albedo = dayColor * blend + nightColor * (1 - blend);
			// Metallic and smoothness come from slider variables
			// o.Metallic = _Metallic;
			// o.Smoothness = _Glossiness;
			o.Alpha = dayColor.a * blend + nightColor.a * (1 - blend);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
