using System;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.Services;

public abstract class ExternalResourceService
{
	public abstract ModelResource ApplicationModel { get; }

	public abstract IEnumerable<Uri> ResourceUris { get; }

	public abstract ModelResource GetModelResource(Uri uri);

	public abstract BinaryResource GetBinaryResource(Uri uri);

	public abstract Uri TranslateStreamUri(Uri streamUri);
}
