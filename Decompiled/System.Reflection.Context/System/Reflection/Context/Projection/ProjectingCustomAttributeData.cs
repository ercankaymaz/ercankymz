using System.Collections.Generic;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal sealed class ProjectingCustomAttributeData : DelegatingCustomAttributeData
{
	private readonly Projector _projector;

	public override ConstructorInfo Constructor => _projector.ProjectConstructor(base.Constructor);

	public override IList<CustomAttributeTypedArgument> ConstructorArguments => _projector.Project(base.ConstructorArguments, _projector.ProjectTypedArgument);

	public override IList<CustomAttributeNamedArgument> NamedArguments => _projector.Project(base.NamedArguments, _projector.ProjectNamedArgument);

	public ProjectingCustomAttributeData(CustomAttributeData attribute, Projector projector)
		: base(attribute)
	{
		_projector = projector;
	}
}
