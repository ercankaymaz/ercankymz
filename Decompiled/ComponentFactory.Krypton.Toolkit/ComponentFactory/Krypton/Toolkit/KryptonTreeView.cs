using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonTreeView), "ToolboxBitmaps.KryptonTreeView.bmp")]
[DefaultEvent("AfterSelect")]
[DefaultProperty("Nodes")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonTreeViewDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Displays a hierarchical collection of labeled items, each represented by a TreeNode")]
[Docking(DockingBehavior.Ask)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonTreeView : VisualControlBase, IContainedInputControl
{
	private class InternalTreeView : TreeView
	{
		private static MethodInfo _miRI;

		private ViewManager _viewManager;

		private ViewDrawPanel _drawPanel;

		private KryptonTreeView _kryptonTreeView;

		private IntPtr _screenDC;

		private bool _mouseOver;

		public ViewDrawPanel ViewDrawPanel => _drawPanel;

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
					}
					else
					{
						OnTrackMouseLeave(EventArgs.Empty);
					}
				}
			}
		}

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public InternalTreeView(KryptonTreeView kryptonTreeView)
		{
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			_kryptonTreeView = kryptonTreeView;
			_drawPanel = new ViewDrawPanel();
			_viewManager = new ViewManager(this, _drawPanel);
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
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

		public void ResetIndent()
		{
			if (_miRI == null)
			{
				_miRI = typeof(TreeView).GetMethod("ResetIndent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, CallingConventions.HasThis, new Type[0], null);
			}
			_miRI.Invoke(this, new object[0]);
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			base.OnLayout(levent);
			using ViewLayoutContext context = new ViewLayoutContext(_viewManager, this, _kryptonTreeView, _kryptonTreeView.Renderer);
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
				if (MouseOver)
				{
					MouseOver = false;
					_kryptonTreeView.PerformNeedPaint(needLayout: true);
					Invalidate();
				}
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonTreeView.PerformNeedPaint(needLayout: true);
					Invalidate();
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
							using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(this, _kryptonTreeView.Renderer))
							{
								viewLayoutContext.DisplayRectangle = rectangle;
								_drawPanel.Layout(viewLayoutContext);
							}
							using (RenderContext context = new RenderContext(this, _kryptonTreeView, graphics, rectangle, _kryptonTreeView.Renderer))
							{
								_drawPanel.Render(context);
							}
							Color backColor = _drawPanel.GetPalette().GetBackColor1(_drawPanel.State);
							if (backColor != BackColor)
							{
								BackColor = backColor;
							}
							IntPtr wParam = m.WParam;
							m.WParam = _screenDC;
							DefWndProc(ref m);
							m.WParam = wParam;
						}
						PI.BitBlt(intPtr, 0, 0, rectangle.Width, rectangle.Height, _screenDC, 0, 0, 13369376);
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

	private PaletteTreeStateRedirect _stateCommon;

	private PaletteTreeState _stateDisabled;

	private PaletteTreeState _stateNormal;

	private PaletteDouble _stateActive;

	private PaletteTreeNodeTriple _stateTracking;

	private PaletteTreeNodeTriple _statePressed;

	private PaletteTreeNodeTriple _stateCheckedNormal;

	private PaletteTreeNodeTriple _stateCheckedTracking;

	private PaletteTreeNodeTriple _stateCheckedPressed;

	private PaletteTreeNodeTripleRedirect _stateFocus;

	private PaletteTripleOverride _overrideNormal;

	private PaletteTripleOverride _overrideTracking;

	private PaletteTripleOverride _overridePressed;

	private PaletteTripleOverride _overrideCheckedNormal;

	private PaletteTripleOverride _overrideCheckedTracking;

	private PaletteTripleOverride _overrideCheckedPressed;

	private PaletteNodeOverride _overrideNormalNode;

	private PaletteRedirectTreeView _redirectImages;

	private TreeViewImages _plusMinusImages;

	private CheckBoxImages _checkBoxImages;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private ViewDrawButton _drawButton;

	private ViewDrawCheckBox _drawCheckBox;

	private ViewLayoutCenter _layoutCheckBox;

	private ViewLayoutDocker _layoutDocker;

	private ViewLayoutStack _layoutImageStack;

	private ViewLayoutCenter _layoutImageCenter;

	private ViewLayoutCenter _layoutImageCenterState;

	private ViewLayoutSeparator _layoutImage;

	private ViewLayoutSeparator _layoutImageState;

	private ViewLayoutSeparator _layoutImageAfter;

	private InternalTreeView _treeView;

	private FixedContentValue _contentValues;

	private bool? _fixedActive;

	private ButtonStyle _style;

	private IntPtr _screenDC;

	private bool _itemHeightDefault;

	private bool _mouseOver;

	private bool _alwaysActive;

	private bool _forcedLayout;

	private bool _trackingMouseEnter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public TreeView TreeView => _treeView;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => TreeView;

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

	[Category("Appearance")]
	[Description("The height of every node in the control.")]
	public int ItemHeight
	{
		get
		{
			return _treeView.ItemHeight;
		}
		set
		{
			if (_treeView.ItemHeight != value)
			{
				_itemHeightDefault = false;
				_treeView.ItemHeight = value;
			}
		}
	}

	[Category("Appearance")]
	[Description("Indicates whether check boxes are displayed next to nodes")]
	[DefaultValue(false)]
	public bool CheckBoxes
	{
		get
		{
			return _treeView.CheckBoxes;
		}
		set
		{
			_treeView.CheckBoxes = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the selection highlight spans the width of the control.")]
	[DefaultValue(false)]
	public bool FullRowSelect
	{
		get
		{
			return _treeView.FullRowSelect;
		}
		set
		{
			_treeView.FullRowSelect = value;
		}
	}

	[Category("Behavior")]
	[Description("Removes highlight from the control when it no longer has focus.")]
	[DefaultValue(true)]
	public bool HideSelection
	{
		get
		{
			return _treeView.HideSelection;
		}
		set
		{
			_treeView.HideSelection = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the node gives feedback as the mouse moves over them.")]
	[DefaultValue(false)]
	public bool HotTracking
	{
		get
		{
			return _treeView.HotTracking;
		}
		set
		{
			_treeView.HotTracking = value;
		}
	}

	[Category("Behavior")]
	[Description("The default image index for nodes.")]
	[Localizable(true)]
	[TypeConverter("ComponentFactory.Krypton.Toolkit.NoneExcludedImageIndexConverter, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[RelatedImageList("ImageList")]
	[DefaultValue(-1)]
	public int ImageIndex
	{
		get
		{
			return _treeView.ImageIndex;
		}
		set
		{
			_treeView.ImageIndex = value;
		}
	}

	[Category("Behavior")]
	[Description("The default image key for the nodes.")]
	[Localizable(true)]
	[TypeConverter(typeof(ImageKeyConverter))]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[RelatedImageList("ImageList")]
	[DefaultValue("")]
	public string ImageKey
	{
		get
		{
			return _treeView.ImageKey;
		}
		set
		{
			_treeView.ImageKey = value;
		}
	}

	[Category("Behavior")]
	[Description("The ImageList control from which nodes images are taken.")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(null)]
	public ImageList ImageList
	{
		get
		{
			return _treeView.ImageList;
		}
		set
		{
			_treeView.ImageList = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the user can edit the label of nodes.")]
	[DefaultValue(false)]
	public bool LabelEdit
	{
		get
		{
			return _treeView.LabelEdit;
		}
		set
		{
			_treeView.LabelEdit = value;
		}
	}

	[Category("Behavior")]
	[Description("The delimitor used for separating nodes with the FullPath property.")]
	[DefaultValue("\\")]
	public string PathSeparator
	{
		get
		{
			return _treeView.PathSeparator;
		}
		set
		{
			_treeView.PathSeparator = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the control displays scroll bars when they are needed.")]
	[DefaultValue(true)]
	public bool Scrollable
	{
		get
		{
			return _treeView.Scrollable;
		}
		set
		{
			_treeView.Scrollable = value;
		}
	}

	[Category("Behavior")]
	[Description("The default image index for selected nodes.")]
	[Localizable(true)]
	[TypeConverter("ComponentFactory.Krypton.Toolkit.NoneExcludedImageIndexConverter, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RelatedImageList("ImageList")]
	[DefaultValue(-1)]
	public int SelectedImageIndex
	{
		get
		{
			return _treeView.SelectedImageIndex;
		}
		set
		{
			_treeView.SelectedImageIndex = value;
		}
	}

	[Category("Behavior")]
	[Description("The default image for selected nodes.")]
	[Localizable(true)]
	[TypeConverter(typeof(ImageKeyConverter))]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RelatedImageList("ImageList")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue("")]
	public string SelectedImageKey
	{
		get
		{
			return _treeView.SelectedImageKey;
		}
		set
		{
			_treeView.SelectedImageKey = value;
		}
	}

	[Category("Appearance")]
	[Description("Note that is currently selected.")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TreeNode SelectedNode
	{
		get
		{
			return _treeView.SelectedNode;
		}
		set
		{
			_treeView.SelectedNode = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates whether lines are drawn between sibling and parent/child nodes.")]
	[DefaultValue(true)]
	public bool ShowLines
	{
		get
		{
			return _treeView.ShowLines;
		}
		set
		{
			_treeView.ShowLines = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether ToolTips are displayed for the nodes.")]
	[DefaultValue(false)]
	public bool ShowNodeToolTips
	{
		get
		{
			return _treeView.ShowNodeToolTips;
		}
		set
		{
			_treeView.ShowNodeToolTips = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether plus/minus nodes are drawn next to parent nodes.")]
	[DefaultValue(true)]
	public bool ShowPlusMinus
	{
		get
		{
			return _treeView.ShowPlusMinus;
		}
		set
		{
			_treeView.ShowPlusMinus = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether lines are shown between root nodes.")]
	[DefaultValue(true)]
	public bool ShowRootLines
	{
		get
		{
			return _treeView.ShowRootLines;
		}
		set
		{
			_treeView.ShowRootLines = value;
		}
	}

	[Category("Behavior")]
	[Description("The ImageList used by the control for custom states.")]
	[DefaultValue(null)]
	public ImageList StateImageList
	{
		get
		{
			return _treeView.StateImageList;
		}
		set
		{
			_treeView.StateImageList = value;
		}
	}

	[Category("Appearance")]
	[Description("First fully-visible node.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public TreeNode TopNode
	{
		get
		{
			return _treeView.TopNode;
		}
		set
		{
			_treeView.TopNode = value;
		}
	}

	[Category("Behavior")]
	[Description("IComparer used to perform custom sorting.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IComparer TreeViewNodeSorter
	{
		get
		{
			return _treeView.TreeViewNodeSorter;
		}
		set
		{
			_treeView.TreeViewNodeSorter = value;
		}
	}

	[Category("Behavior")]
	[Description("Returns number of visible nodes in the control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int VisibleCount => _treeView.VisibleCount;

	[Category("Appearance")]
	[Description("Indicates whether the control layout is right-to-left when the RightToLeft property is True.")]
	[DefaultValue(false)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public bool RightToLeftLayout
	{
		get
		{
			return _treeView.RightToLeftLayout;
		}
		set
		{
			_treeView.RightToLeftLayout = value;
		}
	}

	[Category("Behavior")]
	[Description("The root nodes in the KryptonTreeView control.")]
	[Editor("System.Windows.Forms.Design.TreeNodeCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[MergableProperty(false)]
	[Localizable(true)]
	public TreeNodeCollection Nodes => _treeView.Nodes;

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
				_stateCommon.Node.SetStyles(_style);
				_stateFocus.Node.SetStyles(_style);
				_treeView.Recreate();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Controls whether the list is sorted.")]
	[DefaultValue(false)]
	public bool Sorted
	{
		get
		{
			return _treeView.Sorted;
		}
		set
		{
			_treeView.Sorted = value;
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
				_treeView.Recreate();
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
				_treeView.Recreate();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Plus/minus image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public TreeViewImages PlusMinusImages => _plusMinusImages;

	[Category("Visuals")]
	[Description("CheckBox image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CheckBoxImages CheckBoxImages => _checkBoxImages;

	[Category("Visuals")]
	[Description("Overrides for defining item appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeNodeTripleRedirect OverrideFocus => _stateFocus;

	[Category("Visuals")]
	[Description("Overrides for defining common appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeStateRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeState StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeState StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining active appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateActive => _stateActive;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeNodeTriple StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeNodeTriple StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining normal checked item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeNodeTriple StateCheckedNormal => _stateCheckedNormal;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking checked item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeNodeTriple StateCheckedTracking => _stateCheckedTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed checked item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTreeNodeTriple StateCheckedPressed => _stateCheckedPressed;

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
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _treeView.MouseOver;
		}
	}

	protected override Size DefaultSize => new Size(120, 96);

	[Category("Behavior")]
	[Description("Occurs when a checkbox has been checked or unchecked.")]
	public event TreeViewEventHandler AfterCheck;

	[Category("Behavior")]
	[Description("Occurs when a node has been collapsed.")]
	public event TreeViewEventHandler AfterCollapse;

	[Category("Behavior")]
	[Description("Occurs when a node has been expanded.")]
	public event TreeViewEventHandler AfterExpand;

	[Category("Behavior")]
	[Description("Occurs when the text of node has been edited by the user.")]
	public event NodeLabelEditEventHandler AfterLabelEdit;

	[Category("Behavior")]
	[Description("Occurs when the selection has been changed.")]
	public event TreeViewEventHandler AfterSelect;

	[Category("Behavior")]
	[Description("Occurs when a checkbox is about to be checked or unchecked.")]
	public event TreeViewCancelEventHandler BeforeCheck;

	[Category("Behavior")]
	[Description("Occurs when a node is about to be collapsed.")]
	public event TreeViewCancelEventHandler BeforeCollapse;

	[Category("Behavior")]
	[Description("Occurs when a node is about to be expanded.")]
	public event TreeViewCancelEventHandler BeforeExpand;

	[Category("Behavior")]
	[Description("Occurs when the text of node is about to be edited by the user.")]
	public event NodeLabelEditEventHandler BeforeLabelEdit;

	[Category("Behavior")]
	[Description("Occurs when the selection is about to be changed.")]
	public event TreeViewCancelEventHandler BeforeSelect;

	[Category("Action")]
	[Description("Occurs when the user begins dragging an item.")]
	public event ItemDragEventHandler ItemDrag;

	[Category("Behavior")]
	[Description("Occurs when a node is clicked with the mouse.")]
	public event TreeNodeMouseClickEventHandler NodeMouseClick;

	[Category("Behavior")]
	[Description("Occurs when a node is double clicked with the mouse.")]
	public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick;

	[Category("Action")]
	[Description("Occurs when the mouse hovers over a node.")]
	public event TreeNodeMouseHoverEventHandler NodeMouseHover;

	[Category("PropertyChanged")]
	[Description("Occurs when the value of the RightToLeftLayout property changes.")]
	public event EventHandler RightToLeftLayoutChanged;

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

	public KryptonTreeView()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.StandardClick | ControlStyles.Selectable, value: false);
		_alwaysActive = true;
		_style = ButtonStyle.ListItem;
		_itemHeightDefault = true;
		_plusMinusImages = new TreeViewImages();
		_checkBoxImages = new CheckBoxImages();
		base.Padding = new Padding(1);
		_redirectImages = new PaletteRedirectTreeView(base.Redirector, _plusMinusImages, _checkBoxImages);
		PaletteBackInheritRedirect paletteBackInheritRedirect = new PaletteBackInheritRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone);
		PaletteBorderInheritRedirect paletteBorderInheritRedirect = new PaletteBorderInheritRedirect(base.Redirector, PaletteBorderStyle.InputControlStandalone);
		PaletteBackColor1 back = new PaletteBackColor1(paletteBackInheritRedirect, base.NeedPaintDelegate);
		PaletteBorder border = new PaletteBorder(paletteBorderInheritRedirect, base.NeedPaintDelegate);
		_stateCommon = new PaletteTreeStateRedirect(base.Redirector, back, paletteBackInheritRedirect, border, paletteBorderInheritRedirect, base.NeedPaintDelegate);
		PaletteBackColor1 back2 = new PaletteBackColor1(_stateCommon.PaletteBack, base.NeedPaintDelegate);
		PaletteBorder border2 = new PaletteBorder(_stateCommon.PaletteBorder, base.NeedPaintDelegate);
		_stateDisabled = new PaletteTreeState(_stateCommon, back2, border2, base.NeedPaintDelegate);
		PaletteBackColor1 back3 = new PaletteBackColor1(_stateCommon.PaletteBack, base.NeedPaintDelegate);
		PaletteBorder border3 = new PaletteBorder(_stateCommon.PaletteBorder, base.NeedPaintDelegate);
		_stateNormal = new PaletteTreeState(_stateCommon, back3, border3, base.NeedPaintDelegate);
		PaletteBackColor1 back4 = new PaletteBackColor1(_stateCommon.PaletteBack, base.NeedPaintDelegate);
		PaletteBorder border4 = new PaletteBorder(_stateCommon.PaletteBorder, base.NeedPaintDelegate);
		_stateActive = new PaletteDouble(_stateCommon, back4, border4, base.NeedPaintDelegate);
		_stateFocus = new PaletteTreeNodeTripleRedirect(base.Redirector, PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem, base.NeedPaintDelegate);
		_stateTracking = new PaletteTreeNodeTriple(_stateCommon.Node, base.NeedPaintDelegate);
		_statePressed = new PaletteTreeNodeTriple(_stateCommon.Node, base.NeedPaintDelegate);
		_stateCheckedNormal = new PaletteTreeNodeTriple(_stateCommon.Node, base.NeedPaintDelegate);
		_stateCheckedTracking = new PaletteTreeNodeTriple(_stateCommon.Node, base.NeedPaintDelegate);
		_stateCheckedPressed = new PaletteTreeNodeTriple(_stateCommon.Node, base.NeedPaintDelegate);
		_overrideNormal = new PaletteTripleOverride(_stateFocus.Node, _stateNormal.Node, PaletteState.FocusOverride);
		_overrideTracking = new PaletteTripleOverride(_stateFocus.Node, _stateTracking.Node, PaletteState.FocusOverride);
		_overridePressed = new PaletteTripleOverride(_stateFocus.Node, _statePressed.Node, PaletteState.FocusOverride);
		_overrideCheckedNormal = new PaletteTripleOverride(_stateFocus.Node, _stateCheckedNormal.Node, PaletteState.FocusOverride);
		_overrideCheckedTracking = new PaletteTripleOverride(_stateFocus.Node, _stateCheckedTracking.Node, PaletteState.FocusOverride);
		_overrideCheckedPressed = new PaletteTripleOverride(_stateFocus.Node, _stateCheckedPressed.Node, PaletteState.FocusOverride);
		_overrideNormalNode = new PaletteNodeOverride(_overrideNormal);
		_drawCheckBox = new ViewDrawCheckBox(_redirectImages);
		_layoutCheckBox = new ViewLayoutCenter();
		_layoutCheckBox.Add(_drawCheckBox);
		_layoutImage = new ViewLayoutSeparator(0, 0);
		_layoutImageAfter = new ViewLayoutSeparator(3, 0);
		_layoutImageCenter = new ViewLayoutCenter(_layoutImage);
		_layoutImageStack = new ViewLayoutStack(horizontal: true);
		_layoutImageStack.Add(_layoutImageCenter);
		_layoutImageStack.Add(_layoutImageAfter);
		_layoutImageState = new ViewLayoutSeparator(16, 16);
		_layoutImageCenterState = new ViewLayoutCenter(_layoutImageState);
		_contentValues = new FixedContentValue();
		_drawButton = new ViewDrawButton(StateDisabled.Node, _overrideNormalNode, _overrideTracking, _overridePressed, _overrideCheckedNormal, _overrideCheckedTracking, _overrideCheckedPressed, new PaletteMetricRedirect(base.Redirector), _contentValues, VisualOrientation.Top, useMnemonic: false);
		_layoutDocker = new ViewLayoutDocker();
		_layoutDocker.Add(_layoutImageStack, ViewDockStyle.Left);
		_layoutDocker.Add(_layoutImageCenterState, ViewDockStyle.Left);
		_layoutDocker.Add(_layoutCheckBox, ViewDockStyle.Left);
		_layoutDocker.Add(_drawButton, ViewDockStyle.Fill);
		_treeView = new InternalTreeView(this);
		_treeView.TrackMouseEnter += OnTreeViewMouseChange;
		_treeView.TrackMouseLeave += OnTreeViewMouseChange;
		_treeView.GotFocus += OnTreeViewGotFocus;
		_treeView.LostFocus += OnTreeViewLostFocus;
		_treeView.KeyDown += OnTreeViewKeyDown;
		_treeView.KeyUp += OnTreeViewKeyUp;
		_treeView.KeyPress += OnTreeViewKeyPress;
		_treeView.PreviewKeyDown += OnTreeViewPreviewKeyDown;
		_treeView.Validating += OnTreeViewValidating;
		_treeView.Validated += OnTreeViewValidated;
		_treeView.AfterCheck += OnTreeViewAfterCheck;
		_treeView.AfterCollapse += OnTreeViewAfterCollapse;
		_treeView.AfterExpand += OnTreeViewAfterExpand;
		_treeView.AfterLabelEdit += OnTreeViewAfterLabelEdit;
		_treeView.AfterSelect += OnTreeViewAfterSelect;
		_treeView.BeforeCheck += OnTreeViewBeforeCheck;
		_treeView.BeforeCollapse += OnTreeViewBeforeCollapse;
		_treeView.BeforeExpand += OnTreeViewBeforeExpand;
		_treeView.BeforeLabelEdit += OnTreeViewBeforeLabelEdit;
		_treeView.BeforeSelect += OnTreeViewBeforeSelect;
		_treeView.ItemDrag += OnTreeViewItemDrag;
		_treeView.NodeMouseClick += OnTreeViewNodeMouseClick;
		_treeView.NodeMouseDoubleClick += OnTreeViewNodeMouseDoubleClick;
		_treeView.NodeMouseHover += OnTreeViewNodeMouseHover;
		_treeView.DrawNode += OnTreeViewDrawNode;
		_treeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
		_layoutFill = new ViewLayoutFill(_treeView);
		_layoutFill.DisplayPadding = new Padding(1);
		_drawDockerInner = new ViewLayoutDocker();
		_drawDockerInner.Add(_layoutFill, ViewDockStyle.Fill);
		_drawDockerOuter = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border);
		_drawDockerOuter.Add(_drawDockerInner, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDockerOuter);
		_screenDC = PI.CreateCompatibleDC(IntPtr.Zero);
		((KryptonReadOnlyControls)base.Controls).AddInternal(_treeView);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (_screenDC != IntPtr.Zero)
		{
			PI.DeleteDC(_screenDC);
		}
	}

	private bool ShouldSerializeItemHeight()
	{
		return !_itemHeightDefault;
	}

	private void ResetItemHeight()
	{
		_itemHeightDefault = true;
		UpdateItemHeight();
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

	private bool ShouldSerializePlusMinusImages()
	{
		return !_plusMinusImages.IsDefault;
	}

	private bool ShouldSerializeCheckBoxImages()
	{
		return !_checkBoxImages.IsDefault;
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

	public void CollapseAll()
	{
		_treeView.CollapseAll();
	}

	public void ExpandAll()
	{
		_treeView.ExpandAll();
	}

	public void Sort()
	{
		_treeView.Sort();
	}

	public void BeginUpdate()
	{
		_treeView.BeginUpdate();
	}

	public void EndUpdate()
	{
		_treeView.EndUpdate();
	}

	public TreeNode GetNodeAt(Point pt)
	{
		return _treeView.GetNodeAt(pt);
	}

	public TreeNode GetNodeAt(int x, int y)
	{
		return _treeView.GetNodeAt(x, y);
	}

	public int GetNodeCount(bool includeSubTrees)
	{
		return _treeView.GetNodeCount(includeSubTrees);
	}

	public TreeViewHitTestInfo HitTest(Point pt)
	{
		return _treeView.HitTest(pt);
	}

	public TreeViewHitTestInfo HitTest(int x, int y)
	{
		return _treeView.HitTest(x, y);
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (TreeView != null)
		{
			return TreeView.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (TreeView != null)
		{
			TreeView.Select();
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

	protected virtual void OnAfterCheck(TreeViewEventArgs e)
	{
		if (this.AfterCheck != null)
		{
			this.AfterCheck(this, e);
		}
	}

	protected virtual void OnAfterCollapse(TreeViewEventArgs e)
	{
		if (this.AfterCollapse != null)
		{
			this.AfterCollapse(this, e);
		}
	}

	protected virtual void OnAfterExpand(TreeViewEventArgs e)
	{
		if (this.AfterExpand != null)
		{
			this.AfterExpand(this, e);
		}
	}

	protected virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
	{
		if (this.AfterLabelEdit != null)
		{
			this.AfterLabelEdit(this, e);
		}
	}

	protected virtual void OnAfterSelect(TreeViewEventArgs e)
	{
		if (this.AfterSelect != null)
		{
			this.AfterSelect(this, e);
		}
	}

	protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
	{
		if (this.BeforeCheck != null)
		{
			this.BeforeCheck(this, e);
		}
	}

	protected virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
	{
		if (this.BeforeCollapse != null)
		{
			this.BeforeCollapse(this, e);
		}
	}

	protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
	{
		if (this.BeforeExpand != null)
		{
			this.BeforeExpand(this, e);
		}
	}

	protected virtual void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
	{
		if (this.BeforeLabelEdit != null)
		{
			this.BeforeLabelEdit(this, e);
		}
	}

	protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		if (this.BeforeSelect != null)
		{
			this.BeforeSelect(this, e);
		}
	}

	protected virtual void OnItemDrag(ItemDragEventArgs e)
	{
		if (this.ItemDrag != null)
		{
			this.ItemDrag(this, e);
		}
	}

	protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
	{
		if (this.NodeMouseClick != null)
		{
			this.NodeMouseClick(this, e);
		}
	}

	protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
	{
		if (this.NodeMouseDoubleClick != null)
		{
			this.NodeMouseDoubleClick(this, e);
		}
	}

	protected virtual void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
	{
		if (this.NodeMouseHover != null)
		{
			this.NodeMouseHover(this, e);
		}
	}

	protected virtual void OnRightToLeftLayoutChanged(EventArgs e)
	{
		if (this.RightToLeftLayoutChanged != null)
		{
			this.RightToLeftLayoutChanged(this, e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnPaletteChanged(EventArgs e)
	{
		_treeView.Recreate();
		UpdateItemHeight();
		_treeView.Invalidate();
		base.OnPaletteChanged(e);
	}

	protected override void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		UpdateItemHeight();
		base.OnPaletteChanged(e);
	}

	protected override void OnCreateControl()
	{
		UpdateItemHeight();
		base.OnCreateControl();
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
		TreeView.TabStop = base.TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		TreeView.CausesValidation = base.CausesValidation;
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
			_treeView.Invalidate();
		}
		else
		{
			ForceControlLayout();
		}
		UpdateItemHeight();
		UpdateStateAndPalettes();
		base.OnNeedPaint(sender, e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		if (base.IsHandleCreated || _forcedLayout || (base.DesignMode && _treeView != null))
		{
			Rectangle fillRect = _layoutFill.FillRect;
			_treeView.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		_treeView.Invalidate();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		_treeView.Invalidate();
		base.OnMouseLeave(e);
	}

	private void UpdateItemHeight()
	{
		UpdateContentFromNode(null);
		using ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer);
		_drawButton.ElementState = PaletteState.Normal;
		Size preferredSize = _drawButton.GetPreferredSize(context);
		preferredSize.Height++;
		if (ImageList != null)
		{
			preferredSize.Height = Math.Max(preferredSize.Height, ImageList.ImageSize.Height);
		}
		if (preferredSize.Height != ItemHeight && _itemHeightDefault)
		{
			_treeView.ItemHeight = preferredSize.Height;
		}
	}

	private void UpdateContentFromNode(TreeNode node)
	{
		_overrideNormalNode.TreeNode = node;
		if (node != null)
		{
			_contentValues.ShortText = node.Text;
			_contentValues.LongText = string.Empty;
			_contentValues.Image = null;
			_contentValues.ImageTransparentColor = Color.Empty;
			if (node is KryptonTreeNode kryptonTreeNode)
			{
				_contentValues.LongText = kryptonTreeNode.LongText;
			}
		}
		else
		{
			_contentValues.ShortText = "A";
			_contentValues.LongText = "A";
			_contentValues.Image = null;
			_contentValues.ImageTransparentColor = Color.Empty;
		}
	}

	private void UpdateStateAndPalettes()
	{
		if (!base.IsDisposed)
		{
			IPaletteDouble doubleState = GetDoubleState();
			_treeView.ViewDrawPanel.SetPalettes(doubleState.PaletteBack);
			_drawDockerOuter.SetPalettes(doubleState.PaletteBack, doubleState.PaletteBorder);
			_drawDockerOuter.Enabled = base.Enabled;
			PaletteState elementState = (IsActive ? PaletteState.Tracking : ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal));
			_treeView.ViewDrawPanel.ElementState = elementState;
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

	private int NodeIndent(TreeNode node)
	{
		int num = 0;
		for (TreeNode treeNode = node; treeNode != null; treeNode = treeNode.Parent)
		{
			num++;
		}
		if (!ShowRootLines)
		{
			num--;
		}
		return num * _treeView.Indent;
	}

	private void OnTreeViewDrawNode(object sender, DrawTreeNodeEventArgs e)
	{
		if (e.Node == null)
		{
			return;
		}
		UpdateContentFromNode(e.Node);
		if (ImageList != null)
		{
			_layoutImageStack.Visible = true;
			_layoutImage.SeparatorSize = ImageList.ImageSize;
		}
		else
		{
			_layoutImageStack.Visible = false;
		}
		Image image = null;
		if (StateImageList != null)
		{
			try
			{
				if (CheckBoxes)
				{
					image = ((!e.Node.Checked) ? StateImageList.Images[0] : StateImageList.Images[1]);
				}
				else if (!string.IsNullOrEmpty(e.Node.StateImageKey))
				{
					image = StateImageList.Images[e.Node.StateImageKey];
				}
				else if (e.Node.StateImageIndex >= 0 && e.Node.StateImageIndex < StateImageList.Images.Count)
				{
					image = StateImageList.Images[e.Node.StateImageIndex];
				}
			}
			catch
			{
			}
		}
		_layoutImageCenterState.Visible = image != null;
		_layoutCheckBox.Visible = StateImageList == null && CheckBoxes;
		if (_layoutCheckBox.Visible)
		{
			_drawCheckBox.CheckState = (e.Node.Checked ? CheckState.Checked : CheckState.Unchecked);
		}
		PaletteState paletteState = PaletteState.Normal;
		if ((e.State & TreeNodeStates.Grayed) == TreeNodeStates.Grayed)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
			{
				_drawButton.Checked = true;
				paletteState = (((e.State & TreeNodeStates.Hot) != TreeNodeStates.Hot) ? PaletteState.CheckedNormal : PaletteState.CheckedTracking);
			}
			else
			{
				_drawButton.Checked = false;
				paletteState = (((e.State & TreeNodeStates.Hot) != TreeNodeStates.Hot) ? PaletteState.Normal : PaletteState.Tracking);
			}
			bool apply = false;
			if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused)
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
		_drawButton.ElementState = paletteState;
		IntPtr hdc = e.Graphics.GetHdc();
		try
		{
			Rectangle bounds = e.Bounds;
			int indent = _treeView.Indent;
			int num = NodeIndent(e.Node) + 2;
			Rectangle rectangle = new Rectangle(bounds.X + num - indent, bounds.Y, indent, bounds.Height);
			bounds.X += num;
			bounds.Width -= num;
			IntPtr intPtr = PI.CreateCompatibleBitmap(hdc, bounds.Right, bounds.Bottom);
			if (!(intPtr != IntPtr.Zero))
			{
				return;
			}
			try
			{
				PI.SelectObject(_screenDC, intPtr);
				using Graphics graphics = Graphics.FromHdc(_screenDC);
				Size empty = Size.Empty;
				using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(this, base.Renderer))
				{
					viewLayoutContext.DisplayRectangle = e.Bounds;
					_treeView.ViewDrawPanel.Layout(viewLayoutContext);
					viewLayoutContext.DisplayRectangle = bounds;
					empty = _layoutDocker.GetPreferredSize(viewLayoutContext);
					if (!FullRowSelect && empty.Width < bounds.Width)
					{
						bounds.Width = empty.Width;
					}
					if (bounds.Width < empty.Width)
					{
						bounds.Width = empty.Width;
					}
					viewLayoutContext.DisplayRectangle = bounds;
					_layoutDocker.Layout(viewLayoutContext);
				}
				using (RenderContext context = new RenderContext(this, graphics, e.Bounds, base.Renderer))
				{
					_treeView.ViewDrawPanel.Render(context);
				}
				if (rectangle.X >= 0)
				{
					if (ShowLines && base.Redirector.GetMetricBool(PaletteState.Normal, PaletteMetricBool.TreeViewLines) != InheritBool.False)
					{
						int num2 = rectangle.X + rectangle.Width / 2 - 1;
						int num3 = rectangle.Y + rectangle.Height / 2;
						num3 -= (num3 + 1) % 2;
						int num4 = rectangle.Y;
						num4 -= (num4 + 1) % 2;
						int y = rectangle.Bottom;
						if (e.Node.Parent == null && e.Node.PrevNode == null)
						{
							num4 = num3;
						}
						if (e.Node.NextNode == null)
						{
							y = num3;
						}
						Color contentShortTextColor = base.Redirector.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
						using Pen pen = new Pen(contentShortTextColor);
						pen.DashStyle = DashStyle.Dot;
						pen.DashOffset = indent % 2;
						graphics.DrawLine(pen, num2, num4, num2, y);
						graphics.DrawLine(pen, num2 - 1, num3 - 1, rectangle.Right, num3 - 1);
						for (num2 -= indent; num2 >= 0; num2 -= indent)
						{
							int num5 = rectangle.Y;
							num5 -= (num5 + 1) % 2;
							graphics.DrawLine(pen, num2, num5, num2, rectangle.Bottom);
						}
					}
					if (ShowPlusMinus && e.Node.Nodes.Count > 0)
					{
						Image treeViewImage = _redirectImages.GetTreeViewImage(e.Node.IsExpanded);
						if (treeViewImage != null)
						{
							graphics.DrawImage(treeViewImage, new Rectangle(rectangle.X + (rectangle.Width - treeViewImage.Width) / 2 - 1, rectangle.Y + (rectangle.Height - treeViewImage.Height) / 2, treeViewImage.Width, treeViewImage.Height));
						}
					}
				}
				using (RenderContext context2 = new RenderContext(this, graphics, bounds, base.Renderer))
				{
					_layoutDocker.Render(context2);
				}
				if (ImageList != null)
				{
					Image image2 = null;
					int count = ImageList.Images.Count;
					try
					{
						if (e.Node.IsSelected)
						{
							if (!string.IsNullOrEmpty(e.Node.SelectedImageKey))
							{
								image2 = ImageList.Images[e.Node.SelectedImageKey];
							}
							else if (e.Node.SelectedImageIndex >= 0 && e.Node.SelectedImageIndex < count)
							{
								image2 = ImageList.Images[e.Node.SelectedImageIndex];
							}
							else if (!string.IsNullOrEmpty(SelectedImageKey))
							{
								image2 = ImageList.Images[SelectedImageKey];
							}
							else if (SelectedImageIndex >= 0 && SelectedImageIndex < count)
							{
								image2 = ImageList.Images[SelectedImageIndex];
							}
						}
						else if (!string.IsNullOrEmpty(e.Node.ImageKey))
						{
							image2 = ImageList.Images[e.Node.ImageKey];
						}
						else if (e.Node.ImageIndex >= 0 && e.Node.ImageIndex < count)
						{
							image2 = ImageList.Images[e.Node.ImageIndex];
						}
						else if (!string.IsNullOrEmpty(ImageKey))
						{
							image2 = ImageList.Images[ImageKey];
						}
						else if (ImageIndex >= 0 && ImageIndex < count)
						{
							image2 = ImageList.Images[ImageIndex];
						}
						if (image2 != null)
						{
							graphics.DrawImage(image2, _layoutImage.ClientRectangle);
						}
					}
					catch
					{
					}
				}
				if (_layoutImageCenterState.Visible && image != null)
				{
					graphics.DrawImage(image, _layoutImageState.ClientRectangle);
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

	private void OnTreeViewGotFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		_treeView.Invalidate();
		PerformNeedPaint(needLayout: true);
		OnGotFocus(e);
	}

	private void OnTreeViewLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		_treeView.Invalidate();
		PerformNeedPaint(needLayout: true);
		OnLostFocus(e);
	}

	private void OnTreeViewKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnTreeViewKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnTreeViewKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnTreeViewPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnTreeViewValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnTreeViewValidating(object sender, CancelEventArgs e)
	{
		OnValidating(e);
	}

	private void OnTreeViewNodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
	{
		OnNodeMouseHover(e);
	}

	private void OnTreeViewNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		OnNodeMouseDoubleClick(e);
	}

	private void OnTreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		OnNodeMouseClick(e);
	}

	private void OnTreeViewItemDrag(object sender, ItemDragEventArgs e)
	{
		OnItemDrag(e);
	}

	private void OnTreeViewBeforeSelect(object sender, TreeViewCancelEventArgs e)
	{
		OnBeforeSelect(e);
	}

	private void OnTreeViewBeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
	{
		OnBeforeLabelEdit(e);
	}

	private void OnTreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		OnBeforeExpand(e);
	}

	private void OnTreeViewBeforeCollapse(object sender, TreeViewCancelEventArgs e)
	{
		OnBeforeCollapse(e);
	}

	private void OnTreeViewBeforeCheck(object sender, TreeViewCancelEventArgs e)
	{
		OnBeforeCheck(e);
	}

	private void OnTreeViewAfterSelect(object sender, TreeViewEventArgs e)
	{
		OnAfterSelect(e);
	}

	private void OnTreeViewAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
	{
		OnAfterLabelEdit(e);
	}

	private void OnTreeViewAfterExpand(object sender, TreeViewEventArgs e)
	{
		OnAfterExpand(e);
	}

	private void OnTreeViewAfterCollapse(object sender, TreeViewEventArgs e)
	{
		OnAfterCollapse(e);
	}

	private void OnTreeViewAfterCheck(object sender, TreeViewEventArgs e)
	{
		OnAfterCheck(e);
	}

	private void OnTreeViewMouseChange(object sender, EventArgs e)
	{
		if (_treeView.MouseOver != _trackingMouseEnter)
		{
			_trackingMouseEnter = _treeView.MouseOver;
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
