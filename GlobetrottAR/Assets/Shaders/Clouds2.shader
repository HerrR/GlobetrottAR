// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/Clouds2"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
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
				half3 normal : TEXCOORD1;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				half3 worldNormal : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				float3 viewDir : TEXCOORD4;
				UNITY_FOG_COORDS(3)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldNormal = v.normal;//UnityObjectToWorldNormal(v.normal);
				o.viewDir = normalize(ObjSpaceViewDir(v.vertex));
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				//float3 viewDir = normalize(IN.viewDir);
				half3 worldViewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
				float3 worldSpaceViewDir = _WorldSpaceCameraPos.xyz - i.worldPos;
				half3 viewDir = UNITY_MATRIX_IT_MV[2].xyz;
				half3 worldNormal = normalize(i.worldNormal);
				half opacity = dot(worldNormal, i.viewDir);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				col.a *= opacity;
				return col;
			}
			ENDCG
		}
	}
}
