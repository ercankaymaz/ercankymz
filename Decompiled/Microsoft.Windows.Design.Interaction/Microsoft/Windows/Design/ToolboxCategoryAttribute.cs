using System;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class ToolboxCategoryAttribute : Attribute
{
	public string CategoryPath { get; private set; }

	public bool AlwaysShows { get; private set; }

	public ToolboxCategoryAttribute(string categoryPath)
		: this(categoryPath, alwaysShows: false)
	{
	}

	public ToolboxCategoryAttribute(string categoryPath, bool alwaysShows)
	{
		CategoryPath = categoryPath;
		AlwaysShows = alwaysShows;
	}
}
