Shader "Unlit/FurShader"
{
	Properties
	{	
		_MainTex("Texture", 2D) = "white" {}
		_MaskTex("Texture", 2D) = "white" {}
		_Length("Length", Float) = 1.0
		_LayerCount("Layer Count",Int) = 10
		_LocalVelocity("Local Velocity",Vector) = (0,0,0,0)
		_Gravity("Gravity", Vector) = (0, 0, 0, 0)
		_GravityPow("GravityPow", Float) = 1.0
		_WindVelocity("WindVelocity", Vector) = (0, 0, 0, 0)
	}
	SubShader
	{

		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				FSInput o;
				o.position = mul(UNITY_MATRIX_MVP, i.position);
				o.uv = i.uv;
				return o;
			}

			float4 frag(FSInput i) : SV_Target
			{
				float4 o = tex2D(_MainTex,i.uv);
				return o;
			}
			ENDCG
		}
		Pass //1
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,1);
			}
			ENDCG
		}

		Pass //2
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,2);
			}
			ENDCG
		}

		Pass //3
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,3);
			}
			ENDCG
		}

		Pass //4
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,4);
			}
			ENDCG
		}

		Pass //5
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i, 5);
			}
			ENDCG
		}

		Pass //6
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,6);
			}
			ENDCG
		}

		Pass //7
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,7);
			}
			ENDCG
		}


		Pass //8
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,8);
			}
			ENDCG
		}

		Pass //9
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,9);
			}
			ENDCG
		}

		Pass //10
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,10);
			}
			ENDCG
		}

		Pass //11
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,11);
			}
			ENDCG
		}

		Pass //12
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,12);
			}
			ENDCG
		}

		Pass //13
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,13);
			}
			ENDCG
		}

		Pass //14
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,14);
			}
			ENDCG
		}

		Pass //15
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,15);
			}
			ENDCG
		}

		Pass //16
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,16);
			}
			ENDCG
		}

		Pass //17
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,17);
			}
			ENDCG
		}

		Pass //18
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,18);
			}
			ENDCG
		}

		Pass //19
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,19);
			}
			ENDCG
		}

		Pass //20
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment FS
			#include "FurMethods.cginc"
			FSInput vert(VSInput i)
			{
				return VS(i,20);
			}
			ENDCG
		}

	}
}

