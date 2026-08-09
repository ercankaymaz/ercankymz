using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Fonts.TrueType.Parser;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

public sealed class SystemFontFinder : ISystemFontFinder
{
	private static readonly IReadOnlyDictionary<string, string[]> NameSubstitutes;

	private static readonly Lazy<IReadOnlyList<SystemFontRecord>> AvailableFonts;

	private static readonly object CacheLock;

	private static readonly Dictionary<string, TrueTypeFont> Cache;

	public static readonly ISystemFontFinder Instance;

	private readonly ConcurrentDictionary<string, string> nameToFileNameMap = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private readonly object readFilesLock = new object();

	private readonly HashSet<string> readFiles = new HashSet<string>();

	static SystemFontFinder()
	{
		CacheLock = new object();
		Cache = new Dictionary<string, TrueTypeFont>(StringComparer.OrdinalIgnoreCase);
		Instance = new SystemFontFinder();
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>
		{
			{
				"Courier",
				new string[4] { "CourierNew", "CourierNewPSMT", "LiberationMono", "NimbusMonL-Regu" }
			},
			{
				"Courier-Bold",
				new string[4] { "CourierNewPS-BoldMT", "CourierNew-Bold", "LiberationMono-Bold", "NimbusMonL-Bold" }
			},
			{
				"Courier-Oblique",
				new string[4] { "CourierNewPS-ItalicMT", "CourierNew-Italic", "LiberationMono-Italic", "NimbusMonL-ReguObli" }
			},
			{
				"Courier-BoldOblique",
				new string[4] { "CourierNewPS-BoldItalicMT", "CourierNew-BoldItalic", "LiberationMono-BoldItalic", "NimbusMonL-BoldObli" }
			},
			{
				"Helvetica",
				new string[4] { "ArialMT", "Arial", "LiberationSans", "NimbusSanL-Regu" }
			},
			{
				"Helvetica-Bold",
				new string[4] { "Arial-BoldMT", "Arial-Bold", "LiberationSans-Bold", "NimbusSanL-Bold" }
			},
			{
				"Helvetica-BoldOblique",
				new string[4] { "Arial-BoldItalicMT", "Helvetica-BoldItalic", "LiberationSans-BoldItalic", "NimbusSanL-BoldItal" }
			},
			{
				"Helvetica-Oblique",
				new string[5] { "Arial-ItalicMT", "Arial-Italic", "Helvetica-Italic", "LiberationSans-Italic", "NimbusSanL-ReguItal" }
			},
			{
				"Times-Roman",
				new string[5] { "TimesNewRomanPSMT", "TimesNewRoman", "TimesNewRomanPS", "LiberationSerif", "NimbusRomNo9L-Regu" }
			},
			{
				"Times-Bold",
				new string[5] { "TimesNewRomanPS-BoldMT", "TimesNewRomanPS-Bold", "TimesNewRoman-Bold", "LiberationSerif-Bold", "NimbusRomNo9L-Medi" }
			},
			{
				"Times-Italic",
				new string[5] { "TimesNewRomanPS-ItalicMT", "TimesNewRomanPS-Italic", "TimesNewRoman-Italic", "LiberationSerif-Italic", "NimbusRomNo9L-ReguItal" }
			},
			{
				"Times-BoldItalic",
				new string[5] { "TimesNewRomanPS-BoldItalicMT", "TimesNewRomanPS-BoldItalic", "TimesNewRoman-BoldItalic", "LiberationSerif-BoldItalic", "NimbusRomNo9L-MediItal" }
			},
			{
				"Symbol",
				new string[2] { "SymbolMT", "StandardSymL" }
			},
			{
				"ZapfDingbats",
				new string[3] { "ZapfDingbatsITC", "Dingbats", "MS-Gothic" }
			}
		};
		HashSet<string> names;
		try
		{
			names = Standard14.GetNames();
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("Failed to load the Standard 14 fonts from the assembly's resources.", innerException);
		}
		foreach (string item in names)
		{
			if (!dictionary.ContainsKey(item))
			{
				string mappedFontName = Standard14.GetMappedFontName(item);
				if (dictionary.TryGetValue(mappedFontName, out var value))
				{
					dictionary[item] = value;
					continue;
				}
				dictionary[item] = new string[1] { mappedFontName };
			}
		}
		NameSubstitutes = dictionary;
		ISystemFontLister lister = new WindowsSystemFontLister();
		AvailableFonts = new Lazy<IReadOnlyList<SystemFontRecord>>(() => lister.GetAllFonts().ToArray());
	}

