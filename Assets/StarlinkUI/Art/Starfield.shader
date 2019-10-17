// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "SG/Starfield"
{
Properties
{
	_NebulaColor ("Nebula Color", Color) = (0.5,0.5,0.5,0.5)
	_ShockwaveColor ("Shockwave Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Star Texture", 2D) = "white" {}
	_NebulaTex ("Nebula Texture", 2D) = "black" {}
	_ShockwaveTex ("Shockwave Texture", 2D) = "black" {}
}

Category
{
	Tags
	{
		"Queue"="Background"
		"IgnoreProjector"="True"
		"RenderType"="Opaque"
	}
	Blend Off
	ColorMask RGB
	Cull Off
	Lighting Off
	ZWrite Off
	Fog { Color (0,0,0,0) }
	BindChannels
	{
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}
	
	// ---- Fragment program abilities
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _NebulaTex;
			sampler2D _ShockwaveTex;
			
			fixed4 _NebulaColor;
			fixed4 _ShockwaveColor;
			
			struct appdata_t
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float2 uv2 : TEXCOORD2;
			};
			
			float4 _MainTex_ST;
			float4 _NebulaTex_ST;
			float4 _ShockwaveTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.uv0 = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv1 = TRANSFORM_TEX(v.texcoord, _NebulaTex);
				o.uv2 = TRANSFORM_TEX(v.texcoord, _ShockwaveTex);
				return o;
			}

			half4 frag (v2f i) : COLOR
			{
				return tex2D(_MainTex, i.uv0) +
					tex2D(_NebulaTex, i.uv1) * _NebulaColor +
					tex2D(_ShockwaveTex, i.uv2) * _ShockwaveColor;
			}
			ENDCG 
		}
	} 	
	
	// ---- Dual texture abilities
	SubShader
	{
		Pass
		{
			SetTexture [_MainTex]
			{
				constantColor [_TintColor]
				combine constant * primary
			}
			SetTexture [_MainTex]
			{
				combine texture * previous DOUBLE
			}
		}
	}

	// ---- Single texture abilities (does not do color tint)
	SubShader
	{
		Pass
		{
			SetTexture [_MainTex]
			{
				combine texture * primary
			}
		}
	}
}
}
