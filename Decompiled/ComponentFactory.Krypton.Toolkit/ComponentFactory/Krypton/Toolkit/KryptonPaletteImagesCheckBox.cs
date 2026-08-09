using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImagesCheckBox : Storage
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

	private Image _indeterminateDisabled;

	private Image _indeterminateNormal;

	private Image _indeterminateTracking;

	private Image _indeterminatePressed;

	[Browsable(false)]
	public override bool IsDefault => _common == null && _uncheckedDisabled == null && _uncheckedNormal == null && _uncheckedTracking == null && _uncheckedPressed == null && _checkedDisabled == null && _checkedNormal == null && _checkedTracking == null && _checkedPressed == null && _indeterminateDisabled == null && _indeterminateNormal == null && _indeterminateTracking == null && _indeterminatePressed == null;

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

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is indeterminate but disabled.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image IndeterminateDisabled
	{
		get
		{
			return _indeterminateDisabled;
		}
		set
		{
			if (_indeterminateDisabled != value)
			{
				_indeterminateDisabled = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is indeterminate.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image IndeterminateNormal
	{
		get
		{
			return _indeterminateNormal;
		}
		set
		{
			if (_indeterminateNormal != value)
			{
				_indeterminateNormal = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is indeterminate and hot tracking.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image IndeterminateTracking
	{
		get
		{
			return _indeterminateTracking;
		}
		set
		{
			if (_indeterminateTracking != value)
			{
				_indeterminateTracking = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when the check box is indeterminate and pressed.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image IndeterminatePressed
	{
		get
		{
			return _indeterminatePressed;
		}
		set
		{
			if (_indeterminatePressed != value)
			{
				_indeterminatePressed = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public KryptonPaletteImagesCheckBox(PaletteRedirect redirect, NeedPaintHandler needPaint)
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
		_indeterminateDisabled = null;
		_indeterminateNormal = null;
		_indeterminateTracking = null;
		_indeterminatePressed = null;
	}

	public void PopulateFromBase()
	{
		_checkedDisabled = _redirect.GetCheckBoxImage(enabled: false, CheckState.Checked, tracking: false, pressed: false);
		_checkedNormal = _redirect.GetCheckBoxImage(enabled: true, CheckState.Checked, tracking: false, pressed: false);
		_checkedTracking = _redirect.GetCheckBoxImage(enabled: true, CheckState.Checked, tracking: true, pressed: false);
		_checkedPressed = _redirect.GetCheckBoxImage(enabled: true, CheckState.Checked, tracking: false, pressed: true);
		_uncheckedDisabled = _redirect.GetCheckBoxImage(enabled: false, CheckState.Unchecked, tracking: false, pressed: false);
		_uncheckedNormal = _redirect.GetCheckBoxImage(enabled: true, CheckState.Unchecked, tracking: false, pressed: false);
		_uncheckedTracking = _redirect.GetCheckBoxImage(enabled: true, CheckState.Unchecked, tracking: true, pressed: false);
		_uncheckedPressed = _redirect.GetCheckBoxImage(enabled: true, CheckState.Unchecked, tracking: false, pressed: true);
		_indeterminateDisabled = _redirect.GetCheckBoxImage(enabled: false, CheckState.Indeterminate, tracking: false, pressed: false);
		_indeterminateNormal = _redirect.GetCheckBoxImage(enabled: true, CheckState.Indeterminate, tracking: false, pressed: false);
		_indeterminateTracking = _redirect.GetCheckBoxImage(enabled: true, CheckState.Indeterminate, tracking: true, pressed: false);
		_indeterminatePressed = _redirect.GetCheckBoxImage(enabled: true, CheckState.Indeterminate, tracking: false, pressed: true);
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

	public void ResetIndeterminateDisabled()
	{
		IndeterminateDisabled = null;
	}

	public void ResetIndeterminateNormal()
	{
		IndeterminateNormal = null;
	}

	public void ResetIndeterminateTracking()
	{
		IndeterminateTracking = null;
	}

	public void ResetIndeterminatePressed()
	{
		IndeterminatePressed = null;
	}
}
