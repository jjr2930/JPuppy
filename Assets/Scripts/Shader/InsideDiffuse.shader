Shader "Unlit/InsideDiffuse"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_GroundTex("Base(RGB)",2D) = "white"{}
	}
	SubShader
	{

		Tags{ "RenderType" = "Opaque" }

		Cull Front

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _GroundTex;
			float4 _MainTex_ST;
			float4 _GroundTex_ST;

			struct VSInput
			{
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct FSInput
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};


			FSInput vert(VSInput i)
			{
				FSInput o;
				o.uv = i.uv;
				o.position = mul(UNITY_MATRIX_MVP, i.position);
				o.normal = mul(UNITY_MATRIX_M, i.normal);
				return o;
			}

			float4 frag(FSInput i) : COLOR
			{
				float4 o;
				if (i.normal.y < 0)
				{
					o = tex2D(_GroundTex, i.uv * _GroundTex_ST.xy);
				}
				else
				{
					o = tex2D(_MainTex, i.uv * _MainTex_ST.xy);
				}
				return o;
			}

			ENDCG
		}
	}

	Fallback "Diffuse"
}
