using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ScintillaNET;

[Docking(DockingBehavior.Ask)]
[Designer(typeof(ScintillaDesigner))]
public class Scintilla : Control
{
	private static bool? reparentAll;

	private bool reparent;

	private static readonly string modulePathScintilla;

	private static readonly string modulePathLexilla;

	private static nint moduleHandle;

	private static NativeMethods.Scintilla_DirectFunction directFunction;

	private static nint lexillaHandle;

	private static Lexilla lexilla;

	private static readonly object scNotificationEventKey;

	private static readonly object insertCheckEventKey;

	private static readonly object beforeInsertEventKey;

	private static readonly object beforeDeleteEventKey;

	private static readonly object insertEventKey;

	private static readonly object deleteEventKey;

	private static readonly object updateUIEventKey;

	private static readonly object modifyAttemptEventKey;

	private static readonly object styleNeededEventKey;

	private static readonly object savePointReachedEventKey;

	private static readonly object savePointLeftEventKey;

	private static readonly object changeAnnotationEventKey;

	private static readonly object marginClickEventKey;

	private static readonly object marginRightClickEventKey;

	private static readonly object charAddedEventKey;

	private static readonly object autoCSelectionEventKey;

	private static readonly object autoCSelectionChangeEventKey;

	private static readonly object autoCCompletedEventKey;

	private static readonly object autoCCancelledEventKey;

	private static readonly object autoCCharDeletedEventKey;

	private static readonly object dwellStartEventKey;

	private static readonly object callTipClickEventKey;

	private static readonly object dwellEndEventKey;

	private static readonly object borderStyleChangedEventKey;

	private static readonly object doubleClickEventKey;

	private static readonly object paintedEventKey;

	private static readonly object needShownEventKey;

	private static readonly object hotspotClickEventKey;

	private static readonly object hotspotDoubleClickEventKey;

	private static readonly object hotspotReleaseClickEventKey;

	private static readonly object indicatorClickEventKey;

	private static readonly object indicatorReleaseEventKey;

	private static readonly object zoomChangedEventKey;

	private nint sciPtr;

	private BorderStyle borderStyle;

	private int stylingPosition;

	private int stylingBytePosition;

	private int? cachedPosition;

	private string cachedText;

	private bool doubleClick;

	private nint fillUpChars;

	private string lastCallTip = string.Empty;

	private VisualStyleRenderer renderer;

	public const int TimeForever = 10000000;

	public const int InvalidPosition = -1;

	private static readonly string scintillaVersion;

	private static readonly string lexillaVersion;

	private string lexerName;

	public string ScintillaVersion => scintillaVersion;

	public string LexillaVersion => lexillaVersion;

