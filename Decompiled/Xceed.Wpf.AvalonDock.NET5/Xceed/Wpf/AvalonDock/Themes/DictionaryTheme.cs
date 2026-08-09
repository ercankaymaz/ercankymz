using System;
using System.Windows;

namespace Xceed.Wpf.AvalonDock.Themes;

public abstract class DictionaryTheme : Theme
{
	public ResourceDictionary ThemeResourceDictionary { get; private set; }

	public DictionaryTheme()
	{
	}

	public DictionaryTheme(ResourceDictionary themeResourceDictionary)
	{
		ThemeResourceDictionary = themeResourceDictionary;
	}

	public override Uri GetResourceUri()
	{
		return null;
	}
}
