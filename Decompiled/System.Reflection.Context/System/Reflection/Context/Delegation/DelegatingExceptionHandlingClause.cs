namespace System.Reflection.Context.Delegation;

internal class DelegatingExceptionHandlingClause : ExceptionHandlingClause
{
	private readonly ExceptionHandlingClause _clause;

	public override Type CatchType => _clause.CatchType;

	public override int FilterOffset => _clause.FilterOffset;

	public override ExceptionHandlingClauseOptions Flags => _clause.Flags;

	public override int HandlerLength => _clause.HandlerLength;

	public override int HandlerOffset => _clause.HandlerOffset;

	public override int TryLength => _clause.TryLength;

	public override int TryOffset => _clause.TryOffset;

	public DelegatingExceptionHandlingClause(ExceptionHandlingClause clause)
	{
		_clause = clause;
	}

	public override string ToString()
	{
		return _clause.ToString();
	}
}
