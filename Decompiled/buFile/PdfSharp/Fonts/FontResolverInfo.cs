using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts;

[DebuggerDisplay("{DebuggerDisplay}")]
public class FontResolverInfo
{
	private const string KeyPrefix = "frik:";

	private string _key;

	private readonly string _faceName;

	private readonly bool _mustSimulateBold;

	private readonly bool _mustSimulateItalic;

	private readonly int _collectionNumber;

	internal string Key => _key ?? (_key = "frik:" + _faceName.ToLowerInvariant() + "/" + (_mustSimulateBold ? "b+" : "b-") + (_mustSimulateItalic ? "i+" : "i-"));

	public string FaceName => _faceName;

	public bool MustSimulateBold => _mustSimulateBold;

	public bool MustSimulateItalic => _mustSimulateItalic;

	public XStyleSimulations StyleSimulations => (XStyleSimulations)((_mustSimulateBold ? 1 : 0) | (_mustSimulateItalic ? 2 : 0));

	internal int CollectionNumber => _collectionNumber;

	internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "FontResolverInfo: '{0}',{1}{2}", FaceName, MustSimulateBold ? " simulate Bold" : "", MustSimulateItalic ? " simulate Italic" : "");

	public FontResolverInfo(string faceName)
		: this(faceName, mustSimulateBold: false, mustSimulateItalic: false, 0)
	{
	}

	internal FontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic, int collectionNumber)
	{
		if (string.IsNullOrEmpty(faceName))
		{
			throw new ArgumentNullException("faceName");
		}
		if (collectionNumber != 0)
		{
			throw new NotImplementedException("collectionNumber is not yet implemented and must be 0.");
		}
		_faceName = faceName;
		_mustSimulateBold = mustSimulateBold;
		_mustSimulateItalic = mustSimulateItalic;
		_collectionNumber = collectionNumber;
	}

	public FontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic)
		: this(faceName, mustSimulateBold, mustSimulateItalic, 0)
	{
	}

	public FontResolverInfo(string faceName, XStyleSimulations styleSimulations)
		: this(faceName, (styleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation, (styleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation, 0)
	{
	}
}
