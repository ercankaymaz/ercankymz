using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Themes;

internal class GenericTheme : ResourceDictionary, IComponentConnector
{
	private bool _contentLoaded;

	public GenericTheme()
	{
		((ResourceDictionary)this).MergedDictionaries.Add(AdornerResources.ThemeResources);
	}

	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri uri = new Uri("/Microsoft.Windows.Design.Interaction;component/themes/generic.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		_contentLoaded = true;
	}
}
