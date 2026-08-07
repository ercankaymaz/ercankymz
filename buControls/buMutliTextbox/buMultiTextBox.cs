// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.buMultiTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns1;
using ns3;
using ns7;
using System;
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

#nullable disable
namespace buMutliTextbox;

public class buMultiTextBox : UserControl, ISupportInitialize
{
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
  internal char[] char_0 = new char[10]
  {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
  };
  private MacrosManager macrosManager_0;
  private Color color_9;
  private TextAreaBorderType textAreaBorderType_0;
  private bool bool_29;
  internal Font font_0;
  private Dictionary<System.Windows.Forms.Timer, System.Windows.Forms.Timer> dictionary_1 = new Dictionary<System.Windows.Forms.Timer, System.Windows.Forms.Timer>();
  internal List<Control> list_1 = new List<Control>();
  private bool bool_30;
  private static Dictionary<FCTBAction, bool> dictionary_2 = new Dictionary<FCTBAction, bool>()
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
  private Rectangle rectangle_0;
  protected Range draggedRange;
  private bool bool_33;
  internal Point point_2;
  private Point point_3;
  private readonly System.Windows.Forms.Timer timer_3 = new System.Windows.Forms.Timer();
  private ScrollDirection scrollDirection_0 = ScrollDirection.None;