	private SystemFontFinder()
	{
	}

	public TrueTypeFont GetTrueTypeFont(string name)
	{
		TrueTypeFont trueTypeFontNamed = GetTrueTypeFontNamed(name);
		if (trueTypeFontNamed != null)
		{
			return trueTypeFontNamed;
		}
		if (name.Contains("-"))
		{
			trueTypeFontNamed = GetTrueTypeFontNamed(name.Replace("-", string.Empty));
			if (trueTypeFontNamed != null)
			{
				return trueTypeFontNamed;
			}
		}
		if (name.Contains(","))
		{
			trueTypeFontNamed = GetTrueTypeFontNamed(name.Replace(',', '-'));
			if (trueTypeFontNamed != null)
			{
				return trueTypeFontNamed;
			}
		}
		foreach (string substituteName in GetSubstituteNames(name))
		{
			trueTypeFontNamed = GetTrueTypeFontNamed(substituteName);
			if (trueTypeFontNamed != null)
			{
				return trueTypeFontNamed;
			}
		}
		return GetTrueTypeFontNamed(name + "-Regular");
	}

	private IEnumerable<string> GetSubstituteNames(string name)
	{
		name = name.Replace(" ", string.Empty);
		if (NameSubstitutes.TryGetValue(name, out string[] value))
		{
			return value;
		}
		return Array.Empty<string>();
	}

	private TrueTypeFont GetTrueTypeFontNamed(string name)
	{
		lock (CacheLock)
		{
			if (Cache.TryGetValue(name, out TrueTypeFont value))
			{
				return value;
			}
		}
		if (nameToFileNameMap.TryGetValue(name, out string value2))
		{
			if (TryReadFile(value2, readNameFirst: false, name, out TrueTypeFont font))
			{
				return font;
			}
			return null;
		}
		foreach (SystemFontRecord item in AvailableFonts.Value.Where((SystemFontRecord x) => Path.GetFileName(x.Path)?.StartsWith(name[0].ToString(), StringComparison.OrdinalIgnoreCase) ?? false))
		{
			if (TryGetTrueTypeFont(name, item, out TrueTypeFont font2))
			{
				return font2;
			}
		}
		foreach (SystemFontRecord item2 in AvailableFonts.Value)
		{
			if (TryGetTrueTypeFont(name, item2, out TrueTypeFont font3))
			{
				return font3;
			}
		}
		return null;
	}

	private bool TryGetTrueTypeFont(string name, SystemFontRecord record, out TrueTypeFont font)
	{
		font = null;
		if (record.Type == SystemFontType.TrueType)
		{
			lock (readFilesLock)
			{
				if (readFiles.Contains(record.Path))
				{
					return false;
				}
			}
			return TryReadFile(record.Path, readNameFirst: true, name, out font);
		}
		return false;
	}

	private bool TryReadFile(string fileName, bool readNameFirst, string fontName, out TrueTypeFont font)
	{
		font = null;
		TrueTypeDataBytes trueTypeDataBytes = new TrueTypeDataBytes(new MemoryInputBytes(File.ReadAllBytes(fileName)));
		if (readNameFirst)
		{
			NameTable nameTable = TrueTypeFontParser.GetNameTable(trueTypeDataBytes);
			if (nameTable == null)
			{
				lock (readFilesLock)
				{
					readFiles.Add(fileName);
				}
				return false;
			}
			string text = nameTable.GetPostscriptName() ?? nameTable.FontName;
			nameToFileNameMap.TryAdd(text, fileName);
			if (!string.Equals(text, fontName, StringComparison.OrdinalIgnoreCase))
			{
				lock (readFilesLock)
				{
					readFiles.Add(fileName);
				}
				return false;
			}
		}
		trueTypeDataBytes.Seek(0L);
		font = TrueTypeFontParser.Parse(trueTypeDataBytes);
		string key = font.TableRegister.NameTable?.GetPostscriptName() ?? font.Name;
		lock (CacheLock)
		{
			if (!Cache.ContainsKey(key))
			{
				Cache[key] = font;
			}
		}
		lock (readFilesLock)
		{
			readFiles.Add(fileName);
		}
		return true;
	}
}
