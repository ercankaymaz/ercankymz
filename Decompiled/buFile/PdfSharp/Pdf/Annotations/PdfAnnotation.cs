using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Annotations;

public abstract class PdfAnnotation : PdfDictionary
{
	public class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Annot")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string Subtype = "/Subtype";

		[KeyInfo(KeyType.Rectangle | KeyType.Required)]
		public const string Rect = "/Rect";

		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string Contents = "/Contents";

		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string NM = "/NM";

		[KeyInfo(KeyType.Date | KeyType.Optional)]
		public const string M = "/M";

		[KeyInfo("1.1", KeyType.Integer | KeyType.Optional)]
		public const string F = "/F";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
		public const string BS = "/BS";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
		public const string AP = "/AP";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
		public const string AS = "/AS";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Border = "/Border";

		[KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
		public const string C = "/C";

		[KeyInfo("1.3", KeyType.Integer | KeyType.Optional)]
		public const string StructParent = "/StructParent";

		[KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
		public const string A = "/A";

		[KeyInfo(KeyType.TextString | KeyType.Optional)]
		public const string T = "/T";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string Popup = "/Popup";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string CA = "/CA";

		[KeyInfo("1.5", KeyType.TextString | KeyType.Optional)]
		public const string Subj = "/Subj";
	}

	private PdfAnnotations _parent;

	public PdfAnnotationFlags Flags
	{
		get
		{
			return (PdfAnnotationFlags)base.Elements.GetInteger("/F");
		}
		set
		{
			base.Elements.SetInteger("/F", (int)value);
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	public PdfAnnotations Parent
	{
		get
		{
			return _parent;
		}
		set
		{
			_parent = value;
		}
	}

	public PdfRectangle Rectangle
	{
		get
		{
			return base.Elements.GetRectangle("/Rect", create: true);
		}
		set
		{
			base.Elements.SetRectangle("/Rect", value);
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	public string Title
	{
		get
		{
			return base.Elements.GetString("/T", create: true);
		}
		set
		{
			base.Elements.SetString("/T", value);
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	public string Subject
	{
		get
		{
			return base.Elements.GetString("/Subj", create: true);
		}
		set
		{
			base.Elements.SetString("/Subj", value);
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	public string Contents
	{
		get
		{
			return base.Elements.GetString("/Contents", create: true);
		}
		set
		{
			base.Elements.SetString("/Contents", value);
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	public XColor Color
	{
		get
		{
			PdfItem pdfItem = base.Elements["/C"];
			if (pdfItem is PdfArray pdfArray && pdfArray.Elements.Count == 3)
			{
				return XColor.FromArgb((int)(pdfArray.Elements.GetReal(0) * 255.0), (int)(pdfArray.Elements.GetReal(1) * 255.0), (int)(pdfArray.Elements.GetReal(2) * 255.0));
			}
			return XColors.Black;
		}
		set
		{
			PdfDocument owner = Owner;
			PdfItem[] items = new PdfReal[3]
			{
				new PdfReal((double)(int)value.R / 255.0),
				new PdfReal((double)(int)value.G / 255.0),
				new PdfReal((double)(int)value.B / 255.0)
			};
			PdfArray value2 = new PdfArray(owner, items);
			base.Elements["/C"] = value2;
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	public double Opacity
	{
		get
		{
			if (!base.Elements.ContainsKey("/CA"))
			{
				return 1.0;
			}
			return base.Elements.GetReal("/CA", create: true);
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "Opacity must be a value in the range from 0 to 1.");
			}
			base.Elements.SetReal("/CA", value);
			base.Elements.SetDateTime("/M", DateTime.Now);
		}
	}

	protected PdfAnnotation()
	{
		Initialize();
	}

	protected PdfAnnotation(PdfDocument document)
		: base(document)
	{
		Initialize();
	}

	internal PdfAnnotation(PdfDictionary dict)
		: base(dict)
	{
	}

	private void Initialize()
	{
		base.Elements.SetName("/Type", "/Annot");
		base.Elements.SetString("/NM", Guid.NewGuid().ToString("D"));
		base.Elements.SetDateTime("/M", DateTime.Now);
	}

	[Obsolete("Use 'Parent.Remove(this)'")]
	public void Delete()
	{
		Parent.Remove(this);
	}
}
