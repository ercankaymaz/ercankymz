#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecManagerDraw : ButtonSpecManagerBase
{
	private ViewDrawDocker[] _viewDockers;

	protected override int DockerCount => _viewDockers.Length;

	public ButtonSpecManagerDraw(Control control, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, ViewDrawDocker[] viewDockers, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricInt, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
		: this(control, redirector, variableSpecs, fixedSpecs, viewDockers, viewMetrics, viewMetricInt, viewMetricInt, viewMetricPaddings, getRenderer, needPaint)
	{
	}

	public ButtonSpecManagerDraw(Control control, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, ViewDrawDocker[] viewDockers, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricIntOutside, PaletteMetricInt[] viewMetricIntInside, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
		: base(control, redirector, variableSpecs, fixedSpecs, viewMetrics, viewMetricIntOutside, viewMetricIntInside, viewMetricPaddings, getRenderer, needPaint)
	{
		Debug.Assert(viewDockers != null);
		Debug.Assert(viewDockers.Length == viewMetrics.Length);
		Debug.Assert(viewDockers.Length == viewMetricPaddings.Length);
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
		return _viewDockers[i];
	}

	protected override VisualOrientation DockerOrientation(int i)
	{
		return _viewDockers[i].Orientation;
	}

	protected override ViewDrawContent GetDockerForeground(int i)
	{
		ViewDrawDocker viewDrawDocker = _viewDockers[i];
		foreach (ViewBase item in viewDrawDocker)
		{
			if (viewDrawDocker.GetDock(item) == ViewDockStyle.Fill)
			{
				return item as ViewDrawContent;
			}
		}
		return null;
	}

	protected override void AddViewToDocker(int i, ViewDockStyle dockStyle, ViewBase view, bool usingSpacers)
	{
		ViewDrawDocker viewDrawDocker = _viewDockers[i];
		int num = viewDrawDocker.Count;
		if (usingSpacers)
		{
			for (int j = 0; j < num; j++)
			{
				if (viewDrawDocker[j] is ViewLayoutMetricSpacer)
				{
					num = j;
					break;
				}
			}
		}
		viewDrawDocker.Insert(num, view);
		viewDrawDocker.SetDock(view, dockStyle);
	}

	protected override void AddSpacersToDocker(int i, ViewLayoutMetricSpacer spacerL, ViewLayoutMetricSpacer spacerR)
	{
		ViewDrawDocker viewDrawDocker = _viewDockers[i];
		viewDrawDocker.Add(spacerL, ViewDockStyle.Left);
		viewDrawDocker.Add(spacerR, ViewDockStyle.Right);
	}
}
