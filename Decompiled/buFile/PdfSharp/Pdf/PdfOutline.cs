#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf;

public sealed class PdfOutline : PdfDictionary
{
	internal sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Outlines")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.String | KeyType.Required)]
		public const string Title = "/Title";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string Parent = "/Parent";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string Prev = "/Prev";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string Next = "/Next";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string First = "/First";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string Last = "/Last";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string Count = "/Count";

		[KeyInfo(KeyType.ArrayOrNameOrString | KeyType.Optional)]
		public const string Dest = "/Dest";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string A = "/A";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string SE = "/SE";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string C = "/C";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string F = "/F";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private int _count;

	internal int OpenCount;

	private PdfOutline _parent;

	private PdfPage _destinationPage;

	private double? _left = null;

	private double? _top = null;

	private double _right = double.NaN;

	private double _bottom = double.NaN;

	private double? _zoom;

	private bool _opened;

	private PdfPageDestinationType _pageDestinationType = PdfPageDestinationType.Xyz;

	private XColor _textColor;

	private PdfOutlineCollection _outlines;

	internal int Count
	{
		get
		{
			return _count;
		}
		set
		{
			_count = value;
		}
	}

	public PdfOutline Parent
	{
		get
		{
			return _parent;
		}
		internal set
		{
			_parent = value;
		}
	}

	public string Title
	{
		get
		{
			return base.Elements.GetString("/Title");
		}
		set
		{
			PdfString value2 = new PdfString(value, PdfStringEncoding.Unicode);
			base.Elements.SetValue("/Title", value2);
		}
	}

	public PdfPage DestinationPage
	{
		get
		{
			return _destinationPage;
		}
		set
		{
			_destinationPage = value;
		}
	}

	public double? Left
	{
		get
		{
			return _left;
		}
		set
		{
			_left = value;
		}
	}

	public double? Top
	{
		get
		{
			return _top;
		}
		set
		{
			_top = value;
		}
	}

	public double Right
	{
		get
		{
			return _right;
		}
		set
		{
			_right = value;
		}
	}

	public double Bottom
	{
		get
		{
			return _bottom;
		}
		set
		{
			_bottom = value;
		}
	}

	public double? Zoom
	{
		get
		{
			return _zoom;
		}
		set
		{
			if (value.HasValue && value.Value == 0.0)
			{
				_zoom = null;
			}
			else
			{
				_zoom = value;
			}
		}
	}

	public bool Opened
	{
		get
		{
			return _opened;
		}
		set
		{
			_opened = value;
		}
	}

	public PdfOutlineStyle Style
	{
		get
		{
			return (PdfOutlineStyle)base.Elements.GetInteger("/F");
		}
		set
		{
			base.Elements.SetInteger("/F", (int)value);
		}
	}

	public PdfPageDestinationType PageDestinationType
	{
		get
		{
			return _pageDestinationType;
		}
		set
		{
			_pageDestinationType = value;
		}
	}

	public XColor TextColor
	{
		get
		{
			return _textColor;
		}
		set
		{
			_textColor = value;
		}
	}

	public bool HasChildren => _outlines != null && _outlines.Count > 0;

	public PdfOutlineCollection Outlines => _outlines ?? (_outlines = new PdfOutlineCollection(Owner, this));

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfOutline()
	{
	}

	internal PdfOutline(PdfDocument document)
		: base(document)
	{
	}

	public PdfOutline(PdfDictionary dict)
		: base(dict)
	{
		Initialize();
	}

	public PdfOutline(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style, XColor textColor)
	{
		Title = title;
		DestinationPage = destinationPage;
		Opened = opened;
		Style = style;
		TextColor = textColor;
	}

	public PdfOutline(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style)
	{
		Title = title;
		DestinationPage = destinationPage;
		Opened = opened;
		Style = style;
	}

	public PdfOutline(string title, PdfPage destinationPage, bool opened)
	{
		Title = title;
		DestinationPage = destinationPage;
		Opened = opened;
	}

