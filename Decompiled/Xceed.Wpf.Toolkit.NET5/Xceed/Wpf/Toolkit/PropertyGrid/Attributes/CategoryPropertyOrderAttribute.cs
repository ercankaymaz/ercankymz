using System;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CategoryPropertyOrderAttribute : Attribute
{
	public CategoryPropertyOrderEnum CategoryPropertyOrder { get; private set; }

	public CategoryPropertyOrderAttribute(CategoryPropertyOrderEnum categoryPropertyOrder = CategoryPropertyOrderEnum.Alphabetical)
	{
		CategoryPropertyOrder = categoryPropertyOrder;
	}
}
