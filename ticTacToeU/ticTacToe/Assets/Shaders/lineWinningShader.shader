Shader "Custom/lineWinningShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		//whatever name this starts out with i.e. _MainTex has to match the variable in the Input struct, just with a uv_ in front of it 
		//its a uv_ because this is a texture, if I had another one I wanted to use as well I would need to name it something like _otherTex and have it set in Input as uv2_otherTex
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;

			struct Input {
				float3 viewDir;// -contains view direction, for computing Parallax effects, rim lighting etc

				//float4 COLOR //semantic - contains interpolated per - vertex color.
				//float4 screenPos; // -contains screen space position for reflection or screenspace effects.Note that this is not suitable for GrabPass; you need to compute custom UV yourself using ComputeGrabScreenPos function.
				//float3 worldPos; // -contains world space position.
				//float3 worldRefl; // -contains world reflection vector if surface shader does not write to o.Normal.See Reflect - Diffuse shader for example.
				//float3 worldNormal; // -contains world normal vector if surface shader does not write to o.Normal.
				//float3 worldRefl; //INTERNAL_DATA - contains world reflection vector if surface shader writes to o.Normal.To get the reflection vector based on per - pixel normal map, use WorldReflectionVector(IN, o.Normal).See Reflect - Bumped shader for example.
				//float3 worldNormal; //INTERNAL_DATA - contains world normal vector if surface shader writes to o.Normal.To get the normal vector based on per - pixel normal map, use WorldNormalVector(IN, o.Normal).
				float2 uv_MainTex;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_CBUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_CBUFFER_END

			void surf(Input IN, inout SurfaceOutputStandard o) {
				
				// Albedo comes from a texture tinted by color
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				//these fixed4 float4 variables act as arrays so I can either use a subscript on them or access the rgba values directly, I can choose
				o.Alpha = c[3];
			}
			ENDCG
		}
			FallBack "Diffuse"
}
