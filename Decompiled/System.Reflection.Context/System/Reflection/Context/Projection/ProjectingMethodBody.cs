using System.Collections.Generic;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal sealed class ProjectingMethodBody : DelegatingMethodBody
{
	private readonly Projector _projector;

	public override IList<ExceptionHandlingClause> ExceptionHandlingClauses => _projector.Project(base.ExceptionHandlingClauses, _projector.ProjectExceptionHandlingClause);

	public override IList<LocalVariableInfo> LocalVariables => _projector.Project(base.LocalVariables, _projector.ProjectLocalVariable);

	public ProjectingMethodBody(MethodBody body, Projector projector)
		: base(body)
	{
		_projector = projector;
	}
}
