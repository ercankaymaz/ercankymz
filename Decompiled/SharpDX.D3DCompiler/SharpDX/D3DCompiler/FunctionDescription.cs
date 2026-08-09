using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.D3DCompiler;

public struct FunctionDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public int Version;

		public IntPtr Creator;

		public int Flags;

		public int ConstantBuffers;

		public int BoundResources;

		public int InstructionCount;

		public int TempRegisterCount;

		public int TempArrayCount;

		public int DefCount;

		public int DclCount;

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

		public int MovInstructionCount;

		public int MovcInstructionCount;

		public int ConversionInstructionCount;

		public int BitwiseInstructionCount;

		public FeatureLevel MinFeatureLevel;

		public long RequiredFeatureFlags;

		public IntPtr Name;

		public int FunctionParameterCount;

		public RawBool HasReturn;

		public RawBool Has10Level9VertexShader;

		public RawBool Has10Level9PixelShader;
	}

	public int Version;

	public string Creator;

	public int Flags;

	public int ConstantBuffers;

	public int BoundResources;

	public int InstructionCount;

	public int TempRegisterCount;

	public int TempArrayCount;

	public int DefCount;

	public int DclCount;

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

	public int MovInstructionCount;

	public int MovcInstructionCount;

	public int ConversionInstructionCount;

	public int BitwiseInstructionCount;

	public FeatureLevel MinFeatureLevel;

	public long RequiredFeatureFlags;

	public string Name;

	public int FunctionParameterCount;

	public RawBool HasReturn;

	public RawBool Has10Level9VertexShader;

	public RawBool Has10Level9PixelShader;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Creator);
		Marshal.FreeHGlobal(@ref.Name);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Version = @ref.Version;
		Creator = Marshal.PtrToStringAnsi(@ref.Creator);
		Flags = @ref.Flags;
		ConstantBuffers = @ref.ConstantBuffers;
		BoundResources = @ref.BoundResources;
		InstructionCount = @ref.InstructionCount;
		TempRegisterCount = @ref.TempRegisterCount;
		TempArrayCount = @ref.TempArrayCount;
		DefCount = @ref.DefCount;
		DclCount = @ref.DclCount;
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
		MovInstructionCount = @ref.MovInstructionCount;
		MovcInstructionCount = @ref.MovcInstructionCount;
		ConversionInstructionCount = @ref.ConversionInstructionCount;
		BitwiseInstructionCount = @ref.BitwiseInstructionCount;
		MinFeatureLevel = @ref.MinFeatureLevel;
		RequiredFeatureFlags = @ref.RequiredFeatureFlags;
		Name = Marshal.PtrToStringAnsi(@ref.Name);
		FunctionParameterCount = @ref.FunctionParameterCount;
		HasReturn = @ref.HasReturn;
		Has10Level9VertexShader = @ref.Has10Level9VertexShader;
		Has10Level9PixelShader = @ref.Has10Level9PixelShader;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Version = Version;
		@ref.Creator = Marshal.StringToHGlobalAnsi(Creator);
		@ref.Flags = Flags;
		@ref.ConstantBuffers = ConstantBuffers;
		@ref.BoundResources = BoundResources;
		@ref.InstructionCount = InstructionCount;
		@ref.TempRegisterCount = TempRegisterCount;
		@ref.TempArrayCount = TempArrayCount;
		@ref.DefCount = DefCount;
		@ref.DclCount = DclCount;
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
		@ref.MovInstructionCount = MovInstructionCount;
		@ref.MovcInstructionCount = MovcInstructionCount;
		@ref.ConversionInstructionCount = ConversionInstructionCount;
		@ref.BitwiseInstructionCount = BitwiseInstructionCount;
		@ref.MinFeatureLevel = MinFeatureLevel;
		@ref.RequiredFeatureFlags = RequiredFeatureFlags;
		@ref.Name = Marshal.StringToHGlobalAnsi(Name);
		@ref.FunctionParameterCount = FunctionParameterCount;
		@ref.HasReturn = HasReturn;
		@ref.Has10Level9VertexShader = Has10Level9VertexShader;
		@ref.Has10Level9PixelShader = Has10Level9PixelShader;
	}
}
