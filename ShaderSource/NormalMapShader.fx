﻿#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

// Matrix
float4x4 World;
float4x4 View;
float4x4 Projection;

// Light related
float4 AmbientColor;
float AmbientIntensity;

float3 LightDirection;
float4 DiffuseColor;
float DiffuseIntensity;

float4 SpecularColor;
float SpecularPower;
float3 EyePosition;
//
//float DebugBlend_Normal;
//float DebugBlend_Normal_ColorStart;
//float DebugBlend_Normal_ColorScale;
//
//float DebugBlend_NormalAsVertexColor;

//Default 2
float DEBUG_ValueA;

float NormalMapCustomZ;

texture2D ColorMap;
sampler2D ColorMapSampler = sampler_state
{
	Texture = <ColorMap>;
	MinFilter = linear;
	MagFilter = linear;
	MipFilter = linear;
};

texture2D NormalMap;
sampler2D NormalMapSampler = sampler_state
{
	Texture = <NormalMap>;
	MinFilter = linear;
	MagFilter = linear;
	MipFilter = linear;
};

texture2D SpecularMap;
sampler2D SpecularMapSampler = sampler_state
{
	Texture = <SpecularMap>;
	MinFilter = linear;
	MagFilter = linear;
	MipFilter = linear;
};

// The input for the VertexShader
struct VertexShaderInput
{
    float4 Position : POSITION0;
	float2 TexCoord : TEXCOORD0;
	float3 Normal : NORMAL0;
	float3 Binormal : BINORMAL0;
	float3 Tangent : TANGENT0;
};

// The output from the vertex shader, used for later processing
struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 TexCoord : TEXCOORD0;
	float3 View : TEXCOORD1;
	float3x3 WorldToTangentSpace : TEXCOORD2;
	float3 Normal : NORMAL0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output;

    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);
	output.TexCoord = input.TexCoord;

	output.WorldToTangentSpace[0] = mul(normalize(input.Tangent), World);
	output.WorldToTangentSpace[1] = mul(normalize(input.Binormal), World);
	output.WorldToTangentSpace[2] = mul(normalize(input.Normal), World);
	
	output.View = normalize(float4(EyePosition,1.0) - worldPosition);

	output.Normal = input.Normal;

    return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 color = tex2D(ColorMapSampler, input.TexCoord);
    
	//color = color * float4(color.w, color.w, color.w, 1);

    float3 nmapcol = tex2D(NormalMapSampler, input.TexCoord);
    
	//Ignore the Z of the normal map to be accurate to the game.
	nmapcol = float3(nmapcol.x, nmapcol.y, NormalMapCustomZ);

    //nmapcol.x = -nmapcol.x;
    
	float3 normalMap = 2.0 *(nmapcol)-1.0;

	normalMap = normalize(mul(normalMap, input.WorldToTangentSpace));
	float4 normal = float4(normalMap,1.0);

	//float4 debugNormalColor = float4(
	//	(normal.x * DebugBlend_Normal_ColorScale) + DebugBlend_Normal_ColorStart,
	//	(normal.y * DebugBlend_Normal_ColorScale) + DebugBlend_Normal_ColorStart,
	//	(normal.z * DebugBlend_Normal_ColorScale) + DebugBlend_Normal_ColorStart,
	//	1
	//	);

	float4 diffuse = saturate(dot(-LightDirection,normal));
	float4 reflect = normalize(2*diffuse*normal-float4(LightDirection,1.0));
	float4 specular = pow(saturate(dot(reflect,input.View)),SpecularPower);

    float4 outputColor =  color * AmbientColor * AmbientIntensity + 
			color * DiffuseIntensity * DiffuseColor * diffuse + 
			color * tex2D(SpecularMapSampler, input.TexCoord) * specular;

	outputColor = float4(outputColor.xyz * color.w, color.w);

	return outputColor;

	//float4 outputAndDbgNorm = lerp(outputColor, debugNormalColor, float4(DebugBlend_Normal, DebugBlend_Normal, DebugBlend_Normal, DebugBlend_Normal));

	//float4 dbgNormAsVertColor = saturate(float4(input.Normal.x, input.Normal.y, input.Normal.z, 1));

	//return lerp(outputAndDbgNorm, dbgNormAsVertColor,
	//	float4(DebugBlend_NormalAsVertexColor, DebugBlend_NormalAsVertexColor, DebugBlend_NormalAsVertexColor, DebugBlend_NormalAsVertexColor)
	//		);
}

technique BasicColorDrawing
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};

