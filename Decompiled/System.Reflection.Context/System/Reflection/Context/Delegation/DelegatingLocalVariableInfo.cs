namespace System.Reflection.Context.Delegation;

internal class DelegatingLocalVariableInfo : LocalVariableInfo
{
	public override bool IsPinned => UnderlyingVariable.IsPinned;

	public override int LocalIndex => UnderlyingVariable.LocalIndex;

	public override Type LocalType => UnderlyingVariable.LocalType;

	public LocalVariableInfo UnderlyingVariable { get; }

	public DelegatingLocalVariableInfo(LocalVariableInfo variable)
	{
		UnderlyingVariable = variable;
	}

	public override string ToString()
	{
		return UnderlyingVariable.ToString();
	}
}
