// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "PositionGround"
{
	Properties
	{
		_Color0("Color 0", Color) = (0.05882353,0.25,0.1496324,0)
		_Color1("Color 1", Color) = (0.1812966,0.7132353,0.01048876,0)
		_PositionZ("PositionZ", Float) = 0
		_BottomColor("BottomColor", Color) = (0.05882353,0.25,0.1496324,0)
		_TopColor("Top Color", Color) = (0.1812966,0.7132353,0.01048876,0)
		_PositionY("PositionY", Float) = 0
		_ColorIntensity("ColorIntensity", Float) = 0
		_Blend("Blend", Float) = 0
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
		uniform float _PositionY;
		uniform float4 _Color0;
		uniform float4 _Color1;
		uniform float _PositionZ;
		uniform float _Blend;
		uniform float _ColorIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float4 lerpResult5 = lerp( _BottomColor , _TopColor , ( ( ase_worldPos.y * ( _PositionY * 0.01 ) ) * 0.001 ));
			float4 lerpResult30 = lerp( _Color0 , _Color1 , ( ( ase_worldPos.z * ( _PositionZ * 0.01 ) ) * 0.001 ));
			float4 lerpResult18 = lerp( lerpResult5 , lerpResult30 , ( _Blend * 0.0001 ));
			o.Albedo = ( lerpResult18 * _ColorIntensity ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14001
7;114;1352;607;3323.904;810.4929;2.875859;True;True
Node;AmplifyShaderEditor.RangedFloatNode;25;-2245.946,15.15578;Float;False;Property;_PositionY;PositionY;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-2237.09,124.5942;Float;False;Property;_PositionZ;PositionZ;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;-2023.261,122.4972;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-2016.762,-8.802789;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;6;-2114.95,-236.5699;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-1830.075,33.76927;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;-1838.511,-126.008;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;11;-1209.807,-304.3949;Float;False;Property;_BottomColor;BottomColor;0;0;0.05882353,0.25,0.1496324,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;31;-1031.264,-11.20737;Float;False;Property;_Blend;Blend;8;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;3;-1214.738,-481.0556;Float;False;Property;_TopColor;Top Color;0;0;0.1812966,0.7132353,0.01048876,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-1212.568,-115.0235;Float;False;2;2;0;FLOAT;0,0,0;False;1;FLOAT;0.001;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-1256.998,589.7927;Float;False;2;2;0;FLOAT;0,0,0;False;1;FLOAT;0.001;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;28;-1266.885,384.691;Float;False;Property;_Color0;Color 0;0;0;0.05882353,0.25,0.1496324,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;29;-1246.138,190.9118;Float;False;Property;_Color1;Color 1;0;0;0.1812966,0.7132353,0.01048876,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;5;-803.2963,-314.4775;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;2;FLOAT;0.0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;30;-917.4367,405.9923;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;2;FLOAT;0.0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-789.5925,-38.97214;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0001;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-376.0191,8.67988;Float;False;Property;_ColorIntensity;ColorIntensity;1;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;18;-573.9245,-170.3636;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-281.6899,-210.0135;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;68.80813,-63.77339;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;PositionGround;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;34;0;8;0
WireConnection;33;0;25;0
WireConnection;7;0;6;3
WireConnection;7;1;34;0
WireConnection;26;0;6;2
WireConnection;26;1;33;0
WireConnection;22;0;26;0
WireConnection;27;0;7;0
WireConnection;5;0;11;0
WireConnection;5;1;3;0
WireConnection;5;2;22;0
WireConnection;30;0;28;0
WireConnection;30;1;29;0
WireConnection;30;2;27;0
WireConnection;32;0;31;0
WireConnection;18;0;5;0
WireConnection;18;1;30;0
WireConnection;18;2;32;0
WireConnection;12;0;18;0
WireConnection;12;1;13;0
WireConnection;0;0;12;0
ASEEND*/
//CHKSM=16005D070234DE27EE94DF764B48828A08805BA9