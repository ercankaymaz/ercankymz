namespace SharpDX.D3DCompiler;

public class CompilationResult : CompilationResultBase<ShaderBytecode>
{
	public CompilationResult(ShaderBytecode bytecode, Result resultCode, string message)
		: base(bytecode, resultCode, message)
	{
	}

	public static implicit operator ShaderBytecode(CompilationResult input)
	{
		return input?.Bytecode;
	}

	public static implicit operator byte[](CompilationResult input)
	{
		return input?.Bytecode;
	}
}
