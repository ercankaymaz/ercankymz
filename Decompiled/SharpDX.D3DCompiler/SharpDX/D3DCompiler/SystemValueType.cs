namespace SharpDX.D3DCompiler;

public enum SystemValueType
{
	Undefined = 0,
	Position = 1,
	ClipDistance = 2,
	CullDistance = 3,
	RenderTargetArrayIndex = 4,
	ViewportArrayIndex = 5,
	VertexId = 6,
	PrimitiveId = 7,
	InstanceId = 8,
	IsFrontFace = 9,
	SampleIndex = 10,
	FinalQuadEdgeTessfactor = 11,
	FinalQuadInsideTessfactor = 12,
	FinalTriEdgeTessfactor = 13,
	FinalTriInsideTessfactor = 14,
	FinalLineDetailTessfactor = 15,
	FinalLineDensityTessfactor = 16,
	Barycentrics = 23,
	Target = 64,
	Depth = 65,
	Coverage = 66,
	DepthGreaterEqual = 67,
	DepthLessEqual = 68,
	StencilRef = 69,
	InnerCoverage = 70
}
