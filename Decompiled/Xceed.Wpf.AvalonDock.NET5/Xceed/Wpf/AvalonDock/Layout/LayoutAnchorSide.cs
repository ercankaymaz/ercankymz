using System;
using System.Windows.Markup;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("Children")]
public class LayoutAnchorSide : LayoutGroup<LayoutAnchorGroup>
{
	private AnchorSide _side;

	public AnchorSide Side
	{
		get
		{
			return _side;
		}
		private set
		{
			if (_side != value)
			{
				RaisePropertyChanging("Side");
				_side = value;
				RaisePropertyChanged("Side");
			}
		}
	}

	protected override bool GetVisibility()
	{
		return base.Children.Count > 0;
	}

	protected override void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
		base.OnParentChanged(oldValue, newValue);
		UpdateSide();
	}

	private void UpdateSide()
	{
		if (base.Root.LeftSide == this)
		{
			Side = AnchorSide.Left;
		}
		else if (base.Root.TopSide == this)
		{
			Side = AnchorSide.Top;
		}
		else if (base.Root.RightSide == this)
		{
			Side = AnchorSide.Right;
		}
		else if (base.Root.BottomSide == this)
		{
			Side = AnchorSide.Bottom;
		}
	}
}
