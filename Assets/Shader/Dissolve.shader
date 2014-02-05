Shader "Custom Shaders/Dissolve" {
    Properties {
      _MainTex ("Texture (RGB)", 2D) = "white" {}
      _SliceGuide ("Slice Guide (RGB)", 2D) = "white" {}
      _SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.5
      _AshesWidth ("Ashes Width", Range(0.0, 1.0)) = 0.5
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
          float2 uv_SliceGuide;
          float _SliceAmount;
      };
      sampler2D _MainTex;
      sampler2D _SliceGuide;
      float _SliceAmount;
      float _AshesWidth;
      void surf (Input IN, inout SurfaceOutput o) {
      
      		float clipValue = tex2D (_SliceGuide, IN.uv_SliceGuide).a - _SliceAmount;
      		
      		
      		
          clip(clipValue);
          
          float4 col = tex2D (_MainTex, IN.uv_MainTex);
          
          if( clipValue < _AshesWidth )
          	o.Emission = lerp( float3(1.0, 0.0, 0.0), col.rgb, clipValue);
          else     
          	o.Emission = col.rgb;
          	
          o.Alpha = col.a;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }