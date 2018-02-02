// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Position"
{
	Properties
	{
		_BlendColor("BlendColor", Color) = (0.8299189,1,0.05147058,0)
		_Postion2("Postion2", Float) = 0
		_Position("Position", Float) = 0
		_BottomColor("BottomColor", Color) = (0.05882353,0.25,0.1496324,0)
		_TopColor("Top Color", Color) = (0.1812966,0.7132353,0.01048876,0)
		_ColorIntensity("ColorIntensity", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float3 worldPos;
		};

		uniform float4 _BottomColor;
		uniform float4 _TopColor;
		uniform float _Position;
		uniform float4 _BlendColor;
		uniform float _Postion2;
		uniform float _ColorIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float4 lerpResult5 = lerp( _BottomColor , _TopColor , ( ( ase_worldPos.y * _Position ) / 10000.0 ));
			float4 lerpResult18 = lerp( lerpResult5 , _BlendColor , ( ( ase_worldPos.y * _Postion2 ) / 10000.0 ));
			o.Albedo = ( lerpResult18 * ( _ColorIntensity * 0.01 ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14001
650;391;1191;730;2224.775;762.6243;2.574249;True;True
Node;AmplifyShaderEditor.WorldPosInputsNode;6;-1544.749,-76.76983;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;8;-1550.719,95.53178;Float;False;Property;_Position;Position;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;15;-1544.101,213.6944;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;14;-1550.071,385.996;Float;False;Property;_Postion2;Postion2;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-1330.894,-46.55315;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;11;-1209.807,-304.3949;Float;False;Property;_BottomColor;BottomColor;0;0;0.05882353,0.25,0.1496324,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;3;-1214.738,-481.0556;Float;False;Property;_TopColor;Top Color;0;0;0.1812966,0.7132353,0.01048876,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-1330.246,243.9111;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;10;-1117.646,-128.5052;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;10000.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-678.1346,66.33696;Float;False;Property;_ColorIntensity;ColorIntensity;1;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;17;-1125.064,225.0235;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;10000.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;20;-1199.02,-34.07382;Float;False;Property;_BlendColor;BlendColor;0;0;0.8299189,1,0.05147058,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;5;-803.2963,-314.4775;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;2;FLOAT;0.0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-396.5076,50.1037;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;18;-621.4853,-140.1967;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-281.6899,-210.0135;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-5.845097,-213.0798;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Position;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;7;0;6;2
WireConnection;7;1;8;0
WireConnection;16;0;15;2
WireConnection;16;1;14;0
WireConnection;10;0;7;0
WireConnection;17;0;16;0
WireConnection;5;0;11;0
WireConnection;5;1;3;0
WireConnection;5;2;10;0
WireConnection;21;0;13;0
WireConnection;18;0;5;0
WireConnection;18;1;20;0
WireConnection;18;2;17;0
WireConnection;12;0;18;0
WireConnection;12;1;21;0
WireConnection;0;0;12;0
ASEEND*/
//CHKSM=C318ACFB38840C0A042178781A6B10A55036A2D7