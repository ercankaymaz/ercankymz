#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

public sealed class PdfPage : PdfDictionary, IContentStream
{
	internal sealed class Keys : InheritablePageKeys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Page")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Dictionary | KeyType.Required | KeyType.MustBeIndirect)]
		public const string Parent = "/Parent";

		[KeyInfo(KeyType.Date)]
		public const string LastModified = "/LastModified";

		[KeyInfo("1.3", KeyType.Rectangle | KeyType.Optional)]
		public const string BleedBox = "/BleedBox";

		[KeyInfo("1.3", KeyType.Rectangle | KeyType.Optional)]
		public const string TrimBox = "/TrimBox";

		[KeyInfo("1.3", KeyType.Rectangle | KeyType.Optional)]
		public const string ArtBox = "/ArtBox";

		[KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
		public const string BoxColorInfo = "/BoxColorInfo";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string Contents = "/Contents";

		[KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
		public const string Group = "/Group";

		[KeyInfo(KeyType.Stream | KeyType.Optional)]
		public const string Thumb = "/Thumb";

		[KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
		public const string B = "/B";

		[KeyInfo("1.1", KeyType.Real | KeyType.Optional)]
		public const string Dur = "/Dur";

		[KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
		public const string Trans = "/Trans";

		[KeyInfo(KeyType.Array | KeyType.Optional, typeof(PdfAnnotations))]
		public const string Annots = "/Annots";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
		public const string AA = "/AA";

		[KeyInfo("1.4", KeyType.Stream | KeyType.Optional)]
		public const string Metadata = "/Metadata";

		[KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
		public const string PieceInfo = "/PieceInfo";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string StructParents = "/StructParents";

		[KeyInfo("1.3", KeyType.String | KeyType.Optional)]
		public const string ID = "/ID";

		[KeyInfo("1.3", KeyType.Real | KeyType.Optional)]
		public const string PZ = "/PZ";

		[KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
		public const string SeparationInfo = "/SeparationInfo";

		[KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
		public const string Tabs = "/Tabs";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string TemplateInstantiated = "/TemplateInstantiated";

		[KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
		public const string PresSteps = "/PresSteps";

		[KeyInfo("1.6", KeyType.Real | KeyType.Optional)]
		public const string UserUnit = "/UserUnit";

		[KeyInfo("1.6", KeyType.Dictionary | KeyType.Optional)]
		public const string VP = "/VP";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal class InheritablePageKeys : KeysBase
	{
		[KeyInfo(KeyType.Dictionary | KeyType.Required | KeyType.Inheritable, typeof(PdfResources))]
		public const string Resources = "/Resources";

		[KeyInfo(KeyType.Rectangle | KeyType.Required | KeyType.Inheritable)]
		public const string MediaBox = "/MediaBox";

		[KeyInfo(KeyType.Rectangle | KeyType.Optional | KeyType.Inheritable)]
		public const string CropBox = "/CropBox";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string Rotate = "/Rotate";
	}

	internal struct InheritedValues
	{
		public PdfDictionary Resources;

		public PdfRectangle MediaBox;

		public PdfRectangle CropBox;

		public PdfInteger Rotate;
	}

	private object _tag;

	private bool _closed;

	private PageOrientation _orientation;

	private PageSize _pageSize;

	private TrimMargins _trimMargins = new TrimMargins();

	internal PdfContent RenderContent;

	private PdfContents _contents;

	private PdfAnnotations _annotations;

	private PdfCustomValues _customValues;

	private PdfResources _resources;

	internal bool TransparencyUsed;

	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	internal bool IsClosed => _closed;

	internal override PdfDocument Document
	{
		set
		{
			if (_document != value)
			{
				if (_document != null)
				{
					throw new InvalidOperationException("Cannot change document.");
				}
				_document = value;
				if (base.Reference != null)
				{
					base.Reference.Document = value;
				}
				base.Elements["/Parent"] = _document.Pages.Reference;
			}
		}
	}

	public PageOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public PageSize Size
	{
		get
		{
			return _pageSize;
		}
		set
		{
			if (!Enum.IsDefined(typeof(PageSize), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(PageSize));
			}
			XSize xSize = PageSizeConverter.ToSize(value);
			MediaBox = new PdfRectangle(0.0, 0.0, xSize.Width, xSize.Height);
			_pageSize = value;
		}
	}

	public TrimMargins TrimMargins
	{
		get
		{
			if (_trimMargins == null)
			{
				_trimMargins = new TrimMargins();
			}
			return _trimMargins;
		}
		set
		{
			if (_trimMargins == null)
			{
				_trimMargins = new TrimMargins();
			}
			if (value != null)
			{
				_trimMargins.Left = value.Left;
				_trimMargins.Right = value.Right;
				_trimMargins.Top = value.Top;
				_trimMargins.Bottom = value.Bottom;
			}
			else
			{
				_trimMargins.All = 0;
			}
		}
	}

	public PdfRectangle MediaBox
	{
		get
		{
			return base.Elements.GetRectangle("/MediaBox", create: true);
		}
		set
		{
			base.Elements.SetRectangle("/MediaBox", value);
		}
	}

	public PdfRectangle CropBox
	{
		get
		{
			return base.Elements.GetRectangle("/CropBox", create: true);
		}
		set
		{
			base.Elements.SetRectangle("/CropBox", value);
		}
	}

	public PdfRectangle BleedBox
	{
		get
		{
			return base.Elements.GetRectangle("/BleedBox", create: true);
		}
		set
		{
			base.Elements.SetRectangle("/BleedBox", value);
		}
	}

	public PdfRectangle ArtBox
	{
		get
		{
			return base.Elements.GetRectangle("/ArtBox", create: true);
		}
		set
		{
			base.Elements.SetRectangle("/ArtBox", value);
		}
	}

	public PdfRectangle TrimBox
	{
		get
		{
			return base.Elements.GetRectangle("/TrimBox", create: true);
		}
		set
		{
			base.Elements.SetRectangle("/TrimBox", value);
		}
	}

	public XUnit Height
	{
		get
		{
			PdfRectangle mediaBox = MediaBox;
			return (_orientation == PageOrientation.Portrait) ? mediaBox.Height : mediaBox.Width;
		}
		set
		{
			PdfRectangle mediaBox = MediaBox;
			if (_orientation == PageOrientation.Portrait)
			{
				MediaBox = new PdfRectangle(mediaBox.X1, 0.0, mediaBox.X2, value);
			}
			else
			{
				MediaBox = new PdfRectangle(0.0, mediaBox.Y1, value, mediaBox.Y2);
			}
			_pageSize = PageSize.Undefined;
		}
	}

	public XUnit Width
	{
		get
		{
			PdfRectangle mediaBox = MediaBox;
			return (_orientation == PageOrientation.Portrait) ? mediaBox.Width : mediaBox.Height;
		}
		set
		{
			PdfRectangle mediaBox = MediaBox;
			if (_orientation == PageOrientation.Portrait)
			{
				MediaBox = new PdfRectangle(0.0, mediaBox.Y1, value, mediaBox.Y2);
			}
			else
			{
				MediaBox = new PdfRectangle(mediaBox.X1, 0.0, mediaBox.X2, value);
			}
			_pageSize = PageSize.Undefined;
		}
	}

	public int Rotate
	{
		get
		{
			return _elements.GetInteger("/Rotate");
		}
		set
		{
			if (value % 90 != 0)
			{
				throw new ArgumentException("Value must be a multiple of 90.");
			}
			_elements.SetInteger("/Rotate", value);
		}
	}

	public PdfContents Contents
	{
		get
		{
			if (_contents == null)
			{
				bool flag = true;
				PdfItem pdfItem = base.Elements["/Contents"];
				if (pdfItem == null)
				{
					_contents = new PdfContents(Owner);
				}
				else
				{
					if (pdfItem is PdfReference)
					{
						pdfItem = ((PdfReference)pdfItem).Value;
					}
					PdfArray pdfArray = pdfItem as PdfArray;
					if (pdfArray != null)
					{
						if (pdfArray.IsIndirect)
						{
							pdfArray = pdfArray.Clone();
							pdfArray.Document = Owner;
						}
						_contents = new PdfContents(pdfArray);
					}
					else
					{
						_contents = new PdfContents(Owner);
						PdfContent pdfContent = new PdfContent((PdfDictionary)pdfItem);
						_contents.Elements.Add(pdfContent.Reference);
					}
				}
				Debug.Assert(_contents.Reference == null);
				base.Elements["/Contents"] = _contents;
			}
			return _contents;
		}
	}

	public bool HasAnnotations
	{
		get
		{
			if (_annotations == null)
			{
				_annotations = (PdfAnnotations)base.Elements.GetValue("/Annots");
				_annotations.Page = this;
			}
			return _annotations != null;
		}
	}

	public PdfAnnotations Annotations
	{
		get
		{
			if (_annotations == null)
			{
				_annotations = (PdfAnnotations)base.Elements.GetValue("/Annots", VCF.Create);
				_annotations.Page = this;
			}
			return _annotations;
		}
	}

	public PdfCustomValues CustomValues
	{
		get
		{
			if (_customValues == null)
			{
				_customValues = PdfCustomValues.Get(base.Elements);
			}
			return _customValues;
		}
		set
		{
			if (value != null)
			{
				throw new ArgumentException("Only null is allowed to clear all custom values.");
			}
			PdfCustomValues.Remove(base.Elements);
			_customValues = null;
		}
	}

	public PdfResources Resources
	{
		get
		{
			if (_resources == null)
			{
				_resources = (PdfResources)base.Elements.GetValue("/Resources", VCF.Create);
			}
			return _resources;
		}
	}

	PdfResources IContentStream.Resources => Resources;

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfPage()
	{
		base.Elements.SetName("/Type", "/Page");
		Initialize();
	}

	public PdfPage(PdfDocument document)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Page");
		base.Elements["/Parent"] = document.Pages.Reference;
		Initialize();
	}

	internal PdfPage(PdfDictionary dict)
		: base(dict)
	{
	}

	private void Initialize()
	{
		Size = (RegionInfo.CurrentRegion.IsMetric ? PageSize.A4 : PageSize.Letter);
		PdfRectangle mediaBox = MediaBox;
	}

	public void Close()
	{
		_closed = true;
	}

	public PdfLinkAnnotation AddDocumentLink(PdfRectangle rect, int destinationPage)
	{
		PdfLinkAnnotation pdfLinkAnnotation = PdfLinkAnnotation.CreateDocumentLink(rect, destinationPage);
		Annotations.Add(pdfLinkAnnotation);
		return pdfLinkAnnotation;
	}

	public PdfLinkAnnotation AddWebLink(PdfRectangle rect, string url)
	{
		PdfLinkAnnotation pdfLinkAnnotation = PdfLinkAnnotation.CreateWebLink(rect, url);
		Annotations.Add(pdfLinkAnnotation);
		return pdfLinkAnnotation;
	}

	public PdfLinkAnnotation AddFileLink(PdfRectangle rect, string fileName)
	{
		PdfLinkAnnotation pdfLinkAnnotation = PdfLinkAnnotation.CreateFileLink(rect, fileName);
		Annotations.Add(pdfLinkAnnotation);
		return pdfLinkAnnotation;
	}

	internal string GetFontName(XFont font, out PdfFont pdfFont)
	{
		pdfFont = _document.FontTable.GetFont(font);
		Debug.Assert(pdfFont != null);
		return Resources.AddFont(pdfFont);
	}

	string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
	{
		return GetFontName(font, out pdfFont);
	}

	internal string TryGetFontName(string idName, out PdfFont pdfFont)
	{
		pdfFont = _document.FontTable.TryGetFont(idName);
		string result = null;
		if (pdfFont != null)
		{
			result = Resources.AddFont(pdfFont);
		}
		return result;
	}

	internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
	{
		pdfFont = _document.FontTable.GetFont(idName, fontData);
		Debug.Assert(pdfFont != null);
		return Resources.AddFont(pdfFont);
	}

	string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
	{
		return GetFontName(idName, fontData, out pdfFont);
	}

	internal string GetImageName(XImage image)
	{
		PdfImage image2 = _document.ImageTable.GetImage(image);
		Debug.Assert(image2 != null);
		return Resources.AddImage(image2);
	}

	string IContentStream.GetImageName(XImage image)
	{
		return GetImageName(image);
	}

	internal string GetFormName(XForm form)
	{
		PdfFormXObject form2 = _document.FormTable.GetForm(form);
		Debug.Assert(form2 != null);
		return Resources.AddForm(form2);
	}

	string IContentStream.GetFormName(XForm form)
	{
		return GetFormName(form);
	}

	internal override void WriteObject(PdfWriter writer)
	{
		PdfRectangle mediaBox = MediaBox;
		if (_orientation == PageOrientation.Landscape)
		{
			MediaBox = new PdfRectangle(mediaBox.X1, mediaBox.Y1, mediaBox.Y2, mediaBox.X2);
		}
		TransparencyUsed = true;
		if (TransparencyUsed && !base.Elements.ContainsKey("/Group") && _document.Options.ColorMode != PdfColorMode.Undefined)
		{
			PdfDictionary pdfDictionary = new PdfDictionary();
			_elements["/Group"] = pdfDictionary;
			if (_document.Options.ColorMode != PdfColorMode.Cmyk)
			{
				pdfDictionary.Elements.SetName("/CS", "/DeviceRGB");
			}
			else
			{
				pdfDictionary.Elements.SetName("/CS", "/DeviceCMYK");
			}
			pdfDictionary.Elements.SetName("/S", "/Transparency");
		}
		base.WriteObject(writer);
		if (_orientation == PageOrientation.Landscape)
		{
			MediaBox = mediaBox;
		}
	}

	internal static void InheritValues(PdfDictionary page, InheritedValues values)
	{
		if (values.Resources != null)
		{
			PdfItem pdfItem = page.Elements["/Resources"];
			PdfDictionary pdfDictionary;
			if (pdfItem is PdfReference)
			{
				pdfDictionary = (PdfDictionary)((PdfReference)pdfItem).Value.Clone();
				pdfDictionary.Document = page.Owner;
			}
			else
			{
				pdfDictionary = (PdfDictionary)pdfItem;
			}
			if (pdfDictionary == null)
			{
				pdfDictionary = values.Resources.Clone();
				pdfDictionary.Document = page.Owner;
				page.Elements.Add("/Resources", pdfDictionary);
			}
			else
			{
				PdfName[] keyNames = values.Resources.Elements.KeyNames;
				foreach (PdfName pdfName in keyNames)
				{
					if (!pdfDictionary.Elements.ContainsKey(pdfName.Value))
					{
						PdfItem pdfItem2 = values.Resources.Elements[pdfName];
						if (pdfItem2 is PdfObject)
						{
							pdfItem2 = pdfItem2.Clone();
						}
						pdfDictionary.Elements.Add(pdfName.ToString(), pdfItem2);
					}
				}
			}
		}
		if (values.MediaBox != null && page.Elements["/MediaBox"] == null)
		{
			page.Elements["/MediaBox"] = values.MediaBox;
		}
		if (values.CropBox != null && page.Elements["/CropBox"] == null)
		{
			page.Elements["/CropBox"] = values.CropBox;
		}
		if (values.Rotate != null && page.Elements["/Rotate"] == null)
		{
			page.Elements["/Rotate"] = values.Rotate;
		}
	}

	internal static void InheritValues(PdfDictionary page, ref InheritedValues values)
	{
		PdfItem pdfItem = page.Elements["/Resources"];
		if (pdfItem != null)
		{
			if (pdfItem is PdfReference pdfReference)
			{
				values.Resources = (PdfDictionary)pdfReference.Value;
			}
			else
			{
				values.Resources = (PdfDictionary)pdfItem;
			}
		}
		pdfItem = page.Elements["/MediaBox"];
		if (pdfItem != null)
		{
			values.MediaBox = new PdfRectangle(pdfItem);
		}
		pdfItem = page.Elements["/CropBox"];
		if (pdfItem != null)
		{
			values.CropBox = new PdfRectangle(pdfItem);
		}
		pdfItem = page.Elements["/Rotate"];
		if (pdfItem != null)
		{
			if (pdfItem is PdfReference)
			{
				pdfItem = ((PdfReference)pdfItem).Value;
			}
			values.Rotate = (PdfInteger)pdfItem;
		}
	}

	internal override void PrepareForSave()
	{
		if (_trimMargins.AreSet)
		{
			double num = _trimMargins.Left.Point + Width.Point + _trimMargins.Right.Point;
			double num2 = _trimMargins.Top.Point + Height.Point + _trimMargins.Bottom.Point;
			MediaBox = new PdfRectangle(0.0, 0.0, num, num2);
			CropBox = new PdfRectangle(0.0, 0.0, num, num2);
			BleedBox = new PdfRectangle(0.0, 0.0, num, num2);
			PdfRectangle pdfRectangle = (TrimBox = new PdfRectangle(_trimMargins.Left.Point, _trimMargins.Top.Point, num - _trimMargins.Right.Point, num2 - _trimMargins.Bottom.Point));
			ArtBox = pdfRectangle.Clone();
		}
	}
}
