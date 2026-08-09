namespace System.Reflection.Context.Delegation;

internal class DelegatingManifestResourceInfo : ManifestResourceInfo
{
	public ManifestResourceInfo UnderlyingResource { get; }

	public DelegatingManifestResourceInfo(ManifestResourceInfo resource)
		: base(resource.ReferencedAssembly, resource.FileName, resource.ResourceLocation)
	{
		UnderlyingResource = resource;
	}
}
