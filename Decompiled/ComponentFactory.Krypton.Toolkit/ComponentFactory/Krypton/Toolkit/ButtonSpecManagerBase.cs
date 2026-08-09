#define DEBUG
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class ButtonSpecManagerBase : GlobalId
{
	internal class ButtonSpecLookup : Dictionary<ButtonSpec, ButtonSpecView>
	{
	}

	internal class ListSpacers : List<ViewLayoutMetricSpacer>
	{
	}

	private ToolTipManager _toolTipManager;

	private PaletteRedirect _redirector;

	private ButtonSpecCollectionBase _variableSpecs;

	private ButtonSpecCollectionBase _fixedSpecs;

	private IPaletteMetric[] _viewMetrics;

	private PaletteMetricInt[] _viewMetricIntOutside;

	private PaletteMetricInt[] _viewMetricIntInside;

	private PaletteMetricPadding[] _viewMetricPaddings;

	private ListSpacers[] _viewSpacers;

	private ButtonSpecLookup _specLookup;

	private GetToolStripRenderer _getRenderer;

	private bool _useMnemonic;

	private Control _control;

	private NeedPaintHandler _needPaint;

	public Control Control => _control;

	public ToolTipManager ToolTipManager
	{
		get
		{
			return _toolTipManager;
		}
		set
		{
			_toolTipManager = value;
		}
	}

	public NeedPaintHandler NeedPaint
	{
		get
		{
			return _needPaint;
		}
		set
		{
			_needPaint = value;
		}
	}

	public ButtonSpecView[] ButtonSpecViews
	{
		get
		{
			ButtonSpecView[] array = new ButtonSpecView[_specLookup.Count];
			int num = 0;
			foreach (ButtonSpecView value in _specLookup.Values)
			{
				array[num++] = value;
			}
			return array;
		}
	}

	public bool UseMnemonic
	{
		get
		{
			return _useMnemonic;
		}
		set
		{
			_useMnemonic = value;
		}
	}

	protected virtual bool UseInsideSpacers => false;

	protected abstract int DockerCount { get; }

	public ButtonSpecManagerBase(Control control, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricIntOutside, PaletteMetricInt[] viewMetricIntInside, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
	{
		Debug.Assert(control != null);
		Debug.Assert(redirector != null);
		Debug.Assert(getRenderer != null);
		NeedPaint = needPaint;
		_control = control;
		_redirector = redirector;
		_variableSpecs = variableSpecs;
		_fixedSpecs = fixedSpecs;
		_viewMetrics = viewMetrics;
		_viewMetricIntOutside = viewMetricIntOutside;
		_viewMetricIntInside = viewMetricIntInside;
		_viewMetricPaddings = viewMetricPaddings;
		_getRenderer = getRenderer;
		if (_viewMetrics != null)
		{
			_viewSpacers = new ListSpacers[_viewMetrics.Length];
		}
		_useMnemonic = true;
		_specLookup = new ButtonSpecLookup();
		if (_variableSpecs != null)
		{
			_variableSpecs.Inserted += OnButtonSpecInserted;
			_variableSpecs.Removed += OnButtonSpecRemoved;
		}
	}

	public void Construct()
	{
		if (_viewMetrics == null)
		{
			return;
		}
		for (int i = 0; i < _viewMetrics.Length; i++)
		{
			IPaletteMetric paletteMetric = _viewMetrics[i];
			PaletteMetricInt metricInt = _viewMetricIntOutside[i];
			_viewSpacers[i] = new ListSpacers();
			ViewLayoutMetricSpacer viewLayoutMetricSpacer = new ViewLayoutMetricSpacer(paletteMetric, metricInt);
			ViewLayoutMetricSpacer viewLayoutMetricSpacer2 = new ViewLayoutMetricSpacer(paletteMetric, metricInt);
			bool visible = (viewLayoutMetricSpacer2.Visible = false);
			viewLayoutMetricSpacer.Visible = visible;
			AddSpacersToDocker(i, viewLayoutMetricSpacer, viewLayoutMetricSpacer2);
			_viewSpacers[i].AddRange(new ViewLayoutMetricSpacer[2] { viewLayoutMetricSpacer, viewLayoutMetricSpacer2 });
			if (UseInsideSpacers)
			{
				PaletteMetricInt metricInt2 = _viewMetricIntInside[i];
				ViewLayoutMetricSpacer viewLayoutMetricSpacer3 = new ViewLayoutMetricSpacer(paletteMetric, metricInt2);
				ViewLayoutMetricSpacer viewLayoutMetricSpacer4 = new ViewLayoutMetricSpacer(paletteMetric, metricInt2);
				visible = (viewLayoutMetricSpacer4.Visible = false);
				viewLayoutMetricSpacer3.Visible = visible;
				AddSpacersToDocker(i, viewLayoutMetricSpacer3, viewLayoutMetricSpacer4);
				_viewSpacers[i].AddRange(new ViewLayoutMetricSpacer[2] { viewLayoutMetricSpacer3, viewLayoutMetricSpacer4 });
			}
		}
	}

	public void Destruct()
	{
		if (_variableSpecs != null)
		{
			_variableSpecs.Inserted -= OnButtonSpecInserted;
			_variableSpecs.Removed -= OnButtonSpecRemoved;
		}
		RemoveAll();
	}

	public void RecreateButtons()
	{
		RecreateAll();
		PerformNeedPaint(needLayout: true);
	}

	public bool RefreshButtons()
	{
		return RefreshButtons(composition: false);
	}

	public bool RefreshButtons(bool composition)
	{
		bool flag = false;
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			flag |= value.UpdateVisible();
			flag |= value.UpdateEnabled();
			flag |= value.UpdateChecked();
			value.DrawButtonSpecOnComposition = composition;
		}
		return flag;
	}

	public bool ProcessMnemonic(char charCode)
	{
		if (UseMnemonic)
		{
			foreach (ButtonSpecView value in _specLookup.Values)
			{
				if (value.ViewCenter.Visible && value.ViewButton.Enabled && (Control.IsMnemonic(charCode, value.ButtonSpec.GetShortText(_redirector)) || Control.IsMnemonic(charCode, value.ButtonSpec.GetLongText(_redirector))))
				{
					value.ButtonSpec.PerformClick();
					return true;
				}
			}
		}
		return false;
	}

	public void SetDockerMetrics(ViewBase viewDocker, IPaletteMetric viewMetric)
	{
		if (_viewMetrics == null)
		{
			return;
		}
		int num = DockerIndex(viewDocker);
		if (num < 0)
		{
			return;
		}
		_viewMetrics[num] = viewMetric;
		foreach (ViewLayoutMetricSpacer item in _viewSpacers[num])
		{
			item.SetMetrics(viewMetric);
		}
		PerformNeedPaint(needLayout: true);
	}

	public void SetDockerMetrics(ViewBase viewDocker, IPaletteMetric viewMetric, PaletteMetricInt viewMetricInt, PaletteMetricPadding viewMetricPadding)
	{
		if (_viewMetrics == null)
		{
			return;
		}
		int num = DockerIndex(viewDocker);
		if (num >= 0)
		{
			_viewMetrics[num] = viewMetric;
			_viewMetricPaddings[num] = viewMetricPadding;
			foreach (ViewLayoutMetricSpacer item in _viewSpacers[num])
			{
				item.SetMetrics(viewMetric, viewMetricInt);
			}
			PerformNeedPaint(needLayout: true);
		}
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (value.ViewCenter.Parent == viewDocker)
			{
				value.ViewCenter.MetricPadding = viewMetricPadding;
			}
		}
	}

	public Rectangle GetButtonRectangle(ButtonSpec buttonSpec)
	{
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (value.ButtonSpec == buttonSpec)
			{
				return value.ViewButton.ClientRectangle;
			}
		}
		return Rectangle.Empty;
	}

	public ButtonSpec ButtonSpecFromView(ViewBase element)
	{
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (value.ViewCenter.ContainsRecurse(element))
			{
				return value.ButtonSpec;
			}
		}
		return null;
	}

	public bool DesignerGetHitTest(Point pt)
	{
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (value.ViewButton.Visible && value.ViewButton.Enabled && value.ViewButton.ClientRectangle.Contains(pt))
			{
				return true;
			}
		}
		return false;
	}

	public ToolStripRenderer RenderToolStrip()
	{
		return _getRenderer();
	}

	public void PerformNeedPaint(bool needLayout)
	{
		PerformNeedPaint(this, needLayout);
	}

	public void PerformNeedPaint(object sender, bool needLayout)
	{
		OnNeedPaint(sender, needLayout);
	}

	public virtual ButtonSpec GetButtonSpecFromView(ViewDrawButton viewButton)
	{
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (value.ViewButton == viewButton)
			{
				return value.ButtonSpec;
			}
		}
		return null;
	}

	public virtual ViewDrawButton GetFirstVisibleViewButton(PaletteRelativeEdgeAlign align)
	{
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (value.ViewCenter.Visible && value.ViewButton.Enabled && value.ButtonSpec.Edge == align)
			{
				return value.ViewButton;
			}
		}
		return null;
	}

	public virtual ViewDrawButton GetNextVisibleViewButton(PaletteRelativeEdgeAlign align, ViewDrawButton current)
	{
		bool flag = false;
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			if (!flag)
			{
				flag = value.ViewButton == current;
			}
			else if (value.ViewCenter.Visible && value.ViewButton.Enabled && value.ButtonSpec.Edge == align)
			{
				return value.ViewButton;
			}
		}
		return null;
	}

	public virtual ViewDrawButton GetPreviousVisibleViewButton(PaletteRelativeEdgeAlign align, ViewDrawButton current)
	{
		ButtonSpecView[] array = new ButtonSpecView[_specLookup.Count];
		_specLookup.Values.CopyTo(array, 0);
		bool flag = false;
		for (int num = _specLookup.Count - 1; num >= 0; num--)
		{
			ButtonSpecView buttonSpecView = array[num];
			if (!flag)
			{
				flag = buttonSpecView.ViewButton == current;
			}
			else if (buttonSpecView.ViewCenter.Visible && buttonSpecView.ViewButton.Enabled && buttonSpecView.ButtonSpec.Edge == align)
			{
				return buttonSpecView.ViewButton;
			}
		}
		return null;
	}

	public virtual ViewDrawButton GetLastVisibleViewButton(PaletteRelativeEdgeAlign align)
	{
		ButtonSpecView[] array = new ButtonSpecView[_specLookup.Count];
		_specLookup.Values.CopyTo(array, 0);
		for (int num = _specLookup.Count - 1; num >= 0; num--)
		{
			ButtonSpecView buttonSpecView = array[num];
			if (buttonSpecView.ViewCenter.Visible && buttonSpecView.ViewButton.Enabled && buttonSpecView.ButtonSpec.Edge == align)
			{
				return buttonSpecView.ViewButton;
			}
		}
		return null;
	}

	public virtual PaletteRedirect CreateButtonSpecRemap(PaletteRedirect redirector, ButtonSpec buttonSpec)
	{
		return new ButtonSpecRemapByContentView(redirector, buttonSpec);
	}

	protected abstract int DockerIndex(ViewBase viewDocker);

	protected abstract ViewBase IndexDocker(int i);

	protected abstract VisualOrientation DockerOrientation(int i);

	protected abstract ViewDrawContent GetDockerForeground(int i);

	protected abstract void AddViewToDocker(int i, ViewDockStyle dockStyle, ViewBase view, bool usingSpacers);

	protected abstract void AddSpacersToDocker(int i, ViewLayoutMetricSpacer spacerL, ViewLayoutMetricSpacer spacerR);

	protected virtual void ButtonSpecCreated(ButtonSpec buttonSpec, ButtonSpecView buttonView, int viewDockerIndex)
	{
		ButtonSpecRemapByContentView buttonSpecRemapByContentView = (ButtonSpecRemapByContentView)buttonView.RemapPalette;
		buttonSpecRemapByContentView.Foreground = GetDockerForeground(viewDockerIndex);
	}

	protected virtual ButtonSpecView CreateButtonSpecView(PaletteRedirect redirector, IPaletteMetric viewPaletteMetric, PaletteMetricPadding viewMetricPadding, ButtonSpec buttonSpec)
	{
		return new ButtonSpecView(redirector, viewPaletteMetric, viewMetricPadding, this, buttonSpec);
	}

	protected virtual void OnNeedPaint(object sender, bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(sender, new NeedLayoutEventArgs(needLayout));
		}
	}

	private void RecreateAll()
	{
		RemoveAll();
		CreateAll();
	}

	private void RemoveAll()
	{
		foreach (ButtonSpecView value in _specLookup.Values)
		{
			RemoveButtonSpec(value.ButtonSpec);
		}
		_specLookup.Clear();
	}

	private void CreateAll()
	{
		int[] nearCounts = new int[DockerCount];
		int[] farCounts = new int[DockerCount];
		CreateFromCollection(_variableSpecs, ref nearCounts, ref farCounts);
		CreateFromCollection(_fixedSpecs, ref nearCounts, ref farCounts);
		if (_viewMetrics == null)
		{
			return;
		}
		for (int i = 0; i < _viewMetrics.Length; i++)
		{
			ViewBase viewBase = IndexDocker(i);
			bool visible = farCounts[i] > 0;
			bool visible2 = nearCounts[i] > 0;
			_viewSpacers[i][0].Visible = visible2;
			_viewSpacers[i][1].Visible = visible;
			if (UseInsideSpacers)
			{
				_viewSpacers[i][2].Visible = visible2;
				_viewSpacers[i][3].Visible = visible;
			}
		}
	}

	private void CreateFromCollection(ButtonSpecCollectionBase specs, ref int[] nearCounts, ref int[] farCounts)
	{
		if (specs == null)
		{
			return;
		}
		foreach (ButtonSpec item in specs.Enumerate())
		{
			ButtonSpecView buttonSpecView = AddButtonSpec(item);
			if (buttonSpecView != null && item.GetVisible(_redirector))
			{
				int targetDockerIndex = GetTargetDockerIndex(item.GetLocation(_redirector));
				if (item.GetEdge(_redirector) == RelativeEdgeAlign.Far)
				{
					farCounts[targetDockerIndex]++;
				}
				else
				{
					nearCounts[targetDockerIndex]++;
				}
			}
		}
	}

	private ButtonSpecView AddButtonSpec(ButtonSpec buttonSpec)
	{
		int targetDockerIndex = GetTargetDockerIndex(buttonSpec.GetLocation(_redirector));
		IPaletteMetric paletteMetric = null;
		PaletteMetricPadding paletteMetricPadding = PaletteMetricPadding.None;
		if (_viewMetrics != null && _viewMetrics.Length > targetDockerIndex && _viewMetricPaddings.Length > targetDockerIndex)
		{
			paletteMetric = _viewMetrics[targetDockerIndex];
			paletteMetricPadding = _viewMetricPaddings[targetDockerIndex];
			ButtonSpecView buttonSpecView = CreateButtonSpecView(_redirector, paletteMetric, paletteMetricPadding, buttonSpec);
			_specLookup.Add(buttonSpec, buttonSpecView);
			buttonSpecView.ViewButton.Orientation = CalculateOrientation(DockerOrientation(targetDockerIndex), buttonSpec.GetOrientation(_redirector));
			buttonSpecView.ViewCenter.Orientation = DockerOrientation(targetDockerIndex);
			AddViewToDocker(targetDockerIndex, GetDockStyle(buttonSpec), buttonSpecView.ViewCenter, _viewMetrics != null);
			ButtonSpecCreated(buttonSpec, buttonSpecView, targetDockerIndex);
			buttonSpec.ButtonSpecPropertyChanged += OnPropertyChanged;
			return buttonSpecView;
		}
		return null;
	}

	private void RemoveButtonSpec(ButtonSpec buttonSpec)
	{
		buttonSpec.ButtonSpecPropertyChanged -= OnPropertyChanged;
		ButtonSpecView buttonSpecView = _specLookup[buttonSpec];
		if (buttonSpecView != null)
		{
			if (buttonSpecView.ViewCenter.Parent != null && buttonSpecView.ViewCenter.Parent.Contains(buttonSpecView.ViewCenter))
			{
				buttonSpecView.ViewCenter.Parent.Remove(buttonSpecView.ViewCenter);
			}
			buttonSpecView.Destruct();
		}
	}

	private void OnButtonSpecInserted(object sender, ButtonSpecEventArgs e)
	{
		RecreateAll();
		PerformNeedPaint(needLayout: true);
	}

	private void OnButtonSpecRemoved(object sender, ButtonSpecEventArgs e)
	{
		RecreateAll();
		PerformNeedPaint(needLayout: true);
	}

	private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Edge":
		case "Location":
		case "Orientation":
		case "Type":
			RecreateAll();
			PerformNeedPaint(needLayout: true);
			break;
		}
	}

	private int GetTargetDockerIndex(HeaderLocation location)
	{
		switch (location)
		{
		case HeaderLocation.PrimaryHeader:
			return 0;
		case HeaderLocation.SecondaryHeader:
			return 1;
		default:
			Debug.Assert(condition: false);
			return -1;
		}
	}

	private ViewDockStyle GetDockStyle(ButtonSpec spec)
	{
		return (spec.GetEdge(_redirector) == RelativeEdgeAlign.Near) ? ViewDockStyle.Left : ViewDockStyle.Right;
	}

	private VisualOrientation CalculateOrientation(VisualOrientation viewOrientation, ButtonOrientation buttonOrientation)
	{
		return buttonOrientation switch
		{
			ButtonOrientation.FixedBottom => VisualOrientation.Bottom, 
			ButtonOrientation.FixedLeft => VisualOrientation.Left, 
			ButtonOrientation.FixedRight => VisualOrientation.Right, 
			ButtonOrientation.FixedTop => VisualOrientation.Top, 
			_ => viewOrientation, 
		};
	}
}
