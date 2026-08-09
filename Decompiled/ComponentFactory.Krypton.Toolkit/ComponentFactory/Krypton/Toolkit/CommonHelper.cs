#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ComponentFactory.Krypton.Toolkit;

public static class CommonHelper
{
	private const int VK_SHIFT = 16;

	private const int VK_CONTROL = 17;

	private const int VK_MENU = 18;

	private static readonly char[] _singleDateFormat = new char[13]
	{
		'd', 'f', 'F', 'g', 'h', 'H', 'K', 'm', 'M', 's',
		't', 'y', 'z'
	};

	private static readonly Padding _inheritPadding = new Padding(-1);

	private static readonly int[] _daysInMonth = new int[12]
	{
		0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
		304, 334
	};

	private static readonly ColorMatrix _matrixDisabled = new ColorMatrix(new float[5][]
	{
		new float[5] { 0.3f, 0.3f, 0.3f, 0f, 0f },
		new float[5] { 0.59f, 0.59f, 0.59f, 0f, 0f },
		new float[5] { 0.11f, 0.11f, 0.11f, 0f, 0f },
		new float[5] { 0f, 0f, 0f, 0.5f, 0f },
		new float[5] { 0f, 0f, 0f, 0f, 1f }
	});

	private static int _nextId = 1000;

	private static DateTime _baseDate = new DateTime(2000, 1, 1);

	private static PropertyInfo _cachedShortcutPI;

	private static PropertyInfo _cachedDesignModePI;

	private static MethodInfo _cachedShortcutMI;

	private static NullContentValues _nullContentValues;

	private static Point _nullPoint = new Point(int.MaxValue, int.MaxValue);

	private static Rectangle _nullRectangle = new Rectangle(int.MaxValue, int.MaxValue, 0, 0);

	private static DoubleConverter _dc = new DoubleConverter();

	private static SizeConverter _sc = new SizeConverter();

	private static PointConverter _pc = new PointConverter();

	private static BooleanConverter _bc = new BooleanConverter();

	private static ColorConverter _cc = new ColorConverter();

	private static Form _activeFloatingWindow;

	public static Point NullPoint
	{
		[DebuggerStepThrough]
		get
		{
			return _nullPoint;
		}
	}

	public static Rectangle NullRectangle
	{
		[DebuggerStepThrough]
		get
		{
			return _nullRectangle;
		}
	}

	public static ColorMatrix MatrixDisabled
	{
		[DebuggerStepThrough]
		get
		{
			return _matrixDisabled;
		}
	}

	public static int NextId
	{
		[DebuggerStepThrough]
		get
		{
			return _nextId++;
		}
	}

	public static string UniqueString
	{
		get
		{
			PI.GUIDSTRUCT guid = default(PI.GUIDSTRUCT);
			PI.CoCreateGuid(ref guid);
			return $"{guid.Data1:X4}{guid.Data2:X4}{guid.Data3:X4}{guid.Data4:X4}{guid.Data5:X4}{guid.Data6:X4}{guid.Data7:X4}{guid.Data8:X4}";
		}
	}

	public static Padding InheritPadding
	{
		[DebuggerStepThrough]
		get
		{
			return _inheritPadding;
		}
	}

	public static IContentValues NullContentValues
	{
		get
		{
			if (_nullContentValues == null)
			{
				_nullContentValues = new NullContentValues();
			}
			return _nullContentValues;
		}
	}

	public static bool IsShiftKeyPressed
	{
		[DebuggerStepThrough]
		get
		{
			return (PI.GetKeyState(16) & 0x8000) != 0;
		}
	}

	public static bool IsCtrlKeyPressed
	{
		[DebuggerStepThrough]
		get
		{
			return (PI.GetKeyState(17) & 0x8000) != 0;
		}
	}

	public static bool IsAltKeyPressed
	{
		[DebuggerStepThrough]
		get
		{
			return (PI.GetKeyState(18) & 0x8000) != 0;
		}
	}

	public static Form ActiveFloatingWindow
	{
		get
		{
			return _activeFloatingWindow;
		}
		set
		{
			_activeFloatingWindow = value;
		}
	}

