namespace buEyeBaseVer5.Apps;

public enum DrillCNCMode
{
	Fast = 0,
	Plunge = 1,
	Z1NoOffset = 2,
	Z2NoOffset = 3,
	Z3NoOffset = 4,
	Z1_Z2NoOffset = 5,
	Z1_Z3NoOffset = 6,
	Z2_Z3NoOffset = 7,
	Z1_Z2_Z3NoOffset = 8,
	Cut = 9,
	Safe = 10,
	SafeRapid = 11,
	ToolOffset = 12,
	ToolSet = 13,
	ToolReset = 14,
	PressPistonReset = 15,
	X1ClamperMove = 16,
	X2ClamperMove = 17,
	ToolOffsetGCode = 18,
	None = 1000
}