	public PdfOutline(string title, PdfPage destinationPage)
	{
		Title = title;
		DestinationPage = destinationPage;
	}

	internal int CountOpen()
	{
		int num = (_opened ? 1 : 0);
		if (_outlines != null)
		{
			num += _outlines.CountOpen();
		}
		return num;
	}

	private void Initialize()
	{
		if (base.Elements.TryGetString("/Title", out var value))
		{
			Title = value;
		}
		PdfReference reference = base.Elements.GetReference("/Parent");
		if (reference != null && reference.Value is PdfOutline parent)
		{
			Parent = parent;
		}
		Count = base.Elements.GetInteger("/Count");
		PdfArray array = base.Elements.GetArray("/C");
		if (array != null && array.Elements.Count == 3)
		{
			double real = array.Elements.GetReal(0);
			double real2 = array.Elements.GetReal(1);
			double real3 = array.Elements.GetReal(2);
			TextColor = XColor.FromArgb((int)(real * 255.0), (int)(real2 * 255.0), (int)(real3 * 255.0));
		}
		PdfItem value2 = base.Elements.GetValue("/Dest");
		PdfItem value3 = base.Elements.GetValue("/A");
		Debug.Assert(value2 == null || value3 == null, "Either destination or goto action.");
		PdfArray pdfArray = null;
		if (value2 != null)
		{
			if (value2 is PdfArray destination)
			{
				SplitDestinationPage(destination);
			}
			else
			{
				Debug.Assert(condition: false, "See what to do when this happened.");
			}
		}
		else if (value3 != null)
		{
			if (value3 is PdfDictionary pdfDictionary && pdfDictionary.Elements.GetName("/S") == "/GoTo")
			{
				value2 = pdfDictionary.Elements["/D"];
				if (!(value2 is PdfArray pdfArray2))
				{
					throw new Exception("Destination Array expected.");
				}
				base.Elements.Remove("/A");
				base.Elements.Add("/Dest", pdfArray2);
				SplitDestinationPage(pdfArray2);
			}
			else
			{
				Debug.Assert(condition: false, "See what to do when this happened.");
			}
		}
		InitializeChildren();
	}

