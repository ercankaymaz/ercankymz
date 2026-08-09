using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonListBox), "ToolboxBitmaps.KryptonListBox.bmp")]
[DefaultEvent("SelectedIndexChanged")]
[DefaultProperty("Items")]
[DefaultBindingProperty("SelectedValue")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonListBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Represents a list box control that allows single or multiple item selection.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonListBox : VisualControlBase, IContainedInputControl
{
	private class InternalListBox : ListBox
	{
		private ViewManager _viewManager;

		private ViewDrawPanel _drawPanel;

		private KryptonListBox _kryptonListBox;

		private IntPtr _screenDC;

		private bool _mouseOver;

		private int _mouseIndex;

		public ViewDrawPanel ViewDrawPanel => _drawPanel;

		public int MouseIndex => _mouseIndex;

		public bool MouseOver
		{
			get
			{
				return _mouseOver;
			}
			set
			{
				if (_mouseOver != value)
				{
					_mouseOver = value;
					if (_mouseOver)
					{
						OnTrackMouseEnter(EventArgs.Empty);
						return;
					}
					OnTrackMouseLeave(EventArgs.Empty);
					_mouseIndex = -1;
				}
			}
		}

		public override DrawMode DrawMode
		{
			get
			{
				return DrawMode.OwnerDrawVariable;
			}
			set
			{
			}
		}

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public InternalListBox(KryptonListBox kryptonListBox)
		{
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			_kryptonListBox = kryptonListBox;
			_mouseIndex = -1;
			_drawPanel = new ViewDrawPanel();
			_viewManager = new ViewManager(this, _drawPanel);
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
			base.IntegralHeight = false;
			base.MultiColumn = false;
			base.DrawMode = DrawMode.OwnerDrawVariable;
			_screenDC = PI.CreateCompatibleDC(IntPtr.Zero);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (_screenDC != IntPtr.Zero)
			{
				PI.DeleteDC(_screenDC);
			}
		}

		public void Recreate()
		{
			RecreateHandle();
		}

		public void RefreshItemSizes()
		{
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.DrawMode = DrawMode.OwnerDrawVariable;
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			base.OnLayout(levent);
			using ViewLayoutContext context = new ViewLayoutContext(_viewManager, this, _kryptonListBox, _kryptonListBox.Renderer);
			_drawPanel.Layout(context);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 20:
				break;
			case 15:
			case 792:
				WmPaint(ref m);
				break;
			case 276:
			case 277:
			case 522:
				Invalidate();
				base.WndProc(ref m);
				break;
			case 675:
				MouseOver = false;
				_kryptonListBox.PerformNeedPaint(needLayout: true);
				Invalidate();
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonListBox.PerformNeedPaint(needLayout: true);
					Invalidate();
				}
				else
				{
					Point point = new Point((int)m.LParam.ToInt64());
					int num = IndexFromPoint(point);
					if (num >= 0 && num < base.Items.Count && !GetItemRectangle(num).Contains(point))
					{
						num = -1;
					}
					if (_mouseIndex != num)
					{
						Invalidate();
						_mouseIndex = num;
					}
				}
				base.WndProc(ref m);
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		protected virtual void OnTrackMouseEnter(EventArgs e)
		{
			if (this.TrackMouseEnter != null)
			{
				this.TrackMouseEnter(this, e);
			}
		}

		protected virtual void OnTrackMouseLeave(EventArgs e)
		{
			if (this.TrackMouseLeave != null)
			{
				this.TrackMouseLeave(this, e);
			}
		}

		private void WmPaint(ref Message m)
		{
			PI.PAINTSTRUCT ps = default(PI.PAINTSTRUCT);
			IntPtr intPtr = ((!(m.WParam == IntPtr.Zero)) ? m.WParam : PI.BeginPaint(base.Handle, ref ps));
			Rectangle rectangle = CommonHelper.RealClientRectangle(base.Handle);
			if (rectangle.Width > 0 && rectangle.Height > 0)
			{
				IntPtr intPtr2 = PI.CreateCompatibleBitmap(intPtr, rectangle.Width, rectangle.Height);
				if (intPtr2 != IntPtr.Zero)
				{
					try
					{
						PI.SelectObject(_screenDC, intPtr2);
						using (Graphics graphics = Graphics.FromHdc(_screenDC))
						{
							using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(this, _kryptonListBox.Renderer))
							{
								viewLayoutContext.DisplayRectangle = rectangle;
								_drawPanel.Layout(viewLayoutContext);
							}
							using (RenderContext context = new RenderContext(this, _kryptonListBox, graphics, rectangle, _kryptonListBox.Renderer))
							{
								_drawPanel.Render(context);
							}
							IntPtr wParam = m.WParam;
							m.WParam = _screenDC;
							DefWndProc(ref m);
							m.WParam = wParam;
							if (base.Items.Count == 0)
							{
								using RenderContext context2 = new RenderContext(this, _kryptonListBox, graphics, rectangle, _kryptonListBox.Renderer);
								_drawPanel.Render(context2);
							}
						}
						PI.BitBlt(intPtr, 0, 0, rectangle.Width, rectangle.Height, _screenDC, 0, 0, 13369376);
						if (base.Items.Count == 0)
						{
							using Graphics graphics2 = Graphics.FromHdc(intPtr);
							using RenderContext context3 = new RenderContext(this, _kryptonListBox, graphics2, rectangle, _kryptonListBox.Renderer);
							_drawPanel.Render(context3);
						}
					}
					finally
					{
						PI.DeleteObject(intPtr2);
					}
				}
			}
			if (m.WParam == IntPtr.Zero)
			{
				PI.EndPaint(base.Handle, ref ps);
			}
		}
	}

	private PaletteListStateRedirect _stateCommon;

	private PaletteListState _stateDisabled;

	private PaletteListState _stateNormal;

	private PaletteDouble _stateActive;

	private PaletteListItemTriple _stateTracking;

	private PaletteListItemTriple _statePressed;

	private PaletteListItemTriple _stateCheckedNormal;

	private PaletteListItemTriple _stateCheckedTracking;

	private PaletteListItemTriple _stateCheckedPressed;

	private PaletteListItemTripleRedirect _stateFocus;

	private PaletteTripleOverride _overrideNormal;

	private PaletteTripleOverride _overrideTracking;

	private PaletteTripleOverride _overridePressed;

	private PaletteTripleOverride _overrideCheckedNormal;

	private PaletteTripleOverride _overrideCheckedTracking;

	private PaletteTripleOverride _overrideCheckedPressed;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private ViewDrawButton _drawButton;

	private InternalListBox _listBox;

	private FixedContentValue _contentValues;

	private bool? _fixedActive;

	private ButtonStyle _style;

	private IntPtr _screenDC;

	private int[] _lastSelectedColl;

	private int _lastSelectedIndex;

	private bool _mouseOver;

	private bool _alwaysActive;

	private bool _forcedLayout;

	private bool _trackingMouseEnter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public ListBox ListBox => _listBox;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => ListBox;

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[DefaultValue(typeof(Padding), "1,1,1,1")]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
			_layoutFill.DisplayPadding = value;
			PerformNeedPaint(needLayout: true);
		}
	}

	[Bindable(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectedIndex
	{
		get
		{
			return _listBox.SelectedIndex;
		}
		set
		{
			_listBox.SelectedIndex = value;
		}
	}

	[Category("Data")]
	[Bindable(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(null)]
	public object SelectedValue
	{
		get
		{
			return _listBox.SelectedValue;
		}
		set
		{
			_listBox.SelectedValue = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ListBox.SelectedIndexCollection SelectedIndices => _listBox.SelectedIndices;

	[Bindable(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object SelectedItem
	{
		get
		{
			return _listBox.SelectedItem;
		}
		set
		{
			_listBox.SelectedItem = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ListBox.SelectedObjectCollection SelectedItems => _listBox.SelectedItems;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TopIndex
	{
		get
		{
			return _listBox.TopIndex;
		}
		set
		{
			_listBox.TopIndex = value;
		}
	}

	[Category("Visuals")]
	[Description("Item style.")]
	public ButtonStyle ItemStyle
	{
		get
		{
			return _style;
		}
		set
		{
			if (_style != value)
			{
				_style = value;
				_stateCommon.Item.SetStyles(_style);
				_stateFocus.Item.SetStyles(_style);
				_listBox.Recreate();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("The width, in pixels, by which a list box can be scrolled horizontally. Only valid HorizontalScrollbar is true.")]
	[Localizable(true)]
	[DefaultValue(0)]
	public virtual int HorizontalExtent
	{
		get
		{
			return _listBox.HorizontalExtent;
		}
		set
		{
			_listBox.HorizontalExtent = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the KryptonListBox will display a horizontal scrollbar for items beyond the right edge of the KryptonListBox.")]
	[Localizable(true)]
	[DefaultValue(false)]
	public virtual bool HorizontalScrollbar
	{
		get
		{
			return _listBox.HorizontalScrollbar;
		}
		set
		{
			_listBox.HorizontalScrollbar = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the list box should always have a scroll bar present, regardless of how many items are present.")]
	[Localizable(true)]
	[DefaultValue(false)]
	public virtual bool ScrollAlwaysVisible
	{
		get
		{
			return _listBox.ScrollAlwaysVisible;
		}
		set
		{
			_listBox.ScrollAlwaysVisible = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the list box is to be single-select, multi-select or not selectable.")]
	[DefaultValue(typeof(SelectionMode), "One")]
	public virtual SelectionMode SelectionMode
	{
		get
		{
			return _listBox.SelectionMode;
		}
		set
		{
			_listBox.SelectionMode = value;
		}
	}

	[Category("Behavior")]
	[Description("Controls whether the list is sorted.")]
	[DefaultValue(false)]
	public virtual bool Sorted
	{
		get
		{
			return _listBox.Sorted;
		}
		set
		{
			_listBox.Sorted = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the property to use as the actual value of the items in the control.")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public virtual string ValueMember
	{
		get
		{
			return _listBox.ValueMember;
		}
		set
		{
			_listBox.ValueMember = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the list that this control will use to gets its items.")]
	[AttributeProvider(typeof(IListSource))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(null)]
	public virtual object DataSource
	{
		get
		{
			return _listBox.DataSource;
		}
		set
		{
			_listBox.DataSource = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the property to display for the items in this control.")]
	[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public virtual string DisplayMember
	{
		get
		{
			return _listBox.DisplayMember;
		}
		set
		{
			_listBox.DisplayMember = value;
		}
	}

	[Category("Data")]
	[Description("The items in the KryptonListBox.")]
	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[MergableProperty(false)]
	[Localizable(true)]
	public virtual ListBox.ObjectCollection Items => _listBox.Items;

	[Description("The format specifier characters that indicate how a value is to be displayed.")]
	[Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[MergableProperty(false)]
	[DefaultValue("")]
	public string FormatString
	{
		get
		{
			return _listBox.FormatString;
		}
		set
		{
			_listBox.FormatString = value;
		}
	}

	[Description("If this property is true, the value of FormatString is used to convert the value of DisplayMember into a value that can be displayed.")]
	[DefaultValue(false)]
	public bool FormattingEnabled
	{
		get
		{
			return _listBox.FormattingEnabled;
		}
		set
		{
			_listBox.FormattingEnabled = value;
		}
	}

	[Category("Visuals")]
	[Description("Style used to draw the background.")]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				_listBox.Recreate();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Style used to draw the border.")]
	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _stateCommon.BorderStyle;
		}
		set
		{
			if (_stateCommon.BorderStyle != value)
			{
				_stateCommon.BorderStyle = value;
				_listBox.Recreate();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining item appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListItemTripleRedirect OverrideFocus => _stateFocus;

	[Category("Visuals")]
	[Description("Overrides for defining common appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListStateRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListState StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListState StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining active appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateActive => _stateActive;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListItemTriple StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListItemTriple StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining normal checked item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListItemTriple StateCheckedNormal => _stateCheckedNormal;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking checked item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListItemTriple StateCheckedTracking => _stateCheckedTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed checked item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteListItemTriple StateCheckedPressed => _stateCheckedPressed;

	[Category("Visuals")]
	[Description("Determines if the control is always active or only when the mouse is over the control or has focus.")]
	[DefaultValue(true)]
	public bool AlwaysActive
	{
		get
		{
			return _alwaysActive;
		}
		set
		{
			if (_alwaysActive != value)
			{
				_alwaysActive = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsActive
	{
		get
		{
			if (_fixedActive.HasValue)
			{
				return _fixedActive.Value;
			}
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _listBox.MouseOver;
		}
	}

	protected override Size DefaultSize => new Size(120, 96);

	[Description("Occurs when the value of the DataSource property changes.")]
	[Category("Property Changed")]
	public event EventHandler DataSourceChanged;

	[Description("Occurs when the value of the DisplayMember property changes.")]
	[Category("Property Changed")]
	public event EventHandler DisplayMemberChanged;

	[Description("Occurs when the property of a control is bound to a data value.")]
	[Category("Property Changed")]
	public event EventHandler Format;

	[Description("Occurs when the value of the FormatInfo property changes.")]
	[Category("Property Changed")]
	public event EventHandler FormatInfoChanged;

	[Description("Occurs when the value of the FormatString property changes.")]
	[Category("Property Changed")]
	public event EventHandler FormatStringChanged;

	[Description("Occurs when the value of the FormattingEnabled property changes.")]
	[Category("Property Changed")]
	public event EventHandler FormattingEnabledChanged;

	[Description("Occurs when the value of the SelectedValue property changes.")]
	[Category("Property Changed")]
	public event EventHandler SelectedValueChanged;

	[Description("Occurs when the value of the SelectedIndex property changes.")]
	[Category("Behavior")]
	public event EventHandler SelectedIndexChanged;

	[Description("Occurs when the value of the ValueMember property changes.")]
	[Category("Property Changed")]
	public event EventHandler ValueMemberChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackColorChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler ForeColorChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler PaddingChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event PaintEventHandler Paint;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler TextChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler TrackMouseEnter;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler TrackMouseLeave;

	public KryptonListBox()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.StandardClick | ControlStyles.Selectable, value: false);
		_alwaysActive = true;
		_lastSelectedIndex = -1;
		_style = ButtonStyle.ListItem;
		base.Padding = new Padding(1);
		_stateCommon = new PaletteListStateRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateFocus = new PaletteListItemTripleRedirect(base.Redirector, PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem, base.NeedPaintDelegate);
		_stateDisabled = new PaletteListState(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteDouble(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteListState(_stateCommon, base.NeedPaintDelegate);
		_stateTracking = new PaletteListItemTriple(_stateCommon.Item, base.NeedPaintDelegate);
		_statePressed = new PaletteListItemTriple(_stateCommon.Item, base.NeedPaintDelegate);
		_stateCheckedNormal = new PaletteListItemTriple(_stateCommon.Item, base.NeedPaintDelegate);
		_stateCheckedTracking = new PaletteListItemTriple(_stateCommon.Item, base.NeedPaintDelegate);
		_stateCheckedPressed = new PaletteListItemTriple(_stateCommon.Item, base.NeedPaintDelegate);
		_overrideNormal = new PaletteTripleOverride(_stateFocus.Item, _stateNormal.Item, PaletteState.FocusOverride);
		_overrideTracking = new PaletteTripleOverride(_stateFocus.Item, _stateTracking.Item, PaletteState.FocusOverride);
		_overridePressed = new PaletteTripleOverride(_stateFocus.Item, _statePressed.Item, PaletteState.FocusOverride);
		_overrideCheckedNormal = new PaletteTripleOverride(_stateFocus.Item, _stateCheckedNormal.Item, PaletteState.FocusOverride);
		_overrideCheckedTracking = new PaletteTripleOverride(_stateFocus.Item, _stateCheckedTracking.Item, PaletteState.FocusOverride);
		_overrideCheckedPressed = new PaletteTripleOverride(_stateFocus.Item, _stateCheckedPressed.Item, PaletteState.FocusOverride);
		_contentValues = new FixedContentValue();
		_drawButton = new ViewDrawButton(StateDisabled.Item, _overrideNormal, _overrideTracking, _overridePressed, _overrideCheckedNormal, _overrideCheckedTracking, _overrideCheckedPressed, new PaletteMetricRedirect(base.Redirector), _contentValues, VisualOrientation.Top, useMnemonic: false);
		_listBox = new InternalListBox(this);
		_listBox.DrawItem += OnListBoxDrawItem;
		_listBox.MeasureItem += OnListBoxMeasureItem;
		_listBox.TrackMouseEnter += OnListBoxMouseChange;
		_listBox.TrackMouseLeave += OnListBoxMouseChange;
		_listBox.DataSourceChanged += OnListBoxDataSourceChanged;
		_listBox.DisplayMemberChanged += OnListBoxDisplayMemberChanged;
		_listBox.ValueMemberChanged += OnListBoxValueMemberChanged;
		_listBox.SelectedIndexChanged += OnListBoxSelectedIndexChanged;
		_listBox.SelectedValueChanged += OnListBoxSelectedValueChanged;
		_listBox.DisplayMemberChanged += OnListBoxDisplayMemberChanged;
		_listBox.Format += OnListBoxFormat;
		_listBox.FormatInfoChanged += OnListBoxFormatInfoChanged;
		_listBox.FormatStringChanged += OnListBoxFormatStringChanged;
		_listBox.FormattingEnabledChanged += OnListBoxFormattingEnabledChanged;
		_listBox.GotFocus += OnListBoxGotFocus;
		_listBox.LostFocus += OnListBoxLostFocus;
		_listBox.KeyDown += OnListBoxKeyDown;
		_listBox.KeyUp += OnListBoxKeyUp;
		_listBox.KeyPress += OnListBoxKeyPress;
		_listBox.PreviewKeyDown += OnListBoxPreviewKeyDown;
		_listBox.Validating += OnListBoxValidating;
		_listBox.Validated += OnListBoxValidated;
		_layoutFill = new ViewLayoutFill(_listBox);
		_layoutFill.DisplayPadding = new Padding(1);
		_drawDockerInner = new ViewLayoutDocker();
		_drawDockerInner.Add(_layoutFill, ViewDockStyle.Fill);
		_drawDockerOuter = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border);
		_drawDockerOuter.Add(_drawDockerInner, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDockerOuter);
		_screenDC = PI.CreateCompatibleDC(IntPtr.Zero);
		((KryptonReadOnlyControls)base.Controls).AddInternal(_listBox);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (_screenDC != IntPtr.Zero)
		{
			PI.DeleteDC(_screenDC);
		}
	}

	private bool ShouldSerializeItemStyle()
	{
		return ItemStyle != ButtonStyle.ListItem;
	}

	private void ResetItemStyle()
	{
		ItemStyle = ButtonStyle.ListItem;
	}

	private bool ShouldSerializeBackStyle()
	{
		return BackStyle != PaletteBackStyle.InputControlStandalone;
	}

	private void ResetBackStyle()
	{
		BackStyle = PaletteBackStyle.InputControlStandalone;
	}

	private bool ShouldSerializeBorderStyle()
	{
		return BorderStyle != PaletteBorderStyle.InputControlStandalone;
	}

	private void ResetBorderStyle()
	{
		BorderStyle = PaletteBorderStyle.InputControlStandalone;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
	}

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedPressed()
	{
		return !_stateCheckedPressed.IsDefault;
	}

	public void ClearSelected()
	{
		_listBox.ClearSelected();
	}

	public int FindString(string str)
	{
		return _listBox.FindString(str);
	}

	public int FindString(string str, int startIndex)
	{
		return _listBox.FindString(str, startIndex);
	}

	public int FindStringExact(string str)
	{
		return _listBox.FindStringExact(str);
	}

	public int FindStringExact(string str, int startIndex)
	{
		return _listBox.FindStringExact(str, startIndex);
	}

	public int GetItemHeight(int index)
	{
		return _listBox.GetItemHeight(index);
	}

	public Rectangle GetItemRectangle(int index)
	{
		return _listBox.GetItemRectangle(index);
	}

	public bool GetSelected(int index)
	{
		return _listBox.GetSelected(index);
	}

	public int IndexFromPoint(Point p)
	{
		return _listBox.IndexFromPoint(p);
	}

	public int IndexFromPoint(int x, int y)
	{
		return _listBox.IndexFromPoint(x, y);
	}

	public void SetSelected(int index, bool value)
	{
		_listBox.SetSelected(index, value);
	}

	public string GetItemText(object item)
	{
		return _listBox.GetItemText(item);
	}

	public void BeginUpdate()
	{
		_listBox.BeginUpdate();
	}

	public void EndUpdate()
	{
		_listBox.EndUpdate();
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (ListBox != null)
		{
			return ListBox.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (ListBox != null)
		{
			ListBox.Select();
		}
	}

	protected void ForceControlLayout()
	{
		if (!base.IsHandleCreated)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
		}
	}

	protected virtual void OnDataSourceChanged(EventArgs e)
	{
		if (this.DataSourceChanged != null)
		{
			this.DataSourceChanged(this, e);
		}
	}

	protected virtual void OnDisplayMemberChanged(EventArgs e)
	{
		if (this.DisplayMemberChanged != null)
		{
			this.DisplayMemberChanged(this, e);
		}
	}

	protected virtual void OnValueMemberChanged(EventArgs e)
	{
		if (this.ValueMemberChanged != null)
		{
			this.ValueMemberChanged(this, e);
		}
	}

	protected virtual void OnSelectedIndexChanged(EventArgs e)
	{
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, e);
		}
	}

	protected virtual void OnSelectedValueChanged(EventArgs e)
	{
		if (this.SelectedValueChanged != null)
		{
			this.SelectedValueChanged(this, e);
		}
	}

	protected virtual void OnFormat(ListControlConvertEventArgs e)
	{
		if (this.Format != null)
		{
			this.Format(this, e);
		}
	}

	protected virtual void OnFormatInfoChanged(EventArgs e)
	{
		if (this.FormatInfoChanged != null)
		{
			this.FormatInfoChanged(this, e);
		}
	}

	protected virtual void OnFormatStringChanged(EventArgs e)
	{
		if (this.FormatStringChanged != null)
		{
			this.FormatStringChanged(this, e);
		}
	}

	protected virtual void OnFormattingEnabledChanged(EventArgs e)
	{
		if (this.FormattingEnabledChanged != null)
		{
			this.FormattingEnabledChanged(this, e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnPaletteChanged(EventArgs e)
	{
		_listBox.Recreate();
		_listBox.RefreshItemSizes();
		_listBox.Invalidate();
		base.OnPaletteChanged(e);
	}

	protected override void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		_listBox.RefreshItemSizes();
		base.OnPaletteChanged(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		if (this.BackColorChanged != null)
		{
			this.BackColorChanged(this, e);
		}
	}

	protected override void OnBackgroundImageChanged(EventArgs e)
	{
		if (this.BackgroundImageChanged != null)
		{
			this.BackgroundImageChanged(this, e);
		}
	}

	protected override void OnBackgroundImageLayoutChanged(EventArgs e)
	{
		if (this.BackgroundImageLayoutChanged != null)
		{
			this.BackgroundImageLayoutChanged(this, e);
		}
	}

	protected override void OnForeColorChanged(EventArgs e)
	{
		if (this.ForeColorChanged != null)
		{
			this.ForeColorChanged(this, e);
		}
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		if (this.PaddingChanged != null)
		{
			this.PaddingChanged(this, e);
		}
	}

	protected override void OnTabStopChanged(EventArgs e)
	{
		ListBox.TabStop = base.TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		ListBox.CausesValidation = base.CausesValidation;
		base.OnCausesValidationChanged(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (this.Paint != null)
		{
			this.Paint(this, e);
		}
		base.OnPaint(e);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, e);
		}
	}

	protected virtual void OnTrackMouseEnter(EventArgs e)
	{
		if (this.TrackMouseEnter != null)
		{
			this.TrackMouseEnter(this, e);
		}
	}

	protected virtual void OnTrackMouseLeave(EventArgs e)
	{
		if (this.TrackMouseLeave != null)
		{
			this.TrackMouseLeave(this, e);
		}
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		PerformNeedPaint(needLayout: false);
		InvokeLayout();
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsHandleCreated && !e.NeedLayout)
		{
			_listBox.Invalidate();
		}
		else
		{
			ForceControlLayout();
		}
		UpdateStateAndPalettes();
		base.OnNeedPaint(sender, e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		if (base.IsHandleCreated || _forcedLayout || (base.DesignMode && _listBox != null))
		{
			Rectangle fillRect = _layoutFill.FillRect;
			_listBox.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		_listBox.Invalidate();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		_listBox.Invalidate();
		base.OnMouseLeave(e);
	}

	private void UpdateStateAndPalettes()
	{
		if (!base.IsDisposed)
		{
			IPaletteDouble doubleState = GetDoubleState();
			_listBox.ViewDrawPanel.SetPalettes(doubleState.PaletteBack);
			_drawDockerOuter.SetPalettes(doubleState.PaletteBack, doubleState.PaletteBorder);
			_drawDockerOuter.Enabled = base.Enabled;
			PaletteState elementState = (IsActive ? PaletteState.Tracking : ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal));
			_listBox.ViewDrawPanel.ElementState = elementState;
			_drawDockerOuter.ElementState = elementState;
		}
	}

	private IPaletteDouble GetDoubleState()
	{
		if (base.Enabled)
		{
			if (IsActive)
			{
				return _stateActive;
			}
			return _stateNormal;
		}
		return _stateDisabled;
	}

	private void OnListBoxDrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index < 0)
		{
			return;
		}
		UpdateContentFromItemIndex(e.Index);
		PaletteState elementState = PaletteState.Normal;
		if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
		{
			elementState = PaletteState.Disabled;
		}
		else
		{
			bool flag = e.Index >= 0 && e.Index == _listBox.MouseIndex;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && SelectionMode != SelectionMode.None)
			{
				_drawButton.Checked = true;
				elementState = (flag ? PaletteState.CheckedTracking : PaletteState.CheckedNormal);
			}
			else
			{
				_drawButton.Checked = false;
				if (flag)
				{
					elementState = PaletteState.Tracking;
				}
			}
			bool apply = false;
			if ((e.State & DrawItemState.Focus) == DrawItemState.Focus && (e.State & DrawItemState.NoFocusRect) != DrawItemState.NoFocusRect)
			{
				apply = true;
			}
			_overrideNormal.Apply = apply;
			_overrideTracking.Apply = apply;
			_overridePressed.Apply = apply;
			_overrideCheckedTracking.Apply = apply;
			_overrideCheckedNormal.Apply = apply;
			_overrideCheckedPressed.Apply = apply;
		}
		_drawButton.ElementState = elementState;
		IntPtr hdc = e.Graphics.GetHdc();
		try
		{
			IntPtr intPtr = PI.CreateCompatibleBitmap(hdc, e.Bounds.Right, e.Bounds.Bottom);
			if (!(intPtr != IntPtr.Zero))
			{
				return;
			}
			try
			{
				PI.SelectObject(_screenDC, intPtr);
				using Graphics graphics = Graphics.FromHdc(_screenDC);
				using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(this, base.Renderer))
				{
					viewLayoutContext.DisplayRectangle = e.Bounds;
					_listBox.ViewDrawPanel.Layout(viewLayoutContext);
					_drawButton.Layout(viewLayoutContext);
				}
				using (RenderContext context = new RenderContext(this, graphics, e.Bounds, base.Renderer))
				{
					_listBox.ViewDrawPanel.Render(context);
					_drawButton.Render(context);
				}
				PI.BitBlt(hdc, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height, _screenDC, e.Bounds.X, e.Bounds.Y, 13369376);
			}
			finally
			{
				PI.DeleteObject(intPtr);
			}
		}
		finally
		{
			e.Graphics.ReleaseHdc();
		}
	}

	private void OnListBoxMeasureItem(object sender, MeasureItemEventArgs e)
	{
		UpdateContentFromItemIndex(e.Index);
		using ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer);
		Size preferredSize = _drawButton.GetPreferredSize(context);
		e.ItemWidth = preferredSize.Width;
		e.ItemHeight = preferredSize.Height;
	}

	private void UpdateContentFromItemIndex(int index)
	{
		if (Items[index] is IContentValues contentValues)
		{
			_contentValues.ShortText = contentValues.GetShortText();
			_contentValues.LongText = contentValues.GetLongText();
			_contentValues.Image = contentValues.GetImage(PaletteState.Normal);
			_contentValues.ImageTransparentColor = contentValues.GetImageTransparentColor(PaletteState.Normal);
		}
		else
		{
			_contentValues.ShortText = _listBox.GetItemText(Items[index]);
			_contentValues.LongText = null;
			_contentValues.Image = null;
			_contentValues.ImageTransparentColor = Color.Empty;
		}
	}

	private void OnListBoxDataSourceChanged(object sender, EventArgs e)
	{
		OnDataSourceChanged(e);
	}

	private void OnListBoxDisplayMemberChanged(object sender, EventArgs e)
	{
		OnDisplayMemberChanged(e);
	}

	private void OnListBoxValueMemberChanged(object sender, EventArgs e)
	{
		OnValueMemberChanged(e);
	}

	private void OnListBoxSelectedIndexChanged(object sender, EventArgs e)
	{
		switch (_listBox.SelectionMode)
		{
		case SelectionMode.One:
			if (_lastSelectedIndex != _listBox.SelectedIndex)
			{
				_lastSelectedIndex = _listBox.SelectedIndex;
				UpdateStateAndPalettes();
				_listBox.Invalidate();
				OnSelectedIndexChanged(e);
			}
			break;
		case SelectionMode.MultiSimple:
		case SelectionMode.MultiExtended:
			if (SelectedIndicesChanged(_lastSelectedColl, _listBox.SelectedIndices))
			{
				_lastSelectedColl = new int[_listBox.SelectedIndices.Count];
				_listBox.SelectedIndices.CopyTo(_lastSelectedColl, 0);
				UpdateStateAndPalettes();
				_listBox.Invalidate();
				OnSelectedIndexChanged(e);
			}
			break;
		}
	}

	private bool SelectedIndicesChanged(int[] left, ListBox.SelectedIndexCollection right)
	{
		if (left == null && right != null)
		{
			return true;
		}
		if (left.Length != right.Count)
		{
			return true;
		}
		for (int i = 0; i < left.Length; i++)
		{
			if (left[i] != right[i])
			{
				return true;
			}
		}
		return false;
	}

	private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		_listBox.Invalidate();
		OnSelectedValueChanged(e);
	}

	private void OnListBoxFormat(object sender, ListControlConvertEventArgs e)
	{
		OnFormat(e);
	}

	private void OnListBoxFormatInfoChanged(object sender, EventArgs e)
	{
		OnFormatInfoChanged(e);
	}

	private void OnListBoxFormatStringChanged(object sender, EventArgs e)
	{
		OnFormatStringChanged(e);
	}

	private void OnListBoxFormattingEnabledChanged(object sender, EventArgs e)
	{
		OnFormattingEnabledChanged(e);
	}

	private void OnListBoxGotFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		_listBox.Invalidate();
		PerformNeedPaint(needLayout: true);
		OnGotFocus(e);
	}

	private void OnListBoxLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		_listBox.Invalidate();
		PerformNeedPaint(needLayout: true);
		OnLostFocus(e);
	}

	private void OnListBoxKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnListBoxKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnListBoxKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnListBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnListBoxValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnListBoxValidating(object sender, CancelEventArgs e)
	{
		OnValidating(e);
	}

	private void OnListBoxMouseChange(object sender, EventArgs e)
	{
		if (_listBox.MouseOver != _trackingMouseEnter)
		{
			_trackingMouseEnter = _listBox.MouseOver;
			if (_trackingMouseEnter)
			{
				OnTrackMouseEnter(EventArgs.Empty);
			}
			else
			{
				OnTrackMouseLeave(EventArgs.Empty);
			}
		}
	}
}
