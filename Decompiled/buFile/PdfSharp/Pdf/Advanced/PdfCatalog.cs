using System;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfCatalog : PdfDictionary
{
	internal sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Catalog")]
		public const string Type = "/Type";

		[KeyInfo("1.4", KeyType.Name | KeyType.Optional)]
		public const string Version = "/Version";

		[KeyInfo(KeyType.Dictionary | KeyType.Required | KeyType.MustBeIndirect, typeof(PdfPages))]
		public const string Pages = "/Pages";

		[KeyInfo("1.3", KeyType.NumberTree | KeyType.Optional)]
		public const string PageLabels = "/PageLabels";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
		public const string Names = "/Names";

		[KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
		public const string Dests = "/Dests";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional, typeof(PdfViewerPreferences))]
		public const string ViewerPreferences = "/ViewerPreferences";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string PageLayout = "/PageLayout";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string PageMode = "/PageMode";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfOutline))]
		public const string Outlines = "/Outlines";

		[KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
		public const string Threads = "/Threads";

		[KeyInfo("1.1", KeyType.ArrayOrDictionary | KeyType.Optional)]
		public const string OpenAction = "/OpenAction";

		[KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
		public const string AA = "/AA";

		[KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
		public const string URI = "/URI";

		[KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional, typeof(PdfAcroForm))]
		public const string AcroForm = "/AcroForm";

		[KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional | KeyType.MustBeIndirect)]
		public const string Metadata = "/Metadata";

		[KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
		public const string StructTreeRoot = "/StructTreeRoot";

		[KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
		public const string MarkInfo = "/MarkInfo";

		[KeyInfo("1.4", KeyType.String | KeyType.Optional)]
		public const string Lang = "/Lang";

		[KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
		public const string SpiderInfo = "/SpiderInfo";

		[KeyInfo("1.4", KeyType.Array | KeyType.Optional)]
		public const string OutputIntents = "/OutputIntents";

		[KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
		public const string PieceInfo = "/PieceInfo";

		[KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
		public const string OCProperties = "/OCProperties";

		[KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
		public const string Perms = "/Perms";

		[KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
		public const string Legal = "/Legal";

		[KeyInfo("1.7", KeyType.Array | KeyType.Optional)]
		public const string Requirements = "/Requirements";

		[KeyInfo("1.7", KeyType.Dictionary | KeyType.Optional)]
		public const string Collection = "/Collection";

		[KeyInfo("1.7", KeyType.Boolean | KeyType.Optional)]
		public const string NeedsRendering = "/NeedsRendering";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private string _version = "1.3";

	private PdfPages _pages;

	private PdfViewerPreferences _viewerPreferences;

	private PdfOutline _outline;

	private PdfAcroForm _acroForm;

	public string Version
	{
		get
		{
			return _version;
		}
		set
		{
			switch (value)
			{
			case "1.0":
			case "1.1":
			case "1.2":
				throw new InvalidOperationException("Unsupported PDF version.");
			case "1.3":
			case "1.4":
				_version = value;
				break;
			case "1.5":
			case "1.6":
				throw new InvalidOperationException("Unsupported PDF version.");
			default:
				throw new ArgumentException("Invalid version.");
			}
		}
	}

	public PdfPages Pages
	{
		get
		{
			if (_pages == null)
			{
				_pages = (PdfPages)base.Elements.GetValue("/Pages", VCF.CreateIndirect);
				if (Owner.IsImported)
				{
					_pages.FlattenPageTree();
				}
			}
			return _pages;
		}
	}

	internal PdfPageLayout PageLayout
	{
		get
		{
			return (PdfPageLayout)base.Elements.GetEnumFromName("/PageLayout", PdfPageLayout.SinglePage);
		}
		set
		{
			base.Elements.SetEnumAsName("/PageLayout", value);
		}
	}

	internal PdfPageMode PageMode
	{
		get
		{
			return (PdfPageMode)base.Elements.GetEnumFromName("/PageMode", PdfPageMode.UseNone);
		}
		set
		{
			base.Elements.SetEnumAsName("/PageMode", value);
		}
	}

	internal PdfViewerPreferences ViewerPreferences
	{
		get
		{
			if (_viewerPreferences == null)
			{
				_viewerPreferences = (PdfViewerPreferences)base.Elements.GetValue("/ViewerPreferences", VCF.CreateIndirect);
			}
			return _viewerPreferences;
		}
	}

	internal PdfOutlineCollection Outlines
	{
		get
		{
			if (_outline == null)
			{
				_outline = (PdfOutline)base.Elements.GetValue("/Outlines", VCF.CreateIndirect);
			}
			return _outline.Outlines;
		}
	}

	public PdfAcroForm AcroForm
	{
		get
		{
			if (_acroForm == null)
			{
				_acroForm = (PdfAcroForm)base.Elements.GetValue("/AcroForm");
			}
			return _acroForm;
		}
	}

	public string Language
	{
		get
		{
			return base.Elements.GetString("/Lang");
		}
		set
		{
			if (value == null)
			{
				base.Elements.Remove("/Lang");
			}
			else
			{
				base.Elements.SetString("/Lang", value);
			}
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfCatalog(PdfDocument document)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Catalog");
		_version = "1.4";
	}

	internal PdfCatalog(PdfDictionary dictionary)
		: base(dictionary)
	{
	}

	internal override void PrepareForSave()
	{
		if (_pages != null)
		{
			_pages.PrepareForSave();
		}
		if (_outline != null && _outline.Outlines.Count > 0)
		{
			if (base.Elements["/PageMode"] == null)
			{
				PageMode = PdfPageMode.UseOutlines;
			}
			_outline.PrepareForSave();
		}
	}

	internal override void WriteObject(PdfWriter writer)
	{
		if (_outline != null && _outline.Outlines.Count > 0 && base.Elements["/PageMode"] == null)
		{
			PageMode = PdfPageMode.UseOutlines;
		}
		base.WriteObject(writer);
	}
}
