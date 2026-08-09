using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

public struct ShaderParameterDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr SemanticName;

		public int SemanticIndex;

		public int Register;

		public SystemValueType SystemValueType;

		public RegisterComponentType ComponentType;

		public RegisterComponentMaskFlags UsageMask;

		public RegisterComponentMaskFlags ReadWriteMask;

		public int Stream;

		public MinimumPrecision MinPrecision;
	}

	public string SemanticName;

	public int SemanticIndex;

	public int Register;

	public SystemValueType SystemValueType;

	public RegisterComponentType ComponentType;

	public RegisterComponentMaskFlags UsageMask;

	public RegisterComponentMaskFlags ReadWriteMask;

	public int Stream;

	public MinimumPrecision MinPrecision;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.SemanticName);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		SemanticName = Marshal.PtrToStringAnsi(@ref.SemanticName);
		SemanticIndex = @ref.SemanticIndex;
		Register = @ref.Register;
		SystemValueType = @ref.SystemValueType;
		ComponentType = @ref.ComponentType;
		UsageMask = @ref.UsageMask;
		ReadWriteMask = @ref.ReadWriteMask;
		Stream = @ref.Stream;
		MinPrecision = @ref.MinPrecision;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.SemanticName = Marshal.StringToHGlobalAnsi(SemanticName);
		@ref.SemanticIndex = SemanticIndex;
		@ref.Register = Register;
		@ref.SystemValueType = SystemValueType;
		@ref.ComponentType = ComponentType;
		@ref.UsageMask = UsageMask;
		@ref.ReadWriteMask = ReadWriteMask;
		@ref.Stream = Stream;
		@ref.MinPrecision = MinPrecision;
	}
}
