using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfResources : PdfDictionary
{
	public sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string ExtGState = "/ExtGState";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string ColorSpace = "/ColorSpace";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string Pattern = "/Pattern";

		[KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string Shading = "/Shading";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string XObject = "/XObject";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string Font = "/Font";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string ProcSet = "/ProcSet";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResourceMap))]
		public const string Properties = "/Properties";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private PdfResourceMap _fonts;

	private PdfResourceMap _xObjects;

	private PdfResourceMap _extGStates;

	private PdfResourceMap _colorSpaces;

	private PdfResourceMap _patterns;

	private PdfResourceMap _shadings;

	private PdfResourceMap _properties;

	private int _fontNumber;

	private int _imageNumber;

	private int _formNumber;

	private int _extGStateNumber;

	private int _patternNumber;

	private int _shadingNumber;

	private Dictionary<string, object> _importedResourceNames;

	private readonly Dictionary<PdfObject, string> _resources = new Dictionary<PdfObject, string>();

	internal PdfResourceMap Fonts => _fonts ?? (_fonts = (PdfResourceMap)base.Elements.GetValue("/Font", VCF.Create));

	internal PdfResourceMap XObjects => _xObjects ?? (_xObjects = (PdfResourceMap)base.Elements.GetValue("/XObject", VCF.Create));

	internal PdfResourceMap ExtGStates => _extGStates ?? (_extGStates = (PdfResourceMap)base.Elements.GetValue("/ExtGState", VCF.Create));

	internal PdfResourceMap ColorSpaces => _colorSpaces ?? (_colorSpaces = (PdfResourceMap)base.Elements.GetValue("/ColorSpace", VCF.Create));

	internal PdfResourceMap Patterns => _patterns ?? (_patterns = (PdfResourceMap)base.Elements.GetValue("/Pattern", VCF.Create));

	internal PdfResourceMap Shadings => _shadings ?? (_shadings = (PdfResourceMap)base.Elements.GetValue("/Shading", VCF.Create));

	internal PdfResourceMap Properties => _properties ?? (_properties = (PdfResourceMap)base.Elements.GetValue("/Properties", VCF.Create));

	private string NextFontName
	{
		get
		{
			string result;
			while (ExistsResourceNames(result = $"/F{_fontNumber++}"))
			{
			}
			return result;
		}
	}

	private string NextImageName
	{
		get
		{
			string result;
			while (ExistsResourceNames(result = $"/I{_imageNumber++}"))
			{
			}
			return result;
		}
	}

	private string NextFormName
	{
		get
		{
			string result;
			while (ExistsResourceNames(result = $"/Fm{_formNumber++}"))
			{
			}
			return result;
		}
	}

	private string NextExtGStateName
	{
		get
		{
			string result;
			while (ExistsResourceNames(result = $"/GS{_extGStateNumber++}"))
			{
			}
			return result;
		}
	}

	private string NextPatternName
	{
		get
		{
			string result;
			while (ExistsResourceNames(result = $"/Pa{_patternNumber++}"))
			{
			}
			return result;
		}
	}

	private string NextShadingName
	{
		get
		{
			string result;
			while (ExistsResourceNames(result = $"/Sh{_shadingNumber++}"))
			{
			}
			return result;
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfResources(PdfDocument document)
		: base(document)
	{
		base.Elements["/ProcSet"] = new PdfLiteral("[/PDF/Text/ImageB/ImageC/ImageI]");
	}

	internal PdfResources(PdfDictionary dict)
		: base(dict)
	{
	}

	public string AddFont(PdfFont font)
	{
		if (!_resources.TryGetValue(font, out var value))
		{
			value = NextFontName;
			_resources[font] = value;
			if (font.Reference == null)
			{
				Owner._irefTable.Add(font);
			}
			Fonts.Elements[value] = font.Reference;
		}
		return value;
	}

	public string AddImage(PdfImage image)
	{
		if (!_resources.TryGetValue(image, out var value))
		{
			value = NextImageName;
			_resources[image] = value;
			if (image.Reference == null)
			{
				Owner._irefTable.Add(image);
			}
			XObjects.Elements[value] = image.Reference;
		}
		return value;
	}

	public string AddForm(PdfFormXObject form)
	{
		if (!_resources.TryGetValue(form, out var value))
		{
			value = NextFormName;
			_resources[form] = value;
			if (form.Reference == null)
			{
				Owner._irefTable.Add(form);
			}
			XObjects.Elements[value] = form.Reference;
		}
		return value;
	}

	public string AddExtGState(PdfExtGState extGState)
	{
		if (!_resources.TryGetValue(extGState, out var value))
		{
			value = NextExtGStateName;
			_resources[extGState] = value;
			if (extGState.Reference == null)
			{
				Owner._irefTable.Add(extGState);
			}
			ExtGStates.Elements[value] = extGState.Reference;
		}
		return value;
	}

	public string AddPattern(PdfShadingPattern pattern)
	{
		if (!_resources.TryGetValue(pattern, out var value))
		{
			value = NextPatternName;
			_resources[pattern] = value;
			if (pattern.Reference == null)
			{
				Owner._irefTable.Add(pattern);
			}
			Patterns.Elements[value] = pattern.Reference;
		}
		return value;
	}

	public string AddPattern(PdfTilingPattern pattern)
	{
		if (!_resources.TryGetValue(pattern, out var value))
		{
			value = NextPatternName;
			_resources[pattern] = value;
			if (pattern.Reference == null)
			{
				Owner._irefTable.Add(pattern);
			}
			Patterns.Elements[value] = pattern.Reference;
		}
		return value;
	}

	public string AddShading(PdfShading shading)
	{
		if (!_resources.TryGetValue(shading, out var value))
		{
			value = NextShadingName;
			_resources[shading] = value;
			if (shading.Reference == null)
			{
				Owner._irefTable.Add(shading);
			}
			Shadings.Elements[value] = shading.Reference;
		}
		return value;
	}

	internal bool ExistsResourceNames(string name)
	{
		if (_importedResourceNames == null)
		{
			_importedResourceNames = new Dictionary<string, object>();
			if (base.Elements["/Font"] != null)
			{
				Fonts.CollectResourceNames(_importedResourceNames);
			}
			if (base.Elements["/XObject"] != null)
			{
				XObjects.CollectResourceNames(_importedResourceNames);
			}
			if (base.Elements["/ExtGState"] != null)
			{
				ExtGStates.CollectResourceNames(_importedResourceNames);
			}
			if (base.Elements["/ColorSpace"] != null)
			{
				ColorSpaces.CollectResourceNames(_importedResourceNames);
			}
			if (base.Elements["/Pattern"] != null)
			{
				Patterns.CollectResourceNames(_importedResourceNames);
			}
			if (base.Elements["/Shading"] != null)
			{
				Shadings.CollectResourceNames(_importedResourceNames);
			}
			if (base.Elements["/Properties"] != null)
			{
				Properties.CollectResourceNames(_importedResourceNames);
			}
		}
		return _importedResourceNames.ContainsKey(name);
	}
}
