using System;

namespace Microsoft.Windows.Design.Metadata;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class ProvideMetadataAttribute : Attribute
{
	private Type _metadataProviderType;

	public Type MetadataProviderType => _metadataProviderType;

	public ProvideMetadataAttribute(Type metadataProviderType)
	{
		if ((object)metadataProviderType == null)
		{
			throw new ArgumentNullException("metadataProviderType");
		}
		_metadataProviderType = metadataProviderType;
	}
}
