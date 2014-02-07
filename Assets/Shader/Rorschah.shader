Shader "Custom Shaders/Rorschach" {
    Properties {
      _MainColor ("Color", Color) = (1.0,1.0,1.0,1.0)
    	
      _MainTex ("Texture", 2D) = "white" {}
      _AlphaMask ("Alpha Mask", 2D) = "white" {}
 
      _SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.5
      _SliceWidth ("Slice Width", Range(0.0, 1.0)) = 0.2
      _MirrorValue ("Mirror Value", Range(0.0, 1.0)) = 0.5
    }
    SubShader {
      Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
      Blend SrcAlpha OneMinusSrcAlpha
      ZWrite Off
      Cull Off
      
      CGPROGRAM

      #pragma surface surf Lambert 
      struct Input {
          float2 uv_MainTex;
      };
      
      float4 _MainColor;
      sampler2D _MainTex;
      sampler2D _AlphaMask;

      float _SliceAmount;
      float _SliceWidth;
      float _MirrorValue;

      void surf (Input IN, inout SurfaceOutput o) {
      
      	float2 uv = IN.uv_MainTex;
      	if( uv.x > _MirrorValue )
      		uv.x = 2 * _MirrorValue - uv.x;
      	
      	float texValue = tex2D( _MainTex, uv ).a;
		if( texValue > _SliceAmount + _SliceWidth * 0.5 || texValue < _SliceAmount - _SliceWidth * 0.5 )
			discard;
			
		float alphaMask = tex2D( _AlphaMask, IN.uv_MainTex ).a;
		
		o.Emission = _MainColor.rgb;
		o.Alpha = _MainColor.a * alphaMask;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }