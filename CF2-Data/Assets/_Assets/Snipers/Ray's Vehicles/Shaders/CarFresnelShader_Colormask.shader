Shader "Ray's Shaders/Car Fresnel Shader with Color Mask"{
	Properties  {
		_MainColor ("Paint color", Color) = (1, 1, 1, 1 )
		_MainTex ("Diffuse texture", 2D) = "white" {}
		_ColorMask ("Color mask", 2D) = "white" {}
		_Cube ("Cube map", CUBE) = "" {}
		_RefColor ("Reflection amount", Float) = 1.5
		_SpecColor ("Specular color", Color) = (1, 1, 1, 1)
		_SpecPower ("Specular power", Float) = 0.5
		_GlossPower ("Gloss Power", Float) = 1
		_FresPower ("Fresnel Power", Float) = 1
	
	}
	Subshader {
		Tags {"RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf SimpleSpecular
		#pragma target 2.0
		
		half4 LightingSimpleSpecular (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
          half3 n = normalize (s.Normal);
          half3 h = normalize (lightDir + viewDir);
 
          half diff = max (0, dot (n, lightDir));
 
          float nh = max (0, dot (n, h));
          float spec = pow (nh, s.Specular*64);          
 
          half4 c;
          c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec * _SpecColor.rgb) * (atten * 2);
          c.a = s.Alpha;
          return c;
      }
    	
		struct Input {
			fixed2 uv_MainTex;
			fixed3 worldRefl;
			fixed3 viewDir;
			INTERNAL_DATA
		};
		
		sampler2D _MainTex;
		sampler2D _ColorMask;
		samplerCUBE _Cube;
		fixed4 _MainColor;
		float _SpecPower;
		float _RefColor;
		float _GlossPower;
		float _FresPower;
		
		void surf (Input IN, inout SurfaceOutput o) {
		
		fixed4 tex = tex2D ( _MainTex, IN.uv_MainTex);
		fixed4 colmask = tex2D ( _ColorMask, IN.uv_MainTex);
		fixed4 carpaint = (tex * _MainColor * (1-colmask)) + (tex * colmask);
		
		float4 cubetex = texCUBE (_Cube, WorldReflectionVector (IN, o.Normal));

		half rim = 1.0 - saturate (dot(normalize(IN.viewDir), normalize (o.Normal)));
		half finalrim = pow (rim, _FresPower);
		half blackrim = ((finalrim * -1) + 0.9);
	
						
		o.Albedo = carpaint.rgb;
		o.Specular = _SpecPower;
		o.Gloss = tex.a * _GlossPower;
		o.Emission = (cubetex.rgb * _RefColor)* tex.a * (finalrim) * (blackrim);
		
		}
		ENDCG
	}
	Fallback "Diffuse"
}