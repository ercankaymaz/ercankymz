using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Designer;

internal class PresetManager : Form
{
	private struct _0023_003DzGBzdi_g_003D(string _0023_003DzPw_8sZI_003D, bool _0023_003DzJzPCQShzk4ts, _0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D _0023_003DzI12Aw9CHK3UILn9V1w_003D_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzbpcTNic_003D = _0023_003DzPw_8sZI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzWPfzJ20_003D = _0023_003DzJzPCQShzk4ts;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D _0023_003Dz_rLWr0k_003D = _0023_003DzI12Aw9CHK3UILn9V1w_003D_003D;
	}

	private enum _0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D
	{

	}

	public static SizeF ScalingLevel = UtilityEx.GetScalingLevel();

	public static bool ShowWhenDropped = ReadRegistry();

	private Design _tempDesign;

	private Design _originalDesign;

	private ImageList controlImageList;

	private Camera origCamera;

	private Camera initialCamera;

	private displayType initialDisplayMode;

	private viewType initialViewType;

	private bool initialRotateEnabled;

	private bool initialViewCubeVisibility;

	private ListViewItem lastPresetListViewSelectedItem;

	private ListViewItem lastLayoutListViewSelectedItem;

	private bool skipImages = true;

	private int currHoverIndex = -1;

	private const string SHOW_DESIGNER_KEY = "ShowDesigner";

	private ListViewItem lastDrawnLayout;

	private static bool _firstImage = true;

	private static readonly AssemblyName _executingAssemblyName = Assembly.GetExecutingAssembly().GetName();

	private static readonly string _tempFolderPath = Path.GetTempPath();

	private static readonly string _majorVersion = _executingAssemblyName.Version.Major.ToString();

	private static readonly string _buildVersion = _executingAssemblyName.Version.Build.ToString();

