using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal sealed class ProjectingExceptionHandlingClause : DelegatingExceptionHandlingClause
{
	private readonly Projector _projector;

	public override Type CatchType => _projector.ProjectType(base.CatchType);

	public ProjectingExceptionHandlingClause(ExceptionHandlingClause clause, Projector projector)
		: base(clause)
	{
		_projector = projector;
	}
}
