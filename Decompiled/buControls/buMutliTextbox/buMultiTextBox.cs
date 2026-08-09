using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns21;
using ns23;
using ns27;

namespace buMutliTextbox;

public class buMultiTextBox : UserControl, ISupportInitialize
{
	internal sealed class Class39 : IComparer<LineInfo>
	{
		private readonly int int_0;

		public Class39(int int_1)
		{
			int_0 = int_1;
		}

		int IComparer<LineInfo>.Compare(LineInfo x, LineInfo y)
		{
			if (x.startY != -10)
			{
				return x.startY.CompareTo(int_0);
			}
			return -y.startY.CompareTo(int_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class40
	{
		public buMultiTextBox buMultiTextBox_0;

		public System.Windows.Forms.Timer timer_0;

		internal void method_0()
		{
			buMultiTextBox_0.method_8(timer_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class41
	{
		public DataObject dataObject_0;

		public buMultiTextBox buMultiTextBox_0;

		internal void method_0()
		{
			buMultiTextBox_0.SetClipboard(dataObject_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class42
	{
		public DataObject dataObject_0;

		public buMultiTextBox buMultiTextBox_0;

		internal void method_0()
		{
			buMultiTextBox_0.SetClipboard(dataObject_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class43
	{
		public string string_0;

		internal void method_0()
		{
			if (Clipboard.ContainsText())
			{
				string_0 = Clipboard.GetText();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class Class44
	{
		public buMultiTextBox buMultiTextBox_0;

		public Rectangle rectangle_0;

		public System.Threading.Timer timer_0;

		internal void method_0(object object_0)
		{
			buMultiTextBox_0.Invalidate(rectangle_0);
			timer_0.Dispose();
		}
	}

	[CompilerGenerated]
	internal sealed class Class45 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		private string string_0;

		public string string_1;

		public buMultiTextBox buMultiTextBox_0;

		private Range range_1;

		internal IEnumerator<Range> ienumerator_0;

		private Range range_2;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class45(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_336(this);
				}
			}
			range_1 = null;
			ienumerator_0 = null;
			range_2 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					range_1 = new Range(buMultiTextBox_0);
					range_1.SelectAll();
					ienumerator_0 = range_1.GetRanges(string_0, RegexOptions.None).GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					range_2 = null;
				}
				if (ienumerator_0.MoveNext())
				{
					range_2 = ienumerator_0.Current;
					range_0 = range_2;
					int_0 = 1;
					return true;
				}
				Class76.smethod_336(this);
				ienumerator_0 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class45 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class45(0)
				{
					buMultiTextBox_0 = buMultiTextBox_0
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.string_0 = string_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	internal sealed class Class46 : IDisposable, IEnumerable<Range>, IEnumerable, IEnumerator<Range>, IEnumerator
	{
		internal int int_0;

		private Range range_0;

		private int int_1;

		private string string_0;

		public string string_1;

		private RegexOptions regexOptions_0;

		public RegexOptions regexOptions_1;

		public buMultiTextBox buMultiTextBox_0;

		private Range range_1;

		internal IEnumerator<Range> ienumerator_0;

		private Range range_2;

		Range IEnumerator<Range>.Current => range_0;

		object IEnumerator.Current => range_0;

		public Class46(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_604(this);
				}
			}
			range_1 = null;
			ienumerator_0 = null;
			range_2 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					range_1 = new Range(buMultiTextBox_0);
					range_1.SelectAll();
					ienumerator_0 = range_1.GetRanges(string_0, regexOptions_0).GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					range_2 = null;
				}
				if (ienumerator_0.MoveNext())
				{
					range_2 = ienumerator_0.Current;
					range_0 = range_2;
					int_0 = 1;
					return true;
				}
				Class76.smethod_604(this);
				ienumerator_0 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<Range> IEnumerable<Range>.GetEnumerator()
		{
			Class46 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class46(0)
				{
					buMultiTextBox_0 = buMultiTextBox_0
				};
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.string_0 = string_1;
			@class.regexOptions_0 = regexOptions_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Range>)this).GetEnumerator();
		}
	}

	public readonly List<LineInfo> LineInfos = new List<LineInfo>();

	private readonly Range range_0;

	private readonly System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private readonly System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

	internal readonly System.Windows.Forms.Timer timer_2 = new System.Windows.Forms.Timer();

	private readonly List<VisualMarker> list_0 = new List<VisualMarker>();

	public int TextHeight;

	public bool AllowInsertRemoveLines = true;

	private Brush brush_0;

	private BaseBookmarks baseBookmarks_0;

	private bool bool_0;

	private Color color_0;

	internal int int_0;

	private Color color_1;

	private Cursor cursor_0;

	private Range range_1;

	private string string_0;

	private int int_1 = -1;

	private Color color_2;

	protected Dictionary<int, int> foldingPairs = new Dictionary<int, int>();

	private bool bool_1;

	private bool bool_2;

	internal Hints hints_0;

	private Color color_3;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Language language_0;

	private Keys keys_0;

	private Point point_0;

	private DateTime dateTime_0;

	internal Range range_2;

	internal Range range_3;

	private int int_2;

	internal int int_3;

	private Color color_4;

	internal uint uint_0;

	private int int_4;

	internal TextSource textSource_0;

	private IntPtr intptr_0;

	internal int int_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	protected internal bool needRecalc;

	protected internal bool needRecalcWordWrap;

	internal Point point_1;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private Color color_5;

	private int int_6;

	internal Range range_4;

	internal Range range_5;

	private bool bool_13;

	private Color color_6;

	private Color color_7;

	private bool bool_14;

	private bool bool_15;

	private buMultiTextBox buMultiTextBox_0;

	private int int_7 = -1;

	private int int_8;

	private Range range_6;

	private Range range_7;

	internal bool bool_16;

	internal WordWrapMode wordWrapMode_0 = WordWrapMode.WordWrapControlWidth;

	private int int_9 = 1;

	private int int_10 = 100;

	private Size size_0;

	internal char[] char_0 = new char[10] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };

	[CompilerGenerated]
	private bool bool_17;

	[CompilerGenerated]
	private ServiceColors serviceColors_0;

	[CompilerGenerated]
	private Dictionary<int, int> dictionary_0;

	[CompilerGenerated]
	private BracketsHighlightStrategy bracketsHighlightStrategy_0;

	[CompilerGenerated]
	private bool bool_18;

	[CompilerGenerated]
	private int int_11;

	private MacrosManager macrosManager_0;

	[CompilerGenerated]
	private ToolTip toolTip_0;

	[CompilerGenerated]
	private Color color_8;

	[CompilerGenerated]
	private bool bool_19;

	[CompilerGenerated]
	private FindEndOfFoldingBlockStrategy findEndOfFoldingBlockStrategy_0;

	[CompilerGenerated]
	private bool bool_20;

	[CompilerGenerated]
	private bool bool_21;

	[CompilerGenerated]
	private bool bool_22;

	[CompilerGenerated]
	private bool bool_23;

	private Color color_9;

	private TextAreaBorderType textAreaBorderType_0;

	[CompilerGenerated]
	private int int_12;

	[CompilerGenerated]
	private int int_13;

	[CompilerGenerated]
	private int int_14;

	[CompilerGenerated]
	private bool bool_24;

	[CompilerGenerated]
	private Color color_10;

	[CompilerGenerated]
	private Color color_11;

	[CompilerGenerated]
	private bool bool_25;

	[CompilerGenerated]
	private Padding padding_0;

	[CompilerGenerated]
	private int int_15;

	[CompilerGenerated]
	private HotkeysMapping hotkeysMapping_0;

	[CompilerGenerated]
	private SelectionStyle selectionStyle_0;

	[CompilerGenerated]
	private TextStyle textStyle_0;

	[CompilerGenerated]
	private MarkerStyle markerStyle_0;

	[CompilerGenerated]
	private MarkerStyle markerStyle_1;

	[CompilerGenerated]
	private char char_1;

	[CompilerGenerated]
	private char char_2;

	[CompilerGenerated]
	private char char_3;

	[CompilerGenerated]
	private char char_4;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private HighlightingRangeType highlightingRangeType_0;

	[CompilerGenerated]
	private bool bool_26;

	[CompilerGenerated]
	private bool bool_27;

	[CompilerGenerated]
	private bool bool_28;

	[CompilerGenerated]
	private SyntaxHighlighter syntaxHighlighter_0;

	private bool bool_29;

	[CompilerGenerated]
	private FindForm findForm_0;

	[CompilerGenerated]
	private ReplaceForm replaceForm_0;

	internal Font font_0;

	[CompilerGenerated]
	private EventHandler<ToolTipNeededEventArgs> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<HintClickEventArgs> eventHandler_1;

	[CompilerGenerated]
	private EventHandler<TextChangedEventArgs> eventHandler_2;

	[CompilerGenerated]
	private EventHandler eventHandler_3;

	[CompilerGenerated]
	private EventHandler<TextChangingEventArgs> eventHandler_4;

	[CompilerGenerated]
	private EventHandler<TextChangingEventArgs> eventHandler_5;

	[CompilerGenerated]
	private EventHandler eventHandler_6;

	[CompilerGenerated]
	private EventHandler eventHandler_7;

	[CompilerGenerated]
	private EventHandler<TextChangedEventArgs> eventHandler_8;

	[CompilerGenerated]
	private EventHandler eventHandler_9;

	[CompilerGenerated]
	private EventHandler eventHandler_10;

	[CompilerGenerated]
	private EventHandler<VisualMarkerEventArgs> eventHandler_11;

	[CompilerGenerated]
	private KeyPressEventHandler keyPressEventHandler_0;

	[CompilerGenerated]
	private KeyPressEventHandler keyPressEventHandler_1;

	[CompilerGenerated]
	private EventHandler<AutoIndentEventArgs> eventHandler_12;

	[CompilerGenerated]
	private EventHandler<PaintLineEventArgs> eventHandler_13;

	[CompilerGenerated]
	internal EventHandler<LineInsertedEventArgs> eventHandler_14;

	[CompilerGenerated]
	internal EventHandler<LineRemovedEventArgs> eventHandler_15;

	[CompilerGenerated]
	private EventHandler<EventArgs> eventHandler_16;

	[CompilerGenerated]
	private EventHandler<EventArgs> eventHandler_17;

	[CompilerGenerated]
	private EventHandler eventHandler_18;

	[CompilerGenerated]
	private EventHandler<CustomActionEventArgs> eventHandler_19;

	[CompilerGenerated]
	private EventHandler eventHandler_20;

	[CompilerGenerated]
	internal EventHandler<WordWrapNeededEventArgs> eventHandler_21;

	private Dictionary<System.Windows.Forms.Timer, System.Windows.Forms.Timer> dictionary_1 = new Dictionary<System.Windows.Forms.Timer, System.Windows.Forms.Timer>();

	internal List<Control> list_1 = new List<Control>();

	private bool bool_30;

	private static Dictionary<FCTBAction, bool> dictionary_2 = new Dictionary<FCTBAction, bool>
	{
		{
			FCTBAction.ScrollDown,
			true
		},
		{
			FCTBAction.ScrollUp,
			true
		},
		{
			FCTBAction.ZoomOut,
			true
		},
		{
			FCTBAction.ZoomIn,
			true
		},
		{
			FCTBAction.ZoomNormal,
			true
		}
	};

	internal Font font_1;

	[CompilerGenerated]
	private bool bool_31;

	[CompilerGenerated]
	private string string_2;

	private Rectangle rectangle_0;

	protected Range draggedRange;

	[CompilerGenerated]
	private bool bool_32;

	private bool bool_33;

	internal Point point_2;

	private Point point_3;

	private readonly System.Windows.Forms.Timer timer_3 = new System.Windows.Forms.Timer();

	private ScrollDirection scrollDirection_0 = ScrollDirection.None;

	public char[] AutoCompleteBracketsList
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

	[DefaultValue(false)]
	[Description("AutoComplete brackets.")]
	public bool AutoCompleteBrackets
	{
		[CompilerGenerated]
		get
		{
			return bool_17;
		}
		[CompilerGenerated]
		set
		{
			bool_17 = value;
		}
	}

	[Browsable(true)]
	[Description("Colors of some service visual markers.")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public ServiceColors ServiceColors
	{
		[CompilerGenerated]
		get
		{
			return serviceColors_0;
		}
		[CompilerGenerated]
		set
		{
			serviceColors_0 = value;
		}
	}

	[Browsable(false)]
	public Dictionary<int, int> FoldedBlocks
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		private set
		{
			dictionary_0 = value;
		}
	}

	[DefaultValue(typeof(BracketsHighlightStrategy), "Strategy1")]
	[Description("Strategy of search of brackets to highlighting.")]
	public BracketsHighlightStrategy BracketsHighlightStrategy
	{
		[CompilerGenerated]
		get
		{
			return bracketsHighlightStrategy_0;
		}
		[CompilerGenerated]
		set
		{
			bracketsHighlightStrategy_0 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Automatically shifts secondary wordwrap lines on the shift amount of the first line.")]
	public bool WordWrapAutoIndent
	{
		[CompilerGenerated]
		get
		{
			return bool_18;
		}
		[CompilerGenerated]
		set
		{
			bool_18 = value;
		}
	}

	[DefaultValue(0)]
	[Description("Indent of secondary wordwrap lines (in chars).")]
	public int WordWrapIndent
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	[Browsable(false)]
	public MacrosManager MacrosManager => macrosManager_0;

	[DefaultValue(true)]
	[Description("Allows drag and drop")]
	public override bool AllowDrop
	{
		get
		{
			return base.AllowDrop;
		}
		set
		{
			base.AllowDrop = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Hints Hints
	{
		get
		{
			return hints_0;
		}
		set
		{
			hints_0 = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(500)]
	[Description("Delay(ms) of ToolTip.")]
	public int ToolTipDelay
	{
		get
		{
			return timer_2.Interval;
		}
		set
		{
			timer_2.Interval = value;
		}
	}

	[Browsable(true)]
	[Description("ToolTip component.")]
	public ToolTip ToolTip
	{
		[CompilerGenerated]
		get
		{
			return toolTip_0;
		}
		[CompilerGenerated]
		set
		{
			toolTip_0 = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(typeof(Color), "PowderBlue")]
	[Description("Color of bookmarks.")]
	public Color BookmarkColor
	{
		[CompilerGenerated]
		get
		{
			return color_8;
		}
		[CompilerGenerated]
		set
		{
			color_8 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public BaseBookmarks Bookmarks
	{
		get
		{
			return baseBookmarks_0;
		}
		set
		{
			baseBookmarks_0 = value;
		}
	}

	[DefaultValue(false)]
	[Description("Enables virtual spaces.")]
	public bool VirtualSpace
	{
		[CompilerGenerated]
		get
		{
			return bool_19;
		}
		[CompilerGenerated]
		set
		{
			bool_19 = value;
		}
	}

	[DefaultValue(FindEndOfFoldingBlockStrategy.Strategy1)]
	[Description("Strategy of search of end of folding block.")]
	public FindEndOfFoldingBlockStrategy FindEndOfFoldingBlockStrategy
	{
		[CompilerGenerated]
		get
		{
			return findEndOfFoldingBlockStrategy_0;
		}
		[CompilerGenerated]
		set
		{
			findEndOfFoldingBlockStrategy_0 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Indicates if tab characters are accepted as input.")]
	public bool AcceptsTab
	{
		[CompilerGenerated]
		get
		{
			return bool_20;
		}
		[CompilerGenerated]
		set
		{
			bool_20 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Indicates if return characters are accepted as input.")]
	public bool AcceptsReturn
	{
		[CompilerGenerated]
		get
		{
			return bool_21;
		}
		[CompilerGenerated]
		set
		{
			bool_21 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Shows or hides the caret")]
	public bool CaretVisible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[Description("Enables caret blinking")]
	public bool CaretBlinking
	{
		[CompilerGenerated]
		get
		{
			return bool_22;
		}
		[CompilerGenerated]
		set
		{
			bool_22 = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowCaretWhenInactive
	{
		[CompilerGenerated]
		get
		{
			return bool_23;
		}
		[CompilerGenerated]
		set
		{
			bool_23 = value;
		}
	}

	[DefaultValue(typeof(Color), "Black")]
	[Description("Color of border of text area")]
	public Color TextAreaBorderColor
	{
		get
		{
			return color_9;
		}
		set
		{
			color_9 = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(TextAreaBorderType), "None")]
	[Description("Type of border of text area")]
	public TextAreaBorderType TextAreaBorder
	{
		get
		{
			return textAreaBorderType_0;
		}
		set
		{
			textAreaBorderType_0 = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Description("Background color for current line. Set to Color.Transparent to hide current line highlighting")]
	public Color CurrentLineColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Description("Background color for highlighting of changed lines. Set to Color.Transparent to hide changed line highlighting")]
	public Color ChangedLineColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Invalidate();
		}
	}

	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
			textSource_0.InitDefaultStyle();
			Invalidate();
		}
	}

	[Browsable(false)]
	public int CharHeight
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			NeedRecalc();
			OnCharSizeChanged();
		}
	}

	[Description("Interval between lines in pixels")]
	[DefaultValue(0)]
	public int LineInterval
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
			Class76.smethod_149(this, Font);
			Invalidate();
		}
	}

	[Browsable(false)]
	public int CharWidth
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	[DefaultValue(4)]
	[Description("Spaces count for tab")]
	public int TabLength
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsChanged
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (!value)
			{
				textSource_0.ClearIsChanged();
			}
			bool_3 = value;
		}
	}

	[Browsable(false)]
	public int TextVersion
	{
		[CompilerGenerated]
		get
		{
			return int_14;
		}
		[CompilerGenerated]
		private set
		{
			int_14 = value;
		}
	}

	[DefaultValue(false)]
	public bool ReadOnly
	{
		[CompilerGenerated]
		get
		{
			return bool_24;
		}
		[CompilerGenerated]
		set
		{
			bool_24 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Shows line numbers.")]
	public bool ShowLineNumbers
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
			NeedRecalc();
			Invalidate();
		}
	}

	[DefaultValue(false)]
	[Description("Shows vertical lines between folding start line and folding end line.")]
	public bool ShowFoldingLines
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public Rectangle TextAreaRect
	{
		get
		{
			int val = LeftIndent + int_5 * CharWidth + Paddings.Left + 1;
			val = Math.Max(base.ClientSize.Width - Paddings.Right, val);
			int val2 = TextHeight + Paddings.Top;
			val2 = Math.Max(base.ClientSize.Height - Paddings.Bottom, val2);
			int top = Math.Max(0, Paddings.Top - 1) - base.VerticalScroll.Value;
			int left = LeftIndent - base.HorizontalScroll.Value - 2 + Math.Max(0, Paddings.Left - 1);
			return Rectangle.FromLTRB(left, top, val - base.HorizontalScroll.Value, val2 - base.VerticalScroll.Value);
		}
	}

	[DefaultValue(typeof(Color), "Teal")]
	[Description("Color of line numbers.")]
	public Color LineNumberColor
	{
		get
		{
			return color_4;
		}
		set
		{
			color_4 = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(uint), "1")]
	[Description("Start value of first line number.")]
	public uint LineNumberStartValue
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
			needRecalc = true;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "WhiteSmoke")]
	[Description("Background color of indent area")]
	public Color IndentBackColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Description("Background color of padding area")]
	public Color PaddingBackColor
	{
		get
		{
			return color_5;
		}
		set
		{
			color_5 = value;
			Invalidate();
		}
	}

	[DefaultValue(typeof(Color), "100;180;180;180")]
	[Description("Color of disabled component")]
	public Color DisabledColor
	{
		[CompilerGenerated]
		get
		{
			return color_10;
		}
		[CompilerGenerated]
		set
		{
			color_10 = value;
		}
	}

	[DefaultValue(typeof(Color), "Black")]
	[Description("Color of caret.")]
	public Color CaretColor
	{
		[CompilerGenerated]
		get
		{
			return color_11;
		}
		[CompilerGenerated]
		set
		{
			color_11 = value;
		}
	}

	[DefaultValue(false)]
	[Description("Wide caret.")]
	public bool WideCaret
	{
		[CompilerGenerated]
		get
		{
			return bool_25;
		}
		[CompilerGenerated]
		set
		{
			bool_25 = value;
		}
	}

	[DefaultValue(typeof(Color), "Silver")]
	[Description("Color of service lines (folding lines, borders of blocks etc.)")]
	public Color ServiceLinesColor
	{
		get
		{
			return color_7;
		}
		set
		{
			color_7 = value;
			Invalidate();
		}
	}

	[Browsable(true)]
	[Description("Paddings of text area.")]
	public Padding Paddings
	{
		[CompilerGenerated]
		get
		{
			return padding_0;
		}
		[CompilerGenerated]
		set
		{
			padding_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Padding Padding
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new bool RightToLeft
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[DefaultValue(typeof(Color), "Green")]
	[Description("Color of folding area indicator.")]
	public Color FoldingIndicatorColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			Invalidate();
		}
	}

	[DefaultValue(true)]
	[Description("Enables folding indicator (left vertical line between folding bounds)")]
	public bool HighlightFoldingIndicator
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[Description("Left distance to text beginning.")]
	public int LeftIndent
	{
		[CompilerGenerated]
		get
		{
			return int_15;
		}
		[CompilerGenerated]
		internal set
		{
			int_15 = value;
		}
	}

	[DefaultValue(0)]
	[Description("Width of left service area (in pixels)")]
	public int LeftPadding
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[Description("This property draws vertical line after defined char position. Set to 0 for disable drawing of vertical line.")]
	public int PreferredLineWidth
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public Style[] Styles => textSource_0.Styles;

	[Description("Here you can change hotkeys for FastColoredTextBox.")]
	[Editor(typeof(Class58), typeof(UITypeEditor))]
	[DefaultValue("Tab=IndentIncrease, Escape=ClearHints, PgUp=GoPageUp, PgDn=GoPageDown, End=GoEnd, Home=GoHome, Left=GoLeft, Up=GoUp, Right=GoRight, Down=GoDown, Ins=ReplaceMode, Del=DeleteCharRight, F3=FindNext, Shift+Tab=IndentDecrease, Shift+PgUp=GoPageUpWithSelection, Shift+PgDn=GoPageDownWithSelection, Shift+End=GoEndWithSelection, Shift+Home=GoHomeWithSelection, Shift+Left=GoLeftWithSelection, Shift+Up=GoUpWithSelection, Shift+Right=GoRightWithSelection, Shift+Down=GoDownWithSelection, Shift+Ins=Paste, Shift+Del=Cut, Ctrl+Back=ClearWordLeft, Ctrl+Space=AutocompleteMenu, Ctrl+End=GoLastLine, Ctrl+Home=GoFirstLine, Ctrl+Left=GoWordLeft, Ctrl+Up=ScrollUp, Ctrl+Right=GoWordRight, Ctrl+Down=ScrollDown, Ctrl+Ins=Copy, Ctrl+Del=ClearWordRight, Ctrl+0=ZoomNormal, Ctrl+A=SelectAll, Ctrl+B=BookmarkLine, Ctrl+C=Copy, Ctrl+E=MacroExecute, Ctrl+F=FindDialog, Ctrl+G=GoToDialog, Ctrl+H=ReplaceDialog, Ctrl+I=AutoIndentChars, Ctrl+M=MacroRecord, Ctrl+N=GoNextBookmark, Ctrl+R=Redo, Ctrl+U=UpperCase, Ctrl+V=Paste, Ctrl+X=Cut, Ctrl+Z=Undo, Ctrl+Add=ZoomIn, Ctrl+Subtract=ZoomOut, Ctrl+OemMinus=NavigateBackward, Ctrl+Shift+End=GoLastLineWithSelection, Ctrl+Shift+Home=GoFirstLineWithSelection, Ctrl+Shift+Left=GoWordLeftWithSelection, Ctrl+Shift+Right=GoWordRightWithSelection, Ctrl+Shift+B=UnbookmarkLine, Ctrl+Shift+C=CommentSelected, Ctrl+Shift+N=GoPrevBookmark, Ctrl+Shift+U=LowerCase, Ctrl+Shift+OemMinus=NavigateForward, Alt+Back=Undo, Alt+Up=MoveSelectedLinesUp, Alt+Down=MoveSelectedLinesDown, Alt+F=FindChar, Alt+Shift+Left=GoLeft_ColumnSelectionMode, Alt+Shift+Up=GoUp_ColumnSelectionMode, Alt+Shift+Right=GoRight_ColumnSelectionMode, Alt+Shift+Down=GoDown_ColumnSelectionMode")]
	public string Hotkeys
	{
		get
		{
			return HotkeysMapping.ToString();
		}
		set
		{
			HotkeysMapping = HotkeysMapping.Parse(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HotkeysMapping HotkeysMapping
	{
		[CompilerGenerated]
		get
		{
			return hotkeysMapping_0;
		}
		[CompilerGenerated]
		set
		{
			hotkeysMapping_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TextStyle DefaultStyle
	{
		get
		{
			return textSource_0.DefaultStyle;
		}
		set
		{
			textSource_0.DefaultStyle = value;
		}
	}

	[Browsable(false)]
	public SelectionStyle SelectionStyle
	{
		[CompilerGenerated]
		get
		{
			return selectionStyle_0;
		}
		[CompilerGenerated]
		set
		{
			selectionStyle_0 = value;
		}
	}

	[Browsable(false)]
	public TextStyle FoldedBlockStyle
	{
		[CompilerGenerated]
		get
		{
			return textStyle_0;
		}
		[CompilerGenerated]
		set
		{
			textStyle_0 = value;
		}
	}

	[Browsable(false)]
	public MarkerStyle BracketsStyle
	{
		[CompilerGenerated]
		get
		{
			return markerStyle_0;
		}
		[CompilerGenerated]
		set
		{
			markerStyle_0 = value;
		}
	}

	[Browsable(false)]
	public MarkerStyle BracketsStyle2
	{
		[CompilerGenerated]
		get
		{
			return markerStyle_1;
		}
		[CompilerGenerated]
		set
		{
			markerStyle_1 = value;
		}
	}

	[DefaultValue('\0')]
	[Description("Opening bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char LeftBracket
	{
		[CompilerGenerated]
		get
		{
			return char_1;
		}
		[CompilerGenerated]
		set
		{
			char_1 = value;
		}
	}

	[DefaultValue('\0')]
	[Description("Closing bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char RightBracket
	{
		[CompilerGenerated]
		get
		{
			return char_2;
		}
		[CompilerGenerated]
		set
		{
			char_2 = value;
		}
	}

	[DefaultValue('\0')]
	[Description("Alternative opening bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char LeftBracket2
	{
		[CompilerGenerated]
		get
		{
			return char_3;
		}
		[CompilerGenerated]
		set
		{
			char_3 = value;
		}
	}

	[DefaultValue('\0')]
	[Description("Alternative closing bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
	public char RightBracket2
	{
		[CompilerGenerated]
		get
		{
			return char_4;
		}
		[CompilerGenerated]
		set
		{
			char_4 = value;
		}
	}

	[DefaultValue("//")]
	[Description("Comment line prefix.")]
	public string CommentPrefix
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	[DefaultValue(typeof(HighlightingRangeType), "ChangedRange")]
	[Description("This property specifies which part of the text will be highlighted as you type.")]
	public HighlightingRangeType HighlightingRangeType
	{
		[CompilerGenerated]
		get
		{
			return highlightingRangeType_0;
		}
		[CompilerGenerated]
		set
		{
			highlightingRangeType_0 = value;
		}
	}

	[Browsable(false)]
	public bool IsReplaceMode
	{
		get
		{
			return bool_5 && Selection.IsEmpty && !Selection.ColumnSelectionMode && Selection.Start.iChar < textSource_0[Selection.Start.iLine].Count;
		}
		set
		{
			bool_5 = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[Description("Allows text rendering several styles same time.")]
	public bool AllowSeveralTextStyleDrawing
	{
		[CompilerGenerated]
		get
		{
			return bool_26;
		}
		[CompilerGenerated]
		set
		{
			bool_26 = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(true)]
	[Description("Allows to record macros.")]
	public bool AllowMacroRecording
	{
		get
		{
			return macrosManager_0.AllowMacroRecordingByUser;
		}
		set
		{
			macrosManager_0.AllowMacroRecordingByUser = value;
		}
	}

	[DefaultValue(true)]
	[Description("Allows auto indent. Inserts spaces before line chars.")]
	public bool AutoIndent
	{
		[CompilerGenerated]
		get
		{
			return bool_27;
		}
		[CompilerGenerated]
		set
		{
			bool_27 = value;
		}
	}

	[DefaultValue(true)]
	[Description("Does autoindenting in existing lines. It works only if AutoIndent is True.")]
	public bool AutoIndentExistingLines
	{
		[CompilerGenerated]
		get
		{
			return bool_28;
		}
		[CompilerGenerated]
		set
		{
			bool_28 = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(100)]
	[Description("Minimal delay(ms) for delayed events (except TextChangedDelayed).")]
	public int DelayedEventsInterval
	{
		get
		{
			return timer_0.Interval;
		}
		set
		{
			timer_0.Interval = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(100)]
	[Description("Minimal delay(ms) for TextChangedDelayed event.")]
	public int DelayedTextChangedInterval
	{
		get
		{
			return timer_1.Interval;
		}
		set
		{
			timer_1.Interval = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(typeof(Language), "Custom")]
	[Description("Language for highlighting by built-in highlighter.")]
	public Language Language
	{
		get
		{
			return language_0;
		}
		set
		{
			language_0 = value;
			if (SyntaxHighlighter != null)
			{
				SyntaxHighlighter.InitStyleSchema(language_0);
			}
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SyntaxHighlighter SyntaxHighlighter
	{
		[CompilerGenerated]
		get
		{
			return syntaxHighlighter_0;
		}
		[CompilerGenerated]
		set
		{
			syntaxHighlighter_0 = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(null)]
	[Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
	[Description("XML file with description of syntax highlighting. This property works only with Language == Language.Custom.")]
	public string DescriptionFile
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range LeftBracketPosition => range_2;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range RightBracketPosition => range_4;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range LeftBracketPosition2 => range_3;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Range RightBracketPosition2 => range_5;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int StartFoldingLine => int_7;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int EndFoldingLine => int_1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TextSource TextSource
	{
		get
		{
			return textSource_0;
		}
		set
		{
			InitTextSource(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool HasSourceTextBox => SourceTextBox != null;

	[Browsable(true)]
	[DefaultValue(null)]
	[Description("Allows to get text from other FastColoredTextBox.")]
	public buMultiTextBox SourceTextBox
	{
		get
		{
			return buMultiTextBox_0;
		}
		set
		{
			if (value != buMultiTextBox_0)
			{
				buMultiTextBox_0 = value;
				if (buMultiTextBox_0 != null)
				{
					InitTextSource(SourceTextBox.TextSource);
					bool_3 = false;
				}
				else
				{
					InitTextSource(CreateTextSource());
					textSource_0.InsertLine(0, TextSource.CreateLine());
					IsChanged = false;
				}
				Invalidate();
			}
		}
	}

	[Browsable(false)]
	public Range VisibleRange
	{
		get
		{
			if (range_7 == null)
			{
				return GetRange(PointToPlace(new Point(LeftIndent, 0)), PointToPlace(new Point(base.ClientSize.Width, base.ClientSize.Height)));
			}
			return range_7;
		}
	}

	[Browsable(false)]
	public Range Selection
	{
		get
		{
			return range_0;
		}
		set
		{
			if (value != range_0)
			{
				range_0.BeginUpdate();
				range_0.Start = value.Start;
				range_0.End = value.End;
				range_0.EndUpdate();
				Invalidate();
			}
		}
	}

	[DefaultValue(typeof(Color), "White")]
	[Description("Background color.")]
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
	public Brush BackBrush
	{
		get
		{
			return brush_0;
		}
		set
		{
			brush_0 = value;
			Invalidate();
		}
	}

	[Browsable(true)]
	[DefaultValue(true)]
	[Description("Scollbars visibility.")]
	public bool ShowScrollBars
	{
		get
		{
			return bool_13;
		}
		set
		{
			if (value != bool_13)
			{
				bool_13 = value;
				needRecalc = true;
				Invalidate();
			}
		}
	}

	[Browsable(true)]
	[DefaultValue(true)]
	[Description("Multiline mode.")]
	public bool Multiline
	{
		get
		{
			return bool_8;
		}
		set
		{
			if (bool_8 == value)
			{
				return;
			}
			bool_8 = value;
			needRecalc = true;
			if (!bool_8)
			{
				base.AutoScroll = false;
				ShowScrollBars = false;
				if (textSource_0.Count > 1)
				{
					textSource_0.RemoveLine(1, textSource_0.Count - 1);
				}
				Class76.smethod_89(textSource_0.Manager);
			}
			else
			{
				base.AutoScroll = true;
				ShowScrollBars = true;
			}
			Invalidate();
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[Description("WordWrap.")]
	public bool WordWrap
	{
		get
		{
			return bool_16;
		}
		set
		{
			if (bool_16 != value)
			{
				bool_16 = value;
				if (bool_16)
				{
					Selection.ColumnSelectionMode = false;
				}
				NeedRecalc(forced: false, wordWrapRecalc: true);
				Invalidate();
			}
		}
	}

	[Browsable(true)]
	[DefaultValue(typeof(WordWrapMode), "WordWrapControlWidth")]
	[Description("WordWrap mode.")]
	public WordWrapMode WordWrapMode
	{
		get
		{
			return wordWrapMode_0;
		}
		set
		{
			if (wordWrapMode_0 != value)
			{
				wordWrapMode_0 = value;
				NeedRecalc(forced: false, wordWrapRecalc: true);
				Invalidate();
			}
		}
	}

	[DefaultValue(true)]
	[Description("If enabled then line ends included into the selection will be selected too. Then line ends will be shown as selected blank character.")]
	public bool SelectionHighlightingForLineBreaksEnabled
	{
		get
		{
			return bool_29;
		}
		set
		{
			bool_29 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public FindForm findForm
	{
		[CompilerGenerated]
		get
		{
			return findForm_0;
		}
		[CompilerGenerated]
		private set
		{
			findForm_0 = value;
		}
	}

	[Browsable(false)]
	public ReplaceForm replaceForm
	{
		[CompilerGenerated]
		get
		{
			return replaceForm_0;
		}
		[CompilerGenerated]
		private set
		{
			replaceForm_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool AutoScroll
	{
		get
		{
			return base.AutoScroll;
		}
		set
		{
		}
	}

	[Browsable(false)]
	public int LinesCount => textSource_0.Count;

	public Char this[Place place]
	{
		get
		{
			return textSource_0[place.iLine][place.iChar];
		}
		set
		{
			textSource_0[place.iLine][place.iChar] = value;
		}
	}

	public Line this[int iLine] => textSource_0[iLine];

	[Browsable(true)]
	[Localizable(true)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[SettingsBindable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Description("Text of the control.")]
	[Bindable(true)]
	public override string Text
	{
		get
		{
			if (LinesCount != 0)
			{
				Range range = new Range(this);
				range.SelectAll();
				return range.Text;
			}
			return "";
		}
		set
		{
			if (!(value == Text) || !(value != ""))
			{
				Class76.smethod_298(this);
				Selection.ColumnSelectionMode = false;
				Selection.BeginUpdate();
				try
				{
					Selection.SelectAll();
					InsertText(value);
					GoHome();
				}
				finally
				{
					Selection.EndUpdate();
				}
			}
		}
	}

	public int TextLength
	{
		get
		{
			if (LinesCount != 0)
			{
				Range range = new Range(this);
				range.SelectAll();
				return range.Length;
			}
			return 0;
		}
	}

	[Browsable(false)]
	public IList<string> Lines => textSource_0.GetLines();

	[Browsable(false)]
	public string Html
	{
		get
		{
			ExportToHTML exportToHTML = new ExportToHTML();
			exportToHTML.UseNbsp = false;
			exportToHTML.UseStyleTag = false;
			exportToHTML.UseBr = false;
			return "<pre>" + exportToHTML.GetHtml(this) + "</pre>";
		}
	}

	[Browsable(false)]
	public string Rtf
	{
		get
		{
			ExportToRTF exportToRTF = new ExportToRTF();
			return exportToRTF.GetRtf(this);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return Selection.Text;
		}
		set
		{
			InsertText(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return Math.Min(PlaceToPosition(Selection.Start), PlaceToPosition(Selection.End));
		}
		set
		{
			Selection.Start = PositionToPlace(value);
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	public int SelectionLength
	{
		get
		{
			return Selection.Length;
		}
		set
		{
			if (value > 0)
			{
				Selection.End = PositionToPlace(SelectionStart + value);
			}
		}
	}

	[DefaultValue(typeof(Font), "Courier New, 9.75")]
	public override Font Font
	{
		get
		{
			return Class76.smethod_559(this);
		}
		set
		{
			font_1 = (Font)value.Clone();
			Class76.smethod_149(this, value);
		}
	}

	public new Size AutoScrollMinSize
	{
		get
		{
			if (!bool_13)
			{
				return size_0;
			}
			return base.AutoScrollMinSize;
		}
		set
		{
			if (!bool_13)
			{
				if (base.AutoScroll)
				{
					base.AutoScroll = false;
				}
				base.AutoScrollMinSize = new Size(0, 0);
				base.VerticalScroll.Visible = false;
				base.HorizontalScroll.Visible = false;
				base.VerticalScroll.Maximum = Math.Max(0, value.Height - base.ClientSize.Height);
				base.HorizontalScroll.Maximum = Math.Max(0, value.Width - base.ClientSize.Width);
				size_0 = value;
			}
			else
			{
				if (!base.AutoScroll)
				{
					base.AutoScroll = true;
				}
				Size autoScrollMinSize = value;
				if (WordWrap && WordWrapMode != WordWrapMode.Custom)
				{
					int val = Class76.smethod_297(this);
					autoScrollMinSize = new Size(Math.Min(autoScrollMinSize.Width, val), autoScrollMinSize.Height);
				}
				base.AutoScrollMinSize = autoScrollMinSize;
			}
		}
	}

	[Browsable(false)]
	public bool ImeAllowed => base.ImeMode != ImeMode.Disable && base.ImeMode != ImeMode.Off && base.ImeMode != ImeMode.NoControl;

	[Browsable(false)]
	public bool UndoEnabled => textSource_0.Manager.UndoEnabled;

	[Browsable(false)]
	public bool RedoEnabled => textSource_0.Manager.RedoEnabled;

	[Browsable(false)]
	public Range Range => new Range(this, new Place(0, 0), new Place(textSource_0[textSource_0.Count - 1].Count, textSource_0.Count - 1));

	[DefaultValue(typeof(Color), "Blue")]
	[Description("Color of selected area.")]
	public virtual Color SelectionColor
	{
		get
		{
			return color_6;
		}
		set
		{
			color_6 = value;
			if (color_6.A == byte.MaxValue)
			{
				color_6 = Color.FromArgb(60, color_6);
			}
			SelectionStyle = new SelectionStyle(new SolidBrush(color_6));
			Invalidate();
		}
	}

	public override Cursor Cursor
	{
		get
		{
			return base.Cursor;
		}
		set
		{
			cursor_0 = value;
			base.Cursor = value;
		}
	}

	[DefaultValue(1)]
	[Description("Reserved space for line number characters. If smaller than needed (e. g. line count >= 10 and this value set to 1) this value will have no impact. If you want to reserve space, e. g. for line numbers >= 10 or >= 100, than you can set this value to 2 or 3 or higher.")]
	public int ReservedCountOfLineNumberChars
	{
		get
		{
			return int_9;
		}
		set
		{
			int_9 = value;
			NeedRecalc();
			Invalidate();
		}
	}

	[Description("Enables AutoIndentChars mode")]
	[DefaultValue(true)]
	public bool AutoIndentChars
	{
		[CompilerGenerated]
		get
		{
			return bool_31;
		}
		[CompilerGenerated]
		set
		{
			bool_31 = value;
		}
	}

	[Description("Regex patterns for AutoIndentChars (one regex per line)")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);")]
	public string AutoIndentCharsPatterns
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	[Browsable(false)]
	public int Zoom
	{
		get
		{
			return int_10;
		}
		set
		{
			int_10 = value;
			Class76.smethod_72(this, (float)int_10 / 100f);
			OnZoomChanged();
		}
	}

	[Browsable(true)]
	[Description("Occurs when mouse is moving over text and tooltip is needed.")]
	public event EventHandler<ToolTipNeededEventArgs> ToolTipNeeded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ToolTipNeededEventArgs> eventHandler = eventHandler_0;
			EventHandler<ToolTipNeededEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ToolTipNeededEventArgs> value2 = (EventHandler<ToolTipNeededEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ToolTipNeededEventArgs> eventHandler = eventHandler_0;
			EventHandler<ToolTipNeededEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ToolTipNeededEventArgs> value2 = (EventHandler<ToolTipNeededEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs if user click on the hint.")]
	public event EventHandler<HintClickEventArgs> HintClick
	{
		[CompilerGenerated]
		add
		{
			EventHandler<HintClickEventArgs> eventHandler = eventHandler_1;
			EventHandler<HintClickEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<HintClickEventArgs> value2 = (EventHandler<HintClickEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<HintClickEventArgs> eventHandler = eventHandler_1;
			EventHandler<HintClickEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<HintClickEventArgs> value2 = (EventHandler<HintClickEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs after insert, delete, clear, undo and redo operations.")]
	public new event EventHandler<TextChangedEventArgs> TextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_2;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_2;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Description("Occurs when user paste text from clipboard")]
	public event EventHandler<TextChangingEventArgs> Pasting
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangingEventArgs> eventHandler = eventHandler_4;
			EventHandler<TextChangingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangingEventArgs> value2 = (EventHandler<TextChangingEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangingEventArgs> eventHandler = eventHandler_4;
			EventHandler<TextChangingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangingEventArgs> value2 = (EventHandler<TextChangingEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs before insert, delete, clear, undo and redo operations.")]
	public event EventHandler<TextChangingEventArgs> TextChanging
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangingEventArgs> eventHandler = eventHandler_5;
			EventHandler<TextChangingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangingEventArgs> value2 = (EventHandler<TextChangingEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangingEventArgs> eventHandler = eventHandler_5;
			EventHandler<TextChangingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangingEventArgs> value2 = (EventHandler<TextChangingEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs after changing of selection.")]
	public event EventHandler SelectionChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs after changing of visible range.")]
	public event EventHandler VisibleRangeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs after insert, delete, clear, undo and redo operations. This event occurs with a delay relative to TextChanged, and fires only once.")]
	public event EventHandler<TextChangedEventArgs> TextChangedDelayed
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_8;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_8;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs after changing of selection. This event occurs with a delay relative to SelectionChanged, and fires only once.")]
	public event EventHandler SelectionChangedDelayed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_9;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_9;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs after changing of visible range. This event occurs with a delay relative to VisibleRangeChanged, and fires only once.")]
	public event EventHandler VisibleRangeChangedDelayed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_10;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_10, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_10;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_10, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs when user click on VisualMarker.")]
	public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick
	{
		[CompilerGenerated]
		add
		{
			EventHandler<VisualMarkerEventArgs> eventHandler = eventHandler_11;
			EventHandler<VisualMarkerEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VisualMarkerEventArgs> value2 = (EventHandler<VisualMarkerEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_11, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<VisualMarkerEventArgs> eventHandler = eventHandler_11;
			EventHandler<VisualMarkerEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<VisualMarkerEventArgs> value2 = (EventHandler<VisualMarkerEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_11, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs when visible char is enetering (alphabetic, digit, punctuation, DEL, BACKSPACE).")]
	public event KeyPressEventHandler KeyPressing
	{
		[CompilerGenerated]
		add
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_0;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Combine(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_0, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_0;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Remove(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_0, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs when visible char is enetered (alphabetic, digit, punctuation, DEL, BACKSPACE).")]
	public event KeyPressEventHandler KeyPressed
	{
		[CompilerGenerated]
		add
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_1;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Combine(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_1, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_1;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Remove(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_1, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs when calculates AutoIndent for new line.")]
	public event EventHandler<AutoIndentEventArgs> AutoIndentNeeded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<AutoIndentEventArgs> eventHandler = eventHandler_12;
			EventHandler<AutoIndentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<AutoIndentEventArgs> value2 = (EventHandler<AutoIndentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_12, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<AutoIndentEventArgs> eventHandler = eventHandler_12;
			EventHandler<AutoIndentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<AutoIndentEventArgs> value2 = (EventHandler<AutoIndentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_12, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("It occurs when line background is painting.")]
	public event EventHandler<PaintLineEventArgs> PaintLine
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PaintLineEventArgs> eventHandler = eventHandler_13;
			EventHandler<PaintLineEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PaintLineEventArgs> value2 = (EventHandler<PaintLineEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_13, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PaintLineEventArgs> eventHandler = eventHandler_13;
			EventHandler<PaintLineEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PaintLineEventArgs> value2 = (EventHandler<PaintLineEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_13, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when line was inserted/added.")]
	public event EventHandler<LineInsertedEventArgs> LineInserted
	{
		[CompilerGenerated]
		add
		{
			EventHandler<LineInsertedEventArgs> eventHandler = eventHandler_14;
			EventHandler<LineInsertedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineInsertedEventArgs> value2 = (EventHandler<LineInsertedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_14, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<LineInsertedEventArgs> eventHandler = eventHandler_14;
			EventHandler<LineInsertedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineInsertedEventArgs> value2 = (EventHandler<LineInsertedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_14, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when line was removed.")]
	public event EventHandler<LineRemovedEventArgs> LineRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<LineRemovedEventArgs> eventHandler = eventHandler_15;
			EventHandler<LineRemovedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineRemovedEventArgs> value2 = (EventHandler<LineRemovedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_15, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<LineRemovedEventArgs> eventHandler = eventHandler_15;
			EventHandler<LineRemovedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineRemovedEventArgs> value2 = (EventHandler<LineRemovedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_15, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when current highlighted folding area is changed.")]
	public event EventHandler<EventArgs> FoldingHighlightChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = eventHandler_16;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_16, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = eventHandler_16;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_16, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when undo/redo stack is changed.")]
	public event EventHandler<EventArgs> UndoRedoStateChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = eventHandler_17;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_17, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = eventHandler_17;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_17, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when component was zoomed.")]
	public event EventHandler ZoomChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_18;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_18, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_18;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_18, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when user pressed key, that specified as CustomAction.")]
	public event EventHandler<CustomActionEventArgs> CustomAction
	{
		[CompilerGenerated]
		add
		{
			EventHandler<CustomActionEventArgs> eventHandler = eventHandler_19;
			EventHandler<CustomActionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<CustomActionEventArgs> value2 = (EventHandler<CustomActionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_19, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<CustomActionEventArgs> eventHandler = eventHandler_19;
			EventHandler<CustomActionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<CustomActionEventArgs> value2 = (EventHandler<CustomActionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_19, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when scroolbars are updated.")]
	public event EventHandler ScrollbarsUpdated
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_20;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_20, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_20;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_20, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Browsable(true)]
	[Description("Occurs when custom wordwrap is needed.")]
	public event EventHandler<WordWrapNeededEventArgs> WordWrapNeeded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<WordWrapNeededEventArgs> eventHandler = eventHandler_21;
			EventHandler<WordWrapNeededEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<WordWrapNeededEventArgs> value2 = (EventHandler<WordWrapNeededEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_21, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<WordWrapNeededEventArgs> eventHandler = eventHandler_21;
			EventHandler<WordWrapNeededEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<WordWrapNeededEventArgs> value2 = (EventHandler<WordWrapNeededEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_21, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public buMultiTextBox()
	{
		TypeDescriptionProvider provider = TypeDescriptor.GetProvider(GetType());
		object value = provider.GetType().GetField("Provider", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(provider);
		if (value.GetType() != typeof(Class62))
		{
			TypeDescriptor.AddProvider(new Class62(GetType()), GetType());
		}
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		Font = new Font(FontFamily.GenericMonospace, 9.75f);
		InitTextSource(CreateTextSource());
		if (textSource_0.Count == 0)
		{
			textSource_0.InsertLine(0, textSource_0.CreateLine());
		}
		range_0 = new Range(this)
		{
			Start = new Place(0, 0)
		};
		Cursor = Cursors.IBeam;
		BackColor = Color.White;
		LineNumberColor = Color.Teal;
		IndentBackColor = Color.WhiteSmoke;
		ServiceLinesColor = Color.Silver;
		FoldingIndicatorColor = Color.Green;
		CurrentLineColor = Color.Transparent;
		ChangedLineColor = Color.Transparent;
		HighlightFoldingIndicator = true;
		ShowLineNumbers = true;
		TabLength = 4;
		FoldedBlockStyle = new FoldedBlockStyle(Brushes.Gray, null, FontStyle.Regular);
		SelectionColor = Color.Blue;
		BracketsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(80, Color.Lime)));
		BracketsStyle2 = new MarkerStyle(new SolidBrush(Color.FromArgb(60, Color.Red)));
		DelayedEventsInterval = 100;
		DelayedTextChangedInterval = 100;
		AllowSeveralTextStyleDrawing = false;
		LeftBracket = '\0';
		RightBracket = '\0';
		LeftBracket2 = '\0';
		RightBracket2 = '\0';
		SyntaxHighlighter = new SyntaxHighlighter(this);
		language_0 = Language.Custom;
		PreferredLineWidth = 0;
		needRecalc = true;
		dateTime_0 = DateTime.Now;
		AutoIndent = true;
		AutoIndentExistingLines = true;
		CommentPrefix = "//";
		uint_0 = 1u;
		bool_8 = true;
		bool_13 = true;
		AcceptsTab = true;
		AcceptsReturn = true;
		bool_0 = true;
		CaretColor = Color.Black;
		WideCaret = false;
		Paddings = new Padding(0, 0, 0, 0);
		PaddingBackColor = Color.Transparent;
		DisabledColor = Color.FromArgb(100, 180, 180, 180);
		bool_9 = true;
		AllowDrop = true;
		FindEndOfFoldingBlockStrategy = FindEndOfFoldingBlockStrategy.Strategy1;
		VirtualSpace = false;
		baseBookmarks_0 = new Bookmarks(this);
		BookmarkColor = Color.PowderBlue;
		ToolTip = new ToolTip();
		timer_2.Interval = 500;
		hints_0 = new Hints(this);
		SelectionHighlightingForLineBreaksEnabled = true;
		textAreaBorderType_0 = TextAreaBorderType.None;
		color_9 = Color.Black;
		macrosManager_0 = new MacrosManager(this);
		HotkeysMapping = new HotkeysMapping();
		HotkeysMapping.InitDefault();
		WordWrapAutoIndent = true;
		FoldedBlocks = new Dictionary<int, int>();
		AutoCompleteBrackets = false;
		AutoIndentCharsPatterns = "^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);";
		AutoIndentChars = true;
		CaretBlinking = true;
		ServiceColors = new ServiceColors();
		base.AutoScroll = true;
		timer_0.Tick += timer_0_Tick;
		timer_1.Tick += timer_1_Tick;
		timer_2.Tick += timer_2_Tick;
		timer_3.Tick += timer_3_Tick;
	}

	public void ClearHints()
	{
		if (Hints != null)
		{
			Hints.Clear();
		}
	}

	public virtual Hint AddHint(Range range, Control innerControl, bool scrollToHint, bool inline, bool dock)
	{
		Hint hint = new Hint(range, innerControl, inline, dock);
		Hints.Add(hint);
		if (scrollToHint)
		{
			hint.DoVisible();
		}
		return hint;
	}

	public Hint AddHint(Range range, Control innerControl)
	{
		return AddHint(range, innerControl, scrollToHint: true, inline: true, dock: true);
	}

	public virtual Hint AddHint(Range range, string text, bool scrollToHint, bool inline, bool dock)
	{
		Hint hint = new Hint(range, text, inline, dock);
		Hints.Add(hint);
		if (scrollToHint)
		{
			hint.DoVisible();
		}
		return hint;
	}

	public Hint AddHint(Range range, string text)
	{
		return AddHint(range, text, scrollToHint: true, inline: true, dock: true);
	}

	public virtual void OnHintClick(Hint hint)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, new HintClickEventArgs(hint));
		}
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		timer_2.Stop();
		OnToolTip();
	}

	protected virtual void OnToolTip()
	{
		if (ToolTip == null || eventHandler_0 == null)
		{
			return;
		}
		Place place = PointToPlace(point_0);
		Point point = PlaceToPoint(place);
		if (Math.Abs(point.X - point_0.X) <= CharWidth * 2 && Math.Abs(point.Y - point_0.Y) <= CharHeight * 2)
		{
			Range range = new Range(this, place, place);
			string hoveredWord = range.GetFragment("[a-zA-Z]").Text;
			ToolTipNeededEventArgs e = new ToolTipNeededEventArgs(place, hoveredWord);
			eventHandler_0(this, e);
			if (e.ToolTipText != null)
			{
				ToolTip.ToolTipTitle = e.ToolTipTitle;
				ToolTip.ToolTipIcon = e.ToolTipIcon;
				ToolTip.Show(e.ToolTipText, this, new Point(point_0.X, point_0.Y + CharHeight));
			}
		}
	}

	public virtual void OnVisibleRangeChanged()
	{
		bool_9 = true;
		bool_12 = true;
		method_8(timer_0);
		if (eventHandler_7 != null)
		{
			eventHandler_7(this, new EventArgs());
		}
	}

	public new void Invalidate()
	{
		if (!base.InvokeRequired)
		{
			base.Invalidate();
		}
		else
		{
			BeginInvoke(new MethodInvoker(Invalidate));
		}
	}

	protected virtual void OnCharSizeChanged()
	{
		base.VerticalScroll.SmallChange = int_0;
		base.VerticalScroll.LargeChange = 10 * int_0;
		base.HorizontalScroll.SmallChange = CharWidth;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_0(EventHandler eventHandler_22)
	{
		EventHandler eventHandler = eventHandler_3;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_22);
			eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_1(EventHandler eventHandler_22)
	{
		EventHandler eventHandler = eventHandler_3;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_22);
			eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public List<Style> GetStylesOfChar(Place place)
	{
		List<Style> list = new List<Style>();
		if (place.iLine < LinesCount && place.iChar < this[place.iLine].Count)
		{
			ushort style = (ushort)this[place].style;
			for (int i = 0; i < 16; i++)
			{
				if ((style & (1 << i)) != 0)
				{
					list.Add(Styles[i]);
				}
			}
		}
		return list;
	}

	protected virtual TextSource CreateTextSource()
	{
		return new TextSource(this);
	}

	protected virtual void InitTextSource(TextSource ts)
	{
		if (textSource_0 != null)
		{
			textSource_0.LineInserted -= method_7;
			textSource_0.LineRemoved -= method_6;
			textSource_0.TextChanged -= method_5;
			textSource_0.RecalcNeeded -= method_4;
			textSource_0.RecalcWordWrap -= method_2;
			textSource_0.TextChanging -= method_3;
			textSource_0.Dispose();
		}
		LineInfos.Clear();
		ClearHints();
		if (Bookmarks != null)
		{
			Bookmarks.Clear();
		}
		textSource_0 = ts;
		if (ts != null)
		{
			ts.LineInserted += method_7;
			ts.LineRemoved += method_6;
			ts.TextChanged += method_5;
			ts.RecalcNeeded += method_4;
			ts.RecalcWordWrap += method_2;
			ts.TextChanging += method_3;
			while (LineInfos.Count < ts.Count)
			{
				LineInfos.Add(new LineInfo(-1));
			}
		}
		bool_3 = false;
		needRecalc = true;
	}

	private void method_2(object sender, TextSource.TextChangedEventArgs e)
	{
		int iFromLine = e.iFromLine;
		int iToLine = e.iToLine;
		Class76.smethod_638(iFromLine, this, iToLine);
	}

	private void method_3(object sender, TextChangingEventArgs e)
	{
		if (TextSource.CurrentTB == this)
		{
			string insertingText = e.InsertingText;
			OnTextChanging(ref insertingText);
			e.InsertingText = insertingText;
		}
	}

	private void method_4(object sender, TextSource.TextChangedEventArgs e)
	{
		if (e.iFromLine != e.iToLine || WordWrap || textSource_0.Count <= 100000)
		{
			NeedRecalc(forced: false, WordWrap);
		}
		else
		{
			Class76.smethod_631(this, e.iFromLine);
		}
	}

	public void NeedRecalc()
	{
		NeedRecalc(forced: false);
	}

	public void NeedRecalc(bool forced)
	{
		NeedRecalc(forced, wordWrapRecalc: false);
	}

	public void NeedRecalc(bool forced, bool wordWrapRecalc)
	{
		needRecalc = true;
		if (wordWrapRecalc)
		{
			point_1 = new Point(0, LinesCount - 1);
			needRecalcWordWrap = true;
		}
		if (forced)
		{
			Class76.smethod_722(this);
		}
	}

	private void method_5(object sender, TextSource.TextChangedEventArgs e)
	{
		if (e.iFromLine != e.iToLine || WordWrap)
		{
			needRecalc = true;
		}
		else
		{
			Class76.smethod_631(this, e.iFromLine);
		}
		Invalidate();
		if (TextSource.CurrentTB == this)
		{
			OnTextChanged(e.iFromLine, e.iToLine);
		}
	}

	private void method_6(object sender, LineRemovedEventArgs e)
	{
		LineInfos.RemoveRange(e.Index, e.Count);
		int index = e.Index;
		int count = e.Count;
		List<int> removedLineUniqueIds = e.RemovedLineUniqueIds;
		Class76.smethod_626(removedLineUniqueIds, count, index, this);
	}

	private void method_7(object sender, LineInsertedEventArgs e)
	{
		VisibleState visibleState = VisibleState.Visible;
		if (e.Index >= 0 && e.Index < LineInfos.Count && LineInfos[e.Index].VisibleState == VisibleState.Hidden)
		{
			visibleState = VisibleState.Hidden;
		}
		if (e.Count > 100000)
		{
			LineInfos.Capacity = LineInfos.Count + e.Count + 1000;
		}
		LineInfo[] array = new LineInfo[e.Count];
		for (int i = 0; i < e.Count; i++)
		{
			array[i].startY = -1;
			array[i].VisibleState = visibleState;
		}
		LineInfos.InsertRange(e.Index, array);
		if (e.Count > 1000000)
		{
			GC.Collect();
		}
		Class76.smethod_391(this, e.Index, e.Count);
	}

	public bool NavigateForward()
	{
		DateTime dateTime = DateTime.Now;
		int num = -1;
		for (int i = 0; i < LinesCount; i++)
		{
			if (textSource_0.IsLineLoaded(i) && textSource_0[i].LastVisit > dateTime_0 && textSource_0[i].LastVisit < dateTime)
			{
				dateTime = textSource_0[i].LastVisit;
				num = i;
			}
		}
		if (num < 0)
		{
			return false;
		}
		Navigate(num);
		return true;
	}

	public bool NavigateBackward()
	{
		DateTime dateTime = default(DateTime);
		int num = -1;
		for (int i = 0; i < LinesCount; i++)
		{
			if (textSource_0.IsLineLoaded(i) && textSource_0[i].LastVisit < dateTime_0 && textSource_0[i].LastVisit > dateTime)
			{
				dateTime = textSource_0[i].LastVisit;
				num = i;
			}
		}
		if (num < 0)
		{
			return false;
		}
		Navigate(num);
		return true;
	}

	public void Navigate(int iLine)
	{
		if (iLine < LinesCount)
		{
			dateTime_0 = textSource_0[iLine].LastVisit;
			Selection.Start = new Place(0, iLine);
			DoSelectionVisible();
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		intptr_0 = ImmGetContext(base.Handle);
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		timer_1.Enabled = false;
		if (bool_11)
		{
			bool_11 = false;
			if (range_1 != null)
			{
				range_1 = Range.GetIntersectionWith(range_1);
				range_1.Expand();
				OnTextChangedDelayed(range_1);
				range_1 = null;
			}
		}
	}

	public void AddVisualMarker(VisualMarker marker)
	{
		list_0.Add(marker);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		if (bool_10)
		{
			bool_10 = false;
			OnSelectionChangedDelayed();
		}
		if (bool_12)
		{
			bool_12 = false;
			OnVisibleRangeChangedDelayed();
		}
	}

	public virtual void OnTextChangedDelayed(Range changedRange)
	{
		if (eventHandler_8 != null)
		{
			eventHandler_8(this, new TextChangedEventArgs(changedRange));
		}
	}

	public virtual void OnSelectionChangedDelayed()
	{
		Class76.smethod_631(this, Selection.Start.iLine);
		Class76.smethod_808(this);
		if (LeftBracket != 0 && RightBracket != 0)
		{
			char leftBracket = LeftBracket;
			char rightBracket = RightBracket;
			Class76.smethod_210(leftBracket, this, ref range_2, ref range_4, rightBracket);
		}
		if (LeftBracket2 != 0 && RightBracket2 != 0)
		{
			char leftBracket = LeftBracket2;
			char rightBracket = RightBracket2;
			Class76.smethod_210(leftBracket, this, ref range_3, ref range_5, rightBracket);
		}
		if (Selection.IsEmpty && Selection.Start.iLine < LinesCount && dateTime_0 != textSource_0[Selection.Start.iLine].LastVisit)
		{
			textSource_0[Selection.Start.iLine].LastVisit = DateTime.Now;
			dateTime_0 = textSource_0[Selection.Start.iLine].LastVisit;
		}
		if (eventHandler_9 != null)
		{
			eventHandler_9(this, new EventArgs());
		}
	}

	public virtual void OnVisibleRangeChangedDelayed()
	{
		if (eventHandler_10 != null)
		{
			eventHandler_10(this, new EventArgs());
		}
	}

	private void method_8(System.Windows.Forms.Timer timer_4)
	{
		if (!base.InvokeRequired)
		{
			timer_4.Stop();
			if (!base.IsHandleCreated)
			{
				dictionary_1[timer_4] = timer_4;
			}
			else
			{
				timer_4.Start();
			}
		}
		else
		{
			BeginInvoke((MethodInvoker)delegate
			{
				method_8(timer_4);
			});
		}
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		foreach (System.Windows.Forms.Timer item in new List<System.Windows.Forms.Timer>(dictionary_1.Keys))
		{
			method_8(item);
		}
		dictionary_1.Clear();
		OnScrollbarsUpdated();
	}

	public int AddStyle(Style style)
	{
		if (style != null)
		{
			int styleIndex = GetStyleIndex(style);
			if (styleIndex < 0)
			{
				styleIndex = CheckStylesBufferSize();
				Styles[styleIndex] = style;
				return styleIndex;
			}
			return styleIndex;
		}
		return -1;
	}

	public int CheckStylesBufferSize()
	{
		int num = Styles.Length - 1;
		while (num >= 0 && Styles[num] == null)
		{
			num--;
		}
		num++;
		if (num >= Styles.Length)
		{
			throw new Exception("Maximum count of Styles is exceeded.");
		}
		return num;
	}

	public virtual void ShowFindDialog()
	{
		ShowFindDialog(null);
	}

	public virtual void ShowFindDialog(string findText)
	{
		if (findForm == null)
		{
			findForm = new FindForm(this);
		}
		if (findText == null)
		{
			if (!Selection.IsEmpty && Selection.Start.iLine == Selection.End.iLine)
			{
				findForm.tbFind.Text = Selection.Text;
			}
		}
		else
		{
			findForm.tbFind.Text = findText;
		}
		findForm.tbFind.SelectAll();
		findForm.Show();
		findForm.Focus();
	}

	public virtual void ShowReplaceDialog()
	{
		ShowReplaceDialog(null);
	}

	public virtual void ShowReplaceDialog(string findText)
	{
		if (ReadOnly)
		{
			return;
		}
		if (replaceForm == null)
		{
			replaceForm = new ReplaceForm(this);
		}
		if (findText == null)
		{
			if (!Selection.IsEmpty && Selection.Start.iLine == Selection.End.iLine)
			{
				replaceForm.tbFind.Text = Selection.Text;
			}
		}
		else
		{
			replaceForm.tbFind.Text = findText;
		}
		replaceForm.tbFind.SelectAll();
		replaceForm.Show();
		replaceForm.Focus();
	}

	public int GetLineLength(int iLine)
	{
		if (iLine < 0 || iLine >= textSource_0.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		return textSource_0[iLine].Count;
	}

	public Range GetLine(int iLine)
	{
		if (iLine < 0 || iLine >= textSource_0.Count)
		{
			throw new ArgumentOutOfRangeException("Line index out of range");
		}
		Range range = new Range(this);
		range.Start = new Place(0, iLine);
		range.End = new Place(textSource_0[iLine].Count, iLine);
		return range;
	}

	public virtual void Copy()
	{
		if (Selection.IsEmpty)
		{
			Selection.Expand();
		}
		if (!Selection.IsEmpty)
		{
			DataObject dataObject_0 = new DataObject();
			OnCreateClipboardData(dataObject_0);
			Thread thread = new Thread((ThreadStart)delegate
			{
				SetClipboard(dataObject_0);
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}
	}

	protected virtual void OnCreateClipboardData(DataObject data)
	{
		ExportToHTML exportToHTML = new ExportToHTML();
		exportToHTML.UseBr = false;
		exportToHTML.UseNbsp = false;
		exportToHTML.UseStyleTag = true;
		string html = "<pre>" + exportToHTML.GetHtml(Selection.Clone()) + "</pre>";
		data.SetData(DataFormats.UnicodeText, autoConvert: true, Selection.Text);
		data.SetData(DataFormats.Html, PrepareHtmlForClipboard(html));
		data.SetData(DataFormats.Rtf, new ExportToRTF().GetRtf(Selection.Clone()));
	}

	protected void SetClipboard(DataObject data)
	{
		try
		{
			Class76.CloseClipboard();
			Clipboard.SetDataObject(data, copy: true, 5, 100);
		}
		catch (ExternalException)
		{
		}
	}

	public static MemoryStream PrepareHtmlForClipboard(string html)
	{
		Encoding uTF = Encoding.UTF8;
		string format = "Version:0.9\r\nStartHTML:{0:000000}\r\nEndHTML:{1:000000}\r\nStartFragment:{2:000000}\r\nEndFragment:{3:000000}\r\n";
		string text = "<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=" + uTF.WebName + "\">\r\n<title>HTML clipboard</title>\r\n</head>\r\n<body>\r\n<!--StartFragment-->";
		string text2 = "<!--EndFragment-->\r\n</body>\r\n</html>\r\n";
		string s = string.Format(format, 0, 0, 0, 0);
		int byteCount = uTF.GetByteCount(s);
		int byteCount2 = uTF.GetByteCount(text);
		int byteCount3 = uTF.GetByteCount(html);
		int byteCount4 = uTF.GetByteCount(text2);
		string s2 = string.Format(format, byteCount, byteCount + byteCount2 + byteCount3 + byteCount4, byteCount + byteCount2, byteCount + byteCount2 + byteCount3) + text + html + text2;
		return new MemoryStream(uTF.GetBytes(s2));
	}

	public virtual void Cut()
	{
		if (Selection.IsEmpty)
		{
			if (LinesCount != 1)
			{
				DataObject dataObject_0 = new DataObject();
				OnCreateClipboardData(dataObject_0);
				Thread thread = new Thread((ThreadStart)delegate
				{
					SetClipboard(dataObject_0);
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.Join();
				if (Selection.Start.iLine >= 0 && Selection.Start.iLine < LinesCount)
				{
					int iLine = Selection.Start.iLine;
					RemoveLines(new List<int> { iLine });
					Selection.Start = new Place(0, Math.Max(0, Math.Min(iLine, LinesCount - 1)));
				}
			}
			else
			{
				Selection.SelectAll();
				Copy();
				ClearSelected();
			}
		}
		else
		{
			Copy();
			ClearSelected();
		}
	}

	public virtual void Paste()
	{
		string string_0 = null;
		Thread thread = new Thread((ThreadStart)delegate
		{
			if (Clipboard.ContainsText())
			{
				string_0 = Clipboard.GetText();
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		if (eventHandler_4 != null)
		{
			TextChangingEventArgs e = new TextChangingEventArgs
			{
				Cancel = false,
				InsertingText = string_0
			};
			eventHandler_4(this, e);
			if (!e.Cancel)
			{
				string_0 = e.InsertingText;
			}
			else
			{
				string_0 = string.Empty;
			}
		}
		if (!string.IsNullOrEmpty(string_0))
		{
			InsertText(string_0);
		}
	}

	public void SelectAll()
	{
		Selection.SelectAll();
	}

	public void GoEnd()
	{
		if (textSource_0.Count <= 0)
		{
			Selection.Start = new Place(0, 0);
		}
		else
		{
			Selection.Start = new Place(textSource_0[textSource_0.Count - 1].Count, textSource_0.Count - 1);
		}
		DoCaretVisible();
	}

	public void GoHome()
	{
		Selection.Start = new Place(0, 0);
		DoCaretVisible();
	}

	public virtual void Clear()
	{
		Selection.BeginUpdate();
		try
		{
			Selection.SelectAll();
			ClearSelected();
			Class76.smethod_89(textSource_0.Manager);
			Invalidate();
		}
		finally
		{
			Selection.EndUpdate();
		}
	}

	public void ClearStylesBuffer()
	{
		for (int i = 0; i < Styles.Length; i++)
		{
			Styles[i] = null;
		}
	}

	public void ClearStyle(StyleIndex styleIndex)
	{
		foreach (Line item in textSource_0)
		{
			item.ClearStyle(styleIndex);
		}
		for (int i = 0; i < LineInfos.Count; i++)
		{
			SetVisibleState(i, VisibleState.Visible);
		}
		Invalidate();
	}

	public void ClearUndo()
	{
		Class76.smethod_89(textSource_0.Manager);
	}

	public virtual void InsertText(string text)
	{
		InsertText(text, jumpToCaret: true);
	}

	public virtual void InsertText(string text, bool jumpToCaret)
	{
		if (text == null)
		{
			return;
		}
		if (text == "\r")
		{
			text = "\n";
		}
		textSource_0.Manager.BeginAutoUndoCommands();
		try
		{
			if (!Selection.IsEmpty)
			{
				textSource_0.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
			}
			if (TextSource.Count > 0 && Selection.IsEmpty && Selection.Start.iChar > GetLineLength(Selection.Start.iLine) && VirtualSpace)
			{
				Class76.smethod_778(this);
			}
			textSource_0.Manager.ExecuteCommand(new InsertTextCommand(TextSource, text));
			if (int_8 <= 0 && jumpToCaret)
			{
				DoCaretVisible();
			}
		}
		finally
		{
			textSource_0.Manager.EndAutoUndoCommands();
		}
		Invalidate();
	}

	public virtual Range InsertText(string text, Style style)
	{
		return InsertText(text, style, jumpToCaret: true);
	}

	public virtual Range InsertText(string text, Style style, bool jumpToCaret)
	{
		if (text != null)
		{
			Place start = ((!(Selection.Start > Selection.End)) ? Selection.Start : Selection.End);
			InsertText(text, jumpToCaret);
			Range range = new Range(this, start, Selection.Start)
			{
				ColumnSelectionMode = Selection.ColumnSelectionMode
			};
			range = range.GetIntersectionWith(Range);
			range.SetStyle(style);
			return range;
		}
		return null;
	}

	public virtual Range InsertTextAndRestoreSelection(Range replaceRange, string text, Style style)
	{
		if (text != null)
		{
			int num = PlaceToPosition(Selection.Start);
			int num2 = PlaceToPosition(Selection.End);
			int length = replaceRange.Text.Length;
			int num3 = PlaceToPosition(replaceRange.Start);
			Selection.BeginUpdate();
			Selection = replaceRange;
			Range range = InsertText(text, style);
			length = range.Text.Length - length;
			Selection.Start = PositionToPlace(num + ((num >= num3) ? length : 0));
			Selection.End = PositionToPlace(num2 + ((num2 >= num3) ? length : 0));
			Selection.EndUpdate();
			return range;
		}
		return null;
	}

	public virtual void AppendText(string text)
	{
		AppendText(text, null);
	}

	public virtual void AppendText(string text, Style style)
	{
		if (text == null)
		{
			return;
		}
		Selection.ColumnSelectionMode = false;
		Place start = Selection.Start;
		Place end = Selection.End;
		Selection.BeginUpdate();
		textSource_0.Manager.BeginAutoUndoCommands();
		try
		{
			if (textSource_0.Count <= 0)
			{
				Selection.Start = new Place(0, 0);
			}
			else
			{
				Selection.Start = new Place(textSource_0[textSource_0.Count - 1].Count, textSource_0.Count - 1);
			}
			Place start2 = Selection.Start;
			textSource_0.Manager.ExecuteCommand(new InsertTextCommand(TextSource, text));
			if (style != null)
			{
				new Range(this, start2, Selection.Start).SetStyle(style);
			}
		}
		finally
		{
			textSource_0.Manager.EndAutoUndoCommands();
			Selection.Start = start;
			Selection.End = end;
			Selection.EndUpdate();
		}
		Invalidate();
	}

	public int GetStyleIndex(Style style)
	{
		return Array.IndexOf(Styles, style);
	}

	public StyleIndex GetStyleIndexMask(Style[] styles)
	{
		StyleIndex styleIndex = StyleIndex.None;
		foreach (Style style in styles)
		{
			int styleIndex2 = GetStyleIndex(style);
			if (styleIndex2 >= 0)
			{
				styleIndex |= Range.ToStyleIndex(styleIndex2);
			}
		}
		return styleIndex;
	}

	public static SizeF GetCharSize(Font font, char c)
	{
		Size size = TextRenderer.MeasureText("<" + c + ">", font);
		Size size2 = TextRenderer.MeasureText("<>", font);
		return new SizeF(size.Width - size2.Width + 1, font.Height);
	}

	[DllImport("Imm32.dll")]
	public static extern IntPtr ImmGetContext(IntPtr hWnd);

	[DllImport("Imm32.dll")]
	public static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

	protected override void WndProc(ref Message m)
	{
		if ((m.Msg == 276 || m.Msg == 277) && m.WParam.ToInt32() != 8)
		{
			Invalidate();
		}
		base.WndProc(ref m);
		if (ImeAllowed && m.Msg == 641 && m.WParam.ToInt32() == 1)
		{
			ImmAssociateContext(base.Handle, intptr_0);
		}
	}

	internal void method_9()
	{
		if (ShowScrollBars || Hints.Count <= 0)
		{
			return;
		}
		foreach (Control item in list_1)
		{
			base.Controls.Add(item);
		}
		list_1.Clear();
		ResumeLayout(performLayout: false);
		if (!Focused)
		{
			Focus();
		}
	}

	public void OnScroll(ScrollEventArgs se, bool alignByLines)
	{
		Class76.smethod_21(this);
		if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
		{
			int num = se.NewValue;
			if (alignByLines)
			{
				num = (int)(Math.Ceiling(1.0 * (double)num / (double)CharHeight) * (double)CharHeight);
			}
			base.VerticalScroll.Value = Math.Max(base.VerticalScroll.Minimum, Math.Min(base.VerticalScroll.Maximum, num));
		}
		if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
		{
			base.HorizontalScroll.Value = Math.Max(base.HorizontalScroll.Minimum, Math.Min(base.HorizontalScroll.Maximum, se.NewValue));
		}
		UpdateScrollbars();
		method_9();
		Invalidate();
		base.OnScroll(se);
		OnVisibleRangeChanged();
	}

	protected override void OnScroll(ScrollEventArgs se)
	{
		OnScroll(se, alignByLines: true);
	}

	protected virtual void InsertChar(char c)
	{
		textSource_0.Manager.BeginAutoUndoCommands();
		try
		{
			if (!Selection.IsEmpty)
			{
				textSource_0.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
			}
			if (Selection.IsEmpty && Selection.Start.iChar > GetLineLength(Selection.Start.iLine) && VirtualSpace)
			{
				Class76.smethod_778(this);
			}
			textSource_0.Manager.ExecuteCommand(new InsertCharCommand(TextSource, c));
		}
		finally
		{
			textSource_0.Manager.EndAutoUndoCommands();
		}
		Invalidate();
	}

	public virtual void ClearSelected()
	{
		if (!Selection.IsEmpty)
		{
			textSource_0.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
			Invalidate();
		}
	}

	public void ClearCurrentLine()
	{
		Selection.Expand();
		textSource_0.Manager.ExecuteCommand(new ClearSelectedCommand(TextSource));
		if (Selection.Start.iLine != 0 || Selection.GoRightThroughFolded())
		{
			if (Selection.Start.iLine > 0)
			{
				textSource_0.Manager.ExecuteCommand(new InsertCharCommand(TextSource, '\b'));
			}
			Invalidate();
		}
	}

	public static void CalcCutOffs(List<int> cutOffPositions, int maxCharsPerLine, int maxCharsPerSecondaryLine, bool allowIME, bool charWrap, Line line)
	{
		if (maxCharsPerSecondaryLine < 1)
		{
			maxCharsPerSecondaryLine = 1;
		}
		if (maxCharsPerLine < 1)
		{
			maxCharsPerLine = 1;
		}
		int num = 0;
		int num2 = 0;
		cutOffPositions.Clear();
		for (int i = 0; i < line.Count - 1; i++)
		{
			char c = line[i].c;
			if (!charWrap)
			{
				if (!allowIME || !IsCJKLetter(c))
				{
					if (!char.IsLetterOrDigit(c) && c != '_' && c != '\'' && c != '\u00a0' && ((c != '.' && c != ',') || !char.IsDigit(line[i + 1].c)))
					{
						num2 = Math.Min(i + 1, line.Count - 1);
					}
				}
				else
				{
					num2 = i;
				}
			}
			else
			{
				num2 = i + 1;
			}
			num++;
			if (num == maxCharsPerLine)
			{
				if (num2 == 0 || (cutOffPositions.Count > 0 && num2 == cutOffPositions[cutOffPositions.Count - 1]))
				{
					num2 = i + 1;
				}
				cutOffPositions.Add(num2);
				num = 1 + i - num2;
				maxCharsPerLine = maxCharsPerSecondaryLine;
			}
		}
	}

	public static bool IsCJKLetter(char c)
	{
		int num = Convert.ToInt32(c);
		return (num >= 13056 && num <= 13311) || (num >= 65072 && num <= 65103) || (num >= 63744 && num <= 64255) || (num >= 11904 && num <= 12031) || (num >= 12736 && num <= 12783) || (num >= 19968 && num <= 40959) || (num >= 13312 && num <= 19903) || (num >= 12800 && num <= 13055) || (num >= 9312 && num <= 9471) || (num >= 12352 && num <= 12447) || (num >= 12032 && num <= 12255) || (num >= 12704 && num <= 12735) || (num >= 19904 && num <= 19967) || (num >= 12544 && num <= 12591) || (num >= 12448 && num <= 12543) || (num >= 12784 && num <= 12799) || (num >= 12272 && num <= 12287) || (num >= 4352 && num <= 4607) || (num >= 43360 && num <= 43391) || (num >= 55216 && num <= 55295) || (num >= 12592 && num <= 12687) || (num >= 44032 && num <= 55215);
	}

	protected override void OnClientSizeChanged(EventArgs e)
	{
		base.OnClientSizeChanged(e);
		if (WordWrap)
		{
			NeedRecalc(forced: false, wordWrapRecalc: true);
			Invalidate();
		}
		OnVisibleRangeChanged();
		UpdateScrollbars();
	}

	public void UpdateScrollbars()
	{
		if (!ShowScrollBars)
		{
			PerformLayout();
		}
		else
		{
			base.AutoScrollMinSize -= new Size(1, 0);
			base.AutoScrollMinSize += new Size(1, 0);
		}
		if (base.IsHandleCreated)
		{
			BeginInvoke(new MethodInvoker(OnScrollbarsUpdated));
		}
	}

	protected virtual void OnScrollbarsUpdated()
	{
		if (eventHandler_20 != null)
		{
			eventHandler_20(this, EventArgs.Empty);
		}
	}

	public void DoCaretVisible()
	{
		Invalidate();
		Class76.smethod_722(this);
		Point location = PlaceToPoint(Selection.Start);
		location.Offset(-CharWidth, 0);
		Class76.smethod_542(this, new Rectangle(location, new Size(2 * CharWidth, 2 * CharHeight)));
	}

	public void ScrollLeft()
	{
		Invalidate();
		base.HorizontalScroll.Value = 0;
		AutoScrollMinSize -= new Size(1, 0);
		AutoScrollMinSize += new Size(1, 0);
	}

	public void DoSelectionVisible()
	{
		if (LineInfos[Selection.End.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(Selection.End.iLine);
		}
		if (LineInfos[Selection.Start.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(Selection.Start.iLine);
		}
		Class76.smethod_722(this);
		Class76.smethod_542(this, new Rectangle(PlaceToPoint(new Place(0, Selection.End.iLine)), new Size(2 * CharWidth, 2 * CharHeight)));
		Point location = PlaceToPoint(Selection.Start);
		Point point = PlaceToPoint(Selection.End);
		location.Offset(-CharWidth, -base.ClientSize.Height / 2);
		Class76.smethod_542(this, new Rectangle(location, new Size(Math.Abs(point.X - location.X), base.ClientSize.Height)));
		Invalidate();
	}

	public void DoRangeVisible(Range range)
	{
		DoRangeVisible(range, tryToCentre: false);
	}

	public void DoRangeVisible(Range range, bool tryToCentre)
	{
		range = range.Clone();
		range.Normalize();
		range.End = new Place(range.End.iChar, Math.Min(range.End.iLine, range.Start.iLine + base.ClientSize.Height / CharHeight));
		if (LineInfos[range.End.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(range.End.iLine);
		}
		if (LineInfos[range.Start.iLine].VisibleState != VisibleState.Visible)
		{
			ExpandBlock(range.Start.iLine);
		}
		Class76.smethod_722(this);
		int num = (1 + range.End.iLine - range.Start.iLine) * CharHeight;
		Point location = PlaceToPoint(new Place(0, range.Start.iLine));
		if (tryToCentre)
		{
			location.Offset(0, -base.ClientSize.Height / 2);
			num = base.ClientSize.Height;
		}
		Class76.smethod_542(this, new Rectangle(location, new Size(2 * CharWidth, num)));
		Invalidate();
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (e.KeyCode == Keys.ShiftKey)
		{
			keys_0 &= ~Keys.Shift;
		}
		if (e.KeyCode == Keys.Alt)
		{
			keys_0 &= ~Keys.Alt;
		}
		if (e.KeyCode == Keys.ControlKey)
		{
			keys_0 &= ~Keys.Control;
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (bool_33)
		{
			return;
		}
		base.OnKeyDown(e);
		if (Focused)
		{
			keys_0 = e.Modifiers;
		}
		bool_1 = false;
		if (!e.Handled)
		{
			if (!ProcessKey(e.KeyData))
			{
				e.Handled = true;
				DoCaretVisible();
				Invalidate();
			}
		}
		else
		{
			bool_1 = true;
		}
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if ((keyData & Keys.Alt) <= Keys.None || !HotkeysMapping.ContainsKey(keyData))
		{
			return base.ProcessDialogKey(keyData);
		}
		ProcessKey(keyData);
		return true;
	}

	public virtual bool ProcessKey(Keys keyData)
	{
		KeyEventArgs e = new KeyEventArgs(keyData);
		if (e.KeyCode != Keys.Tab || AcceptsTab)
		{
			if (macrosManager_0 != null && (!HotkeysMapping.ContainsKey(keyData) || (HotkeysMapping[keyData] != FCTBAction.MacroExecute && HotkeysMapping[keyData] != FCTBAction.MacroRecord)))
			{
				Class76.smethod_496(macrosManager_0, keyData);
			}
			if (!HotkeysMapping.ContainsKey(keyData))
			{
				if (e.KeyCode == Keys.Alt)
				{
					return true;
				}
				if ((e.Modifiers & Keys.Control) != Keys.None)
				{
					return true;
				}
				if ((e.Modifiers & Keys.Alt) != Keys.None)
				{
					if ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.None)
					{
						CheckAndChangeSelectionType();
					}
					return true;
				}
				if (e.KeyCode == Keys.ShiftKey)
				{
					return true;
				}
			}
			else
			{
				FCTBAction fCTBAction = HotkeysMapping[keyData];
				method_10(fCTBAction);
				if (dictionary_2.ContainsKey(fCTBAction))
				{
					return true;
				}
				if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift))
				{
					bool_1 = true;
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private void method_10(FCTBAction fctbaction_0)
	{
		switch (fctbaction_0)
		{
		case FCTBAction.CustomAction1:
		case FCTBAction.CustomAction2:
		case FCTBAction.CustomAction3:
		case FCTBAction.CustomAction4:
		case FCTBAction.CustomAction5:
		case FCTBAction.CustomAction6:
		case FCTBAction.CustomAction7:
		case FCTBAction.CustomAction8:
		case FCTBAction.CustomAction9:
		case FCTBAction.CustomAction10:
		case FCTBAction.CustomAction11:
		case FCTBAction.CustomAction12:
		case FCTBAction.CustomAction13:
		case FCTBAction.CustomAction14:
		case FCTBAction.CustomAction15:
		case FCTBAction.CustomAction16:
		case FCTBAction.CustomAction17:
		case FCTBAction.CustomAction18:
		case FCTBAction.CustomAction19:
		case FCTBAction.CustomAction20:
			OnCustomAction(new CustomActionEventArgs(fctbaction_0));
			break;
		case FCTBAction.ZoomIn:
			ChangeFontSize(2);
			break;
		case FCTBAction.ZoomOut:
			ChangeFontSize(-2);
			break;
		case FCTBAction.ZoomNormal:
			Class76.smethod_365(this);
			break;
		case FCTBAction.ScrollDown:
			method_15(1, -1);
			break;
		case FCTBAction.ScrollUp:
			method_15(1, 1);
			break;
		case FCTBAction.GoToDialog:
			ShowGoToDialog();
			break;
		case FCTBAction.FindDialog:
			ShowFindDialog();
			break;
		case FCTBAction.FindChar:
			bool_30 = true;
			break;
		case FCTBAction.FindNext:
			if (findForm != null && !(findForm.tbFind.Text == ""))
			{
				findForm.FindNext(findForm.tbFind.Text);
			}
			else
			{
				ShowFindDialog();
			}
			break;
		case FCTBAction.ReplaceDialog:
			ShowReplaceDialog();
			break;
		case FCTBAction.Copy:
			Copy();
			break;
		case FCTBAction.CommentSelected:
			CommentSelected();
			break;
		case FCTBAction.Cut:
			if (!Selection.ReadOnly)
			{
				Cut();
			}
			break;
		case FCTBAction.Paste:
			if (!Selection.ReadOnly)
			{
				Paste();
			}
			break;
		case FCTBAction.SelectAll:
			Selection.SelectAll();
			break;
		case FCTBAction.Undo:
			if (!ReadOnly)
			{
				Undo();
			}
			break;
		case FCTBAction.Redo:
			if (!ReadOnly)
			{
				Redo();
			}
			break;
		case FCTBAction.LowerCase:
			if (!Selection.ReadOnly)
			{
				LowerCase();
			}
			break;
		case FCTBAction.UpperCase:
			if (!Selection.ReadOnly)
			{
				UpperCase();
			}
			break;
		case FCTBAction.IndentDecrease:
		{
			if (Selection.ReadOnly)
			{
				break;
			}
			Range range2 = Selection.Clone();
			if (range2.Start.iLine == range2.End.iLine)
			{
				Line line = this[range2.Start.iLine];
				if (range2.Start.iChar != 0 || range2.End.iChar != line.Count)
				{
					if (range2.Start.iChar == line.Count && range2.End.iChar == 0)
					{
						Selection = new Range(this, line.Count, range2.Start.iLine, line.StartSpacesCount, range2.Start.iLine);
					}
				}
				else
				{
					Selection = new Range(this, line.StartSpacesCount, range2.Start.iLine, line.Count, range2.Start.iLine);
				}
			}
			DecreaseIndent();
			break;
		}
		case FCTBAction.IndentIncrease:
		{
			if (Selection.ReadOnly)
			{
				break;
			}
			Range range = Selection.Clone();
			bool flag = range.Start > range.End;
			range.Normalize();
			int startSpacesCount = this[range.Start.iLine].StartSpacesCount;
			if (range.Start.iLine == range.End.iLine && (range.Start.iChar > startSpacesCount || range.End.iChar != this[range.Start.iLine].Count) && range.End.iChar > startSpacesCount)
			{
				ProcessKey('\t', Keys.None);
				break;
			}
			IncreaseIndent();
			if (range.Start.iLine == range.End.iLine && !range.IsEmpty)
			{
				Selection = new Range(this, this[range.Start.iLine].StartSpacesCount, range.End.iLine, this[range.Start.iLine].Count, range.End.iLine);
				if (flag)
				{
					Selection.Inverse();
				}
			}
			break;
		}
		case FCTBAction.AutoIndentChars:
			if (!Selection.ReadOnly)
			{
				DoAutoIndentChars(Selection.Start.iLine);
			}
			break;
		case FCTBAction.NavigateBackward:
			NavigateBackward();
			break;
		case FCTBAction.NavigateForward:
			NavigateForward();
			break;
		case FCTBAction.UnbookmarkLine:
			UnbookmarkLine(Selection.Start.iLine);
			break;
		case FCTBAction.BookmarkLine:
			BookmarkLine(Selection.Start.iLine);
			break;
		case FCTBAction.GoNextBookmark:
			GotoNextBookmark(Selection.Start.iLine);
			break;
		case FCTBAction.GoPrevBookmark:
			GotoPrevBookmark(Selection.Start.iLine);
			break;
		case FCTBAction.ClearWordLeft:
			if (method_11('\b'))
			{
				break;
			}
			if (!Selection.ReadOnly)
			{
				if (!Selection.IsEmpty)
				{
					ClearSelected();
				}
				Selection.GoWordLeft(shift: true);
				if (!Selection.ReadOnly)
				{
					ClearSelected();
				}
			}
			OnKeyPressed('\b');
			break;
		case FCTBAction.ReplaceMode:
			if (!ReadOnly)
			{
				bool_5 = !bool_5;
			}
			break;
		case FCTBAction.DeleteCharRight:
			if (Selection.ReadOnly || method_11('ÿ'))
			{
				break;
			}
			if (Selection.IsEmpty)
			{
				if (this[Selection.Start.iLine].StartSpacesCount == this[Selection.Start.iLine].Count)
				{
					Class76.smethod_44(this);
				}
				if (!Selection.IsReadOnlyRightChar() && Selection.GoRightThroughFolded())
				{
					int iLine = Selection.Start.iLine;
					InsertChar('\b');
					if (iLine != Selection.Start.iLine && AutoIndent && Selection.Start.iChar > 0)
					{
						Class76.smethod_44(this);
					}
				}
			}
			else
			{
				ClearSelected();
			}
			if (AutoIndentChars)
			{
				DoAutoIndentChars(Selection.Start.iLine);
			}
			OnKeyPressed('ÿ');
			break;
		case FCTBAction.ClearWordRight:
			if (method_11('ÿ'))
			{
				break;
			}
			if (!Selection.ReadOnly)
			{
				if (!Selection.IsEmpty)
				{
					ClearSelected();
				}
				Selection.GoWordRight(shift: true);
				if (!Selection.ReadOnly)
				{
					ClearSelected();
				}
			}
			OnKeyPressed('ÿ');
			break;
		case FCTBAction.GoWordLeft:
			Selection.GoWordLeft(shift: false);
			break;
		case FCTBAction.GoWordLeftWithSelection:
			Selection.GoWordLeft(shift: true);
			break;
		case FCTBAction.GoLeft:
			Selection.GoLeft(shift: false);
			break;
		case FCTBAction.GoLeftWithSelection:
			Selection.GoLeft(shift: true);
			break;
		case FCTBAction.GoLeft_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Class76.smethod_198(Selection);
			}
			Invalidate();
			break;
		case FCTBAction.GoWordRight:
			Selection.GoWordRight(shift: false, goToStartOfNextWord: true);
			break;
		case FCTBAction.GoWordRightWithSelection:
			Selection.GoWordRight(shift: true, goToStartOfNextWord: true);
			break;
		case FCTBAction.GoRight:
			Selection.GoRight(shift: false);
			break;
		case FCTBAction.GoRightWithSelection:
			Selection.GoRight(shift: true);
			break;
		case FCTBAction.GoRight_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Class76.smethod_847(Selection);
			}
			Invalidate();
			break;
		case FCTBAction.GoUp:
			Class76.smethod_486(Selection, false);
			ScrollLeft();
			break;
		case FCTBAction.GoUpWithSelection:
			Class76.smethod_486(Selection, true);
			ScrollLeft();
			break;
		case FCTBAction.GoUp_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Class76.smethod_379(Selection);
			}
			Invalidate();
			break;
		case FCTBAction.MoveSelectedLinesUp:
			if (!Selection.ColumnSelectionMode)
			{
				MoveSelectedLinesUp();
			}
			break;
		case FCTBAction.GoDown:
			Class76.smethod_713(Selection, false);
			ScrollLeft();
			break;
		case FCTBAction.GoDownWithSelection:
			Class76.smethod_713(Selection, true);
			ScrollLeft();
			break;
		case FCTBAction.GoDown_ColumnSelectionMode:
			CheckAndChangeSelectionType();
			if (Selection.ColumnSelectionMode)
			{
				Class76.smethod_186(Selection);
			}
			Invalidate();
			break;
		case FCTBAction.MoveSelectedLinesDown:
			if (!Selection.ColumnSelectionMode)
			{
				MoveSelectedLinesDown();
			}
			break;
		case FCTBAction.GoPageUp:
			Class76.smethod_17(Selection, false);
			ScrollLeft();
			break;
		case FCTBAction.GoPageUpWithSelection:
			Class76.smethod_17(Selection, true);
			ScrollLeft();
			break;
		case FCTBAction.GoPageDown:
			Class76.smethod_227(Selection, false);
			ScrollLeft();
			break;
		case FCTBAction.GoPageDownWithSelection:
			Class76.smethod_227(Selection, true);
			ScrollLeft();
			break;
		case FCTBAction.GoFirstLine:
			Class76.smethod_461(Selection, false);
			break;
		case FCTBAction.GoFirstLineWithSelection:
			Class76.smethod_461(Selection, true);
			break;
		case FCTBAction.GoHome:
			Class76.smethod_797(this, false);
			ScrollLeft();
			break;
		case FCTBAction.GoHomeWithSelection:
			Class76.smethod_797(this, true);
			ScrollLeft();
			break;
		case FCTBAction.GoLastLine:
			Class76.smethod_342(Selection, false);
			break;
		case FCTBAction.GoLastLineWithSelection:
			Class76.smethod_342(Selection, true);
			break;
		case FCTBAction.GoEnd:
			Class76.smethod_710(Selection, false);
			break;
		case FCTBAction.GoEndWithSelection:
			Class76.smethod_710(Selection, true);
			break;
		case FCTBAction.ClearHints:
			ClearHints();
			if (MacrosManager != null)
			{
				MacrosManager.IsRecording = false;
			}
			break;
		case FCTBAction.MacroRecord:
			if (MacrosManager != null)
			{
				if (MacrosManager.AllowMacroRecordingByUser)
				{
					MacrosManager.IsRecording = !MacrosManager.IsRecording;
				}
				if (MacrosManager.IsRecording)
				{
					MacrosManager.ClearMacros();
				}
			}
			break;
		case FCTBAction.MacroExecute:
			if (MacrosManager != null)
			{
				MacrosManager.IsRecording = false;
				MacrosManager.ExecuteMacros();
			}
			break;
		}
	}

	protected virtual void OnCustomAction(CustomActionEventArgs e)
	{
		if (eventHandler_19 != null)
		{
			eventHandler_19(this, e);
		}
	}

	public bool GotoNextBookmark(int iLine)
	{
		Bookmark bookmark = null;
		int num = int.MaxValue;
		Bookmark bookmark2 = null;
		int num2 = int.MaxValue;
		foreach (Bookmark item in baseBookmarks_0)
		{
			if (item.LineIndex < num2)
			{
				num2 = item.LineIndex;
				bookmark2 = item;
			}
			if (item.LineIndex > iLine && item.LineIndex < num)
			{
				num = item.LineIndex;
				bookmark = item;
			}
		}
		if (bookmark == null)
		{
			if (bookmark2 == null)
			{
				return false;
			}
			bookmark2.DoVisible();
			return true;
		}
		bookmark.DoVisible();
		return true;
	}

	public bool GotoPrevBookmark(int iLine)
	{
		Bookmark bookmark = null;
		int num = -1;
		Bookmark bookmark2 = null;
		int num2 = -1;
		foreach (Bookmark item in baseBookmarks_0)
		{
			if (item.LineIndex > num2)
			{
				num2 = item.LineIndex;
				bookmark2 = item;
			}
			if (item.LineIndex < iLine && item.LineIndex > num)
			{
				num = item.LineIndex;
				bookmark = item;
			}
		}
		if (bookmark == null)
		{
			if (bookmark2 == null)
			{
				return false;
			}
			bookmark2.DoVisible();
			return true;
		}
		bookmark.DoVisible();
		return true;
	}

	public virtual void BookmarkLine(int iLine)
	{
		if (!baseBookmarks_0.Contains(iLine))
		{
			baseBookmarks_0.Add(iLine);
		}
	}

	public virtual void UnbookmarkLine(int iLine)
	{
		baseBookmarks_0.Remove(iLine);
	}

	public virtual void MoveSelectedLinesDown()
	{
		Range range = Selection.Clone();
		Selection.Expand();
		if (Selection.ReadOnly)
		{
			Selection = range;
			return;
		}
		int iLine = Selection.Start.iLine;
		if (Selection.End.iLine < LinesCount - 1)
		{
			string selectedText = SelectedText;
			List<int> list = new List<int>();
			for (int i = Selection.Start.iLine; i <= Selection.End.iLine; i++)
			{
				list.Add(i);
			}
			RemoveLines(list);
			Selection.Start = new Place(GetLineLength(iLine), iLine);
			SelectedText = "\n" + selectedText;
			Selection.Start = new Place(range.Start.iChar, range.Start.iLine + 1);
			Selection.End = new Place(range.End.iChar, range.End.iLine + 1);
		}
		else
		{
			Selection = range;
		}
	}

	public virtual void MoveSelectedLinesUp()
	{
		Range range = Selection.Clone();
		Selection.Expand();
		if (Selection.ReadOnly)
		{
			Selection = range;
			return;
		}
		int iLine = Selection.Start.iLine;
		if (iLine != 0)
		{
			string selectedText = SelectedText;
			List<int> list = new List<int>();
			for (int i = Selection.Start.iLine; i <= Selection.End.iLine; i++)
			{
				list.Add(i);
			}
			RemoveLines(list);
			Selection.Start = new Place(0, iLine - 1);
			SelectedText = selectedText + "\n";
			Selection.Start = new Place(range.Start.iChar, range.Start.iLine - 1);
			Selection.End = new Place(range.End.iChar, range.End.iLine - 1);
		}
		else
		{
			Selection = range;
		}
	}

	public virtual void UpperCase()
	{
		Range range = Selection.Clone();
		SelectedText = SelectedText.ToUpper();
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public virtual void LowerCase()
	{
		Range range = Selection.Clone();
		SelectedText = SelectedText.ToLower();
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public virtual void TitleCase()
	{
		Range range = Selection.Clone();
		SelectedText = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(SelectedText.ToLower());
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public virtual void SentenceCase()
	{
		Range range = Selection.Clone();
		string input = SelectedText.ToLower();
		Regex regex = new Regex("(^\\S)|[\\.\\?!:]\\s+(\\S)", RegexOptions.ExplicitCapture);
		SelectedText = regex.Replace(input, (Match match_0) => match_0.Value.ToUpper());
		Selection.Start = range.Start;
		Selection.End = range.End;
	}

	public void CommentSelected()
	{
		CommentSelected(CommentPrefix);
	}

	public virtual void CommentSelected(string commentPrefix)
	{
		if (!string.IsNullOrEmpty(commentPrefix))
		{
			Selection.Normalize();
			if (!textSource_0[Selection.Start.iLine].Text.TrimStart().StartsWith(commentPrefix))
			{
				InsertLinePrefix(commentPrefix);
			}
			else
			{
				RemoveLinePrefix(commentPrefix);
			}
		}
	}

	public void OnKeyPressing(KeyPressEventArgs args)
	{
		if (keyPressEventHandler_0 != null)
		{
			keyPressEventHandler_0(this, args);
		}
	}

	private bool method_11(char char_5)
	{
		if (!bool_30)
		{
			KeyPressEventArgs e = new KeyPressEventArgs(char_5);
			OnKeyPressing(e);
			return e.Handled;
		}
		bool_30 = false;
		FindChar(char_5);
		return true;
	}

	public void OnKeyPressed(char c)
	{
		KeyPressEventArgs e = new KeyPressEventArgs(c);
		if (keyPressEventHandler_1 != null)
		{
			keyPressEventHandler_1(this, e);
		}
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (!bool_33)
		{
			if (!Focused)
			{
				return false;
			}
			return ProcessKey(charCode, keys_0) || base.ProcessMnemonic(charCode);
		}
		return false;
	}

	protected override bool ProcessKeyMessage(ref Message m)
	{
		if (m.Msg == 258)
		{
			ProcessMnemonic(Convert.ToChar(m.WParam.ToInt32()));
		}
		return base.ProcessKeyMessage(ref m);
	}

	public virtual bool ProcessKey(char c, Keys modifiers)
	{
		if (!bool_1)
		{
			if (macrosManager_0 != null)
			{
				Class76.smethod_500(c, macrosManager_0, modifiers);
			}
			if (c != '\b' || (modifiers != Keys.None && modifiers != Keys.Shift && (modifiers & Keys.Alt) == 0))
			{
				if (!char.IsControl(c) || c == '\r' || c == '\t')
				{
					if (!ReadOnly && base.Enabled)
					{
						if (modifiers == Keys.None || modifiers == Keys.Shift || modifiers == (Keys.Control | Keys.Alt) || modifiers == (Keys.Shift | Keys.Control | Keys.Alt) || (modifiers == Keys.Alt && !char.IsLetterOrDigit(c)))
						{
							char c2 = c;
							if (!method_11(c2))
							{
								if (!Selection.ReadOnly)
								{
									if (c != '\r' || AcceptsReturn)
									{
										if (c == '\r')
										{
											c = '\n';
										}
										if (IsReplaceMode)
										{
											Selection.GoRight(shift: true);
											Selection.Inverse();
										}
										if (!Selection.ReadOnly && !Class76.smethod_829(c, this))
										{
											InsertChar(c);
										}
										if (c == '\n' || AutoIndentExistingLines)
										{
											DoAutoIndentIfNeed();
										}
										if (AutoIndentChars)
										{
											DoAutoIndentChars(Selection.Start.iLine);
										}
										DoCaretVisible();
										Invalidate();
										OnKeyPressed(c2);
										return true;
									}
									return false;
								}
								return false;
							}
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			if (!ReadOnly && base.Enabled)
			{
				if (!method_11(c))
				{
					if (!Selection.ReadOnly)
					{
						if (Selection.IsEmpty)
						{
							if (!Selection.IsReadOnlyLeftChar())
							{
								InsertChar('\b');
							}
						}
						else
						{
							ClearSelected();
						}
						if (AutoIndentChars)
						{
							DoAutoIndentChars(Selection.Start.iLine);
						}
						OnKeyPressed('\b');
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	public void DoAutoIndentChars(int iLine)
	{
		string[] array = AutoIndentCharsPatterns.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		int num = 0;
		string pattern;
		while (true)
		{
			if (num < array2.Length)
			{
				pattern = array2[num];
				Match match = Regex.Match(this[iLine].Text, pattern);
				if (match.Success)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		DoAutoIndentChars(iLine, new Regex(pattern));
	}

	protected void DoAutoIndentChars(int iLine, Regex regex)
	{
		Range range = Selection.Clone();
		SortedDictionary<int, CaptureCollection> sortedDictionary = new SortedDictionary<int, CaptureCollection>();
		SortedDictionary<int, string> sortedDictionary2 = new SortedDictionary<int, string>();
		int num = 0;
		int startSpacesCount = this[iLine].StartSpacesCount;
		int num2 = iLine;
		while (num2 >= 0 && startSpacesCount == this[num2].StartSpacesCount)
		{
			string text = this[num2].Text;
			Match match = regex.Match(text);
			if (!match.Success)
			{
				break;
			}
			sortedDictionary[num2] = match.Groups["range"].Captures;
			sortedDictionary2[num2] = text;
			if (sortedDictionary[num2].Count > num)
			{
				num = sortedDictionary[num2].Count;
			}
			num2--;
		}
		for (int i = iLine + 1; i < LinesCount && startSpacesCount == this[i].StartSpacesCount; i++)
		{
			string text2 = this[i].Text;
			Match match2 = regex.Match(text2);
			if (!match2.Success)
			{
				break;
			}
			sortedDictionary[i] = match2.Groups["range"].Captures;
			sortedDictionary2[i] = text2;
			if (sortedDictionary[i].Count > num)
			{
				num = sortedDictionary[i].Count;
			}
		}
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		bool flag = false;
		for (int num3 = num - 1; num3 >= 0; num3--)
		{
			int num4 = 0;
			foreach (int key in sortedDictionary.Keys)
			{
				CaptureCollection captureCollection = sortedDictionary[key];
				if (captureCollection.Count > num3)
				{
					int num5 = 0;
					Capture capture = captureCollection[num3];
					int num6 = capture.Index;
					string text3 = sortedDictionary2[key];
					while (num6 > 0 && text3[num6 - 1] == ' ')
					{
						num6--;
					}
					num5 = ((num3 == 0) ? num6 : (num6 - captureCollection[num3 - 1].Index - 1));
					if (num5 > num4)
					{
						num4 = num5;
					}
				}
			}
			foreach (int item in new List<int>(sortedDictionary2.Keys))
			{
				if (sortedDictionary[item].Count <= num3)
				{
					continue;
				}
				int num7 = 0;
				Capture capture2 = sortedDictionary[item][num3];
				num7 = ((num3 == 0) ? capture2.Index : (capture2.Index - sortedDictionary[item][num3 - 1].Index - 1));
				int num8 = num4 - num7 + 1;
				if (num8 != 0)
				{
					if (range.Start.iLine == item && range.Start.iChar > capture2.Index)
					{
						range.Start = new Place(range.Start.iChar + num8, item);
					}
					if (num8 <= 0)
					{
						sortedDictionary2[item] = sortedDictionary2[item].Remove(capture2.Index + num8, -num8);
					}
					else
					{
						sortedDictionary2[item] = sortedDictionary2[item].Insert(capture2.Index, new string(' ', num8));
					}
					dictionary[item] = true;
					flag = true;
				}
			}
		}
		if (!flag)
		{
			return;
		}
		Selection.BeginUpdate();
		BeginAutoUndo();
		BeginUpdate();
		TextSource.Manager.ExecuteCommand(new SelectCommand(TextSource));
		foreach (int key2 in sortedDictionary2.Keys)
		{
			if (dictionary.ContainsKey(key2))
			{
				Selection = new Range(this, 0, key2, this[key2].Count, key2);
				if (!Selection.ReadOnly)
				{
					InsertText(sortedDictionary2[key2]);
				}
			}
		}
		Selection = range;
		EndUpdate();
		EndAutoUndo();
		Selection.EndUpdate();
	}

	internal bool method_12(char char_5, char char_6)
	{
		if (!Selection.ColumnSelectionMode)
		{
			if (!Selection.IsEmpty)
			{
				InsertText(char_5 + SelectedText + char_6);
			}
			else
			{
				InsertText(char_5.ToString() + char_6);
				Selection.GoLeft();
			}
		}
		else
		{
			Range range = Selection.Clone();
			range.Normalize();
			Selection.BeginUpdate();
			BeginAutoUndo();
			Selection = new Range(this, range.Start.iChar, range.Start.iLine, range.Start.iChar, range.End.iLine)
			{
				ColumnSelectionMode = true
			};
			InsertChar(char_5);
			Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine)
			{
				ColumnSelectionMode = true
			};
			InsertChar(char_6);
			if (range.IsEmpty)
			{
				Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine)
				{
					ColumnSelectionMode = true
				};
			}
			EndAutoUndo();
			Selection.EndUpdate();
		}
		return true;
	}

	protected virtual void FindChar(char c)
	{
		if (c == '\r')
		{
			c = '\n';
		}
		Range range = Selection.Clone();
		do
		{
			if (!range.GoRight())
			{
				return;
			}
		}
		while (range.CharBeforeStart != c);
		Selection = range;
		DoCaretVisible();
	}

	public virtual void DoAutoIndentIfNeed()
	{
		if (!Selection.ColumnSelectionMode && AutoIndent)
		{
			DoCaretVisible();
			int num = CalcAutoIndent(Selection.Start.iLine);
			if (this[Selection.Start.iLine].AutoIndentSpacesNeededCount != num)
			{
				DoAutoIndent(Selection.Start.iLine);
				this[Selection.Start.iLine].AutoIndentSpacesNeededCount = num;
			}
		}
	}

	public virtual void DoAutoIndent(int iLine)
	{
		if (Selection.ColumnSelectionMode)
		{
			return;
		}
		Place start = Selection.Start;
		int num = CalcAutoIndent(iLine);
		int startSpacesCount = textSource_0[iLine].StartSpacesCount;
		int num2 = num - startSpacesCount;
		if (num2 < 0)
		{
			num2 = -Math.Min(-num2, startSpacesCount);
		}
		if (num2 != 0)
		{
			Selection.Start = new Place(0, iLine);
			if (num2 <= 0)
			{
				Selection.Start = new Place(0, iLine);
				Selection.End = new Place(-num2, iLine);
				ClearSelected();
			}
			else
			{
				InsertText(new string(' ', num2));
			}
			Selection.Start = new Place(Math.Min(textSource_0[iLine].Count, Math.Max(0, start.iChar + num2)), iLine);
		}
	}

	public virtual int CalcAutoIndent(int iLine)
	{
		if (iLine >= 0 && iLine < LinesCount)
		{
			EventHandler<AutoIndentEventArgs> eventHandler = eventHandler_12;
			if (eventHandler == null)
			{
				eventHandler = ((Language != Language.Custom && SyntaxHighlighter != null) ? new EventHandler<AutoIndentEventArgs>(SyntaxHighlighter.AutoIndentNeeded) : new EventHandler<AutoIndentEventArgs>(vmethod_0));
			}
			int num = 0;
			Stack<AutoIndentEventArgs> stack = new Stack<AutoIndentEventArgs>();
			int num2;
			for (num2 = iLine - 1; num2 >= 0; num2--)
			{
				AutoIndentEventArgs e = new AutoIndentEventArgs(num2, textSource_0[num2].Text, (num2 <= 0) ? "" : textSource_0[num2 - 1].Text, TabLength, 0);
				eventHandler(this, e);
				stack.Push(e);
				if (e.Shift == 0 && e.AbsoluteIndentation == 0 && e.LineText.Trim() != "")
				{
					break;
				}
			}
			int num3 = textSource_0[(num2 >= 0) ? num2 : 0].StartSpacesCount;
			while (stack.Count != 0)
			{
				AutoIndentEventArgs e2 = stack.Pop();
				num3 = ((e2.AbsoluteIndentation != 0) ? (e2.AbsoluteIndentation + e2.ShiftNextLines) : (num3 + e2.ShiftNextLines));
			}
			AutoIndentEventArgs e3 = new AutoIndentEventArgs(iLine, textSource_0[iLine].Text, (iLine <= 0) ? "" : textSource_0[iLine - 1].Text, TabLength, num3);
			eventHandler(this, e3);
			return e3.AbsoluteIndentation + e3.Shift;
		}
		return 0;
	}

	internal virtual void vmethod_0(object sender, AutoIndentEventArgs e)
	{
		if (!string.IsNullOrEmpty(textSource_0[e.iLine].FoldingEndMarker) || string.IsNullOrEmpty(textSource_0[e.iLine].FoldingStartMarker))
		{
			if (!string.IsNullOrEmpty(textSource_0[e.iLine].FoldingEndMarker) && string.IsNullOrEmpty(textSource_0[e.iLine].FoldingStartMarker))
			{
				e.Shift = -TabLength;
				e.ShiftNextLines = -TabLength;
			}
		}
		else
		{
			e.ShiftNextLines = TabLength;
		}
	}

	protected int GetMinStartSpacesCount(int fromLine, int toLine)
	{
		if (fromLine <= toLine)
		{
			int num = int.MaxValue;
			for (int i = fromLine; i <= toLine; i++)
			{
				int startSpacesCount = textSource_0[i].StartSpacesCount;
				if (startSpacesCount < num)
				{
					num = startSpacesCount;
				}
			}
			return num;
		}
		return 0;
	}

	protected int GetMaxStartSpacesCount(int fromLine, int toLine)
	{
		if (fromLine <= toLine)
		{
			int num = 0;
			for (int i = fromLine; i <= toLine; i++)
			{
				int startSpacesCount = textSource_0[i].StartSpacesCount;
				if (startSpacesCount > num)
				{
					num = startSpacesCount;
				}
			}
			return num;
		}
		return 0;
	}

	public virtual void Undo()
	{
		textSource_0.Manager.Undo();
		DoCaretVisible();
		Invalidate();
	}

	public virtual void Redo()
	{
		Class76.smethod_553(textSource_0.Manager);
		DoCaretVisible();
		Invalidate();
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if (keyData != Keys.Tab || AcceptsTab)
		{
			if (keyData != Keys.Return || AcceptsReturn)
			{
				if ((keyData & Keys.Alt) == 0)
				{
					Keys keys = keyData & Keys.KeyCode;
					if (keys == Keys.Return)
					{
						return true;
					}
				}
				if ((keyData & Keys.Alt) != Keys.Alt)
				{
					switch (keyData & Keys.KeyCode)
					{
					case Keys.Tab:
						return (keyData & Keys.Control) == 0;
					case Keys.Escape:
						return false;
					case Keys.Prior:
					case Keys.Next:
					case Keys.End:
					case Keys.Home:
					case Keys.Left:
					case Keys.Up:
					case Keys.Right:
					case Keys.Down:
						return true;
					}
				}
				return base.IsInputKey(keyData);
			}
			return false;
		}
		return false;
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		if (BackBrush != null)
		{
			e.Graphics.FillRectangle(BackBrush, base.ClientRectangle);
		}
		else
		{
			base.OnPaintBackground(e);
		}
	}

	public void DrawText(Graphics gr, Place start, Size size)
	{
		if (needRecalc)
		{
			Class76.smethod_722(this);
		}
		if (bool_9)
		{
			RecalcFoldingLines();
		}
		Point point = PlaceToPoint(start);
		int num = point.Y + base.VerticalScroll.Value;
		int num2 = point.X + base.HorizontalScroll.Value - LeftIndent - Paddings.Left;
		int iChar = start.iChar;
		int num3 = (num2 + size.Width) / CharWidth;
		int iLine = start.iLine;
		for (int i = iLine; i < textSource_0.Count; i++)
		{
			Line line = textSource_0[i];
			LineInfo lineInfo = LineInfos[i];
			if (lineInfo.startY > num + size.Height)
			{
				break;
			}
			if (lineInfo.startY + lineInfo.WordWrapStringsCount * CharHeight >= num && lineInfo.VisibleState != VisibleState.Hidden)
			{
				int num4 = lineInfo.startY - num;
				gr.SmoothingMode = SmoothingMode.None;
				if (lineInfo.VisibleState == VisibleState.Visible && line.BackgroundBrush != null)
				{
					gr.FillRectangle(line.BackgroundBrush, new Rectangle(0, num4, size.Width, CharHeight * lineInfo.WordWrapStringsCount));
				}
				gr.SmoothingMode = SmoothingMode.AntiAlias;
				for (int j = 0; j < lineInfo.WordWrapStringsCount; j++)
				{
					num4 = lineInfo.startY + j * CharHeight - num;
					int num5 = ((j != 0) ? (lineInfo.int_1 * CharWidth) : 0);
					Class76.smethod_675(-num2 + num5, j, iChar, gr, num4, num3, i, this);
				}
			}
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (needRecalc)
		{
			Class76.smethod_722(this);
		}
		if (bool_9)
		{
			RecalcFoldingLines();
		}
		list_0.Clear();
		e.Graphics.SmoothingMode = SmoothingMode.None;
		Pen pen = new Pen(ServiceLinesColor);
		Brush brush = new SolidBrush(ChangedLineColor);
		Brush brush2 = new SolidBrush(IndentBackColor);
		Brush brush3 = new SolidBrush(PaddingBackColor);
		Brush brush4 = new SolidBrush(Color.FromArgb((CurrentLineColor.A != byte.MaxValue) ? CurrentLineColor.A : 50, CurrentLineColor));
		Rectangle textAreaRect = TextAreaRect;
		e.Graphics.FillRectangle(brush3, 0, -base.VerticalScroll.Value, base.ClientSize.Width, Math.Max(0, Paddings.Top - 1));
		e.Graphics.FillRectangle(brush3, 0, textAreaRect.Bottom, base.ClientSize.Width, base.ClientSize.Height);
		e.Graphics.FillRectangle(brush3, textAreaRect.Right, 0, base.ClientSize.Width, base.ClientSize.Height);
		e.Graphics.FillRectangle(brush3, Class76.smethod_612(this), 0, LeftIndent - Class76.smethod_612(this) - 1, base.ClientSize.Height);
		if (base.HorizontalScroll.Value <= Paddings.Left)
		{
			e.Graphics.FillRectangle(brush3, LeftIndent - base.HorizontalScroll.Value - 2, 0, Math.Max(0, Paddings.Left - 1), base.ClientSize.Height);
		}
		Math.Max(LeftIndent, LeftIndent + Paddings.Left - base.HorizontalScroll.Value);
		_ = textAreaRect.Width;
		e.Graphics.FillRectangle(brush2, 0, 0, Class76.smethod_612(this), base.ClientSize.Height);
		if (LeftIndent > 8)
		{
			e.Graphics.DrawLine(pen, Class76.smethod_612(this), 0, Class76.smethod_612(this), base.ClientSize.Height);
		}
		if (PreferredLineWidth > 0)
		{
			e.Graphics.DrawLine(pen, new Point(LeftIndent + Paddings.Left + PreferredLineWidth * CharWidth - base.HorizontalScroll.Value + 1, textAreaRect.Top + 1), new Point(LeftIndent + Paddings.Left + PreferredLineWidth * CharWidth - base.HorizontalScroll.Value + 1, textAreaRect.Bottom - 1));
		}
		Class76.smethod_636(this, e.Graphics);
		int num = Math.Max(0, base.HorizontalScroll.Value - Paddings.Left) / CharWidth;
		int num2 = (base.HorizontalScroll.Value + base.ClientSize.Width) / CharWidth;
		int num3 = LeftIndent + Paddings.Left - base.HorizontalScroll.Value;
		if (num3 < LeftIndent)
		{
			num++;
		}
		Dictionary<int, Bookmark> dictionary = new Dictionary<int, Bookmark>();
		foreach (Bookmark item in baseBookmarks_0)
		{
			dictionary[item.LineIndex] = item;
		}
		int num4 = Class76.smethod_53(this, base.VerticalScroll.Value);
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		int i;
		for (i = num4; i < textSource_0.Count; i++)
		{
			Line line = textSource_0[i];
			LineInfo lineInfo = LineInfos[i];
			if (lineInfo.startY > base.VerticalScroll.Value + base.ClientSize.Height)
			{
				break;
			}
			if (lineInfo.startY + lineInfo.WordWrapStringsCount * CharHeight < base.VerticalScroll.Value || lineInfo.VisibleState == VisibleState.Hidden)
			{
				continue;
			}
			int num5 = lineInfo.startY - base.VerticalScroll.Value;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			if (lineInfo.VisibleState == VisibleState.Visible && line.BackgroundBrush != null)
			{
				e.Graphics.FillRectangle(line.BackgroundBrush, new Rectangle(textAreaRect.Left, num5, textAreaRect.Width, CharHeight * lineInfo.WordWrapStringsCount));
			}
			if (CurrentLineColor != Color.Transparent && i == Selection.Start.iLine && Selection.IsEmpty)
			{
				e.Graphics.FillRectangle(brush4, new Rectangle(textAreaRect.Left, num5, textAreaRect.Width, CharHeight));
			}
			if (ChangedLineColor != Color.Transparent && line.IsChanged)
			{
				e.Graphics.FillRectangle(brush, new RectangleF(-10f, num5, LeftIndent - 8 - 2 + 10, CharHeight + 1));
			}
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (dictionary.ContainsKey(i))
			{
				dictionary[i].Paint(e.Graphics, new Rectangle(LeftIndent, num5, base.Width, CharHeight * lineInfo.WordWrapStringsCount));
			}
			if (lineInfo.VisibleState == VisibleState.Visible)
			{
				OnPaintLine(new PaintLineEventArgs(i, new Rectangle(LeftIndent, num5, base.Width, CharHeight * lineInfo.WordWrapStringsCount), e.Graphics, e.ClipRectangle));
			}
			if (ShowLineNumbers)
			{
				using SolidBrush brush5 = new SolidBrush(LineNumberColor);
				e.Graphics.DrawString((i + uint_0).ToString(), Font, brush5, new RectangleF(-10f, num5, LeftIndent - 8 - 2 + 10, CharHeight), new StringFormat(StringFormatFlags.DirectionRightToLeft));
			}
			if (lineInfo.VisibleState == VisibleState.StartOfHiddenBlock)
			{
				list_0.Add(new ExpandFoldingMarker(i, new Rectangle(Class76.smethod_612(this) - 4, num5 + CharHeight / 2 - 3, 8, 8)));
			}
			if (!string.IsNullOrEmpty(line.FoldingStartMarker) && lineInfo.VisibleState == VisibleState.Visible && string.IsNullOrEmpty(line.FoldingEndMarker))
			{
				list_0.Add(new CollapseFoldingMarker(i, new Rectangle(Class76.smethod_612(this) - 4, num5 + CharHeight / 2 - 3, 8, 8)));
			}
			if (lineInfo.VisibleState == VisibleState.Visible && !string.IsNullOrEmpty(line.FoldingEndMarker) && string.IsNullOrEmpty(line.FoldingStartMarker))
			{
				e.Graphics.DrawLine(pen, Class76.smethod_612(this), num5 + CharHeight * lineInfo.WordWrapStringsCount - 1, Class76.smethod_612(this) + 4, num5 + CharHeight * lineInfo.WordWrapStringsCount - 1);
			}
			for (int j = 0; j < lineInfo.WordWrapStringsCount; j++)
			{
				num5 = lineInfo.startY + j * CharHeight - base.VerticalScroll.Value;
				int num6 = ((j != 0) ? (lineInfo.int_1 * CharWidth) : 0);
				Class76.smethod_675(num3 + num6, j, num, e.Graphics, num5, num2, i, this);
			}
		}
		int endLine = i - 1;
		if (ShowFoldingLines)
		{
			DrawFoldingLines(e, num4, endLine);
		}
		if (Selection.ColumnSelectionMode && SelectionStyle.BackgroundBrush is SolidBrush)
		{
			Color color = ((SolidBrush)SelectionStyle.BackgroundBrush).Color;
			Point point = PlaceToPoint(Selection.Start);
			Point point2 = PlaceToPoint(Selection.End);
			using Pen pen2 = new Pen(color);
			e.Graphics.DrawRectangle(pen2, Rectangle.FromLTRB(Math.Min(point.X, point2.X) - 1, Math.Min(point.Y, point2.Y), Math.Max(point.X, point2.X), Math.Max(point.Y, point2.Y) + CharHeight));
		}
		if (BracketsStyle != null && range_2 != null && range_4 != null)
		{
			BracketsStyle.Draw(e.Graphics, PlaceToPoint(range_2.Start), range_2);
			BracketsStyle.Draw(e.Graphics, PlaceToPoint(range_4.Start), range_4);
		}
		if (BracketsStyle2 != null && range_3 != null && range_5 != null)
		{
			BracketsStyle2.Draw(e.Graphics, PlaceToPoint(range_3.Start), range_3);
			BracketsStyle2.Draw(e.Graphics, PlaceToPoint(range_5.Start), range_5);
		}
		e.Graphics.SmoothingMode = SmoothingMode.None;
		if ((int_7 >= 0 || int_1 >= 0) && Selection.Start == Selection.End && int_1 < LineInfos.Count)
		{
			int y = ((int_7 >= 0) ? LineInfos[int_7].startY : 0) - base.VerticalScroll.Value + CharHeight / 2;
			int y2 = ((int_1 < 0) ? (TextHeight + CharHeight) : (LineInfos[int_1].startY + (LineInfos[int_1].WordWrapStringsCount - 1) * CharHeight)) - base.VerticalScroll.Value + CharHeight;
			using Pen pen3 = new Pen(Color.FromArgb(100, FoldingIndicatorColor), 4f);
			e.Graphics.DrawLine(pen3, LeftIndent - 5, y, LeftIndent - 5, y2);
		}
		Class76.smethod_533(this, e.Graphics);
		method_13(e, pen);
		Point point3 = PlaceToPoint(Selection.Start);
		int num7 = CharHeight - int_3;
		point3.Offset(0, int_3 / 2);
		if ((!Focused && !method_20() && !ShowCaretWhenInactive) || point3.X < LeftIndent || !CaretVisible)
		{
			Class76.HideCaret(base.Handle);
			rectangle_0 = Rectangle.Empty;
		}
		else
		{
			int num8 = ((!IsReplaceMode && !WideCaret) ? 1 : CharWidth);
			if (!WideCaret)
			{
				using Pen pen4 = new Pen(CaretColor);
				e.Graphics.DrawLine(pen4, point3.X, point3.Y, point3.X, point3.Y + num7);
			}
			else
			{
				using SolidBrush brush6 = new SolidBrush(CaretColor);
				e.Graphics.FillRectangle(brush6, point3.X, point3.Y, num8, num7 + 1);
			}
			Rectangle rectangle = new Rectangle(base.HorizontalScroll.Value + point3.X, base.VerticalScroll.Value + point3.Y, num8, num7 + 1);
			if (CaretBlinking && (rectangle_0 != rectangle || !ShowScrollBars))
			{
				Class76.CreateCaret(base.Handle, 0, num8, num7 + 1);
				Class76.SetCaretPos(point3.X, point3.Y);
				Class76.ShowCaret(base.Handle);
			}
			rectangle_0 = rectangle;
		}
		if (!base.Enabled)
		{
			using SolidBrush brush7 = new SolidBrush(DisabledColor);
			e.Graphics.FillRectangle(brush7, base.ClientRectangle);
		}
		if (MacrosManager.IsRecording)
		{
			Class76.smethod_78(this, e.Graphics);
		}
		if (bool_33)
		{
			Class76.smethod_849(this, e.Graphics);
		}
		pen.Dispose();
		brush.Dispose();
		brush2.Dispose();
		brush4.Dispose();
		brush3.Dispose();
		base.OnPaint(e);
	}

	private void method_13(PaintEventArgs paintEventArgs_0, Pen pen_0)
	{
		foreach (VisualMarker item in list_0)
		{
			if (ServiceColors == null)
			{
				ServiceColors = new ServiceColors();
			}
			if (!(item is CollapseFoldingMarker))
			{
				if (!(item is ExpandFoldingMarker))
				{
					item.Draw(paintEventArgs_0.Graphics, pen_0);
					continue;
				}
				using (SolidBrush backgroundBrush = new SolidBrush(ServiceColors.ExpandMarkerBackColor))
				{
					using Pen forePen = new Pen(ServiceColors.ExpandMarkerForeColor);
					using Pen pen = new Pen(ServiceColors.ExpandMarkerBorderColor);
					(item as ExpandFoldingMarker).Draw(paintEventArgs_0.Graphics, pen, backgroundBrush, forePen);
				}
				continue;
			}
			using SolidBrush backgroundBrush2 = new SolidBrush(ServiceColors.CollapseMarkerBackColor);
			using Pen forePen2 = new Pen(ServiceColors.CollapseMarkerForeColor);
			using Pen pen2 = new Pen(ServiceColors.CollapseMarkerBorderColor);
			(item as CollapseFoldingMarker).Draw(paintEventArgs_0.Graphics, pen2, backgroundBrush2, forePen2);
		}
	}

	protected virtual void DrawFoldingLines(PaintEventArgs e, int startLine, int endLine)
	{
		e.Graphics.SmoothingMode = SmoothingMode.None;
		using Pen pen = new Pen(Color.FromArgb(200, ServiceLinesColor))
		{
			DashStyle = DashStyle.Dot
		};
		foreach (KeyValuePair<int, int> foldingPair in foldingPairs)
		{
			if (foldingPair.Key >= endLine || foldingPair.Value <= startLine)
			{
				continue;
			}
			Line line = textSource_0[foldingPair.Key];
			int num = LineInfos[foldingPair.Key].startY - base.VerticalScroll.Value + CharHeight;
			num += num % 2;
			int num3;
			if (foldingPair.Value < LinesCount)
			{
				if (LineInfos[foldingPair.Value].VisibleState != VisibleState.Visible)
				{
					continue;
				}
				int num2 = 0;
				int startSpacesCount = line.StartSpacesCount;
				if (textSource_0[foldingPair.Value].Count <= startSpacesCount || textSource_0[foldingPair.Value][startSpacesCount].c == ' ')
				{
					num2 = CharHeight;
				}
				num3 = LineInfos[foldingPair.Value].startY - base.VerticalScroll.Value + num2;
			}
			else
			{
				num3 = LineInfos[LinesCount - 1].startY + CharHeight - base.VerticalScroll.Value;
			}
			int num4 = LeftIndent + Paddings.Left + line.StartSpacesCount * CharWidth - base.HorizontalScroll.Value;
			if (num4 >= LeftIndent + Paddings.Left)
			{
				e.Graphics.DrawLine(pen, num4, (num >= 0) ? num : 0, num4, (num3 >= base.ClientSize.Height) ? base.ClientSize.Height : num3);
			}
		}
	}

	protected override void OnEnter(EventArgs e)
	{
		base.OnEnter(e);
		bool_6 = false;
		bool_7 = false;
		draggedRange = null;
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		bool_4 = false;
		if (e.Button == MouseButtons.Left && bool_7)
		{
			method_14(e);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (!bool_33)
		{
			MacrosManager.IsRecording = false;
			Select();
			base.ActiveControl = null;
			if (e.Button != MouseButtons.Left)
			{
				if (e.Button == MouseButtons.Middle)
				{
					method_22(e);
				}
				return;
			}
			VisualMarker visualMarker = method_18(e.Location);
			if (visualMarker == null)
			{
				bool_6 = true;
				bool_7 = false;
				draggedRange = null;
				bool_4 = e.Location.X < Class76.smethod_612(this);
				if (bool_4)
				{
					CheckAndChangeSelectionType();
					Selection.BeginUpdate();
					int iLine = (int_4 = Class76.smethod_105(this, e.Location).iLine);
					Selection.Start = new Place(0, iLine);
					Selection.End = new Place(GetLineLength(iLine), iLine);
					Selection.EndUpdate();
					Invalidate();
					return;
				}
				Place place = PointToPlace(e.Location);
				if (e.Clicks != 2)
				{
					if (!Selection.IsEmpty && Selection.Contains(place) && this[place.iLine].Count > place.iChar && !ReadOnly)
					{
						bool_7 = true;
						bool_6 = false;
					}
					else
					{
						method_14(e);
					}
				}
				else
				{
					bool_6 = false;
					bool_7 = false;
					draggedRange = null;
					Class76.smethod_141(this, place);
				}
			}
			else
			{
				bool_6 = false;
				bool_7 = false;
				draggedRange = null;
				OnMarkerClick(e, visualMarker);
			}
		}
		else
		{
			method_23();
			bool_6 = false;
			if (e.Button == MouseButtons.Middle)
			{
				method_24();
			}
		}
	}

	private void method_14(MouseEventArgs mouseEventArgs_0)
	{
		Place end = Selection.End;
		Selection.BeginUpdate();
		if (!Selection.ColumnSelectionMode)
		{
			if (!VirtualSpace)
			{
				Selection.Start = PointToPlace(mouseEventArgs_0.Location);
			}
			else
			{
				Selection.Start = Class76.smethod_105(this, mouseEventArgs_0.Location);
			}
		}
		else
		{
			Selection.Start = Class76.smethod_105(this, mouseEventArgs_0.Location);
			Selection.ColumnSelectionMode = true;
		}
		if ((keys_0 & Keys.Shift) != Keys.None)
		{
			Selection.End = end;
		}
		CheckAndChangeSelectionType();
		Selection.EndUpdate();
		Invalidate();
	}

	protected virtual void CheckAndChangeSelectionType()
	{
		if ((Control.ModifierKeys & Keys.Alt) == 0 || WordWrap)
		{
			Selection.ColumnSelectionMode = false;
		}
		else
		{
			Selection.ColumnSelectionMode = true;
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		Invalidate();
		if (keys_0 != Keys.Control)
		{
			if (base.VerticalScroll.Visible || !ShowScrollBars)
			{
				int int_ = Class76.smethod_734();
				method_15(int_, e.Delta);
				((HandledMouseEventArgs)e).Handled = true;
			}
		}
		else
		{
			ChangeFontSize(2 * Math.Sign(e.Delta));
			((HandledMouseEventArgs)e).Handled = true;
		}
		method_23();
	}

	private void method_15(int int_16, int int_17)
	{
		if (base.VerticalScroll.Visible || !ShowScrollBars)
		{
			int num = base.ClientSize.Height / CharHeight;
			int num2 = ((int_16 == -1 || int_16 > num) ? (CharHeight * num) : (CharHeight * int_16));
			int newValue = base.VerticalScroll.Value - Math.Sign(int_17) * num2;
			ScrollEventArgs se = new ScrollEventArgs((int_17 <= 0) ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, base.VerticalScroll.Value, newValue, ScrollOrientation.VerticalScroll);
			OnScroll(se);
		}
	}

	public void ChangeFontSize(int step)
	{
		float sizeInPoints = Font.SizeInPoints;
		using Graphics graphics = Graphics.FromHwnd(base.Handle);
		float dpiY = graphics.DpiY;
		float num = sizeInPoints + (float)step * 72f / dpiY;
		if (!(num < 1f))
		{
			float num2 = num / font_1.SizeInPoints;
			Zoom = (int)(100f * num2);
		}
	}

	protected virtual void OnZoomChanged()
	{
		if (eventHandler_18 != null)
		{
			eventHandler_18(this, EventArgs.Empty);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		Class76.smethod_324(this);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (bool_33)
		{
			return;
		}
		if (point_0 != e.Location)
		{
			Class76.smethod_324(this);
			timer_2.Start();
		}
		point_0 = e.Location;
		if (e.Button != MouseButtons.Left || !bool_7)
		{
			if (e.Button == MouseButtons.Left && bool_6)
			{
				Place place = ((Selection.ColumnSelectionMode || VirtualSpace) ? Class76.smethod_105(this, e.Location) : PointToPlace(e.Location));
				if (!bool_4)
				{
					if (place != Selection.Start)
					{
						Place end = Selection.End;
						Selection.BeginUpdate();
						if (!Selection.ColumnSelectionMode)
						{
							Selection.Start = place;
						}
						else
						{
							Selection.Start = place;
							Selection.ColumnSelectionMode = true;
						}
						Selection.End = end;
						Selection.EndUpdate();
						DoCaretVisible();
						Invalidate();
						return;
					}
				}
				else
				{
					Selection.BeginUpdate();
					int iLine = place.iLine;
					if (iLine >= int_4)
					{
						Selection.Start = new Place(GetLineLength(iLine), iLine);
						Selection.End = new Place(0, int_4);
					}
					else
					{
						Selection.Start = new Place(0, iLine);
						Selection.End = new Place(GetLineLength(int_4), int_4);
					}
					Selection.EndUpdate();
					DoCaretVisible();
					base.HorizontalScroll.Value = 0;
					UpdateScrollbars();
					Invalidate();
				}
			}
			VisualMarker visualMarker = method_18(e.Location);
			if (visualMarker == null)
			{
				if (e.Location.X >= Class76.smethod_612(this) && !bool_4)
				{
					base.Cursor = cursor_0;
				}
				else
				{
					base.Cursor = Cursors.Arrow;
				}
			}
			else
			{
				base.Cursor = visualMarker.Cursor;
			}
		}
		else
		{
			draggedRange = Selection.Clone();
			DoDragDrop(SelectedText, DragDropEffects.Copy);
			draggedRange = null;
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		VisualMarker visualMarker = method_18(e.Location);
		if (visualMarker != null)
		{
			OnMarkerDoubleClick(visualMarker);
		}
	}

	public Place PointToPlace(Point point)
	{
		point.Offset(base.HorizontalScroll.Value, base.VerticalScroll.Value);
		point.Offset(-LeftIndent - Paddings.Left, 0);
		int i = Class76.smethod_53(this, point.Y);
		if (i >= 0)
		{
			int num = 0;
			for (; i < textSource_0.Count; i++)
			{
				num = LineInfos[i].startY + LineInfos[i].WordWrapStringsCount * CharHeight;
				if (num > point.Y && LineInfos[i].VisibleState == VisibleState.Visible)
				{
					break;
				}
			}
			if (i >= textSource_0.Count)
			{
				i = textSource_0.Count - 1;
			}
			if (LineInfos[i].VisibleState != VisibleState.Visible)
			{
				i = Class76.smethod_735(this, i);
			}
			int num2 = LineInfos[i].WordWrapStringsCount;
			do
			{
				num2--;
				num -= CharHeight;
			}
			while (num > point.Y);
			if (num2 < 0)
			{
				num2 = 0;
			}
			int num3 = LineInfos[i].method_0(num2);
			int num4 = LineInfos[i].method_1(num2, textSource_0[i]);
			int num5 = (int)Math.Round((float)point.X / (float)CharWidth);
			if (num2 > 0)
			{
				num5 -= LineInfos[i].int_1;
			}
			num5 = ((num5 >= 0) ? (num3 + num5) : num3);
			if (num5 > num4)
			{
				num5 = num4 + 1;
			}
			if (num5 > textSource_0[i].Count)
			{
				num5 = textSource_0[i].Count;
			}
			return new Place(num5, i);
		}
		return Place.Empty;
	}

	public int PointToPosition(Point point)
	{
		return PlaceToPosition(PointToPlace(point));
	}

	public virtual void OnTextChanging(ref string text)
	{
		Class76.smethod_808(this);
		if (eventHandler_5 != null)
		{
			TextChangingEventArgs e = new TextChangingEventArgs
			{
				InsertingText = text
			};
			eventHandler_5(this, e);
			text = e.InsertingText;
			if (e.Cancel)
			{
				text = string.Empty;
			}
		}
	}

	public virtual void OnTextChanging()
	{
		string text = null;
		OnTextChanging(ref text);
	}

	public virtual void OnTextChanged()
	{
		Range range = new Range(this);
		range.SelectAll();
		OnTextChanged(new TextChangedEventArgs(range));
	}

	public virtual void OnTextChanged(int fromLine, int toLine)
	{
		Range range = new Range(this);
		range.Start = new Place(0, Math.Min(fromLine, toLine));
		range.End = new Place(textSource_0[Math.Max(fromLine, toLine)].Count, Math.Max(fromLine, toLine));
		OnTextChanged(new TextChangedEventArgs(range));
	}

	public virtual void OnTextChanged(Range r)
	{
		OnTextChanged(new TextChangedEventArgs(r));
	}

	public void BeginUpdate()
	{
		if (int_8 == 0)
		{
			range_6 = null;
		}
		int_8++;
	}

	public void EndUpdate()
	{
		int_8--;
		if (int_8 == 0 && range_6 != null)
		{
			range_6.Expand();
			OnTextChanged(range_6);
		}
	}

	protected virtual void OnTextChanged(TextChangedEventArgs args)
	{
		args.ChangedRange.Normalize();
		if (int_8 <= 0)
		{
			Class76.smethod_324(this);
			ClearHints();
			IsChanged = true;
			TextVersion++;
			Class76.smethod_644(args.ChangedRange, this);
			Class76.smethod_323(this, args.ChangedRange);
			if (bool_16)
			{
				int iLine = args.ChangedRange.Start.iLine;
				int iLine2 = args.ChangedRange.End.iLine;
				Class76.smethod_638(iLine, this, iLine2);
			}
			base.OnTextChanged(args);
			if (range_1 != null)
			{
				range_1 = range_1.GetUnionWith(args.ChangedRange);
			}
			else
			{
				range_1 = args.ChangedRange.Clone();
			}
			bool_11 = true;
			method_8(timer_1);
			OnSyntaxHighlight(args);
			if (eventHandler_2 != null)
			{
				eventHandler_2(this, args);
			}
			if (eventHandler_3 != null)
			{
				eventHandler_3(this, EventArgs.Empty);
			}
			base.OnTextChanged(EventArgs.Empty);
			OnVisibleRangeChanged();
		}
		else if (range_6 != null)
		{
			if (range_6.Start.iLine > args.ChangedRange.Start.iLine)
			{
				range_6.Start = new Place(0, args.ChangedRange.Start.iLine);
			}
			if (range_6.End.iLine < args.ChangedRange.End.iLine)
			{
				range_6.End = new Place(textSource_0[args.ChangedRange.End.iLine].Count, args.ChangedRange.End.iLine);
			}
			range_6 = range_6.GetIntersectionWith(Range);
		}
		else
		{
			range_6 = args.ChangedRange.Clone();
		}
	}

	public virtual void OnSelectionChanged()
	{
		if (HighlightFoldingIndicator)
		{
			method_16();
		}
		bool_10 = true;
		method_8(timer_0);
		if (eventHandler_6 != null)
		{
			eventHandler_6(this, new EventArgs());
		}
	}

	private void method_16()
	{
		if (LinesCount == 0)
		{
			return;
		}
		int num = int_7;
		int num2 = int_1;
		int_7 = -1;
		int_1 = -1;
		int num3 = 0;
		for (int num4 = Selection.Start.iLine; num4 >= Math.Max(Selection.Start.iLine - 3000, 0); num4--)
		{
			bool flag = textSource_0.LineHasFoldingStartMarker(num4);
			bool flag2;
			if (!((flag2 = textSource_0.LineHasFoldingEndMarker(num4)) && flag))
			{
				if (flag)
				{
					num3--;
					if (num3 == -1)
					{
						int_7 = num4;
						break;
					}
				}
				if (flag2 && num4 != Selection.Start.iLine)
				{
					num3++;
				}
			}
		}
		if (int_7 >= 0)
		{
			int_1 = FindEndOfFoldingBlock(int_7, 3000);
			if (int_1 == int_7)
			{
				int_1 = -1;
			}
		}
		if (int_7 != num || int_1 != num2)
		{
			OnFoldingHighlightChanged();
		}
	}

	protected virtual void OnFoldingHighlightChanged()
	{
		if (eventHandler_16 != null)
		{
			eventHandler_16(this, EventArgs.Empty);
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		Class76.smethod_298(this);
		base.OnGotFocus(e);
		Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		keys_0 = Keys.None;
		method_23();
		base.OnLostFocus(e);
		Invalidate();
	}

	public int PlaceToPosition(Place point)
	{
		if (point.iLine >= 0 && point.iLine < textSource_0.Count && point.iChar < textSource_0[point.iLine].Count + Environment.NewLine.Length)
		{
			int num = 0;
			for (int i = 0; i < point.iLine; i++)
			{
				num += textSource_0[i].Count + Environment.NewLine.Length;
			}
			return num + point.iChar;
		}
		return -1;
	}

	public Place PositionToPlace(int pos)
	{
		if (pos >= 0)
		{
			for (int i = 0; i < textSource_0.Count; i++)
			{
				int num = textSource_0[i].Count + Environment.NewLine.Length;
				if (pos >= textSource_0[i].Count)
				{
					if (pos >= num)
					{
						pos -= num;
						continue;
					}
					return new Place(textSource_0[i].Count, i);
				}
				return new Place(pos, i);
			}
			if (textSource_0.Count <= 0)
			{
				return new Place(0, 0);
			}
			return new Place(textSource_0[textSource_0.Count - 1].Count, textSource_0.Count - 1);
		}
		return new Place(0, 0);
	}

	public Point PositionToPoint(int pos)
	{
		return PlaceToPoint(PositionToPlace(pos));
	}

	public Point PlaceToPoint(Place place)
	{
		if (place.iLine < LineInfos.Count)
		{
			int startY = LineInfos[place.iLine].startY;
			int wordWrapStringIndex = LineInfos[place.iLine].GetWordWrapStringIndex(place.iChar);
			startY += wordWrapStringIndex * CharHeight;
			int num = (place.iChar - LineInfos[place.iLine].method_0(wordWrapStringIndex)) * CharWidth;
			if (wordWrapStringIndex > 0)
			{
				num += LineInfos[place.iLine].int_1 * CharWidth;
			}
			startY -= base.VerticalScroll.Value;
			num = LeftIndent + Paddings.Left + num - base.HorizontalScroll.Value;
			return new Point(num, startY);
		}
		return default(Point);
	}

	public Range GetRange(int fromPos, int toPos)
	{
		Range range = new Range(this);
		range.Start = PositionToPlace(fromPos);
		range.End = PositionToPlace(toPos);
		return range;
	}

	public Range GetRange(Place fromPlace, Place toPlace)
	{
		return new Range(this, fromPlace, toPlace);
	}

	[IteratorStateMachine(typeof(Class45))]
	public IEnumerable<Range> GetRanges(string regexPattern)
	{
		//yield-return decompiler failed: Method not found
		return new Class45(-2)
		{
			buMultiTextBox_0 = this,
			string_1 = regexPattern
		};
	}

	[IteratorStateMachine(typeof(Class46))]
	public IEnumerable<Range> GetRanges(string regexPattern, RegexOptions options)
	{
		//yield-return decompiler failed: Method not found
		return new Class46(-2)
		{
			buMultiTextBox_0 = this,
			string_1 = regexPattern,
			regexOptions_1 = options
		};
	}

	public string GetLineText(int iLine)
	{
		if (iLine >= 0 && iLine < textSource_0.Count)
		{
			StringBuilder stringBuilder = new StringBuilder(textSource_0[iLine].Count);
			foreach (Char item in textSource_0[iLine])
			{
				stringBuilder.Append(item.c);
			}
			return stringBuilder.ToString();
		}
		throw new ArgumentOutOfRangeException("Line index out of range");
	}

	public virtual void ExpandFoldedBlock(int iLine)
	{
		if (iLine >= 0 && iLine < textSource_0.Count)
		{
			int i;
			for (i = iLine; i < LinesCount - 1 && LineInfos[i + 1].VisibleState == VisibleState.Hidden; i++)
			{
			}
			ExpandBlock(iLine, i);
			FoldedBlocks.Remove(this[iLine].UniqueId);
			AdjustFolding();
			return;
		}
		throw new ArgumentOutOfRangeException("Line index out of range");
	}

	public virtual void AdjustFolding()
	{
		for (int i = 0; i < LinesCount; i++)
		{
			if (LineInfos[i].VisibleState == VisibleState.Visible && FoldedBlocks.ContainsKey(this[i].UniqueId))
			{
				CollapseFoldingBlock(i);
			}
		}
	}

	public virtual void ExpandBlock(int fromLine, int toLine)
	{
		int num = Math.Min(fromLine, toLine);
		int num2 = Math.Max(fromLine, toLine);
		for (int i = num; i <= num2; i++)
		{
			SetVisibleState(i, VisibleState.Visible);
		}
		needRecalc = true;
		Invalidate();
		OnVisibleRangeChanged();
	}

	public void ExpandBlock(int iLine)
	{
		if (LineInfos[iLine].VisibleState != VisibleState.Visible)
		{
			for (int i = iLine; i < LinesCount && LineInfos[i].VisibleState != VisibleState.Visible; i++)
			{
				SetVisibleState(i, VisibleState.Visible);
				needRecalc = true;
			}
			int num = iLine - 1;
			while (num >= 0 && LineInfos[num].VisibleState != VisibleState.Visible)
			{
				SetVisibleState(num, VisibleState.Visible);
				needRecalc = true;
				num--;
			}
			Invalidate();
			OnVisibleRangeChanged();
		}
	}

	public virtual void CollapseAllFoldingBlocks()
	{
		for (int i = 0; i < LinesCount; i++)
		{
			if (textSource_0.LineHasFoldingStartMarker(i))
			{
				int num = method_17(i);
				if (num >= 0)
				{
					CollapseBlock(i, num);
					i = num;
				}
			}
		}
		OnVisibleRangeChanged();
		UpdateScrollbars();
	}

	public virtual void ExpandAllFoldingBlocks()
	{
		for (int i = 0; i < LinesCount; i++)
		{
			SetVisibleState(i, VisibleState.Visible);
		}
		FoldedBlocks.Clear();
		OnVisibleRangeChanged();
		Invalidate();
		UpdateScrollbars();
	}

	public virtual void CollapseFoldingBlock(int iLine)
	{
		if (iLine >= 0 && iLine < textSource_0.Count)
		{
			if (!string.IsNullOrEmpty(textSource_0[iLine].FoldingStartMarker))
			{
				int num = method_17(iLine);
				if (num >= 0)
				{
					CollapseBlock(iLine, num);
					int uniqueId = this[iLine].UniqueId;
					FoldedBlocks[uniqueId] = uniqueId;
				}
				return;
			}
			throw new ArgumentOutOfRangeException("This line is not folding start line");
		}
		throw new ArgumentOutOfRangeException("Line index out of range");
	}

	private int method_17(int int_16)
	{
		return FindEndOfFoldingBlock(int_16, int.MaxValue);
	}

	protected virtual int FindEndOfFoldingBlock(int iStartLine, int maxLines)
	{
		_ = textSource_0[iStartLine].FoldingStartMarker;
		Stack<string> stack = new Stack<string>();
		switch (FindEndOfFoldingBlockStrategy)
		{
		case FindEndOfFoldingBlockStrategy.Strategy1:
		{
			for (int i = iStartLine; i < LinesCount; i++)
			{
				if (textSource_0.LineHasFoldingStartMarker(i))
				{
					stack.Push(textSource_0[i].FoldingStartMarker);
				}
				if (textSource_0.LineHasFoldingEndMarker(i))
				{
					string foldingEndMarker2 = textSource_0[i].FoldingEndMarker;
					while (stack.Count > 0 && stack.Pop() != foldingEndMarker2)
					{
					}
					if (stack.Count == 0)
					{
						return i;
					}
				}
				maxLines--;
				if (maxLines < 0)
				{
					return i;
				}
			}
			break;
		}
		case FindEndOfFoldingBlockStrategy.Strategy2:
		{
			for (int i = iStartLine; i < LinesCount; i++)
			{
				if (textSource_0.LineHasFoldingEndMarker(i))
				{
					string foldingEndMarker = textSource_0[i].FoldingEndMarker;
					while (stack.Count > 0 && stack.Pop() != foldingEndMarker)
					{
					}
					if (stack.Count == 0)
					{
						return i;
					}
				}
				if (textSource_0.LineHasFoldingStartMarker(i))
				{
					stack.Push(textSource_0[i].FoldingStartMarker);
				}
				maxLines--;
				if (maxLines < 0)
				{
					return i;
				}
			}
			break;
		}
		}
		return LinesCount - 1;
	}

	public string GetLineFoldingStartMarker(int iLine)
	{
		if (!textSource_0.LineHasFoldingStartMarker(iLine))
		{
			return null;
		}
		return textSource_0[iLine].FoldingStartMarker;
	}

	public string GetLineFoldingEndMarker(int iLine)
	{
		if (!textSource_0.LineHasFoldingEndMarker(iLine))
		{
			return null;
		}
		return textSource_0[iLine].FoldingEndMarker;
	}

	protected virtual void RecalcFoldingLines()
	{
		if (!bool_9)
		{
			return;
		}
		bool_9 = false;
		if (!ShowFoldingLines)
		{
			return;
		}
		foldingPairs.Clear();
		Range visibleRange = VisibleRange;
		int num = Math.Max(visibleRange.Start.iLine - 3000, 0);
		int num2 = Math.Min(visibleRange.End.iLine + 3000, Math.Max(visibleRange.End.iLine, LinesCount - 1));
		Stack<int> stack = new Stack<int>();
		for (int i = num; i <= num2; i++)
		{
			bool flag = textSource_0.LineHasFoldingStartMarker(i);
			bool flag2;
			if ((flag2 = textSource_0.LineHasFoldingEndMarker(i)) && flag)
			{
				continue;
			}
			if (flag)
			{
				stack.Push(i);
			}
			if (!flag2)
			{
				continue;
			}
			string foldingEndMarker = textSource_0[i].FoldingEndMarker;
			while (stack.Count > 0)
			{
				int num3 = stack.Pop();
				foldingPairs[num3] = i;
				if (foldingEndMarker == textSource_0[num3].FoldingStartMarker)
				{
					break;
				}
			}
		}
		while (stack.Count > 0)
		{
			foldingPairs[stack.Pop()] = num2 + 1;
		}
	}

	public virtual void CollapseBlock(int fromLine, int toLine)
	{
		int i = Math.Min(fromLine, toLine);
		int num = Math.Max(fromLine, toLine);
		if (i == num)
		{
			return;
		}
		for (; i <= num; i++)
		{
			if (GetLineText(i).Trim().Length > 0)
			{
				for (int j = i + 1; j <= num; j++)
				{
					SetVisibleState(j, VisibleState.Hidden);
				}
				SetVisibleState(i, VisibleState.StartOfHiddenBlock);
				Invalidate();
				break;
			}
		}
		i = Math.Min(fromLine, toLine);
		num = Math.Max(fromLine, toLine);
		int num2 = Class76.smethod_97(this, num);
		if (num2 == num)
		{
			num2 = Class76.smethod_735(this, i);
		}
		Selection.Start = new Place(0, num2);
		needRecalc = true;
		Invalidate();
		OnVisibleRangeChanged();
	}

	private VisualMarker method_18(Point point_4)
	{
		foreach (VisualMarker item in list_0)
		{
			if (item.rectangle.Contains(point_4))
			{
				return item;
			}
		}
		return null;
	}

	public virtual void IncreaseIndent()
	{
		if (!(Selection.Start == Selection.End))
		{
			bool flag = Selection.Start > Selection.End && !Selection.ColumnSelectionMode;
			int iChar = 0;
			if (Selection.ColumnSelectionMode)
			{
				iChar = Math.Min(Selection.End.iChar, Selection.Start.iChar);
			}
			BeginUpdate();
			Selection.BeginUpdate();
			textSource_0.Manager.BeginAutoUndoCommands();
			Range selection = Selection.Clone();
			textSource_0.Manager.ExecuteCommand(new SelectCommand(TextSource));
			Selection.Normalize();
			Range range = Selection.Clone();
			int iLine = Selection.Start.iLine;
			int num = Selection.End.iLine;
			if (!Selection.ColumnSelectionMode && Selection.End.iChar == 0)
			{
				num--;
			}
			for (int i = iLine; i <= num; i++)
			{
				if (textSource_0[i].Count != 0)
				{
					Selection.Start = new Place(iChar, i);
					textSource_0.Manager.ExecuteCommand(new InsertTextCommand(TextSource, new string(' ', TabLength)));
				}
			}
			if (Selection.ColumnSelectionMode)
			{
				Selection = selection;
			}
			else
			{
				int iChar2 = range.Start.iChar + TabLength;
				int iChar3 = range.End.iChar + ((range.End.iLine == num) ? TabLength : 0);
				Selection.Start = new Place(iChar2, range.Start.iLine);
				Selection.End = new Place(iChar3, range.End.iLine);
			}
			textSource_0.Manager.EndAutoUndoCommands();
			if (flag)
			{
				Selection.Inverse();
			}
			needRecalc = true;
			Selection.EndUpdate();
			EndUpdate();
			Invalidate();
		}
		else
		{
			if (Selection.ReadOnly)
			{
				return;
			}
			Selection.Start = new Place(this[Selection.Start.iLine].StartSpacesCount, Selection.Start.iLine);
			int num2 = TabLength - Selection.Start.iChar % TabLength;
			if (IsReplaceMode)
			{
				for (int j = 0; j < num2; j++)
				{
					Selection.GoRight(shift: true);
				}
				Selection.Inverse();
			}
			InsertText(new string(' ', num2));
		}
	}

	public virtual void DecreaseIndent()
	{
		if (Selection.Start.iLine != Selection.End.iLine)
		{
			int num = 0;
			if (Selection.ColumnSelectionMode)
			{
				num = Math.Min(Selection.End.iChar, Selection.Start.iChar);
			}
			BeginUpdate();
			Selection.BeginUpdate();
			textSource_0.Manager.BeginAutoUndoCommands();
			Range selection = Selection.Clone();
			textSource_0.Manager.ExecuteCommand(new SelectCommand(TextSource));
			Range range = Selection.Clone();
			Selection.Normalize();
			int iLine = Selection.Start.iLine;
			int num2 = Selection.End.iLine;
			if (!Selection.ColumnSelectionMode && Selection.End.iChar == 0)
			{
				num2--;
			}
			int num3 = 0;
			int num4 = 0;
			for (int i = iLine; i <= num2; i++)
			{
				if (num <= textSource_0[i].Count)
				{
					int num5 = Math.Min(textSource_0[i].Count, num + TabLength);
					string text = textSource_0[i].Text.Substring(num, num5 - num);
					num5 = Math.Min(num5, num + text.Length - text.TrimStart().Length);
					Selection = new Range(this, new Place(num, i), new Place(num5, i));
					int num6 = num5 - num;
					if (i == range.Start.iLine)
					{
						num3 = num6;
					}
					if (i == range.End.iLine)
					{
						num4 = num6;
					}
					if (!Selection.IsEmpty)
					{
						ClearSelected();
					}
				}
			}
			if (Selection.ColumnSelectionMode)
			{
				Selection = selection;
			}
			else
			{
				int iChar = Math.Max(0, range.Start.iChar - num3);
				int iChar2 = Math.Max(0, range.End.iChar - num4);
				Selection.Start = new Place(iChar, range.Start.iLine);
				Selection.End = new Place(iChar2, range.End.iLine);
			}
			textSource_0.Manager.EndAutoUndoCommands();
			needRecalc = true;
			Selection.EndUpdate();
			EndUpdate();
			Invalidate();
		}
		else
		{
			DecreaseIndentOfSingleLine();
		}
	}

	protected virtual void DecreaseIndentOfSingleLine()
	{
		if (Selection.Start.iLine == Selection.End.iLine)
		{
			Range range = Selection.Clone();
			int iLine = Selection.Start.iLine;
			int num = Math.Min(Selection.Start.iChar, Selection.End.iChar);
			string input = textSource_0[iLine].Text;
			Match match = new Regex("\\s*", RegexOptions.RightToLeft).Match(input, num);
			int index = match.Index;
			int length = match.Length;
			int num2 = 0;
			if (length > 0)
			{
				int num3 = ((TabLength > 0) ? (num % TabLength) : 0);
				num2 = ((num3 == 0) ? Math.Min(TabLength, length) : Math.Min(num3, length));
			}
			if (num2 > 0)
			{
				BeginUpdate();
				Selection.BeginUpdate();
				textSource_0.Manager.BeginAutoUndoCommands();
				textSource_0.Manager.ExecuteCommand(new SelectCommand(TextSource));
				Selection.Start = new Place(index, iLine);
				Selection.End = new Place(index + num2, iLine);
				ClearSelected();
				int iChar = range.Start.iChar - num2;
				int iChar2 = range.End.iChar - num2;
				Selection.Start = new Place(iChar, iLine);
				Selection.End = new Place(iChar2, iLine);
				textSource_0.Manager.ExecuteCommand(new SelectCommand(TextSource));
				textSource_0.Manager.EndAutoUndoCommands();
				Selection.EndUpdate();
				EndUpdate();
			}
			Invalidate();
		}
	}

	public virtual void DoAutoIndent()
	{
		if (!Selection.ColumnSelectionMode)
		{
			Range range = Selection.Clone();
			range.Normalize();
			BeginUpdate();
			Selection.BeginUpdate();
			textSource_0.Manager.BeginAutoUndoCommands();
			for (int i = range.Start.iLine; i <= range.End.iLine; i++)
			{
				DoAutoIndent(i);
			}
			textSource_0.Manager.EndAutoUndoCommands();
			Selection.Start = range.Start;
			Selection.End = range.End;
			Selection.Expand();
			Selection.EndUpdate();
			EndUpdate();
		}
	}

	public virtual void InsertLinePrefix(string prefix)
	{
		Selection.Clone();
		int num = Math.Min(Selection.Start.iLine, Selection.End.iLine);
		int num2 = Math.Max(Selection.Start.iLine, Selection.End.iLine);
		BeginUpdate();
		Selection.BeginUpdate();
		textSource_0.Manager.BeginAutoUndoCommands();
		textSource_0.Manager.ExecuteCommand(new SelectCommand(TextSource));
		int minStartSpacesCount = GetMinStartSpacesCount(num, num2);
		for (int i = num; i <= num2; i++)
		{
			Selection.Start = new Place(minStartSpacesCount, i);
			textSource_0.Manager.ExecuteCommand(new InsertTextCommand(TextSource, prefix));
		}
		Selection.Start = new Place(0, num);
		Selection.End = new Place(textSource_0[num2].Count, num2);
		needRecalc = true;
		textSource_0.Manager.EndAutoUndoCommands();
		Selection.EndUpdate();
		EndUpdate();
		Invalidate();
	}

	public virtual void RemoveLinePrefix(string prefix)
	{
		Selection.Clone();
		int num = Math.Min(Selection.Start.iLine, Selection.End.iLine);
		int num2 = Math.Max(Selection.Start.iLine, Selection.End.iLine);
		BeginUpdate();
		Selection.BeginUpdate();
		textSource_0.Manager.BeginAutoUndoCommands();
		textSource_0.Manager.ExecuteCommand(new SelectCommand(TextSource));
		for (int i = num; i <= num2; i++)
		{
			string text = textSource_0[i].Text;
			string text2 = text.TrimStart();
			if (text2.StartsWith(prefix))
			{
				int num3 = text.Length - text2.Length;
				Selection.Start = new Place(num3, i);
				Selection.End = new Place(num3 + prefix.Length, i);
				ClearSelected();
			}
		}
		Selection.Start = new Place(0, num);
		Selection.End = new Place(textSource_0[num2].Count, num2);
		needRecalc = true;
		textSource_0.Manager.EndAutoUndoCommands();
		Selection.EndUpdate();
		EndUpdate();
	}

	public void BeginAutoUndo()
	{
		textSource_0.Manager.BeginAutoUndoCommands();
	}

	public void EndAutoUndo()
	{
		textSource_0.Manager.EndAutoUndoCommands();
	}

	public virtual void OnVisualMarkerClick(MouseEventArgs args, StyleVisualMarker marker)
	{
		if (eventHandler_11 != null)
		{
			eventHandler_11(this, new VisualMarkerEventArgs(marker.Style, marker, args));
		}
		marker.Style.OnVisualMarkerClick(this, new VisualMarkerEventArgs(marker.Style, marker, args));
	}

	protected virtual void OnMarkerClick(MouseEventArgs args, VisualMarker marker)
	{
		if (!(marker is StyleVisualMarker))
		{
			if (!(marker is CollapseFoldingMarker))
			{
				if (!(marker is ExpandFoldingMarker))
				{
					if (marker is FoldedAreaMarker)
					{
						int iLine = (marker as FoldedAreaMarker).iLine;
						int num = method_17(iLine);
						if (num >= 0)
						{
							Selection.BeginUpdate();
							Selection.Start = new Place(0, iLine);
							Selection.End = new Place(textSource_0[num].Count, num);
							Selection.EndUpdate();
							Invalidate();
						}
					}
				}
				else
				{
					ExpandFoldedBlock((marker as ExpandFoldingMarker).iLine);
				}
			}
			else
			{
				CollapseFoldingBlock((marker as CollapseFoldingMarker).iLine);
			}
		}
		else
		{
			OnVisualMarkerClick(args, marker as StyleVisualMarker);
		}
	}

	protected virtual void OnMarkerDoubleClick(VisualMarker marker)
	{
		if (marker is FoldedAreaMarker)
		{
			ExpandFoldedBlock((marker as FoldedAreaMarker).iLine);
			Invalidate();
		}
	}

	public Range GetBracketsRange(Place placeInsideBrackets, char leftBracket, char rightBracket, bool includeBrackets)
	{
		Range range = new Range(this, placeInsideBrackets, placeInsideBrackets);
		Range range2 = range.Clone();
		Range range3 = null;
		Range range4 = null;
		int num = 0;
		int num2 = 1000;
		while (range2.GoLeftThroughFolded())
		{
			if (range2.CharAfterStart == leftBracket)
			{
				num++;
			}
			if (range2.CharAfterStart == rightBracket)
			{
				num--;
			}
			if (num != 1)
			{
				num2--;
				if (num2 <= 0)
				{
					break;
				}
				continue;
			}
			range2.Start = new Place(range2.Start.iChar + ((!includeBrackets) ? 1 : 0), range2.Start.iLine);
			range3 = range2;
			break;
		}
		range2 = range.Clone();
		num = 0;
		num2 = 1000;
		do
		{
			if (range2.CharAfterStart == leftBracket)
			{
				num++;
			}
			if (range2.CharAfterStart == rightBracket)
			{
				num--;
			}
			if (num != -1)
			{
				num2--;
				continue;
			}
			range2.End = new Place(range2.Start.iChar + (includeBrackets ? 1 : 0), range2.Start.iLine);
			range4 = range2;
			break;
		}
		while (num2 > 0 && range2.GoRightThroughFolded());
		if (range3 == null || range4 == null)
		{
			return null;
		}
		return new Range(this, range3.Start, range4.End);
	}

	public bool SelectNext(string regexPattern, bool backward = false, RegexOptions options = RegexOptions.None)
	{
		Range range = Selection.Clone();
		range.Normalize();
		Range range2 = ((!backward) ? new Range(this, range.End, Range.End) : new Range(this, Range.Start, range.Start));
		Range range3 = null;
		foreach (Range range4 in range2.GetRanges(regexPattern, options))
		{
			range3 = range4;
			if (!backward)
			{
				break;
			}
		}
		if (range3 != null)
		{
			Selection = range3;
			Invalidate();
			return true;
		}
		return false;
	}

	public virtual void OnSyntaxHighlight(TextChangedEventArgs args)
	{
		HighlightingRangeType highlightingRangeType = HighlightingRangeType;
		HighlightingRangeType highlightingRangeType2 = highlightingRangeType;
		Range range = ((highlightingRangeType2 == HighlightingRangeType.VisibleRange) ? VisibleRange.GetUnionWith(args.ChangedRange) : ((highlightingRangeType2 != HighlightingRangeType.AllTextRange) ? args.ChangedRange : Range));
		if (SyntaxHighlighter != null)
		{
			if (Language != Language.Custom || string.IsNullOrEmpty(DescriptionFile))
			{
				SyntaxHighlighter.HighlightSyntax(Language, range);
			}
			else
			{
				SyntaxHighlighter.HighlightSyntax(DescriptionFile, range);
			}
		}
	}

	public virtual void Print(Range range, PrintDialogSettings settings)
	{
		ExportToHTML exportToHTML = new ExportToHTML();
		exportToHTML.UseBr = true;
		exportToHTML.UseForwardNbsp = true;
		exportToHTML.UseNbsp = true;
		exportToHTML.UseStyleTag = false;
		exportToHTML.IncludeLineNumbers = settings.IncludeLineNumbers;
		if (range == null)
		{
			range = Range;
		}
		if (range.Text == string.Empty)
		{
			return;
		}
		range_7 = range;
		try
		{
			if (eventHandler_7 != null)
			{
				eventHandler_7(this, new EventArgs());
			}
			if (eventHandler_10 != null)
			{
				eventHandler_10(this, new EventArgs());
			}
		}
		finally
		{
			range_7 = null;
		}
		string html = exportToHTML.GetHtml(range);
		html = "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=UTF-8\"><head><title>" + PrepareHtmlText(settings.Title) + "</title></head>" + html + "<br>" + Class76.smethod_745(this);
		string text = Path.GetTempPath() + "fctb.html";
		File.WriteAllText(text, html);
		Class76.smethod_666(settings);
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.Tag = settings;
		webBrowser.Visible = false;
		webBrowser.Location = new Point(-1000, -1000);
		webBrowser.Parent = this;
		webBrowser.StatusTextChanged += method_19;
		webBrowser.Navigate(text);
	}

	protected virtual string PrepareHtmlText(string s)
	{
		return s.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
	}

	private void method_19(object sender, EventArgs e)
	{
		WebBrowser webBrowser = sender as WebBrowser;
		if (!webBrowser.StatusText.Contains("#print"))
		{
			return;
		}
		PrintDialogSettings printDialogSettings = webBrowser.Tag as PrintDialogSettings;
		try
		{
			if (!printDialogSettings.ShowPrintPreviewDialog)
			{
				if (printDialogSettings.ShowPageSetupDialog)
				{
					webBrowser.ShowPageSetupDialog();
				}
				if (!printDialogSettings.ShowPrintDialog)
				{
					webBrowser.Print();
				}
				else
				{
					webBrowser.ShowPrintDialog();
				}
			}
			else
			{
				webBrowser.ShowPrintPreviewDialog();
			}
		}
		finally
		{
			webBrowser.Parent = null;
			webBrowser.Dispose();
		}
	}

	public void Print(PrintDialogSettings settings)
	{
		Print(Range, settings);
	}

	public void Print()
	{
		Print(Range, new PrintDialogSettings
		{
			ShowPageSetupDialog = false,
			ShowPrintDialog = false,
			ShowPrintPreviewDialog = false
		});
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			if (SyntaxHighlighter != null)
			{
				SyntaxHighlighter.Dispose();
			}
			timer_0.Dispose();
			timer_1.Dispose();
			timer_3.Dispose();
			if (findForm != null)
			{
				findForm.Dispose();
			}
			if (replaceForm != null)
			{
				replaceForm.Dispose();
			}
			if (TextSource != null)
			{
				TextSource.Dispose();
			}
			if (ToolTip != null)
			{
				ToolTip.Dispose();
			}
		}
	}

	protected virtual void OnPaintLine(PaintLineEventArgs e)
	{
		if (eventHandler_13 != null)
		{
			eventHandler_13(this, e);
		}
	}

	public void OpenFile(string fileName, Encoding enc)
	{
		TextSource ts = CreateTextSource();
		try
		{
			InitTextSource(ts);
			Text = File.ReadAllText(fileName, enc);
			ClearUndo();
			IsChanged = false;
			OnVisibleRangeChanged();
		}
		catch
		{
			InitTextSource(CreateTextSource());
			textSource_0.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			throw;
		}
		Selection.Start = Place.Empty;
		DoSelectionVisible();
	}

	public void OpenFile(string fileName)
	{
		try
		{
			Encoding encoding = EncodingDetector.DetectTextFileEncoding(fileName);
			if (encoding == null)
			{
				OpenFile(fileName, Encoding.Default);
			}
			else
			{
				OpenFile(fileName, encoding);
			}
		}
		catch
		{
			InitTextSource(CreateTextSource());
			textSource_0.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			throw;
		}
	}

	public void OpenBindingFile(string fileName, Encoding enc)
	{
		FileTextSource fileTextSource = new FileTextSource(this);
		try
		{
			InitTextSource(fileTextSource);
			fileTextSource.OpenFile(fileName, enc);
			IsChanged = false;
			OnVisibleRangeChanged();
		}
		catch
		{
			fileTextSource.CloseFile();
			InitTextSource(CreateTextSource());
			textSource_0.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			throw;
		}
		Invalidate();
	}

	public void CloseBindingFile()
	{
		if (textSource_0 is FileTextSource)
		{
			FileTextSource fileTextSource = textSource_0 as FileTextSource;
			fileTextSource.CloseFile();
			InitTextSource(CreateTextSource());
			textSource_0.InsertLine(0, TextSource.CreateLine());
			IsChanged = false;
			Invalidate();
		}
	}

	public void SaveToFile(string fileName, Encoding enc)
	{
		textSource_0.SaveToFile(fileName, enc);
		IsChanged = false;
		OnVisibleRangeChanged();
		UpdateScrollbars();
	}

	public void SetVisibleState(int iLine, VisibleState state)
	{
		LineInfo value = LineInfos[iLine];
		value.VisibleState = state;
		LineInfos[iLine] = value;
		needRecalc = true;
	}

	public VisibleState GetVisibleState(int iLine)
	{
		return LineInfos[iLine].VisibleState;
	}

	public void ShowGoToDialog()
	{
		GoToForm goToForm = new GoToForm();
		goToForm.TotalLineCount = LinesCount;
		goToForm.SelectedLineNumber = Selection.Start.iLine + 1;
		if (goToForm.ShowDialog() == DialogResult.OK)
		{
			int num = Math.Min(LinesCount - 1, Math.Max(0, goToForm.SelectedLineNumber - 1));
			Selection = new Range(this, 0, num, 0, num);
			DoSelectionVisible();
		}
	}

	public void OnUndoRedoStateChanged()
	{
		if (eventHandler_17 != null)
		{
			eventHandler_17(this, EventArgs.Empty);
		}
	}

	public List<int> FindLines(string searchPattern, RegexOptions options)
	{
		List<int> list = new List<int>();
		foreach (Range rangesByLine in Range.GetRangesByLines(searchPattern, options))
		{
			list.Add(rangesByLine.Start.iLine);
		}
		return list;
	}

	public void RemoveLines(List<int> iLines)
	{
		TextSource.Manager.ExecuteCommand(new RemoveLinesCommand(TextSource, iLines));
		if (iLines.Count > 0)
		{
			IsChanged = true;
		}
		if (LinesCount == 0)
		{
			Text = "";
		}
		NeedRecalc();
		Invalidate();
	}

	void ISupportInitialize.BeginInit()
	{
	}

	void ISupportInitialize.EndInit()
	{
		OnTextChanged();
		Selection.Start = Place.Empty;
		DoCaretVisible();
		IsChanged = false;
		ClearUndo();
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_20()
	{
		return bool_32;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_21(bool bool_34)
	{
		bool_32 = bool_34;
	}

	protected override void OnDragEnter(DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text) && AllowDrop)
		{
			e.Effect = DragDropEffects.Copy;
			method_21(bool_34: true);
		}
		base.OnDragEnter(e);
	}

	protected override void OnDragDrop(DragEventArgs e)
	{
		if (!ReadOnly && AllowDrop)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				if (base.ParentForm != null)
				{
					base.ParentForm.Activate();
				}
				Focus();
				Point point = PointToClient(new Point(e.X, e.Y));
				string text = e.Data.GetData(DataFormats.Text).ToString();
				Place place = PointToPlace(point);
				DoDragDrop(place, text);
				method_21(bool_34: false);
			}
			base.OnDragDrop(e);
		}
		else
		{
			method_21(bool_34: false);
		}
	}

	protected virtual void DoDragDrop(Place place, string text)
	{
		Range range = new Range(this, place, place);
		if (range.ReadOnly || (draggedRange != null && draggedRange.Contains(place)))
		{
			return;
		}
		bool flag = draggedRange == null || draggedRange.ReadOnly || (Control.ModifierKeys & Keys.Control) != 0;
		if (draggedRange != null)
		{
			if (!draggedRange.Contains(place))
			{
				BeginAutoUndo();
				Selection = draggedRange;
				textSource_0.Manager.ExecuteCommand(new SelectCommand(textSource_0));
				if (draggedRange.ColumnSelectionMode)
				{
					draggedRange.Normalize();
					range = new Range(this, place, new Place(place.iChar, place.iLine + draggedRange.End.iLine - draggedRange.Start.iLine))
					{
						ColumnSelectionMode = true
					};
					for (int i = LinesCount; i <= range.End.iLine; i++)
					{
						Class76.smethod_342(Selection, false);
						InsertChar('\n');
					}
				}
				if (!range.ReadOnly)
				{
					if (!(place < draggedRange.Start))
					{
						Selection = range;
						Selection.ColumnSelectionMode = range.ColumnSelectionMode;
						InsertText(text);
						if (!flag)
						{
							Selection = draggedRange;
							ClearSelected();
						}
					}
					else
					{
						if (!flag)
						{
							Selection = draggedRange;
							ClearSelected();
						}
						Selection = range;
						Selection.ColumnSelectionMode = range.ColumnSelectionMode;
						InsertText(text);
					}
				}
				Place start = place;
				Place end = Selection.Start;
				Range range2 = ((!(draggedRange.End > draggedRange.Start)) ? GetRange(draggedRange.End, draggedRange.Start) : GetRange(draggedRange.Start, draggedRange.End));
				Place place2 = place;
				if (place > draggedRange.Start && !flag && !draggedRange.ColumnSelectionMode)
				{
					int iChar;
					int iChar2;
					if (range2.Start.iLine == range2.End.iLine)
					{
						if (range2.End.iLine != place2.iLine)
						{
							iChar = place2.iChar;
							iChar2 = place2.iChar + range2.Text.Length;
						}
						else
						{
							iChar = place2.iChar - range2.Text.Length;
							iChar2 = place2.iChar;
						}
					}
					else
					{
						iChar = ((range2.End.iLine == place2.iLine) ? (range2.Start.iChar + (place2.iChar - range2.End.iChar)) : place2.iChar);
						iChar2 = range2.End.iChar;
					}
					int iLine;
					int iLine2;
					if (range2.End.iLine == place2.iLine)
					{
						iLine = range2.Start.iLine;
						iLine2 = range2.End.iLine;
					}
					else
					{
						iLine = place2.iLine - (range2.End.iLine - range2.Start.iLine);
						iLine2 = place2.iLine;
					}
					start = new Place(iChar, iLine);
					end = new Place(iChar2, iLine2);
				}
				if (draggedRange.ColumnSelectionMode)
				{
					int iChar;
					int iChar2;
					if (flag || place.iLine < range2.Start.iLine || place.iLine > range2.End.iLine || place.iChar < range2.End.iChar)
					{
						iChar = place2.iChar;
						iChar2 = place2.iChar + (range2.End.iChar - range2.Start.iChar);
					}
					else
					{
						iChar = place2.iChar - (range2.End.iChar - range2.Start.iChar);
						iChar2 = place2.iChar;
					}
					int iLine = place2.iLine;
					int iLine2 = place2.iLine + (range2.End.iLine - range2.Start.iLine);
					start = new Place(iChar, iLine);
					end = new Place(iChar2, iLine2);
					Selection = new Range(this, start, end)
					{
						ColumnSelectionMode = true
					};
				}
				else
				{
					Selection = new Range(this, start, end);
				}
				EndAutoUndo();
			}
			range_0.Inverse();
			OnSelectionChanged();
		}
		else
		{
			Selection.BeginUpdate();
			Selection.Start = place;
			InsertText(text);
			Selection = new Range(this, place, Selection.Start);
			Selection.EndUpdate();
		}
		draggedRange = null;
	}

	protected override void OnDragOver(DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text))
		{
			Point point = PointToClient(new Point(e.X, e.Y));
			Selection.Start = PointToPlace(point);
			if (point.Y < 6 && base.VerticalScroll.Visible && base.VerticalScroll.Value > 0)
			{
				base.VerticalScroll.Value = Math.Max(0, base.VerticalScroll.Value - int_0);
			}
			DoCaretVisible();
			Invalidate();
		}
		base.OnDragOver(e);
	}

	protected override void OnDragLeave(EventArgs e)
	{
		method_21(bool_34: false);
		base.OnDragLeave(e);
	}

	private void method_22(MouseEventArgs mouseEventArgs_0)
	{
		if (!bool_33 && (base.HorizontalScroll.Visible || base.VerticalScroll.Visible || !ShowScrollBars))
		{
			bool_33 = true;
			point_2 = mouseEventArgs_0.Location;
			point_3 = new Point(base.HorizontalScroll.Value, base.VerticalScroll.Value);
			timer_3.Interval = 50;
			timer_3.Enabled = true;
			base.Capture = true;
			Refresh();
			Class76.SendMessage_4(base.Handle, 11, 0, 0);
		}
	}

	private void method_23()
	{
		if (bool_33)
		{
			bool_33 = false;
			timer_3.Enabled = false;
			base.Capture = false;
			base.Cursor = cursor_0;
			Class76.SendMessage_4(base.Handle, 11, 1, 0);
			Invalidate();
		}
	}

	private void method_24()
	{
		ScrollEventArgs se = new ScrollEventArgs(ScrollEventType.ThumbPosition, base.HorizontalScroll.Value, point_3.X, ScrollOrientation.HorizontalScroll);
		OnScroll(se);
		ScrollEventArgs se2 = new ScrollEventArgs(ScrollEventType.ThumbPosition, base.VerticalScroll.Value, point_3.Y, ScrollOrientation.VerticalScroll);
		OnScroll(se2);
	}

	private void timer_3_Tick(object sender, EventArgs e)
	{
		if (base.IsDisposed || !bool_33)
		{
			return;
		}
		Point point = PointToClient(Cursor.Position);
		base.Capture = true;
		int num = point_2.X - point.X;
		int num2 = point_2.Y - point.Y;
		if (!base.VerticalScroll.Visible && ShowScrollBars)
		{
			num2 = 0;
		}
		if (!base.HorizontalScroll.Visible && ShowScrollBars)
		{
			num = 0;
		}
		double num3 = 180.0 - Math.Atan2(num2, num) * 180.0 / Math.PI;
		double num4 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0));
		if (!(num4 > 10.0))
		{
			scrollDirection_0 = ScrollDirection.None;
		}
		else if (num3 < 325.0 && !(num3 <= 35.0))
		{
			if (!(num3 <= 55.0))
			{
				if (!(num3 <= 125.0))
				{
					if (!(num3 <= 145.0))
					{
						if (!(num3 <= 215.0))
						{
							if (!(num3 <= 235.0))
							{
								if (!(num3 <= 305.0))
								{
									scrollDirection_0 = ScrollDirection.Right | ScrollDirection.Down;
								}
								else
								{
									scrollDirection_0 = ScrollDirection.Down;
								}
							}
							else
							{
								scrollDirection_0 = ScrollDirection.Left | ScrollDirection.Down;
							}
						}
						else
						{
							scrollDirection_0 = ScrollDirection.Left;
						}
					}
					else
					{
						scrollDirection_0 = ScrollDirection.Left | ScrollDirection.Up;
					}
				}
				else
				{
					scrollDirection_0 = ScrollDirection.Up;
				}
			}
			else
			{
				scrollDirection_0 = ScrollDirection.Right | ScrollDirection.Up;
			}
		}
		else
		{
			scrollDirection_0 = ScrollDirection.Right;
		}
		int num5;
		int num6;
		ScrollEventArgs se;
		ScrollEventArgs se2;
		switch (scrollDirection_0)
		{
		case ScrollDirection.Right | ScrollDirection.Down:
			base.Cursor = Cursors.PanSE;
			goto IL_0136;
		case ScrollDirection.Right:
			base.Cursor = Cursors.PanEast;
			goto IL_0136;
		case ScrollDirection.Right | ScrollDirection.Up:
			base.Cursor = Cursors.PanNE;
			goto IL_0136;
		case ScrollDirection.Up:
			base.Cursor = Cursors.PanNorth;
			goto IL_0136;
		case ScrollDirection.Left | ScrollDirection.Up:
			base.Cursor = Cursors.PanNW;
			goto IL_0136;
		case ScrollDirection.Left:
			base.Cursor = Cursors.PanWest;
			goto IL_0136;
		case ScrollDirection.Left | ScrollDirection.Down:
			base.Cursor = Cursors.PanSW;
			goto IL_0136;
		case ScrollDirection.Down:
			base.Cursor = Cursors.PanSouth;
			goto IL_0136;
		default:
			{
				base.Cursor = cursor_0;
				break;
			}
			IL_0136:
			num5 = (int)((double)(-num) / 5.0);
			num6 = (int)((double)(-num2) / 5.0);
			se = new ScrollEventArgs((num5 < 0) ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, base.HorizontalScroll.Value, base.HorizontalScroll.Value + num5, ScrollOrientation.HorizontalScroll);
			se2 = new ScrollEventArgs((num6 >= 0) ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, base.VerticalScroll.Value, base.VerticalScroll.Value + num6, ScrollOrientation.VerticalScroll);
			if ((int)(scrollDirection_0 & (ScrollDirection.Up | ScrollDirection.Down)) > 0)
			{
				OnScroll(se2, alignByLines: false);
			}
			if ((int)(scrollDirection_0 & (ScrollDirection.Left | ScrollDirection.Right)) > 0)
			{
				OnScroll(se);
			}
			Class76.SendMessage_4(base.Handle, 11, 1, 0);
			Refresh();
			Class76.SendMessage_4(base.Handle, 11, 0, 0);
			break;
		}
	}
}
