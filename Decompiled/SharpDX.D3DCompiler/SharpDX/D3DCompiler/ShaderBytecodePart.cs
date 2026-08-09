namespace SharpDX.D3DCompiler;

public enum ShaderBytecodePart
{
	InputSignatureBlob = 0,
	OutputSignatureBlob = 1,
	InputAndOutputSignatureBlob = 2,
	PatchConstantSignatureBlob = 3,
	AllSignatureBlob = 4,
	DebugInformation = 5,
	LegacyShader = 6,
	XnaPrepassShader = 7,
	XnaShader = 8,
	Pdb = 9,
	PrivateData = 10,
	RootSignature = 11,
	DebugName = 12,
	TestAlternateShader = 32768,
	TestCompileDetails = 32769,
	TestCompilePerf = 32770,
	TestCompileReport = 32771
}
