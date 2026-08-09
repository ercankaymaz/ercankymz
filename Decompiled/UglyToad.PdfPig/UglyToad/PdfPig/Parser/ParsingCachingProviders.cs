using System;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.Parser;

internal class ParsingCachingProviders
{
	public IResourceStore ResourceContainer { get; }

	public ParsingCachingProviders(IResourceStore resourceContainer)
	{
		ResourceContainer = resourceContainer ?? throw new ArgumentNullException("resourceContainer");
	}
}
