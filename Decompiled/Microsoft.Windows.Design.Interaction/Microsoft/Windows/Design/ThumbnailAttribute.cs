using System;
using System.Reflection;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class ThumbnailAttribute : Attribute
{
	private string _resourceName;

	private Assembly _resourceAssembly;

	public Assembly ResourceAssembly => _resourceAssembly;

	public string ResourceName => _resourceName;

	public ThumbnailAttribute(Type resourceAssemblyType, string resourceName)
	{
		if ((object)resourceAssemblyType == null)
		{
			throw new ArgumentNullException("resourceAssemblyType");
		}
		if (string.IsNullOrEmpty(resourceName))
		{
			throw new ArgumentNullException("resourceName");
		}
		_resourceAssembly = resourceAssemblyType.Assembly;
		_resourceName = resourceName;
	}
}
