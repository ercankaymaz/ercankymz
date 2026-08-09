using System.Globalization;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfExtGState : PdfDictionary
{
	internal sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string LW = "/LW";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string LC = "/LC";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string LJ = "/LJ";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string ML = "/ML";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string D = "/D";

		[KeyInfo(KeyType.Name | KeyType.Optional)]
		public const string RI = "/RI";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string OP = "/OP";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string op = "/op";

		[KeyInfo(KeyType.Integer | KeyType.Optional)]
		public const string OPM = "/OPM";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Font = "/Font";

		[KeyInfo(KeyType.Function | KeyType.Optional)]
		public const string BG = "/BG";

		[KeyInfo(KeyType.FunctionOrName | KeyType.Optional)]
		public const string BG2 = "/BG2";

		[KeyInfo(KeyType.Function | KeyType.Optional)]
		public const string UCR = "/UCR";

		[KeyInfo(KeyType.FunctionOrName | KeyType.Optional)]
		public const string UCR2 = "/UCR2";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string SA = "/SA";

		[KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
		public const string BM = "/BM";

		[KeyInfo(KeyType.NameOrDictionary | KeyType.Optional)]
		public const string SMask = "/SMask";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string CA = "/CA";

		[KeyInfo(KeyType.Real | KeyType.Optional)]
		public const string ca = "/ca";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string AIS = "/AIS";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string TK = "/TK";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private double _strokeAlpha;

	private double _nonStrokeAlpha;

	private bool _strokeOverprint;

	private bool _nonStrokeOverprint;

	private string _key;

	public double StrokeAlpha
	{
		set
		{
			_strokeAlpha = value;
			base.Elements.SetReal("/CA", value);
			UpdateKey();
		}
	}

	public double NonStrokeAlpha
	{
		set
		{
			_nonStrokeAlpha = value;
			base.Elements.SetReal("/ca", value);
			UpdateKey();
		}
	}

	public bool StrokeOverprint
	{
		set
		{
			_strokeOverprint = value;
			base.Elements.SetBoolean("/OP", value);
			UpdateKey();
		}
	}

	public bool NonStrokeOverprint
	{
		set
		{
			_nonStrokeOverprint = value;
			base.Elements.SetBoolean("/op", value);
			UpdateKey();
		}
	}

	public PdfSoftMask SoftMask
	{
		set
		{
			base.Elements.SetReference("/SMask", value);
		}
	}

	internal string Key => _key;

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfExtGState(PdfDocument document)
		: base(document)
	{
		base.Elements.SetName("/Type", "/ExtGState");
	}

	internal void SetDefault1()
	{
		base.Elements.SetBoolean("/AIS", value: false);
		if (base.Elements.ContainsKey("/BM"))
		{
			base.Elements.SetName("/BM", "/Normal");
		}
		StrokeAlpha = 1.0;
		NonStrokeAlpha = 1.0;
		base.Elements.SetBoolean("/op", value: false);
		base.Elements.SetBoolean("/OP", value: false);
		base.Elements.SetBoolean("/SA", value: true);
		base.Elements.SetName("/SMask", "/None");
	}

	internal void SetDefault2()
	{
		base.Elements.SetBoolean("/AIS", value: false);
		base.Elements.SetName("/BM", "/Normal");
		StrokeAlpha = 1.0;
		NonStrokeAlpha = 1.0;
		base.Elements.SetBoolean("/op", value: true);
		base.Elements.SetBoolean("/OP", value: true);
		base.Elements.SetInteger("/OPM", 1);
		base.Elements.SetBoolean("/SA", value: true);
		base.Elements.SetName("/SMask", "/None");
	}

	private void UpdateKey()
	{
		_key = ((int)(1000.0 * _strokeAlpha)).ToString(CultureInfo.InvariantCulture) + ((int)(1000.0 * _nonStrokeAlpha)).ToString(CultureInfo.InvariantCulture) + (_strokeOverprint ? "S" : "s") + (_nonStrokeOverprint ? "N" : "n");
	}

	internal static string MakeKey(double alpha, bool overPaint)
	{
		return ((int)(1000.0 * alpha)).ToString(CultureInfo.InvariantCulture) + (overPaint ? "O" : "0");
	}
}
