using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal sealed class ProjectingLocalVariableInfo : DelegatingLocalVariableInfo
{
	private readonly Projector _projector;

	public override Type LocalType => _projector.ProjectType(base.LocalType);

	public ProjectingLocalVariableInfo(LocalVariableInfo variable, Projector projector)
		: base(variable)
	{
		_projector = projector;
	}
}
