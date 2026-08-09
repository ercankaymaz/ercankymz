using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonImageStates : Storage
{
	private Image _imageNormal;

	private Image _imageDisabled;

	private Image _imagePressed;

	private Image _imageTracking;

	[Browsable(false)]
	public override bool IsDefault => ImageNormal == null && ImageDisabled == null && ImagePressed == null && ImageTracking == null;

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for normal state.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public Image ImageNormal
	{
		get
		{
			return _imageNormal;
		}
		set
		{
			if (_imageNormal != value)
			{
				_imageNormal = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for disabled state.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public Image ImageDisabled
	{
		get
		{
			return _imageDisabled;
		}
		set
		{
			if (_imageDisabled != value)
			{
				_imageDisabled = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for pressed state.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public Image ImagePressed
	{
		get
		{
			return _imagePressed;
		}
		set
		{
			if (_imagePressed != value)
			{
				_imagePressed = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image for tracking state.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public Image ImageTracking
	{
		get
		{
			return _imageTracking;
		}
		set
		{
			if (_imageTracking != value)
			{
				_imageTracking = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Image ImageCheckedNormal
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Image ImageCheckedPressed
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Image ImageCheckedTracking
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private bool ShouldSerializeImageNormal()
	{
		return ImageNormal != null;
	}

	public void ResetImageNormal()
	{
		ImageNormal = null;
	}

	private bool ShouldSerializeImageDisabled()
	{
		return ImageDisabled != null;
	}

	public void ResetImageDisabled()
	{
		ImageDisabled = null;
	}

	private bool ShouldSerializeImagePressed()
	{
		return ImagePressed != null;
	}

	public void ResetImagePressed()
	{
		ImagePressed = null;
	}

	private bool ShouldSerializeImageTracking()
	{
		return ImageTracking != null;
	}

	public void ResetImageTracking()
	{
		ImageTracking = null;
	}

	public virtual void CopyFrom(ButtonImageStates source)
	{
		ImageDisabled = source.ImageDisabled;
		ImageNormal = source.ImageNormal;
		ImagePressed = source.ImagePressed;
		ImageTracking = source.ImageTracking;
	}
}
