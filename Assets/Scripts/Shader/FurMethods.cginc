#include "UnityCG.cginc"

float3 _Gravity;
float3 _WindVelocity;
float3 _LocalVelocity;
sampler2D _MainTex;
sampler2D _MaskTex;
float4 _MaskTex_ST;
float _Length;
float _LayerCount;
float _step;

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
	float4 worldVertexPos = mul(UNITY_MATRIX_M, originPos);
	float4 worldNormal = mul(UNITY_MATRIX_M, normal);
	float4 worldGravity = mul(UNITY_MATRIX_M, _Gravity);
	float3 temp = worldVertexPos.xyz + normal *length * step / layerCount;
	float3 delta = _Gravity + _WindVelocity - _LocalVelocity;
	//delta = normalize(delta);
	delta = delta * step / layerCount;
	temp += delta;
	float4 o = float4(temp, originPos.w);
	return o;
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
	o.position = mul(UNITY_MATRIX_VP, o.position);
	_step++;
	return o;
}
	
