using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class CheckButtonImageStates : ButtonImageStates
{
	private Image _imageCheckedNormal;

	private Image _imageCheckedPressed;

	private Image _imageCheckedTracking;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && ImageCheckedNormal == null && ImageCheckedPressed == null && ImageCheckedTracking == null;

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for checked normal state.")]
	[RefreshProperties(RefreshProperties.All)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	[DefaultValue(null)]
	public override Image ImageCheckedNormal
	{
		get
		{
			return _imageCheckedNormal;
		}
		set
		{
			if (_imageCheckedNormal != value)
			{
				_imageCheckedNormal = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for checked pressed state.")]
	[RefreshProperties(RefreshProperties.All)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	[DefaultValue(null)]
	public override Image ImageCheckedPressed
	{
		get
		{
			return _imageCheckedPressed;
		}
		set
		{
			if (_imageCheckedPressed != value)
			{
				_imageCheckedPressed = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for checked tracking state.")]
	[RefreshProperties(RefreshProperties.All)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	[DefaultValue(null)]
	public override Image ImageCheckedTracking
	{
		get
		{
			return _imageCheckedTracking;
		}
		set
		{
			if (_imageCheckedTracking != value)
			{
				_imageCheckedTracking = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	private bool ShouldSerializeImageCheckedNormal()
	{
		return ImageCheckedNormal != null;
	}

	public void ResetImageCheckedNormal()
	{
		ImageCheckedNormal = null;
	}

	private bool ShouldSerializeImageCheckedPressed()
	{
		return ImageCheckedPressed != null;
	}

	public void ResetImageCheckedPressed()
	{
		ImageCheckedPressed = null;
	}

	private bool ShouldSerializeImageCheckedTracking()
	{
		return ImageCheckedTracking != null;
	}

	public void ResetImageCheckedTracking()
	{
		ImageCheckedTracking = null;
	}

	public void CopyFrom(CheckButtonImageStates source)
	{
		base.CopyFrom(source);
		ImageCheckedNormal = source.ImageCheckedNormal;
		ImageCheckedPressed = source.ImageCheckedPressed;
		ImageCheckedTracking = source.ImageCheckedTracking;
	}
}
