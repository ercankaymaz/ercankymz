using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImagesTreeView : Storage
{
	private PaletteRedirect _redirect;

	private Image _plus;

	private Image _minus;

	[Browsable(false)]
	public override bool IsDefault => _plus == null && _minus == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for use when a node is collapsed.")]
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
	[Description("Image for use when a node is expanded.")]
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

	public KryptonPaletteImagesTreeView(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_redirect = redirect;
		NeedPaint = needPaint;
		_plus = null;
		_minus = null;
	}

	public void PopulateFromBase()
	{
		_plus = _redirect.GetTreeViewImage(expanded: false);
		_minus = _redirect.GetTreeViewImage(expanded: true);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirect = redirect;
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
