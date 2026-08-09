using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum OdPrcMarkup_MarkupSubType
{
	kUnknownSubtype = 0,
	kEnumMax = 1,
	kDatum_Ident = 1,
	kDatum_Target = 2,
	kDatum_EnumMax = 3,
	kDimension_Distance = 1,
	kDimension_Distance_Offset = 2,
	kDimension_Distance_Cumulate = 3,
	kDimension_Chamfer = 4,
	kDimension_Slope = 5,
	kDimension_Ordinate = 6,
	kDimension_Radius = 7,
	kDimension_Radius_Tangent = 8,
	kDimension_Radius_Cylinder = 9,
	kDimension_Radius_Edge = 0xA,
	kDimension_Diameter = 0xB,
	kDimension_Diameter_Tangent = 0xC,
	kDimension_Diameter_Cylinder = 0xD,
	kDimension_Diameter_Edge = 0xE,
	kDimension_Diameter_Cone = 0xF,
	kDimension_Length = 0x10,
	kDimension_Length_Curvilinear = 0x11,
	kDimension_Length_Circular = 0x12,
	kDimension_Angle = 0x13,
	kDimension_EnumMax = 0x14,
	kGdt_Fcf = 1,
	kGdt_EnumMax = 2,
	kWelding_Line = 1,
	kWelding_Spot = 2,
	kWelding_EnumMax = 3,
	kOther_Symbol_User = 4,
	kOther_Symbol_Utility = 2,
	kOther_Symbol_Custom = 3,
	kOther_GeometricReference = 4,
	kOther_EnumMax = 5
}
