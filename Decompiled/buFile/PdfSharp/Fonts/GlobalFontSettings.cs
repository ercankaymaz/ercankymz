using System;
using PdfSharp.Internal;
using PdfSharp.Pdf;

namespace PdfSharp.Fonts;

public static class GlobalFontSettings
{
	public const string DefaultFontName = "PlatformDefault";

	private static IFontResolver _fontResolver;

	private static PdfFontEncoding _fontEncoding;

	private static bool _fontEncodingInitialized;

	public static IFontResolver FontResolver
	{
		get
		{
			return _fontResolver;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			try
			{
				Lock.EnterFontFactory();
				if (_fontResolver != value)
				{
					if (FontFactory.HasFontSources)
					{
						throw new InvalidOperationException("Must not change font resolver after is was once used.");
					}
					_fontResolver = value;
				}
			}
			finally
			{
				Lock.ExitFontFactory();
			}
		}
	}

	public static PdfFontEncoding DefaultFontEncoding
	{
		get
		{
			if (!_fontEncodingInitialized)
			{
				DefaultFontEncoding = PdfFontEncoding.Unicode;
			}
			return _fontEncoding;
		}
		set
		{
			try
			{
				Lock.EnterFontFactory();
				if (_fontEncodingInitialized)
				{
					if (_fontEncoding != value)
					{
						throw new InvalidOperationException("Must not change DefaultFontEncoding after is was set once.");
					}
				}
				else
				{
					_fontEncoding = value;
					_fontEncodingInitialized = true;
				}
			}
			finally
			{
				Lock.ExitFontFactory();
			}
		}
	}
}
