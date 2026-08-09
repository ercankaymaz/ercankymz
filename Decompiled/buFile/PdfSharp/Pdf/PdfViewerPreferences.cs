namespace PdfSharp.Pdf;

public sealed class PdfViewerPreferences : PdfDictionary
{
	internal sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string HideToolbar = "/HideToolbar";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string HideMenubar = "/HideMenubar";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string HideWindowUI = "/HideWindowUI";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string FitWindow = "/FitWindow";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string CenterWindow = "/CenterWindow";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string DisplayDocTitle = "/DisplayDocTitle";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string NonFullScreenPageMode = "/NonFullScreenPageMode";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string Direction = "/Direction";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string ViewArea = "/ViewArea";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string ViewClip = "/ViewClip";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string PrintArea = "/PrintArea";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string PrintClip = "/PrintClip";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string PrintScaling = "/PrintScaling";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	public bool HideToolbar
	{
		get
		{
			return base.Elements.GetBoolean("/HideToolbar");
		}
		set
		{
			base.Elements.SetBoolean("/HideToolbar", value);
		}
	}

	public bool HideMenubar
	{
		get
		{
			return base.Elements.GetBoolean("/HideMenubar");
		}
		set
		{
			base.Elements.SetBoolean("/HideMenubar", value);
		}
	}

	public bool HideWindowUI
	{
		get
		{
			return base.Elements.GetBoolean("/HideWindowUI");
		}
		set
		{
			base.Elements.SetBoolean("/HideWindowUI", value);
		}
	}

	public bool FitWindow
	{
		get
		{
			return base.Elements.GetBoolean("/FitWindow");
		}
		set
		{
			base.Elements.SetBoolean("/FitWindow", value);
		}
	}

	public bool CenterWindow
	{
		get
		{
			return base.Elements.GetBoolean("/CenterWindow");
		}
		set
		{
			base.Elements.SetBoolean("/CenterWindow", value);
		}
	}

	public bool DisplayDocTitle
	{
		get
		{
			return base.Elements.GetBoolean("/DisplayDocTitle");
		}
		set
		{
			base.Elements.SetBoolean("/DisplayDocTitle", value);
		}
	}

	public PdfReadingDirection? Direction
	{
		get
		{
			string name = base.Elements.GetName("/Direction");
			string text = name;
			if (!(text == "L2R"))
			{
				if (text == "R2L")
				{
					return PdfReadingDirection.RightToLeft;
				}
				return null;
			}
			return PdfReadingDirection.LeftToRight;
		}
		set
		{
			if (value.HasValue)
			{
				PdfReadingDirection value2 = value.Value;
				PdfReadingDirection pdfReadingDirection = value2;
				if (pdfReadingDirection == PdfReadingDirection.RightToLeft)
				{
					base.Elements.SetName("/Direction", "R2L");
				}
				else
				{
					base.Elements.SetName("/Direction", "L2R");
				}
			}
			else
			{
				base.Elements.Remove("/Direction");
			}
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfViewerPreferences(PdfDocument document)
		: base(document)
	{
	}

	private PdfViewerPreferences(PdfDictionary dict)
		: base(dict)
	{
	}
}
