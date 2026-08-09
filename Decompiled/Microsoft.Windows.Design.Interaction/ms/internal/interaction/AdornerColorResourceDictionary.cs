using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class AdornerColorResourceDictionary : ResourceDictionary, IComponentConnector
{
	private bool _contentLoaded;

	internal AdornerColorResourceDictionary()
	{
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		if (SystemParameters.HighContrast)
		{
			((ResourceDictionary)this).Add((object)AdornerColors.AlignmentMarkColorKey, (object)SystemColors.ControlDarkColor);
			((ResourceDictionary)this).Add((object)AdornerColors.ElementBorderColorKey, (object)SystemColors.ControlLightLightColor);
			((ResourceDictionary)this).Add((object)AdornerColors.GlyphFillColorKey, (object)SystemColors.ControlDarkColor);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleBorderColorKey, (object)SystemColors.ControlTextColor);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleFillColorKey, (object)SystemColors.ControlColor);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleEmptyFillColorKey, (object)Colors.Transparent);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleFillHoverColorKey, (object)SystemColors.ActiveCaptionColor);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleFillPressedColorKey, (object)SystemColors.ActiveBorderColor);
			((ResourceDictionary)this).Add((object)AdornerColors.MoveHandleContentColorKey, (object)SystemColors.ControlDarkColor);
			((ResourceDictionary)this).Add((object)AdornerColors.MoveHandleFillColorKey, (object)Colors.Transparent);
			((ResourceDictionary)this).Add((object)AdornerColors.MoveHandleFillHoverColorKey, (object)SystemColors.ControlColor);
			((ResourceDictionary)this).Add((object)AdornerColors.RailFillColorKey, (object)Colors.Transparent);
			((ResourceDictionary)this).Add((object)AdornerColors.SelectionFrameBorderColorKey, (object)SystemColors.ControlDarkColor);
			((ResourceDictionary)this).Add((object)AdornerColors.SelectionFrameFillColorKey, (object)Colors.Transparent);
			((ResourceDictionary)this).Add((object)AdornerColors.SimpleWashColorKey, (object)Colors.Transparent);
			((ResourceDictionary)this).Add((object)AdornerColors.ToggledGlyphFillColorKey, (object)SystemColors.ControlDarkDarkColor);
		}
		else
		{
			((ResourceDictionary)this).Add((object)AdornerColors.AlignmentMarkColorKey, (object)Color.FromArgb(byte.MaxValue, (byte)99, (byte)65, (byte)24));
			((ResourceDictionary)this).Add((object)AdornerColors.ElementBorderColorKey, (object)Color.FromArgb((byte)102, (byte)116, (byte)142, (byte)170));
			((ResourceDictionary)this).Add((object)AdornerColors.GlyphFillColorKey, (object)SystemColors.ControlDarkColor);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleBorderColorKey, (object)Color.FromRgb((byte)116, (byte)142, (byte)170));
			((ResourceDictionary)this).Add((object)AdornerColors.HandleFillColorKey, (object)Color.FromRgb((byte)203, (byte)216, (byte)221));
			((ResourceDictionary)this).Add((object)AdornerColors.HandleEmptyFillColorKey, (object)Colors.White);
			((ResourceDictionary)this).Add((object)AdornerColors.HandleFillHoverColorKey, (object)Color.FromRgb((byte)247, (byte)148, (byte)28));
			((ResourceDictionary)this).Add((object)AdornerColors.HandleFillPressedColorKey, (object)Color.FromRgb((byte)204, (byte)0, (byte)0));
			((ResourceDictionary)this).Add((object)AdornerColors.MoveHandleContentColorKey, (object)Colors.Transparent);
			((ResourceDictionary)this).Add((object)AdornerColors.MoveHandleFillColorKey, (object)Color.FromArgb((byte)102, (byte)154, (byte)191, (byte)229));
			((ResourceDictionary)this).Add((object)AdornerColors.MoveHandleFillHoverColorKey, (object)Color.FromArgb((byte)102, (byte)154, (byte)191, (byte)229));
			((ResourceDictionary)this).Add((object)AdornerColors.RailFillColorKey, (object)Color.FromArgb((byte)102, (byte)154, (byte)191, (byte)229));
			((ResourceDictionary)this).Add((object)AdornerColors.SelectionFrameBorderColorKey, (object)Color.FromArgb((byte)128, (byte)116, (byte)142, (byte)170));
			((ResourceDictionary)this).Add((object)AdornerColors.SelectionFrameFillColorKey, (object)Color.FromArgb((byte)127, (byte)99, (byte)65, (byte)24));
			((ResourceDictionary)this).Add((object)AdornerColors.SimpleWashColorKey, (object)Color.FromArgb((byte)51, (byte)204, (byte)204, (byte)204));
			((ResourceDictionary)this).Add((object)AdornerColors.ToggledGlyphFillColorKey, (object)SystemColors.ControlDarkDarkColor);
		}
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri uri = new Uri("/Microsoft.Windows.Design.Interaction;component/ms/internal/interaction/adornercolorresourcedictionary.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		_contentLoaded = true;
	}
}
