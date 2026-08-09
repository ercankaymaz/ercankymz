using System;

namespace Xceed.Wpf.Toolkit.Core;

public class VersionResourceDictionary : ResourceDictionary
{
	public VersionResourceDictionary()
	{
	}

	public VersionResourceDictionary(string assemblyName, string sourcePath)
		: base(assemblyName, sourcePath)
	{
	}

	protected override Uri BuildUri()
	{
		string sourcePath = base.SourcePath;
		return new Uri(PackUriExtension.BuildAbsolutePackUriString(base.AssemblyName, "4.5.0.0", sourcePath), UriKind.Absolute);
	}
}
