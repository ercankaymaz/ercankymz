using System.Windows;
using System.Windows.Media;
using MS.Internal.Interaction;

namespace Microsoft.Windows.Design.Interaction;

public static class AdornerFonts
{
	private static readonly ResourceKey _fontFamilyKey;

	private static readonly ResourceKey _fontSizeKey;

	public static ResourceKey FontFamilyKey => _fontFamilyKey;

	public static ResourceKey FontSizeKey => _fontSizeKey;

	public static FontFamily FontFamily => GetFontFamily(FontFamilyKey);

	public static double FontSize => GetFontSize(FontSizeKey);

	static AdornerFonts()
	{
		_fontFamilyKey = CreateKey("FontFamilyKey");
		_fontSizeKey = CreateKey("FontSizeKey");
		AdornerResources.RegisterResources(() => (ResourceDictionary)(object)new AdornerFontResourceDictionary());
	}

	private static ResourceKey CreateKey(string name)
	{
		return AdornerResources.CreateResourceKey(typeof(AdornerFonts), name);
	}

	private static double GetFontSize(ResourceKey key)
	{
		return (double)AdornerResources.FindResource(key);
	}

	private static FontFamily GetFontFamily(ResourceKey key)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		return (FontFamily)AdornerResources.FindResource(key);
	}
}
