using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

public struct ParameterDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr Name;

		public IntPtr SemanticName;

		public ShaderVariableType Type;

		public ShaderVariableClass Class;

		public int Rows;

		public int Columns;

		public InterpolationMode InterpolationMode;

		public ParameterFlags Flags;

		public int FirstInRegister;

		public int FirstInComponent;

		public int FirstOutRegister;

		public int FirstOutComponent;
	}

	public string Name;

	public string SemanticName;

	public ShaderVariableType Type;

	public ShaderVariableClass Class;

	public int Rows;

	public int Columns;

	public InterpolationMode InterpolationMode;

	public ParameterFlags Flags;

	public int FirstInRegister;

	public int FirstInComponent;

	public int FirstOutRegister;

	public int FirstOutComponent;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Name);
		Marshal.FreeHGlobal(@ref.SemanticName);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Name = Marshal.PtrToStringAnsi(@ref.Name);
		SemanticName = Marshal.PtrToStringAnsi(@ref.SemanticName);
		Type = @ref.Type;
		Class = @ref.Class;
		Rows = @ref.Rows;
		Columns = @ref.Columns;
		InterpolationMode = @ref.InterpolationMode;
		Flags = @ref.Flags;
		FirstInRegister = @ref.FirstInRegister;
		FirstInComponent = @ref.FirstInComponent;
		FirstOutRegister = @ref.FirstOutRegister;
		FirstOutComponent = @ref.FirstOutComponent;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Name = Marshal.StringToHGlobalAnsi(Name);
		@ref.SemanticName = Marshal.StringToHGlobalAnsi(SemanticName);
		@ref.Type = Type;
		@ref.Class = Class;
		@ref.Rows = Rows;
		@ref.Columns = Columns;
		@ref.InterpolationMode = InterpolationMode;
		@ref.Flags = Flags;
		@ref.FirstInRegister = FirstInRegister;
		@ref.FirstInComponent = FirstInComponent;
		@ref.FirstOutRegister = FirstOutRegister;
		@ref.FirstOutComponent = FirstOutComponent;
	}
}
