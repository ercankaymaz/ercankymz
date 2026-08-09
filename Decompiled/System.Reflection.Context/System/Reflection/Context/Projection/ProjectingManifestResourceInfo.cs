using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal sealed class ProjectingManifestResourceInfo : DelegatingManifestResourceInfo
{
	private readonly Projector _projector;

	public override Assembly ReferencedAssembly => _projector.ProjectAssembly(base.ReferencedAssembly);

	public ProjectingManifestResourceInfo(ManifestResourceInfo resource, Projector projector)
		: base(resource)
	{
		_projector = projector;
	}
}
