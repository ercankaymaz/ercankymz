using System;
using System.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Drawing;

public sealed class XFontFamily
{
	internal FontFamilyInternal FamilyInternal;

	public string Name => FamilyInternal.Name;

	[Obsolete("Use platform API directly.")]
	public static XFontFamily[] Families
	{
		get
		{
			throw new InvalidOperationException("Obsolete and not implemted any more.");
		}
	}

	public XFontFamily(string familyName)
	{
		FamilyInternal = FontFamilyInternal.GetOrCreateFromName(familyName, createPlatformObject: true);
	}

	internal XFontFamily(string familyName, bool createPlatformObjects)
	{
		FamilyInternal = FontFamilyInternal.GetOrCreateFromName(familyName, createPlatformObjects);
	}

	private XFontFamily(FontFamilyInternal fontFamilyInternal)
	{
		FamilyInternal = fontFamilyInternal;
	}

	internal static XFontFamily CreateFromName_not_used(string name, bool createPlatformFamily)
	{
		XFontFamily result = new XFontFamily(name);
		if (createPlatformFamily)
		{
		}
		return result;
	}

	internal static XFontFamily GetOrCreateFontFamily(string name)
	{
		FontFamilyInternal fontFamilyInternal = FontFamilyCache.GetFamilyByName(name);
		if (fontFamilyInternal == null)
		{
			fontFamilyInternal = FontFamilyInternal.GetOrCreateFromName(name, createPlatformObject: false);
			fontFamilyInternal = FontFamilyCache.CacheOrGetFontFamily(fontFamilyInternal);
		}
		return new XFontFamily(fontFamilyInternal);
	}

	internal static XFontFamily GetOrCreateFromGdi(Font font)
	{
		FontFamilyInternal orCreateFromGdi = FontFamilyInternal.GetOrCreateFromGdi(font.FontFamily);
		return new XFontFamily(orCreateFromGdi);
	}

	public int GetCellAscent(XFontStyle style)
	{
		OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(Name, style);
		return openTypeDescriptor.Ascender;
	}

	public int GetCellDescent(XFontStyle style)
	{
		OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(Name, style);
		return openTypeDescriptor.Descender;
	}

	public int GetEmHeight(XFontStyle style)
	{
		OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(Name, style);
		return openTypeDescriptor.UnitsPerEm;
	}

	public int GetLineSpacing(XFontStyle style)
	{
		OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(Name, style);
		return openTypeDescriptor.LineSpacing;
	}

	public bool IsStyleAvailable(XFontStyle style)
	{
		XGdiFontStyle xGdiFontStyle = (XGdiFontStyle)(style & XFontStyle.BoldItalic);
		throw new InvalidOperationException("In CORE build it is the responsibility of the developer to provide all required font faces.");
	}

	[Obsolete("Use platform API directly.")]
	public static XFontFamily[] GetFamilies(XGraphics graphics)
	{
		throw new InvalidOperationException("Obsolete and not implemted any more.");
	}
}
