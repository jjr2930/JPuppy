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
		_WindVelocity("WindVelocity", Vector) = (0, 0, 0, 0)
	}
	SubShader
	{

		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
		LOD 100

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
				_step = 3;
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
				_step = 4;
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
				_step = 5;
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
				_step = 6;
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
				_step = 7;
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
				_step = 8;
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
				_step = 9;
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
				_step = 10;
				return VS(i,10);
			}
			ENDCG
		}

	}
}

