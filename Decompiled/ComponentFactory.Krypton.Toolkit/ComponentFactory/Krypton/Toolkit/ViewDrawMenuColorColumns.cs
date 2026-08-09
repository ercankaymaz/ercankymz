#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMenuColorColumns : ViewComposite
{
	private IContextMenuProvider _provider;

	private KryptonContextMenuColorColumns _colorColumns;

	private ViewLayoutDocker _outerDocker;

	private ViewLayoutDocker _innerDocker;

	public ViewDrawMenuColorColumns(IContextMenuProvider provider, KryptonContextMenuColorColumns colorColumns)
	{
		_provider = provider;
		_colorColumns = colorColumns;
		_innerDocker = new ViewLayoutDocker();
		colorColumns.SelectedColorChanged += OnSelectedColorChanged;
		Color[][] colors = colorColumns.Colors;
		int num = colors.Length;
		int num2 = ((num > 0 && colors[0] != null) ? colors[0].Length : 0);
		bool providerEnabled = provider.ProviderEnabled;
		ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: false) { CreateColumns(provider, colorColumns, colors, 0, 1, providerEnabled) };
		if (num2 > 1)
		{
			if (_colorColumns.GroupNonFirstRows)
			{
				viewLayoutStack.Add(new ViewLayoutSeparator(5));
				viewLayoutStack.Add(CreateColumns(provider, colorColumns, colors, 1, num2, providerEnabled));
			}
			else
			{
				for (int i = 1; i < num2; i++)
				{
					viewLayoutStack.Add(new ViewLayoutSeparator(5));
					viewLayoutStack.Add(CreateColumns(provider, colorColumns, colors, i, i + 1, providerEnabled));
				}
			}
		}
		_innerDocker.Add(viewLayoutStack, ViewDockStyle.Fill);
		_innerDocker.Add(new ViewLayoutSeparator(3), ViewDockStyle.Top);
		_innerDocker.Add(new ViewLayoutSeparator(3), ViewDockStyle.Bottom);
		_innerDocker.Add(new ViewLayoutSeparator(2), ViewDockStyle.Left);
		_innerDocker.Add(new ViewLayoutSeparator(2), ViewDockStyle.Right);
		_outerDocker = new ViewLayoutDocker();
		_outerDocker.Add(_innerDocker, ViewDockStyle.Top);
		_outerDocker.Add(new ViewLayoutNull(), ViewDockStyle.Fill);
		Add(_outerDocker);
	}

	protected override void Dispose(bool disposing)
	{
		_colorColumns.SelectedColorChanged -= OnSelectedColorChanged;
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewDrawMenuColorColumns:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	private ViewLayoutStack CreateColumns(IContextMenuProvider provider, KryptonContextMenuColorColumns colorColumns, Color[][] colors, int start, int end, bool enabled)
	{
		ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: true);
		viewLayoutStack.FillLastChild = false;
		for (int i = 0; i < colors.Length; i++)
		{
			if (i > 0)
			{
				viewLayoutStack.Add(new ViewLayoutSeparator(4));
			}
			ViewDrawMenuColorColumn item = new ViewDrawMenuColorColumn(provider, colorColumns, colors[i], start, end, enabled);
			viewLayoutStack.Add(item);
		}
		return viewLayoutStack;
	}

	private void OnSelectedColorChanged(object sender, ColorEventArgs e)
	{
		_provider.ProviderNeedPaintDelegate(this, new NeedLayoutEventArgs(needLayout: false));
	}
}