	public static bool CheckContextMenuForShortcut(ContextMenuStrip cms, ref Message msg, Keys keyData)
	{
		if (cms != null)
		{
			if (_cachedShortcutPI == null)
			{
				_cachedShortcutPI = typeof(ToolStrip).GetProperty("Shortcuts", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);
				_cachedShortcutMI = typeof(ToolStripMenuItem).GetMethod("ProcessCmdKey", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			Hashtable hashtable = (Hashtable)_cachedShortcutPI.GetValue(cms, null);
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)hashtable[keyData];
			if (toolStripMenuItem != null)
			{
				object obj = _cachedShortcutMI.Invoke(toolStripMenuItem, new object[2] { msg, keyData });
				if (obj != null)
				{
					return (bool)obj;
				}
			}
		}
		return false;
	}

	public static Size ApplyPadding(Orientation orientation, Size size, Padding padding)
	{
		if (!padding.Equals(InheritPadding))
		{
			switch (orientation)
			{
			case Orientation.Vertical:
				size.Width += padding.Vertical;
				size.Height += padding.Horizontal;
				break;
			case Orientation.Horizontal:
				size.Width += padding.Horizontal;
				size.Height += padding.Vertical;
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		return size;
	}

	public static Size ApplyPadding(VisualOrientation orientation, Size size, Padding padding)
	{
		if (!padding.Equals(InheritPadding))
		{
			switch (orientation)
			{
			case VisualOrientation.Top:
			case VisualOrientation.Bottom:
				size.Width += padding.Horizontal;
				size.Height += padding.Vertical;
				break;
			case VisualOrientation.Left:
			case VisualOrientation.Right:
				size.Width += padding.Vertical;
				size.Height += padding.Horizontal;
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		return size;
	}

	public static Rectangle ApplyPadding(Orientation orientation, Rectangle rect, Padding padding)
	{
		if (!padding.Equals(InheritPadding))
		{
			switch (orientation)
			{
			case Orientation.Horizontal:
				rect.X += padding.Left;
				rect.Width -= padding.Horizontal;
				rect.Y += padding.Top;
				rect.Height -= padding.Vertical;
				break;
			case Orientation.Vertical:
				rect.X += padding.Top;
				rect.Width -= padding.Vertical;
				rect.Y += padding.Right;
				rect.Height -= padding.Horizontal;
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		return rect;
	}

	public static Rectangle ApplyPadding(VisualOrientation orientation, Rectangle rect, Padding padding)
	{
		if (!padding.Equals(InheritPadding))
		{
			switch (orientation)
			{
			case VisualOrientation.Top:
				rect = new Rectangle(rect.X + padding.Left, rect.Y + padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical);
				break;
			case VisualOrientation.Bottom:
				rect = new Rectangle(rect.X + padding.Right, rect.Y + padding.Bottom, rect.Width - padding.Horizontal, rect.Height - padding.Vertical);
				break;
			case VisualOrientation.Left:
				rect = new Rectangle(rect.X + padding.Top, rect.Y + padding.Right, rect.Width - padding.Vertical, rect.Height - padding.Horizontal);
				break;
			case VisualOrientation.Right:
				rect = new Rectangle(rect.X + padding.Bottom, rect.Y + padding.Left, rect.Width - padding.Vertical, rect.Height - padding.Horizontal);
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		return rect;
	}

	public static Padding OrientatePadding(VisualOrientation orientation, Padding padding)
	{
		switch (orientation)
		{
		case VisualOrientation.Top:
			return padding;
		case VisualOrientation.Bottom:
			return new Padding(padding.Right, padding.Bottom, padding.Left, padding.Top);
		case VisualOrientation.Left:
			return new Padding(padding.Top, padding.Right, padding.Bottom, padding.Left);
		case VisualOrientation.Right:
			return new Padding(padding.Bottom, padding.Left, padding.Top, padding.Right);
		default:
			Debug.Assert(condition: false);
			return padding;
		}
	}

	[DebuggerStepThrough]
	public static void SwapRectangleSizes(ref Rectangle rect)
	{
		int width = rect.Width;
		rect.Width = rect.Height;
		rect.Height = width;
	}

	public static bool GetRightToLeftLayout(Control control)
	{
		bool result = false;
		if (control != null)
		{
			Form form = control.FindForm();
			if (form != null)
			{
				result = form.RightToLeftLayout;
			}
		}
		return result;
	}

	public static bool ValidContextMenuStrip(ContextMenuStrip cms)
	{
		return cms != null && cms.Items.Count > 0;
	}

	public static bool ValidKryptonContextMenu(KryptonContextMenu kcm)
	{
		return kcm != null && kcm.Items.Count > 0;
	}

	public static object PerformOperation(Operation op, object parameter)
	{
		using ModalWaitDialog modalWaitDialog = new ModalWaitDialog();
		OperationThread operationThread = new OperationThread(op, parameter);
		Thread thread = new Thread(operationThread.Run);
		thread.Start();
		while (operationThread.State == 0)
		{
			Thread.Sleep(25);
			modalWaitDialog.UpdateDialog();
		}
		switch (operationThread.State)
		{
		case 1:
			return operationThread.Result;
		case 2:
			throw operationThread.Exception;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	[DebuggerStepThrough]
	public static bool IsOverrideState(PaletteState state)
	{
		return (state & PaletteState.Override) == PaletteState.Override;
	}

	[DebuggerStepThrough]
	public static bool IsOverrideStateExclude(PaletteState state, PaletteState exclude)
	{
		return state != exclude && IsOverrideState(state);
	}

	[DebuggerStepThrough]
	public static bool HasNoBorders(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.All) == 0;
	}

	[DebuggerStepThrough]
	public static bool HasABorder(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.All) != 0;
	}

	[DebuggerStepThrough]
	public static bool HasOneBorder(PaletteDrawBorders borders)
	{
		PaletteDrawBorders paletteDrawBorders = borders & PaletteDrawBorders.All;
		return paletteDrawBorders == PaletteDrawBorders.Top || paletteDrawBorders == PaletteDrawBorders.Bottom || paletteDrawBorders == PaletteDrawBorders.Left || paletteDrawBorders == PaletteDrawBorders.Right;
	}

	[DebuggerStepThrough]
	public static bool HasTopBorder(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.Top) == PaletteDrawBorders.Top;
	}

	[DebuggerStepThrough]
	public static bool HasBottomBorder(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.Bottom) == PaletteDrawBorders.Bottom;
	}

	[DebuggerStepThrough]
	public static bool HasLeftBorder(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.Left) == PaletteDrawBorders.Left;
	}

	[DebuggerStepThrough]
	public static bool HasRightBorder(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.Right) == PaletteDrawBorders.Right;
	}

	[DebuggerStepThrough]
	public static bool HasAllBorders(PaletteDrawBorders borders)
	{
		return (borders & PaletteDrawBorders.All) == PaletteDrawBorders.All;
	}

	public static PaletteDrawBorders OrientateDrawBorders(PaletteDrawBorders borders, VisualOrientation orientation)
	{
		if (orientation == VisualOrientation.Top)
		{
			return borders;
		}
		if (borders == PaletteDrawBorders.All || borders == PaletteDrawBorders.None)
		{
			return borders;
		}
		PaletteDrawBorders paletteDrawBorders = PaletteDrawBorders.None;
		switch (orientation)
		{
		case VisualOrientation.Bottom:
			if (HasTopBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Bottom;
			}
			if (HasBottomBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Top;
			}
			if (HasLeftBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Right;
			}
			if (HasRightBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Left;
			}
			break;
		case VisualOrientation.Left:
			if (HasTopBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Left;
			}
			if (HasBottomBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Right;
			}
			if (HasLeftBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Bottom;
			}
			if (HasRightBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Top;
			}
			break;
		case VisualOrientation.Right:
			if (HasTopBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Right;
			}
			if (HasBottomBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Left;
			}
			if (HasLeftBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Top;
			}
			if (HasRightBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Bottom;
			}
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return paletteDrawBorders;
	}

	public static PaletteDrawBorders ReverseOrientateDrawBorders(PaletteDrawBorders borders, VisualOrientation orientation)
	{
		if (orientation == VisualOrientation.Top)
		{
			return borders;
		}
		if (borders == PaletteDrawBorders.All || borders == PaletteDrawBorders.None)
		{
			return borders;
		}
		PaletteDrawBorders paletteDrawBorders = PaletteDrawBorders.None;
		switch (orientation)
		{
		case VisualOrientation.Bottom:
			if (HasTopBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Bottom;
			}
			if (HasBottomBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Top;
			}
			if (HasLeftBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Right;
			}
			if (HasRightBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Left;
			}
			break;
		case VisualOrientation.Right:
			if (HasTopBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Left;
			}
			if (HasBottomBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Right;
			}
			if (HasLeftBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Bottom;
			}
			if (HasRightBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Top;
			}
			break;
		case VisualOrientation.Left:
			if (HasTopBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Right;
			}
			if (HasBottomBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Left;
			}
			if (HasLeftBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Top;
			}
			if (HasRightBorder(borders))
			{
				paletteDrawBorders |= PaletteDrawBorders.Bottom;
			}
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return paletteDrawBorders;
	}

	public static Orientation VisualToOrientation(VisualOrientation orientation)
	{
		switch (orientation)
		{
		case VisualOrientation.Top:
		case VisualOrientation.Bottom:
			return Orientation.Vertical;
		case VisualOrientation.Left:
		case VisualOrientation.Right:
			return Orientation.Horizontal;
		default:
			Debug.Assert(condition: false);
			return Orientation.Vertical;
		}
	}

	public static PaletteButtonStyle ButtonStyleToPalette(ButtonStyle style)
	{
		switch (style)
		{
		case ButtonStyle.Standalone:
			return PaletteButtonStyle.Standalone;
		case ButtonStyle.Alternate:
			return PaletteButtonStyle.Alternate;
		case ButtonStyle.LowProfile:
			return PaletteButtonStyle.LowProfile;
		case ButtonStyle.ButtonSpec:
			return PaletteButtonStyle.ButtonSpec;
		case ButtonStyle.BreadCrumb:
			return PaletteButtonStyle.BreadCrumb;
		case ButtonStyle.Cluster:
			return PaletteButtonStyle.Cluster;
		case ButtonStyle.NavigatorStack:
			return PaletteButtonStyle.NavigatorStack;
		case ButtonStyle.NavigatorOverflow:
			return PaletteButtonStyle.NavigatorOverflow;
		case ButtonStyle.NavigatorMini:
			return PaletteButtonStyle.NavigatorMini;
		case ButtonStyle.InputControl:
			return PaletteButtonStyle.InputControl;
		case ButtonStyle.ListItem:
			return PaletteButtonStyle.ListItem;
		case ButtonStyle.Form:
			return PaletteButtonStyle.Form;
		case ButtonStyle.FormClose:
			return PaletteButtonStyle.FormClose;
		case ButtonStyle.Command:
			return PaletteButtonStyle.Command;
		case ButtonStyle.Custom1:
			return PaletteButtonStyle.Custom1;
		case ButtonStyle.Custom2:
			return PaletteButtonStyle.Custom2;
		case ButtonStyle.Custom3:
			return PaletteButtonStyle.Custom3;
		default:
			Debug.Assert(condition: false);
			return PaletteButtonStyle.Standalone;
		}
	}

	public static GraphicsPath RoundedRectanglePath(Rectangle rect, int rounding)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		rounding = Math.Min(rounding, Math.Min(rect.Width / 2, rect.Height / 2) - rounding);
		if (rounding <= 0)
		{
			graphicsPath.AddRectangle(rect);
		}
		else
		{
			RectangleF rectangleF = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
			int num = rounding * 2;
			graphicsPath.AddArc(rectangleF.Left, rectangleF.Top, num, num, 180f, 90f);
			graphicsPath.AddArc(rectangleF.Right - (float)num, rectangleF.Top, num, num, 270f, 90f);
			graphicsPath.AddArc(rectangleF.Right - (float)num, rectangleF.Bottom - (float)num, num, num, 0f, 90f);
			graphicsPath.AddArc(rectangleF.Left, rectangleF.Bottom - (float)num, num, num, 90f, 90f);
			graphicsPath.CloseFigure();
		}
		return graphicsPath;
	}

	public static Color ColorToBlackAndWhite(Color color)
	{
		int num = (int)((float)(int)color.R * 0.3f + (float)(int)color.G * 0.59f + (float)(int)color.B * 0.11f);
		return Color.FromArgb(num, num, num);
	}

	public static Color WhitenColor(Color color1, float percentR, float percentG, float percentB)
	{
		int num = (int)((float)(int)color1.R / percentR);
		int num2 = (int)((float)(int)color1.G / percentG);
		int num3 = (int)((float)(int)color1.B / percentB);
		if (num < 0)
		{
			num = 0;
		}
		if (num > 255)
		{
			num = 255;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 > 255)
		{
			num2 = 255;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		if (num3 > 255)
		{
			num3 = 255;
		}
		return Color.FromArgb(color1.A, num, num2, num3);
	}

	public static Color BlackenColor(Color color1, float percentR, float percentG, float percentB)
	{
		int num = (int)((float)(int)color1.R * percentR);
		int num2 = (int)((float)(int)color1.G * percentG);
		int num3 = (int)((float)(int)color1.B * percentB);
		if (num < 0)
		{
			num = 0;
		}
		if (num > 255)
		{
			num = 255;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 > 255)
		{
			num2 = 255;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		if (num3 > 255)
		{
			num3 = 255;
		}
		return Color.FromArgb(color1.A, num, num2, num3);
	}

	public static Color MergeColors(Color color1, float percent1, Color color2, float percent2)
	{
		return MergeColors(color1, percent1, color2, percent2, Color.Empty, 0f);
	}

	public static Color MergeColors(Color color1, float percent1, Color color2, float percent2, Color color3, float percent3)
	{
		int num = (int)((float)(int)color1.R * percent1 + (float)(int)color2.R * percent2 + (float)(int)color3.R * percent3);
		int num2 = (int)((float)(int)color1.G * percent1 + (float)(int)color2.G * percent2 + (float)(int)color3.G * percent3);
		int num3 = (int)((float)(int)color1.B * percent1 + (float)(int)color2.B * percent2 + (float)(int)color3.B * percent3);
		if (num < 0)
		{
			num = 0;
		}
		if (num > 255)
		{
			num = 255;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 > 255)
		{
			num2 = 255;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		if (num3 > 255)
		{
			num3 = 255;
		}
		return Color.FromArgb(num, num2, num3);
	}

	public static int ColorDepth()
	{
		IntPtr dC = PI.GetDC(IntPtr.Zero);
		int deviceCaps = PI.GetDeviceCaps(dC, 14);
		int deviceCaps2 = PI.GetDeviceCaps(dC, 12);
		PI.ReleaseDC(IntPtr.Zero, dC);
		return deviceCaps * deviceCaps2;
	}

	public static Control GetControlWithFocus(Control control)
	{
		if (control.Focused && !(control is IContainedInputControl))
		{
			return control;
		}
		foreach (Control control2 in control.Controls)
		{
			if (control2.ContainsFocus)
			{
				return GetControlWithFocus(control2);
			}
		}
		return null;
	}

	public static void AddControlToParent(Control parent, Control c)
	{
		Debug.Assert(parent != null);
		Debug.Assert(c != null);
		if (c.Parent != null)
		{
			RemoveControlFromParent(c);
		}
		if (parent.Controls is KryptonControlCollection)
		{
			KryptonControlCollection kryptonControlCollection = (KryptonControlCollection)parent.Controls;
			kryptonControlCollection.AddInternal(c);
		}
		else
		{
			parent.Controls.Add(c);
		}
	}

	public static void RemoveControlFromParent(Control c)
	{
		Debug.Assert(c != null);
		if (c.Parent != null)
		{
			if (c.Parent.Controls is KryptonControlCollection)
			{
				KryptonControlCollection kryptonControlCollection = (KryptonControlCollection)c.Parent.Controls;
				kryptonControlCollection.RemoveInternal(c);
			}
			else
			{
				c.Parent.Controls.Remove(c);
			}
		}
	}

	public static Padding GetWindowBorders(CreateParams cp)
	{
		PI.RECT rect = new PI.RECT
		{
			left = 0,
			right = 0,
			top = 0,
			bottom = 0
		};
		PI.AdjustWindowRectEx(ref rect, cp.Style, hasMenu: false, cp.ExStyle);
		return new Padding(-rect.left, -rect.top, rect.right, rect.bottom);
	}

	public static bool IsFormMinimized(Form f)
	{
		uint windowLong = PI.GetWindowLong(f.Handle, -16);
		return (windowLong &= 0x20000000) != 0;
	}

	public static bool IsFormMaximized(Form f)
	{
		uint windowLong = PI.GetWindowLong(f.Handle, -16);
		return (windowLong &= 0x1000000) != 0;
	}

	public static Rectangle RealClientRectangle(IntPtr handle)
	{
		PI.RECT rect = default(PI.RECT);
		PI.GetWindowRect(handle, ref rect);
		return new Rectangle(0, 0, rect.right - rect.left, rect.bottom - rect.top);
	}

	public static PaletteContentStyle ContentStyleFromLabelStyle(LabelStyle style)
	{
		switch (style)
		{
		case LabelStyle.NormalControl:
			return PaletteContentStyle.LabelNormalControl;
		case LabelStyle.BoldControl:
			return PaletteContentStyle.LabelBoldControl;
		case LabelStyle.ItalicControl:
			return PaletteContentStyle.LabelItalicControl;
		case LabelStyle.TitleControl:
			return PaletteContentStyle.LabelTitleControl;
		case LabelStyle.NormalPanel:
			return PaletteContentStyle.LabelNormalPanel;
		case LabelStyle.BoldPanel:
			return PaletteContentStyle.LabelBoldPanel;
		case LabelStyle.ItalicPanel:
			return PaletteContentStyle.LabelItalicPanel;
		case LabelStyle.TitlePanel:
			return PaletteContentStyle.LabelTitlePanel;
		case LabelStyle.GroupBoxCaption:
			return PaletteContentStyle.LabelGroupBoxCaption;
		case LabelStyle.ToolTip:
			return PaletteContentStyle.LabelToolTip;
		case LabelStyle.SuperTip:
			return PaletteContentStyle.LabelSuperTip;
		case LabelStyle.KeyTip:
			return PaletteContentStyle.LabelKeyTip;
		case LabelStyle.Custom1:
			return PaletteContentStyle.LabelCustom1;
		case LabelStyle.Custom2:
			return PaletteContentStyle.LabelCustom2;
		case LabelStyle.Custom3:
			return PaletteContentStyle.LabelCustom3;
		default:
			Debug.Assert(condition: false);
			return PaletteContentStyle.LabelNormalPanel;
		}
	}

	public static TextRenderingHint PaletteTextHintToRenderingHint(PaletteTextHint hint)
	{
		switch (hint)
		{
		case PaletteTextHint.AntiAlias:
			return TextRenderingHint.AntiAlias;
		case PaletteTextHint.AntiAliasGridFit:
			return TextRenderingHint.AntiAliasGridFit;
		case PaletteTextHint.ClearTypeGridFit:
			return TextRenderingHint.ClearTypeGridFit;
		case PaletteTextHint.SingleBitPerPixel:
			return TextRenderingHint.SingleBitPerPixel;
		case PaletteTextHint.SingleBitPerPixelGridFit:
			return TextRenderingHint.SingleBitPerPixelGridFit;
		case PaletteTextHint.SystemDefault:
			return TextRenderingHint.SystemDefault;
		default:
			Debug.Assert(condition: false);
			return TextRenderingHint.SystemDefault;
		}
	}

	public static PaletteMetricPadding SeparatorStyleToMetricPadding(SeparatorStyle separatorStyle)
	{
		switch (separatorStyle)
		{
		case SeparatorStyle.LowProfile:
			return PaletteMetricPadding.SeparatorPaddingLowProfile;
		case SeparatorStyle.HighProfile:
			return PaletteMetricPadding.SeparatorPaddingHighProfile;
		case SeparatorStyle.HighInternalProfile:
			return PaletteMetricPadding.SeparatorPaddingHighInternalProfile;
		case SeparatorStyle.Custom1:
			return PaletteMetricPadding.SeparatorPaddingCustom1;
		default:
			Debug.Assert(condition: false);
			return PaletteMetricPadding.SeparatorPaddingLowProfile;
		}
	}

	public static string MakeCustomDateFormat(string format)
	{
		if (format.Length == 1 && format.IndexOfAny(_singleDateFormat) == 0)
		{
			format = "%" + format;
		}
		return format;
	}

	public static object CreateInstance(Type itemType, IDesignerHost host)
	{
		object obj = null;
		if (typeof(IComponent).IsAssignableFrom(itemType) && host != null)
		{
			obj = host.CreateComponent(itemType, null);
			if (host.GetDesigner((IComponent)obj) is IComponentInitializer componentInitializer)
			{
				componentInitializer.InitializeNewComponent(null);
			}
		}
		else
		{
			obj = TypeDescriptor.CreateInstance(host, itemType, null, null);
		}
		return obj;
	}

	public static void DestroyInstance(object instance, IDesignerHost host)
	{
		if (instance is IComponent component)
		{
			if (host != null)
			{
				host.DestroyComponent(component);
			}
			else
			{
				component.Dispose();
			}
		}
		else if (instance is IDisposable disposable)
		{
			disposable.Dispose();
		}
	}

	public static void LogOutput(string str)
	{
		FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
		using StreamWriter streamWriter = new StreamWriter(fileInfo.DirectoryName + "LogOutput.txt", append: true, Encoding.ASCII);
		streamWriter.Write(DateTime.Now.ToLongTimeString() + " :  ");
		streamWriter.WriteLine(str);
		streamWriter.Flush();
	}

	public static bool DesignMode(Component c)
	{
		if (_cachedDesignModePI == null)
		{
			_cachedDesignModePI = typeof(ToolStrip).GetProperty("DesignMode", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);
		}
		return (bool)_cachedDesignModePI.GetValue(c, null);
	}

	public static string DoubleToString(double d)
	{
		return _dc.ConvertToInvariantString(d);
	}

	public static double StringToDouble(string s)
	{
		return (double)_dc.ConvertFromInvariantString(s);
	}

	public static string SizeToString(Size s)
	{
		return _sc.ConvertToInvariantString(s);
	}

	public static Size StringToSize(string s)
	{
		return (Size)_sc.ConvertFromInvariantString(s);
	}

	public static string PointToString(Point s)
	{
		return _pc.ConvertToInvariantString(s);
	}

	public static Point StringToPoint(string s)
	{
		return (Point)_pc.ConvertFromInvariantString(s);
	}

	public static string BoolToString(bool b)
	{
		return _bc.ConvertToInvariantString(b);
	}

	public static bool StringToBool(string s)
	{
		return (bool)_bc.ConvertFromInvariantString(s);
	}

	public static string ColorToString(Color c)
	{
		return _cc.ConvertToInvariantString(c);
	}

	public static Color StringToColor(string s)
	{
		return (Color)_cc.ConvertFromInvariantString(s);
	}

	public static Point ClientMouseMessageToScreenPt(Message m)
	{
		PI.POINTC pOINTC = new PI.POINTC();
		pOINTC.x = PI.LOWORD((int)m.LParam);
		pOINTC.y = PI.HIWORD((int)m.LParam);
		if (pOINTC.x >= 32767)
		{
			pOINTC.x -= 65536;
		}
		if (pOINTC.y >= 32767)
		{
			pOINTC.y -= 65536;
		}
		PI.POINTC pOINTC2 = new PI.POINTC();
		pOINTC2.x = 0;
		pOINTC2.y = 0;
		PI.MapWindowPoints(m.HWnd, IntPtr.Zero, pOINTC2, 1);
		pOINTC.x += pOINTC2.x;
		pOINTC.y += pOINTC2.y;
		return new Point(pOINTC.x, pOINTC.y);
	}

	public static void TextToXmlAttribute(XmlWriter xmlWriter, string name, string value)
	{
		TextToXmlAttribute(xmlWriter, name, value, string.Empty);
	}

	public static void TextToXmlAttribute(XmlWriter xmlWriter, string name, string value, string def)
	{
		if (!string.IsNullOrEmpty(value) && value != def)
		{
			xmlWriter.WriteAttributeString(name, value);
		}
	}

	public static string XmlAttributeToText(XmlReader xmlReader, string name)
	{
		return XmlAttributeToText(xmlReader, name, string.Empty);
	}

	public static string XmlAttributeToText(XmlReader xmlReader, string name, string def)
	{
		try
		{
			string text = xmlReader.GetAttribute(name);
			if (text == null)
			{
				text = def;
			}
			return text;
		}
		catch
		{
			return def;
		}
	}

	public static void ImageToXmlCData(XmlWriter xmlWriter, string name, Image image)
	{
		if (image != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, image);
			string text = Convert.ToBase64String(memoryStream.ToArray());
			xmlWriter.WriteStartElement(name);
			xmlWriter.WriteCData(text);
			xmlWriter.WriteEndElement();
		}
	}

	public static Image XmlCDataToImage(XmlReader xmlReader)
	{
		byte[] buffer = Convert.FromBase64String(xmlReader.ReadContentAsString());
		MemoryStream serializationStream = new MemoryStream(buffer);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		return (Image)binaryFormatter.Deserialize(serializationStream);
	}
}
