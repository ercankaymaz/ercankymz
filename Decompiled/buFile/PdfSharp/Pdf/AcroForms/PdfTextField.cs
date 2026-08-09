using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfTextField : PdfAcroField
{
	public new class Keys : PdfAcroField.Keys
	{
		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string MaxLen = "/MaxLen";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private XFont _font = new XFont("Courier New", 10.0);

	private XColor _foreColor = XColors.Black;

	private XColor _backColor = XColor.Empty;

	public string Text
	{
		get
		{
			return base.Elements.GetString("/V");
		}
		set
		{
			base.Elements.SetString("/V", value);
			RenderAppearance();
		}
	}

	public XFont Font
	{
		get
		{
			return _font;
		}
		set
		{
			_font = value;
		}
	}

	public XColor ForeColor
	{
		get
		{
			return _foreColor;
		}
		set
		{
			_foreColor = value;
		}
	}

	public XColor BackColor
	{
		get
		{
			return _backColor;
		}
		set
		{
			_backColor = value;
		}
	}

	public int MaxLength
	{
		get
		{
			return base.Elements.GetInteger("/MaxLen");
		}
		set
		{
			base.Elements.SetInteger("/MaxLen", value);
		}
	}

	public bool MultiLine
	{
		get
		{
			return (base.Flags & PdfAcroFieldFlags.Multiline) != 0;
		}
		set
		{
			if (value)
			{
				base.SetFlags |= PdfAcroFieldFlags.Multiline;
			}
			else
			{
				base.SetFlags &= ~PdfAcroFieldFlags.Multiline;
			}
		}
	}

	public bool Password
	{
		get
		{
			return (base.Flags & PdfAcroFieldFlags.Password) != 0;
		}
		set
		{
			if (value)
			{
				base.SetFlags |= PdfAcroFieldFlags.Password;
			}
			else
			{
				base.SetFlags &= ~PdfAcroFieldFlags.Password;
			}
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfTextField(PdfDocument document)
		: base(document)
	{
	}

	internal PdfTextField(PdfDictionary dict)
		: base(dict)
	{
	}

	private void RenderAppearance()
	{
		PdfRectangle rectangle = base.Elements.GetRectangle("/Rect");
		XForm xForm = new XForm(_document, rectangle.Size);
		XGraphics xGraphics = XGraphics.FromForm(xForm);
		if (_backColor != XColor.Empty)
		{
			xGraphics.DrawRectangle(new XSolidBrush(BackColor), rectangle.ToXRect() - rectangle.Location);
		}
		string text = Text;
		if (text.Length > 0)
		{
			xGraphics.DrawString(Text, Font, new XSolidBrush(ForeColor), rectangle.ToXRect() - rectangle.Location + new XPoint(2.0, 0.0), XStringFormats.TopLeft);
		}
		xForm.DrawingFinished();
		xForm.PdfForm.Elements.Add("/FormType", new PdfLiteral("1"));
		PdfDictionary pdfDictionary = base.Elements["/AP"] as PdfDictionary;
		if (pdfDictionary == null)
		{
			pdfDictionary = new PdfDictionary(_document);
			base.Elements["/AP"] = pdfDictionary;
		}
		pdfDictionary.Elements["/N"] = xForm.PdfForm.Reference;
		PdfFormXObject pdfForm = xForm.PdfForm;
		string text2 = pdfForm.Stream.ToString();
		text2 = "/Tx BMC\n" + text2 + "\nEMC";
		pdfForm.Stream.Value = new RawEncoding().GetBytes(text2);
	}

	internal override void PrepareForSave()
	{
		base.PrepareForSave();
		RenderAppearance();
	}
}
