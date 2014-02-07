Shader "Custom Shaders/Color Transition" {
    Properties {
      _MainColor ("Color", Color) = (1.0,1.0,1.0,1.0)
    	
      _MainTex ("Texture", 2D) = "white" {}
      _MaskTex ("Mask Texture", 2D) = "white" {}
      
      _SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.5
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
          float _SliceAmount;
      };
      
      float4 _MainColor;
      sampler2D _MainTex;
      sampler2D _MaskTex;
      float _SliceAmount;

      void surf (Input IN, inout SurfaceOutput o) {
      
      	float clipValue = tex2D (_MaskTex, IN.uv_MainTex).a - _SliceAmount;
        float4 textCol = tex2D (_MainTex, IN.uv_MainTex); 
         	
        if( clipValue > 0.0 )
        	o.Emission = textCol.rgb;
        else
        	o.Emission = _MainColor.rgb;

        o.Alpha = textCol.a * _MainColor.a;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }