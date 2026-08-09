using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

public struct ShaderDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public int Version;

		public IntPtr Creator;

		public ShaderFlags Flags;

		public int ConstantBuffers;

		public int BoundResources;

		public int InputParameters;

		public int OutputParameters;

		public int InstructionCount;

		public int TempRegisterCount;

		public int TempArrayCount;

		public int DefineCount;

		public int DeclarationCount;

		public int TextureNormalInstructions;

		public int TextureLoadInstructions;

		public int TextureCompInstructions;

		public int TextureBiasInstructions;

		public int TextureGradientInstructions;

		public int FloatInstructionCount;

		public int IntInstructionCount;

		public int UintInstructionCount;

		public int StaticFlowControlCount;

		public int DynamicFlowControlCount;

		public int MacroInstructionCount;

		public int ArrayInstructionCount;

		public int CutInstructionCount;

		public int EmitInstructionCount;

		public PrimitiveTopology GeometryShaderOutputTopology;

		public int GeometryShaderMaxOutputVertexCount;

		public InputPrimitive InputPrimitive;

		public int PatchConstantParameters;

		public int GeometryShaderInstanceCount;

		public int ControlPoints;

		public TessellatorOutputPrimitive HullShaderOutputPrimitive;

		public TessellatorPartitioning HullShaderPartitioning;

		public TessellatorDomain TessellatorDomain;

		public int BarrierInstructions;

		public int InterlockedInstructions;

		public int TextureStoreInstructions;
	}

	public int Version;

	public string Creator;

	public ShaderFlags Flags;

	public int ConstantBuffers;

	public int BoundResources;

	public int InputParameters;

	public int OutputParameters;

	public int InstructionCount;

	public int TempRegisterCount;

	public int TempArrayCount;

	public int DefineCount;

	public int DeclarationCount;

	public int TextureNormalInstructions;

	public int TextureLoadInstructions;

	public int TextureCompInstructions;

	public int TextureBiasInstructions;

	public int TextureGradientInstructions;

	public int FloatInstructionCount;

	public int IntInstructionCount;

	public int UintInstructionCount;

	public int StaticFlowControlCount;

	public int DynamicFlowControlCount;

	public int MacroInstructionCount;

	public int ArrayInstructionCount;

	public int CutInstructionCount;

	public int EmitInstructionCount;

	public PrimitiveTopology GeometryShaderOutputTopology;

	public int GeometryShaderMaxOutputVertexCount;

	public InputPrimitive InputPrimitive;

	public int PatchConstantParameters;

	public int GeometryShaderInstanceCount;

	public int ControlPoints;

	public TessellatorOutputPrimitive HullShaderOutputPrimitive;

	public TessellatorPartitioning HullShaderPartitioning;

	public TessellatorDomain TessellatorDomain;

	public int BarrierInstructions;

	public int InterlockedInstructions;

	public int TextureStoreInstructions;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Creator);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Version = @ref.Version;
		Creator = Marshal.PtrToStringAnsi(@ref.Creator);
		Flags = @ref.Flags;
		ConstantBuffers = @ref.ConstantBuffers;
		BoundResources = @ref.BoundResources;
		InputParameters = @ref.InputParameters;
		OutputParameters = @ref.OutputParameters;
		InstructionCount = @ref.InstructionCount;
		TempRegisterCount = @ref.TempRegisterCount;
		TempArrayCount = @ref.TempArrayCount;
		DefineCount = @ref.DefineCount;
		DeclarationCount = @ref.DeclarationCount;
		TextureNormalInstructions = @ref.TextureNormalInstructions;
		TextureLoadInstructions = @ref.TextureLoadInstructions;
		TextureCompInstructions = @ref.TextureCompInstructions;
		TextureBiasInstructions = @ref.TextureBiasInstructions;
		TextureGradientInstructions = @ref.TextureGradientInstructions;
		FloatInstructionCount = @ref.FloatInstructionCount;
		IntInstructionCount = @ref.IntInstructionCount;
		UintInstructionCount = @ref.UintInstructionCount;
		StaticFlowControlCount = @ref.StaticFlowControlCount;
		DynamicFlowControlCount = @ref.DynamicFlowControlCount;
		MacroInstructionCount = @ref.MacroInstructionCount;
		ArrayInstructionCount = @ref.ArrayInstructionCount;
		CutInstructionCount = @ref.CutInstructionCount;
		EmitInstructionCount = @ref.EmitInstructionCount;
		GeometryShaderOutputTopology = @ref.GeometryShaderOutputTopology;
		GeometryShaderMaxOutputVertexCount = @ref.GeometryShaderMaxOutputVertexCount;
		InputPrimitive = @ref.InputPrimitive;
		PatchConstantParameters = @ref.PatchConstantParameters;
		GeometryShaderInstanceCount = @ref.GeometryShaderInstanceCount;
		ControlPoints = @ref.ControlPoints;
		HullShaderOutputPrimitive = @ref.HullShaderOutputPrimitive;
		HullShaderPartitioning = @ref.HullShaderPartitioning;
		TessellatorDomain = @ref.TessellatorDomain;
		BarrierInstructions = @ref.BarrierInstructions;
		InterlockedInstructions = @ref.InterlockedInstructions;
		TextureStoreInstructions = @ref.TextureStoreInstructions;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Version = Version;
		@ref.Creator = Marshal.StringToHGlobalAnsi(Creator);
		@ref.Flags = Flags;
		@ref.ConstantBuffers = ConstantBuffers;
		@ref.BoundResources = BoundResources;
		@ref.InputParameters = InputParameters;
		@ref.OutputParameters = OutputParameters;
		@ref.InstructionCount = InstructionCount;
		@ref.TempRegisterCount = TempRegisterCount;
		@ref.TempArrayCount = TempArrayCount;
		@ref.DefineCount = DefineCount;
		@ref.DeclarationCount = DeclarationCount;
		@ref.TextureNormalInstructions = TextureNormalInstructions;
		@ref.TextureLoadInstructions = TextureLoadInstructions;
		@ref.TextureCompInstructions = TextureCompInstructions;
		@ref.TextureBiasInstructions = TextureBiasInstructions;
		@ref.TextureGradientInstructions = TextureGradientInstructions;
		@ref.FloatInstructionCount = FloatInstructionCount;
		@ref.IntInstructionCount = IntInstructionCount;
		@ref.UintInstructionCount = UintInstructionCount;
		@ref.StaticFlowControlCount = StaticFlowControlCount;
		@ref.DynamicFlowControlCount = DynamicFlowControlCount;
		@ref.MacroInstructionCount = MacroInstructionCount;
		@ref.ArrayInstructionCount = ArrayInstructionCount;
		@ref.CutInstructionCount = CutInstructionCount;
		@ref.EmitInstructionCount = EmitInstructionCount;
		@ref.GeometryShaderOutputTopology = GeometryShaderOutputTopology;
		@ref.GeometryShaderMaxOutputVertexCount = GeometryShaderMaxOutputVertexCount;
		@ref.InputPrimitive = InputPrimitive;
		@ref.PatchConstantParameters = PatchConstantParameters;
		@ref.GeometryShaderInstanceCount = GeometryShaderInstanceCount;
		@ref.ControlPoints = ControlPoints;
		@ref.HullShaderOutputPrimitive = HullShaderOutputPrimitive;
		@ref.HullShaderPartitioning = HullShaderPartitioning;
		@ref.TessellatorDomain = TessellatorDomain;
		@ref.BarrierInstructions = BarrierInstructions;
		@ref.InterlockedInstructions = InterlockedInstructions;
		@ref.TextureStoreInstructions = TextureStoreInstructions;
	}
}