	private void SplitDestinationPage(PdfArray destination)
	{
		PdfDictionary pdfDictionary = (PdfDictionary)((PdfReference)destination.Elements[0]).Value;
		PdfPage pdfPage = pdfDictionary as PdfPage;
		if (pdfPage == null)
		{
			pdfPage = new PdfPage(pdfDictionary);
		}
		DestinationPage = pdfPage;
		PdfName pdfName = destination.Elements[1] as PdfName;
		if (pdfName != null)
		{
			PageDestinationType = (PdfPageDestinationType)Enum.Parse(typeof(PdfPageDestinationType), pdfName.Value.Substring(1), ignoreCase: true);
			switch (PageDestinationType)
			{
			case PdfPageDestinationType.Xyz:
				Left = destination.Elements.GetNullableReal(2);
				Top = destination.Elements.GetNullableReal(3);
				Zoom = destination.Elements.GetNullableReal(4);
				break;
			case PdfPageDestinationType.Fit:
				break;
			case PdfPageDestinationType.FitH:
				Top = destination.Elements.GetNullableReal(2);
				break;
			case PdfPageDestinationType.FitV:
				Left = destination.Elements.GetNullableReal(2);
				break;
			case PdfPageDestinationType.FitR:
				Left = destination.Elements.GetReal(2);
				Bottom = destination.Elements.GetReal(3);
				Right = destination.Elements.GetReal(4);
				Top = destination.Elements.GetReal(5);
				break;
			case PdfPageDestinationType.FitB:
				break;
			case PdfPageDestinationType.FitBH:
				Top = destination.Elements.GetReal(2);
				break;
			case PdfPageDestinationType.FitBV:
				Left = destination.Elements.GetReal(2);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	private void InitializeChildren()
	{
		PdfReference reference = base.Elements.GetReference("/First");
		PdfReference reference2 = base.Elements.GetReference("/Last");
		PdfReference pdfReference = reference;
		while (pdfReference != null)
		{
			PdfOutline pdfOutline = new PdfOutline((PdfDictionary)pdfReference.Value);
			Outlines.Add(pdfOutline);
			pdfReference = pdfOutline.Elements.GetReference("/Next");
		}
	}

	internal override void PrepareForSave()
	{
		bool hasChildren = HasChildren;
		if (!(_parent != null || hasChildren))
		{
			return;
		}
		if (_parent == null)
		{
			Debug.Assert(_outlines != null && _outlines.Count > 0 && _outlines[0] != null);
			base.Elements["/First"] = _outlines[0].Reference;
			base.Elements["/Last"] = _outlines[_outlines.Count - 1].Reference;
			if (OpenCount > 0)
			{
				base.Elements["/Count"] = new PdfInteger(OpenCount);
			}
		}
		else
		{
			base.Elements["/Parent"] = _parent.Reference;
			int count = _parent._outlines.Count;
			int num = _parent._outlines.IndexOf(this);
			Debug.Assert(num != -1);
			if (DestinationPage != null)
			{
				base.Elements["/Dest"] = CreateDestArray();
			}
			if (num > 0)
			{
				base.Elements["/Prev"] = _parent._outlines[num - 1].Reference;
			}
			if (num < count - 1)
			{
				base.Elements["/Next"] = _parent._outlines[num + 1].Reference;
			}
			if (hasChildren)
			{
				base.Elements["/First"] = _outlines[0].Reference;
				base.Elements["/Last"] = _outlines[_outlines.Count - 1].Reference;
			}
			if (OpenCount > 0)
			{
				base.Elements["/Count"] = new PdfInteger((_opened ? 1 : (-1)) * OpenCount);
			}
			if (_textColor != XColor.Empty && Owner.HasVersion("1.4"))
			{
				base.Elements["/C"] = new PdfLiteral("[{0}]", PdfEncoders.ToString(_textColor, PdfColorMode.Rgb));
			}
		}
		if (!hasChildren)
		{
			return;
		}
		foreach (PdfOutline outline in _outlines)
		{
			outline.PrepareForSave();
		}
	}

	private PdfArray CreateDestArray()
	{
		PdfArray pdfArray = null;
		return PageDestinationType switch
		{
			PdfPageDestinationType.Xyz => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral($"/XYZ {Fd(Left)} {Fd(Top)} {Fd(Zoom)}")), 
			PdfPageDestinationType.Fit => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral("/Fit")), 
			PdfPageDestinationType.FitH => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral($"/FitH {Fd(Top)}")), 
			PdfPageDestinationType.FitV => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral($"/FitV {Fd(Left)}")), 
			PdfPageDestinationType.FitR => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral($"/FitR {Fd(Left)} {Fd(Bottom)} {Fd(Right)} {Fd(Top)}")), 
			PdfPageDestinationType.FitB => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral("/FitB")), 
			PdfPageDestinationType.FitBH => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral($"/FitBH {Fd(Top)}")), 
			PdfPageDestinationType.FitBV => new PdfArray(Owner, DestinationPage.Reference, new PdfLiteral($"/FitBV {Fd(Left)}")), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private string Fd(double value)
	{
		if (double.IsNaN(value))
		{
			throw new InvalidOperationException("Value is not a valid Double.");
		}
		return value.ToString("#.##", CultureInfo.InvariantCulture);
	}

	private string Fd(double? value)
	{
		return value.HasValue ? value.Value.ToString("#.##", CultureInfo.InvariantCulture) : "null";
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.WriteRaw("% Title = " + FilterUnicode(Title) + "\n");
		bool hasChildren = HasChildren;
		if (_parent != null || hasChildren)
		{
			base.WriteObject(writer);
		}
	}

	private string FilterUnicode(string text)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in text)
		{
			stringBuilder.Append(((uint)c < 256u) ? ((c != '\r' && c != '\n') ? c : ' ') : '?');
		}
		return stringBuilder.ToString();
	}
}
