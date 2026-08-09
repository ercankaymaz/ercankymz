using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImagesRadioButton : Storage
{
	private PaletteRedirect _redirect;

	private Image _common;

	private Image _uncheckedDisabled;

	private Image _uncheckedNormal;

	private Image _uncheckedTracking;

	private Image _uncheckedPressed;

	private Image _checkedDisabled;

	private Image _checkedNormal;

	private Image _checkedTracking;

	private Image _checkedPressed;

	[Browsable(false)]
	public override bool IsDefault => _common == null && _uncheckedDisabled == null && _uncheckedNormal == null && _uncheckedTracking == null && _uncheckedPressed == null && _checkedDisabled == null && _checkedNormal == null && _checkedTracking == null && _checkedPressed == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Common image that other check box images inherit from.")]
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
	[Description("Image for use when the check box is not checked and disabled.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image UncheckedDisabled
	{
		get
		{
			return _uncheckedDisabled;
		}
		set
		{
			if (_uncheckedDisabled != value)
			{
				_uncheckedDisabled = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is unchecked.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image UncheckedNormal
	{
		get
		{
			return _uncheckedNormal;
		}
		set
		{
			if (_uncheckedNormal != value)
			{
				_uncheckedNormal = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is unchecked and hot tracking.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image UncheckedTracking
	{
		get
		{
			return _uncheckedTracking;
		}
		set
		{
			if (_uncheckedTracking != value)
			{
				_uncheckedTracking = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is unchecked and pressed.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image UncheckedPressed
	{
		get
		{
			return _uncheckedPressed;
		}
		set
		{
			if (_uncheckedPressed != value)
			{
				_uncheckedPressed = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is checked but disabled.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image CheckedDisabled
	{
		get
		{
			return _checkedDisabled;
		}
		set
		{
			if (_checkedDisabled != value)
			{
				_checkedDisabled = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is checked.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image CheckedNormal
	{
		get
		{
			return _checkedNormal;
		}
		set
		{
			if (_checkedNormal != value)
			{
				_checkedNormal = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is checked and hot tracking.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image CheckedTracking
	{
		get
		{
			return _checkedTracking;
		}
		set
		{
			if (_checkedTracking != value)
			{
				_checkedTracking = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is checked and pressed.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image CheckedPressed
	{
		get
		{
			return _checkedPressed;
		}
		set
		{
			if (_checkedPressed != value)
			{
				_checkedPressed = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public KryptonPaletteImagesRadioButton(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_redirect = redirect;
		NeedPaint = needPaint;
		_common = null;
		_uncheckedDisabled = null;
		_uncheckedNormal = null;
		_uncheckedTracking = null;
		_uncheckedPressed = null;
		_checkedDisabled = null;
		_checkedNormal = null;
		_checkedTracking = null;
		_checkedPressed = null;
	}

	public void PopulateFromBase()
	{
		_checkedDisabled = _redirect.GetRadioButtonImage(enabled: false, checkState: true, tracking: false, pressed: false);
		_checkedNormal = _redirect.GetRadioButtonImage(enabled: true, checkState: true, tracking: false, pressed: false);
		_checkedTracking = _redirect.GetRadioButtonImage(enabled: true, checkState: true, tracking: true, pressed: false);
		_checkedPressed = _redirect.GetRadioButtonImage(enabled: true, checkState: true, tracking: false, pressed: true);
		_uncheckedDisabled = _redirect.GetRadioButtonImage(enabled: false, checkState: false, tracking: false, pressed: false);
		_uncheckedNormal = _redirect.GetRadioButtonImage(enabled: true, checkState: false, tracking: false, pressed: false);
		_uncheckedTracking = _redirect.GetRadioButtonImage(enabled: true, checkState: false, tracking: true, pressed: false);
		_uncheckedPressed = _redirect.GetRadioButtonImage(enabled: true, checkState: false, tracking: false, pressed: true);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
	}

	public void ResetCommon()
	{
		Common = null;
	}

	public void ResetUncheckedDisabled()
	{
		UncheckedDisabled = null;
	}

	public void ResetUncheckedNormal()
	{
		UncheckedNormal = null;
	}

	public void ResetUncheckedTracking()
	{
		UncheckedTracking = null;
	}

	public void ResetUncheckedPressed()
	{
		UncheckedPressed = null;
	}

	public void ResetCheckedDisabled()
	{
		CheckedDisabled = null;
	}

	public void ResetCheckedNormal()
	{
		CheckedNormal = null;
	}

	public void ResetCheckedTracking()
	{
		CheckedTracking = null;
	}

	public void ResetCheckedPressed()
	{
		CheckedPressed = null;
	}
}
