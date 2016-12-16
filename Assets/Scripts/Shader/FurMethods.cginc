// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

#include "UnityCG.cginc"

float3 _Gravity;
float3 _WindVelocity;
float3 _LocalVelocity;
sampler2D _MainTex;
sampler2D _MaskTex;
float4 _MaskTex_ST;
float _Length;
float _LayerCount;
float _GravityPow;
struct VSInput
{
	float4 position : POSITION;
	float3 normal : NORMAL;
	float2 uv : TEXCOORD0;
};

struct FSInput
{
	float4 position : POSITION;
	float2 uv : TEXCOORD0;
};

float4 GetPosition(float4 originPos, float3 normal, float step, float layerCount, float length)
{
	float layerRate = step / layerCount;
	float powRate = pow(layerRate, _GravityPow);
	float3 p = originPos.xyz;
	float3 g = _Gravity.xyz;
	float3 n = normalize(normal) * length * layerRate;
	float3 w = _WindVelocity * powRate;
	float3 l = _LocalVelocity * powRate;
	p += n;
	p += g * powRate;
	p += w;
	p -= l;
	return float4(p,1);

	//float layerRate = step / layerCount;
	//float4 worldVertexPos = mul(unity_ObjectToWorld, originPos);
	//float4 worldNormal = mul(unity_ObjectToWorld, normal);
	//float4 worldGravity = float4(_Gravity.xyz, 0) * pow(layerRate, _GravityPow);
	//float3 windVelocity = _WindVelocity * pow(layerRate, _GravityPow);
	//float3 localVelocity = _LocalVelocity * pow(layerRate, _GravityPow);
	//
	//worldVertexPos += worldNormal * layerRate;
	//worldVertexPos += worldGravity;
	//return worldVertexPos;
}

float4 FS(FSInput i) : SV_Target
{
	float4 o;
	float4 albedo = tex2D(_MainTex, i.uv);
	float4 maskAlpha = tex2D(_MaskTex, i.uv * _MaskTex_ST.xy);
	o = albedo;
	o.a = maskAlpha.a;
	return o;
}

FSInput VS(VSInput i, float step)
{
	FSInput o;
	o.uv = i.uv;
	o.position = GetPosition(i.position, i.normal, step, _LayerCount, _Length);
	o.position = mul(UNITY_MATRIX_MVP, o.position);
	return o;
}
	
