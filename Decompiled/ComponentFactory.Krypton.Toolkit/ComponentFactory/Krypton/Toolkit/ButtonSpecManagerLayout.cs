using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecManagerLayout : ButtonSpecManagerBase
{
	private ViewLayoutDocker[] _viewDockers;

	protected override int DockerCount => _viewDockers.Length;

	public ButtonSpecManagerLayout(Control control, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, ViewLayoutDocker[] viewDockers, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricInt, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
		: this(control, redirector, variableSpecs, fixedSpecs, viewDockers, viewMetrics, viewMetricInt, viewMetricInt, viewMetricPaddings, getRenderer, needPaint)
	{
	}

	public ButtonSpecManagerLayout(Control control, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, ViewLayoutDocker[] viewDockers, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricIntOutside, PaletteMetricInt[] viewMetricIntInside, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
		: base(control, redirector, variableSpecs, fixedSpecs, viewMetrics, viewMetricIntOutside, viewMetricIntInside, viewMetricPaddings, getRenderer, needPaint)
	{
		_viewDockers = viewDockers;
		Construct();
	}

	protected override int DockerIndex(ViewBase viewDocker)
	{
		for (int i = 0; i < _viewDockers.Length; i++)
		{
			if (_viewDockers[i] == viewDocker)
			{
				return i;
			}
		}
		return -1;
	}

	protected override ViewBase IndexDocker(int i)
	{
		if (_viewDockers.Length > i)
		{
			return _viewDockers[i];
		}
		return null;
	}

	protected override VisualOrientation DockerOrientation(int i)
	{
		if (_viewDockers.Length > i)
		{
			return _viewDockers[i].Orientation;
		}
		return VisualOrientation.Top;
	}

	protected override ViewDrawContent GetDockerForeground(int i)
	{
		return null;
	}

	protected override void AddViewToDocker(int i, ViewDockStyle dockStyle, ViewBase view, bool usingSpacers)
	{
		ViewLayoutDocker viewLayoutDocker = _viewDockers[i];
		int num = viewLayoutDocker.Count;
		if (usingSpacers)
		{
			for (int j = 0; j < num; j++)
			{
				if (viewLayoutDocker[j] is ViewLayoutMetricSpacer)
				{
					num = j;
					break;
				}
			}
		}
		viewLayoutDocker.Insert(num, view);
		viewLayoutDocker.SetDock(view, dockStyle);
	}

	protected override void AddSpacersToDocker(int i, ViewLayoutMetricSpacer spacerL, ViewLayoutMetricSpacer spacerR)
	{
		ViewLayoutDocker viewLayoutDocker = _viewDockers[i];
		viewLayoutDocker.Add(spacerL, ViewDockStyle.Left);
		viewLayoutDocker.Add(spacerR, ViewDockStyle.Right);
	}
}
