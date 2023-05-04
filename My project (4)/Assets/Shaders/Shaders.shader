Shader "Unlit/Shaders"
{
	Properties
	{
		_ColorA("ColorA", Color) = (1,1,1,1)
		_ColorB("ColorB", Color) = (1,1,1,1)
		_ColorStart("Color Start", range(0,1)) = 0
		_ColorEnd("Color End", range(0,1)) = 1
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#define TAU 6.2831855

			float4 _ColorA;
			float4 _ColorB;
			float _ColorStart;
			float _ColorEnd;

			struct MeshData
			{
				float4 vertex : POSITION;
				float3 normals : NORMAL;
				float2 uv0 : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 normal : TEXCOORD0;
				float2 uv :TEXCOORD1;
			};

			v2f vert(MeshData v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = UnityObjectToWorldNormal(v.normals);
				o.uv = v.uv0; //passthrough
				return o;
			}
			float InverseLerp(float a, float b, float v)
			{
				return (v - a) / (b - a);
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float xOffset = i.uv.y;
			
				float t = cos(i.uv.x * TAU * 5) * 0.5f +0.5f;
			return t;

			}
			ENDCG
		}
	}
}
