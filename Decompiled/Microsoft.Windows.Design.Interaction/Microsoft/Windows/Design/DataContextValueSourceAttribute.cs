using System;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Property)]
public sealed class DataContextValueSourceAttribute : Attribute
{
	public string DataContextValueSourceProperty { get; private set; }

	public bool IsCollectionItem { get; private set; }

	public string AncestorPath { get; private set; }

	public DataContextValueSourceAttribute(string dataContextValueSourceProperty, bool isCollectionItem)
		: this(dataContextValueSourceProperty, null, isCollectionItem)
	{
	}

	public DataContextValueSourceAttribute(string dataContextValueSourceProperty, string ancestorPath, bool isCollectionItem)
	{
		DataContextValueSourceProperty = dataContextValueSourceProperty;
		AncestorPath = ancestorPath;
		IsCollectionItem = isCollectionItem;
	}
}
