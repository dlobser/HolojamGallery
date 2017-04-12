Shader "Custom/cgToon" {

    Properties 
    {
        _Color ("Color", Color) = (1,1,1,1)
        _DarkColor ("DarkColor", Color) = (1,1,1,1)
		_Tile ("Tiling", Float) = 12
		_MainTile("MainTile",Vector) = (1,1,1,1)

		
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_CrossTex1("Sketch Darkest (RGB)", 2D) = "white" {}
		_CrossTex2("Sketch (RGB)", 2D) = "white" {}
		_CrossTex3("Sketch (RGB)", 2D) = "white" {}
		_CrossTex4("Sketch (RGB)", 2D) = "white" {}
		
    }
    SubShader 
    {
    
        Tags {"Queue" = "Geometry" "RenderType" = "Opaque"}
        Pass 
        {
            Tags {"LightMode" = "ForwardBase"}                      // This Pass tag is important or Unity may not give it the correct light information.
           		CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fwdbase                       // This line tells Unity to compile this pass for forward base.
                
                #include "UnityCG.cginc"
                
               	struct vertex_input
               	{
               		float4 vertex : POSITION;
               		float3 normal : NORMAL;
               		float2 texcoord : TEXCOORD0;
               		
//               		float2 uv_MainTex;
               		
               	};
                
                struct vertex_output
                {
                    float4  pos         : SV_POSITION;
                    float2  uv          : TEXCOORD0;
                    float3  lightDir    : TEXCOORD1;
                    float3  normal		: TEXCOORD2;

                };
                
                sampler2D _MainTex;
				sampler2D _CrossTex1;
				sampler2D _CrossTex2;
				sampler2D _CrossTex3;
				sampler2D _CrossTex4;
				
                fixed4 _Color;
                fixed4 _LightColor0; 
                
				fixed4 _DarkColor;
				fixed4 _MultColor;
				float _Tile;
   				float4 _MainTile;
              
                vertex_output vert (vertex_input v)
                {
                    vertex_output o;
                    o.pos = mul( UNITY_MATRIX_MVP, v.vertex);
                    o.uv = v.texcoord.xy;
                    
                    return o;
                }
                
                fixed4 frag(vertex_output i) : COLOR
                {
                  	float2 nUV = i.uv*_Tile;
		         	fixed4 Main = tex2D(_MainTex, (i.uv*_MainTile.xy)+_MainTile.zw);
		 			fixed4 CR1 = tex2D(_CrossTex1, nUV); CR1.a = CR1.r;
					fixed4 CR2 = tex2D(_CrossTex2, nUV); CR2.a = CR2.r;
					fixed4 CR3 = tex2D(_CrossTex3, nUV); CR3.a = CR3.r;
					fixed4 CR4 = tex2D(_CrossTex4, nUV); CR4.a = CR4.r;
					
					fixed4 emit =  lerp(fixed4(0,0,0,0),
								   lerp(CR1,
								   lerp(CR2,
								   lerp(CR3,
								   lerp(CR4, fixed4(1,1,1,1), 
								   		clamp((2.*_Color.a*(_Color.a*Main.r)-0.75)*10.0, 0.0, 1.0)),
								   		clamp((2.*_Color.a*(_Color.a*Main.r)-0.6)*10.0, 0.0, 1.0)),
								   		clamp((2.*_Color.a*(_Color.a*Main.r)-0.45)*10.0, 0.0, 1.0)),
								   		clamp((2.*_Color.a*(_Color.a*Main.r)-0.3)*10.0, 0.0, 1.0)),
								   		clamp((2.*_Color.a*(_Color.a*Main.r)-0.15)*10.0, 0.0, 1.0));
								   		

					fixed4 L = lerp(_DarkColor,_Color,emit.a); 		
		            return  L;
					
                }
            ENDCG
        }
    }
    FallBack "VertexLit"   
}
 