using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class TreeViewImages : Storage
{
	private Image _plus;

	private Image _minus;

	[Browsable(false)]
	public override bool IsDefault => _plus == null && _minus == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image used to expand a tree node.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Plus
	{
		get
		{
			return _plus;
		}
		set
		{
			if (_plus != value)
			{
				_plus = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image used to collapse a tree node.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Minus
	{
		get
		{
			return _minus;
		}
		set
		{
			if (_minus != value)
			{
				_minus = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public TreeViewImages()
		: this(null)
	{
	}

	public TreeViewImages(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_plus = null;
		_minus = null;
	}

	public void ResetPlus()
	{
		Plus = null;
	}

	public void ResetMinus()
	{
		Minus = null;
	}
}