	private static string _majorVersionFolder = Path.Combine(_tempFolderPath, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600474), _majorVersion);

	private string _devDeptImageCacheFolder = Path.Combine(_majorVersionFolder, _buildVersion);

	private readonly string _imagePreambleName = _executingAssemblyName.Name;

	private Color[,] gradientColor = new Color[12, 2]
	{
		{
			Color.FromArgb(245, 245, 245),
			Color.FromArgb(102, 163, 210)
		},
		{
			Color.FromArgb(248, 73, 1),
			Color.FromArgb(178, 52, 0)
		},
		{
			Color.FromArgb(231, 231, 231),
			Color.FromArgb(231, 231, 231)
		},
		{
			Color.FromArgb(46, 82, 103),
			Color.FromArgb(18, 32, 41)
		},
		{
			Color.FromArgb(8, 206, 225),
			Color.FromArgb(18, 57, 81)
		},
		{
			Color.FromArgb(67, 71, 82),
			Color.FromArgb(34, 35, 41)
		},
		{
			Color.FromArgb(104, 53, 32),
			Color.FromArgb(0, 0, 0)
		},
		{
			Color.FromArgb(250, 248, 239),
			Color.FromArgb(240, 235, 211)
		},
		{
			Color.FromArgb(255, 204, 109),
			Color.FromArgb(255, 184, 44)
		},
		{
			Color.FromArgb(245, 245, 245),
			Color.FromArgb(227, 229, 232)
		},
		{
			Color.FromArgb(0, 134, 219),
			Color.FromArgb(0, 95, 164)
		},
		{
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255)
		}
	};

	private _0023_003DzGBzdi_g_003D[] presets = new _0023_003DzGBzdi_g_003D[12]
	{
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601303), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)0),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601321), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)1),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601333), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)2),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601091), _0023_003DzJzPCQShzk4ts: true, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)3),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601106), _0023_003DzJzPCQShzk4ts: true, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)4),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601125), _0023_003DzJzPCQShzk4ts: true, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)5),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601140), _0023_003DzJzPCQShzk4ts: true, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)6),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601156), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)7),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601178), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)8),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601187), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)9),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601206), _0023_003DzJzPCQShzk4ts: true, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)10),
		new _0023_003DzGBzdi_g_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600454), _0023_003DzJzPCQShzk4ts: false, (_0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D)11)
	};

	private IContainer components;

	private ListView layoutListView;

	private Button loadButton;

	private CheckBox showDesignerCheckBox;

	private ImageList layoutImageList;

	private SplitContainer splitContainer1;

	private _0023_003DzHYgOs2MdsobpKI3Os7Iof1eYlYY2wPlA_Krta9c_003D presetListView;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int LayoutIndex { get; private set; } = -1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ThemeIndex { get; private set; } = -1;

	public PresetManager(Design design)
	{
		_originalDesign = design;
		InitPresetManager();
	}

	public static void AdjustScalingLevel(Form form)
	{
		if (ScalingLevel.Width != 1f || ScalingLevel.Height != 1f)
		{
			form.Scale(ScalingLevel);
		}
	}

	private Design GetDesign(Design design)
	{
		if (!(design is Simulation))
		{
			if (design is Manufacture)
			{
				return new Manufacture();
			}
			return new Design();
		}
		return new Simulation();
	}

	private void InitPresetManager()
	{
		_firstImage = true;
		_tempDesign = GetDesign(_originalDesign);
		_tempDesign._0023_003DzXRmPWIn6oGDi();
		_tempDesign.Tag = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597558);
		_tempDesign.ZoomFitMode = zoomFitType.Standard;
		InitializeViewportsByLayoutType(_tempDesign, viewportLayoutType.SingleViewport);
		_tempDesign.CreateControl();
		_tempDesign.CreateGraphics();
		InitializeComponent();
		presetListView.OwnerDraw = true;
		presetListView.DrawItem += PresetListViewOnDrawItem;
		presetListView.SelectedIndexChanged += PresetListViewOnSelectedIndexChanged;
		presetListView.MouseMove += PresetListViewOnMouseMove;
		layoutListView.Items.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600496), 0);
		if (!(_originalDesign is Manufacture) && !(_originalDesign is Simulation))
		{
			layoutListView.Items.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600539), 1);
			layoutListView.Items.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600552), 2);
			layoutListView.Items.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600563), 3);
			layoutListView.Items.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600320), 4);
		}
		layoutListView.Items[0].Selected = true;
		layoutListView.Select();
		presetListView.ItemSelectionChanged += presetListView_ItemSelectionChanged;
		presetListView.MultiSelect = false;
		presetListView.MouseUp += presetListView_MouseUp;
		layoutListView.ItemSelectionChanged += layoutListView_ItemSelectionChanged;
		layoutListView.MultiSelect = false;
		layoutListView.MouseUp += layoutListView_MouseUp;
		initialDisplayMode = _tempDesign.ActiveViewport.DisplayMode;
		initialCamera = (Camera)_tempDesign.ActiveViewport.Camera.Clone();
		initialRotateEnabled = _tempDesign.ActiveViewport.Rotate.Enabled;
		initialViewCubeVisibility = _tempDesign.ActiveViewport.ViewCubeIcon?.Visible ?? false;
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		AdjustScalingLevel(this);
	}

	private void presetListView_MouseUp(object sender, MouseEventArgs e)
	{
		if (presetListView.GetItemAt(e.X, e.Y) == null && lastPresetListViewSelectedItem != null)
		{
			presetListView.Items[lastPresetListViewSelectedItem.Index].Selected = true;
		}
	}

	private void presetListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		lastPresetListViewSelectedItem = e.Item;
	}

	private void layoutListView_MouseUp(object sender, MouseEventArgs e)
	{
		if (layoutListView.GetItemAt(e.X, e.Y) == null && lastLayoutListViewSelectedItem != null)
		{
			layoutListView.Items[lastLayoutListViewSelectedItem.Index].Selected = true;
		}
	}

	private void layoutListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		lastLayoutListViewSelectedItem = e.Item;
	}

	private void PresetListViewOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
	{
		foreach (ListViewItem item in presetListView.Items)
		{
			if (!item.Bounds.Contains(mouseEventArgs.Location))
			{
				continue;
			}
			if (item.Index != currHoverIndex)
			{
				if (currHoverIndex >= 0)
				{
					presetListView.Invalidate(presetListView.Items[currHoverIndex].Bounds);
				}
				currHoverIndex = item.Index;
				presetListView.Invalidate(presetListView.Items[currHoverIndex].Bounds);
				presetListView.Update();
			}
			break;
		}
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		skipImages = false;
		UpdateImages();
	}

	private void PresetListViewOnSelectedIndexChanged(object sender, EventArgs eventArgs)
	{
		if (currHoverIndex != -1)
		{
			presetListView.Invalidate(presetListView.Items[currHoverIndex].Bounds);
		}
		currHoverIndex = -1;
	}

	private void PresetListViewOnDrawItem(object sender, DrawListViewItemEventArgs drawListViewItemEventArgs)
	{
		if (drawListViewItemEventArgs.Item.ImageIndex >= 0)
		{
			System.Drawing.Graphics graphics = drawListViewItemEventArgs.Graphics;
			Rectangle bounds = drawListViewItemEventArgs.Item.Bounds;
			SizeF sizeF = graphics.MeasureString(drawListViewItemEventArgs.Item.Text, drawListViewItemEventArgs.Item.Font);
			Image image = controlImageList.Images[drawListViewItemEventArgs.Item.ImageIndex];
			Point point = new Point(bounds.Location.X + (bounds.Width - image.Width) / 2, bounds.Location.Y + 8);
			if (drawListViewItemEventArgs.Item.Selected)
			{
				graphics.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), point.X - 8, point.Y - 8, image.Size.Width + 16, image.Size.Height + 16);
				graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder), point.X - 8, point.Y - 8, image.Size.Width + 16, image.Size.Height + 16);
			}
			else if (currHoverIndex == drawListViewItemEventArgs.ItemIndex)
			{
				graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight), point.X - 8, point.Y - 8, image.Size.Width + 16, image.Size.Height + 16);
				graphics.DrawRectangle(new Pen(SystemColors.Control), point.X - 8, point.Y - 8, image.Size.Width + 16, image.Size.Height + 16);
			}
			graphics.DrawImage(image, point);
			graphics.DrawString(drawListViewItemEventArgs.Item.Text, drawListViewItemEventArgs.Item.Font, Brushes.Black, new PointF((float)bounds.Location.X + ((float)bounds.Width - sizeF.Width) / 2f, (float)(bounds.Y + bounds.Height) - sizeF.Height));
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		if (!_originalDesign._0023_003DzNz_00241Di_amPH5._0023_003DzXo29RJWG4ZETOVgJ7zeSpac_003D())
		{
			Close();
		}
		showDesignerCheckBox.Checked = ShowWhenDropped;
		base.OnLoad(e);
	}

	private static bool ReadRegistry()
	{
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(GetSubSubKey());
			if (registryKey == null)
			{
				WriteRegistry(true);
				return true;
			}
			string value = (string)registryKey.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600365));
			if (string.IsNullOrEmpty(value))
			{
				WriteRegistry(true);
				return true;
			}
			return Convert.ToBoolean(value);
		}
		catch
		{
			return true;
		}
	}

	private static void WriteRegistry(object value)
	{
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(GetSubSubKey());
			if (registryKey != null)
			{
				registryKey.SetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600365), value);
				ShowWhenDropped = Convert.ToBoolean(value);
			}
		}
		catch
		{
		}
	}

	private static string GetSubSubKey()
	{
		Workspace.GetAssembly(out var _, out var title, out var _, out var version);
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600378), title, version.Major);
	}

	private void loadButton_Click(object sender, EventArgs e)
	{
		if (presetListView.SelectedItems.Count != 0 && layoutListView.SelectedItems.Count != 0)
		{
			LayoutIndex = layoutListView.SelectedItems[0].Index;
			ThemeIndex = presetListView.SelectedItems[0].Index;
		}
	}

	public Design SetTheme()
	{
		if (SetTheme(_originalDesign))
		{
			return _originalDesign;
		}
		return null;
	}

	public bool SetTheme(Design design)
	{
		if (LayoutIndex >= 0)
		{
			switch (LayoutIndex)
			{
			case 0:
				MakeSingleViewportLayout(design, ThemeIndex);
				break;
			case 1:
				MakeDualViewportLayout(design, ThemeIndex);
				break;
			case 2:
				MakeThreeViewportsWithOneOnLeft(design, ThemeIndex);
				break;
			case 3:
				MakeFourViewports(design, ThemeIndex);
				break;
			case 4:
				Make2DTopView(design, ThemeIndex);
				break;
			}
			design.CompileUserInterfaceElements();
			return true;
		}
		return false;
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
		_tempDesign.Dispose();
	}

	private void layoutListView_SelectedIndexChanged(object sender, EventArgs e)
	{
		UpdateImages();
		currHoverIndex = 1;
	}

	private void UpdateImages()
	{
		if (!skipImages && layoutListView.SelectedItems.Count != 0 && layoutListView.SelectedItems[0] != lastDrawnLayout)
		{
			lastDrawnLayout = layoutListView.SelectedItems[0];
			presetListView.Clear();
			if (controlImageList != null)
			{
				controlImageList.Images.Clear();
			}
			Size size = _tempDesign.Size;
			Size imageSize = new Size(256, 210);
			ImageList imageList = new ImageList();
			imageList.ImageSize = imageSize;
			imageList.ColorDepth = ColorDepth.Depth8Bit;
			controlImageList = new ImageList();
			controlImageList.ImageSize = new Size(240, 192);
			_tempDesign.Size = controlImageList.ImageSize;
			controlImageList.ColorDepth = ColorDepth.Depth24Bit;
			List<string> list = new List<string>();
			switch (layoutListView.SelectedItems[0].Index)
			{
			case 0:
				FillSingleViewportImages(list);
				break;
			case 1:
				FillDualViewportImages(list);
				break;
			case 2:
				FillTripleViewportImages(list);
				break;
			case 3:
				FillQuadViewportImages(list);
				break;
			case 4:
				Fill2DTopViewportImages(list);
				break;
			}
			presetListView.View = View.LargeIcon;
			presetListView.LargeImageList = imageList;
			presetListView.LargeImageList.ImageSize = imageSize;
			_tempDesign.Size = size;
			for (int i = 0; i < list.Count; i++)
			{
				presetListView.Items.Add(list[i], i);
				imageList.Images.Add(new Bitmap(imageSize.Width, imageSize.Height));
			}
			ListView_SetSpacing(presetListView, (short)(imageSize.Width + 50), (short)(imageSize.Height + 42));
			presetListView.Items[0].Selected = true;
		}
	}

	[DllImport("user32.dll")]
	[CLSCompliant(false)]
	public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	public int MakeLong(short lowPart, short highPart)
	{
		return (ushort)lowPart | (highPart << 16);
	}

	public void ListView_SetSpacing(ListView listview, short cx, short cy)
	{
		SendMessage(listview.Handle, 4149u, IntPtr.Zero, (IntPtr)MakeLong(cx, cy));
	}

	private void AddImageWithTitle(string title, int numViewports, int viewportIx, bool is2D, bool isHorizontal, List<string> titles)
	{
		controlImageList.Images.Add(title, RetrieveImage(title, numViewports, viewportIx, is2D, isHorizontal));
		titles.Add(title);
	}

	private Image RetrieveImage(string title, int numViewports, int viewportIx, bool is2D, bool isHorizontal)
	{
		string cachedImageName = GetCachedImageName(_originalDesign.GetType().Name, title, numViewports, viewportIx, is2D, isHorizontal);
		if (File.Exists(cachedImageName))
		{
			return Image.FromFile(cachedImageName);
		}
		if (!Directory.Exists(_devDeptImageCacheFolder))
		{
			if (Directory.Exists(_majorVersionFolder))
			{
				string[] directories = Directory.GetDirectories(_majorVersionFolder);
				for (int i = 0; i < directories.Length; i++)
				{
					Directory.Delete(directories[i], recursive: true);
				}
			}
			Directory.CreateDirectory(_devDeptImageCacheFolder);
		}
		Image layoutBitmap = GetLayoutBitmap(controlImageList.ImageSize.Width);
		if (_firstImage)
		{
			layoutBitmap = GetLayoutBitmap(controlImageList.ImageSize.Width);
			_firstImage = false;
		}
		layoutBitmap.Save(cachedImageName, ImageFormat.Png);
		return layoutBitmap;
	}

	private string GetCachedImageName(string workspaceType, string title, int numViewports, int viewportIx, bool is2D, bool isHorizontal)
	{
		string text = (is2D ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600411) : string.Empty);
		string text2 = (isHorizontal ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600425) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600401));
		return Path.Combine(_devDeptImageCacheFolder, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600417), _imagePreambleName, workspaceType, title, numViewports, viewportIx, text2, text));
	}

	private void SetTopView(Design design, Viewport viewport, int margin)
	{
		viewport.Camera.Rotation = viewType.Top;
		PrepareParallelProjectionAndFit(design, viewport, Color.Gainsboro, margin);
		SetGrid(viewport, visible: true, 10.0, Plane.XY);
	}

	private void SetFrontView(Design design, Viewport viewport, int margin)
	{
		viewport.Camera.Rotation = viewType.Front;
		PrepareParallelProjectionAndFit(design, viewport, Color.Gainsboro, margin);
		SetGrid(viewport, visible: true, 10.0, Plane.XZ);
	}

	private void SetSideView(Design design, Viewport viewport, int margin)
	{
		viewport.Camera.Rotation = viewType.Right;
		PrepareParallelProjectionAndFit(design, viewport, Color.Gainsboro, margin);
		SetGrid(viewport, visible: true, 10.0, Plane.YZ);
	}

	private static void PrepareParallelProjectionAndFit(Design design, Viewport viewport, Color backColor, int margin)
	{
		viewport.Camera.ProjectionMode = projectionType.Orthographic;
		viewport.AdjustNearAndFarPlanes();
		viewport.DisplayMode = displayType.Wireframe;
		if (viewport.ViewCubeIcon != null)
		{
			viewport.ViewCubeIcon.Visible = false;
		}
		viewport.Rotate.Enabled = false;
		devDept.Eyeshot.Control.ToolBar toolBar = viewport.ToolBar;
		if (toolBar != null && toolBar.Buttons != null)
		{
			ToolBarButtonList toolBarButtonList = new ToolBarButtonList(toolBar);
			foreach (devDept.Eyeshot.Control.ToolBarButton button in toolBar.Buttons)
			{
				if (!(button is HomeToolBarButton) && !(button is RotateToolBarButton))
				{
					toolBarButtonList.Add(button);
				}
			}
			toolBar.Buttons = toolBarButtonList;
		}
		if (viewport.Grids.Length != 0)
		{
			viewport.Grid.Visible = false;
		}
		viewport.ZoomFit(margin);
		viewport.Background.StyleMode = backgroundStyleType.Solid;
		viewport.Background.TopColor = RenderContextUtility.ConvertColor(backColor);
	}

	internal void InitializeViewportsByLayoutType(Design design, viewportLayoutType layoutType)
	{
		int num;
		switch (layoutType)
		{
		case viewportLayoutType.SingleViewport:
			num = 1;
			break;
		case viewportLayoutType.TwoViewportsVertical:
		case viewportLayoutType.TwoViewportsHorizontal:
			num = 2;
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnLeft:
		case viewportLayoutType.ThreeViewportsWithOneOnTop:
		case viewportLayoutType.ThreeViewportsWithOneOnRight:
		case viewportLayoutType.ThreeViewportsWithOneOnBottom:
			num = 3;
			break;
		case viewportLayoutType.FourViewports:
			num = 4;
			break;
		default:
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600732) + layoutType.ToString() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600777));
		}
		if (design.Viewports.Count > num)
		{
			while (design.Viewports.Count > num)
			{
				design.Viewports.RemoveAt(design.Viewports.Count - 1);
			}
		}
		else
		{
			while (design.Viewports.Count < num)
			{
				Viewport value = new Viewport();
				design.Viewports.Add(value);
			}
		}
		bool flag = false;
		flag = design is Simulation;
		if (initialCamera != null)
		{
			design.Viewports[0].Camera = (Camera)initialCamera.Clone();
			design.Viewports[0].DisplayMode = initialDisplayMode;
		}
		foreach (Viewport viewport in design.Viewports)
		{
			devDept.Eyeshot.Control.ToolBar toolBar = viewport.ToolBar;
			if (toolBar == null || toolBar.Buttons.Count < 7)
			{
				viewport.ToolBars = new devDept.Eyeshot.Control.ToolBar[1] { devDept.Eyeshot.Control.ToolBar.GetDefaultToolBar() };
			}
			if (viewport.OriginSymbols != null)
			{
				OriginSymbol[] originSymbols = viewport.OriginSymbols;
				for (int i = 0; i < originSymbols.Length; i++)
				{
					originSymbols[i].Lighting = false;
				}
			}
			if (viewport.ViewCubeIcon != null)
			{
				viewport.ViewCubeIcon.Lighting = false;
			}
			if (viewport.CoordinateSystemIcon != null)
			{
				viewport.CoordinateSystemIcon.Lighting = false;
			}
			if (viewport.Grids != null)
			{
				Grid[] grids = viewport.Grids;
				for (int i = 0; i < grids.Length; i++)
				{
					grids[i].Lighting = false;
				}
			}
			if (flag && (viewport.Legends == null || viewport.Legends.Length == 0))
			{
				viewport.Legends = new Legend[1]
				{
					new Legend()
				};
			}
			if (viewport.Legends != null)
			{
				Legend[] legends = viewport.Legends;
				foreach (Legend legend in legends)
				{
					legend.Lighting = false;
					legend.Items = Legend.RedToBlue9;
					legend.SetRange(legend.Min, legend.Max);
					if (flag)
					{
						legend.Visible = true;
					}
				}
			}
			if (flag)
			{
				if (viewport.Histogram != null)
				{
					viewport.Histogram.Visible = true;
				}
				if (viewport.ScaleBar != null)
				{
					viewport.ScaleBar.Visible = true;
				}
			}
		}
		design.ProgressBar.Lighting = false;
		design.LayoutMode = layoutType;
	}

	private void FillSingleViewportImages(List<string> titles)
	{
		for (int i = 0; i < presets.Length; i++)
		{
			MakeSingleViewportLayout(_tempDesign, i, titles);
		}
	}

	internal void MakeSingleViewportLayout(Design design, int index)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.SingleViewport);
		SetLinearColorGradient(design.Viewports[0], presets[index]._0023_003Dz_rLWr0k_003D);
		SetGrid(design, presets[index]);
	}

	private void MakeSingleViewportLayout(Design design, int index, List<string> titles)
	{
		MakeSingleViewportLayout(design, index);
		AddImageWithTitle(presets[index]._0023_003DzbpcTNic_003D, 1, index, is2D: false, isHorizontal: false, titles);
	}

	internal void MakeTwoViewportsVertical(Design design, int index)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.TwoViewportsVertical);
		SetLinearColorGradient(design.Viewports[0], presets[index]._0023_003Dz_rLWr0k_003D);
		SetTopView(design, design.Viewports[1], 30);
		SetGrid(design, presets[index]);
	}

	private void MakeTwoViewportsVertical(Design design, int index, List<string> titles)
	{
		MakeTwoViewportsVertical(design, index);
		AddImageWithTitle(presets[index]._0023_003DzbpcTNic_003D, 2, index, is2D: false, isHorizontal: false, titles);
	}

	internal void MakeTwoViewportsHorizontal(Design design, int index)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.TwoViewportsHorizontal);
		SetLinearColorGradient(design.Viewports[0], presets[index]._0023_003Dz_rLWr0k_003D);
		SetTopView(design, design.Viewports[1], 20);
		SetGrid(design, presets[index]);
	}

	private void MakeTwoViewportsHorizontal(Design design, int index, ImageList collection, List<string> titles)
	{
		MakeTwoViewportsHorizontal(design, index);
		AddImageWithTitle(presets[index]._0023_003DzbpcTNic_003D, 2, index, is2D: false, isHorizontal: false, titles);
	}

	internal void MakeDualViewportLayout(Design design, int index)
	{
		int num = presets.Length;
		if (index < num)
		{
			MakeTwoViewportsVertical(design, index);
		}
	}

	private void FillDualViewportImages(List<string> titles)
	{
		int num = presets.Length;
		for (int i = 0; i < num; i++)
		{
			MakeTwoViewportsVertical(_tempDesign, i, titles);
		}
	}

	internal void MakeThreeViewportsWithOneOnLeft(Design design, int index)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.ThreeViewportsWithOneOnLeft);
		SetLinearColorGradient(design.Viewports[0], presets[index]._0023_003Dz_rLWr0k_003D);
		SetTopView(design, design.Viewports[1], 20);
		SetFrontView(design, design.Viewports[2], 20);
		SetGrid(design, presets[index]);
	}

	private void MakeThreeViewportsWithOneOnLeft(Design design, int index, List<string> titles)
	{
		MakeThreeViewportsWithOneOnLeft(design, index);
		AddImageWithTitle(presets[index]._0023_003DzbpcTNic_003D, 3, index, is2D: false, isHorizontal: false, titles);
	}

	private void FillTripleViewportImages(List<string> titles)
	{
		int num = presets.Length;
		for (int i = 0; i < num; i++)
		{
			MakeThreeViewportsWithOneOnLeft(_tempDesign, i, titles);
		}
	}

	internal void MakeThreeViewportsWithOneOnBottom(Design design)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.ThreeViewportsWithOneOnBottom);
	}

	internal void MakeThreeViewportsWithOneOnRight(Design design)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.ThreeViewportsWithOneOnRight);
	}

	internal void MakeThreeViewportsWithOneOnTop(Design design)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.ThreeViewportsWithOneOnTop);
	}

	private void FillQuadViewportImages(List<string> titles)
	{
		int num = presets.Length;
		for (int i = 0; i < num; i++)
		{
			MakeFourViewports(_tempDesign, i, titles);
		}
	}

	internal void MakeFourViewports(Design design, int index)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.FourViewports);
		SetLinearColorGradient(design.Viewports[0], presets[index]._0023_003Dz_rLWr0k_003D);
		SetTopView(design, design.Viewports[1], 20);
		SetFrontView(design, design.Viewports[2], 20);
		SetSideView(design, design.Viewports[3], 20);
		SetGrid(design, presets[index]);
	}

	private void MakeFourViewports(Design design, int index, List<string> titles)
	{
		MakeFourViewports(design, index);
		AddImageWithTitle(presets[index]._0023_003DzbpcTNic_003D, 4, index, is2D: false, isHorizontal: false, titles);
	}

	private void Fill2DTopViewportImages(List<string> titles)
	{
		Viewport viewport = _tempDesign.Viewports[0];
		Camera camera = (Camera)viewport.Camera.Clone();
		displayType displayMode = viewport.DisplayMode;
		bool enabled = viewport.Rotate.Enabled;
		bool visible = true;
		bool visible2 = true;
		if (viewport.ViewCubeIcon != null)
		{
			visible2 = viewport.ViewCubeIcon.Visible;
		}
		Color color = ((_tempDesign.Entities.Count > 0) ? _tempDesign.Entities[0].Color : Color.Empty);
		if (viewport.Grids.Length != 0)
		{
			visible = viewport.Grid.Visible;
		}
		InitializeViewportsByLayoutType(_tempDesign, viewportLayoutType.SingleViewport);
		_tempDesign.ActiveViewport.Camera.Rotation = viewType.Top;
		PrepareParallelProjectionAndFit(_tempDesign, viewport, Color.White, 30);
		AddImageWithTitle(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600454), 1, 1, is2D: true, isHorizontal: false, titles);
		PrepareParallelProjectionAndFit(_tempDesign, viewport, Color.Black, 30);
		AddImageWithTitle(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600791), 1, 1, is2D: true, isHorizontal: false, titles);
		PrepareParallelProjectionAndFit(_tempDesign, viewport, Color.Gainsboro, 30);
		AddImageWithTitle(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601333), 1, 1, is2D: true, isHorizontal: false, titles);
		PrepareParallelProjectionAndFit(_tempDesign, viewport, Color.FromArgb(0, 0, 63), 30);
		AddImageWithTitle(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600811), 1, 1, is2D: true, isHorizontal: false, titles);
		viewport.DisplayMode = displayMode;
		viewport.Camera = camera;
		viewport.Rotate.Enabled = enabled;
		if (viewport.Grids.Length != 0)
		{
			viewport.Grid.Visible = visible;
		}
		if (viewport.ViewCubeIcon != null)
		{
			viewport.ViewCubeIcon.Visible = visible2;
		}
		if (_tempDesign.Entities.Count > 0)
		{
			_tempDesign.Entities[0].Color = color;
		}
	}

	internal void Make2DTopView(Design design, int index)
	{
		InitializeViewportsByLayoutType(design, viewportLayoutType.SingleViewport);
		design.ActiveViewport.Camera.Rotation = viewType.Top;
		switch (index)
		{
		case 0:
			PrepareParallelProjectionAndFit(design, design.Viewports[0], Color.White, 30);
			break;
		case 1:
			PrepareParallelProjectionAndFit(design, design.Viewports[0], Color.Black, 30);
			break;
		case 2:
			PrepareParallelProjectionAndFit(design, design.Viewports[0], Color.Gainsboro, 30);
			break;
		case 3:
			PrepareParallelProjectionAndFit(design, design.Viewports[0], Color.FromArgb(0, 0, 63), 30);
			break;
		}
	}

	private void SetLinearColorGradient(Viewport viewport, _0023_003DzkL9NjBgQ_0024yeKBAvT2Q_003D_003D gradient)
	{
		viewport.Background.StyleMode = backgroundStyleType.LinearGradient;
		viewport.Background.BottomColor = RenderContextUtility.ConvertColor(gradientColor[(int)gradient, 0]);
		viewport.Background.TopColor = RenderContextUtility.ConvertColor(gradientColor[(int)gradient, 1]);
	}

	private void SetGrid(Design design, _0023_003DzGBzdi_g_003D pr)
	{
		SetGrid(design.ActiveViewport, visible: true);
	}

	private void SetGrid(Viewport viewport, bool visible, double step = 10.0, Plane plane = null)
	{
		Grid grid = viewport.Grid;
		grid.Visible = true;
		grid.Step = step;
		if (plane != null)
		{
			grid.Plane = plane;
		}
	}

	private Image GetLayoutBitmap(int bmpSize)
	{
		_tempDesign.RenderContext.MakeCurrent();
		_tempDesign.CompileUserInterfaceElements();
		return _tempDesign.GetPresetManagerThumbnail(bmpSize);
	}

	private void showDesignerCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		WriteRegistry(showDesignerCheckBox.Checked);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		new System.ComponentModel.ComponentResourceManager(typeof(devDept.Eyeshot.Designer.PresetManager));
		this.layoutListView = new System.Windows.Forms.ListView();
		this.layoutImageList = new System.Windows.Forms.ImageList(this.components);
		this.loadButton = new System.Windows.Forms.Button();
		this.showDesignerCheckBox = new System.Windows.Forms.CheckBox();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.presetListView = new _0023_003DzHYgOs2MdsobpKI3Os7Iof1eYlYY2wPlA_Krta9c_003D();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.layoutListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
		this.layoutListView.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutListView.Location = new System.Drawing.Point(0, 0);
		this.layoutListView.MultiSelect = false;
		this.layoutListView.Name = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600826);
		this.layoutListView.Size = new System.Drawing.Size(112, 753);
		this.layoutListView.SmallImageList = this.layoutImageList;
		this.layoutListView.TabIndex = 0;
		this.layoutListView.UseCompatibleStateImageBehavior = false;
		this.layoutListView.View = System.Windows.Forms.View.List;
		this.layoutListView.SelectedIndexChanged += new System.EventHandler(layoutListView_SelectedIndexChanged);
		this.layoutImageList.TransparentColor = System.Drawing.Color.Transparent;
		this.layoutImageList.Images.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600581), _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzRY7N522C4ui9());
		this.layoutImageList.Images.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600596), _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzbWAsgCMkwU6mbC6_hw_003D_003D());
		this.layoutImageList.Images.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600613), _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dzm_0024dujxcU4_00241AIt8Clw_003D_003D());
		this.layoutImageList.Images.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600628), _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz0T9O_0024H956WIEGt7p_g_003D_003D());
		this.layoutImageList.Images.Add(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600645), _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DztSfHBhepZTupGYVd3A_003D_003D());
		this.loadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.loadButton.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.loadButton.Location = new System.Drawing.Point(1026, 771);
		this.loadButton.Name = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600661);
		this.loadButton.Size = new System.Drawing.Size(75, 23);
		this.loadButton.TabIndex = 2;
		this.loadButton.Text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600676);
		this.loadButton.UseVisualStyleBackColor = true;
		this.loadButton.Click += new System.EventHandler(loadButton_Click);
		this.showDesignerCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.showDesignerCheckBox.AutoSize = true;
		this.showDesignerCheckBox.Checked = true;
		this.showDesignerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
		this.showDesignerCheckBox.Location = new System.Drawing.Point(12, 775);
		this.showDesignerCheckBox.Name = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600697);
		this.showDesignerCheckBox.Size = new System.Drawing.Size(421, 17);
		this.showDesignerCheckBox.TabIndex = 3;
		this.showDesignerCheckBox.Text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602014);
		this.showDesignerCheckBox.UseVisualStyleBackColor = true;
		this.showDesignerCheckBox.CheckedChanged += new System.EventHandler(showDesignerCheckBox_CheckedChanged);
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.Location = new System.Drawing.Point(12, 12);
		this.splitContainer1.Name = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602088);
		this.splitContainer1.Panel1.Controls.Add(this.layoutListView);
		this.splitContainer1.Panel2.Controls.Add(this.presetListView);
		this.splitContainer1.Size = new System.Drawing.Size(1090, 753);
		this.splitContainer1.SplitterDistance = 112;
		this.splitContainer1.TabIndex = 4;
		this.presetListView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.presetListView.Location = new System.Drawing.Point(0, 0);
		this.presetListView.Margin = new System.Windows.Forms.Padding(0);
		this.presetListView.MultiSelect = false;
		this.presetListView.Name = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602098);
		this.presetListView.Size = new System.Drawing.Size(973, 753);
		this.presetListView.TabIndex = 1;
		this.presetListView.TileSize = new System.Drawing.Size(250, 200);
		this.presetListView.UseCompatibleStateImageBehavior = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1114, 801);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.loadButton);
		base.Controls.Add(this.showDesignerCheckBox);
		this.Font = new System.Drawing.Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597689), 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzZdKxiCiVS_yU();
		base.Name = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601885);
		this.Text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601897);
		base.TopMost = true;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
