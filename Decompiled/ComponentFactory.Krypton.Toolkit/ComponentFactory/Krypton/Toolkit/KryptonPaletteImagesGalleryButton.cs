using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImagesGalleryButton : Storage
{
	private PaletteRibbonGalleryButton _button;

	private PaletteRedirect _redirect;

	private Image _common;

	private Image _disabled;

	private Image _normal;

	private Image _tracking;

	private Image _pressed;

	[Browsable(false)]
	public override bool IsDefault => _common == null && _disabled == null && _normal == null && _tracking == null && _pressed == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Common image that other gallery button images inherit from.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Common
	{
		get
		{
			return _common;
		}
		set
		{
			if (_common != value)
			{
				_common = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the gallery button is disabled.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Disabled
	{
		get
		{
			return _disabled;
		}
		set
		{
			if (_disabled != value)
			{
				_disabled = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the gallery button is normal.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Normal
	{
		get
		{
			return _normal;
		}
		set
		{
			if (_normal != value)
			{
				_normal = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the gallery button is hot tracking.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Tracking
	{
		get
		{
			return _tracking;
		}
		set
		{
			if (_tracking != value)
			{
				_tracking = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the gallery button is pressed.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Pressed
	{
		get
		{
			return _pressed;
		}
		set
		{
			if (_pressed != value)
			{
				_pressed = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public KryptonPaletteImagesGalleryButton(PaletteRibbonGalleryButton button, PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_button = button;
		_redirect = redirect;
		NeedPaint = needPaint;
		_common = null;
		_disabled = null;
		_normal = null;
		_tracking = null;
		_pressed = null;
	}

	public void PopulateFromBase()
	{
		_disabled = _redirect.GetGalleryButtonImage(_button, PaletteState.Disabled);
		_normal = _redirect.GetGalleryButtonImage(_button, PaletteState.Normal);
		_tracking = _redirect.GetGalleryButtonImage(_button, PaletteState.Tracking);
		_pressed = _redirect.GetGalleryButtonImage(_button, PaletteState.Pressed);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public void ResetCommon()
	{
		Common = null;
	}

	public void ResetDisabled()
	{
		Disabled = null;
	}

	public void ResetNormal()
	{
		Normal = null;
	}

	public void ResetTracking()
	{
		Tracking = null;
	}

	public void ResetPressed()
	{
		Pressed = null;
	}
}