  public buMultiTextBox()
  {
    TypeDescriptionProvider provider = TypeDescriptor.GetProvider(this.GetType());
    if (provider.GetType().GetField("Provider", BindingFlags.Instance | BindingFlags.NonPublic).GetValue((object) provider).GetType() != typeof (Class25))
      TypeDescriptor.AddProvider((TypeDescriptionProvider) new Class25(this.GetType()), this.GetType());
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.Font = new Font(FontFamily.GenericMonospace, 9.75f);
    this.InitTextSource(this.CreateTextSource());
    if (this.textSource_0.Count == 0)
      this.textSource_0.InsertLine(0, this.textSource_0.CreateLine());
    this.range_0 = new Range(this)
    {
      Start = new Place(0, 0)
    };
    this.Cursor = Cursors.IBeam;
    this.BackColor = Color.White;
    this.LineNumberColor = Color.Teal;
    this.IndentBackColor = Color.WhiteSmoke;
    this.ServiceLinesColor = Color.Silver;
    this.FoldingIndicatorColor = Color.Green;
    this.CurrentLineColor = Color.Transparent;
    this.ChangedLineColor = Color.Transparent;
    this.HighlightFoldingIndicator = true;
    this.ShowLineNumbers = true;
    this.TabLength = 4;
    this.FoldedBlockStyle = (TextStyle) new buMutliTextbox.FoldedBlockStyle(Brushes.Gray, (Brush) null, FontStyle.Regular);
    this.SelectionColor = Color.Blue;
    this.BracketsStyle = new MarkerStyle((Brush) new SolidBrush(Color.FromArgb(80 /*0x50*/, Color.Lime)));
    this.BracketsStyle2 = new MarkerStyle((Brush) new SolidBrush(Color.FromArgb(60, Color.Red)));
    this.DelayedEventsInterval = 100;
    this.DelayedTextChangedInterval = 100;
    this.AllowSeveralTextStyleDrawing = false;
    this.LeftBracket = char.MinValue;
    this.RightBracket = char.MinValue;
    this.LeftBracket2 = char.MinValue;
    this.RightBracket2 = char.MinValue;
    this.SyntaxHighlighter = new SyntaxHighlighter(this);
    this.language_0 = Language.Custom;
    this.PreferredLineWidth = 0;
    this.needRecalc = true;
    this.dateTime_0 = DateTime.Now;
    this.AutoIndent = true;
    this.AutoIndentExistingLines = true;
    this.CommentPrefix = "//";
    this.uint_0 = 1U;
    this.bool_8 = true;
    this.bool_13 = true;
    this.AcceptsTab = true;
    this.AcceptsReturn = true;
    this.bool_0 = true;
    this.CaretColor = Color.Black;
    this.WideCaret = false;
    this.Paddings = new Padding(0, 0, 0, 0);
    this.PaddingBackColor = Color.Transparent;
    this.DisabledColor = Color.FromArgb(100, 180, 180, 180);
    this.bool_9 = true;
    this.AllowDrop = true;
    this.FindEndOfFoldingBlockStrategy = FindEndOfFoldingBlockStrategy.Strategy1;
    this.VirtualSpace = false;
    this.baseBookmarks_0 = (BaseBookmarks) new buMutliTextbox.Bookmarks(this);
    this.BookmarkColor = Color.PowderBlue;
    this.ToolTip = new ToolTip();
    this.timer_2.Interval = 500;
    this.hints_0 = new Hints(this);
    this.SelectionHighlightingForLineBreaksEnabled = true;
    this.textAreaBorderType_0 = TextAreaBorderType.None;
    this.color_9 = Color.Black;
    this.macrosManager_0 = new MacrosManager(this);
    this.HotkeysMapping = new HotkeysMapping();
    this.HotkeysMapping.InitDefault();
    this.WordWrapAutoIndent = true;
    this.FoldedBlocks = new Dictionary<int, int>();
    this.AutoCompleteBrackets = false;
    this.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);";
    this.AutoIndentChars = true;
    this.CaretBlinking = true;
    this.ServiceColors = new ServiceColors();
    base.AutoScroll = true;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
    this.timer_2.Tick += new EventHandler(this.timer_2_Tick);
    this.timer_3.Tick += new EventHandler(this.timer_3_Tick);
  }

  public char[] AutoCompleteBracketsList
  {
    get => this.char_0;
    set => this.char_0 = value;
  }

  [DefaultValue(false)]
  [Description("AutoComplete brackets.")]
  public bool AutoCompleteBrackets { get; set; }

  [Browsable(true)]
  [Description("Colors of some service visual markers.")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  public ServiceColors ServiceColors { get; set; }

  [Browsable(false)]
  public Dictionary<int, int> FoldedBlocks { get; private set; }

  [DefaultValue(typeof (BracketsHighlightStrategy), "Strategy1")]
  [Description("Strategy of search of brackets to highlighting.")]
  public BracketsHighlightStrategy BracketsHighlightStrategy { get; set; }

  [DefaultValue(true)]
  [Description("Automatically shifts secondary wordwrap lines on the shift amount of the first line.")]
  public bool WordWrapAutoIndent { get; set; }

  [DefaultValue(0)]
  [Description("Indent of secondary wordwrap lines (in chars).")]
  public int WordWrapIndent { get; set; }

  [Browsable(false)]
  public MacrosManager MacrosManager => this.macrosManager_0;

  [DefaultValue(true)]
  [Description("Allows drag and drop")]
  public override bool AllowDrop
  {
    get => base.AllowDrop;
    set => base.AllowDrop = value;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public Hints Hints
  {
    get => this.hints_0;
    set => this.hints_0 = value;
  }

  [Browsable(true)]
  [DefaultValue(500)]
  [Description("Delay(ms) of ToolTip.")]
  public int ToolTipDelay
  {
    get => this.timer_2.Interval;
    set => this.timer_2.Interval = value;
  }

  [Browsable(true)]
  [Description("ToolTip component.")]
  public ToolTip ToolTip { get; set; }

  [Browsable(true)]
  [DefaultValue(typeof (Color), "PowderBlue")]
  [Description("Color of bookmarks.")]
  public Color BookmarkColor { get; set; }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public BaseBookmarks Bookmarks
  {
    get => this.baseBookmarks_0;
    set => this.baseBookmarks_0 = value;
  }

  [DefaultValue(false)]
  [Description("Enables virtual spaces.")]
  public bool VirtualSpace { get; set; }

  [DefaultValue(FindEndOfFoldingBlockStrategy.Strategy1)]
  [Description("Strategy of search of end of folding block.")]
  public FindEndOfFoldingBlockStrategy FindEndOfFoldingBlockStrategy { get; set; }

  [DefaultValue(true)]
  [Description("Indicates if tab characters are accepted as input.")]
  public bool AcceptsTab { get; set; }

  [DefaultValue(true)]
  [Description("Indicates if return characters are accepted as input.")]
  public bool AcceptsReturn { get; set; }

  [DefaultValue(true)]
  [Description("Shows or hides the caret")]
  public bool CaretVisible
  {
    get => this.bool_0;
    set
    {
      this.bool_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(true)]
  [Description("Enables caret blinking")]
  public bool CaretBlinking { get; set; }

  [DefaultValue(false)]
  public bool ShowCaretWhenInactive { get; set; }

  [DefaultValue(typeof (Color), "Black")]
  [Description("Color of border of text area")]
  public Color TextAreaBorderColor
  {
    get => this.color_9;
    set
    {
      this.color_9 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (TextAreaBorderType), "None")]
  [Description("Type of border of text area")]
  public TextAreaBorderType TextAreaBorder
  {
    get => this.textAreaBorderType_0;
    set
    {
      this.textAreaBorderType_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "Transparent")]
  [Description("Background color for current line. Set to Color.Transparent to hide current line highlighting")]
  public Color CurrentLineColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "Transparent")]
  [Description("Background color for highlighting of changed lines. Set to Color.Transparent to hide changed line highlighting")]
  public Color ChangedLineColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.Invalidate();
    }
  }

  public override Color ForeColor
  {
    get => base.ForeColor;
    set
    {
      base.ForeColor = value;
      this.textSource_0.InitDefaultStyle();
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public int CharHeight
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      this.NeedRecalc();
      this.OnCharSizeChanged();
    }
  }

  [Description("Interval between lines in pixels")]
  [DefaultValue(0)]
  public int LineInterval
  {
    get => this.int_3;
    set
    {
      this.int_3 = value;
      Class39.smethod_149(this, this.Font);
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public int CharWidth { get; set; }

  [DefaultValue(4)]
  [Description("Spaces count for tab")]
  public int TabLength { get; set; }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsChanged
  {
    get => this.bool_3;
    set
    {
      if (!value)
        this.textSource_0.ClearIsChanged();
      this.bool_3 = value;
    }
  }

  [Browsable(false)]
  public int TextVersion { get; private set; }

  [DefaultValue(false)]
  public bool ReadOnly { get; set; }

  [DefaultValue(true)]
  [Description("Shows line numbers.")]
  public bool ShowLineNumbers
  {
    get => this.bool_15;
    set
    {
      this.bool_15 = value;
      this.NeedRecalc();
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [Description("Shows vertical lines between folding start line and folding end line.")]
  public bool ShowFoldingLines
  {
    get => this.bool_14;
    set
    {
      this.bool_14 = value;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public Rectangle TextAreaRect
  {
    get
    {
      int num1 = Math.Max(this.ClientSize.Width - this.Paddings.Right, this.LeftIndent + this.int_5 * this.CharWidth + this.Paddings.Left + 1);
      int num2 = Math.Max(this.ClientSize.Height - this.Paddings.Bottom, this.TextHeight + this.Paddings.Top);
      int top = Math.Max(0, this.Paddings.Top - 1) - this.VerticalScroll.Value;
      return Rectangle.FromLTRB(this.LeftIndent - this.HorizontalScroll.Value - 2 + Math.Max(0, this.Paddings.Left - 1), top, num1 - this.HorizontalScroll.Value, num2 - this.VerticalScroll.Value);
    }
  }

  [DefaultValue(typeof (Color), "Teal")]
  [Description("Color of line numbers.")]
  public Color LineNumberColor
  {
    get => this.color_4;
    set
    {
      this.color_4 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (uint), "1")]
  [Description("Start value of first line number.")]
  public uint LineNumberStartValue
  {
    get => this.uint_0;
    set
    {
      this.uint_0 = value;
      this.needRecalc = true;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "WhiteSmoke")]
  [Description("Background color of indent area")]
  public Color IndentBackColor
  {
    get => this.color_3;
    set
    {
      this.color_3 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "Transparent")]
  [Description("Background color of padding area")]
  public Color PaddingBackColor
  {
    get => this.color_5;
    set
    {
      this.color_5 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "100;180;180;180")]
  [Description("Color of disabled component")]
  public new Color DisabledColor { get; set; }

  [DefaultValue(typeof (Color), "Black")]
  [Description("Color of caret.")]
  public Color CaretColor { get; set; }

  [DefaultValue(false)]
  [Description("Wide caret.")]
  public bool WideCaret { get; set; }

  [DefaultValue(typeof (Color), "Silver")]
  [Description("Color of service lines (folding lines, borders of blocks etc.)")]
  public Color ServiceLinesColor
  {
    get => this.color_7;
    set
    {
      this.color_7 = value;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [Description("Paddings of text area.")]
  public Padding Paddings { get; set; }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public new Padding Padding
  {
    get => throw new NotImplementedException();
    set => throw new NotImplementedException();
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public bool RightToLeft
  {
    get => throw new NotImplementedException();
    set => throw new NotImplementedException();
  }

  [DefaultValue(typeof (Color), "Green")]
  [Description("Color of folding area indicator.")]
  public Color FoldingIndicatorColor
  {
    get => this.color_2;
    set
    {
      this.color_2 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(true)]
  [Description("Enables folding indicator (left vertical line between folding bounds)")]
  public bool HighlightFoldingIndicator
  {
    get => this.bool_2;
    set
    {
      this.bool_2 = value;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  [Description("Left distance to text beginning.")]
  public int LeftIndent { get; internal set; }

  [DefaultValue(0)]
  [Description("Width of left service area (in pixels)")]
  public int LeftPadding
  {
    get => this.int_2;
    set
    {
      this.int_2 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(0)]
  [Description("This property draws vertical line after defined char position. Set to 0 for disable drawing of vertical line.")]
  public int PreferredLineWidth
  {
    get => this.int_6;
    set
    {
      this.int_6 = value;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public Style[] Styles => this.textSource_0.Styles;

  [Description("Here you can change hotkeys for FastColoredTextBox.")]
  [Editor(typeof (Class21), typeof (UITypeEditor))]
  [DefaultValue("Tab=IndentIncrease, Escape=ClearHints, PgUp=GoPageUp, PgDn=GoPageDown, End=GoEnd, Home=GoHome, Left=GoLeft, Up=GoUp, Right=GoRight, Down=GoDown, Ins=ReplaceMode, Del=DeleteCharRight, F3=FindNext, Shift+Tab=IndentDecrease, Shift+PgUp=GoPageUpWithSelection, Shift+PgDn=GoPageDownWithSelection, Shift+End=GoEndWithSelection, Shift+Home=GoHomeWithSelection, Shift+Left=GoLeftWithSelection, Shift+Up=GoUpWithSelection, Shift+Right=GoRightWithSelection, Shift+Down=GoDownWithSelection, Shift+Ins=Paste, Shift+Del=Cut, Ctrl+Back=ClearWordLeft, Ctrl+Space=AutocompleteMenu, Ctrl+End=GoLastLine, Ctrl+Home=GoFirstLine, Ctrl+Left=GoWordLeft, Ctrl+Up=ScrollUp, Ctrl+Right=GoWordRight, Ctrl+Down=ScrollDown, Ctrl+Ins=Copy, Ctrl+Del=ClearWordRight, Ctrl+0=ZoomNormal, Ctrl+A=SelectAll, Ctrl+B=BookmarkLine, Ctrl+C=Copy, Ctrl+E=MacroExecute, Ctrl+F=FindDialog, Ctrl+G=GoToDialog, Ctrl+H=ReplaceDialog, Ctrl+I=AutoIndentChars, Ctrl+M=MacroRecord, Ctrl+N=GoNextBookmark, Ctrl+R=Redo, Ctrl+U=UpperCase, Ctrl+V=Paste, Ctrl+X=Cut, Ctrl+Z=Undo, Ctrl+Add=ZoomIn, Ctrl+Subtract=ZoomOut, Ctrl+OemMinus=NavigateBackward, Ctrl+Shift+End=GoLastLineWithSelection, Ctrl+Shift+Home=GoFirstLineWithSelection, Ctrl+Shift+Left=GoWordLeftWithSelection, Ctrl+Shift+Right=GoWordRightWithSelection, Ctrl+Shift+B=UnbookmarkLine, Ctrl+Shift+C=CommentSelected, Ctrl+Shift+N=GoPrevBookmark, Ctrl+Shift+U=LowerCase, Ctrl+Shift+OemMinus=NavigateForward, Alt+Back=Undo, Alt+Up=MoveSelectedLinesUp, Alt+Down=MoveSelectedLinesDown, Alt+F=FindChar, Alt+Shift+Left=GoLeft_ColumnSelectionMode, Alt+Shift+Up=GoUp_ColumnSelectionMode, Alt+Shift+Right=GoRight_ColumnSelectionMode, Alt+Shift+Down=GoDown_ColumnSelectionMode")]
  public string Hotkeys
  {
    get => this.HotkeysMapping.ToString();
    set => this.HotkeysMapping = HotkeysMapping.Parse(value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public HotkeysMapping HotkeysMapping { get; set; }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public TextStyle DefaultStyle
  {
    get => this.textSource_0.DefaultStyle;
    set => this.textSource_0.DefaultStyle = value;
  }

  [Browsable(false)]
  public SelectionStyle SelectionStyle { get; set; }

  [Browsable(false)]
  public TextStyle FoldedBlockStyle { get; set; }

  [Browsable(false)]
  public MarkerStyle BracketsStyle { get; set; }

  [Browsable(false)]
  public MarkerStyle BracketsStyle2 { get; set; }

  [DefaultValue('\0')]
  [Description("Opening bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
  public char LeftBracket { get; set; }

  [DefaultValue('\0')]
  [Description("Closing bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
  public char RightBracket { get; set; }

  [DefaultValue('\0')]
  [Description("Alternative opening bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
  public char LeftBracket2 { get; set; }

  [DefaultValue('\0')]
  [Description("Alternative closing bracket for brackets highlighting. Set to '\\x0' for disable brackets highlighting.")]
  public char RightBracket2 { get; set; }

  [DefaultValue("//")]
  [Description("Comment line prefix.")]
  public string CommentPrefix { get; set; }

  [DefaultValue(typeof (HighlightingRangeType), "ChangedRange")]
  [Description("This property specifies which part of the text will be highlighted as you type.")]
  public HighlightingRangeType HighlightingRangeType { get; set; }

  [Browsable(false)]
  public bool IsReplaceMode
  {
    get
    {
      return this.bool_5 && this.Selection.IsEmpty && !this.Selection.ColumnSelectionMode && this.Selection.Start.iChar < this.textSource_0[this.Selection.Start.iLine].Count;
    }
    set => this.bool_5 = value;
  }

  [Browsable(true)]
  [DefaultValue(false)]
  [Description("Allows text rendering several styles same time.")]
  public bool AllowSeveralTextStyleDrawing { get; set; }

  [Browsable(true)]
  [DefaultValue(true)]
  [Description("Allows to record macros.")]
  public bool AllowMacroRecording
  {
    get => this.macrosManager_0.AllowMacroRecordingByUser;
    set => this.macrosManager_0.AllowMacroRecordingByUser = value;
  }

  [DefaultValue(true)]
  [Description("Allows auto indent. Inserts spaces before line chars.")]
  public bool AutoIndent { get; set; }

  [DefaultValue(true)]
  [Description("Does autoindenting in existing lines. It works only if AutoIndent is True.")]
  public bool AutoIndentExistingLines { get; set; }

  [Browsable(true)]
  [DefaultValue(100)]
  [Description("Minimal delay(ms) for delayed events (except TextChangedDelayed).")]
  public int DelayedEventsInterval
  {
    get => this.timer_0.Interval;
    set => this.timer_0.Interval = value;
  }

  [Browsable(true)]
  [DefaultValue(100)]
  [Description("Minimal delay(ms) for TextChangedDelayed event.")]
  public int DelayedTextChangedInterval
  {
    get => this.timer_1.Interval;
    set => this.timer_1.Interval = value;
  }

  [Browsable(true)]
  [DefaultValue(typeof (Language), "Custom")]
  [Description("Language for highlighting by built-in highlighter.")]
  public Language Language
  {
    get => this.language_0;
    set
    {
      this.language_0 = value;
      if (this.SyntaxHighlighter != null)
        this.SyntaxHighlighter.InitStyleSchema(this.language_0);
      this.Invalidate();
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public SyntaxHighlighter SyntaxHighlighter { get; set; }

  [Browsable(true)]
  [DefaultValue(null)]
  [Editor(typeof (FileNameEditor), typeof (UITypeEditor))]
  [Description("XML file with description of syntax highlighting. This property works only with Language == Language.Custom.")]
  public string DescriptionFile
  {
    get => this.string_0;
    set
    {
      this.string_0 = value;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Range LeftBracketPosition => this.range_2;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Range RightBracketPosition => this.range_4;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Range LeftBracketPosition2 => this.range_3;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Range RightBracketPosition2 => this.range_5;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int StartFoldingLine => this.int_7;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int EndFoldingLine => this.int_1;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public TextSource TextSource
  {
    get => this.textSource_0;
    set => this.InitTextSource(value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool HasSourceTextBox => this.SourceTextBox != null;

  [Browsable(true)]
  [DefaultValue(null)]
  [Description("Allows to get text from other FastColoredTextBox.")]
  public buMultiTextBox SourceTextBox
  {
    get => this.buMultiTextBox_0;
    set
    {
      if (value == this.buMultiTextBox_0)
        return;
      this.buMultiTextBox_0 = value;
      if (this.buMultiTextBox_0 == null)
      {
        this.InitTextSource(this.CreateTextSource());
        this.textSource_0.InsertLine(0, this.TextSource.CreateLine());
        this.IsChanged = false;
      }
      else
      {
        this.InitTextSource(this.SourceTextBox.TextSource);
        this.bool_3 = false;
      }
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public Range VisibleRange
  {
    get
    {
      Range visibleRange;
      if (this.range_7 != null)
      {
        visibleRange = this.range_7;
      }
      else
      {
        Place place1 = this.PointToPlace(new Point(this.LeftIndent, 0));
        Size clientSize = this.ClientSize;
        int width = clientSize.Width;
        clientSize = this.ClientSize;
        int height = clientSize.Height;
        Place place2 = this.PointToPlace(new Point(width, height));
        visibleRange = this.GetRange(place1, place2);
      }
      return visibleRange;
    }
  }

  [Browsable(false)]
  public Range Selection
  {
    get => this.range_0;
    set
    {
      if (value == this.range_0)
        return;
      this.range_0.BeginUpdate();
      this.range_0.Start = value.Start;
      this.range_0.End = value.End;
      this.range_0.EndUpdate();
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "White")]
  [Description("Background color.")]
  public override Color BackColor
  {
    get => base.BackColor;
    set => base.BackColor = value;
  }

  [Browsable(false)]
  public Brush BackBrush
  {
    get => this.brush_0;
    set
    {
      this.brush_0 = value;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [DefaultValue(true)]
  [Description("Scollbars visibility.")]
  public bool ShowScrollBars
  {
    get => this.bool_13;
    set
    {
      if (value == this.bool_13)
        return;
      this.bool_13 = value;
      this.needRecalc = true;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [DefaultValue(true)]
  [Description("Multiline mode.")]
  public bool Multiline
  {
    get => this.bool_8;
    set
    {
      if (this.bool_8 == value)
        return;
      this.bool_8 = value;
      this.needRecalc = true;
      if (this.bool_8)
      {
        base.AutoScroll = true;
        this.ShowScrollBars = true;
      }
      else
      {
        base.AutoScroll = false;
        this.ShowScrollBars = false;
        if (this.textSource_0.Count > 1)
          this.textSource_0.RemoveLine(1, this.textSource_0.Count - 1);
        Class39.smethod_89(this.textSource_0.Manager);
      }
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [DefaultValue(false)]
  [Description("WordWrap.")]
  public bool WordWrap
  {
    get => this.bool_16;
    set
    {
      if (this.bool_16 == value)
        return;
      this.bool_16 = value;
      if (this.bool_16)
        this.Selection.ColumnSelectionMode = false;
      this.NeedRecalc(false, true);
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [DefaultValue(typeof (WordWrapMode), "WordWrapControlWidth")]
  [Description("WordWrap mode.")]
  public WordWrapMode WordWrapMode
  {
    get => this.wordWrapMode_0;
    set
    {
      if (this.wordWrapMode_0 == value)
        return;
      this.wordWrapMode_0 = value;
      this.NeedRecalc(false, true);
      this.Invalidate();
    }
  }

  [DefaultValue(true)]
  [Description("If enabled then line ends included into the selection will be selected too. Then line ends will be shown as selected blank character.")]
  public bool SelectionHighlightingForLineBreaksEnabled
  {
    get => this.bool_29;
    set
    {
      this.bool_29 = value;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public buMutliTextbox.FindForm findForm { get; private set; }

  [Browsable(false)]
  public ReplaceForm replaceForm { get; private set; }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public override bool AutoScroll
  {
    get => base.AutoScroll;
    set
    {
    }
  }

  [Browsable(false)]
  public int LinesCount => this.textSource_0.Count;

  public Char this[Place place]
  {
    get => this.textSource_0[place.iLine][place.iChar];
    set => this.textSource_0[place.iLine][place.iChar] = value;
  }

  public Line this[int iLine] => this.textSource_0[iLine];

  [Browsable(true)]
  [Localizable(true)]
  [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
  [SettingsBindable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  [Description("Text of the control.")]
  [Bindable(true)]
  public override string Text
  {
    get
    {
      string text;
      if (this.LinesCount == 0)
      {
        text = "";
      }
      else
      {
        Range range = new Range(this);
        range.SelectAll();
        text = range.Text;
      }
      return text;
    }
    set
    {
      if ((!(value == this.Text) ? 0 : (value != "" ? 1 : 0)) != 0)
        return;
      Class39.smethod_298(this);
      this.Selection.ColumnSelectionMode = false;
      this.Selection.BeginUpdate();
      try
      {
        this.Selection.SelectAll();
        this.InsertText(value);
        this.GoHome();
      }
      finally
      {
        this.Selection.EndUpdate();
      }
    }
  }

  public int TextLength
  {
    get
    {
      int textLength;
      if (this.LinesCount == 0)
      {
        textLength = 0;
      }
      else
      {
        Range range = new Range(this);
        range.SelectAll();
        textLength = range.Length;
      }
      return textLength;
    }
  }

  [Browsable(false)]
  public IList<string> Lines => this.textSource_0.GetLines();

  [Browsable(false)]
  public string Html
  {
    get
    {
      return $"<pre>{new ExportToHTML()
      {
        UseNbsp = false,
        UseStyleTag = false,
        UseBr = false
      }.GetHtml(this)}</pre>";
    }
  }

  [Browsable(false)]
  public string Rtf => new ExportToRTF().GetRtf(this);

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public string SelectedText
  {
    get => this.Selection.Text;
    set => this.InsertText(value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int SelectionStart
  {
    get
    {
      return Math.Min(this.PlaceToPosition(this.Selection.Start), this.PlaceToPosition(this.Selection.End));
    }
    set => this.Selection.Start = this.PositionToPlace(value);
  }

  [Browsable(false)]
  [DefaultValue(0)]
  public int SelectionLength
  {
    get => this.Selection.Length;
    set
    {
      if (value <= 0)
        return;
      this.Selection.End = this.PositionToPlace(this.SelectionStart + value);
    }
  }

  [DefaultValue(typeof (Font), "Courier New, 9.75")]
  public override Font Font
  {
    get => Class39.smethod_559(this);
    set
    {
      this.font_1 = (Font) value.Clone();
      Class39.smethod_149(this, value);
    }
  }

  public new Size AutoScrollMinSize
  {
    set
    {
      if (this.bool_13)
      {
        if (!base.AutoScroll)
          base.AutoScroll = true;
        Size size = value;
        if ((!this.WordWrap ? 0 : (this.WordWrapMode != WordWrapMode.Custom ? 1 : 0)) != 0)
        {
          int val2 = Class39.smethod_297(this);
          size = new Size(Math.Min(size.Width, val2), size.Height);
        }
        base.AutoScrollMinSize = size;
      }
      else
      {
        if (base.AutoScroll)
          base.AutoScroll = false;
        base.AutoScrollMinSize = new Size(0, 0);
        this.VerticalScroll.Visible = false;
        this.HorizontalScroll.Visible = false;
        VScrollProperties verticalScroll = this.VerticalScroll;
        int height1 = value.Height;
        Size clientSize = this.ClientSize;
        int height2 = clientSize.Height;
        int num1 = Math.Max(0, height1 - height2);
        verticalScroll.Maximum = num1;
        HScrollProperties horizontalScroll = this.HorizontalScroll;
        int width1 = value.Width;
        clientSize = this.ClientSize;
        int width2 = clientSize.Width;
        int num2 = Math.Max(0, width1 - width2);
        horizontalScroll.Maximum = num2;
        this.size_0 = value;
      }
    }
    get => !this.bool_13 ? this.size_0 : base.AutoScrollMinSize;
  }

  [Browsable(false)]
  public bool ImeAllowed
  {
    get => this.ImeMode != ImeMode.Disable && this.ImeMode != ImeMode.Off && this.ImeMode != 0;
  }

  [Browsable(false)]
  public bool UndoEnabled => this.textSource_0.Manager.UndoEnabled;

  [Browsable(false)]
  public bool RedoEnabled => this.textSource_0.Manager.RedoEnabled;

  [Browsable(false)]
  public Range Range
  {
    get
    {
      return new Range(this, new Place(0, 0), new Place(this.textSource_0[this.textSource_0.Count - 1].Count, this.textSource_0.Count - 1));
    }
  }

  [DefaultValue(typeof (Color), "Blue")]
  [Description("Color of selected area.")]
  public virtual Color SelectionColor
  {
    get => this.color_6;
    set
    {
      this.color_6 = value;
      if (this.color_6.A == byte.MaxValue)
        this.color_6 = Color.FromArgb(60, this.color_6);
      this.SelectionStyle = new SelectionStyle((Brush) new SolidBrush(this.color_6));
      this.Invalidate();
    }
  }

  public override Cursor Cursor
  {
    get => base.Cursor;
    set
    {
      this.cursor_0 = value;
      base.Cursor = value;
    }
  }

  [DefaultValue(1)]
  [Description("Reserved space for line number characters. If smaller than needed (e. g. line count >= 10 and this value set to 1) this value will have no impact. If you want to reserve space, e. g. for line numbers >= 10 or >= 100, than you can set this value to 2 or 3 or higher.")]
  public int ReservedCountOfLineNumberChars
  {
    get => this.int_9;
    set
    {
      this.int_9 = value;
      this.NeedRecalc();
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [Description("Occurs when mouse is moving over text and tooltip is needed.")]
  public event EventHandler<ToolTipNeededEventArgs> ToolTipNeeded;

  public void ClearHints()
  {
    if (this.Hints == null)
      return;
    this.Hints.Clear();
  }

  public virtual Hint AddHint(
    Range range,
    Control innerControl,
    bool scrollToHint,
    bool inline,
    bool dock)
  {
    Hint hint = new Hint(range, innerControl, inline, dock);
    this.Hints.Add(hint);
    if (scrollToHint)
      hint.DoVisible();
    return hint;
  }

  public Hint AddHint(Range range, Control innerControl)
  {
    return this.AddHint(range, innerControl, true, true, true);
  }

  public virtual Hint AddHint(
    Range range,
    string text,
    bool scrollToHint,
    bool inline,
    bool dock)
  {
    Hint hint = new Hint(range, text, inline, dock);
    this.Hints.Add(hint);
    if (scrollToHint)
      hint.DoVisible();
    return hint;
  }

  public Hint AddHint(Range range, string text) => this.AddHint(range, text, true, true, true);

  public virtual void OnHintClick(Hint hint)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, new HintClickEventArgs(hint));
  }

  private void timer_2_Tick(object sender, EventArgs e)
  {
    this.timer_2.Stop();
    this.OnToolTip();
  }

  protected virtual void OnToolTip()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.ToolTip == null || this.eventHandler_0 == null)
      return;
    Place place = this.PointToPlace(this.point_0);
    Point point = this.PlaceToPoint(place);
    if ((Math.Abs(point.X - this.point_0.X) > this.CharWidth * 2 ? 1 : (Math.Abs(point.Y - this.point_0.Y) > this.CharHeight * 2 ? 1 : 0)) != 0)
      return;
    string text = new Range(this, place, place).GetFragment("[a-zA-Z]").Text;
    ToolTipNeededEventArgs e = new ToolTipNeededEventArgs(place, text);
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, e);
    if (e.ToolTipText == null)
      return;
    this.ToolTip.ToolTipTitle = e.ToolTipTitle;
    this.ToolTip.ToolTipIcon = e.ToolTipIcon;
    this.ToolTip.Show(e.ToolTipText, (IWin32Window) this, new Point(this.point_0.X, this.point_0.Y + this.CharHeight));
  }

  public virtual void OnVisibleRangeChanged()
  {
    this.bool_9 = true;
    this.bool_12 = true;
    this.method_8(this.timer_0);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_7 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_7((object) this, new EventArgs());
  }

  public new void Invalidate()
  {
    if (this.InvokeRequired)
      this.BeginInvoke((Delegate) new MethodInvoker(this.Invalidate));
    else
      base.Invalidate();
  }

  protected virtual void OnCharSizeChanged()
  {
    this.VerticalScroll.SmallChange = this.int_0;
    this.VerticalScroll.LargeChange = 10 * this.int_0;
    this.HorizontalScroll.SmallChange = this.CharWidth;
  }

  [Browsable(true)]
  [Description("It occurs if user click on the hint.")]
  public event EventHandler<HintClickEventArgs> HintClick;

  [Browsable(true)]
  [Description("It occurs after insert, delete, clear, undo and redo operations.")]
  public event EventHandler<TextChangedEventArgs> TextChanged;

  [CompilerGenerated]
  [SpecialName]
  internal void method_0(EventHandler eventHandler_22)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = this.eventHandler_3;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, comparand + eventHandler_22, comparand);
    }
    while (eventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  internal void method_1(EventHandler eventHandler_22)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = this.eventHandler_3;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, comparand - eventHandler_22, comparand);
    }
    while (eventHandler != comparand);
  }

  [Description("Occurs when user paste text from clipboard")]
  public event EventHandler<TextChangingEventArgs> Pasting;

  [Browsable(true)]
  [Description("It occurs before insert, delete, clear, undo and redo operations.")]
  public event EventHandler<TextChangingEventArgs> TextChanging;

  [Browsable(true)]
  [Description("It occurs after changing of selection.")]
  public event EventHandler SelectionChanged;

  [Browsable(true)]
  [Description("It occurs after changing of visible range.")]
  public event EventHandler VisibleRangeChanged;

  [Browsable(true)]
  [Description("It occurs after insert, delete, clear, undo and redo operations. This event occurs with a delay relative to TextChanged, and fires only once.")]
  public event EventHandler<TextChangedEventArgs> TextChangedDelayed;

  [Browsable(true)]
  [Description("It occurs after changing of selection. This event occurs with a delay relative to SelectionChanged, and fires only once.")]
  public event EventHandler SelectionChangedDelayed;

  [Browsable(true)]
  [Description("It occurs after changing of visible range. This event occurs with a delay relative to VisibleRangeChanged, and fires only once.")]
  public event EventHandler VisibleRangeChangedDelayed;

  [Browsable(true)]
  [Description("It occurs when user click on VisualMarker.")]
  public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

  [Browsable(true)]
  [Description("It occurs when visible char is enetering (alphabetic, digit, punctuation, DEL, BACKSPACE).")]
  public event KeyPressEventHandler KeyPressing;

  [Browsable(true)]
  [Description("It occurs when visible char is enetered (alphabetic, digit, punctuation, DEL, BACKSPACE).")]
  public event KeyPressEventHandler KeyPressed;

  [Browsable(true)]
  [Description("It occurs when calculates AutoIndent for new line.")]
  public event EventHandler<AutoIndentEventArgs> AutoIndentNeeded;

  [Browsable(true)]
  [Description("It occurs when line background is painting.")]
  public event EventHandler<PaintLineEventArgs> PaintLine;

  [Browsable(true)]
  [Description("Occurs when line was inserted/added.")]
  public event EventHandler<LineInsertedEventArgs> LineInserted;

  [Browsable(true)]
  [Description("Occurs when line was removed.")]
  public event EventHandler<LineRemovedEventArgs> LineRemoved;

  [Browsable(true)]
  [Description("Occurs when current highlighted folding area is changed.")]
  public event EventHandler<EventArgs> FoldingHighlightChanged;

  [Browsable(true)]
  [Description("Occurs when undo/redo stack is changed.")]
  public event EventHandler<EventArgs> UndoRedoStateChanged;

  [Browsable(true)]
  [Description("Occurs when component was zoomed.")]
  public event EventHandler ZoomChanged;

  [Browsable(true)]
  [Description("Occurs when user pressed key, that specified as CustomAction.")]
  public event EventHandler<CustomActionEventArgs> CustomAction;

  [Browsable(true)]
  [Description("Occurs when scroolbars are updated.")]
  public event EventHandler ScrollbarsUpdated;

  [Browsable(true)]
  [Description("Occurs when custom wordwrap is needed.")]
  public event EventHandler<WordWrapNeededEventArgs> WordWrapNeeded;

  public List<Style> GetStylesOfChar(Place place)
  {
    List<Style> stylesOfChar = new List<Style>();
    if ((place.iLine >= this.LinesCount ? 0 : (place.iChar < this[place.iLine].Count ? 1 : 0)) != 0)
    {
      ushort style = (ushort) this[place].style;
      for (int index = 0; index < 16 /*0x10*/; ++index)
      {
        if (((uint) style & (uint) (1 << index)) > 0U)
          stylesOfChar.Add(this.Styles[index]);
      }
    }
    return stylesOfChar;
  }

  protected virtual TextSource CreateTextSource() => new TextSource(this);

  protected virtual void InitTextSource(TextSource ts)
  {
    if (this.textSource_0 != null)
    {
      this.textSource_0.LineInserted -= new EventHandler<LineInsertedEventArgs>(this.method_7);
      this.textSource_0.LineRemoved -= new EventHandler<LineRemovedEventArgs>(this.method_6);
      this.textSource_0.TextChanged -= new EventHandler<TextSource.TextChangedEventArgs>(this.method_5);
      this.textSource_0.RecalcNeeded -= new EventHandler<TextSource.TextChangedEventArgs>(this.method_4);
      this.textSource_0.RecalcWordWrap -= new EventHandler<TextSource.TextChangedEventArgs>(this.method_2);
      this.textSource_0.TextChanging -= new EventHandler<TextChangingEventArgs>(this.method_3);
      this.textSource_0.Dispose();
    }
    this.LineInfos.Clear();
    this.ClearHints();
    if (this.Bookmarks != null)
      this.Bookmarks.Clear();
    this.textSource_0 = ts;
    if (ts != null)
    {
      ts.LineInserted += new EventHandler<LineInsertedEventArgs>(this.method_7);
      ts.LineRemoved += new EventHandler<LineRemovedEventArgs>(this.method_6);
      ts.TextChanged += new EventHandler<TextSource.TextChangedEventArgs>(this.method_5);
      ts.RecalcNeeded += new EventHandler<TextSource.TextChangedEventArgs>(this.method_4);
      ts.RecalcWordWrap += new EventHandler<TextSource.TextChangedEventArgs>(this.method_2);
      ts.TextChanging += new EventHandler<TextChangingEventArgs>(this.method_3);
      while (this.LineInfos.Count < ts.Count)
        this.LineInfos.Add(new LineInfo(-1));
    }
    this.bool_3 = false;
    this.needRecalc = true;
  }

  private void method_2(object sender, TextSource.TextChangedEventArgs e)
  {
    Class39.smethod_638(e.iFromLine, this, e.iToLine);
  }

  private void method_3(object sender, TextChangingEventArgs e)
  {
    if (this.TextSource.CurrentTB != this)
      return;
    string insertingText = e.InsertingText;
    this.OnTextChanging(ref insertingText);
    e.InsertingText = insertingText;
  }

  private void method_4(object sender, TextSource.TextChangedEventArgs e)
  {
    if ((e.iFromLine != e.iToLine || this.WordWrap ? 0 : (this.textSource_0.Count > 100000 ? 1 : 0)) != 0)
      Class39.smethod_631(this, e.iFromLine);
    else
      this.NeedRecalc(false, this.WordWrap);
  }

  public void NeedRecalc() => this.NeedRecalc(false);

  public void NeedRecalc(bool forced) => this.NeedRecalc(forced, false);

  public void NeedRecalc(bool forced, bool wordWrapRecalc)
  {
    this.needRecalc = true;
    if (wordWrapRecalc)
    {
      this.point_1 = new Point(0, this.LinesCount - 1);
      this.needRecalcWordWrap = true;
    }
    if (!forced)
      return;
    Class39.smethod_722(this);
  }

  private void method_5(object sender, TextSource.TextChangedEventArgs e)
  {
    if ((e.iFromLine != e.iToLine ? 0 : (!this.WordWrap ? 1 : 0)) != 0)
      Class39.smethod_631(this, e.iFromLine);
    else
      this.needRecalc = true;
    this.Invalidate();
    if (this.TextSource.CurrentTB != this)
      return;
    this.OnTextChanged(e.iFromLine, e.iToLine);
  }

  private void method_6(object sender, LineRemovedEventArgs e)
  {
    this.LineInfos.RemoveRange(e.Index, e.Count);
    int index = e.Index;
    int count = e.Count;
    Class39.smethod_626(e.RemovedLineUniqueIds, count, index, this);
  }

  private void method_7(object sender, LineInsertedEventArgs e)
  {
    VisibleState visibleState = VisibleState.Visible;
    if ((e.Index < 0 || e.Index >= this.LineInfos.Count ? 0 : (this.LineInfos[e.Index].VisibleState == VisibleState.Hidden ? 1 : 0)) != 0)
      visibleState = VisibleState.Hidden;
    if (e.Count > 100000)
      this.LineInfos.Capacity = this.LineInfos.Count + e.Count + 1000;
    LineInfo[] collection = new LineInfo[e.Count];
    for (int index = 0; index < e.Count; ++index)
    {
      collection[index].startY = -1;
      collection[index].VisibleState = visibleState;
    }
    this.LineInfos.InsertRange(e.Index, (IEnumerable<LineInfo>) collection);
    if (e.Count > 1000000)
      GC.Collect();
    Class39.smethod_391(this, e.Index, e.Count);
  }

  public bool NavigateForward()
  {
    DateTime dateTime = DateTime.Now;
    int iLine = -1;
    for (int index = 0; index < this.LinesCount; ++index)
    {
      if (this.textSource_0.IsLineLoaded(index) && (!(this.textSource_0[index].LastVisit > this.dateTime_0) ? 0 : (this.textSource_0[index].LastVisit < dateTime ? 1 : 0)) != 0)
      {
        dateTime = this.textSource_0[index].LastVisit;
        iLine = index;
      }
    }
    bool flag;
    if (iLine >= 0)
    {
      this.Navigate(iLine);
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public bool NavigateBackward()
  {
    DateTime dateTime = new DateTime();
    int iLine = -1;
    for (int index = 0; index < this.LinesCount; ++index)
    {
      if (this.textSource_0.IsLineLoaded(index) && (!(this.textSource_0[index].LastVisit < this.dateTime_0) ? 0 : (this.textSource_0[index].LastVisit > dateTime ? 1 : 0)) != 0)
      {
        dateTime = this.textSource_0[index].LastVisit;
        iLine = index;
      }
    }
    bool flag;
    if (iLine >= 0)
    {
      this.Navigate(iLine);
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public void Navigate(int iLine)
  {
    if (iLine >= this.LinesCount)
      return;
    this.dateTime_0 = this.textSource_0[iLine].LastVisit;
    this.Selection.Start = new Place(0, iLine);
    this.DoSelectionVisible();
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    this.intptr_0 = buMultiTextBox.ImmGetContext(this.Handle);
  }

  private void timer_1_Tick(object sender, EventArgs e)
  {
    this.timer_1.Enabled = false;
    if (!this.bool_11)
      return;
    this.bool_11 = false;
    if (this.range_1 == null)
      return;
    this.range_1 = this.Range.GetIntersectionWith(this.range_1);
    this.range_1.Expand();
    this.OnTextChangedDelayed(this.range_1);
    this.range_1 = (Range) null;
  }

  public void AddVisualMarker(VisualMarker marker) => this.list_0.Add(marker);

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.timer_0.Enabled = false;
    if (this.bool_10)
    {
      this.bool_10 = false;
      this.OnSelectionChangedDelayed();
    }
    if (!this.bool_12)
      return;
    this.bool_12 = false;
    this.OnVisibleRangeChangedDelayed();
  }

  public virtual void OnTextChangedDelayed(Range changedRange)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_8 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_8((object) this, new TextChangedEventArgs(changedRange));
  }

  public virtual void OnSelectionChangedDelayed()
  {
    Class39.smethod_631(this, this.Selection.Start.iLine);
    Class39.smethod_808(this);
    if ((this.LeftBracket == char.MinValue ? 0 : (this.RightBracket > char.MinValue ? 1 : 0)) != 0)
    {
      char leftBracket = this.LeftBracket;
      char rightBracket = this.RightBracket;
      ref Range local1 = ref this.range_2;
      ref Range local2 = ref this.range_4;
      Class39.smethod_210(leftBracket, this, ref local1, ref local2, rightBracket);
    }
    if ((this.LeftBracket2 == char.MinValue ? 0 : (this.RightBracket2 > char.MinValue ? 1 : 0)) != 0)
    {
      char leftBracket2 = this.LeftBracket2;
      char rightBracket2 = this.RightBracket2;
      ref Range local3 = ref this.range_3;
      ref Range local4 = ref this.range_5;
      Class39.smethod_210(leftBracket2, this, ref local3, ref local4, rightBracket2);
    }
    if ((!this.Selection.IsEmpty ? 0 : (this.Selection.Start.iLine < this.LinesCount ? 1 : 0)) != 0 && this.dateTime_0 != this.textSource_0[this.Selection.Start.iLine].LastVisit)
    {
      this.textSource_0[this.Selection.Start.iLine].LastVisit = DateTime.Now;
      this.dateTime_0 = this.textSource_0[this.Selection.Start.iLine].LastVisit;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_9 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_9((object) this, new EventArgs());
  }

  public virtual void OnVisibleRangeChangedDelayed()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_10 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_10((object) this, new EventArgs());
  }

  private void method_8(System.Windows.Forms.Timer timer_4)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    buMultiTextBox.Class3 class3 = new buMultiTextBox.Class3();
    // ISSUE: reference to a compiler-generated field
    class3.buMultiTextBox_0 = this;
    // ISSUE: reference to a compiler-generated field
    class3.timer_0 = timer_4;
    if (this.InvokeRequired)
    {
      // ISSUE: reference to a compiler-generated method
      this.BeginInvoke((Delegate) new MethodInvoker(class3.method_0));
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      class3.timer_0.Stop();
      if (this.IsHandleCreated)
      {
        // ISSUE: reference to a compiler-generated field
        class3.timer_0.Start();
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.dictionary_1[class3.timer_0] = class3.timer_0;
      }
    }
  }

  protected override void OnHandleCreated(EventArgs e)
  {
    base.OnHandleCreated(e);
    foreach (System.Windows.Forms.Timer timer_4 in new List<System.Windows.Forms.Timer>((IEnumerable<System.Windows.Forms.Timer>) this.dictionary_1.Keys))
      this.method_8(timer_4);
    this.dictionary_1.Clear();
    this.OnScrollbarsUpdated();
  }

  public int AddStyle(Style style)
  {
    int num;
    if (style == null)
    {
      num = -1;
    }
    else
    {
      int styleIndex = this.GetStyleIndex(style);
      if (styleIndex >= 0)
      {
        num = styleIndex;
      }
      else
      {
        int index = this.CheckStylesBufferSize();
        this.Styles[index] = style;
        num = index;
      }
    }
    return num;
  }

  public int CheckStylesBufferSize()
  {
    int index = this.Styles.Length - 1;
    while (index >= 0 && this.Styles[index] == null)
      --index;
    int num = index + 1;
    if (num >= this.Styles.Length)
      throw new Exception("Maximum count of Styles is exceeded.");
    return num;
  }

  public virtual void ShowFindDialog() => this.ShowFindDialog((string) null);

  public virtual void ShowFindDialog(string findText)
  {
    if (this.findForm == null)
      this.findForm = new buMutliTextbox.FindForm(this);
    if (findText != null)
      this.findForm.tbFind.Text = findText;
    else if ((this.Selection.IsEmpty ? 0 : (this.Selection.Start.iLine == this.Selection.End.iLine ? 1 : 0)) != 0)
      this.findForm.tbFind.Text = this.Selection.Text;
    this.findForm.tbFind.SelectAll();
    this.findForm.Show();
    this.findForm.Focus();
  }

  public virtual void ShowReplaceDialog() => this.ShowReplaceDialog((string) null);

  public virtual void ShowReplaceDialog(string findText)
  {
    if (this.ReadOnly)
      return;
    if (this.replaceForm == null)
      this.replaceForm = new ReplaceForm(this);
    if (findText != null)
      this.replaceForm.tbFind.Text = findText;
    else if ((this.Selection.IsEmpty ? 0 : (this.Selection.Start.iLine == this.Selection.End.iLine ? 1 : 0)) != 0)
      this.replaceForm.tbFind.Text = this.Selection.Text;
    this.replaceForm.tbFind.SelectAll();
    this.replaceForm.Show();
    this.replaceForm.Focus();
  }

  public int GetLineLength(int iLine)
  {
    if ((iLine < 0 ? 1 : (iLine >= this.textSource_0.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException("Line index out of range");
    return this.textSource_0[iLine].Count;
  }

  public Range GetLine(int iLine)
  {
    if ((iLine < 0 ? 1 : (iLine >= this.textSource_0.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException("Line index out of range");
    return new Range(this)
    {
      Start = new Place(0, iLine),
      End = new Place(this.textSource_0[iLine].Count, iLine)
    };
  }

  public virtual void Copy()
  {
    if (this.Selection.IsEmpty)
      this.Selection.Expand();
    if (this.Selection.IsEmpty)
      return;
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    buMultiTextBox.Class4 class4 = new buMultiTextBox.Class4();
    // ISSUE: reference to a compiler-generated field
    class4.buMultiTextBox_0 = this;
    // ISSUE: reference to a compiler-generated field
    class4.dataObject_0 = new DataObject();
    // ISSUE: reference to a compiler-generated field
    this.OnCreateClipboardData(class4.dataObject_0);
    // ISSUE: reference to a compiler-generated method
    Thread thread = new Thread(new ThreadStart(class4.method_0));
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    thread.Join();
  }

  protected virtual void OnCreateClipboardData(DataObject data)
  {
    string html = $"<pre>{new ExportToHTML()
    {
      UseBr = false,
      UseNbsp = false,
      UseStyleTag = true
    }.GetHtml(this.Selection.Clone())}</pre>";
    data.SetData(DataFormats.UnicodeText, true, (object) this.Selection.Text);
    data.SetData(DataFormats.Html, (object) buMultiTextBox.PrepareHtmlForClipboard(html));
    data.SetData(DataFormats.Rtf, (object) new ExportToRTF().GetRtf(this.Selection.Clone()));
  }

  protected void SetClipboard(DataObject data)
  {
    try
    {
      Class39.CloseClipboard();
      Clipboard.SetDataObject((object) data, true, 5, 100);
    }
    catch (ExternalException ex)
    {
    }
  }

  public static MemoryStream PrepareHtmlForClipboard(string html)
  {
    Encoding utF8 = Encoding.UTF8;
    string format = "Version:0.9\r\nStartHTML:{0:000000}\r\nEndHTML:{1:000000}\r\nStartFragment:{2:000000}\r\nEndFragment:{3:000000}\r\n";
    string s1 = $"<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset={utF8.WebName}\">\r\n<title>HTML clipboard</title>\r\n</head>\r\n<body>\r\n<!--StartFragment-->";
    string s2 = "<!--EndFragment-->\r\n</body>\r\n</html>\r\n";
    string s3 = string.Format(format, (object) 0, (object) 0, (object) 0, (object) 0);
    int byteCount1 = utF8.GetByteCount(s3);
    int byteCount2 = utF8.GetByteCount(s1);
    int byteCount3 = utF8.GetByteCount(html);
    int byteCount4 = utF8.GetByteCount(s2);
    string s4 = string.Format(format, (object) byteCount1, (object) (byteCount1 + byteCount2 + byteCount3 + byteCount4), (object) (byteCount1 + byteCount2), (object) (byteCount1 + byteCount2 + byteCount3)) + s1 + html + s2;
    return new MemoryStream(utF8.GetBytes(s4));
  }

  public virtual void Cut()
  {
    if (!this.Selection.IsEmpty)
    {
      this.Copy();
      this.ClearSelected();
    }
    else if (this.LinesCount == 1)
    {
      this.Selection.SelectAll();
      this.Copy();
      this.ClearSelected();
    }
    else
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      buMultiTextBox.Class5 class5 = new buMultiTextBox.Class5();
      // ISSUE: reference to a compiler-generated field
      class5.buMultiTextBox_0 = this;
      // ISSUE: reference to a compiler-generated field
      class5.dataObject_0 = new DataObject();
      // ISSUE: reference to a compiler-generated field
      this.OnCreateClipboardData(class5.dataObject_0);
      // ISSUE: reference to a compiler-generated method
      Thread thread = new Thread(new ThreadStart(class5.method_0));
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start();
      thread.Join();
      if ((this.Selection.Start.iLine < 0 ? 0 : (this.Selection.Start.iLine < this.LinesCount ? 1 : 0)) == 0)
        return;
      int iLine = this.Selection.Start.iLine;
      this.RemoveLines(new List<int>() { iLine });
      this.Selection.Start = new Place(0, Math.Max(0, Math.Min(iLine, this.LinesCount - 1)));
    }
  }

  public virtual void Paste()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    buMultiTextBox.Class6 class6 = new buMultiTextBox.Class6();
    // ISSUE: reference to a compiler-generated field
    class6.string_0 = (string) null;
    // ISSUE: reference to a compiler-generated method
    Thread thread = new Thread(new ThreadStart(class6.method_0));
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    thread.Join();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_4 != null)
    {
      // ISSUE: reference to a compiler-generated field
      TextChangingEventArgs e = new TextChangingEventArgs()
      {
        Cancel = false,
        InsertingText = class6.string_0
      };
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_4((object) this, e);
      // ISSUE: reference to a compiler-generated field
      class6.string_0 = !e.Cancel ? e.InsertingText : string.Empty;
    }
    // ISSUE: reference to a compiler-generated field
    if (string.IsNullOrEmpty(class6.string_0))
      return;
    // ISSUE: reference to a compiler-generated field
    this.InsertText(class6.string_0);
  }

  public void SelectAll() => this.Selection.SelectAll();

  public void GoEnd()
  {
    this.Selection.Start = this.textSource_0.Count <= 0 ? new Place(0, 0) : new Place(this.textSource_0[this.textSource_0.Count - 1].Count, this.textSource_0.Count - 1);
    this.DoCaretVisible();
  }

  public void GoHome()
  {
    this.Selection.Start = new Place(0, 0);
    this.DoCaretVisible();
  }

  public virtual void Clear()
  {
    this.Selection.BeginUpdate();
    try
    {
      this.Selection.SelectAll();
      this.ClearSelected();
      Class39.smethod_89(this.textSource_0.Manager);
      this.Invalidate();
    }
    finally
    {
      this.Selection.EndUpdate();
    }
  }

  public void ClearStylesBuffer()
  {
    for (int index = 0; index < this.Styles.Length; ++index)
      this.Styles[index] = (Style) null;
  }

  public void ClearStyle(StyleIndex styleIndex)
  {
    foreach (Line line in this.textSource_0)
      line.ClearStyle(styleIndex);
    for (int iLine = 0; iLine < this.LineInfos.Count; ++iLine)
      this.SetVisibleState(iLine, VisibleState.Visible);
    this.Invalidate();
  }

  public void ClearUndo() => Class39.smethod_89(this.textSource_0.Manager);

  public virtual void InsertText(string text) => this.InsertText(text, true);

  public virtual void InsertText(string text, bool jumpToCaret)
  {
    switch (text)
    {
      case null:
        return;
      case "\r":
        text = "\n";
        break;
    }
    this.textSource_0.Manager.BeginAutoUndoCommands();
    try
    {
      if (!this.Selection.IsEmpty)
        this.textSource_0.Manager.ExecuteCommand((Command) new ClearSelectedCommand(this.TextSource));
      if (this.TextSource.Count > 0 && (!this.Selection.IsEmpty || this.Selection.Start.iChar <= this.GetLineLength(this.Selection.Start.iLine) ? 0 : (this.VirtualSpace ? 1 : 0)) != 0)
        Class39.smethod_778(this);
      this.textSource_0.Manager.ExecuteCommand((Command) new InsertTextCommand(this.TextSource, text));
      if (this.int_8 <= 0 & jumpToCaret)
        this.DoCaretVisible();
    }
    finally
    {
      this.textSource_0.Manager.EndAutoUndoCommands();
    }
    this.Invalidate();
  }

  public virtual Range InsertText(string text, Style style) => this.InsertText(text, style, true);

  public virtual Range InsertText(string text, Style style, bool jumpToCaret)
  {
    Range range;
    if (text == null)
    {
      range = (Range) null;
    }
    else
    {
      Place start = this.Selection.Start > this.Selection.End ? this.Selection.End : this.Selection.Start;
      this.InsertText(text, jumpToCaret);
      Range intersectionWith = new Range(this, start, this.Selection.Start)
      {
        ColumnSelectionMode = this.Selection.ColumnSelectionMode
      }.GetIntersectionWith(this.Range);
      intersectionWith.SetStyle(style);
      range = intersectionWith;
    }
    return range;
  }

  public virtual Range InsertTextAndRestoreSelection(Range replaceRange, string text, Style style)
  {
    Range range1;
    if (text == null)
    {
      range1 = (Range) null;
    }
    else
    {
      int position1 = this.PlaceToPosition(this.Selection.Start);
      int position2 = this.PlaceToPosition(this.Selection.End);
      int length = replaceRange.Text.Length;
      int position3 = this.PlaceToPosition(replaceRange.Start);
      this.Selection.BeginUpdate();
      this.Selection = replaceRange;
      Range range2 = this.InsertText(text, style);
      int num = range2.Text.Length - length;
      this.Selection.Start = this.PositionToPlace(position1 + (position1 >= position3 ? num : 0));
      this.Selection.End = this.PositionToPlace(position2 + (position2 >= position3 ? num : 0));
      this.Selection.EndUpdate();
      range1 = range2;
    }
    return range1;
  }

  public virtual void AppendText(string text) => this.AppendText(text, (Style) null);

  public virtual void AppendText(string text, Style style)
  {
    if (text == null)
      return;
    this.Selection.ColumnSelectionMode = false;
    Place start1 = this.Selection.Start;
    Place end = this.Selection.End;
    this.Selection.BeginUpdate();
    this.textSource_0.Manager.BeginAutoUndoCommands();
    try
    {
      this.Selection.Start = this.textSource_0.Count <= 0 ? new Place(0, 0) : new Place(this.textSource_0[this.textSource_0.Count - 1].Count, this.textSource_0.Count - 1);
      Place start2 = this.Selection.Start;
      this.textSource_0.Manager.ExecuteCommand((Command) new InsertTextCommand(this.TextSource, text));
      if (style != null)
        new Range(this, start2, this.Selection.Start).SetStyle(style);
    }
    finally
    {
      this.textSource_0.Manager.EndAutoUndoCommands();
      this.Selection.Start = start1;
      this.Selection.End = end;
      this.Selection.EndUpdate();
    }
    this.Invalidate();
  }

  public int GetStyleIndex(Style style) => Array.IndexOf<Style>(this.Styles, style);

  public StyleIndex GetStyleIndexMask(Style[] styles)
  {
    StyleIndex styleIndexMask = StyleIndex.None;
    foreach (Style style in styles)
    {
      int styleIndex = this.GetStyleIndex(style);
      if (styleIndex >= 0)
        styleIndexMask |= Range.ToStyleIndex(styleIndex);
    }
    return styleIndexMask;
  }

  public static SizeF GetCharSize(Font font, char c)
  {
    return new SizeF((float) (TextRenderer.MeasureText($"<{c.ToString()}>", font).Width - TextRenderer.MeasureText("<>", font).Width + 1), (float) font.Height);
  }

  [DllImport("Imm32.dll")]
  public static extern IntPtr ImmGetContext(IntPtr hWnd);

  [DllImport("Imm32.dll")]
  public static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

  protected override void WndProc(ref Message m)
  {
    IntPtr wparam;
    if ((m.Msg == 276 ? 1 : (m.Msg == 277 ? 1 : 0)) != 0)
    {
      wparam = m.WParam;
      if (wparam.ToInt32() != 8)
        this.Invalidate();
    }
    base.WndProc(ref m);
    if (!this.ImeAllowed)
      return;
    int num;
    if (m.Msg == 641)
    {
      wparam = m.WParam;
      num = wparam.ToInt32() == 1 ? 1 : 0;
    }
    else
      num = 0;
    if (num == 0)
      return;
    buMultiTextBox.ImmAssociateContext(this.Handle, this.intptr_0);
  }

  internal void method_9()
  {
    if ((this.ShowScrollBars ? 0 : (this.Hints.Count > 0 ? 1 : 0)) == 0)
      return;
    foreach (Control control in this.list_1)
      this.Controls.Add(control);
    this.list_1.Clear();
    this.ResumeLayout(false);
    if (this.Focused)
      return;
    this.Focus();
  }

  public void OnScroll(ScrollEventArgs se, bool alignByLines)
  {
    Class39.smethod_21(this);
    if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
    {
      int val2 = se.NewValue;
      if (alignByLines)
        val2 = (int) (Math.Ceiling(1.0 * (double) val2 / (double) this.CharHeight) * (double) this.CharHeight);
      this.VerticalScroll.Value = Math.Max(this.VerticalScroll.Minimum, Math.Min(this.VerticalScroll.Maximum, val2));
    }
    if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
      this.HorizontalScroll.Value = Math.Max(this.HorizontalScroll.Minimum, Math.Min(this.HorizontalScroll.Maximum, se.NewValue));
    this.UpdateScrollbars();
    this.method_9();
    this.Invalidate();
    base.OnScroll(se);
    this.OnVisibleRangeChanged();
  }

  protected override void OnScroll(ScrollEventArgs se) => this.OnScroll(se, true);

  protected virtual void InsertChar(char c)
  {
    this.textSource_0.Manager.BeginAutoUndoCommands();
    try
    {
      if (!this.Selection.IsEmpty)
        this.textSource_0.Manager.ExecuteCommand((Command) new ClearSelectedCommand(this.TextSource));
      if ((!this.Selection.IsEmpty || this.Selection.Start.iChar <= this.GetLineLength(this.Selection.Start.iLine) ? 0 : (this.VirtualSpace ? 1 : 0)) != 0)
        Class39.smethod_778(this);
      this.textSource_0.Manager.ExecuteCommand((Command) new InsertCharCommand(this.TextSource, c));
    }
    finally
    {
      this.textSource_0.Manager.EndAutoUndoCommands();
    }
    this.Invalidate();
  }

  public virtual void ClearSelected()
  {
    if (this.Selection.IsEmpty)
      return;
    this.textSource_0.Manager.ExecuteCommand((Command) new ClearSelectedCommand(this.TextSource));
    this.Invalidate();
  }

  public void ClearCurrentLine()
  {
    this.Selection.Expand();
    this.textSource_0.Manager.ExecuteCommand((Command) new ClearSelectedCommand(this.TextSource));
    if (this.Selection.Start.iLine == 0 && !this.Selection.GoRightThroughFolded())
      return;
    if (this.Selection.Start.iLine > 0)
      this.textSource_0.Manager.ExecuteCommand((Command) new InsertCharCommand(this.TextSource, '\b'));
    this.Invalidate();
  }

  public static void CalcCutOffs(
    List<int> cutOffPositions,
    int maxCharsPerLine,
    int maxCharsPerSecondaryLine,
    bool allowIME,
    bool charWrap,
    Line line)
  {
    if (maxCharsPerSecondaryLine < 1)
      maxCharsPerSecondaryLine = 1;
    if (maxCharsPerLine < 1)
      maxCharsPerLine = 1;
    int num1 = 0;
    int num2 = 0;
    cutOffPositions.Clear();
    for (int index = 0; index < line.Count - 1; ++index)
    {
      char c = line[index].c;
      if (charWrap)
        num2 = index + 1;
      else if ((!allowIME ? 0 : (buMultiTextBox.IsCJKLetter(c) ? 1 : 0)) != 0)
      {
        num2 = index;
      }
      else
      {
        int num3;
        if (!char.IsLetterOrDigit(c))
        {
          switch (c)
          {
            case '\'':
            case '_':
            case ' ':
              break;
            case ',':
            case '.':
              num3 = !char.IsDigit(line[index + 1].c) ? 1 : 0;
              goto label_15;
            default:
              num3 = 1;
              goto label_15;
          }
        }
        num3 = 0;
label_15:
        if (num3 != 0)
          num2 = Math.Min(index + 1, line.Count - 1);
      }
      ++num1;
      if (num1 == maxCharsPerLine)
      {
        if ((num2 == 0 ? 1 : (cutOffPositions.Count <= 0 ? 0 : (num2 == cutOffPositions[cutOffPositions.Count - 1] ? 1 : 0))) != 0)
          num2 = index + 1;
        cutOffPositions.Add(num2);
        num1 = 1 + index - num2;
        maxCharsPerLine = maxCharsPerSecondaryLine;
      }
    }
  }

  public static bool IsCJKLetter(char c)
  {
    int int32 = Convert.ToInt32(c);
    if (int32 >= 13056 && int32 <= 13311 || int32 >= 65072 && int32 <= 65103 || int32 >= 63744 && int32 <= 64255 || int32 >= 11904 && int32 <= 12031 || int32 >= 12736 && int32 <= 12783 || int32 >= 19968 && int32 <= 40959 /*0x9FFF*/ || int32 >= 13312 && int32 <= 19903 || int32 >= 12800 && int32 <= 13055 || int32 >= 9312 && int32 <= 9471 || int32 >= 12352 && int32 <= 12447 || int32 >= 12032 && int32 <= 12255 || int32 >= 12704 && int32 <= 12735 || int32 >= 19904 && int32 <= 19967 || int32 >= 12544 && int32 <= 12591 || int32 >= 12448 && int32 <= 12543 || int32 >= 12784 && int32 <= 12799 || int32 >= 12272 && int32 <= 12287 /*0x2FFF*/ || int32 >= 4352 && int32 <= 4607 || int32 >= 43360 && int32 <= 43391 || int32 >= 55216 && int32 <= 55295 || int32 >= 12592 && int32 <= 12687)
      return true;
    return int32 >= 44032 && int32 <= 55215;
  }

  protected override void OnClientSizeChanged(EventArgs e)
  {
    base.OnClientSizeChanged(e);
    if (this.WordWrap)
    {
      this.NeedRecalc(false, true);
      this.Invalidate();
    }
    this.OnVisibleRangeChanged();
    this.UpdateScrollbars();
  }

  public void UpdateScrollbars()
  {
    if (this.ShowScrollBars)
    {
      base.AutoScrollMinSize = base.AutoScrollMinSize - new Size(1, 0);
      base.AutoScrollMinSize = base.AutoScrollMinSize + new Size(1, 0);
    }
    else
      this.PerformLayout();
    if (!this.IsHandleCreated)
      return;
    this.BeginInvoke((Delegate) new MethodInvoker(this.OnScrollbarsUpdated));
  }

  protected virtual void OnScrollbarsUpdated()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_20 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_20((object) this, EventArgs.Empty);
  }

  public void DoCaretVisible()
  {
    this.Invalidate();
    Class39.smethod_722(this);
    Point point = this.PlaceToPoint(this.Selection.Start);
    point.Offset(-this.CharWidth, 0);
    Class39.smethod_542(this, new Rectangle(point, new Size(2 * this.CharWidth, 2 * this.CharHeight)));
  }

  public void ScrollLeft()
  {
    this.Invalidate();
    this.HorizontalScroll.Value = 0;
    this.AutoScrollMinSize -= new Size(1, 0);
    this.AutoScrollMinSize += new Size(1, 0);
  }

  public void DoSelectionVisible()
  {
    if (this.LineInfos[this.Selection.End.iLine].VisibleState != 0)
      this.ExpandBlock(this.Selection.End.iLine);
    if (this.LineInfos[this.Selection.Start.iLine].VisibleState != 0)
      this.ExpandBlock(this.Selection.Start.iLine);
    Class39.smethod_722(this);
    Class39.smethod_542(this, new Rectangle(this.PlaceToPoint(new Place(0, this.Selection.End.iLine)), new Size(2 * this.CharWidth, 2 * this.CharHeight)));
    Point point1 = this.PlaceToPoint(this.Selection.Start);
    Point point2 = this.PlaceToPoint(this.Selection.End);
    point1.Offset(-this.CharWidth, -this.ClientSize.Height / 2);
    Class39.smethod_542(this, new Rectangle(point1, new Size(Math.Abs(point2.X - point1.X), this.ClientSize.Height)));
    this.Invalidate();
  }

  public void DoRangeVisible(Range range) => this.DoRangeVisible(range, false);

  public void DoRangeVisible(Range range, bool tryToCentre)
  {
    range = range.Clone();
    range.Normalize();
    range.End = new Place(range.End.iChar, Math.Min(range.End.iLine, range.Start.iLine + this.ClientSize.Height / this.CharHeight));
    if (this.LineInfos[range.End.iLine].VisibleState != 0)
      this.ExpandBlock(range.End.iLine);
    if (this.LineInfos[range.Start.iLine].VisibleState != 0)
      this.ExpandBlock(range.Start.iLine);
    Class39.smethod_722(this);
    int height = (1 + range.End.iLine - range.Start.iLine) * this.CharHeight;
    Point point = this.PlaceToPoint(new Place(0, range.Start.iLine));
    if (tryToCentre)
    {
      ref Point local = ref point;
      Size clientSize = this.ClientSize;
      int dy = -clientSize.Height / 2;
      local.Offset(0, dy);
      clientSize = this.ClientSize;
      height = clientSize.Height;
    }
    Class39.smethod_542(this, new Rectangle(point, new Size(2 * this.CharWidth, height)));
    this.Invalidate();
  }

  protected override void OnKeyUp(KeyEventArgs e)
  {
    base.OnKeyUp(e);
    if (e.KeyCode == Keys.ShiftKey)
      this.keys_0 &= ~Keys.Shift;
    if (e.KeyCode == Keys.Alt)
      this.keys_0 &= ~Keys.Alt;
    if (e.KeyCode != Keys.ControlKey)
      return;
    this.keys_0 &= ~Keys.Control;
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (this.bool_33)
      return;
    base.OnKeyDown(e);
    if (this.Focused)
      this.keys_0 = e.Modifiers;
    this.bool_1 = false;
    if (e.Handled)
    {
      this.bool_1 = true;
    }
    else
    {
      if (this.ProcessKey(e.KeyData))
        return;
      e.Handled = true;
      this.DoCaretVisible();
      this.Invalidate();
    }
  }

  protected override bool ProcessDialogKey(Keys keyData)
  {
    bool flag;
    if ((keyData & Keys.Alt) > Keys.None && this.HotkeysMapping.ContainsKey(keyData))
    {
      this.ProcessKey(keyData);
      flag = true;
    }
    else
      flag = base.ProcessDialogKey(keyData);
    return flag;
  }

  public virtual bool ProcessKey(Keys keyData)
  {
    KeyEventArgs keyEventArgs = new KeyEventArgs(keyData);
    bool flag;
    if ((keyEventArgs.KeyCode != Keys.Tab ? 0 : (!this.AcceptsTab ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      if (this.macrosManager_0 != null && (!this.HotkeysMapping.ContainsKey(keyData) ? 1 : (this.HotkeysMapping[keyData] == FCTBAction.MacroExecute ? 0 : (this.HotkeysMapping[keyData] != FCTBAction.MacroRecord ? 1 : 0))) != 0)
        Class39.smethod_496(this.macrosManager_0, keyData);
      if (this.HotkeysMapping.ContainsKey(keyData))
      {
        FCTBAction fctbAction = this.HotkeysMapping[keyData];
        this.method_10(fctbAction);
        if (buMultiTextBox.dictionary_2.ContainsKey(fctbAction))
        {
          flag = true;
          goto label_20;
        }
        if ((keyData == Keys.Tab ? 1 : (keyData == (Keys.Tab | Keys.Shift) ? 1 : 0)) != 0)
        {
          this.bool_1 = true;
          flag = true;
          goto label_20;
        }
      }
      else
      {
        if (keyEventArgs.KeyCode == Keys.Alt)
        {
          flag = true;
          goto label_20;
        }
        if ((keyEventArgs.Modifiers & Keys.Control) != 0)
        {
          flag = true;
          goto label_20;
        }
        if ((keyEventArgs.Modifiers & Keys.Alt) != 0)
        {
          if ((Control.MouseButtons & MouseButtons.Left) != 0)
            this.CheckAndChangeSelectionType();
          flag = true;
          goto label_20;
        }
        if (keyEventArgs.KeyCode == Keys.ShiftKey)
        {
          flag = true;
          goto label_20;
        }
      }
      flag = false;
    }
label_20:
    return flag;
  }

  private void method_10(FCTBAction fctbaction_0)
  {
    switch (fctbaction_0)
    {
      case FCTBAction.AutoIndentChars:
        if (this.Selection.ReadOnly)
          break;
        this.DoAutoIndentChars(this.Selection.Start.iLine);
        break;
      case FCTBAction.BookmarkLine:
        this.BookmarkLine(this.Selection.Start.iLine);
        break;
      case FCTBAction.ClearHints:
        this.ClearHints();
        if (this.MacrosManager == null)
          break;
        this.MacrosManager.IsRecording = false;
        break;
      case FCTBAction.ClearWordLeft:
        if (this.method_11('\b'))
          break;
        if (!this.Selection.ReadOnly)
        {
          if (!this.Selection.IsEmpty)
            this.ClearSelected();
          this.Selection.GoWordLeft(true);
          if (!this.Selection.ReadOnly)
            this.ClearSelected();
        }
        this.OnKeyPressed('\b');
        break;
      case FCTBAction.ClearWordRight:
        if (this.method_11('ÿ'))
          break;
        if (!this.Selection.ReadOnly)
        {
          if (!this.Selection.IsEmpty)
            this.ClearSelected();
          this.Selection.GoWordRight(true);
          if (!this.Selection.ReadOnly)
            this.ClearSelected();
        }
        this.OnKeyPressed('ÿ');
        break;
      case FCTBAction.CommentSelected:
        this.CommentSelected();
        break;
      case FCTBAction.Copy:
        this.Copy();
        break;
      case FCTBAction.Cut:
        if (this.Selection.ReadOnly)
          break;
        this.Cut();
        break;
      case FCTBAction.DeleteCharRight:
        if (this.Selection.ReadOnly || this.method_11('ÿ'))
          break;
        if (!this.Selection.IsEmpty)
        {
          this.ClearSelected();
        }
        else
        {
          if (this[this.Selection.Start.iLine].StartSpacesCount == this[this.Selection.Start.iLine].Count)
            Class39.smethod_44(this);
          if (!this.Selection.IsReadOnlyRightChar() && this.Selection.GoRightThroughFolded())
          {
            int iLine = this.Selection.Start.iLine;
            this.InsertChar('\b');
            if ((iLine == this.Selection.Start.iLine ? 0 : (this.AutoIndent ? 1 : 0)) != 0 && this.Selection.Start.iChar > 0)
              Class39.smethod_44(this);
          }
        }
        if (this.AutoIndentChars)
          this.DoAutoIndentChars(this.Selection.Start.iLine);
        this.OnKeyPressed('ÿ');
        break;
      case FCTBAction.FindChar:
        this.bool_30 = true;
        break;
      case FCTBAction.FindDialog:
        this.ShowFindDialog();
        break;
      case FCTBAction.FindNext:
        if ((this.findForm == null ? 1 : (this.findForm.tbFind.Text == "" ? 1 : 0)) != 0)
        {
          this.ShowFindDialog();
          break;
        }
        this.findForm.FindNext(this.findForm.tbFind.Text);
        break;
      case FCTBAction.GoDown:
        Class39.smethod_713(this.Selection, false);
        this.ScrollLeft();
        break;
      case FCTBAction.GoDownWithSelection:
        Class39.smethod_713(this.Selection, true);
        this.ScrollLeft();
        break;
      case FCTBAction.GoDown_ColumnSelectionMode:
        this.CheckAndChangeSelectionType();
        if (this.Selection.ColumnSelectionMode)
          Class39.smethod_186(this.Selection);
        this.Invalidate();
        break;
      case FCTBAction.GoEnd:
        Class39.smethod_710(this.Selection, false);
        break;
      case FCTBAction.GoEndWithSelection:
        Class39.smethod_710(this.Selection, true);
        break;
      case FCTBAction.GoFirstLine:
        Class39.smethod_461(this.Selection, false);
        break;
      case FCTBAction.GoFirstLineWithSelection:
        Class39.smethod_461(this.Selection, true);
        break;
      case FCTBAction.GoHome:
        Class39.smethod_797(this, false);
        this.ScrollLeft();
        break;
      case FCTBAction.GoHomeWithSelection:
        Class39.smethod_797(this, true);
        this.ScrollLeft();
        break;
      case FCTBAction.GoLastLine:
        Class39.smethod_342(this.Selection, false);
        break;
      case FCTBAction.GoLastLineWithSelection:
        Class39.smethod_342(this.Selection, true);
        break;
      case FCTBAction.GoLeft:
        this.Selection.GoLeft(false);
        break;
      case FCTBAction.GoLeftWithSelection:
        this.Selection.GoLeft(true);
        break;
      case FCTBAction.GoLeft_ColumnSelectionMode:
        this.CheckAndChangeSelectionType();
        if (this.Selection.ColumnSelectionMode)
          Class39.smethod_198(this.Selection);
        this.Invalidate();
        break;
      case FCTBAction.GoPageDown:
        Class39.smethod_227(this.Selection, false);
        this.ScrollLeft();
        break;
      case FCTBAction.GoPageDownWithSelection:
        Class39.smethod_227(this.Selection, true);
        this.ScrollLeft();
        break;
      case FCTBAction.GoPageUp:
        Class39.smethod_17(this.Selection, false);
        this.ScrollLeft();
        break;
      case FCTBAction.GoPageUpWithSelection:
        Class39.smethod_17(this.Selection, true);
        this.ScrollLeft();
        break;
      case FCTBAction.GoRight:
        this.Selection.GoRight(false);
        break;
      case FCTBAction.GoRightWithSelection:
        this.Selection.GoRight(true);
        break;
      case FCTBAction.GoRight_ColumnSelectionMode:
        this.CheckAndChangeSelectionType();
        if (this.Selection.ColumnSelectionMode)
          Class39.smethod_847(this.Selection);
        this.Invalidate();
        break;
      case FCTBAction.GoToDialog:
        this.ShowGoToDialog();
        break;
      case FCTBAction.GoNextBookmark:
        this.GotoNextBookmark(this.Selection.Start.iLine);
        break;
      case FCTBAction.GoPrevBookmark:
        this.GotoPrevBookmark(this.Selection.Start.iLine);
        break;
      case FCTBAction.GoUp:
        Class39.smethod_486(this.Selection, false);
        this.ScrollLeft();
        break;
      case FCTBAction.GoUpWithSelection:
        Class39.smethod_486(this.Selection, true);
        this.ScrollLeft();
        break;
      case FCTBAction.GoUp_ColumnSelectionMode:
        this.CheckAndChangeSelectionType();
        if (this.Selection.ColumnSelectionMode)
          Class39.smethod_379(this.Selection);
        this.Invalidate();
        break;
      case FCTBAction.GoWordLeft:
        this.Selection.GoWordLeft(false);
        break;
      case FCTBAction.GoWordLeftWithSelection:
        this.Selection.GoWordLeft(true);
        break;
      case FCTBAction.GoWordRight:
        this.Selection.GoWordRight(false, true);
        break;
      case FCTBAction.GoWordRightWithSelection:
        this.Selection.GoWordRight(true, true);
        break;
      case FCTBAction.IndentIncrease:
        if (this.Selection.ReadOnly)
          break;
        Range range1 = this.Selection.Clone();
        bool flag = range1.Start > range1.End;
        range1.Normalize();
        int startSpacesCount = this[range1.Start.iLine].StartSpacesCount;
        if ((range1.Start.iLine != range1.End.iLine || range1.Start.iChar <= startSpacesCount && range1.End.iChar == this[range1.Start.iLine].Count ? 1 : (range1.End.iChar <= startSpacesCount ? 1 : 0)) != 0)
        {
          this.IncreaseIndent();
          if ((range1.Start.iLine != range1.End.iLine ? 0 : (!range1.IsEmpty ? 1 : 0)) == 0)
            break;
          this.Selection = new Range(this, this[range1.Start.iLine].StartSpacesCount, range1.End.iLine, this[range1.Start.iLine].Count, range1.End.iLine);
          if (!flag)
            break;
          this.Selection.Inverse();
          break;
        }
        this.ProcessKey('\t', Keys.None);
        break;
      case FCTBAction.IndentDecrease:
        if (this.Selection.ReadOnly)
          break;
        Range range2 = this.Selection.Clone();
        if (range2.Start.iLine == range2.End.iLine)
        {
          Line line = this[range2.Start.iLine];
          if ((range2.Start.iChar != 0 ? 0 : (range2.End.iChar == line.Count ? 1 : 0)) != 0)
            this.Selection = new Range(this, line.StartSpacesCount, range2.Start.iLine, line.Count, range2.Start.iLine);
          else if ((range2.Start.iChar != line.Count ? 0 : (range2.End.iChar == 0 ? 1 : 0)) != 0)
            this.Selection = new Range(this, line.Count, range2.Start.iLine, line.StartSpacesCount, range2.Start.iLine);
        }
        this.DecreaseIndent();
        break;
      case FCTBAction.LowerCase:
        if (this.Selection.ReadOnly)
          break;
        this.LowerCase();
        break;
      case FCTBAction.MacroExecute:
        if (this.MacrosManager == null)
          break;
        this.MacrosManager.IsRecording = false;
        this.MacrosManager.ExecuteMacros();
        break;
      case FCTBAction.MacroRecord:
        if (this.MacrosManager == null)
          break;
        if (this.MacrosManager.AllowMacroRecordingByUser)
          this.MacrosManager.IsRecording = !this.MacrosManager.IsRecording;
        if (!this.MacrosManager.IsRecording)
          break;
        this.MacrosManager.ClearMacros();
        break;
      case FCTBAction.MoveSelectedLinesDown:
        if (this.Selection.ColumnSelectionMode)
          break;
        this.MoveSelectedLinesDown();
        break;
      case FCTBAction.MoveSelectedLinesUp:
        if (this.Selection.ColumnSelectionMode)
          break;
        this.MoveSelectedLinesUp();
        break;
      case FCTBAction.NavigateBackward:
        this.NavigateBackward();
        break;
      case FCTBAction.NavigateForward:
        this.NavigateForward();
        break;
      case FCTBAction.Paste:
        if (this.Selection.ReadOnly)
          break;
        this.Paste();
        break;
      case FCTBAction.Redo:
        if (this.ReadOnly)
          break;
        this.Redo();
        break;
      case FCTBAction.ReplaceDialog:
        this.ShowReplaceDialog();
        break;
      case FCTBAction.ReplaceMode:
        if (this.ReadOnly)
          break;
        this.bool_5 = !this.bool_5;
        break;
      case FCTBAction.ScrollDown:
        this.method_15(1, -1);
        break;
      case FCTBAction.ScrollUp:
        this.method_15(1, 1);
        break;
      case FCTBAction.SelectAll:
        this.Selection.SelectAll();
        break;
      case FCTBAction.UnbookmarkLine:
        this.UnbookmarkLine(this.Selection.Start.iLine);
        break;
      case FCTBAction.Undo:
        if (this.ReadOnly)
          break;
        this.Undo();
        break;
      case FCTBAction.UpperCase:
        if (this.Selection.ReadOnly)
          break;
        this.UpperCase();
        break;
      case FCTBAction.ZoomIn:
        this.ChangeFontSize(2);
        break;
      case FCTBAction.ZoomNormal:
        Class39.smethod_365(this);
        break;
      case FCTBAction.ZoomOut:
        this.ChangeFontSize(-2);
        break;
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
        this.OnCustomAction(new CustomActionEventArgs(fctbaction_0));
        break;
    }
  }

  protected virtual void OnCustomAction(CustomActionEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_19 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_19((object) this, e);
  }

  public bool GotoNextBookmark(int iLine)
  {
    Bookmark bookmark1 = (Bookmark) null;
    int num1 = int.MaxValue;
    Bookmark bookmark2 = (Bookmark) null;
    int num2 = int.MaxValue;
    foreach (Bookmark bookmark3 in this.baseBookmarks_0)
    {
      if (bookmark3.LineIndex < num2)
      {
        num2 = bookmark3.LineIndex;
        bookmark2 = bookmark3;
      }
      if ((bookmark3.LineIndex <= iLine ? 0 : (bookmark3.LineIndex < num1 ? 1 : 0)) != 0)
      {
        num1 = bookmark3.LineIndex;
        bookmark1 = bookmark3;
      }
    }
    bool flag;
    if (bookmark1 != null)
    {
      bookmark1.DoVisible();
      flag = true;
    }
    else if (bookmark2 != null)
    {
      bookmark2.DoVisible();
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public bool GotoPrevBookmark(int iLine)
  {
    Bookmark bookmark1 = (Bookmark) null;
    int num1 = -1;
    Bookmark bookmark2 = (Bookmark) null;
    int num2 = -1;
    foreach (Bookmark bookmark3 in this.baseBookmarks_0)
    {
      if (bookmark3.LineIndex > num2)
      {
        num2 = bookmark3.LineIndex;
        bookmark2 = bookmark3;
      }
      if ((bookmark3.LineIndex >= iLine ? 0 : (bookmark3.LineIndex > num1 ? 1 : 0)) != 0)
      {
        num1 = bookmark3.LineIndex;
        bookmark1 = bookmark3;
      }
    }
    bool flag;
    if (bookmark1 != null)
    {
      bookmark1.DoVisible();
      flag = true;
    }
    else if (bookmark2 != null)
    {
      bookmark2.DoVisible();
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public virtual void BookmarkLine(int iLine)
  {
    if (this.baseBookmarks_0.Contains(iLine))
      return;
    this.baseBookmarks_0.Add(iLine);
  }

  public virtual void UnbookmarkLine(int iLine) => this.baseBookmarks_0.Remove(iLine);

  public virtual void MoveSelectedLinesDown()
  {
    Range range = this.Selection.Clone();
    this.Selection.Expand();
    if (!this.Selection.ReadOnly)
    {
      int iLine1 = this.Selection.Start.iLine;
      if (this.Selection.End.iLine >= this.LinesCount - 1)
      {
        this.Selection = range;
      }
      else
      {
        string selectedText = this.SelectedText;
        List<int> iLines = new List<int>();
        for (int iLine2 = this.Selection.Start.iLine; iLine2 <= this.Selection.End.iLine; ++iLine2)
          iLines.Add(iLine2);
        this.RemoveLines(iLines);
        this.Selection.Start = new Place(this.GetLineLength(iLine1), iLine1);
        this.SelectedText = "\n" + selectedText;
        this.Selection.Start = new Place(range.Start.iChar, range.Start.iLine + 1);
        this.Selection.End = new Place(range.End.iChar, range.End.iLine + 1);
      }
    }
    else
      this.Selection = range;
  }

  public virtual void MoveSelectedLinesUp()
  {
    Range range = this.Selection.Clone();
    this.Selection.Expand();
    if (!this.Selection.ReadOnly)
    {
      int iLine1 = this.Selection.Start.iLine;
      if (iLine1 == 0)
      {
        this.Selection = range;
      }
      else
      {
        string selectedText = this.SelectedText;
        List<int> iLines = new List<int>();
        for (int iLine2 = this.Selection.Start.iLine; iLine2 <= this.Selection.End.iLine; ++iLine2)
          iLines.Add(iLine2);
        this.RemoveLines(iLines);
        this.Selection.Start = new Place(0, iLine1 - 1);
        this.SelectedText = selectedText + "\n";
        this.Selection.Start = new Place(range.Start.iChar, range.Start.iLine - 1);
        this.Selection.End = new Place(range.End.iChar, range.End.iLine - 1);
      }
    }
    else
      this.Selection = range;
  }

  public virtual void UpperCase()
  {
    Range range = this.Selection.Clone();
    this.SelectedText = this.SelectedText.ToUpper();
    this.Selection.Start = range.Start;
    this.Selection.End = range.End;
  }

  public virtual void LowerCase()
  {
    Range range = this.Selection.Clone();
    this.SelectedText = this.SelectedText.ToLower();
    this.Selection.Start = range.Start;
    this.Selection.End = range.End;
  }

  public virtual void TitleCase()
  {
    Range range = this.Selection.Clone();
    this.SelectedText = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.SelectedText.ToLower());
    this.Selection.Start = range.Start;
    this.Selection.End = range.End;
  }

  public virtual void SentenceCase()
  {
    Range range = this.Selection.Clone();
    this.SelectedText = new Regex("(^\\S)|[\\.\\?!:]\\s+(\\S)", RegexOptions.ExplicitCapture).Replace(this.SelectedText.ToLower(), (MatchEvaluator) (match_0 => match_0.Value.ToUpper()));
    this.Selection.Start = range.Start;
    this.Selection.End = range.End;
  }

  public void CommentSelected() => this.CommentSelected(this.CommentPrefix);

  public virtual void CommentSelected(string commentPrefix)
  {
    if (string.IsNullOrEmpty(commentPrefix))
      return;
    this.Selection.Normalize();
    if (this.textSource_0[this.Selection.Start.iLine].Text.TrimStart().StartsWith(commentPrefix))
      this.RemoveLinePrefix(commentPrefix);
    else
      this.InsertLinePrefix(commentPrefix);
  }

  public void OnKeyPressing(KeyPressEventArgs args)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.keyPressEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.keyPressEventHandler_0((object) this, args);
  }

  private bool method_11(char char_5)
  {
    bool flag;
    if (this.bool_30)
    {
      this.bool_30 = false;
      this.FindChar(char_5);
      flag = true;
    }
    else
    {
      KeyPressEventArgs args = new KeyPressEventArgs(char_5);
      this.OnKeyPressing(args);
      flag = args.Handled;
    }
    return flag;
  }

  public void OnKeyPressed(char c)
  {
    KeyPressEventArgs e = new KeyPressEventArgs(c);
    // ISSUE: reference to a compiler-generated field
    if (this.keyPressEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.keyPressEventHandler_1((object) this, e);
  }

  protected override bool ProcessMnemonic(char charCode)
  {
    return !this.bool_33 && this.Focused && (this.ProcessKey(charCode, this.keys_0) || base.ProcessMnemonic(charCode));
  }

  protected override bool ProcessKeyMessage(ref Message m)
  {
    if (m.Msg == 258)
      this.ProcessMnemonic(Convert.ToChar(m.WParam.ToInt32()));
    return base.ProcessKeyMessage(ref m);
  }

  public virtual bool ProcessKey(char c, Keys modifiers)
  {
    bool flag;
    if (this.bool_1)
    {
      flag = true;
    }
    else
    {
      if (this.macrosManager_0 != null)
        Class39.smethod_500(c, this.macrosManager_0, modifiers);
      if ((c != '\b' ? 0 : (modifiers == Keys.None || modifiers == Keys.Shift ? 1 : ((modifiers & Keys.Alt) != 0 ? 1 : 0))) != 0)
      {
        if ((this.ReadOnly ? 1 : (!this.Enabled ? 1 : 0)) != 0)
          flag = false;
        else if (this.method_11(c))
          flag = true;
        else if (this.Selection.ReadOnly)
        {
          flag = false;
        }
        else
        {
          if (!this.Selection.IsEmpty)
            this.ClearSelected();
          else if (!this.Selection.IsReadOnlyLeftChar())
            this.InsertChar('\b');
          if (this.AutoIndentChars)
            this.DoAutoIndentChars(this.Selection.Start.iLine);
          this.OnKeyPressed('\b');
          flag = true;
        }
      }
      else if ((!char.IsControl(c) || c == '\r' ? 0 : (c != '\t' ? 1 : 0)) != 0)
        flag = false;
      else if ((this.ReadOnly ? 1 : (!this.Enabled ? 1 : 0)) != 0)
      {
        flag = false;
      }
      else
      {
        int num;
        switch (modifiers)
        {
          case Keys.None:
          case Keys.Shift:
          case Keys.Control | Keys.Alt:
          case Keys.Shift | Keys.Control | Keys.Alt:
            num = 0;
            break;
          case Keys.Alt:
            num = char.IsLetterOrDigit(c) ? 1 : 0;
            break;
          default:
            num = 1;
            break;
        }
        if (num != 0)
        {
          flag = false;
        }
        else
        {
          char ch = c;
          if (this.method_11(ch))
            flag = true;
          else if (this.Selection.ReadOnly)
            flag = false;
          else if ((c != '\r' ? 0 : (!this.AcceptsReturn ? 1 : 0)) != 0)
          {
            flag = false;
          }
          else
          {
            if (c == '\r')
              c = '\n';
            if (this.IsReplaceMode)
            {
              this.Selection.GoRight(true);
              this.Selection.Inverse();
            }
            if (!this.Selection.ReadOnly && !Class39.smethod_829(c, this))
              this.InsertChar(c);
            if ((c == '\n' ? 1 : (this.AutoIndentExistingLines ? 1 : 0)) != 0)
              this.DoAutoIndentIfNeed();
            if (this.AutoIndentChars)
              this.DoAutoIndentChars(this.Selection.Start.iLine);
            this.DoCaretVisible();
            this.Invalidate();
            this.OnKeyPressed(ch);
            flag = true;
          }
        }
      }
    }
    return flag;
  }

  [Description("Enables AutoIndentChars mode")]
  [DefaultValue(true)]
  public bool AutoIndentChars { get; set; }

  [Description("Regex patterns for AutoIndentChars (one regex per line)")]
  [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
  [DefaultValue("^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);")]
  public string AutoIndentCharsPatterns { get; set; }

  public void DoAutoIndentChars(int iLine)
  {
    string indentCharsPatterns = this.AutoIndentCharsPatterns;
    char[] separator = new char[2]{ '\r', '\n' };
    foreach (string pattern in indentCharsPatterns.Split(separator, StringSplitOptions.RemoveEmptyEntries))
    {
      if (Regex.Match(this[iLine].Text, pattern).Success)
      {
        this.DoAutoIndentChars(iLine, new Regex(pattern));
        break;
      }
    }
  }

  protected void DoAutoIndentChars(int iLine, Regex regex)
  {
    Range range = this.Selection.Clone();
    SortedDictionary<int, CaptureCollection> sortedDictionary1 = new SortedDictionary<int, CaptureCollection>();
    SortedDictionary<int, string> sortedDictionary2 = new SortedDictionary<int, string>();
    int num1 = 0;
    int startSpacesCount = this[iLine].StartSpacesCount;
    for (int index = iLine; index >= 0 && startSpacesCount == this[index].StartSpacesCount; --index)
    {
      string text = this[index].Text;
      Match match = regex.Match(text);
      if (match.Success)
      {
        sortedDictionary1[index] = match.Groups["range"].Captures;
        sortedDictionary2[index] = text;
        if (sortedDictionary1[index].Count > num1)
          num1 = sortedDictionary1[index].Count;
      }
      else
        break;
    }
    for (int index = iLine + 1; index < this.LinesCount && startSpacesCount == this[index].StartSpacesCount; ++index)
    {
      string text = this[index].Text;
      Match match = regex.Match(text);
      if (match.Success)
      {
        sortedDictionary1[index] = match.Groups["range"].Captures;
        sortedDictionary2[index] = text;
        if (sortedDictionary1[index].Count > num1)
          num1 = sortedDictionary1[index].Count;
      }
      else
        break;
    }
    Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
    bool flag = false;
    for (int i = num1 - 1; i >= 0; --i)
    {
      int num2 = 0;
      foreach (int key in sortedDictionary1.Keys)
      {
        CaptureCollection captureCollection = sortedDictionary1[key];
        if (captureCollection.Count > i)
        {
          int index = captureCollection[i].Index;
          string str = sortedDictionary2[key];
          while ((index <= 0 ? 0 : (str[index - 1] == ' ' ? 1 : 0)) != 0)
            --index;
          int num3 = i != 0 ? index - captureCollection[i - 1].Index - 1 : index;
          if (num3 > num2)
            num2 = num3;
        }
      }
      foreach (int num4 in new List<int>((IEnumerable<int>) sortedDictionary2.Keys))
      {
        if (sortedDictionary1[num4].Count > i)
        {
          System.Text.RegularExpressions.Capture capture = sortedDictionary1[num4][i];
          int num5 = i != 0 ? capture.Index - sortedDictionary1[num4][i - 1].Index - 1 : capture.Index;
          int count = num2 - num5 + 1;
          if (count != 0)
          {
            if ((range.Start.iLine != num4 ? 0 : (range.Start.iChar > capture.Index ? 1 : 0)) != 0)
              range.Start = new Place(range.Start.iChar + count, num4);
            sortedDictionary2[num4] = count <= 0 ? sortedDictionary2[num4].Remove(capture.Index + count, -count) : sortedDictionary2[num4].Insert(capture.Index, new string(' ', count));
            dictionary[num4] = true;
            flag = true;
          }
        }
      }
    }
    if (!flag)
      return;
    this.Selection.BeginUpdate();
    this.BeginAutoUndo();
    this.BeginUpdate();
    this.TextSource.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
    foreach (int key in sortedDictionary2.Keys)
    {
      if (dictionary.ContainsKey(key))
      {
        this.Selection = new Range(this, 0, key, this[key].Count, key);
        if (!this.Selection.ReadOnly)
          this.InsertText(sortedDictionary2[key]);
      }
    }
    this.Selection = range;
    this.EndUpdate();
    this.EndAutoUndo();
    this.Selection.EndUpdate();
  }

  internal bool method_12(char char_5, char char_6)
  {
    if (this.Selection.ColumnSelectionMode)
    {
      Range range = this.Selection.Clone();
      range.Normalize();
      this.Selection.BeginUpdate();
      this.BeginAutoUndo();
      this.Selection = new Range(this, range.Start.iChar, range.Start.iLine, range.Start.iChar, range.End.iLine)
      {
        ColumnSelectionMode = true
      };
      this.InsertChar(char_5);
      this.Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine)
      {
        ColumnSelectionMode = true
      };
      this.InsertChar(char_6);
      if (range.IsEmpty)
        this.Selection = new Range(this, range.End.iChar + 1, range.Start.iLine, range.End.iChar + 1, range.End.iLine)
        {
          ColumnSelectionMode = true
        };
      this.EndAutoUndo();
      this.Selection.EndUpdate();
    }
    else if (this.Selection.IsEmpty)
    {
      this.InsertText(char_5.ToString() + char_6.ToString());
      this.Selection.GoLeft();
    }
    else
      this.InsertText(char_5.ToString() + this.SelectedText + char_6.ToString());
    return true;
  }

  protected virtual void FindChar(char c)
  {
    if (c == '\r')
      c = '\n';
    Range range = this.Selection.Clone();
    while (range.GoRight())
    {
      if ((int) range.CharBeforeStart == (int) c)
      {
        this.Selection = range;
        this.DoCaretVisible();
        break;
      }
    }
  }

  public virtual void DoAutoIndentIfNeed()
  {
    if (this.Selection.ColumnSelectionMode || !this.AutoIndent)
      return;
    this.DoCaretVisible();
    int num = this.CalcAutoIndent(this.Selection.Start.iLine);
    if (this[this.Selection.Start.iLine].AutoIndentSpacesNeededCount == num)
      return;
    this.DoAutoIndent(this.Selection.Start.iLine);
    this[this.Selection.Start.iLine].AutoIndentSpacesNeededCount = num;
  }

  public virtual void DoAutoIndent(int iLine)
  {
    if (this.Selection.ColumnSelectionMode)
      return;
    Place start = this.Selection.Start;
    int num = this.CalcAutoIndent(iLine);
    int startSpacesCount = this.textSource_0[iLine].StartSpacesCount;
    int count = num - startSpacesCount;
    if (count < 0)
      count = -Math.Min(-count, startSpacesCount);
    if (count == 0)
      return;
    this.Selection.Start = new Place(0, iLine);
    if (count > 0)
    {
      this.InsertText(new string(' ', count));
    }
    else
    {
      this.Selection.Start = new Place(0, iLine);
      this.Selection.End = new Place(-count, iLine);
      this.ClearSelected();
    }
    this.Selection.Start = new Place(Math.Min(this.textSource_0[iLine].Count, Math.Max(0, start.iChar + count)), iLine);
  }

  public virtual int CalcAutoIndent(int iLine)
  {
    int num1;
    if ((iLine < 0 ? 1 : (iLine >= this.LinesCount ? 1 : 0)) != 0)
    {
      num1 = 0;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      EventHandler<AutoIndentEventArgs> eventHandler = this.eventHandler_12 ?? ((this.Language == Language.Custom ? 0 : (this.SyntaxHighlighter != null ? 1 : 0)) == 0 ? new EventHandler<AutoIndentEventArgs>(this.vmethod_0) : new EventHandler<AutoIndentEventArgs>(this.SyntaxHighlighter.AutoIndentNeeded));
      Stack<AutoIndentEventArgs> autoIndentEventArgsStack = new Stack<AutoIndentEventArgs>();
      int num2;
      for (num2 = iLine - 1; num2 >= 0; --num2)
      {
        AutoIndentEventArgs e = new AutoIndentEventArgs(num2, this.textSource_0[num2].Text, num2 > 0 ? this.textSource_0[num2 - 1].Text : "", this.TabLength, 0);
        eventHandler((object) this, e);
        autoIndentEventArgsStack.Push(e);
        if ((e.Shift != 0 || e.AbsoluteIndentation != 0 ? 0 : (e.LineText.Trim() != "" ? 1 : 0)) != 0)
          break;
      }
      int currentIndentation = this.textSource_0[num2 >= 0 ? num2 : 0].StartSpacesCount;
      while (autoIndentEventArgsStack.Count != 0)
      {
        AutoIndentEventArgs autoIndentEventArgs = autoIndentEventArgsStack.Pop();
        if (autoIndentEventArgs.AbsoluteIndentation != 0)
          currentIndentation = autoIndentEventArgs.AbsoluteIndentation + autoIndentEventArgs.ShiftNextLines;
        else
          currentIndentation += autoIndentEventArgs.ShiftNextLines;
      }
      AutoIndentEventArgs e1 = new AutoIndentEventArgs(iLine, this.textSource_0[iLine].Text, iLine > 0 ? this.textSource_0[iLine - 1].Text : "", this.TabLength, currentIndentation);
      eventHandler((object) this, e1);
      num1 = e1.AbsoluteIndentation + e1.Shift;
    }
    return num1;
  }

  internal virtual void vmethod_0(object sender, AutoIndentEventArgs e)
  {
    if ((!string.IsNullOrEmpty(this.textSource_0[e.iLine].FoldingEndMarker) ? 0 : (!string.IsNullOrEmpty(this.textSource_0[e.iLine].FoldingStartMarker) ? 1 : 0)) != 0)
    {
      e.ShiftNextLines = this.TabLength;
    }
    else
    {
      if ((string.IsNullOrEmpty(this.textSource_0[e.iLine].FoldingEndMarker) ? 0 : (string.IsNullOrEmpty(this.textSource_0[e.iLine].FoldingStartMarker) ? 1 : 0)) == 0)
        return;
      e.Shift = -this.TabLength;
      e.ShiftNextLines = -this.TabLength;
    }
  }

  protected int GetMinStartSpacesCount(int fromLine, int toLine)
  {
    int startSpacesCount1;
    if (fromLine > toLine)
    {
      startSpacesCount1 = 0;
    }
    else
    {
      int num = int.MaxValue;
      for (int i = fromLine; i <= toLine; ++i)
      {
        int startSpacesCount2 = this.textSource_0[i].StartSpacesCount;
        if (startSpacesCount2 < num)
          num = startSpacesCount2;
      }
      startSpacesCount1 = num;
    }
    return startSpacesCount1;
  }

  protected int GetMaxStartSpacesCount(int fromLine, int toLine)
  {
    int startSpacesCount1;
    if (fromLine > toLine)
    {
      startSpacesCount1 = 0;
    }
    else
    {
      int num = 0;
      for (int i = fromLine; i <= toLine; ++i)
      {
        int startSpacesCount2 = this.textSource_0[i].StartSpacesCount;
        if (startSpacesCount2 > num)
          num = startSpacesCount2;
      }
      startSpacesCount1 = num;
    }
    return startSpacesCount1;
  }

  public virtual void Undo()
  {
    this.textSource_0.Manager.Undo();
    this.DoCaretVisible();
    this.Invalidate();
  }

  public virtual void Redo()
  {
    Class39.smethod_553(this.textSource_0.Manager);
    this.DoCaretVisible();
    this.Invalidate();
  }

  protected override bool IsInputKey(Keys keyData)
  {
    bool flag;
    if ((keyData != Keys.Tab ? 0 : (!this.AcceptsTab ? 1 : 0)) != 0)
      flag = false;
    else if ((keyData != Keys.Return ? 0 : (!this.AcceptsReturn ? 1 : 0)) != 0)
      flag = false;
    else if ((keyData & Keys.Alt) == Keys.None && (keyData & Keys.KeyCode) == Keys.Return)
    {
      flag = true;
    }
    else
    {
      if ((keyData & Keys.Alt) != Keys.Alt)
      {
        switch (keyData & Keys.KeyCode)
        {
          case Keys.Tab:
            flag = (keyData & Keys.Control) == Keys.None;
            goto label_12;
          case Keys.Escape:
            flag = false;
            goto label_12;
          case Keys.Prior:
          case Keys.Next:
          case Keys.End:
          case Keys.Home:
          case Keys.Left:
          case Keys.Up:
          case Keys.Right:
          case Keys.Down:
            flag = true;
            goto label_12;
        }
      }
      flag = base.IsInputKey(keyData);
    }
label_12:
    return flag;
  }

  protected override void OnPaintBackground(PaintEventArgs e)
  {
    if (this.BackBrush == null)
      base.OnPaintBackground(e);
    else
      e.Graphics.FillRectangle(this.BackBrush, this.ClientRectangle);
  }

  public void DrawText(Graphics gr, Place start, Size size)
  {
    if (this.needRecalc)
      Class39.smethod_722(this);
    if (this.bool_9)
      this.RecalcFoldingLines();
    Point point = this.PlaceToPoint(start);
    int num1 = point.Y + this.VerticalScroll.Value;
    int num2 = point.X + this.HorizontalScroll.Value - this.LeftIndent - this.Paddings.Left;
    int iChar = start.iChar;
    int int_4 = (num2 + size.Width) / this.CharWidth;
    for (int iLine = start.iLine; iLine < this.textSource_0.Count; ++iLine)
    {
      Line line = this.textSource_0[iLine];
      LineInfo lineInfo = this.LineInfos[iLine];
      if (lineInfo.startY > num1 + size.Height)
        break;
      if (lineInfo.startY + lineInfo.WordWrapStringsCount * this.CharHeight >= num1 && lineInfo.VisibleState != VisibleState.Hidden)
      {
        int y = lineInfo.startY - num1;
        gr.SmoothingMode = SmoothingMode.None;
        if (lineInfo.VisibleState == VisibleState.Visible && line.BackgroundBrush != null)
          gr.FillRectangle(line.BackgroundBrush, new Rectangle(0, y, size.Width, this.CharHeight * lineInfo.WordWrapStringsCount));
        gr.SmoothingMode = SmoothingMode.AntiAlias;
        for (int int_1 = 0; int_1 < lineInfo.WordWrapStringsCount; ++int_1)
        {
          int int_3 = lineInfo.startY + int_1 * this.CharHeight - num1;
          int num3 = int_1 == 0 ? 0 : lineInfo.int_1 * this.CharWidth;
          Class39.smethod_675(-num2 + num3, int_1, iChar, gr, int_3, int_4, iLine, this);
        }
      }
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    if (this.needRecalc)
      Class39.smethod_722(this);
    if (this.bool_9)
      this.RecalcFoldingLines();
    this.list_0.Clear();
    e.Graphics.SmoothingMode = SmoothingMode.None;
    Pen pen1 = new Pen(this.ServiceLinesColor);
    Brush brush1 = (Brush) new SolidBrush(this.ChangedLineColor);
    Brush brush2 = (Brush) new SolidBrush(this.IndentBackColor);
    Brush brush3 = (Brush) new SolidBrush(this.PaddingBackColor);
    Brush brush4 = (Brush) new SolidBrush(Color.FromArgb(this.CurrentLineColor.A == byte.MaxValue ? 50 : (int) this.CurrentLineColor.A, this.CurrentLineColor));
    Rectangle textAreaRect = this.TextAreaRect;
    e.Graphics.FillRectangle(brush3, 0, -this.VerticalScroll.Value, this.ClientSize.Width, Math.Max(0, this.Paddings.Top - 1));
    Graphics graphics1 = e.Graphics;
    Brush brush5 = brush3;
    int bottom = textAreaRect.Bottom;
    int width1 = this.ClientSize.Width;
    Size clientSize = this.ClientSize;
    int height1 = clientSize.Height;
    graphics1.FillRectangle(brush5, 0, bottom, width1, height1);
    Graphics graphics2 = e.Graphics;
    Brush brush6 = brush3;
    int right = textAreaRect.Right;
    clientSize = this.ClientSize;
    int width2 = clientSize.Width;
    clientSize = this.ClientSize;
    int height2 = clientSize.Height;
    graphics2.FillRectangle(brush6, right, 0, width2, height2);
    Graphics graphics3 = e.Graphics;
    Brush brush7 = brush3;
    int x1 = Class39.smethod_612(this);
    int width3 = this.LeftIndent - Class39.smethod_612(this) - 1;
    clientSize = this.ClientSize;
    int height3 = clientSize.Height;
    graphics3.FillRectangle(brush7, x1, 0, width3, height3);
    Padding paddings;
    if (this.HorizontalScroll.Value <= this.Paddings.Left)
    {
      Graphics graphics4 = e.Graphics;
      Brush brush8 = brush3;
      int x2 = this.LeftIndent - this.HorizontalScroll.Value - 2;
      paddings = this.Paddings;
      int width4 = Math.Max(0, paddings.Left - 1);
      clientSize = this.ClientSize;
      int height4 = clientSize.Height;
      graphics4.FillRectangle(brush8, x2, 0, width4, height4);
    }
    int leftIndent1 = this.LeftIndent;
    int leftIndent2 = this.LeftIndent;
    paddings = this.Paddings;
    int left1 = paddings.Left;
    int val2 = leftIndent2 + left1 - this.HorizontalScroll.Value;
    Math.Max(leftIndent1, val2);
    int width5 = textAreaRect.Width;
    Graphics graphics5 = e.Graphics;
    Brush brush9 = brush2;
    int width6 = Class39.smethod_612(this);
    clientSize = this.ClientSize;
    int height5 = clientSize.Height;
    graphics5.FillRectangle(brush9, 0, 0, width6, height5);
    if (this.LeftIndent > 8)
    {
      Graphics graphics6 = e.Graphics;
      Pen pen2 = pen1;
      int x1_1 = Class39.smethod_612(this);
      int x2 = Class39.smethod_612(this);
      clientSize = this.ClientSize;
      int height6 = clientSize.Height;
      graphics6.DrawLine(pen2, x1_1, 0, x2, height6);
    }
    if (this.PreferredLineWidth > 0)
    {
      Graphics graphics7 = e.Graphics;
      Pen pen3 = pen1;
      int leftIndent3 = this.LeftIndent;
      paddings = this.Paddings;
      int left2 = paddings.Left;
      Point pt1 = new Point(leftIndent3 + left2 + this.PreferredLineWidth * this.CharWidth - this.HorizontalScroll.Value + 1, textAreaRect.Top + 1);
      int leftIndent4 = this.LeftIndent;
      paddings = this.Paddings;
      int left3 = paddings.Left;
      Point pt2 = new Point(leftIndent4 + left3 + this.PreferredLineWidth * this.CharWidth - this.HorizontalScroll.Value + 1, textAreaRect.Bottom - 1);
      graphics7.DrawLine(pen3, pt1, pt2);
    }
    Class39.smethod_636(this, e.Graphics);
    int num1 = this.HorizontalScroll.Value;
    paddings = this.Paddings;
    int left4 = paddings.Left;
    int int_2 = Math.Max(0, num1 - left4) / this.CharWidth;
    int num2 = this.HorizontalScroll.Value;
    clientSize = this.ClientSize;
    int width7 = clientSize.Width;
    int int_4 = (num2 + width7) / this.CharWidth;
    int leftIndent5 = this.LeftIndent;
    paddings = this.Paddings;
    int left5 = paddings.Left;
    int num3 = leftIndent5 + left5 - this.HorizontalScroll.Value;
    if (num3 < this.LeftIndent)
      ++int_2;
    Dictionary<int, Bookmark> dictionary = new Dictionary<int, Bookmark>();
    foreach (Bookmark bookmark in this.baseBookmarks_0)
      dictionary[bookmark.LineIndex] = bookmark;
    int startLine = Class39.smethod_53(this, this.VerticalScroll.Value);
    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    int num4;
    for (num4 = startLine; num4 < this.textSource_0.Count; ++num4)
    {
      Line line = this.textSource_0[num4];
      LineInfo lineInfo = this.LineInfos[num4];
      if (lineInfo.startY <= this.VerticalScroll.Value + this.ClientSize.Height)
      {
        if (lineInfo.startY + lineInfo.WordWrapStringsCount * this.CharHeight >= this.VerticalScroll.Value && lineInfo.VisibleState != VisibleState.Hidden)
        {
          int y = lineInfo.startY - this.VerticalScroll.Value;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          if (lineInfo.VisibleState == VisibleState.Visible && line.BackgroundBrush != null)
            e.Graphics.FillRectangle(line.BackgroundBrush, new Rectangle(textAreaRect.Left, y, textAreaRect.Width, this.CharHeight * lineInfo.WordWrapStringsCount));
          if ((!(this.CurrentLineColor != Color.Transparent) ? 0 : (num4 == this.Selection.Start.iLine ? 1 : 0)) != 0 && this.Selection.IsEmpty)
            e.Graphics.FillRectangle(brush4, new Rectangle(textAreaRect.Left, y, textAreaRect.Width, this.CharHeight));
          if ((!(this.ChangedLineColor != Color.Transparent) ? 0 : (line.IsChanged ? 1 : 0)) != 0)
            e.Graphics.FillRectangle(brush1, new RectangleF(-10f, (float) y, (float) (this.LeftIndent - 8 - 2 + 10), (float) (this.CharHeight + 1)));
          e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
          if (dictionary.ContainsKey(num4))
            dictionary[num4].Paint(e.Graphics, new Rectangle(this.LeftIndent, y, this.Width, this.CharHeight * lineInfo.WordWrapStringsCount));
          if (lineInfo.VisibleState == VisibleState.Visible)
            this.OnPaintLine(new PaintLineEventArgs(num4, new Rectangle(this.LeftIndent, y, this.Width, this.CharHeight * lineInfo.WordWrapStringsCount), e.Graphics, e.ClipRectangle));
          if (this.ShowLineNumbers)
          {
            using (SolidBrush solidBrush = new SolidBrush(this.LineNumberColor))
              e.Graphics.DrawString(((long) num4 + (long) this.uint_0).ToString(), this.Font, (Brush) solidBrush, new RectangleF(-10f, (float) y, (float) (this.LeftIndent - 8 - 2 + 10), (float) this.CharHeight), new StringFormat(StringFormatFlags.DirectionRightToLeft));
          }
          if (lineInfo.VisibleState == VisibleState.StartOfHiddenBlock)
            this.list_0.Add((VisualMarker) new ExpandFoldingMarker(num4, new Rectangle(Class39.smethod_612(this) - 4, y + this.CharHeight / 2 - 3, 8, 8)));
          if ((string.IsNullOrEmpty(line.FoldingStartMarker) || lineInfo.VisibleState != VisibleState.Visible ? 0 : (string.IsNullOrEmpty(line.FoldingEndMarker) ? 1 : 0)) != 0)
            this.list_0.Add((VisualMarker) new CollapseFoldingMarker(num4, new Rectangle(Class39.smethod_612(this) - 4, y + this.CharHeight / 2 - 3, 8, 8)));
          if ((lineInfo.VisibleState != VisibleState.Visible || string.IsNullOrEmpty(line.FoldingEndMarker) ? 0 : (string.IsNullOrEmpty(line.FoldingStartMarker) ? 1 : 0)) != 0)
            e.Graphics.DrawLine(pen1, Class39.smethod_612(this), y + this.CharHeight * lineInfo.WordWrapStringsCount - 1, Class39.smethod_612(this) + 4, y + this.CharHeight * lineInfo.WordWrapStringsCount - 1);
          for (int int_1 = 0; int_1 < lineInfo.WordWrapStringsCount; ++int_1)
          {
            int int_3 = lineInfo.startY + int_1 * this.CharHeight - this.VerticalScroll.Value;
            int num5 = int_1 == 0 ? 0 : lineInfo.int_1 * this.CharWidth;
            Class39.smethod_675(num3 + num5, int_1, int_2, e.Graphics, int_3, int_4, num4, this);
          }
        }
      }
      else
        break;
    }
    int endLine = num4 - 1;
    if (this.ShowFoldingLines)
      this.DrawFoldingLines(e, startLine, endLine);
    if (this.Selection.ColumnSelectionMode && this.SelectionStyle.BackgroundBrush is SolidBrush)
    {
      Color color = ((SolidBrush) this.SelectionStyle.BackgroundBrush).Color;
      Point point1 = this.PlaceToPoint(this.Selection.Start);
      Point point2 = this.PlaceToPoint(this.Selection.End);
      using (Pen pen4 = new Pen(color))
        e.Graphics.DrawRectangle(pen4, Rectangle.FromLTRB(Math.Min(point1.X, point2.X) - 1, Math.Min(point1.Y, point2.Y), Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y) + this.CharHeight));
    }
    if ((this.BracketsStyle == null || this.range_2 == null ? 0 : (this.range_4 != null ? 1 : 0)) != 0)
    {
      this.BracketsStyle.Draw(e.Graphics, this.PlaceToPoint(this.range_2.Start), this.range_2);
      this.BracketsStyle.Draw(e.Graphics, this.PlaceToPoint(this.range_4.Start), this.range_4);
    }
    if ((this.BracketsStyle2 == null || this.range_3 == null ? 0 : (this.range_5 != null ? 1 : 0)) != 0)
    {
      this.BracketsStyle2.Draw(e.Graphics, this.PlaceToPoint(this.range_3.Start), this.range_3);
      this.BracketsStyle2.Draw(e.Graphics, this.PlaceToPoint(this.range_5.Start), this.range_5);
    }
    e.Graphics.SmoothingMode = SmoothingMode.None;
    if ((this.int_7 >= 0 || this.int_1 >= 0 ? (this.Selection.Start == this.Selection.End ? 1 : 0) : 0) != 0 && this.int_1 < this.LineInfos.Count)
    {
      int y1 = (this.int_7 >= 0 ? this.LineInfos[this.int_7].startY : 0) - this.VerticalScroll.Value + this.CharHeight / 2;
      int y2 = (this.int_1 >= 0 ? this.LineInfos[this.int_1].startY + (this.LineInfos[this.int_1].WordWrapStringsCount - 1) * this.CharHeight : this.TextHeight + this.CharHeight) - this.VerticalScroll.Value + this.CharHeight;
      using (Pen pen5 = new Pen(Color.FromArgb(100, this.FoldingIndicatorColor), 4f))
        e.Graphics.DrawLine(pen5, this.LeftIndent - 5, y1, this.LeftIndent - 5, y2);
    }
    Class39.smethod_533(this, e.Graphics);
    this.method_13(e, pen1);
    Point point = this.PlaceToPoint(this.Selection.Start);
    int num6 = this.CharHeight - this.int_3;
    point.Offset(0, this.int_3 / 2);
    // ISSUE: reference to a compiler-generated method
    if ((!this.Focused && !this.method_20() && !this.ShowCaretWhenInactive || point.X < this.LeftIndent ? 0 : (this.CaretVisible ? 1 : 0)) != 0)
    {
      int num7 = this.IsReplaceMode || this.WideCaret ? this.CharWidth : 1;
      if (this.WideCaret)
      {
        using (SolidBrush solidBrush = new SolidBrush(this.CaretColor))
          e.Graphics.FillRectangle((Brush) solidBrush, point.X, point.Y, num7, num6 + 1);
      }
      else
      {
        using (Pen pen6 = new Pen(this.CaretColor))
          e.Graphics.DrawLine(pen6, point.X, point.Y, point.X, point.Y + num6);
      }
      Rectangle rectangle = new Rectangle(this.HorizontalScroll.Value + point.X, this.VerticalScroll.Value + point.Y, num7, num6 + 1);
      if (this.CaretBlinking && (this.rectangle_0 != rectangle ? 1 : (!this.ShowScrollBars ? 1 : 0)) != 0)
      {
        Class39.CreateCaret(this.Handle, 0, num7, num6 + 1);
        Class39.SetCaretPos(point.X, point.Y);
        Class39.ShowCaret(this.Handle);
      }
      this.rectangle_0 = rectangle;
    }
    else
    {
      Class39.HideCaret(this.Handle);
      this.rectangle_0 = Rectangle.Empty;
    }
    if (!this.Enabled)
    {
      using (SolidBrush solidBrush = new SolidBrush(this.DisabledColor))
        e.Graphics.FillRectangle((Brush) solidBrush, this.ClientRectangle);
    }
    if (this.MacrosManager.IsRecording)
      Class39.smethod_78(this, e.Graphics);
    if (this.bool_33)
      Class39.smethod_849(this, e.Graphics);
    pen1.Dispose();
    brush1.Dispose();
    brush2.Dispose();
    brush4.Dispose();
    brush3.Dispose();
    base.OnPaint(e);
  }

  private void method_13(PaintEventArgs paintEventArgs_0, Pen pen_0)
  {
    foreach (VisualMarker visualMarker in this.list_0)
    {
      if (this.ServiceColors == null)
        this.ServiceColors = new ServiceColors();
      switch (visualMarker)
      {
        case CollapseFoldingMarker _:
          using (SolidBrush backgroundBrush = new SolidBrush(this.ServiceColors.CollapseMarkerBackColor))
          {
            using (Pen forePen = new Pen(this.ServiceColors.CollapseMarkerForeColor))
            {
              using (Pen pen = new Pen(this.ServiceColors.CollapseMarkerBorderColor))
              {
                (visualMarker as CollapseFoldingMarker).Draw(paintEventArgs_0.Graphics, pen, (Brush) backgroundBrush, forePen);
                continue;
              }
            }
          }
        case ExpandFoldingMarker _:
          using (SolidBrush backgroundBrush = new SolidBrush(this.ServiceColors.ExpandMarkerBackColor))
          {
            using (Pen forePen = new Pen(this.ServiceColors.ExpandMarkerForeColor))
            {
              using (Pen pen = new Pen(this.ServiceColors.ExpandMarkerBorderColor))
              {
                (visualMarker as ExpandFoldingMarker).Draw(paintEventArgs_0.Graphics, pen, (Brush) backgroundBrush, forePen);
                continue;
              }
            }
          }
        default:
          visualMarker.Draw(paintEventArgs_0.Graphics, pen_0);
          continue;
      }
    }
  }

  protected virtual void DrawFoldingLines(PaintEventArgs e, int startLine, int endLine)
  {
    e.Graphics.SmoothingMode = SmoothingMode.None;
    using (Pen pen1 = new Pen(Color.FromArgb(200, this.ServiceLinesColor))
    {
      DashStyle = DashStyle.Dot
    })
    {
      foreach (KeyValuePair<int, int> foldingPair in this.foldingPairs)
      {
        if ((foldingPair.Key >= endLine ? 0 : (foldingPair.Value > startLine ? 1 : 0)) != 0)
        {
          Line line = this.textSource_0[foldingPair.Key];
          int num1 = this.LineInfos[foldingPair.Key].startY - this.VerticalScroll.Value + this.CharHeight;
          int num2 = num1 + num1 % 2;
          int num3;
          if (foldingPair.Value >= this.LinesCount)
            num3 = this.LineInfos[this.LinesCount - 1].startY + this.CharHeight - this.VerticalScroll.Value;
          else if (this.LineInfos[foldingPair.Value].VisibleState == VisibleState.Visible)
          {
            int num4 = 0;
            int startSpacesCount = line.StartSpacesCount;
            if ((this.textSource_0[foldingPair.Value].Count <= startSpacesCount ? 1 : (this.textSource_0[foldingPair.Value][startSpacesCount].c == ' ' ? 1 : 0)) != 0)
              num4 = this.CharHeight;
            num3 = this.LineInfos[foldingPair.Value].startY - this.VerticalScroll.Value + num4;
          }
          else
            continue;
          int leftIndent1 = this.LeftIndent;
          Padding paddings = this.Paddings;
          int left1 = paddings.Left;
          int num5 = leftIndent1 + left1 + line.StartSpacesCount * this.CharWidth - this.HorizontalScroll.Value;
          int num6 = num5;
          int leftIndent2 = this.LeftIndent;
          paddings = this.Paddings;
          int left2 = paddings.Left;
          int num7 = leftIndent2 + left2;
          if (num6 >= num7)
          {
            Graphics graphics = e.Graphics;
            Pen pen2 = pen1;
            int x1 = num5;
            int y1 = num2 >= 0 ? num2 : 0;
            int x2 = num5;
            int num8 = num3;
            Size clientSize = this.ClientSize;
            int height = clientSize.Height;
            int y2;
            if (num8 >= height)
            {
              clientSize = this.ClientSize;
              y2 = clientSize.Height;
            }
            else
              y2 = num3;
            graphics.DrawLine(pen2, x1, y1, x2, y2);
          }
        }
      }
    }
  }

  protected override void OnEnter(EventArgs e)
  {
    base.OnEnter(e);
    this.bool_6 = false;
    this.bool_7 = false;
    this.draggedRange = (Range) null;
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    base.OnMouseUp(e);
    this.bool_4 = false;
    if (e.Button != MouseButtons.Left || !this.bool_7)
      return;
    this.method_14(e);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    base.OnMouseDown(e);
    if (this.bool_33)
    {
      this.method_23();
      this.bool_6 = false;
      if (e.Button != MouseButtons.Middle)
        return;
      this.method_24();
    }
    else
    {
      this.MacrosManager.IsRecording = false;
      this.Select();
      this.ActiveControl = (Control) null;
      if (e.Button == MouseButtons.Left)
      {
        VisualMarker marker = this.method_18(e.Location);
        if (marker != null)
        {
          this.bool_6 = false;
          this.bool_7 = false;
          this.draggedRange = (Range) null;
          this.OnMarkerClick(e, marker);
        }
        else
        {
          this.bool_6 = true;
          this.bool_7 = false;
          this.draggedRange = (Range) null;
          this.bool_4 = e.Location.X < Class39.smethod_612(this);
          if (!this.bool_4)
          {
            Place place = this.PointToPlace(e.Location);
            if (e.Clicks == 2)
            {
              this.bool_6 = false;
              this.bool_7 = false;
              this.draggedRange = (Range) null;
              Class39.smethod_141(this, place);
            }
            else if ((this.Selection.IsEmpty || !this.Selection.Contains(place) || this[place.iLine].Count <= place.iChar ? 1 : (this.ReadOnly ? 1 : 0)) != 0)
            {
              this.method_14(e);
            }
            else
            {
              this.bool_7 = true;
              this.bool_6 = false;
            }
          }
          else
          {
            this.CheckAndChangeSelectionType();
            this.Selection.BeginUpdate();
            int iLine = Class39.smethod_105(this, e.Location).iLine;
            this.int_4 = iLine;
            this.Selection.Start = new Place(0, iLine);
            this.Selection.End = new Place(this.GetLineLength(iLine), iLine);
            this.Selection.EndUpdate();
            this.Invalidate();
          }
        }
      }
      else
      {
        if (e.Button != MouseButtons.Middle)
          return;
        this.method_22(e);
      }
    }
  }

  private void method_14(MouseEventArgs mouseEventArgs_0)
  {
    Place end = this.Selection.End;
    this.Selection.BeginUpdate();
    if (this.Selection.ColumnSelectionMode)
    {
      this.Selection.Start = Class39.smethod_105(this, mouseEventArgs_0.Location);
      this.Selection.ColumnSelectionMode = true;
    }
    else
      this.Selection.Start = !this.VirtualSpace ? this.PointToPlace(mouseEventArgs_0.Location) : Class39.smethod_105(this, mouseEventArgs_0.Location);
    if ((this.keys_0 & Keys.Shift) != 0)
      this.Selection.End = end;
    this.CheckAndChangeSelectionType();
    this.Selection.EndUpdate();
    this.Invalidate();
  }

  protected virtual void CheckAndChangeSelectionType()
  {
    if (((Control.ModifierKeys & Keys.Alt) == Keys.None ? 0 : (!this.WordWrap ? 1 : 0)) != 0)
      this.Selection.ColumnSelectionMode = true;
    else
      this.Selection.ColumnSelectionMode = false;
  }

  protected override void OnMouseWheel(MouseEventArgs e)
  {
    this.Invalidate();
    if (this.keys_0 == Keys.Control)
    {
      this.ChangeFontSize(2 * Math.Sign(e.Delta));
      ((HandledMouseEventArgs) e).Handled = true;
    }
    else if ((this.VerticalScroll.Visible ? 1 : (!this.ShowScrollBars ? 1 : 0)) != 0)
    {
      this.method_15(Class39.smethod_734(), e.Delta);
      ((HandledMouseEventArgs) e).Handled = true;
    }
    this.method_23();
  }

  private void method_15(int int_16, int int_17)
  {
    if ((this.VerticalScroll.Visible ? 1 : (!this.ShowScrollBars ? 1 : 0)) == 0)
      return;
    int num1 = this.ClientSize.Height / this.CharHeight;
    int num2 = (int_16 == -1 ? 1 : (int_16 > num1 ? 1 : 0)) == 0 ? this.CharHeight * int_16 : this.CharHeight * num1;
    int newValue = this.VerticalScroll.Value - Math.Sign(int_17) * num2;
    this.OnScroll(new ScrollEventArgs(int_17 > 0 ? ScrollEventType.SmallDecrement : ScrollEventType.SmallIncrement, this.VerticalScroll.Value, newValue, ScrollOrientation.VerticalScroll));
  }

  public void ChangeFontSize(int step)
  {
    float sizeInPoints = this.Font.SizeInPoints;
    using (Graphics graphics = Graphics.FromHwnd(this.Handle))
    {
      float dpiY = graphics.DpiY;
      float num = sizeInPoints + (float) step * 72f / dpiY;
      if ((double) num < 1.0)
        return;
      this.Zoom = (int) (100.0 * (double) (num / this.font_1.SizeInPoints));
    }
  }

  [Browsable(false)]
  public int Zoom
  {
    get => this.int_10;
    set
    {
      this.int_10 = value;
      Class39.smethod_72(this, (float) this.int_10 / 100f);
      this.OnZoomChanged();
    }
  }

  protected virtual void OnZoomChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_18 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_18((object) this, EventArgs.Empty);
  }

  protected override void OnMouseLeave(EventArgs e)
  {
    base.OnMouseLeave(e);
    Class39.smethod_324(this);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    base.OnMouseMove(e);
    if (this.bool_33)
      return;
    if (this.point_0 != e.Location)
    {
      Class39.smethod_324(this);
      this.timer_2.Start();
    }
    this.point_0 = e.Location;
    if ((e.Button != MouseButtons.Left ? 0 : (this.bool_7 ? 1 : 0)) != 0)
    {
      this.draggedRange = this.Selection.Clone();
      int num = (int) this.DoDragDrop((object) this.SelectedText, DragDropEffects.Copy);
      this.draggedRange = (Range) null;
    }
    else
    {
      if ((e.Button != MouseButtons.Left ? 0 : (this.bool_6 ? 1 : 0)) != 0)
      {
        Place place = (this.Selection.ColumnSelectionMode ? 1 : (this.VirtualSpace ? 1 : 0)) == 0 ? this.PointToPlace(e.Location) : Class39.smethod_105(this, e.Location);
        if (this.bool_4)
        {
          this.Selection.BeginUpdate();
          int iLine = place.iLine;
          if (iLine < this.int_4)
          {
            this.Selection.Start = new Place(0, iLine);
            this.Selection.End = new Place(this.GetLineLength(this.int_4), this.int_4);
          }
          else
          {
            this.Selection.Start = new Place(this.GetLineLength(iLine), iLine);
            this.Selection.End = new Place(0, this.int_4);
          }
          this.Selection.EndUpdate();
          this.DoCaretVisible();
          this.HorizontalScroll.Value = 0;
          this.UpdateScrollbars();
          this.Invalidate();
        }
        else if (place != this.Selection.Start)
        {
          Place end = this.Selection.End;
          this.Selection.BeginUpdate();
          if (this.Selection.ColumnSelectionMode)
          {
            this.Selection.Start = place;
            this.Selection.ColumnSelectionMode = true;
          }
          else
            this.Selection.Start = place;
          this.Selection.End = end;
          this.Selection.EndUpdate();
          this.DoCaretVisible();
          this.Invalidate();
          return;
        }
      }
      VisualMarker visualMarker = this.method_18(e.Location);
      if (visualMarker != null)
        base.Cursor = visualMarker.Cursor;
      else if ((e.Location.X < Class39.smethod_612(this) ? 1 : (this.bool_4 ? 1 : 0)) != 0)
        base.Cursor = Cursors.Arrow;
      else
        base.Cursor = this.cursor_0;
    }
  }

  protected override void OnMouseDoubleClick(MouseEventArgs e)
  {
    base.OnMouseDoubleClick(e);
    VisualMarker marker = this.method_18(e.Location);
    if (marker == null)
      return;
    this.OnMarkerDoubleClick(marker);
  }

  public Place PointToPlace(Point point)
  {
    point.Offset(this.HorizontalScroll.Value, this.VerticalScroll.Value);
    point.Offset(-this.LeftIndent - this.Paddings.Left, 0);
    int num1 = Class39.smethod_53(this, point.Y);
    Place place;
    if (num1 < 0)
    {
      place = Place.Empty;
    }
    else
    {
      int num2 = 0;
      for (; num1 < this.textSource_0.Count; ++num1)
      {
        num2 = this.LineInfos[num1].startY + this.LineInfos[num1].WordWrapStringsCount * this.CharHeight;
        if ((num2 <= point.Y ? 0 : (this.LineInfos[num1].VisibleState == VisibleState.Visible ? 1 : 0)) != 0)
          break;
      }
      if (num1 >= this.textSource_0.Count)
        num1 = this.textSource_0.Count - 1;
      if (this.LineInfos[num1].VisibleState != 0)
        num1 = Class39.smethod_735(this, num1);
      int int_2 = this.LineInfos[num1].WordWrapStringsCount;
      do
      {
        --int_2;
        num2 -= this.CharHeight;
      }
      while (num2 > point.Y);
      if (int_2 < 0)
        int_2 = 0;
      int num3 = this.LineInfos[num1].method_0(int_2);
      int num4 = this.LineInfos[num1].method_1(int_2, this.textSource_0[num1]);
      int num5 = (int) Math.Round((double) point.X / (double) this.CharWidth);
      if (int_2 > 0)
        num5 -= this.LineInfos[num1].int_1;
      int iChar = num5 < 0 ? num3 : num3 + num5;
      if (iChar > num4)
        iChar = num4 + 1;
      if (iChar > this.textSource_0[num1].Count)
        iChar = this.textSource_0[num1].Count;
      place = new Place(iChar, num1);
    }
    return place;
  }

  public int PointToPosition(Point point) => this.PlaceToPosition(this.PointToPlace(point));

  public virtual void OnTextChanging(ref string text)
  {
    Class39.smethod_808(this);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_5 == null)
      return;
    TextChangingEventArgs e = new TextChangingEventArgs()
    {
      InsertingText = text
    };
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_5((object) this, e);
    text = e.InsertingText;
    if (!e.Cancel)
      return;
    text = string.Empty;
  }

  public virtual void OnTextChanging()
  {
    string text = (string) null;
    this.OnTextChanging(ref text);
  }

  public virtual void OnTextChanged()
  {
    Range changedRange = new Range(this);
    changedRange.SelectAll();
    this.OnTextChanged(new TextChangedEventArgs(changedRange));
  }

  public virtual void OnTextChanged(int fromLine, int toLine)
  {
    this.OnTextChanged(new TextChangedEventArgs(new Range(this)
    {
      Start = new Place(0, Math.Min(fromLine, toLine)),
      End = new Place(this.textSource_0[Math.Max(fromLine, toLine)].Count, Math.Max(fromLine, toLine))
    }));
  }

  public virtual void OnTextChanged(Range r) => this.OnTextChanged(new TextChangedEventArgs(r));

  public void BeginUpdate()
  {
    if (this.int_8 == 0)
      this.range_6 = (Range) null;
    ++this.int_8;
  }

  public void EndUpdate()
  {
    --this.int_8;
    if ((this.int_8 != 0 ? 0 : (this.range_6 != null ? 1 : 0)) == 0)
      return;
    this.range_6.Expand();
    this.OnTextChanged(this.range_6);
  }

  protected virtual void OnTextChanged(TextChangedEventArgs args)
  {
    args.ChangedRange.Normalize();
    if (this.int_8 > 0)
    {
      if (this.range_6 == null)
      {
        this.range_6 = args.ChangedRange.Clone();
      }
      else
      {
        if (this.range_6.Start.iLine > args.ChangedRange.Start.iLine)
          this.range_6.Start = new Place(0, args.ChangedRange.Start.iLine);
        if (this.range_6.End.iLine < args.ChangedRange.End.iLine)
          this.range_6.End = new Place(this.textSource_0[args.ChangedRange.End.iLine].Count, args.ChangedRange.End.iLine);
        this.range_6 = this.range_6.GetIntersectionWith(this.Range);
      }
    }
    else
    {
      Class39.smethod_324(this);
      this.ClearHints();
      this.IsChanged = true;
      ++this.TextVersion;
      Class39.smethod_644(args.ChangedRange, this);
      Class39.smethod_323(this, args.ChangedRange);
      if (this.bool_16)
        Class39.smethod_638(args.ChangedRange.Start.iLine, this, args.ChangedRange.End.iLine);
      this.OnTextChanged((EventArgs) args);
      this.range_1 = this.range_1 != null ? this.range_1.GetUnionWith(args.ChangedRange) : args.ChangedRange.Clone();
      this.bool_11 = true;
      this.method_8(this.timer_1);
      this.OnSyntaxHighlight(args);
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_2((object) this, args);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_3 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_3((object) this, EventArgs.Empty);
      }
      this.OnTextChanged(EventArgs.Empty);
      this.OnVisibleRangeChanged();
    }
  }

  public virtual void OnSelectionChanged()
  {
    if (this.HighlightFoldingIndicator)
      this.method_16();
    this.bool_10 = true;
    this.method_8(this.timer_0);
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_6 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_6((object) this, new EventArgs());
  }

  private void method_16()
  {
    if (this.LinesCount == 0)
      return;
    int int7 = this.int_7;
    int int1 = this.int_1;
    this.int_7 = -1;
    this.int_1 = -1;
    int num = 0;
    for (int iLine = this.Selection.Start.iLine; iLine >= Math.Max(this.Selection.Start.iLine - 3000, 0); --iLine)
    {
      bool flag1 = this.textSource_0.LineHasFoldingStartMarker(iLine);
      bool flag2;
      if (!((flag2 = this.textSource_0.LineHasFoldingEndMarker(iLine)) & flag1))
      {
        if (flag1)
        {
          --num;
          if (num == -1)
          {
            this.int_7 = iLine;
            break;
          }
        }
        if ((!flag2 ? 0 : (iLine != this.Selection.Start.iLine ? 1 : 0)) != 0)
          ++num;
      }
    }
    if (this.int_7 >= 0)
    {
      this.int_1 = this.FindEndOfFoldingBlock(this.int_7, 3000);
      if (this.int_1 == this.int_7)
        this.int_1 = -1;
    }
    if ((this.int_7 != int7 ? 1 : (this.int_1 != int1 ? 1 : 0)) == 0)
      return;
    this.OnFoldingHighlightChanged();
  }

  protected virtual void OnFoldingHighlightChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_16 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_16((object) this, EventArgs.Empty);
  }

  protected override void OnGotFocus(EventArgs e)
  {
    Class39.smethod_298(this);
    base.OnGotFocus(e);
    this.Invalidate();
  }

  protected override void OnLostFocus(EventArgs e)
  {
    this.keys_0 = Keys.None;
    this.method_23();
    base.OnLostFocus(e);
    this.Invalidate();
  }

  public int PlaceToPosition(Place point)
  {
    int position;
    if ((point.iLine < 0 || point.iLine >= this.textSource_0.Count ? 1 : (point.iChar >= this.textSource_0[point.iLine].Count + Environment.NewLine.Length ? 1 : 0)) != 0)
    {
      position = -1;
    }
    else
    {
      int num = 0;
      for (int i = 0; i < point.iLine; ++i)
        num += this.textSource_0[i].Count + Environment.NewLine.Length;
      position = num + point.iChar;
    }
    return position;
  }

  public Place PositionToPlace(int pos)
  {
    Place place;
    if (pos < 0)
    {
      place = new Place(0, 0);
    }
    else
    {
      for (int index = 0; index < this.textSource_0.Count; ++index)
      {
        int num = this.textSource_0[index].Count + Environment.NewLine.Length;
        if (pos >= this.textSource_0[index].Count)
        {
          if (pos >= num)
          {
            pos -= num;
          }
          else
          {
            place = new Place(this.textSource_0[index].Count, index);
            goto label_10;
          }
        }
        else
        {
          place = new Place(pos, index);
          goto label_10;
        }
      }
      place = this.textSource_0.Count <= 0 ? new Place(0, 0) : new Place(this.textSource_0[this.textSource_0.Count - 1].Count, this.textSource_0.Count - 1);
    }
label_10:
    return place;
  }

  public Point PositionToPoint(int pos) => this.PlaceToPoint(this.PositionToPlace(pos));

  public Point PlaceToPoint(Place place)
  {
    Point point;
    if (place.iLine >= this.LineInfos.Count)
    {
      point = new Point();
    }
    else
    {
      int startY = this.LineInfos[place.iLine].startY;
      LineInfo lineInfo = this.LineInfos[place.iLine];
      int wordWrapStringIndex = lineInfo.GetWordWrapStringIndex(place.iChar);
      int num1 = startY + wordWrapStringIndex * this.CharHeight;
      int iChar = place.iChar;
      lineInfo = this.LineInfos[place.iLine];
      int num2 = lineInfo.method_0(wordWrapStringIndex);
      int num3 = (iChar - num2) * this.CharWidth;
      if (wordWrapStringIndex > 0)
        num3 += this.LineInfos[place.iLine].int_1 * this.CharWidth;
      int y = num1 - this.VerticalScroll.Value;
      point = new Point(this.LeftIndent + this.Paddings.Left + num3 - this.HorizontalScroll.Value, y);
    }
    return point;
  }

  public Range GetRange(int fromPos, int toPos)
  {
    return new Range(this)
    {
      Start = this.PositionToPlace(fromPos),
      End = this.PositionToPlace(toPos)
    };
  }

  public Range GetRange(Place fromPlace, Place toPlace) => new Range(this, fromPlace, toPlace);

  public IEnumerable<Range> GetRanges(string regexPattern)
  {
    Range range1 = new Range(this);
    range1.SelectAll();
    IEnumerator<Range> enumerator = range1.GetRanges(regexPattern, RegexOptions.None).GetEnumerator();
    while (enumerator.MoveNext())
    {
      Range range2 = enumerator.Current;
      yield return range2;
      range2 = (Range) null;
    }
    Class39.smethod_336(this);
    enumerator = (IEnumerator<Range>) null;
  }

  public IEnumerable<Range> GetRanges(string regexPattern, RegexOptions options)
  {
    Range range1 = new Range(this);
    range1.SelectAll();
    IEnumerator<Range> enumerator = range1.GetRanges(regexPattern, options).GetEnumerator();
    while (enumerator.MoveNext())
    {
      Range range2 = enumerator.Current;
      yield return range2;
      range2 = (Range) null;
    }
    Class39.smethod_604(this);
    enumerator = (IEnumerator<Range>) null;
  }

  public string GetLineText(int iLine)
  {
    if ((iLine < 0 ? 1 : (iLine >= this.textSource_0.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException("Line index out of range");
    StringBuilder stringBuilder = new StringBuilder(this.textSource_0[iLine].Count);
    foreach (Char @char in this.textSource_0[iLine])
      stringBuilder.Append(@char.c);
    return stringBuilder.ToString();
  }

  public virtual void ExpandFoldedBlock(int iLine)
  {
    if ((iLine < 0 ? 1 : (iLine >= this.textSource_0.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException("Line index out of range");
    int toLine = iLine;
    while (toLine < this.LinesCount - 1 && this.LineInfos[toLine + 1].VisibleState == VisibleState.Hidden)
      ++toLine;
    this.ExpandBlock(iLine, toLine);
    this.FoldedBlocks.Remove(this[iLine].UniqueId);
    this.AdjustFolding();
  }

  public virtual void AdjustFolding()
  {
    for (int index = 0; index < this.LinesCount; ++index)
    {
      if (this.LineInfos[index].VisibleState == VisibleState.Visible && this.FoldedBlocks.ContainsKey(this[index].UniqueId))
        this.CollapseFoldingBlock(index);
    }
  }

  public virtual void ExpandBlock(int fromLine, int toLine)
  {
    int num1 = Math.Min(fromLine, toLine);
    int num2 = Math.Max(fromLine, toLine);
    for (int iLine = num1; iLine <= num2; ++iLine)
      this.SetVisibleState(iLine, VisibleState.Visible);
    this.needRecalc = true;
    this.Invalidate();
    this.OnVisibleRangeChanged();
  }

  public void ExpandBlock(int iLine)
  {
    if (this.LineInfos[iLine].VisibleState == VisibleState.Visible)
      return;
    for (int index = iLine; index < this.LinesCount && this.LineInfos[index].VisibleState != VisibleState.Visible; ++index)
    {
      this.SetVisibleState(index, VisibleState.Visible);
      this.needRecalc = true;
    }
    for (int index = iLine - 1; index >= 0 && this.LineInfos[index].VisibleState != VisibleState.Visible; --index)
    {
      this.SetVisibleState(index, VisibleState.Visible);
      this.needRecalc = true;
    }
    this.Invalidate();
    this.OnVisibleRangeChanged();
  }

  public virtual void CollapseAllFoldingBlocks()
  {
    for (int index = 0; index < this.LinesCount; ++index)
    {
      if (this.textSource_0.LineHasFoldingStartMarker(index))
      {
        int toLine = this.method_17(index);
        if (toLine >= 0)
        {
          this.CollapseBlock(index, toLine);
          index = toLine;
        }
      }
    }
    this.OnVisibleRangeChanged();
    this.UpdateScrollbars();
  }

  public virtual void ExpandAllFoldingBlocks()
  {
    for (int iLine = 0; iLine < this.LinesCount; ++iLine)
      this.SetVisibleState(iLine, VisibleState.Visible);
    this.FoldedBlocks.Clear();
    this.OnVisibleRangeChanged();
    this.Invalidate();
    this.UpdateScrollbars();
  }

  public virtual void CollapseFoldingBlock(int iLine)
  {
    if ((iLine < 0 ? 1 : (iLine >= this.textSource_0.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException("Line index out of range");
    if (string.IsNullOrEmpty(this.textSource_0[iLine].FoldingStartMarker))
      throw new ArgumentOutOfRangeException("This line is not folding start line");
    int toLine = this.method_17(iLine);
    if (toLine < 0)
      return;
    this.CollapseBlock(iLine, toLine);
    int uniqueId = this[iLine].UniqueId;
    this.FoldedBlocks[uniqueId] = uniqueId;
  }

  private int method_17(int int_16) => this.FindEndOfFoldingBlock(int_16, int.MaxValue);

  protected virtual int FindEndOfFoldingBlock(int iStartLine, int maxLines)
  {
    string foldingStartMarker = this.textSource_0[iStartLine].FoldingStartMarker;
    Stack<string> stringStack = new Stack<string>();
    int endOfFoldingBlock;
    switch (this.FindEndOfFoldingBlockStrategy)
    {
      case FindEndOfFoldingBlockStrategy.Strategy1:
        for (int index = iStartLine; index < this.LinesCount; ++index)
        {
          if (this.textSource_0.LineHasFoldingStartMarker(index))
            stringStack.Push(this.textSource_0[index].FoldingStartMarker);
          if (this.textSource_0.LineHasFoldingEndMarker(index))
          {
            string foldingEndMarker = this.textSource_0[index].FoldingEndMarker;
            do
              ;
            while ((stringStack.Count <= 0 ? 0 : (stringStack.Pop() != foldingEndMarker ? 1 : 0)) != 0);
            if (stringStack.Count == 0)
            {
              endOfFoldingBlock = index;
              goto label_26;
            }
          }
          --maxLines;
          if (maxLines < 0)
          {
            endOfFoldingBlock = index;
            goto label_26;
          }
        }
        goto default;
      case FindEndOfFoldingBlockStrategy.Strategy2:
        for (int index = iStartLine; index < this.LinesCount; ++index)
        {
          if (this.textSource_0.LineHasFoldingEndMarker(index))
          {
            string foldingEndMarker = this.textSource_0[index].FoldingEndMarker;
            do
              ;
            while ((stringStack.Count <= 0 ? 0 : (stringStack.Pop() != foldingEndMarker ? 1 : 0)) != 0);
            if (stringStack.Count == 0)
            {
              endOfFoldingBlock = index;
              goto label_26;
            }
          }
          if (this.textSource_0.LineHasFoldingStartMarker(index))
            stringStack.Push(this.textSource_0[index].FoldingStartMarker);
          --maxLines;
          if (maxLines < 0)
          {
            endOfFoldingBlock = index;
            goto label_26;
          }
        }
        goto default;
      default:
        endOfFoldingBlock = this.LinesCount - 1;
        break;
    }
label_26:
    return endOfFoldingBlock;
  }

  public string GetLineFoldingStartMarker(int iLine)
  {
    return !this.textSource_0.LineHasFoldingStartMarker(iLine) ? (string) null : this.textSource_0[iLine].FoldingStartMarker;
  }

  public string GetLineFoldingEndMarker(int iLine)
  {
    return !this.textSource_0.LineHasFoldingEndMarker(iLine) ? (string) null : this.textSource_0[iLine].FoldingEndMarker;
  }

  protected virtual void RecalcFoldingLines()
  {
    if (!this.bool_9)
      return;
    this.bool_9 = false;
    if (!this.ShowFoldingLines)
      return;
    this.foldingPairs.Clear();
    Range visibleRange = this.VisibleRange;
    int num1 = Math.Max(visibleRange.Start.iLine - 3000, 0);
    int num2 = Math.Min(visibleRange.End.iLine + 3000, Math.Max(visibleRange.End.iLine, this.LinesCount - 1));
    Stack<int> intStack = new Stack<int>();
    for (int index = num1; index <= num2; ++index)
    {
      bool flag1 = this.textSource_0.LineHasFoldingStartMarker(index);
      bool flag2;
      if (!((flag2 = this.textSource_0.LineHasFoldingEndMarker(index)) & flag1))
      {
        if (flag1)
          intStack.Push(index);
        if (flag2)
        {
          string foldingEndMarker = this.textSource_0[index].FoldingEndMarker;
          while (intStack.Count > 0)
          {
            int num3 = intStack.Pop();
            this.foldingPairs[num3] = index;
            if (foldingEndMarker == this.textSource_0[num3].FoldingStartMarker)
              break;
          }
        }
      }
    }
    while (intStack.Count > 0)
      this.foldingPairs[intStack.Pop()] = num2 + 1;
  }

  public virtual void CollapseBlock(int fromLine, int toLine)
  {
    int iLine1 = Math.Min(fromLine, toLine);
    int num = Math.Max(fromLine, toLine);
    if (iLine1 == num)
      return;
    for (; iLine1 <= num; ++iLine1)
    {
      if (this.GetLineText(iLine1).Trim().Length > 0)
      {
        for (int iLine2 = iLine1 + 1; iLine2 <= num; ++iLine2)
          this.SetVisibleState(iLine2, VisibleState.Hidden);
        this.SetVisibleState(iLine1, VisibleState.StartOfHiddenBlock);
        this.Invalidate();
        break;
      }
    }
    int int_0_1 = Math.Min(fromLine, toLine);
    int int_0_2 = Math.Max(fromLine, toLine);
    int iLine3 = Class39.smethod_97(this, int_0_2);
    if (iLine3 == int_0_2)
      iLine3 = Class39.smethod_735(this, int_0_1);
    this.Selection.Start = new Place(0, iLine3);
    this.needRecalc = true;
    this.Invalidate();
    this.OnVisibleRangeChanged();
  }

  private VisualMarker method_18(Point point_4)
  {
    VisualMarker visualMarker1;
    foreach (VisualMarker visualMarker2 in this.list_0)
    {
      if (visualMarker2.rectangle.Contains(point_4))
      {
        visualMarker1 = visualMarker2;
        goto label_7;
      }
    }
    visualMarker1 = (VisualMarker) null;
label_7:
    return visualMarker1;
  }

  public virtual void IncreaseIndent()
  {
    if (this.Selection.Start == this.Selection.End)
    {
      if (this.Selection.ReadOnly)
        return;
      this.Selection.Start = new Place(this[this.Selection.Start.iLine].StartSpacesCount, this.Selection.Start.iLine);
      int count = this.TabLength - this.Selection.Start.iChar % this.TabLength;
      if (this.IsReplaceMode)
      {
        for (int index = 0; index < count; ++index)
          this.Selection.GoRight(true);
        this.Selection.Inverse();
      }
      this.InsertText(new string(' ', count));
    }
    else
    {
      bool flag = this.Selection.Start > this.Selection.End && !this.Selection.ColumnSelectionMode;
      int iChar1 = 0;
      if (this.Selection.ColumnSelectionMode)
        iChar1 = Math.Min(this.Selection.End.iChar, this.Selection.Start.iChar);
      this.BeginUpdate();
      this.Selection.BeginUpdate();
      this.textSource_0.Manager.BeginAutoUndoCommands();
      Range range1 = this.Selection.Clone();
      this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
      this.Selection.Normalize();
      Range range2 = this.Selection.Clone();
      int iLine1 = this.Selection.Start.iLine;
      int iLine2 = this.Selection.End.iLine;
      if (!this.Selection.ColumnSelectionMode && this.Selection.End.iChar == 0)
        --iLine2;
      for (int index = iLine1; index <= iLine2; ++index)
      {
        if (this.textSource_0[index].Count != 0)
        {
          this.Selection.Start = new Place(iChar1, index);
          this.textSource_0.Manager.ExecuteCommand((Command) new InsertTextCommand(this.TextSource, new string(' ', this.TabLength)));
        }
      }
      if (!this.Selection.ColumnSelectionMode)
      {
        int iChar2 = range2.Start.iChar + this.TabLength;
        int iChar3 = range2.End.iChar + (range2.End.iLine == iLine2 ? this.TabLength : 0);
        this.Selection.Start = new Place(iChar2, range2.Start.iLine);
        this.Selection.End = new Place(iChar3, range2.End.iLine);
      }
      else
        this.Selection = range1;
      this.textSource_0.Manager.EndAutoUndoCommands();
      if (flag)
        this.Selection.Inverse();
      this.needRecalc = true;
      this.Selection.EndUpdate();
      this.EndUpdate();
      this.Invalidate();
    }
  }

  public virtual void DecreaseIndent()
  {
    if (this.Selection.Start.iLine == this.Selection.End.iLine)
    {
      this.DecreaseIndentOfSingleLine();
    }
    else
    {
      int num1 = 0;
      if (this.Selection.ColumnSelectionMode)
        num1 = Math.Min(this.Selection.End.iChar, this.Selection.Start.iChar);
      this.BeginUpdate();
      this.Selection.BeginUpdate();
      this.textSource_0.Manager.BeginAutoUndoCommands();
      Range range1 = this.Selection.Clone();
      this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
      Range range2 = this.Selection.Clone();
      this.Selection.Normalize();
      int iLine1 = this.Selection.Start.iLine;
      int iLine2 = this.Selection.End.iLine;
      if (!this.Selection.ColumnSelectionMode && this.Selection.End.iChar == 0)
        --iLine2;
      int num2 = 0;
      int num3 = 0;
      for (int index = iLine1; index <= iLine2; ++index)
      {
        if (num1 <= this.textSource_0[index].Count)
        {
          int val1 = Math.Min(this.textSource_0[index].Count, num1 + this.TabLength);
          string str = this.textSource_0[index].Text.Substring(num1, val1 - num1);
          int iChar = Math.Min(val1, num1 + str.Length - str.TrimStart().Length);
          this.Selection = new Range(this, new Place(num1, index), new Place(iChar, index));
          int num4 = iChar - num1;
          if (index == range2.Start.iLine)
            num2 = num4;
          if (index == range2.End.iLine)
            num3 = num4;
          if (!this.Selection.IsEmpty)
            this.ClearSelected();
        }
      }
      if (!this.Selection.ColumnSelectionMode)
      {
        int iChar1 = Math.Max(0, range2.Start.iChar - num2);
        int iChar2 = Math.Max(0, range2.End.iChar - num3);
        this.Selection.Start = new Place(iChar1, range2.Start.iLine);
        this.Selection.End = new Place(iChar2, range2.End.iLine);
      }
      else
        this.Selection = range1;
      this.textSource_0.Manager.EndAutoUndoCommands();
      this.needRecalc = true;
      this.Selection.EndUpdate();
      this.EndUpdate();
      this.Invalidate();
    }
  }

  protected virtual void DecreaseIndentOfSingleLine()
  {
    if (this.Selection.Start.iLine != this.Selection.End.iLine)
      return;
    Range range = this.Selection.Clone();
    int iLine = this.Selection.Start.iLine;
    int startat = Math.Min(this.Selection.Start.iChar, this.Selection.End.iChar);
    Match match = new Regex("\\s*", RegexOptions.RightToLeft).Match(this.textSource_0[iLine].Text, startat);
    int index = match.Index;
    int length = match.Length;
    int num = 0;
    if (length > 0)
    {
      int val1 = this.TabLength > 0 ? startat % this.TabLength : 0;
      num = val1 != 0 ? Math.Min(val1, length) : Math.Min(this.TabLength, length);
    }
    if (num > 0)
    {
      this.BeginUpdate();
      this.Selection.BeginUpdate();
      this.textSource_0.Manager.BeginAutoUndoCommands();
      this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
      this.Selection.Start = new Place(index, iLine);
      this.Selection.End = new Place(index + num, iLine);
      this.ClearSelected();
      int iChar1 = range.Start.iChar - num;
      int iChar2 = range.End.iChar - num;
      this.Selection.Start = new Place(iChar1, iLine);
      this.Selection.End = new Place(iChar2, iLine);
      this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
      this.textSource_0.Manager.EndAutoUndoCommands();
      this.Selection.EndUpdate();
      this.EndUpdate();
    }
    this.Invalidate();
  }

  public virtual void DoAutoIndent()
  {
    if (this.Selection.ColumnSelectionMode)
      return;
    Range range = this.Selection.Clone();
    range.Normalize();
    this.BeginUpdate();
    this.Selection.BeginUpdate();
    this.textSource_0.Manager.BeginAutoUndoCommands();
    for (int iLine = range.Start.iLine; iLine <= range.End.iLine; ++iLine)
      this.DoAutoIndent(iLine);
    this.textSource_0.Manager.EndAutoUndoCommands();
    this.Selection.Start = range.Start;
    this.Selection.End = range.End;
    this.Selection.Expand();
    this.Selection.EndUpdate();
    this.EndUpdate();
  }

  public virtual void InsertLinePrefix(string prefix)
  {
    this.Selection.Clone();
    int num1 = Math.Min(this.Selection.Start.iLine, this.Selection.End.iLine);
    int num2 = Math.Max(this.Selection.Start.iLine, this.Selection.End.iLine);
    this.BeginUpdate();
    this.Selection.BeginUpdate();
    this.textSource_0.Manager.BeginAutoUndoCommands();
    this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
    int startSpacesCount = this.GetMinStartSpacesCount(num1, num2);
    for (int iLine = num1; iLine <= num2; ++iLine)
    {
      this.Selection.Start = new Place(startSpacesCount, iLine);
      this.textSource_0.Manager.ExecuteCommand((Command) new InsertTextCommand(this.TextSource, prefix));
    }
    this.Selection.Start = new Place(0, num1);
    this.Selection.End = new Place(this.textSource_0[num2].Count, num2);
    this.needRecalc = true;
    this.textSource_0.Manager.EndAutoUndoCommands();
    this.Selection.EndUpdate();
    this.EndUpdate();
    this.Invalidate();
  }

  public virtual void RemoveLinePrefix(string prefix)
  {
    this.Selection.Clone();
    int iLine = Math.Min(this.Selection.Start.iLine, this.Selection.End.iLine);
    int num = Math.Max(this.Selection.Start.iLine, this.Selection.End.iLine);
    this.BeginUpdate();
    this.Selection.BeginUpdate();
    this.textSource_0.Manager.BeginAutoUndoCommands();
    this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.TextSource));
    for (int index = iLine; index <= num; ++index)
    {
      string text = this.textSource_0[index].Text;
      string str = text.TrimStart();
      if (str.StartsWith(prefix))
      {
        int iChar = text.Length - str.Length;
        this.Selection.Start = new Place(iChar, index);
        this.Selection.End = new Place(iChar + prefix.Length, index);
        this.ClearSelected();
      }
    }
    this.Selection.Start = new Place(0, iLine);
    this.Selection.End = new Place(this.textSource_0[num].Count, num);
    this.needRecalc = true;
    this.textSource_0.Manager.EndAutoUndoCommands();
    this.Selection.EndUpdate();
    this.EndUpdate();
  }

  public void BeginAutoUndo() => this.textSource_0.Manager.BeginAutoUndoCommands();

  public void EndAutoUndo() => this.textSource_0.Manager.EndAutoUndoCommands();

  public virtual void OnVisualMarkerClick(MouseEventArgs args, StyleVisualMarker marker)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_11 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_11((object) this, new VisualMarkerEventArgs(marker.Style, marker, args));
    }
    marker.Style.OnVisualMarkerClick(this, new VisualMarkerEventArgs(marker.Style, marker, args));
  }

  protected virtual void OnMarkerClick(MouseEventArgs args, VisualMarker marker)
  {
    switch (marker)
    {
      case StyleVisualMarker _:
        this.OnVisualMarkerClick(args, marker as StyleVisualMarker);
        break;
      case CollapseFoldingMarker _:
        this.CollapseFoldingBlock((marker as CollapseFoldingMarker).iLine);
        break;
      case ExpandFoldingMarker _:
        this.ExpandFoldedBlock((marker as ExpandFoldingMarker).iLine);
        break;
      case FoldedAreaMarker _:
        int iLine = (marker as FoldedAreaMarker).iLine;
        int num = this.method_17(iLine);
        if (num < 0)
          break;
        this.Selection.BeginUpdate();
        this.Selection.Start = new Place(0, iLine);
        this.Selection.End = new Place(this.textSource_0[num].Count, num);
        this.Selection.EndUpdate();
        this.Invalidate();
        break;
    }
  }

  protected virtual void OnMarkerDoubleClick(VisualMarker marker)
  {
    if (!(marker is FoldedAreaMarker))
      return;
    this.ExpandFoldedBlock((marker as FoldedAreaMarker).iLine);
    this.Invalidate();
  }

  public Range GetBracketsRange(
    Place placeInsideBrackets,
    char leftBracket,
    char rightBracket,
    bool includeBrackets)
  {
    Range range1 = new Range(this, placeInsideBrackets, placeInsideBrackets);
    Range range2 = range1.Clone();
    Range range3 = (Range) null;
    Range range4 = (Range) null;
    int num1 = 0;
    int num2 = 1000;
    while (range2.GoLeftThroughFolded())
    {
      if ((int) range2.CharAfterStart == (int) leftBracket)
        ++num1;
      if ((int) range2.CharAfterStart == (int) rightBracket)
        --num1;
      if (num1 != 1)
      {
        --num2;
        if (num2 <= 0)
          break;
      }
      else
      {
        range2.Start = new Place(range2.Start.iChar + (!includeBrackets ? 1 : 0), range2.Start.iLine);
        range3 = range2;
        break;
      }
    }
    Range range5 = range1.Clone();
    int num3 = 0;
    int num4 = 1000;
    do
    {
      if ((int) range5.CharAfterStart == (int) leftBracket)
        goto label_14;
label_10:
      if ((int) range5.CharAfterStart == (int) rightBracket)
        --num3;
      if (num3 != -1)
      {
        --num4;
        continue;
      }
      goto label_16;
label_14:
      ++num3;
      goto label_10;
    }
    while (num4 > 0 && range5.GoRightThroughFolded());
    goto label_17;
label_16:
    range5.End = new Place(range5.Start.iChar + (includeBrackets ? 1 : 0), range5.Start.iLine);
    range4 = range5;
label_17:
    return (range3 == null ? 0 : (range4 != null ? 1 : 0)) == 0 ? (Range) null : new Range(this, range3.Start, range4.End);
  }

  public bool SelectNext(string regexPattern, bool backward = false, RegexOptions options = RegexOptions.None)
  {
    Range range1 = this.Selection.Clone();
    range1.Normalize();
    Range range2 = backward ? new Range(this, this.Range.Start, range1.Start) : new Range(this, range1.End, this.Range.End);
    Range range3 = (Range) null;
    foreach (Range range4 in range2.GetRanges(regexPattern, options))
    {
      range3 = range4;
      if (!backward)
        break;
    }
    bool flag;
    if (range3 == null)
    {
      flag = false;
    }
    else
    {
      this.Selection = range3;
      this.Invalidate();
      flag = true;
    }
    return flag;
  }

  public virtual void OnSyntaxHighlight(TextChangedEventArgs args)
  {
    Range range;
    switch (this.HighlightingRangeType)
    {
      case HighlightingRangeType.VisibleRange:
        range = this.VisibleRange.GetUnionWith(args.ChangedRange);
        break;
      case HighlightingRangeType.AllTextRange:
        range = this.Range;
        break;
      default:
        range = args.ChangedRange;
        break;
    }
    if (this.SyntaxHighlighter == null)
      return;
    if ((this.Language != Language.Custom ? 0 : (!string.IsNullOrEmpty(this.DescriptionFile) ? 1 : 0)) != 0)
      this.SyntaxHighlighter.HighlightSyntax(this.DescriptionFile, range);
    else
      this.SyntaxHighlighter.HighlightSyntax(this.Language, range);
  }

  public virtual void Print(Range range, PrintDialogSettings settings)
  {
    ExportToHTML exportToHtml = new ExportToHTML();
    exportToHtml.UseBr = true;
    exportToHtml.UseForwardNbsp = true;
    exportToHtml.UseNbsp = true;
    exportToHtml.UseStyleTag = false;
    exportToHtml.IncludeLineNumbers = settings.IncludeLineNumbers;
    if (range == null)
      range = this.Range;
    if (range.Text == string.Empty)
      return;
    this.range_7 = range;
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_7 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_7((object) this, new EventArgs());
      }
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_10 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_10((object) this, new EventArgs());
      }
    }
    finally
    {
      this.range_7 = (Range) null;
    }
    string html = exportToHtml.GetHtml(range);
    string contents = $"<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=UTF-8\"><head><title>{this.PrepareHtmlText(settings.Title)}</title></head>{html}<br>{Class39.smethod_745(this)}";
    string str = Path.GetTempPath() + "fctb.html";
    File.WriteAllText(str, contents);
    Class39.smethod_666(settings);
    WebBrowser webBrowser = new WebBrowser();
    webBrowser.Tag = (object) settings;
    webBrowser.Visible = false;
    webBrowser.Location = new Point(-1000, -1000);
    webBrowser.Parent = (Control) this;
    webBrowser.StatusTextChanged += new EventHandler(this.method_19);
    webBrowser.Navigate(str);
  }

  protected virtual string PrepareHtmlText(string s)
  {
    return s.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
  }

  private void method_19(object sender, EventArgs e)
  {
    WebBrowser webBrowser = sender as WebBrowser;
    if (!webBrowser.StatusText.Contains("#print"))
      return;
    PrintDialogSettings tag = webBrowser.Tag as PrintDialogSettings;
    try
    {
      if (tag.ShowPrintPreviewDialog)
      {
        webBrowser.ShowPrintPreviewDialog();
      }
      else
      {
        if (tag.ShowPageSetupDialog)
          webBrowser.ShowPageSetupDialog();
        if (tag.ShowPrintDialog)
          webBrowser.ShowPrintDialog();
        else
          webBrowser.Print();
      }
    }
    finally
    {
      webBrowser.Parent = (Control) null;
      webBrowser.Dispose();
    }
  }

  public void Print(PrintDialogSettings settings) => this.Print(this.Range, settings);

  public void Print()
  {
    this.Print(this.Range, new PrintDialogSettings()
    {
      ShowPageSetupDialog = false,
      ShowPrintDialog = false,
      ShowPrintPreviewDialog = false
    });
  }

  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    if (!disposing)
      return;
    if (this.SyntaxHighlighter != null)
      this.SyntaxHighlighter.Dispose();
    this.timer_0.Dispose();
    this.timer_1.Dispose();
    this.timer_3.Dispose();
    if (this.findForm != null)
      this.findForm.Dispose();
    if (this.replaceForm != null)
      this.replaceForm.Dispose();
    if (this.TextSource != null)
      this.TextSource.Dispose();
    if (this.ToolTip == null)
      return;
    this.ToolTip.Dispose();
  }

  protected virtual void OnPaintLine(PaintLineEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_13 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_13((object) this, e);
  }

  public void OpenFile(string fileName, Encoding enc)
  {
    TextSource textSource = this.CreateTextSource();
    try
    {
      this.InitTextSource(textSource);
      this.Text = File.ReadAllText(fileName, enc);
      this.ClearUndo();
      this.IsChanged = false;
      this.OnVisibleRangeChanged();
    }
    catch
    {
      this.InitTextSource(this.CreateTextSource());
      this.textSource_0.InsertLine(0, this.TextSource.CreateLine());
      this.IsChanged = false;
      throw;
    }
    this.Selection.Start = Place.Empty;
    this.DoSelectionVisible();
  }

  public void OpenFile(string fileName)
  {
    try
    {
      Encoding enc = EncodingDetector.DetectTextFileEncoding(fileName);
      if (enc != null)
        this.OpenFile(fileName, enc);
      else
        this.OpenFile(fileName, Encoding.Default);
    }
    catch
    {
      this.InitTextSource(this.CreateTextSource());
      this.textSource_0.InsertLine(0, this.TextSource.CreateLine());
      this.IsChanged = false;
      throw;
    }
  }

  public void OpenBindingFile(string fileName, Encoding enc)
  {
    FileTextSource ts = new FileTextSource(this);
    try
    {
      this.InitTextSource((TextSource) ts);
      ts.OpenFile(fileName, enc);
      this.IsChanged = false;
      this.OnVisibleRangeChanged();
    }
    catch
    {
      ts.CloseFile();
      this.InitTextSource(this.CreateTextSource());
      this.textSource_0.InsertLine(0, this.TextSource.CreateLine());
      this.IsChanged = false;
      throw;
    }
    this.Invalidate();
  }

  public void CloseBindingFile()
  {
    if (!(this.textSource_0 is FileTextSource))
      return;
    (this.textSource_0 as FileTextSource).CloseFile();
    this.InitTextSource(this.CreateTextSource());
    this.textSource_0.InsertLine(0, this.TextSource.CreateLine());
    this.IsChanged = false;
    this.Invalidate();
  }

  public void SaveToFile(string fileName, Encoding enc)
  {
    this.textSource_0.SaveToFile(fileName, enc);
    this.IsChanged = false;
    this.OnVisibleRangeChanged();
    this.UpdateScrollbars();
  }

  public void SetVisibleState(int iLine, VisibleState state)
  {
    LineInfo lineInfo = this.LineInfos[iLine] with
    {
      VisibleState = state
    };
    this.LineInfos[iLine] = lineInfo;
    this.needRecalc = true;
  }

  public VisibleState GetVisibleState(int iLine) => this.LineInfos[iLine].VisibleState;

  public void ShowGoToDialog()
  {
    GoToForm goToForm = new GoToForm();
    goToForm.TotalLineCount = this.LinesCount;
    goToForm.SelectedLineNumber = this.Selection.Start.iLine + 1;
    if (goToForm.ShowDialog() != DialogResult.OK)
      return;
    int num = Math.Min(this.LinesCount - 1, Math.Max(0, goToForm.SelectedLineNumber - 1));
    this.Selection = new Range(this, 0, num, 0, num);
    this.DoSelectionVisible();
  }

  public void OnUndoRedoStateChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_17 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_17((object) this, EventArgs.Empty);
  }

  public List<int> FindLines(string searchPattern, RegexOptions options)
  {
    List<int> lines = new List<int>();
    foreach (Range rangesByLine in this.Range.GetRangesByLines(searchPattern, options))
      lines.Add(rangesByLine.Start.iLine);
    return lines;
  }

  public void RemoveLines(List<int> iLines)
  {
    this.TextSource.Manager.ExecuteCommand((Command) new RemoveLinesCommand(this.TextSource, iLines));
    if (iLines.Count > 0)
      this.IsChanged = true;
    if (this.LinesCount == 0)
      this.Text = "";
    this.NeedRecalc();
    this.Invalidate();
  }

  void ISupportInitialize.BeginInit()
  {
  }

  void ISupportInitialize.EndInit()
  {
    this.OnTextChanged();
    this.Selection.Start = Place.Empty;
    this.DoCaretVisible();
    this.IsChanged = false;
    this.ClearUndo();
  }

  protected override void OnDragEnter(DragEventArgs e)
  {
    if ((!e.Data.GetDataPresent(DataFormats.Text) ? 0 : (this.AllowDrop ? 1 : 0)) != 0)
    {
      e.Effect = DragDropEffects.Copy;
      // ISSUE: reference to a compiler-generated method
      this.method_21(true);
    }
    base.OnDragEnter(e);
  }

  protected override void OnDragDrop(DragEventArgs e)
  {
    if ((this.ReadOnly ? 1 : (!this.AllowDrop ? 1 : 0)) != 0)
    {
      // ISSUE: reference to a compiler-generated method
      this.method_21(false);
    }
    else
    {
      if (e.Data.GetDataPresent(DataFormats.Text))
      {
        if (this.ParentForm != null)
          this.ParentForm.Activate();
        this.Focus();
        Point client = this.PointToClient(new Point(e.X, e.Y));
        string text = e.Data.GetData(DataFormats.Text).ToString();
        this.DoDragDrop(this.PointToPlace(client), text);
        // ISSUE: reference to a compiler-generated method
        this.method_21(false);
      }
      base.OnDragDrop(e);
    }
  }

  protected virtual void DoDragDrop(Place place, string text)
  {
    Range range1 = new Range(this, place, place);
    if (range1.ReadOnly || (this.draggedRange == null ? 0 : (this.draggedRange.Contains(place) ? 1 : 0)) != 0)
      return;
    bool flag = this.draggedRange == null || this.draggedRange.ReadOnly || (Control.ModifierKeys & Keys.Control) != 0;
    if (this.draggedRange == null)
    {
      this.Selection.BeginUpdate();
      this.Selection.Start = place;
      this.InsertText(text);
      this.Selection = new Range(this, place, this.Selection.Start);
      this.Selection.EndUpdate();
    }
    else
    {
      if (!this.draggedRange.Contains(place))
      {
        this.BeginAutoUndo();
        this.Selection = this.draggedRange;
        this.textSource_0.Manager.ExecuteCommand((Command) new SelectCommand(this.textSource_0));
        if (this.draggedRange.ColumnSelectionMode)
        {
          this.draggedRange.Normalize();
          range1 = new Range(this, place, new Place(place.iChar, place.iLine + this.draggedRange.End.iLine - this.draggedRange.Start.iLine))
          {
            ColumnSelectionMode = true
          };
          for (int linesCount = this.LinesCount; linesCount <= range1.End.iLine; ++linesCount)
          {
            Class39.smethod_342(this.Selection, false);
            this.InsertChar('\n');
          }
        }
        if (!range1.ReadOnly)
        {
          if (place < this.draggedRange.Start)
          {
            if (!flag)
            {
              this.Selection = this.draggedRange;
              this.ClearSelected();
            }
            this.Selection = range1;
            this.Selection.ColumnSelectionMode = range1.ColumnSelectionMode;
            this.InsertText(text);
          }
          else
          {
            this.Selection = range1;
            this.Selection.ColumnSelectionMode = range1.ColumnSelectionMode;
            this.InsertText(text);
            if (!flag)
            {
              this.Selection = this.draggedRange;
              this.ClearSelected();
            }
          }
        }
        Place start = place;
        Place end = this.Selection.Start;
        Range range2 = this.draggedRange.End > this.draggedRange.Start ? this.GetRange(this.draggedRange.Start, this.draggedRange.End) : this.GetRange(this.draggedRange.End, this.draggedRange.Start);
        Place place1 = place;
        if ((!(place > this.draggedRange.Start) ? 0 : (!flag ? 1 : 0)) != 0 && !this.draggedRange.ColumnSelectionMode)
        {
          int iChar1;
          int iChar2;
          if (range2.Start.iLine != range2.End.iLine)
          {
            iChar1 = range2.End.iLine != place1.iLine ? place1.iChar : range2.Start.iChar + (place1.iChar - range2.End.iChar);
            iChar2 = range2.End.iChar;
          }
          else if (range2.End.iLine == place1.iLine)
          {
            iChar1 = place1.iChar - range2.Text.Length;
            iChar2 = place1.iChar;
          }
          else
          {
            iChar1 = place1.iChar;
            iChar2 = place1.iChar + range2.Text.Length;
          }
          int iLine1;
          int iLine2;
          if (range2.End.iLine != place1.iLine)
          {
            iLine1 = place1.iLine - (range2.End.iLine - range2.Start.iLine);
            iLine2 = place1.iLine;
          }
          else
          {
            iLine1 = range2.Start.iLine;
            iLine2 = range2.End.iLine;
          }
          start = new Place(iChar1, iLine1);
          end = new Place(iChar2, iLine2);
        }
        if (!this.draggedRange.ColumnSelectionMode)
        {
          this.Selection = new Range(this, start, end);
        }
        else
        {
          int iChar3;
          int iChar4;
          if ((flag || place.iLine < range2.Start.iLine || place.iLine > range2.End.iLine ? 0 : (place.iChar >= range2.End.iChar ? 1 : 0)) != 0)
          {
            iChar3 = place1.iChar - (range2.End.iChar - range2.Start.iChar);
            iChar4 = place1.iChar;
          }
          else
          {
            iChar3 = place1.iChar;
            iChar4 = place1.iChar + (range2.End.iChar - range2.Start.iChar);
          }
          int iLine3 = place1.iLine;
          int iLine4 = place1.iLine + (range2.End.iLine - range2.Start.iLine);
          start = new Place(iChar3, iLine3);
          end = new Place(iChar4, iLine4);
          this.Selection = new Range(this, start, end)
          {
            ColumnSelectionMode = true
          };
        }
        this.EndAutoUndo();
      }
      this.range_0.Inverse();
      this.OnSelectionChanged();
    }
    this.draggedRange = (Range) null;
  }

  protected override void OnDragOver(DragEventArgs e)
  {
    if (e.Data.GetDataPresent(DataFormats.Text))
    {
      Point client = this.PointToClient(new Point(e.X, e.Y));
      this.Selection.Start = this.PointToPlace(client);
      if ((client.Y >= 6 || !this.VerticalScroll.Visible ? 0 : (this.VerticalScroll.Value > 0 ? 1 : 0)) != 0)
        this.VerticalScroll.Value = Math.Max(0, this.VerticalScroll.Value - this.int_0);
      this.DoCaretVisible();
      this.Invalidate();
    }
    base.OnDragOver(e);
  }

  protected override void OnDragLeave(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated method
    this.method_21(false);
    base.OnDragLeave(e);
  }

  private void method_22(MouseEventArgs mouseEventArgs_0)
  {
    if (this.bool_33 || (this.HorizontalScroll.Visible ? 0 : (!this.VerticalScroll.Visible ? 1 : 0)) != 0 && this.ShowScrollBars)
      return;
    this.bool_33 = true;
    this.point_2 = mouseEventArgs_0.Location;
    this.point_3 = new Point(this.HorizontalScroll.Value, this.VerticalScroll.Value);
    this.timer_3.Interval = 50;
    this.timer_3.Enabled = true;
    this.Capture = true;
    this.Refresh();
    Class39.SendMessage_4(this.Handle, 11, 0, 0);
  }

  private void method_23()
  {
    if (!this.bool_33)
      return;
    this.bool_33 = false;
    this.timer_3.Enabled = false;
    this.Capture = false;
    base.Cursor = this.cursor_0;
    Class39.SendMessage_4(this.Handle, 11, 1, 0);
    this.Invalidate();
  }

  private void method_24()
  {
    this.OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, this.HorizontalScroll.Value, this.point_3.X, ScrollOrientation.HorizontalScroll));
    this.OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, this.VerticalScroll.Value, this.point_3.Y, ScrollOrientation.VerticalScroll));
  }

  private void timer_3_Tick(object sender, EventArgs e)
  {
    if (this.IsDisposed || !this.bool_33)
      return;
    Point client = this.PointToClient(Cursor.Position);
    this.Capture = true;
    int x = this.point_2.X - client.X;
    int num1 = this.point_2.Y - client.Y;
    if ((this.VerticalScroll.Visible ? 0 : (this.ShowScrollBars ? 1 : 0)) != 0)
      num1 = 0;
    if ((this.HorizontalScroll.Visible ? 0 : (this.ShowScrollBars ? 1 : 0)) != 0)
      x = 0;
    double num2 = 180.0 - Math.Atan2((double) num1, (double) x) * 180.0 / Math.PI;
    this.scrollDirection_0 = Math.Sqrt(Math.Pow((double) x, 2.0) + Math.Pow((double) num1, 2.0)) <= 10.0 ? ScrollDirection.None : ((num2 >= 325.0 ? 1 : (num2 <= 35.0 ? 1 : 0)) == 0 ? (num2 > 55.0 ? (num2 > 125.0 ? (num2 > 145.0 ? (num2 > 215.0 ? (num2 > 235.0 ? (num2 > 305.0 ? ScrollDirection.Right | ScrollDirection.Down : ScrollDirection.Down) : ScrollDirection.Left | ScrollDirection.Down) : ScrollDirection.Left) : ScrollDirection.Left | ScrollDirection.Up) : ScrollDirection.Up) : ScrollDirection.Right | ScrollDirection.Up) : ScrollDirection.Right);
    switch (this.scrollDirection_0)
    {
      case ScrollDirection.Left:
        base.Cursor = Cursors.PanWest;
        break;
      case ScrollDirection.Right:
        base.Cursor = Cursors.PanEast;
        break;
      case ScrollDirection.Up:
        base.Cursor = Cursors.PanNorth;
        break;
      case ScrollDirection.Left | ScrollDirection.Up:
        base.Cursor = Cursors.PanNW;
        break;
      case ScrollDirection.Right | ScrollDirection.Up:
        base.Cursor = Cursors.PanNE;
        break;
      case ScrollDirection.Down:
        base.Cursor = Cursors.PanSouth;
        break;
      case ScrollDirection.Left | ScrollDirection.Down:
        base.Cursor = Cursors.PanSW;
        break;
      case ScrollDirection.Right | ScrollDirection.Down:
        base.Cursor = Cursors.PanSE;
        break;
      default:
        base.Cursor = this.cursor_0;
        return;
    }
    int num3 = (int) ((double) -x / 5.0);
    int num4 = (int) ((double) -num1 / 5.0);
    ScrollEventArgs se1 = new ScrollEventArgs(num3 < 0 ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement, this.HorizontalScroll.Value, this.HorizontalScroll.Value + num3, ScrollOrientation.HorizontalScroll);
    ScrollEventArgs se2 = new ScrollEventArgs(num4 < 0 ? ScrollEventType.SmallDecrement : ScrollEventType.SmallIncrement, this.VerticalScroll.Value, this.VerticalScroll.Value + num4, ScrollOrientation.VerticalScroll);
    if ((this.scrollDirection_0 & (ScrollDirection.Up | ScrollDirection.Down)) > ScrollDirection.None)
      this.OnScroll(se2, false);
    if ((this.scrollDirection_0 & (ScrollDirection.Left | ScrollDirection.Right)) > ScrollDirection.None)
      this.OnScroll(se1);
    Class39.SendMessage_4(this.Handle, 11, 1, 0);
    this.Refresh();
    Class39.SendMessage_4(this.Handle, 11, 0, 0);
  }

  internal sealed class Class2 : IComparer<LineInfo>
  {
    private readonly int int_0;

    public Class2(int int_1) => this.int_0 = int_1;

    public int System\u002ECollections\u002EGeneric\u002EIComparer\u003CbuMutliTextbox\u002ELineInfo\u003E\u002ECompare(
      LineInfo x,
      LineInfo y)
    {
      return x.startY != -10 ? x.startY.CompareTo(this.int_0) : -y.startY.CompareTo(this.int_0);
    }
  }
}
