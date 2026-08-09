using System;
using System.IO;
using System.Reflection;
using System.Windows;
using MS.Internal;

namespace Microsoft.Windows.Design.PropertyEditing;

public class NewItemFactory
{
	private Type[] NoTypes = new Type[0];

	public virtual Stream GetImageStream(Type type, Size desiredSize, out string imageName)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		ExtensibleIconLookup extensibleIconLookup = new ExtensibleIconLookup(type, (int)((Size)(ref desiredSize)).Width, (int)((Size)(ref desiredSize)).Height);
		imageName = extensibleIconLookup.ResourceName;
		return extensibleIconLookup.Stream;
	}

	public virtual string GetDisplayName(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return type.Name;
	}

	public virtual object CreateInstance(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, NoTypes, null);
		if ((object)constructor == null && type.IsValueType && !type.IsPrimitive)
		{
			return Activator.CreateInstance(type);
		}
		return constructor?.Invoke(null);
	}
}
