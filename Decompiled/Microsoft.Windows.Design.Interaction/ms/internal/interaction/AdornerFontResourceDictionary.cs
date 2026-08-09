using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class AdornerFontResourceDictionary : ResourceDictionary, IComponentConnector
{
	private bool _contentLoaded;

	internal AdornerFontResourceDictionary()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		((ResourceDictionary)this).Add((object)AdornerFonts.FontFamilyKey, (object)new FontFamily("Tahoma"));
		((ResourceDictionary)this).Add((object)AdornerFonts.FontSizeKey, (object)8.4);
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri uri = new Uri("/Microsoft.Windows.Design.Interaction;component/ms/internal/interaction/adornerfontresourcedictionary.xaml", UriKind.Relative);
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