	[DefaultValue(Layer.Base)]
	[Category("Selection")]
	[Description("The layer where the text selection will be painted.")]
	public Layer SelectionLayer
	{
		get
		{
			return (Layer)((IntPtr)DirectMessage(2762)).ToInt32();
		}
		set
		{
			DirectMessage(2763, new IntPtr((int)value), IntPtr.Zero);
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	[Description("Indicates whether Scintilla's native drag && drop should be used instead of WinForms based one.")]
	public bool _ScintillaManagedDragDrop { get; set; }

	[DefaultValue(BiDirectionalDisplayType.Disabled)]
	[Category("Behavior")]
	[Description("The bi-directionality of the Scintilla control.")]
	public BiDirectionalDisplayType BiDirectionality
	{
		get
		{
			return (BiDirectionalDisplayType)((IntPtr)DirectMessage(2708)).ToInt32();
		}
		set
		{
			if (value != BiDirectionalDisplayType.Disabled && ((IntPtr)DirectMessage(2631)).ToInt32() == 0)
			{
				DirectMessage(2630, new IntPtr(1));
			}
			DirectMessage(2709, new IntPtr((int)value));
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	[Description("A value indicating whether the reading layout is from right to left.")]
	public bool UseRightToLeftReadingLayout
	{
		get
		{
			if (!base.IsHandleCreated)
			{
				return false;
			}
			long num = ((IntPtr)base.Handle.GetWindowLongPtr(-20)).ToInt64();
			return num == (num | 0x400000);
		}
		set
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			long num = ((IntPtr)base.Handle.GetWindowLongPtr(-20)).ToInt64();
			if (value)
			{
				if (((IntPtr)DirectMessage(2631)).ToInt32() != 0)
				{
					DirectMessage(2630, new IntPtr(0));
				}
				num |= 0x400000;
			}
			else
			{
				num &= -4194305;
			}
			base.Handle.SetWindowLongPtr(-20, new IntPtr(num));
			WrapMode wrapMode = WrapMode;
			WrapMode = ((wrapMode == WrapMode.None) ? WrapMode.Word : WrapMode.None);
			WrapMode = wrapMode;
		}
	}

	[Category("Multiple Selection")]
	[Description("The additional caret foreground color.")]
	public Color AdditionalCaretForeColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(41))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(41), new IntPtr(value2));
		}
	}

	[DefaultValue(true)]
	[Category("Multiple Selection")]
	[Description("Whether the carets in additional selections should blink.")]
	public bool AdditionalCaretsBlink
	{
		get
		{
			return DirectMessage(2568) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2567, wParam);
		}
	}

	[DefaultValue(true)]
	[Category("Multiple Selection")]
	[Description("Whether the carets in additional selections are visible.")]
	public bool AdditionalCaretsVisible
	{
		get
		{
			return DirectMessage(2609) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2608, wParam);
		}
	}

	[DefaultValue(256)]
	[Category("Multiple Selection")]
	[Description("The transparency of additional selections.")]
	[Obsolete("Use SelectionAdditionalTextColor with alpha channel instead.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int AdditionalSelAlpha
	{
		get
		{
			return ((IntPtr)DirectMessage(2603)).ToInt32();
		}
		set
		{
			value = Helpers.Clamp(value, 0, 256);
			DirectMessage(2602, new IntPtr(value));
		}
	}

	[DefaultValue(false)]
	[Category("Multiple Selection")]
	[Description("Whether typing, backspace, or delete works with multiple selection simultaneously.")]
	public bool AdditionalSelectionTyping
	{
		get
		{
			return DirectMessage(2566) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2565, wParam);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AnchorPosition
	{
		get
		{
			int pos = ((IntPtr)DirectMessage(2009)).ToInt32();
			return Lines.ByteToCharPosition(pos);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			int value2 = Lines.CharToBytePosition(value);
			DirectMessage(2026, new IntPtr(value2));
		}
	}

	[DefaultValue(Annotation.Hidden)]
	[Category("Appearance")]
	[Description("Display and location of annotations.")]
	public Annotation AnnotationVisible
	{
		get
		{
			return (Annotation)((IntPtr)DirectMessage(2549)).ToInt32();
		}
		set
		{
			DirectMessage(2548, new IntPtr((int)value));
		}
	}

	[Description("The text color in autocompletion lists.")]
	[Category("Autocompletion")]
	[DefaultValue(typeof(Color), "Black")]
	public Color AutocompleteListTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(0))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(0), new IntPtr(value2));
		}
	}

	[Description("The background color in autocompletion lists.")]
	[Category("Autocompletion")]
	[DefaultValue(typeof(Color), "White")]
	public Color AutocompleteListBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(1))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(1), new IntPtr(value2));
		}
	}

	[Description("The text color of selected item in autocompletion lists.")]
	[Category("Autocompletion")]
	[DefaultValue(typeof(Color), "White")]
	public Color AutocompleteListSelectedTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(2))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(2), new IntPtr(value2));
		}
	}

	[Description("The background color of selected item in autocompletion lists.")]
	[Category("Autocompletion")]
	[DefaultValue(typeof(Color), "0, 120, 215")]
	public Color AutocompleteListSelectedBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(3))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(3), new IntPtr(value2));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AutoCActive => DirectMessage(2102) != IntPtr.Zero;

	[DefaultValue(true)]
	[Category("Autocompletion")]
	[Description("Whether to automatically cancel autocompletion when no match is possible.")]
	public bool AutoCAutoHide
	{
		get
		{
			return DirectMessage(2119) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2118, wParam);
		}
	}

	[DefaultValue(true)]
	[Category("Autocompletion")]
	[Description("Whether to cancel an autocompletion if the caret moves from its initial location, or is allowed to move to the word start.")]
	public bool AutoCCancelAtStart
	{
		get
		{
			return DirectMessage(2111) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2110, wParam);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AutoCCurrent => ((IntPtr)DirectMessage(2445)).ToInt32();

	[DefaultValue(false)]
	[Category("Autocompletion")]
	[Description("Whether to automatically choose an autocompletion item when it is the only one in the list.")]
	public bool AutoCChooseSingle
	{
		get
		{
			return DirectMessage(2114) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2113, wParam);
		}
	}

	[DefaultValue(false)]
	[Category("Autocompletion")]
	[Description("Whether to delete any existing word characters following the caret after autocompletion.")]
	public bool AutoCDropRestOfWord
	{
		get
		{
			return DirectMessage(2271) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2270, wParam);
		}
	}

	[DefaultValue(false)]
	[Category("Autocompletion")]
	[Description("Whether autocompletion word matching can ignore case.")]
	public bool AutoCIgnoreCase
	{
		get
		{
			return DirectMessage(2116) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2115, wParam);
		}
	}

	[DefaultValue(9)]
	[Category("Autocompletion")]
	[Description("The maximum number of rows to display in an autocompletion list.")]
	public int AutoCMaxHeight
	{
		get
		{
			return ((IntPtr)DirectMessage(2211)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2210, new IntPtr(value));
		}
	}

	[DefaultValue(0)]
	[Category("Autocompletion")]
	[Description("The width of the autocompletion list measured in characters.")]
	public int AutoCMaxWidth
	{
		get
		{
			return ((IntPtr)DirectMessage(2209)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2208, new IntPtr(value));
		}
	}

	[DefaultValue(Order.Presorted)]
	[Category("Autocompletion")]
	[Description("The order of words in an autocompletion list.")]
	public Order AutoCOrder
	{
		get
		{
			return (Order)((IntPtr)DirectMessage(2661)).ToInt32();
		}
		set
		{
			DirectMessage(2660, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AutoCPosStart
	{
		get
		{
			int pos = ((IntPtr)DirectMessage(2103)).ToInt32();
			return Lines.ByteToCharPosition(pos);
		}
	}

	[DefaultValue(' ')]
	[Category("Autocompletion")]
	[Description("The autocompletion list word delimiter. The default is a space character.")]
	public char AutoCSeparator
	{
		get
		{
			return (char)((IntPtr)DirectMessage(2107)).ToInt32();
		}
		set
		{
			byte value2 = (byte)value;
			DirectMessage(2106, new IntPtr(value2));
		}
	}

	[DefaultValue('?')]
	[Category("Autocompletion")]
	[Description("The autocompletion list image type delimiter.")]
	public char AutoCTypeSeparator
	{
		get
		{
			return (char)((IntPtr)DirectMessage(2285)).ToInt32();
		}
		set
		{
			byte value2 = (byte)value;
			DirectMessage(2286, new IntPtr(value2));
		}
	}

	[DefaultValue(AutomaticFold.None)]
	[Category("Behavior")]
	[Description("Options for allowing the control to automatically handle folding.")]
	[Editor(typeof(FlagsEditor), typeof(UITypeEditor))]
	[TypeConverter(typeof(FlagsConverter))]
	public AutomaticFold AutomaticFold
	{
		get
		{
			return (AutomaticFold)DirectMessage(2664);
		}
		set
		{
			DirectMessage(2663, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	[DefaultValue(false)]
	[Category("Indentation")]
	[Description("Determines whether backspace deletes a character, or unindents.")]
	public bool BackspaceUnindents
	{
		get
		{
			return DirectMessage(2263) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2262, wParam);
		}
	}

	[DefaultValue(BorderStyle.Fixed3D)]
	[Category("Appearance")]
	[Description("Indicates whether the control should have a border.")]
	public BorderStyle BorderStyle
	{
		get
		{
			return borderStyle;
		}
		set
		{
			if (borderStyle != value)
			{
				if (!Enum.IsDefined(typeof(BorderStyle), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(BorderStyle));
				}
				borderStyle = value;
				UpdateStyles();
				OnBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	[Category("Misc")]
	[Description("Determines whether drawing is double-buffered.")]
	public bool BufferedDraw
	{
		get
		{
			return DirectMessage(2034) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2035, wParam);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CallTipActive => DirectMessage(2202) != IntPtr.Zero;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanPaste => DirectMessage(2173) != IntPtr.Zero;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanRedo => DirectMessage(2016) != IntPtr.Zero;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanUndo => DirectMessage(2174) != IntPtr.Zero;

	[DefaultValue(typeof(Color), "Black")]
	[Category("Caret")]
	[Description("The caret foreground color.")]
	public Color CaretForeColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(40))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(40), new IntPtr(value2));
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Category("Caret")]
	[Description("The background color of the current line.")]
	public Color CaretLineBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(50))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(50), new IntPtr(value2));
		}
	}

	[DefaultValue(256)]
	[Category("Caret")]
	[Description("The transparency of the current line background color.")]
	[Obsolete("Use CaretLineBackColor with alpha channel instead.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int CaretLineBackColorAlpha
	{
		get
		{
			return ((IntPtr)DirectMessage(2471)).ToInt32();
		}
		set
		{
			value = Helpers.Clamp(value, 0, 256);
			DirectMessage(2470, new IntPtr(value));
		}
	}

	[DefaultValue(0)]
	[Category("Caret")]
	[Description("The Width of the current line frame.")]
	public int CaretLineFrame
	{
		get
		{
			return ((IntPtr)DirectMessage(2704)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2705, new IntPtr(value));
		}
	}

	[DefaultValue(true)]
	[Category("Caret")]
	[Description("Determines whether to highlight the current caret line.")]
	[Obsolete("Use CaretLineBackColor with alpha channel instead.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool CaretLineVisible
	{
		get
		{
			return DirectMessage(2095) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2096, wParam);
		}
	}

	[DefaultValue(false)]
	[Category("Caret")]
	[Description("Determines whether the caret line always visible even when the window is not in focus..")]
	public bool CaretLineVisibleAlways
	{
		get
		{
			return DirectMessage(2654) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2655, wParam);
		}
	}

	[DefaultValue(Layer.Base)]
	[Category("Caret")]
	[Description("The layer where the line caret will be painted.")]
	public Layer CaretLineLayer
	{
		get
		{
			return (Layer)((IntPtr)DirectMessage(2764)).ToInt32();
		}
		set
		{
			DirectMessage(2765, new IntPtr((int)value));
		}
	}

	[DefaultValue(530)]
	[Category("Caret")]
	[Description("The caret blink rate in milliseconds.")]
	public int CaretPeriod
	{
		get
		{
			return ((IntPtr)DirectMessage(2075)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2076, new IntPtr(value));
		}
	}

	[DefaultValue(CaretStyle.Line)]
	[Category("Caret")]
	[Description("The caret display style.")]
	public CaretStyle CaretStyle
	{
		get
		{
			return (CaretStyle)((IntPtr)DirectMessage(2513)).ToInt32();
		}
		set
		{
			DirectMessage(2512, new IntPtr((int)value));
		}
	}

	[DefaultValue(1)]
	[Category("Caret")]
	[Description("The width of the caret line measured in pixels (between 0 and 3).")]
	public int CaretWidth
	{
		get
		{
			return ((IntPtr)DirectMessage(2189)).ToInt32();
		}
		set
		{
			value = Helpers.Clamp(value, 0, 3);
			DirectMessage(2188, new IntPtr(value));
		}
	}

	[DefaultValue(ChangeHistory.Disabled)]
	[Category("Change History")]
	[Description("Controls whether Scintilla should keep track of document change history and in which ways it should display the difference.")]
	[Editor(typeof(FlagsEditor), typeof(UITypeEditor))]
	[TypeConverter(typeof(FlagsConverter))]
	public ChangeHistory ChangeHistory
	{
		get
		{
			return (ChangeHistory)((IntPtr)DirectMessage(2781)).ToInt32();
		}
		set
		{
			DirectMessage(2780, new IntPtr((int)value));
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			if (moduleHandle == IntPtr.Zero)
			{
				moduleHandle = NativeMethods.LoadLibrary(modulePathScintilla);
				lexillaHandle = NativeMethods.LoadLibrary(modulePathLexilla);
				if (moduleHandle == IntPtr.Zero)
				{
					throw new Win32Exception(string.Format(CultureInfo.InvariantCulture, "Could not load the Scintilla module at the path '{0}'.", modulePathScintilla), new Win32Exception());
				}
				_ = IntPtr.Size;
				string lpProcName = "Scintilla_DirectFunction";
				nint procAddress = NativeMethods.GetProcAddress(new HandleRef(this, moduleHandle), lpProcName);
				if (procAddress == IntPtr.Zero)
				{
					throw new Win32Exception("The Scintilla module has no export for the 'Scintilla_DirectFunction' procedure.", new Win32Exception());
				}
				lexilla = new Lexilla(lexillaHandle);
				directFunction = (NativeMethods.Scintilla_DirectFunction)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(NativeMethods.Scintilla_DirectFunction));
			}
			CreateParams createParams = base.CreateParams;
			createParams.ClassName = "Scintilla";
			createParams.ExStyle &= -513;
			createParams.Style &= -8388609;
			switch (borderStyle)
			{
			case BorderStyle.Fixed3D:
			case BorderStyle.Fixed3DVisualStyles:
				createParams.ExStyle |= 512;
				break;
			case BorderStyle.FixedSingle:
				createParams.Style |= 8388608;
				break;
			}
			return createParams;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int CurrentLine
	{
		get
		{
			int value = ((IntPtr)DirectMessage(2008)).ToInt32();
			return ((IntPtr)DirectMessage(2166, new IntPtr(value))).ToInt32();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int CurrentPosition
	{
		get
		{
			int pos = ((IntPtr)DirectMessage(2008)).ToInt32();
			return Lines.ByteToCharPosition(pos);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			int value2 = Lines.CharToBytePosition(value);
			DirectMessage(2141, new IntPtr(value2));
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Cursor Cursor
	{
		get
		{
			return base.Cursor;
		}
		set
		{
			base.Cursor = value;
		}
	}

	protected override Cursor DefaultCursor => Cursors.IBeam;

	protected override Size DefaultSize => new Size(200, 100);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int DistanceToSecondaryStyles => ((IntPtr)DirectMessage(4025)).ToInt32();

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Document Document
	{
		get
		{
			nint value = DirectMessage(2357);
			return new Document
			{
				Value = value
			};
		}
		set
		{
			Eol eolMode = EolMode;
			bool useTabs = UseTabs;
			int tabWidth = TabWidth;
			int indentWidth = IndentWidth;
			nint value2 = value.Value;
			DirectMessage(2358, IntPtr.Zero, value2);
			InitDocument(eolMode, useTabs, tabWidth, indentWidth);
			Lines.RebuildLineData();
		}
	}

	[DefaultValue(typeof(Color), "Silver")]
	[Category("Long Lines")]
	[Description("The background color to use when indicating long lines.")]
	public Color EdgeColor
	{
		get
		{
			return HelperMethods.FromWin32ColorOpaque(((IntPtr)DirectMessage(2364)).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32ColorOpaque(value);
			DirectMessage(2365, new IntPtr(value2));
		}
	}

	[DefaultValue(0)]
	[Category("Long Lines")]
	[Description("The number of columns at which to display long line indicators.")]
	public int EdgeColumn
	{
		get
		{
			return ((IntPtr)DirectMessage(2360)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2361, new IntPtr(value));
		}
	}

	[DefaultValue(EdgeMode.None)]
	[Category("Long Lines")]
	[Description("Determines how long lines are indicated.")]
	public EdgeMode EdgeMode
	{
		get
		{
			return (EdgeMode)DirectMessage(2362);
		}
		set
		{
			DirectMessage(2363, new IntPtr((int)value));
		}
	}

	internal Encoding Encoding
	{
		get
		{
			int num = (int)DirectMessage(2137);
			if (num != 0)
			{
				return Encoding.GetEncoding(num);
			}
			return Encoding.Default;
		}
	}

	[DefaultValue(true)]
	[Category("Scrolling")]
	[Description("Determines whether the maximum vertical scroll position ends at the last line or can scroll past.")]
	public bool EndAtLastLine
	{
		get
		{
			return DirectMessage(2278) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2277, wParam);
		}
	}

	[DefaultValue(Eol.CrLf)]
	[Category("Line Endings")]
	[Description("Determines the characters added into the document when the user presses the Enter key.")]
	public Eol EolMode
	{
		get
		{
			return (Eol)DirectMessage(2030);
		}
		set
		{
			DirectMessage(2031, new IntPtr((int)value));
		}
	}

	[DefaultValue(0)]
	[Category("Whitespace")]
	[Description("Extra whitespace added to the ascent (top) of each line.")]
	public int ExtraAscent
	{
		get
		{
			return ((IntPtr)DirectMessage(2526)).ToInt32();
		}
		set
		{
			DirectMessage(2525, new IntPtr(value));
		}
	}

	[DefaultValue(0)]
	[Category("Whitespace")]
	[Description("Extra whitespace added to the descent (bottom) of each line.")]
	public int ExtraDescent
	{
		get
		{
			return ((IntPtr)DirectMessage(2528)).ToInt32();
		}
		set
		{
			DirectMessage(2527, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int FirstVisibleLine
	{
		get
		{
			return ((IntPtr)DirectMessage(2152)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2613, new IntPtr(value));
		}
	}

	[Category("Appearance")]
	[Description("The font of the text displayed by the control.")]
	public override Font Font
	{
		get
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			if (!base.IsHandleCreated)
			{
				return base.Font;
			}
			Style style = Styles[32];
			FontStyle val = (FontStyle)(style.Bold ? 1 : 0);
			if (style.Italic)
			{
				val = (FontStyle)(val | 2);
			}
			if (style.Underline)
			{
				val = (FontStyle)(val | 4);
			}
			return new Font(style.Font, style.SizeF, val);
		}
		set
		{
			Style style = Styles[32];
			if (value == null)
			{
				value = base.Parent?.Font ?? Control.DefaultFont;
			}
			style.Font = value.Name;
			style.SizeF = value.Size;
			style.Bold = value.Bold;
			style.Italic = value.Italic;
			style.Underline = value.Underline;
			base.Font = value;
		}
	}

	[DefaultValue(FontQuality.Default)]
	[Category("Misc")]
	[Description("Specifies the anti-aliasing method to use when rendering fonts.")]
	public FontQuality FontQuality
	{
		get
		{
			return (FontQuality)DirectMessage(2612);
		}
		set
		{
			DirectMessage(2611, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int HighlightGuide
	{
		get
		{
			return ((IntPtr)DirectMessage(2135)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2134, new IntPtr(value));
		}
	}

	[DefaultValue(true)]
	[Category("Scrolling")]
	[Description("Determines whether to show the horizontal scroll bar if needed.")]
	public bool HScrollBar
	{
		get
		{
			return DirectMessage(2131) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2130, wParam);
		}
	}

	[DefaultValue(IdleStyling.None)]
	[Category("Misc")]
	[Description("Specifies how to use application idle time for styling.")]
	public IdleStyling IdleStyling
	{
		get
		{
			return (IdleStyling)DirectMessage(2693);
		}
		set
		{
			DirectMessage(2692, new IntPtr((int)value));
		}
	}

	[DefaultValue(0)]
	[Category("Indentation")]
	[Description("The indentation size in characters or 0 to make it the same as the tab width.")]
	public int IndentWidth
	{
		get
		{
			return ((IntPtr)DirectMessage(2123)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2122, new IntPtr(value));
		}
	}

	[DefaultValue(IndentView.None)]
	[Category("Indentation")]
	[Description("Indicates whether indentation guides are displayed.")]
	public IndentView IndentationGuides
	{
		get
		{
			return (IndentView)DirectMessage(2133);
		}
		set
		{
			DirectMessage(2132, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int IndicatorCurrent
	{
		get
		{
			return ((IntPtr)DirectMessage(2501)).ToInt32();
		}
		set
		{
			value = Helpers.Clamp(value, 0, Indicators.Count - 1);
			DirectMessage(2500, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IndicatorCollection Indicators { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int IndicatorValue
	{
		get
		{
			return ((IntPtr)DirectMessage(2503)).ToInt32();
		}
		set
		{
			DirectMessage(2502, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool InternalFocusFlag
	{
		get
		{
			return DirectMessage(2381) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2380, wParam);
		}
	}

	[Category("Lexing")]
	public string LexerName
	{
		get
		{
			return lexerName;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value) && value != string.Empty)
			{
				lexerName = value;
				return;
			}
			if (!SetLexerByName(value))
			{
				throw new InvalidOperationException("Lexer with the name of '" + value + "' was not found.");
			}
			lexerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public unsafe string LexerLanguage
	{
		get
		{
			int num = ((IntPtr)DirectMessage(4012)).ToInt32();
			if (num == 0)
			{
				return string.Empty;
			}
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(4012, IntPtr.Zero, new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
			}
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				DirectMessage(4006, IntPtr.Zero, IntPtr.Zero);
				return;
			}
			fixed (byte* bytes = Helpers.GetBytes(value, Encoding.ASCII, zeroTerminated: true))
			{
				DirectMessage(4006, IntPtr.Zero, new IntPtr(bytes));
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LineEndType LineEndTypesActive => (LineEndType)DirectMessage(2658);

	[DefaultValue(LineEndType.Default)]
	[Category("Line Endings")]
	[Description("Line endings types interpreted by the control.")]
	[Editor(typeof(FlagsEditor), typeof(UITypeEditor))]
	[TypeConverter(typeof(FlagsConverter))]
	public LineEndType LineEndTypesAllowed
	{
		get
		{
			return (LineEndType)DirectMessage(2657);
		}
		set
		{
			DirectMessage(2656, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LineEndType LineEndTypesSupported => (LineEndType)DirectMessage(4018);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LineCollection Lines { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int LinesOnScreen => ((IntPtr)DirectMessage(2370)).ToInt32();

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int MainSelection
	{
		get
		{
			return ((IntPtr)DirectMessage(2575)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2574, new IntPtr(value));
		}
	}

	[Category("Collections")]
	[Description("The margins collection.")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MarginCollection Margins { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MarkerCollection Markers { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Modified => DirectMessage(2159) != IntPtr.Zero;

	[DefaultValue(10000000)]
	[Category("Behavior")]
	[Description("The time in milliseconds the mouse must linger to generate a dwell start event. A value of 10000000 disables dwell events.")]
	public int MouseDwellTime
	{
		get
		{
			return ((IntPtr)DirectMessage(2265)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2264, new IntPtr(value));
		}
	}

	[DefaultValue(false)]
	[Category("Multiple Selection")]
	[Description("Enable or disable the ability to switch to rectangular selection mode while making a selection with the mouse.")]
	public bool MouseSelectionRectangularSwitch
	{
		get
		{
			return DirectMessage(2669) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2668, wParam);
		}
	}

	[DefaultValue(false)]
	[Category("Multiple Selection")]
	[Description("Enable or disable multiple selection with the CTRL key.")]
	public bool MultipleSelection
	{
		get
		{
			return DirectMessage(2564) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2563, wParam);
		}
	}

	[DefaultValue(MultiPaste.Once)]
	[Category("Multiple Selection")]
	[Description("Determines how pasted text is applied to multiple selections.")]
	public MultiPaste MultiPaste
	{
		get
		{
			return (MultiPaste)DirectMessage(2615);
		}
		set
		{
			DirectMessage(2614, new IntPtr((int)value));
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	[Description("Puts the caret into overtype mode.")]
	public bool Overtype
	{
		get
		{
			return DirectMessage(2187) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2186, wParam);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[DefaultValue(true)]
	[Category("Line Endings")]
	[Description("Whether line endings in pasted text are converted to match the document end-of-line mode.")]
	public bool PasteConvertEndings
	{
		get
		{
			return DirectMessage(2468) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2467, wParam);
		}
	}

	[DefaultValue(Phases.Two)]
	[Category("Misc")]
	[Description("Adjusts the number of phases used when drawing.")]
	public Phases PhasesDraw
	{
		get
		{
			return (Phases)DirectMessage(2673);
		}
		set
		{
			DirectMessage(2674, new IntPtr((int)value));
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	[Description("Controls whether the document text can be modified.")]
	public bool ReadOnly
	{
		get
		{
			return DirectMessage(2140) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2171, wParam);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int RectangularSelectionAnchor
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2591)).ToInt32();
			if (num <= 0)
			{
				return num;
			}
			return Lines.ByteToCharPosition(num);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			value = Lines.CharToBytePosition(value);
			DirectMessage(2590, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int RectangularSelectionAnchorVirtualSpace
	{
		get
		{
			return ((IntPtr)DirectMessage(2595)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2594, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int RectangularSelectionCaret
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2589)).ToInt32();
			if (num <= 0)
			{
				return 0;
			}
			return Lines.ByteToCharPosition(num);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			value = Lines.CharToBytePosition(value);
			DirectMessage(2588, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int RectangularSelectionCaretVirtualSpace
	{
		get
		{
			return ((IntPtr)DirectMessage(2593)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2592, new IntPtr(value));
		}
	}

	private nint SciPointer
	{
		get
		{
			if (Control.CheckForIllegalCrossThreadCalls && base.InvokeRequired)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Control '{0}' accessed from a thread other than the thread it was created on.", base.Name));
			}
			if (sciPtr == IntPtr.Zero)
			{
				sciPtr = NativeMethods.SendMessage(new HandleRef(this, base.Handle), 2185, IntPtr.Zero, IntPtr.Zero);
			}
			return sciPtr;
		}
	}

	[DefaultValue(1)]
	[Category("Scrolling")]
	[Description("The range in pixels of the horizontal scroll bar.")]
	public int ScrollWidth
	{
		get
		{
			return ((IntPtr)DirectMessage(2275)).ToInt32();
		}
		set
		{
			DirectMessage(2274, new IntPtr(value));
		}
	}

	[DefaultValue(true)]
	[Category("Scrolling")]
	[Description("Determines whether to increase the horizontal scroll width as needed.")]
	public bool ScrollWidthTracking
	{
		get
		{
			return DirectMessage(2517) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2516, wParam);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SearchFlags SearchFlags
	{
		get
		{
			return (SearchFlags)((IntPtr)DirectMessage(2199)).ToInt32();
		}
		set
		{
			DirectMessage(2198, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public unsafe string SelectedText
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2161)).ToInt32();
			if (num <= 0)
			{
				return string.Empty;
			}
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(2161, IntPtr.Zero, new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionEnd
	{
		get
		{
			int pos = ((IntPtr)DirectMessage(2145)).ToInt32();
			return Lines.ByteToCharPosition(pos);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			value = Lines.CharToBytePosition(value);
			DirectMessage(2144, new IntPtr(value));
		}
	}

	[DefaultValue(false)]
	[Category("Selection")]
	[Description("Determines whether a selection should fill past the end of the line.")]
	public bool SelectionEolFilled
	{
		get
		{
			return DirectMessage(2479) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2480, wParam);
		}
	}

	[Description("The color of visible white space.")]
	[Category("Whitespace")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color WhitespaceTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(60))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(60), new IntPtr(value2));
		}
	}

	[Description("The background color of visible white space.")]
	[Category("Whitespace")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color WhitespaceBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(61))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(61), new IntPtr(value2));
		}
	}

	[Description("The text color of active hot spot.")]
	[Category("Hotspot")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color ActiveHotspotTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(70))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(70), new IntPtr(value2));
		}
	}

	[Description("The background color of active hot spot.")]
	[Category("Hotspot")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color ActiveHotspotBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(71))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(71), new IntPtr(value2));
		}
	}

	[Description("The text color of main selection.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color SelectionTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(10))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(10), new IntPtr(value2));
		}
	}

	[Description("The background color of main selection.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Silver")]
	public Color SelectionBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(11))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(11), new IntPtr(value2));
		}
	}

	[Description("The text color of additional selections.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color SelectionAdditionalTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(12))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(12), new IntPtr(value2));
		}
	}

	[Description("The background color of additional selections.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "215, 215, 215")]
	public Color SelectionAdditionalBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(13))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(13), new IntPtr(value2));
		}
	}

	[Description("The text colour of selections when another window contains the primary selection.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color SelectionSecondaryTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(14))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(14), new IntPtr(value2));
		}
	}

	[Description("The background color of selections when another window contains the primary selection.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "176, 176, 176")]
	public Color SelectionSecondaryBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(15))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(15), new IntPtr(value2));
		}
	}

	[Description("The text colour of selections when the control has no focus.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color SelectionInactiveTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(16))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(16), new IntPtr(value2));
		}
	}

	[Description("The selection highlight color to use when the control has no focus.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "63, 128, 128, 128")]
	public Color SelectionInactiveBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(17))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(17), new IntPtr(value2));
		}
	}

	[Description("The selected text color to use when the control has no focus.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color SelectionInactiveAdditionalTextColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(18))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(18), new IntPtr(value2));
		}
	}

	[Description("The selection highlight color to use when the control has no focus.")]
	[Category("Selection")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color SelectionInactiveAdditionalBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(19))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(19), new IntPtr(value2));
		}
	}

	[Description("The color of fold lines.")]
	[Category("Folding")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color FoldLineBackColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(80))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(80), new IntPtr(value2));
		}
	}

	[Description("The color of line drawn to show there are lines hidden at that point.")]
	[Category("Folding")]
	[DefaultValue(typeof(Color), "Transparent")]
	public Color FoldLineStripColor
	{
		get
		{
			return HelperMethods.FromWin32Color(((IntPtr)DirectMessage(2754, new IntPtr(81))).ToInt32());
		}
		set
		{
			int value2 = HelperMethods.ToWin32Color(value);
			DirectMessage(2753, new IntPtr(81), new IntPtr(value2));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SelectionCollection Selections { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			int pos = ((IntPtr)DirectMessage(2143)).ToInt32();
			return Lines.ByteToCharPosition(pos);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			value = Lines.CharToBytePosition(value);
			DirectMessage(2142, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Status Status
	{
		get
		{
			return (Status)DirectMessage(2383);
		}
		set
		{
			DirectMessage(2382, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public StyleCollection Styles { get; private set; }

	[DefaultValue(TabDrawMode.LongArrow)]
	[Category("Whitespace")]
	[Description("Style of visible tab characters.")]
	public TabDrawMode TabDrawMode
	{
		get
		{
			return (TabDrawMode)DirectMessage(2698);
		}
		set
		{
			DirectMessage(2699, new IntPtr((int)value));
		}
	}

	[DefaultValue(true)]
	[Category("Indentation")]
	[Description("Determines whether tab inserts a tab character, or indents.")]
	public bool TabIndents
	{
		get
		{
			return DirectMessage(2261) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2260, wParam);
		}
	}

	[DefaultValue(4)]
	[Category("Indentation")]
	[Description("The tab size in characters.")]
	public int TabWidth
	{
		get
		{
			return ((IntPtr)DirectMessage(2121)).ToInt32();
		}
		set
		{
			DirectMessage(2036, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TargetEnd
	{
		get
		{
			int pos = Helpers.Clamp(((IntPtr)DirectMessage(2193)).ToInt32(), 0, ((IntPtr)DirectMessage(2183)).ToInt32());
			return Lines.ByteToCharPosition(pos);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			value = Lines.CharToBytePosition(value);
			DirectMessage(2192, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TargetStart
	{
		get
		{
			int pos = Helpers.Clamp(((IntPtr)DirectMessage(2191)).ToInt32(), 0, ((IntPtr)DirectMessage(2183)).ToInt32());
			return Lines.ByteToCharPosition(pos);
		}
		set
		{
			value = Helpers.Clamp(value, 0, TextLength);
			value = Lines.CharToBytePosition(value);
			DirectMessage(2190, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public unsafe string TargetText
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2687)).ToInt32();
			if (num == 0)
			{
				return string.Empty;
			}
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(2687, IntPtr.Zero, new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding);
			}
		}
	}

	[DefaultValue(Technology.Default)]
	[Category("Misc")]
	[Description("The rendering technology used to draw text.")]
	public Technology Technology
	{
		get
		{
			return (Technology)DirectMessage(2631);
		}
		set
		{
			DirectMessage(2630, new IntPtr((int)value));
		}
	}

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", typeof(UITypeEditor))]
	[Description("The text associated with this control.")]
	[Category("Appearance")]
	public unsafe override string Text
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2183)).ToInt32();
			nint num2 = DirectMessage(2643, new IntPtr(0), new IntPtr(num));
			if (num2 == IntPtr.Zero)
			{
				return string.Empty;
			}
			return new string((sbyte*)num2, 0, num, Encoding);
		}
		set
		{
			int num;
			if (base.DesignMode)
			{
				num = (ReadOnly ? 1 : 0);
				if (num != 0 && base.DesignMode)
				{
					DirectMessage(2171, IntPtr.Zero);
				}
			}
			else
			{
				num = 0;
			}
			if (string.IsNullOrEmpty(value))
			{
				DirectMessage(2004);
			}
			else if (value.Contains("\0"))
			{
				DirectMessage(2004);
				AppendText(value);
			}
			else
			{
				fixed (byte* bytes = Helpers.GetBytes(value, Encoding, zeroTerminated: true))
				{
					DirectMessage(2181, IntPtr.Zero, new IntPtr(bytes));
				}
			}
			if (num != 0 && base.DesignMode)
			{
				DirectMessage(2171, new IntPtr(1));
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TextLength => Lines.TextLength;

	[DefaultValue(false)]
	[Category("Indentation")]
	[Description("Determines whether indentation allows tab characters or purely space characters.")]
	public bool UseTabs
	{
		get
		{
			return DirectMessage(2125) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2124, wParam);
		}
	}

	public new bool UseWaitCursor
	{
		get
		{
			return base.UseWaitCursor;
		}
		set
		{
			base.UseWaitCursor = value;
			int value2 = (value ? 4 : (-1));
			DirectMessage(2386, new IntPtr(value2));
		}
	}

	[DefaultValue(false)]
	[Category("Line Endings")]
	[Description("Display end-of-line characters.")]
	public bool ViewEol
	{
		get
		{
			return DirectMessage(2355) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2356, wParam);
		}
	}

	[DefaultValue(WhitespaceMode.Invisible)]
	[Category("Whitespace")]
	[Description("Options for displaying whitespace characters.")]
	public WhitespaceMode ViewWhitespace
	{
		get
		{
			return (WhitespaceMode)DirectMessage(2020);
		}
		set
		{
			DirectMessage(2021, new IntPtr((int)value));
		}
	}

	[DefaultValue(VirtualSpace.None)]
	[Category("Behavior")]
	[Description("Options for allowing the caret to move beyond the end of each line.")]
	[Editor(typeof(FlagsEditor), typeof(UITypeEditor))]
	[TypeConverter(typeof(FlagsConverter))]
	public VirtualSpace VirtualSpaceOptions
	{
		get
		{
			return (VirtualSpace)DirectMessage(2597);
		}
		set
		{
			DirectMessage(2596, new IntPtr((int)value));
		}
	}

	[DefaultValue(true)]
	[Category("Scrolling")]
	[Description("Determines whether to show the vertical scroll bar when needed.")]
	public bool VScrollBar
	{
		get
		{
			return DirectMessage(2281) != IntPtr.Zero;
		}
		set
		{
			nint wParam = (value ? new IntPtr(1) : IntPtr.Zero);
			DirectMessage(2280, wParam);
		}
	}

	private int VisibleLineCount
	{
		get
		{
			bool flag = WrapMode == WrapMode.None;
			bool allLinesVisible = Lines.AllLinesVisible;
			if (flag && allLinesVisible)
			{
				return Lines.Count;
			}
			int num = 0;
			for (int i = 0; i < Lines.Count; i++)
			{
				if (allLinesVisible || Lines[i].Visible)
				{
					num += (flag ? 1 : Lines[i].WrapCount);
				}
			}
			return num;
		}
	}

	[Browsable(false)]
	[Category("Whitespace")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public unsafe string WhitespaceChars
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2647, IntPtr.Zero, IntPtr.Zero)).ToInt32();
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(2647, IntPtr.Zero, new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
			}
		}
		set
		{
			if (value == null)
			{
				DirectMessage(2443, IntPtr.Zero, IntPtr.Zero);
				return;
			}
			fixed (byte* bytes = Helpers.GetBytes(value, Encoding.ASCII, zeroTerminated: true))
			{
				DirectMessage(2443, IntPtr.Zero, new IntPtr(bytes));
			}
		}
	}

	[DefaultValue(1)]
	[Category("Whitespace")]
	[Description("The size of whitespace dots.")]
	public int WhitespaceSize
	{
		get
		{
			return ((IntPtr)DirectMessage(2087)).ToInt32();
		}
		set
		{
			DirectMessage(2086, new IntPtr(value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public unsafe string WordChars
	{
		get
		{
			int num = ((IntPtr)DirectMessage(2646, IntPtr.Zero, IntPtr.Zero)).ToInt32();
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(2646, IntPtr.Zero, new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
			}
		}
		set
		{
			if (value == null)
			{
				DirectMessage(2077, IntPtr.Zero, IntPtr.Zero);
				return;
			}
			fixed (byte* bytes = Helpers.GetBytes(value, Encoding.ASCII, zeroTerminated: true))
			{
				DirectMessage(2077, IntPtr.Zero, new IntPtr(bytes));
			}
		}
	}

	[DefaultValue(WrapIndentMode.Fixed)]
	[Category("Line Wrapping")]
	[Description("Determines how wrapped sublines are indented.")]
	public WrapIndentMode WrapIndentMode
	{
		get
		{
			return (WrapIndentMode)DirectMessage(2473);
		}
		set
		{
			DirectMessage(2472, new IntPtr((int)value));
		}
	}

	[DefaultValue(WrapMode.None)]
	[Category("Line Wrapping")]
	[Description("The line wrapping strategy.")]
	public WrapMode WrapMode
	{
		get
		{
			return (WrapMode)DirectMessage(2269);
		}
		set
		{
			DirectMessage(2268, new IntPtr((int)value));
		}
	}

	[DefaultValue(0)]
	[Category("Line Wrapping")]
	[Description("The amount of pixels to indent wrapped sublines.")]
	public int WrapStartIndent
	{
		get
		{
			return ((IntPtr)DirectMessage(2465)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2464, new IntPtr(value));
		}
	}

	[DefaultValue(WrapVisualFlags.None)]
	[Category("Line Wrapping")]
	[Description("The visual indicator displayed on a wrapped line.")]
	[Editor(typeof(FlagsEditor), typeof(UITypeEditor))]
	[TypeConverter(typeof(FlagsConverter))]
	public WrapVisualFlags WrapVisualFlags
	{
		get
		{
			return (WrapVisualFlags)DirectMessage(2461);
		}
		set
		{
			DirectMessage(2460, new IntPtr((int)value));
		}
	}

	[DefaultValue(WrapVisualFlagLocation.Default)]
	[Category("Line Wrapping")]
	[Description("The location of wrap visual flags in relation to the line text.")]
	public WrapVisualFlagLocation WrapVisualFlagLocation
	{
		get
		{
			return (WrapVisualFlagLocation)DirectMessage(2463);
		}
		set
		{
			DirectMessage(2462, new IntPtr((int)value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int XOffset
	{
		get
		{
			return ((IntPtr)DirectMessage(2398)).ToInt32();
		}
		set
		{
			value = Helpers.ClampMin(value, 0);
			DirectMessage(2397, new IntPtr(value));
		}
	}

	[DefaultValue(0)]
	[Category("Appearance")]
	[Description("Zoom factor in points applied to the displayed text.")]
	public int Zoom
	{
		get
		{
			return ((IntPtr)DirectMessage(2374)).ToInt32();
		}
		set
		{
			DirectMessage(2373, new IntPtr(value));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Not used by the Scintilla.NET control.")]
	public new RightToLeft RightToLeft { get; set; }

	[Category("Notifications")]
	[Description("Occurs when an autocompletion list is cancelled.")]
	public event EventHandler<EventArgs> AutoCCancelled
	{
		add
		{
			base.Events.AddHandler(autoCCancelledEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(autoCCancelledEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user deletes a character while an autocompletion list is active.")]
	public event EventHandler<EventArgs> AutoCCharDeleted
	{
		add
		{
			base.Events.AddHandler(autoCCharDeletedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(autoCCharDeletedEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs after autocompleted text has been inserted.")]
	public event EventHandler<AutoCSelectionEventArgs> AutoCCompleted
	{
		add
		{
			base.Events.AddHandler(autoCCompletedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(autoCCompletedEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when a user has selected an item in an autocompletion list.")]
	public event EventHandler<AutoCSelectionEventArgs> AutoCSelection
	{
		add
		{
			base.Events.AddHandler(autoCSelectionEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(autoCSelectionEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when a user has highlighted an item in an autocompletion list.")]
	public event EventHandler<AutoCSelectionChangeEventArgs> AutoCSelectionChange
	{
		add
		{
			base.Events.AddHandler(autoCSelectionChangeEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(autoCSelectionChangeEventKey, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackColorChanged
	{
		add
		{
			base.BackColorChanged += value;
		}
		remove
		{
			base.BackColorChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageChanged
	{
		add
		{
			base.BackgroundImageChanged += value;
		}
		remove
		{
			base.BackgroundImageChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged
	{
		add
		{
			base.BackgroundImageLayoutChanged += value;
		}
		remove
		{
			base.BackgroundImageLayoutChanged -= value;
		}
	}

	[Category("Notifications")]
	[Description("Occurs before text is deleted.")]
	public event EventHandler<BeforeModificationEventArgs> BeforeDelete
	{
		add
		{
			base.Events.AddHandler(beforeDeleteEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(beforeDeleteEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs before text is inserted.")]
	public event EventHandler<BeforeModificationEventArgs> BeforeInsert
	{
		add
		{
			base.Events.AddHandler(beforeInsertEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(beforeInsertEventKey, value);
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of the BorderStyle property changes.")]
	public event EventHandler BorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(borderStyleChangedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(borderStyleChangedEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when an annotation has changed.")]
	public event EventHandler<ChangeAnnotationEventArgs> ChangeAnnotation
	{
		add
		{
			base.Events.AddHandler(changeAnnotationEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(changeAnnotationEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user types a character.")]
	public event EventHandler<CharAddedEventArgs> CharAdded
	{
		add
		{
			base.Events.AddHandler(charAddedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(charAddedEventKey, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler CursorChanged
	{
		add
		{
			base.CursorChanged += value;
		}
		remove
		{
			base.CursorChanged -= value;
		}
	}

	[Category("Notifications")]
	[Description("Occurs when text is deleted.")]
	public event EventHandler<ModificationEventArgs> Delete
	{
		add
		{
			base.Events.AddHandler(deleteEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(deleteEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the editor is double clicked.")]
	public new event EventHandler<DoubleClickEventArgs> DoubleClick
	{
		add
		{
			base.Events.AddHandler(doubleClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(doubleClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the mouse moves from its dwell start position.")]
	public event EventHandler<DwellEventArgs> DwellEnd
	{
		add
		{
			base.Events.AddHandler(dwellEndEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(dwellEndEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the mouse is clicked over a calltip.")]
	public event EventHandler<CallTipClickEventArgs> CallTipClick
	{
		add
		{
			base.Events.AddHandler(callTipClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(callTipClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the mouse is kept in one position (hovers) for a period of time.")]
	public event EventHandler<DwellEventArgs> DwellStart
	{
		add
		{
			base.Events.AddHandler(dwellStartEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(dwellStartEventKey, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler FontChanged
	{
		add
		{
			base.FontChanged += value;
		}
		remove
		{
			base.FontChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler ForeColorChanged
	{
		add
		{
			base.ForeColorChanged += value;
		}
		remove
		{
			base.ForeColorChanged -= value;
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user clicks text styled with the hotspot flag.")]
	public event EventHandler<HotspotClickEventArgs> HotspotClick
	{
		add
		{
			base.Events.AddHandler(hotspotClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(hotspotClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user double clicks text styled with the hotspot flag.")]
	public event EventHandler<HotspotClickEventArgs> HotspotDoubleClick
	{
		add
		{
			base.Events.AddHandler(hotspotDoubleClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(hotspotDoubleClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user releases a click on text styled with the hotspot flag.")]
	public event EventHandler<HotspotClickEventArgs> HotspotReleaseClick
	{
		add
		{
			base.Events.AddHandler(hotspotReleaseClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(hotspotReleaseClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user clicks text with an indicator.")]
	public event EventHandler<IndicatorClickEventArgs> IndicatorClick
	{
		add
		{
			base.Events.AddHandler(indicatorClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(indicatorClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the user releases a click on text with an indicator.")]
	public event EventHandler<IndicatorReleaseEventArgs> IndicatorRelease
	{
		add
		{
			base.Events.AddHandler(indicatorReleaseEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(indicatorReleaseEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when text is inserted.")]
	public event EventHandler<ModificationEventArgs> Insert
	{
		add
		{
			base.Events.AddHandler(insertEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(insertEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs before text is inserted. Permits changing the inserted text.")]
	public event EventHandler<InsertCheckEventArgs> InsertCheck
	{
		add
		{
			base.Events.AddHandler(insertCheckEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(insertCheckEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the mouse is clicked in a sensitive margin.")]
	public event EventHandler<MarginClickEventArgs> MarginClick
	{
		add
		{
			base.Events.AddHandler(marginClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(marginClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the mouse is right-clicked in a sensitive margin.")]
	public event EventHandler<MarginClickEventArgs> MarginRightClick
	{
		add
		{
			base.Events.AddHandler(marginRightClickEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(marginRightClickEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when an attempt is made to change text in read-only mode.")]
	public event EventHandler<EventArgs> ModifyAttempt
	{
		add
		{
			base.Events.AddHandler(modifyAttemptEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(modifyAttemptEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when hidden (folded) text should be shown.")]
	public event EventHandler<NeedShownEventArgs> NeedShown
	{
		add
		{
			base.Events.AddHandler(needShownEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(needShownEventKey, value);
		}
	}

	internal event EventHandler<SCNotificationEventArgs> SCNotification
	{
		add
		{
			base.Events.AddHandler(scNotificationEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(scNotificationEventKey, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event PaintEventHandler Paint
	{
		add
		{
			base.Paint += value;
		}
		remove
		{
			base.Paint -= value;
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the control is painted.")]
	public event EventHandler<EventArgs> Painted
	{
		add
		{
			base.Events.AddHandler(paintedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(paintedEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when a save point is left and the document becomes dirty.")]
	public event EventHandler<EventArgs> SavePointLeft
	{
		add
		{
			base.Events.AddHandler(savePointLeftEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(savePointLeftEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when a save point is reached and the document is no longer dirty.")]
	public event EventHandler<EventArgs> SavePointReached
	{
		add
		{
			base.Events.AddHandler(savePointReachedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(savePointReachedEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the text needs styling.")]
	public event EventHandler<StyleNeededEventArgs> StyleNeeded
	{
		add
		{
			base.Events.AddHandler(styleNeededEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(styleNeededEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the control UI is updated.")]
	public event EventHandler<UpdateUIEventArgs> UpdateUI
	{
		add
		{
			base.Events.AddHandler(updateUIEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(updateUIEventKey, value);
		}
	}

	[Category("Notifications")]
	[Description("Occurs when the control is zoomed.")]
	public event EventHandler<EventArgs> ZoomChanged
	{
		add
		{
			base.Events.AddHandler(zoomChangedEventKey, value);
		}
		remove
		{
			base.Events.RemoveHandler(zoomChangedEventKey, value);
		}
	}

	static Scintilla()
	{
		scNotificationEventKey = new object();
		insertCheckEventKey = new object();
		beforeInsertEventKey = new object();
		beforeDeleteEventKey = new object();
		insertEventKey = new object();
		deleteEventKey = new object();
		updateUIEventKey = new object();
		modifyAttemptEventKey = new object();
		styleNeededEventKey = new object();
		savePointReachedEventKey = new object();
		savePointLeftEventKey = new object();
		changeAnnotationEventKey = new object();
		marginClickEventKey = new object();
		marginRightClickEventKey = new object();
		charAddedEventKey = new object();
		autoCSelectionEventKey = new object();
		autoCSelectionChangeEventKey = new object();
		autoCCompletedEventKey = new object();
		autoCCancelledEventKey = new object();
		autoCCharDeletedEventKey = new object();
		dwellStartEventKey = new object();
		callTipClickEventKey = new object();
		dwellEndEventKey = new object();
		borderStyleChangedEventKey = new object();
		doubleClickEventKey = new object();
		paintedEventKey = new object();
		needShownEventKey = new object();
		hotspotClickEventKey = new object();
		hotspotDoubleClickEventKey = new object();
		hotspotReleaseClickEventKey = new object();
		indicatorClickEventKey = new object();
		indicatorReleaseEventKey = new object();
		zoomChangedEventKey = new object();
		List<string> list = new List<string>();
		foreach (string item in EnumerateSatelliteLibrarySearchPaths())
		{
			string path = Path.Combine(item, "Scintilla.dll");
			string path2 = Path.Combine(item, "Lexilla.dll");
			if (File.Exists(path) && File.Exists(path2))
			{
				modulePathScintilla = path;
				modulePathLexilla = path2;
				try
				{
					FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(modulePathScintilla);
					scintillaVersion = versionInfo.ProductVersion ?? versionInfo.FileVersion;
					versionInfo = FileVersionInfo.GetVersionInfo(modulePathLexilla);
					lexillaVersion = versionInfo.ProductVersion ?? versionInfo.FileVersion;
					return;
				}
				catch
				{
					list.Add(item);
				}
			}
			else
			{
				list.Add(item);
			}
		}
		string text = string.Join("\n", list);
		scintillaVersion = "ERROR";
		lexillaVersion = "ERROR";
		throw new InvalidOperationException("Scintilla.NET satellite assemblies not found in any of the following paths:\n" + text);
	}

	private static bool InDesignProcess()
	{
		using Process process = Process.GetCurrentProcess();
		switch (process.ProcessName)
		{
		case "devenv":
		case "DesignToolsServer":
		case "xdesproc":
		case "blend":
			return true;
		default:
			return false;
		}
	}

	public static IEnumerable<string> EnumerateSatelliteLibrarySearchPaths()
	{
		string folder = Path.Combine("runtimes", Environment.Is64BitProcess ? "win-x64" : "win-x86", "native");
		string location = Assembly.GetExecutingAssembly().Location;
		if (string.IsNullOrWhiteSpace(location))
		{
			location = Assembly.GetEntryAssembly().Location;
		}
		string path = Path.GetDirectoryName(location) ?? AppDomain.CurrentDomain.BaseDirectory;
		yield return Path.Combine(path, folder);
		if (InDesignProcess())
		{
			Assembly designtimeAssembly = Assembly.GetAssembly(typeof(Scintilla));
			string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget\\packages\\scintilla5.net");
			Version version = designtimeAssembly.GetName().Version;
			string versionString = ((version.Revision == 0) ? version.ToString(3) : version.ToString());
			yield return Path.Combine(path2, versionString, folder);
			string location2 = designtimeAssembly.Location;
			string name = designtimeAssembly.GetName().Name;
			string fullPath = Path.GetFullPath(Path.Combine(location2, "..\\..\\..\\.."));
			yield return Path.Combine(fullPath, "packages", name + "." + versionString, folder);
		}
	}

	private bool SetLexerByName(string lexerName)
	{
		if (lexerName == string.Empty)
		{
			DirectMessage(4033, IntPtr.Zero, IntPtr.Zero);
			return true;
		}
		nint num = Lexilla.CreateLexer(lexerName);
		if (num == IntPtr.Zero)
		{
			return false;
		}
		DirectMessage(4033, IntPtr.Zero, num);
		return true;
	}

	public void AddRefDocument(Document document)
	{
		nint value = document.Value;
		DirectMessage(2376, IntPtr.Zero, value);
	}

	public void AddSelection(int caret, int anchor)
	{
		int textLength = TextLength;
		caret = Helpers.Clamp(caret, 0, textLength);
		anchor = Helpers.Clamp(anchor, 0, textLength);
		caret = Lines.CharToBytePosition(caret);
		anchor = Lines.CharToBytePosition(anchor);
		DirectMessage(2573, new IntPtr(caret), new IntPtr(anchor));
	}

	public unsafe void AddText(string text)
	{
		byte[] bytes = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: false);
		fixed (byte* value = bytes)
		{
			DirectMessage(2001, new IntPtr(bytes.Length), new IntPtr(value));
		}
	}

	public int AllocateSubstyles(int styleBase, int numberStyles)
	{
		return ((IntPtr)DirectMessage(4020, new IntPtr(styleBase), new IntPtr(numberStyles))).ToInt32();
	}

	public void AnnotationClearAll()
	{
		DirectMessage(2547);
	}

	public unsafe void AppendText(string text)
	{
		byte[] bytes = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: false);
		fixed (byte* value = bytes)
		{
			DirectMessage(2282, new IntPtr(bytes.Length), new IntPtr(value));
		}
	}

	public void AssignCmdKey(Keys keyDefinition, Command sciCommand)
	{
		int value = Helpers.TranslateKeys(keyDefinition);
		DirectMessage(2070, new IntPtr(value), new IntPtr((int)sciCommand));
	}

	public void AutoCCancel()
	{
		DirectMessage(2101);
	}

	public void AutoCComplete()
	{
		DirectMessage(2104);
	}

	public unsafe void AutoCSelect(string select)
	{
		fixed (byte* bytes = Helpers.GetBytes(select, Encoding, zeroTerminated: true))
		{
			DirectMessage(2108, IntPtr.Zero, new IntPtr(bytes));
		}
	}

	public unsafe void AutoCSetFillUps(string chars)
	{
		if (chars == null)
		{
			chars = string.Empty;
		}
		if (fillUpChars != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(fillUpChars);
			fillUpChars = IntPtr.Zero;
		}
		int num = Encoding.GetByteCount(chars) + 1;
		nint num2 = Marshal.AllocHGlobal(num);
		fixed (char* chars2 = chars)
		{
			Encoding.GetBytes(chars2, chars.Length, (byte*)num2, num);
		}
		*(sbyte*)(num2 + (num - 1)) = 0;
		fillUpChars = num2;
		DirectMessage(2112, IntPtr.Zero, fillUpChars);
	}

	public unsafe void AutoCShow(int lenEntered, string list)
	{
		if (string.IsNullOrEmpty(list))
		{
			return;
		}
		lenEntered = Helpers.ClampMin(lenEntered, 0);
		if (lenEntered > 0)
		{
			int num = ((IntPtr)DirectMessage(2008)).ToInt32();
			int num2 = num;
			for (int i = 0; i < lenEntered; i++)
			{
				num2 = ((IntPtr)DirectMessage(2670, new IntPtr(num2), new IntPtr(-1))).ToInt32();
			}
			lenEntered = num - num2;
		}
		fixed (byte* bytes = Helpers.GetBytes(list, Encoding, zeroTerminated: true))
		{
			DirectMessage(2100, new IntPtr(lenEntered), new IntPtr(bytes));
		}
	}

	public unsafe void AutoCStops(string chars)
	{
		fixed (byte* bytes = Helpers.GetBytes(chars ?? string.Empty, Encoding.ASCII, zeroTerminated: true))
		{
			DirectMessage(2105, IntPtr.Zero, new IntPtr(bytes));
		}
	}

	public void BeginUndoAction()
	{
		DirectMessage(2078);
	}

	public void BraceBadLight(int position)
	{
		position = Helpers.Clamp(position, -1, TextLength);
		if (position > 0)
		{
			position = Lines.CharToBytePosition(position);
		}
		DirectMessage(2352, new IntPtr(position));
	}

	public void BraceHighlight(int position1, int position2)
	{
		int textLength = TextLength;
		position1 = Helpers.Clamp(position1, -1, textLength);
		if (position1 > 0)
		{
			position1 = Lines.CharToBytePosition(position1);
		}
		position2 = Helpers.Clamp(position2, -1, textLength);
		if (position2 > 0)
		{
			position2 = Lines.CharToBytePosition(position2);
		}
		DirectMessage(2351, new IntPtr(position1), new IntPtr(position2));
	}

	public int BraceMatch(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		int num = ((IntPtr)DirectMessage(2353, new IntPtr(position), IntPtr.Zero)).ToInt32();
		if (num > 0)
		{
			num = Lines.ByteToCharPosition(num);
		}
		return num;
	}

	public void CallTipCancel()
	{
		DirectMessage(2201);
	}

	public void CallTipSetForeHlt(Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		DirectMessage(2207, new IntPtr(value));
	}

	public unsafe void CallTipSetHlt(int hlStart, int hlEnd)
	{
		hlStart = Helpers.Clamp(hlStart, 0, lastCallTip.Length);
		hlEnd = Helpers.Clamp(hlEnd, 0, lastCallTip.Length);
		fixed (char* ptr = lastCallTip)
		{
			hlEnd = Encoding.GetByteCount(ptr + hlStart, hlEnd - hlStart);
			hlStart = Encoding.GetByteCount(ptr, hlStart);
			hlEnd += hlStart;
		}
		DirectMessage(2204, new IntPtr(hlStart), new IntPtr(hlEnd));
	}

	public void CallTipSetPosition(bool above)
	{
		nint wParam = (above ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2213, wParam);
	}

	public unsafe void CallTipShow(int posStart, string definition)
	{
		posStart = Helpers.Clamp(posStart, 0, TextLength);
		if (definition != null)
		{
			lastCallTip = definition;
			posStart = Lines.CharToBytePosition(posStart);
			fixed (byte* bytes = Helpers.GetBytes(definition, Encoding, zeroTerminated: true))
			{
				DirectMessage(2200, new IntPtr(posStart), new IntPtr(bytes));
			}
		}
	}

	public void CallTipTabSize(int tabSize)
	{
		tabSize = Helpers.ClampMin(tabSize, 0);
		DirectMessage(2212, new IntPtr(tabSize));
	}

	public void ChangeLexerState(int startPos, int endPos)
	{
		int textLength = TextLength;
		startPos = Helpers.Clamp(startPos, 0, textLength);
		endPos = Helpers.Clamp(endPos, 0, textLength);
		startPos = Lines.CharToBytePosition(startPos);
		endPos = Lines.CharToBytePosition(endPos);
		DirectMessage(2617, new IntPtr(startPos), new IntPtr(endPos));
	}

	public int CharPositionFromPoint(int x, int y)
	{
		int pos = ((IntPtr)DirectMessage(2561, new IntPtr(x), new IntPtr(y))).ToInt32();
		return Lines.ByteToCharPosition(pos);
	}

	public int CharPositionFromPointClose(int x, int y)
	{
		int num = ((IntPtr)DirectMessage(2562, new IntPtr(x), new IntPtr(y))).ToInt32();
		if (num >= 0)
		{
			num = Lines.ByteToCharPosition(num);
		}
		return num;
	}

	public void ChooseCaretX()
	{
		DirectMessage(2399);
	}

	public void Clear()
	{
		DirectMessage(2180);
	}

	public void ClearAll()
	{
		DirectMessage(2004);
	}

	public void ClearCmdKey(Keys keyDefinition)
	{
		int value = Helpers.TranslateKeys(keyDefinition);
		DirectMessage(2071, new IntPtr(value));
	}

	public void ClearAllCmdKeys()
	{
		DirectMessage(2072);
	}

	public void ClearDocumentStyle()
	{
		DirectMessage(2005);
	}

	public void ClearRegisteredImages()
	{
		DirectMessage(2408);
	}

	public void ClearSelections()
	{
		DirectMessage(2571);
	}

	public void Colorize(int startPos, int endPos)
	{
		int textLength = TextLength;
		startPos = Helpers.Clamp(startPos, 0, textLength);
		endPos = Helpers.Clamp(endPos, 0, textLength);
		startPos = Lines.CharToBytePosition(startPos);
		endPos = Lines.CharToBytePosition(endPos);
		DirectMessage(4003, new IntPtr(startPos), new IntPtr(endPos));
	}

	public void ConvertEols(Eol eolMode)
	{
		DirectMessage(2029, new IntPtr((int)eolMode));
	}

	public void Copy()
	{
		DirectMessage(2178);
	}

	public void Copy(CopyFormat format)
	{
		Helpers.Copy(this, format, useSelection: true, allowLine: false, 0, 0);
	}

	public void CopyAllowLine()
	{
		DirectMessage(2519);
	}

	public void CopyAllowLine(CopyFormat format)
	{
		Helpers.Copy(this, format, useSelection: true, allowLine: true, 0, 0);
	}

	public void CopyRange(int start, int end)
	{
		int textLength = TextLength;
		start = Helpers.Clamp(start, 0, textLength);
		end = Helpers.Clamp(end, 0, textLength);
		start = Lines.CharToBytePosition(start);
		end = Lines.CharToBytePosition(end);
		DirectMessage(2419, new IntPtr(start), new IntPtr(end));
	}

	public void CopyRange(int start, int end, CopyFormat format)
	{
		int textLength = TextLength;
		start = Helpers.Clamp(start, 0, textLength);
		end = Helpers.Clamp(end, 0, textLength);
		if (start != end)
		{
			start = Lines.CharToBytePosition(start);
			end = Lines.CharToBytePosition(end);
			Helpers.Copy(this, format, useSelection: false, allowLine: false, start, end);
		}
	}

	public Document CreateDocument()
	{
		nint value = DirectMessage(2375);
		return new Document
		{
			Value = value
		};
	}

	public ILoader CreateLoader(int length)
	{
		length = Helpers.ClampMin(length, 0);
		nint num = DirectMessage(2632, new IntPtr(length));
		if (num == IntPtr.Zero)
		{
			return null;
		}
		return new Loader(num, Encoding);
	}

	public void Cut()
	{
		DirectMessage(2177);
	}

	public void DeleteRange(int position, int length)
	{
		int textLength = TextLength;
		position = Helpers.Clamp(position, 0, textLength);
		length = Helpers.Clamp(length, 0, textLength - position);
		int num = Lines.CharToBytePosition(position);
		int num2 = Lines.CharToBytePosition(position + length);
		DirectMessage(2645, new IntPtr(num), new IntPtr(num2 - num));
	}

	public unsafe string DescribeKeywordSets()
	{
		int num = ((IntPtr)DirectMessage(4017)).ToInt32();
		byte[] array = new byte[num + 1];
		fixed (byte* value = array)
		{
			DirectMessage(4017, IntPtr.Zero, new IntPtr(value));
		}
		return Encoding.ASCII.GetString(array, 0, num);
	}

	public unsafe string DescribeProperty(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return string.Empty;
		}
		fixed (byte* bytes = Helpers.GetBytes(name, Encoding.ASCII, zeroTerminated: true))
		{
			int num = ((IntPtr)DirectMessage(4016, new IntPtr(bytes), IntPtr.Zero)).ToInt32();
			if (num == 0)
			{
				return string.Empty;
			}
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(4016, new IntPtr(bytes), new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
			}
		}
	}

	internal nint DirectMessage(int msg)
	{
		return DirectMessage(msg, IntPtr.Zero, IntPtr.Zero);
	}

	internal nint DirectMessage(int msg, nint wParam)
	{
		return DirectMessage(msg, wParam, IntPtr.Zero);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual nint DirectMessage(int msg, nint wParam, nint lParam)
	{
		return DirectMessage(SciPointer, msg, wParam, lParam);
	}

	private static nint DirectMessage(nint sciPtr, int msg, nint wParam, nint lParam)
	{
		return directFunction(sciPtr, msg, wParam, lParam);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (reparent)
			{
				reparent = false;
				if (base.IsHandleCreated)
				{
					DestroyHandle();
				}
			}
			if (fillUpChars != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(fillUpChars);
				fillUpChars = IntPtr.Zero;
			}
		}
		base.Dispose(disposing);
	}

	public int DocLineFromVisible(int displayLine)
	{
		displayLine = Helpers.Clamp(displayLine, 0, VisibleLineCount);
		return ((IntPtr)DirectMessage(2221, new IntPtr(displayLine))).ToInt32();
	}

	public void DropSelection(int selection)
	{
		selection = Helpers.ClampMin(selection, 0);
		DirectMessage(2671, new IntPtr(selection));
	}

	public void EmptyUndoBuffer()
	{
		DirectMessage(2175);
	}

	public void EndUndoAction()
	{
		DirectMessage(2079);
	}

	public void ExecuteCmd(Command sciCommand)
	{
		DirectMessage((int)sciCommand);
	}

	public unsafe int FindText(SearchFlags searchFlags, string text, int start, int end)
	{
		int num = 0;
		fixed (byte* bytes = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: true))
		{
			NativeMethods.Sci_TextToFind sci_TextToFind = new NativeMethods.Sci_TextToFind
			{
				chrg = new NativeMethods.Sci_CharacterRange
				{
					cpMin = Lines.CharToBytePosition(Helpers.Clamp(start, 0, TextLength)),
					cpMax = Lines.CharToBytePosition(Helpers.Clamp(end, 0, TextLength))
				},
				lpstrText = new IntPtr(bytes)
			};
			num = ((IntPtr)DirectMessage(2150, (nint)searchFlags, new IntPtr(&sci_TextToFind))).ToInt32();
		}
		if (num == -1)
		{
			return num;
		}
		return Lines.ByteToCharPosition(num);
	}

	public void FoldAll(FoldAction action)
	{
		DirectMessage(2662, new IntPtr((int)action));
	}

	public void FoldDisplayTextSetStyle(FoldDisplayText style)
	{
		DirectMessage(2701, new IntPtr((int)style));
	}

	public void FreeSubstyles()
	{
		DirectMessage(4023);
	}

	public unsafe int GetCharAt(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		int num = ((IntPtr)DirectMessage(2670, new IntPtr(position), new IntPtr(1))).ToInt32();
		int num2 = num - position;
		if (num2 <= 1)
		{
			return ((IntPtr)DirectMessage(2007, new IntPtr(position))).ToInt32();
		}
		fixed (byte* value = new byte[num2 + 1])
		{
			NativeMethods.Sci_TextRange* ptr = stackalloc NativeMethods.Sci_TextRange[1];
			ptr->chrg.cpMin = position;
			ptr->chrg.cpMax = num;
			ptr->lpstrText = new IntPtr(value);
			DirectMessage(2162, IntPtr.Zero, new IntPtr(ptr));
			return Helpers.GetString(new IntPtr(value), num2, Encoding)[0];
		}
	}

	public int GetColumn(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		return ((IntPtr)DirectMessage(2129, new IntPtr(position))).ToInt32();
	}

	public int GetEndStyled()
	{
		int pos = ((IntPtr)DirectMessage(2028)).ToInt32();
		return Lines.ByteToCharPosition(pos);
	}

	public int GetPrimaryStyleFromStyle(int style)
	{
		return ((IntPtr)DirectMessage(4028, new IntPtr(style))).ToInt32();
	}

	public unsafe string GetProperty(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return string.Empty;
		}
		fixed (byte* bytes = Helpers.GetBytes(name, Encoding.ASCII, zeroTerminated: true))
		{
			int num = ((IntPtr)DirectMessage(4008, new IntPtr(bytes))).ToInt32();
			if (num == 0)
			{
				return string.Empty;
			}
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(4008, new IntPtr(bytes), new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
			}
		}
	}

	public unsafe string GetPropertyExpanded(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return string.Empty;
		}
		fixed (byte* bytes = Helpers.GetBytes(name, Encoding.ASCII, zeroTerminated: true))
		{
			int num = ((IntPtr)DirectMessage(4009, new IntPtr(bytes))).ToInt32();
			if (num == 0)
			{
				return string.Empty;
			}
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(4009, new IntPtr(bytes), new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
			}
		}
	}

	public unsafe int GetPropertyInt(string name, int defaultValue)
	{
		if (string.IsNullOrEmpty(name))
		{
			return defaultValue;
		}
		fixed (byte* bytes = Helpers.GetBytes(name, Encoding.ASCII, zeroTerminated: true))
		{
			return ((IntPtr)DirectMessage(4010, new IntPtr(bytes), new IntPtr(defaultValue))).ToInt32();
		}
	}

	public int GetStyleAt(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		return ((IntPtr)DirectMessage(2010, new IntPtr(position))).ToInt32();
	}

	public int GetStyleFromSubstyle(int subStyle)
	{
		return ((IntPtr)DirectMessage(4027, new IntPtr(subStyle))).ToInt32();
	}

	public int GetSubstylesLength(int styleBase)
	{
		return ((IntPtr)DirectMessage(4022, new IntPtr(styleBase))).ToInt32();
	}

	public int GetSubstylesStart(int styleBase)
	{
		return ((IntPtr)DirectMessage(4021, new IntPtr(styleBase))).ToInt32();
	}

	public unsafe string GetTag(int tagNumber)
	{
		tagNumber = Helpers.Clamp(tagNumber, 1, 9);
		int num = ((IntPtr)DirectMessage(2616, new IntPtr(tagNumber), IntPtr.Zero)).ToInt32();
		if (num <= 0)
		{
			return string.Empty;
		}
		fixed (byte* value = new byte[num + 1])
		{
			DirectMessage(2616, new IntPtr(tagNumber), new IntPtr(value));
			return Helpers.GetString(new IntPtr(value), num, Encoding);
		}
	}

	public string GetWideTextRange(int position, int length)
	{
		int textLength = TextLength;
		position = Helpers.Clamp(position, 0, textLength);
		length = Helpers.Clamp(length, 0, textLength - position);
		int num = Lines.CharToWideBytePosition(position);
		int num2 = Lines.CharToWideBytePosition(position + length);
		nint num3 = DirectMessage(2643, new IntPtr(num), new IntPtr(num2 - num));
		if (num3 == IntPtr.Zero)
		{
			return string.Empty;
		}
		return Helpers.GetString(num3, num2 - num, Encoding);
	}

	public string GetLexerIDFromLexer(Lexer lexer)
	{
		return lexer switch
		{
			Lexer.SCLEX_A68K => "a68k", 
			Lexer.SCLEX_ADPL => "apdl", 
			Lexer.SCLEX_ASYMPTOTE => "asy", 
			Lexer.SCLEX_AU3 => "au3", 
			Lexer.SCLEX_AVE => "ave", 
			Lexer.SCLEX_AVS => "avs", 
			Lexer.SCLEX_ABAQUS => "abaqus", 
			Lexer.SCLEX_ADA => "ada", 
			Lexer.SCLEX_ASCIIDOC => "asciidoc", 
			Lexer.SCLEX_ASM => "asm", 
			Lexer.SCLEX_AS => "as", 
			Lexer.SCLEX_ASN1 => "asn1", 
			Lexer.SCLEX_BAAN => "baan", 
			Lexer.SCLEX_BASH => "bash", 
			Lexer.SCLEX_BLITZBASIC => "blitzbasic", 
			Lexer.SCLEX_PUREBASIC => "purebasic", 
			Lexer.SCLEX_FREEBASIC => "freebasic", 
			Lexer.SCLEX_BATCH => "batch", 
			Lexer.SCLEX_BIBTEX => "bibtex", 
			Lexer.SCLEX_BULLANT => "bullant", 
			Lexer.SCLEX_CIL => "cil", 
			Lexer.SCLEX_CLW => "clarion", 
			Lexer.SCLEX_CLWNOCASE => "clarionnocase", 
			Lexer.SCLEX_COBOL => "COBOL", 
			Lexer.SCLEX_CPP => "cpp", 
			Lexer.SCLEX_CPPNOCASE => "cppnocase", 
			Lexer.SCLEX_CSHARP => "cpp", 
			Lexer.SCLEX_JAVA => "cpp", 
			Lexer.SCLEX_JAVASCRIPT => "cpp", 
			Lexer.SCLEX_CSS => "css", 
			Lexer.SCLEX_CAML => "caml", 
			Lexer.SCLEX_CMAKE => "cmake", 
			Lexer.SCLEX_COFFEESCRIPT => "coffeescript", 
			Lexer.SCLEX_CONF => "conf", 
			Lexer.SCLEX_NNCRONTAB => "nncrontab", 
			Lexer.SCLEX_CSOUND => "csound", 
			Lexer.SCLEX_D => "d", 
			Lexer.SCLEX_DMAP => "DMAP", 
			Lexer.SCLEX_DMIS => "DMIS", 
			Lexer.SCLEX_DATAFLEX => "dataflex", 
			Lexer.SCLEX_DIFF => "diff", 
			Lexer.SCLEX_ECL => "ecl", 
			Lexer.SCLEX_EDIFACT => "edifact", 
			Lexer.SCLEX_ESCRIPT => "escript", 
			Lexer.SCLEX_EIFFEL => "eiffel", 
			Lexer.SCLEX_EIFFELKW => "eiffelkw", 
			Lexer.SCLEX_ERLANG => "erlang", 
			Lexer.SCLEX_ERRORLIST => "errorlist", 
			Lexer.SCLEX_FSHARP => "fsharp", 
			Lexer.SCLEX_FLAGSHIP => "flagship", 
			Lexer.SCLEX_FORTH => "forth", 
			Lexer.SCLEX_FORTRAN => "fortran", 
			Lexer.SCLEX_F77 => "f77", 
			Lexer.SCLEX_GAP => "gap", 
			Lexer.SCLEX_GDSCRIPT => "gdscript", 
			Lexer.SCLEX_GUI4CLI => "gui4cli", 
			Lexer.SCLEX_HTML => "hypertext", 
			Lexer.SCLEX_XML => "xml", 
			Lexer.SCLEX_PHPSCRIPT => "phpscript", 
			Lexer.SCLEX_HASKELL => "haskell", 
			Lexer.SCLEX_LITERATEHASKELL => "literatehaskell", 
			Lexer.SCLEX_SREC => "srec", 
			Lexer.SCLEX_IHEX => "ihex", 
			Lexer.SCLEX_TEHEX => "tehex", 
			Lexer.SCLEX_HOLLYWOOD => "hollywood", 
			Lexer.SCLEX_INDENT => "indent", 
			Lexer.SCLEX_INNOSETUP => "inno", 
			Lexer.SCLEX_JSON => "json", 
			Lexer.SCLEX_JULIA => "julia", 
			Lexer.SCLEX_KIX => "kix", 
			Lexer.SCLEX_KVIRC => "kvirc", 
			Lexer.SCLEX_LATEX => "latex", 
			Lexer.SCLEX_LISP => "lisp", 
			Lexer.SCLEX_LOUT => "lout", 
			Lexer.SCLEX_LUA => "lua", 
			Lexer.SCLEX_MMIXAL => "mmixal", 
			Lexer.SCLEX_LOT => "lot", 
			Lexer.SCLEX_MSSQL => "mssql", 
			Lexer.SCLEX_MAGIK => "magiksf", 
			Lexer.SCLEX_MAKEFILE => "makefile", 
			Lexer.SCLEX_MARKDOWN => "markdown", 
			Lexer.SCLEX_MATLAB => "matlab", 
			Lexer.SCLEX_OCTAVE => "octave", 
			Lexer.SCLEX_MAXIMA => "maxima", 
			Lexer.SCLEX_METAPOST => "metapost", 
			Lexer.SCLEX_MODULA => "modula", 
			Lexer.SCLEX_MYSQL => "mysql", 
			Lexer.SCLEX_NIM => "nim", 
			Lexer.SCLEX_NIMROD => "nimrod", 
			Lexer.SCLEX_NSIS => "nsis", 
			Lexer.SCLEX_NULL => "null", 
			Lexer.SCLEX_OSCRIPT => "oscript", 
			Lexer.SCLEX_OPAL => "opal", 
			Lexer.SCLEX_POWERBASIC => "powerbasic", 
			Lexer.SCLEX_PLM => "PL/M", 
			Lexer.SCLEX_PO => "po", 
			Lexer.SCLEX_POV => "pov", 
			Lexer.SCLEX_POSTSCRIPT => "ps", 
			Lexer.SCLEX_PASCAL => "pascal", 
			Lexer.SCLEX_PERL => "perl", 
			Lexer.SCLEX_POWERPRO => "powerpro", 
			Lexer.SCLEX_POWERSHELL => "powershell", 
			Lexer.SCLEX_PROGRESS => "abl", 
			Lexer.SCLEX_PROPERTIES => "props", 
			Lexer.SCLEX_PYTHON => "python", 
			Lexer.SCLEX_R => "r", 
			Lexer.SCLEX_S => "r", 
			Lexer.SCLEX_SPLUS => "r", 
			Lexer.SCLEX_RAKU => "raku", 
			Lexer.SCLEX_REBOL => "rebol", 
			Lexer.SCLEX_REGISTRY => "registry", 
			Lexer.SCLEX_RUBY => "ruby", 
			Lexer.SCLEX_RUST => "rust", 
			Lexer.SCLEX_SAS => "sas", 
			Lexer.SCLEX_SML => "SML", 
			Lexer.SCLEX_SQL => "sql", 
			Lexer.SCLEX_STTXT => "fcST", 
			Lexer.SCLEX_SCRIPTOL => "scriptol", 
			Lexer.SCLEX_SMALLTALK => "smalltalk", 
			Lexer.SCLEX_SORCUS => "sorcins", 
			Lexer.SCLEX_SPECMAN => "specman", 
			Lexer.SCLEX_SPICE => "spice", 
			Lexer.SCLEX_STATA => "stata", 
			Lexer.SCLEX_TACL => "TACL", 
			Lexer.SCLEX_TADS3 => "tads3", 
			Lexer.SCLEX_TAL => "TAL", 
			Lexer.SCLEX_TCL => "tcl", 
			Lexer.SCLEX_TCMD => "tcmd", 
			Lexer.SCLEX_TEX => "tex", 
			Lexer.SCLEX_TXT2TAGS => "txt2tags", 
			Lexer.SCLEX_VB => "vb", 
			Lexer.SCLEX_VBSCRIPT => "vbscript", 
			Lexer.SCLEX_VHDL => "vhdl", 
			Lexer.SCLEX_VERILOG => "verilog", 
			Lexer.SCLEX_VISUALPROLOG => "visualprolog", 
			Lexer.SCLEX_X12 => "x12", 
			Lexer.SCLEX_YAML => "yaml", 
			_ => throw new ArgumentOutOfRangeException("lexer", lexer, null), 
		};
	}

	public string GetTextRange(int position, int length)
	{
		int textLength = TextLength;
		position = Helpers.Clamp(position, 0, textLength);
		length = Helpers.Clamp(length, 0, textLength - position);
		int num = Lines.CharToBytePosition(position);
		int num2 = Lines.CharToBytePosition(position + length);
		nint num3 = DirectMessage(2643, new IntPtr(num), new IntPtr(num2 - num));
		if (num3 == IntPtr.Zero)
		{
			return string.Empty;
		}
		return Helpers.GetString(num3, num2 - num, Encoding);
	}

	public string GetTextRangeAsHtml(int position, int length)
	{
		int textLength = TextLength;
		position = Helpers.Clamp(position, 0, textLength);
		length = Helpers.Clamp(length, 0, textLength - position);
		int startBytePos = Lines.CharToBytePosition(position);
		int endBytePos = Lines.CharToBytePosition(position + length);
		return Helpers.GetHtml(this, startBytePos, endBytePos);
	}

	public FileVersionInfo GetVersionInfo()
	{
		return FileVersionInfo.GetVersionInfo(modulePathScintilla);
	}

	public string GetWordFromPosition(int position)
	{
		int num = WordStartPosition(position, onlyWordCharacters: true);
		int num2 = WordEndPosition(position, onlyWordCharacters: true);
		return GetTextRange(num, num2 - num);
	}

	public void GotoPosition(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		DirectMessage(2025, new IntPtr(position));
	}

	public void HideLines(int lineStart, int lineEnd)
	{
		lineStart = Helpers.Clamp(lineStart, 0, Lines.Count);
		lineEnd = Helpers.Clamp(lineEnd, lineStart, Lines.Count);
		DirectMessage(2227, new IntPtr(lineStart), new IntPtr(lineEnd));
	}

	public uint IndicatorAllOnFor(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		return (uint)((IntPtr)DirectMessage(2506, new IntPtr(position))).ToInt32();
	}

	public void IndicatorClearRange(int position, int length)
	{
		int textLength = TextLength;
		position = Helpers.Clamp(position, 0, textLength);
		length = Helpers.Clamp(length, 0, textLength - position);
		int num = Lines.CharToBytePosition(position);
		int num2 = Lines.CharToBytePosition(position + length);
		DirectMessage(2505, new IntPtr(num), new IntPtr(num2 - num));
	}

	public void IndicatorFillRange(int position, int length)
	{
		int textLength = TextLength;
		position = Helpers.Clamp(position, 0, textLength);
		length = Helpers.Clamp(length, 0, textLength - position);
		int num = Lines.CharToBytePosition(position);
		int num2 = Lines.CharToBytePosition(position + length);
		DirectMessage(2504, new IntPtr(num), new IntPtr(num2 - num));
	}

	private void InitDocument(Eol eolMode = Eol.CrLf, bool useTabs = false, int tabWidth = 4, int indentWidth = 0)
	{
		DirectMessage(2037, new IntPtr(65001));
		DirectMessage(2012, new IntPtr(1));
		DirectMessage(2031, new IntPtr((int)eolMode));
		DirectMessage(2124, useTabs ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2036, new IntPtr(tabWidth));
		DirectMessage(2122, new IntPtr(indentWidth));
	}

	private void InitControlProps()
	{
		ScrollWidth = 1;
		ScrollWidthTracking = true;
		WordChars = "abcdefghijklmnopqrstuvwxyz_ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		foreach (Margin margin in Margins)
		{
			margin.Width = 0;
		}
	}

	public unsafe void InsertText(int position, string text)
	{
		if (position < -1)
		{
			throw new ArgumentOutOfRangeException("position", "Position must be greater or equal to zero, or -1.");
		}
		if (position != -1)
		{
			int textLength = TextLength;
			if (position > textLength)
			{
				throw new ArgumentOutOfRangeException("position", "Position cannot exceed document length.");
			}
			position = Lines.CharToBytePosition(position);
		}
		fixed (byte* bytes = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: true))
		{
			DirectMessage(2003, new IntPtr(position), new IntPtr(bytes));
		}
	}

	public bool IsRangeWord(int start, int end)
	{
		int textLength = TextLength;
		start = Helpers.Clamp(start, 0, textLength);
		end = Helpers.Clamp(end, 0, textLength);
		start = Lines.CharToBytePosition(start);
		end = Lines.CharToBytePosition(end);
		return DirectMessage(2691, new IntPtr(start), new IntPtr(end)) != IntPtr.Zero;
	}

	public int LineFromPosition(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		return Lines.LineFromCharPosition(position);
	}

	public void LineScroll(int lines, int columns)
	{
		DirectMessage(2168, new IntPtr(columns), new IntPtr(lines));
	}

	public unsafe void LoadLexerLibrary(string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			fixed (byte* bytes = Helpers.GetBytes(path, Encoding.Default, zeroTerminated: true))
			{
				DirectMessage(4007, IntPtr.Zero, new IntPtr(bytes));
			}
		}
	}

	public void MarkerDeleteAll(int marker)
	{
		marker = Helpers.Clamp(marker, -1, Markers.Count - 1);
		DirectMessage(2045, new IntPtr(marker));
	}

	public void MarkerDeleteHandle(MarkerHandle markerHandle)
	{
		DirectMessage(2018, markerHandle.Value);
	}

	public void MarkerEnableHighlight(bool enabled)
	{
		nint wParam = (enabled ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2293, wParam);
	}

	public int MarkerLineFromHandle(MarkerHandle markerHandle)
	{
		return ((IntPtr)DirectMessage(2017, markerHandle.Value)).ToInt32();
	}

	public void MultiEdgeAddLine(int column, Color edgeColor)
	{
		column = Helpers.ClampMin(column, 0);
		int value = HelperMethods.ToWin32ColorOpaque(edgeColor);
		DirectMessage(2694, new IntPtr(column), new IntPtr(value));
	}

	public void MultiEdgeClearAll()
	{
		DirectMessage(2695);
	}

	public void MultipleSelectAddEach()
	{
		DirectMessage(2689);
	}

	public void MultipleSelectAddNext()
	{
		DirectMessage(2688);
	}

	protected virtual void OnAutoCCancelled(EventArgs e)
	{
		if (base.Events[autoCCancelledEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnAutoCCharDeleted(EventArgs e)
	{
		if (base.Events[autoCCharDeletedEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnAutoCCompleted(AutoCSelectionEventArgs e)
	{
		if (base.Events[autoCCompletedEventKey] is EventHandler<AutoCSelectionEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnAutoCSelection(AutoCSelectionEventArgs e)
	{
		if (base.Events[autoCSelectionEventKey] is EventHandler<AutoCSelectionEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnAutoCSelectionChange(AutoCSelectionChangeEventArgs e)
	{
		if (base.Events[autoCSelectionChangeEventKey] is EventHandler<AutoCSelectionChangeEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnBeforeDelete(BeforeModificationEventArgs e)
	{
		if (base.Events[beforeDeleteEventKey] is EventHandler<BeforeModificationEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnBeforeInsert(BeforeModificationEventArgs e)
	{
		if (base.Events[beforeInsertEventKey] is EventHandler<BeforeModificationEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnBorderStyleChanged(EventArgs e)
	{
		if (base.Events[borderStyleChangedEventKey] is EventHandler eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnChangeAnnotation(ChangeAnnotationEventArgs e)
	{
		if (base.Events[changeAnnotationEventKey] is EventHandler<ChangeAnnotationEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnCharAdded(CharAddedEventArgs e)
	{
		if (base.Events[charAddedEventKey] is EventHandler<CharAddedEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnDelete(ModificationEventArgs e)
	{
		if (base.Events[deleteEventKey] is EventHandler<ModificationEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnDoubleClick(DoubleClickEventArgs e)
	{
		if (base.Events[doubleClickEventKey] is EventHandler<DoubleClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnDwellEnd(DwellEventArgs e)
	{
		if (base.Events[dwellEndEventKey] is EventHandler<DwellEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnDwellStart(DwellEventArgs e)
	{
		if (base.Events[dwellStartEventKey] is EventHandler<DwellEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnCallTipClick(CallTipClickEventArgs e)
	{
		if (base.Events[callTipClickEventKey] is EventHandler<CallTipClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		InitDocument();
		InitControlProps();
		DirectMessage(2212, new IntPtr(16));
		if (!_ScintillaManagedDragDrop)
		{
			NativeMethods.RevokeDragDrop(base.Handle);
		}
		base.OnHandleCreated(e);
	}

	protected virtual void OnHotspotClick(HotspotClickEventArgs e)
	{
		if (base.Events[hotspotClickEventKey] is EventHandler<HotspotClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnHotspotDoubleClick(HotspotClickEventArgs e)
	{
		if (base.Events[hotspotDoubleClickEventKey] is EventHandler<HotspotClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnHotspotReleaseClick(HotspotClickEventArgs e)
	{
		if (base.Events[hotspotReleaseClickEventKey] is EventHandler<HotspotClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnIndicatorClick(IndicatorClickEventArgs e)
	{
		if (base.Events[indicatorClickEventKey] is EventHandler<IndicatorClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnIndicatorRelease(IndicatorReleaseEventArgs e)
	{
		if (base.Events[indicatorReleaseEventKey] is EventHandler<IndicatorReleaseEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnInsert(ModificationEventArgs e)
	{
		if (base.Events[insertEventKey] is EventHandler<ModificationEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnInsertCheck(InsertCheckEventArgs e)
	{
		if (base.Events[insertCheckEventKey] is EventHandler<InsertCheckEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnMarginClick(MarginClickEventArgs e)
	{
		if (base.Events[marginClickEventKey] is EventHandler<MarginClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnMarginRightClick(MarginClickEventArgs e)
	{
		if (base.Events[marginRightClickEventKey] is EventHandler<MarginClickEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnModifyAttempt(EventArgs e)
	{
		if (base.Events[modifyAttemptEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (!doubleClick)
		{
			OnClick(e);
			OnMouseClick(e);
		}
		else
		{
			MouseEventArgs e2 = new MouseEventArgs(e.Button, 2, e.X, e.Y, e.Delta);
			OnDoubleClick(e2);
			OnMouseDoubleClick(e2);
			doubleClick = false;
		}
		base.OnMouseUp(e);
	}

	protected virtual void OnNeedShown(NeedShownEventArgs e)
	{
		if (base.Events[needShownEventKey] is EventHandler<NeedShownEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnPainted(EventArgs e)
	{
		if (base.Events[paintedEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnSavePointLeft(EventArgs e)
	{
		if (base.Events[savePointLeftEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnSavePointReached(EventArgs e)
	{
		if (base.Events[savePointReachedEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnStyleNeeded(StyleNeededEventArgs e)
	{
		if (base.Events[styleNeededEventKey] is EventHandler<StyleNeededEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnUpdateUI(UpdateUIEventArgs e)
	{
		if (base.Events[updateUIEventKey] is EventHandler<UpdateUIEventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	protected virtual void OnZoomChanged(EventArgs e)
	{
		if (base.Events[zoomChangedEventKey] is EventHandler<EventArgs> eventHandler)
		{
			eventHandler(this, e);
		}
	}

	public void Paste()
	{
		DirectMessage(2179);
	}

	public int PointXFromPosition(int pos)
	{
		pos = Helpers.Clamp(pos, 0, TextLength);
		pos = Lines.CharToBytePosition(pos);
		return ((IntPtr)DirectMessage(2164, IntPtr.Zero, new IntPtr(pos))).ToInt32();
	}

	public int PointYFromPosition(int pos)
	{
		pos = Helpers.Clamp(pos, 0, TextLength);
		pos = Lines.CharToBytePosition(pos);
		return ((IntPtr)DirectMessage(2165, IntPtr.Zero, new IntPtr(pos))).ToInt32();
	}

	public unsafe string PropertyNames()
	{
		int num = ((IntPtr)DirectMessage(4014)).ToInt32();
		if (num == 0)
		{
			return string.Empty;
		}
		fixed (byte* value = new byte[num + 1])
		{
			DirectMessage(4014, IntPtr.Zero, new IntPtr(value));
			return Helpers.GetString(new IntPtr(value), num, Encoding.ASCII);
		}
	}

	public unsafe PropertyType PropertyType(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return ScintillaNET.PropertyType.Boolean;
		}
		fixed (byte* bytes = Helpers.GetBytes(name, Encoding.ASCII, zeroTerminated: true))
		{
			return (PropertyType)DirectMessage(4015, new IntPtr(bytes));
		}
	}

	public void Redo()
	{
		DirectMessage(2011);
	}

	public unsafe void RegisterRgbaImage(int type, Bitmap image)
	{
		if (image != null)
		{
			DirectMessage(2624, new IntPtr(((Image)image).Width));
			DirectMessage(2625, new IntPtr(((Image)image).Height));
			fixed (byte* value = Helpers.BitmapToArgb(image))
			{
				DirectMessage(2627, new IntPtr(type), new IntPtr(value));
			}
		}
	}

	public void ReleaseDocument(Document document)
	{
		nint value = document.Value;
		DirectMessage(2377, IntPtr.Zero, value);
	}

	public unsafe void ReplaceSelection(string text)
	{
		fixed (byte* bytes = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: true))
		{
			DirectMessage(2170, IntPtr.Zero, new IntPtr(bytes));
		}
	}

	public unsafe int ReplaceTarget(string text)
	{
		if (text == null)
		{
			text = string.Empty;
		}
		byte[] array = Helpers.GetBytes(text, Encoding, zeroTerminated: false);
		int num = array.Length;
		if (num == 0)
		{
			array = new byte[1];
		}
		fixed (byte* value = array)
		{
			DirectMessage(2194, new IntPtr(num), new IntPtr(value));
		}
		return text.Length;
	}

	public unsafe int ReplaceTargetRe(string text)
	{
		byte[] array = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: false);
		int num = array.Length;
		if (num == 0)
		{
			array = new byte[1];
		}
		fixed (byte* value = array)
		{
			DirectMessage(2195, new IntPtr(num), new IntPtr(value));
		}
		return Math.Abs(TargetEnd - TargetStart);
	}

	private void ResetAdditionalCaretForeColor()
	{
		AdditionalCaretForeColor = Color.FromArgb(127, 127, 127);
	}

	public void RotateSelection()
	{
		DirectMessage(2606);
	}

	private void ScnDoubleClick(ref NativeMethods.SCNotification scn)
	{
		Keys modifiers = (Keys)(-65536 & (scn.modifiers << 16));
		DoubleClickEventArgs e = new DoubleClickEventArgs(this, modifiers, ((IntPtr)scn.position).ToInt32(), ((IntPtr)scn.line).ToInt32());
		OnDoubleClick(e);
	}

	private void ScnHotspotClick(ref NativeMethods.SCNotification scn)
	{
		Keys modifiers = (Keys)(-65536 & (scn.modifiers << 16));
		HotspotClickEventArgs e = new HotspotClickEventArgs(this, modifiers, ((IntPtr)scn.position).ToInt32());
		switch (scn.nmhdr.code)
		{
		case 2019:
			OnHotspotClick(e);
			break;
		case 2020:
			OnHotspotDoubleClick(e);
			break;
		case 2027:
			OnHotspotReleaseClick(e);
			break;
		}
	}

	private void ScnIndicatorClick(ref NativeMethods.SCNotification scn)
	{
		switch (scn.nmhdr.code)
		{
		case 2023:
		{
			Keys modifiers = (Keys)(-65536 & (scn.modifiers << 16));
			OnIndicatorClick(new IndicatorClickEventArgs(this, modifiers, ((IntPtr)scn.position).ToInt32()));
			break;
		}
		case 2024:
			OnIndicatorRelease(new IndicatorReleaseEventArgs(this, ((IntPtr)scn.position).ToInt32()));
			break;
		}
	}

	private void ScnMarginClick(ref NativeMethods.SCNotification scn)
	{
		Keys modifiers = (Keys)(-65536 & (scn.modifiers << 16));
		MarginClickEventArgs e = new MarginClickEventArgs(this, modifiers, ((IntPtr)scn.position).ToInt32(), scn.margin);
		if (scn.nmhdr.code == 2010)
		{
			OnMarginClick(e);
		}
		else
		{
			OnMarginRightClick(e);
		}
	}

	private void ScnModified(ref NativeMethods.SCNotification scn)
	{
		if ((scn.modificationType & 0x100000) > 0)
		{
			InsertCheckEventArgs e = new InsertCheckEventArgs(this, ((IntPtr)scn.position).ToInt32(), ((IntPtr)scn.length).ToInt32(), scn.text);
			OnInsertCheck(e);
			cachedPosition = e.CachedPosition;
			cachedText = e.CachedText;
		}
		if ((scn.modificationType & 0xC00) > 0)
		{
			ModificationSource source = (ModificationSource)(scn.modificationType & 0x70);
			BeforeModificationEventArgs e2 = new BeforeModificationEventArgs(this, source, ((IntPtr)scn.position).ToInt32(), ((IntPtr)scn.length).ToInt32(), scn.text)
			{
				CachedPosition = cachedPosition,
				CachedText = cachedText
			};
			if ((scn.modificationType & 0x400) > 0)
			{
				OnBeforeInsert(e2);
			}
			else
			{
				OnBeforeDelete(e2);
			}
			cachedPosition = e2.CachedPosition;
			cachedText = e2.CachedText;
		}
		if ((scn.modificationType & 3) > 0)
		{
			ModificationSource source2 = (ModificationSource)(scn.modificationType & 0x70);
			ModificationEventArgs e3 = new ModificationEventArgs(this, source2, ((IntPtr)scn.position).ToInt32(), ((IntPtr)scn.length).ToInt32(), scn.text, ((IntPtr)scn.linesAdded).ToInt32())
			{
				CachedPosition = cachedPosition,
				CachedText = cachedText
			};
			if ((scn.modificationType & 1) > 0)
			{
				OnInsert(e3);
			}
			else
			{
				OnDelete(e3);
			}
			cachedPosition = null;
			cachedText = null;
			OnTextChanged(EventArgs.Empty);
		}
		if ((scn.modificationType & 0x20000) > 0)
		{
			ChangeAnnotationEventArgs e4 = new ChangeAnnotationEventArgs(((IntPtr)scn.line).ToInt32());
			OnChangeAnnotation(e4);
		}
	}

	public void ScrollCaret()
	{
		DirectMessage(2169);
	}

	public void ScrollRange(int start, int end)
	{
		int textLength = TextLength;
		start = Helpers.Clamp(start, 0, textLength);
		end = Helpers.Clamp(end, 0, textLength);
		start = Lines.CharToBytePosition(start);
		end = Lines.CharToBytePosition(end);
		DirectMessage(2569, new IntPtr(start), new IntPtr(end));
	}

	public unsafe int SearchInTarget(string text)
	{
		int num = 0;
		byte[] array = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: false);
		int num2 = array.Length;
		if (num2 == 0)
		{
			array = new byte[1];
		}
		fixed (byte* value = array)
		{
			num = ((IntPtr)DirectMessage(2197, new IntPtr(num2), new IntPtr(value))).ToInt32();
		}
		if (num == -1)
		{
			return num;
		}
		return Lines.ByteToCharPosition(num);
	}

	public void SelectAll()
	{
		DirectMessage(2013);
	}

	[Obsolete("Superseded by SelectionAdditionalBackColor property.")]
	public void SetAdditionalSelBack(Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		DirectMessage(2601, new IntPtr(value));
	}

	[Obsolete("Superseded by SelectionAdditionalTextColor property.")]
	public void SetAdditionalSelFore(Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		DirectMessage(2600, new IntPtr(value));
	}

	public void SetEmptySelection(int pos)
	{
		pos = Helpers.Clamp(pos, 0, TextLength);
		pos = Lines.CharToBytePosition(pos);
		DirectMessage(2556, new IntPtr(pos));
	}

	public void SetFoldFlags(FoldFlags flags)
	{
		DirectMessage(2233, new IntPtr((int)flags));
	}

	public void SetFoldMarginColor(bool use, Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		nint wParam = (use ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2290, wParam, new IntPtr(value));
	}

	public void SetFoldMarginHighlightColor(bool use, Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		nint wParam = (use ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2291, wParam, new IntPtr(value));
	}

	public unsafe void SetIdentifiers(int style, string identifiers)
	{
		int styleFromSubstyle = GetStyleFromSubstyle(style);
		int substylesStart = GetSubstylesStart(styleFromSubstyle);
		int substylesLength = GetSubstylesLength(styleFromSubstyle);
		int max = ((substylesLength > 0) ? (substylesStart + substylesLength - 1) : substylesStart);
		style = Helpers.Clamp(style, substylesStart, max);
		fixed (byte* bytes = Helpers.GetBytes(identifiers ?? string.Empty, Encoding.ASCII, zeroTerminated: true))
		{
			DirectMessage(4024, new IntPtr(style), new IntPtr(bytes));
		}
	}

	public unsafe void SetKeywords(int set, string keywords)
	{
		set = Helpers.Clamp(set, 0, 8);
		fixed (byte* bytes = Helpers.GetBytes(keywords ?? string.Empty, Encoding.ASCII, zeroTerminated: true))
		{
			DirectMessage(4005, new IntPtr(set), new IntPtr(bytes));
		}
	}

	public static void SetDestroyHandleBehavior(bool reparent)
	{
		bool valueOrDefault = reparentAll == true;
		if (!reparentAll.HasValue)
		{
			valueOrDefault = reparent;
			reparentAll = valueOrDefault;
		}
	}

	public unsafe void SetProperty(string name, string value)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		byte[] bytes = Helpers.GetBytes(name, Encoding.ASCII, zeroTerminated: true);
		byte[] bytes2 = Helpers.GetBytes(value ?? string.Empty, Encoding.ASCII, zeroTerminated: true);
		fixed (byte* value2 = bytes)
		{
			fixed (byte* value3 = bytes2)
			{
				DirectMessage(4004, new IntPtr(value2), new IntPtr(value3));
			}
		}
	}

	private bool SetRenderer(VisualStyleElement element)
	{
		if (!Application.RenderWithVisualStyles)
		{
			return false;
		}
		if (!VisualStyleRenderer.IsElementDefined(element))
		{
			return false;
		}
		if (renderer == null)
		{
			renderer = new VisualStyleRenderer(element);
		}
		else
		{
			renderer.SetParameters(element);
		}
		return true;
	}

	public void SetSavePoint()
	{
		DirectMessage(2014);
	}

	public void SetSel(int anchorPos, int currentPos)
	{
		if (anchorPos == currentPos)
		{
			anchorPos = -1;
		}
		int textLength = TextLength;
		if (anchorPos >= 0)
		{
			anchorPos = Helpers.Clamp(anchorPos, 0, textLength);
			anchorPos = Lines.CharToBytePosition(anchorPos);
		}
		if (currentPos >= 0)
		{
			currentPos = Helpers.Clamp(currentPos, 0, textLength);
			currentPos = Lines.CharToBytePosition(currentPos);
		}
		DirectMessage(2160, new IntPtr(anchorPos), new IntPtr(currentPos));
	}

	public void SetSelection(int caret, int anchor)
	{
		int textLength = TextLength;
		caret = Helpers.Clamp(caret, 0, textLength);
		anchor = Helpers.Clamp(anchor, 0, textLength);
		caret = Lines.CharToBytePosition(caret);
		anchor = Lines.CharToBytePosition(anchor);
		DirectMessage(2572, new IntPtr(caret), new IntPtr(anchor));
	}

	[Obsolete("Superseded by SelectionBackColor property.")]
	public void SetSelectionBackColor(bool use, Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		nint wParam = (use ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2068, wParam, new IntPtr(value));
	}

	[Obsolete("Superseded by SelectionTextColor property.")]
	public void SetSelectionForeColor(bool use, Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		nint wParam = (use ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2067, wParam, new IntPtr(value));
	}

	public void SetStyling(int length, int style)
	{
		int textLength = TextLength;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length", "Length cannot be less than zero.");
		}
		if (stylingPosition + length > textLength)
		{
			throw new ArgumentOutOfRangeException("length", "Position and length must refer to a range within the document.");
		}
		if (style < 0 || style >= Styles.Count)
		{
			throw new ArgumentOutOfRangeException("style", "Style must be non-negative and less than the size of the collection.");
		}
		int pos = stylingPosition + length;
		int num = Lines.CharToBytePosition(pos);
		DirectMessage(2033, new IntPtr(num - stylingBytePosition), new IntPtr(style));
		stylingPosition = pos;
		stylingBytePosition = num;
	}

	public void SetTargetRange(int start, int end)
	{
		int textLength = TextLength;
		start = Helpers.Clamp(start, 0, textLength);
		end = Helpers.Clamp(end, 0, textLength);
		start = Lines.CharToBytePosition(start);
		end = Lines.CharToBytePosition(end);
		DirectMessage(2686, new IntPtr(start), new IntPtr(end));
	}

	[Obsolete("Superseded by WhitespaceBackColor property.")]
	public void SetWhitespaceBackColor(bool use, Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		nint wParam = (use ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2085, wParam, new IntPtr(value));
	}

	[Obsolete("Superseded by WhitespaceTextColor property.")]
	public void SetWhitespaceForeColor(bool use, Color color)
	{
		int value = HelperMethods.ToWin32ColorOpaque(color);
		nint wParam = (use ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2084, wParam, new IntPtr(value));
	}

	public void SetXCaretPolicy(CaretPolicy caretPolicy, int caretSlop)
	{
		DirectMessage(2402, new IntPtr((int)caretPolicy), new IntPtr(caretSlop));
	}

	public void SetYCaretPolicy(CaretPolicy caretPolicy, int caretSlop)
	{
		DirectMessage(2403, new IntPtr((int)caretPolicy), new IntPtr(caretSlop));
	}

	private bool ShouldSerializeAdditionalCaretForeColor()
	{
		return AdditionalCaretForeColor != Color.FromArgb(127, 127, 127);
	}

	public void ShowLines(int lineStart, int lineEnd)
	{
		lineStart = Helpers.Clamp(lineStart, 0, Lines.Count);
		lineEnd = Helpers.Clamp(lineEnd, lineStart, Lines.Count);
		DirectMessage(2226, new IntPtr(lineStart), new IntPtr(lineEnd));
	}

	public void StartStyling(int position)
	{
		position = Helpers.Clamp(position, 0, TextLength);
		int value = Lines.CharToBytePosition(position);
		DirectMessage(2032, new IntPtr(value));
		stylingPosition = position;
		stylingBytePosition = value;
	}

	public void StyleClearAll()
	{
		DirectMessage(2050);
	}

	public void StyleResetDefault()
	{
		DirectMessage(2058);
	}

	public void SwapMainAnchorCaret()
	{
		DirectMessage(2607);
	}

	public void TargetFromSelection()
	{
		DirectMessage(2287);
	}

	public void TargetWholeDocument()
	{
		DirectMessage(2690);
	}

	public unsafe int TextWidth(int style, string text)
	{
		style = Helpers.Clamp(style, 0, Styles.Count - 1);
		fixed (byte* bytes = Helpers.GetBytes(text ?? string.Empty, Encoding, zeroTerminated: true))
		{
			return ((IntPtr)DirectMessage(2276, new IntPtr(style), new IntPtr(bytes))).ToInt32();
		}
	}

	public void Undo()
	{
		DirectMessage(2176);
	}

	public void UsePopup(bool enablePopup)
	{
		nint wParam = (enablePopup ? new IntPtr(1) : IntPtr.Zero);
		DirectMessage(2371, wParam);
	}

	public void UsePopup(PopupMode popupMode)
	{
		DirectMessage(2371, new IntPtr((int)popupMode));
	}

	private void WmDestroy(ref Message m)
	{
		if (reparent && base.IsHandleCreated)
		{
			NativeMethods.SetParent(base.Handle, new IntPtr(-3));
			m.Result = IntPtr.Zero;
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	private void WmNcPaint(ref Message m)
	{
		if (BorderStyle != BorderStyle.Fixed3DVisualStyles)
		{
			base.WndProc(ref m);
			return;
		}
		VisualStyleElement visualStyleElement = VisualStyleElement.TextBox.TextEdit.Normal;
		if (ReadOnly)
		{
			visualStyleElement = VisualStyleElement.TextBox.TextEdit.ReadOnly;
		}
		else if (Focused)
		{
			visualStyleElement = VisualStyleElement.TextBox.TextEdit.Focused;
		}
		if (!SetRenderer(visualStyleElement))
		{
			base.WndProc(ref m);
			return;
		}
		NativeMethods.GetWindowRect(m.HWnd, out var lpRect);
		Size border3DSize = SystemInformation.Border3DSize;
		nint windowDC = NativeMethods.GetWindowDC(m.HWnd);
		try
		{
			Graphics val = Graphics.FromHdc((IntPtr)windowDC);
			try
			{
				Rectangle rectangle = new Rectangle(0, 0, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
				val.ExcludeClip(Rectangle.Inflate(rectangle, -border3DSize.Width, -border3DSize.Height));
				if (renderer.IsBackgroundPartiallyTransparent())
				{
					renderer.DrawParentBackground((IDeviceContext)(object)val, rectangle, this);
				}
				renderer.DrawBackground((IDeviceContext)(object)val, rectangle);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		finally
		{
			NativeMethods.ReleaseDC(m.HWnd, windowDC);
		}
		nint num = NativeMethods.CreateRectRgn(lpRect.left + border3DSize.Width, lpRect.top + border3DSize.Height, lpRect.right - border3DSize.Width, lpRect.bottom - border3DSize.Height);
		if (m.WParam != 1)
		{
			NativeMethods.CombineRgn(num, num, m.WParam, 1);
		}
		m.WParam = num;
		DefWndProc(ref m);
		m.Result = IntPtr.Zero;
	}

	private void WmReflectNotify(ref Message m)
	{
		NativeMethods.SCNotification scn = (NativeMethods.SCNotification)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.SCNotification));
		int code = scn.nmhdr.code;
		if (code >= 2000 && code <= 2032)
		{
			if (base.Events[scNotificationEventKey] is EventHandler<SCNotificationEventArgs> eventHandler)
			{
				eventHandler(this, new SCNotificationEventArgs(scn));
			}
			switch (scn.nmhdr.code)
			{
			case 2013:
				OnPainted(EventArgs.Empty);
				break;
			case 2008:
				ScnModified(ref scn);
				break;
			case 2004:
				OnModifyAttempt(EventArgs.Empty);
				break;
			case 2000:
				OnStyleNeeded(new StyleNeededEventArgs(this, ((IntPtr)scn.position).ToInt32()));
				break;
			case 2003:
				OnSavePointLeft(EventArgs.Empty);
				break;
			case 2002:
				OnSavePointReached(EventArgs.Empty);
				break;
			case 2010:
			case 2031:
				ScnMarginClick(ref scn);
				break;
			case 2007:
				OnUpdateUI(new UpdateUIEventArgs((UpdateChange)scn.updated));
				break;
			case 2001:
				OnCharAdded(new CharAddedEventArgs(scn.ch));
				break;
			case 2022:
				OnAutoCSelection(new AutoCSelectionEventArgs(this, ((IntPtr)scn.position).ToInt32(), scn.text, scn.ch, (ListCompletionMethod)scn.listCompletionMethod));
				break;
			case 2030:
				OnAutoCCompleted(new AutoCSelectionEventArgs(this, ((IntPtr)scn.position).ToInt32(), scn.text, scn.ch, (ListCompletionMethod)scn.listCompletionMethod));
				break;
			case 2025:
				OnAutoCCancelled(EventArgs.Empty);
				break;
			case 2026:
				OnAutoCCharDeleted(EventArgs.Empty);
				break;
			case 2032:
				OnAutoCSelectionChange(new AutoCSelectionChangeEventArgs(this, scn.text, ((IntPtr)scn.position).ToInt32(), scn.listType));
				break;
			case 2016:
				OnDwellStart(new DwellEventArgs(this, ((IntPtr)scn.position).ToInt32(), scn.x, scn.y));
				break;
			case 2017:
				OnDwellEnd(new DwellEventArgs(this, ((IntPtr)scn.position).ToInt32(), scn.x, scn.y));
				break;
			case 2006:
				ScnDoubleClick(ref scn);
				break;
			case 2011:
				OnNeedShown(new NeedShownEventArgs(this, ((IntPtr)scn.position).ToInt32(), ((IntPtr)scn.length).ToInt32()));
				break;
			case 2019:
			case 2020:
			case 2027:
				ScnHotspotClick(ref scn);
				break;
			case 2023:
			case 2024:
				ScnIndicatorClick(ref scn);
				break;
			case 2018:
				OnZoomChanged(EventArgs.Empty);
				break;
			case 2021:
				OnCallTipClick(new CallTipClickEventArgs(this, (CallTipClickType)((IntPtr)scn.position).ToInt32()));
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}
	}

	protected override void WndProc(ref Message m)
	{
		switch (m.Msg)
		{
		case 8270:
			WmReflectNotify(ref m);
			return;
		case 32:
			DefWndProc(ref m);
			return;
		case 133:
			WmNcPaint(ref m);
			return;
		case 515:
		case 518:
		case 521:
		case 525:
			doubleClick = true;
			break;
		case 2:
			WmDestroy(ref m);
			return;
		}
		base.WndProc(ref m);
	}

	public int WordEndPosition(int position, bool onlyWordCharacters)
	{
		nint lParam = (onlyWordCharacters ? new IntPtr(1) : IntPtr.Zero);
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		position = ((IntPtr)DirectMessage(2267, new IntPtr(position), lParam)).ToInt32();
		return Lines.ByteToCharPosition(position);
	}

	public int WordStartPosition(int position, bool onlyWordCharacters)
	{
		nint lParam = (onlyWordCharacters ? new IntPtr(1) : IntPtr.Zero);
		position = Helpers.Clamp(position, 0, TextLength);
		position = Lines.CharToBytePosition(position);
		position = ((IntPtr)DirectMessage(2266, new IntPtr(position), lParam)).ToInt32();
		return Lines.ByteToCharPosition(position);
	}

	public void ZoomIn()
	{
		DirectMessage(2333);
	}

	public void ZoomOut()
	{
		DirectMessage(2334);
	}

	public unsafe void SetRepresentation(string encodedString, string representationString)
	{
		byte[] bytes = Helpers.GetBytes(encodedString, Encoding, zeroTerminated: true);
		byte[] bytes2 = Helpers.GetBytes(representationString, Encoding, zeroTerminated: true);
		fixed (byte* value = bytes)
		{
			fixed (byte* value2 = bytes2)
			{
				DirectMessage(2665, new IntPtr(value), new IntPtr(value2));
			}
		}
	}

	public unsafe string GetRepresentation(string encodedString)
	{
		fixed (byte* bytes = Helpers.GetBytes(encodedString, Encoding, zeroTerminated: true))
		{
			int num = ((IntPtr)DirectMessage(2666, new IntPtr(bytes), IntPtr.Zero)).ToInt32();
			fixed (byte* value = new byte[num + 1])
			{
				DirectMessage(2666, new IntPtr(bytes), new IntPtr(value));
				return Helpers.GetString(new IntPtr(value), num, Encoding);
			}
		}
	}

	public unsafe void ClearRepresentation(string encodedString)
	{
		fixed (byte* bytes = Helpers.GetBytes(encodedString, Encoding, zeroTerminated: true))
		{
			DirectMessage(2667, new IntPtr(bytes), IntPtr.Zero);
		}
	}

	public void ClearChangeHistory()
	{
		EmptyUndoBuffer();
		ChangeHistory changeHistory = ChangeHistory;
		ChangeHistory = ChangeHistory.Disabled;
		ChangeHistory = changeHistory;
	}

	public Scintilla()
	{
		if (!reparentAll.HasValue || reparentAll.Value)
		{
			reparent = true;
		}
		SetStyle(ControlStyles.CacheText, value: true);
		SetStyle(ControlStyles.UserPaint | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.UseTextForAccessibility, value: false);
		borderStyle = BorderStyle.Fixed3D;
		Lines = new LineCollection(this);
		Styles = new StyleCollection(this);
		Indicators = new IndicatorCollection(this);
		Margins = new MarginCollection(this);
		Markers = new MarkerCollection(this);
		Selections = new SelectionCollection(this);
	}
}
