Shader "Custom Shaders/Snow" {
    Properties {
      _MainTex ("Texture (RGB)", 2D) = "white" {}
      _SliceGuide ("Slice Guide (RGB)", 2D) = "white" {}
      
      _SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.5
//      _AshesWidth ("Ashes Width", Range(0.0, 1.0)) = 0.5
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
//      float _AshesWidth;
      void surf (Input IN, inout SurfaceOutput o) {
      
      	float clipValue = tex2D (_SliceGuide, IN.uv_SliceGuide).a - _SliceAmount;
          
 
          
//          if( clipValue < _AshesWidth )
//          	o.Emission = lerp( float3(1.0, 0.0, 0.0), col.rgb, clipValue);
//          else     
          	
          	
//          	float noiseValue = tex2D (_SliceGuide, IN.uv_SliceGuide).a;
         
          	float4 textCol = tex2D (_MainTex, IN.uv_MainTex); 
          	 	
          	if( clipValue > 0.0 )
          	{
          		
          		o.Emission = textCol.rgb;
//          		o.Alpha = textCol.a;
          	}
          	else
          	{
          		o.Emission = 1.0;
//          		o.Alpha = 1.0;
          	}
          	
          	o.Alpha = textCol.a;
          		
          	
	
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }