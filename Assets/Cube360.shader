Shader "Custom/Cube360" {
	Properties {
		_Colour ("Colour", Color) = (1,0,0,1) 
		_AngleDeg("AngleDeg",float) = 180.0
		_GridWidth("Grid Width",int) = 10
		_GridHeight("Grid Height",int) = 10
		_GridX("Grid X",int) = 0
		_GridX("Grid Y",int) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            
            uniform fixed4 _Colour; 
            uniform float _AngleDeg;
            uniform int _GridWidth;
            uniform int _GridX;
            uniform int _GridY;
            
            float Interp(float Start,float End,float Time)
            {
            	return Start + ( (End - Start) * Time );
            }

			struct vertexInput {
                float4 position : POSITION;
            };

            struct fragmentInput{
                float4 position : SV_POSITION;
                float4 colour : COLOR;
            };

            fragmentInput vert(vertexInput In)  {

				fragmentInput Out;
				
                //return mul (UNITY_MATRIX_MVP, v );

              	//	object settings
            	float NearDistance = 4.0;
            	float FarDistance = 6.0;
            	float AngleStep = 360.0/(float)_GridWidth;
            	float LeftAngle = radians( (_GridX+0) * AngleStep );
            	float RightAngle = radians( (_GridX+1) * AngleStep );
            	float HeightStep = 1.0;
            	float Bottom = (_GridY+0) * HeightStep;
            	float Top = (_GridY+1) * HeightStep;
            	
            	//	gr: dimensions must be 0.5 not 1...?
            	float CubeRadius = 0.5;
            	float VertDepth = (In.position.z + CubeRadius ) / (CubeRadius*2.0);
            	float VertWidth = (In.position.x + CubeRadius ) / (CubeRadius*2.0);	
            	float VertHeight = (In.position.y + CubeRadius) / (CubeRadius*2.0);
            	
            	float VertDistance = Interp( NearDistance, FarDistance, VertDepth ); 
            	float VertAngle = Interp( LeftAngle, RightAngle, VertWidth ); 
            	float VertY = Interp( Bottom, Top, VertHeight );
            	
            	float4 WorldPos = float4( sin(VertAngle) * VertDistance, VertY, cos(VertAngle)*VertDistance, 1.0 );
            	
            	Out.position = mul (UNITY_MATRIX_MVP, WorldPos );
            	Out.colour = float4(1,0,0,0);
                return Out;
            }

            fixed4 frag(fragmentInput In) : COLOR {
                return _Colour;
            }

            ENDCG
        }
	} 
	FallBack "Diffuse"
}
