#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects;

public static class OpCodes
{
	private static readonly Dictionary<string, OpCode> StringToOpCode;

	private static readonly OpCode Dictionary;

	private static readonly OpCode b;

	private static readonly OpCode B;

	private static readonly OpCode bx;

	private static readonly OpCode Bx;

	private static readonly OpCode BDC;

	private static readonly OpCode BI;

	private static readonly OpCode BMC;

	private static readonly OpCode BT;

	private static readonly OpCode BX;

	private static readonly OpCode c;

	private static readonly OpCode cm;

	private static readonly OpCode CS;

	private static readonly OpCode cs;

	private static readonly OpCode d;

	private static readonly OpCode d0;

	private static readonly OpCode d1;

	private static readonly OpCode Do;

	private static readonly OpCode DP;

	private static readonly OpCode EI;

	private static readonly OpCode EMC;

	private static readonly OpCode ET;

	private static readonly OpCode EX;

	private static readonly OpCode f;

	private static readonly OpCode F;

	private static readonly OpCode fx;

	private static readonly OpCode G;

	private static readonly OpCode g;

	private static readonly OpCode gs;

	private static readonly OpCode h;

	private static readonly OpCode i;

	private static readonly OpCode ID;

	private static readonly OpCode j;

	private static readonly OpCode J;

	private static readonly OpCode K;

	private static readonly OpCode k;

	private static readonly OpCode l;

	private static readonly OpCode m;

	private static readonly OpCode M;

	private static readonly OpCode MP;

	private static readonly OpCode n;

	private static readonly OpCode q;

	private static readonly OpCode Q;

	private static readonly OpCode re;

	private static readonly OpCode RG;

	private static readonly OpCode rg;

	private static readonly OpCode ri;

	private static readonly OpCode s;

	private static readonly OpCode S;

	private static readonly OpCode SC;

	private static readonly OpCode sc;

	private static readonly OpCode SCN;

	private static readonly OpCode scn;

	private static readonly OpCode sh;

	private static readonly OpCode Tx;

	private static readonly OpCode Tc;

	private static readonly OpCode Td;

	private static readonly OpCode TD;

	private static readonly OpCode Tf;

	private static readonly OpCode Tj;

	private static readonly OpCode TJ;

	private static readonly OpCode TL;

	private static readonly OpCode Tm;

	private static readonly OpCode Tr;

	private static readonly OpCode Ts;

	private static readonly OpCode Tw;

	private static readonly OpCode Tz;

	private static readonly OpCode v;

	private static readonly OpCode w;

	private static readonly OpCode W;

	private static readonly OpCode Wx;

	private static readonly OpCode y;

	private static readonly OpCode QuoteSingle;

	private static readonly OpCode QuoteDbl;

	private static readonly OpCode[] ops;

	public static COperator OperatorFromName(string name)
	{
		COperator result = null;
		OpCode opCode = StringToOpCode[name];
		if (opCode != null)
		{
			result = new COperator(opCode);
		}
		else
		{
			Debug.Assert(condition: false, "Unknown operator in PDF content stream.");
		}
		return result;
	}

	static OpCodes()
	{
		Dictionary = new OpCode("Dictionary", OpCodeName.Dictionary, -1, "name, dictionary", OpCodeFlags.None, "E.g.: /Name << ... >>");
		b = new OpCode("b", OpCodeName.b, 0, "closepath, fill, stroke", OpCodeFlags.None, "Close, fill, and stroke path using nonzero winding number");
		B = new OpCode("B", OpCodeName.B, 0, "fill, stroke", OpCodeFlags.None, "Fill and stroke path using nonzero winding number rule");
		bx = new OpCode("b*", OpCodeName.bx, 0, "closepath, eofill, stroke", OpCodeFlags.None, "Close, fill, and stroke path using even-odd rule");
		Bx = new OpCode("B*", OpCodeName.Bx, 0, "eofill, stroke", OpCodeFlags.None, "Fill and stroke path using even-odd rule");
		BDC = new OpCode("BDC", OpCodeName.BDC, -1, null, OpCodeFlags.None, "(PDF 1.2) Begin marked-content sequence with property list");
		BI = new OpCode("BI", OpCodeName.BI, 0, null, OpCodeFlags.None, "Begin inline image object");
		BMC = new OpCode("BMC", OpCodeName.BMC, 1, null, OpCodeFlags.None, "(PDF 1.2) Begin marked-content sequence");
		BT = new OpCode("BT", OpCodeName.BT, 0, null, OpCodeFlags.None, "Begin text object");
		BX = new OpCode("BX", OpCodeName.BX, 0, null, OpCodeFlags.None, "(PDF 1.1) Begin compatibility section");
		c = new OpCode("c", OpCodeName.c, 6, "curveto", OpCodeFlags.None, "Append curved segment to path (three control points)");
		cm = new OpCode("cm", OpCodeName.cm, 6, "concat", OpCodeFlags.None, "Concatenate matrix to current transformation matrix");
		CS = new OpCode("CS", OpCodeName.CS, 1, "setcolorspace", OpCodeFlags.None, "(PDF 1.1) Set color space for stroking operations");
		cs = new OpCode("cs", OpCodeName.cs, 1, "setcolorspace", OpCodeFlags.None, "(PDF 1.1) Set color space for nonstroking operations");
		d = new OpCode("d", OpCodeName.d, 2, "setdash", OpCodeFlags.None, "Set line dash pattern");
		d0 = new OpCode("d0", OpCodeName.d0, 2, "setcharwidth", OpCodeFlags.None, "Set glyph width in Type 3 font");
		d1 = new OpCode("d1", OpCodeName.d1, 6, "setcachedevice", OpCodeFlags.None, "Set glyph width and bounding box in Type 3 font");
		Do = new OpCode("Do", OpCodeName.Do, 1, null, OpCodeFlags.None, "Invoke named XObject");
		DP = new OpCode("DP", OpCodeName.DP, 2, null, OpCodeFlags.None, "(PDF 1.2) Define marked-content point with property list");
		EI = new OpCode("EI", OpCodeName.EI, 0, null, OpCodeFlags.None, "End inline image object");
		EMC = new OpCode("EMC", OpCodeName.EMC, 0, null, OpCodeFlags.None, "(PDF 1.2) End marked-content sequence");
		ET = new OpCode("ET", OpCodeName.ET, 0, null, OpCodeFlags.None, "End text object");
		EX = new OpCode("EX", OpCodeName.EX, 0, null, OpCodeFlags.None, "(PDF 1.1) End compatibility section");
		f = new OpCode("f", OpCodeName.f, 0, "fill", OpCodeFlags.None, "Fill path using nonzero winding number rule");
		F = new OpCode("F", OpCodeName.F, 0, "fill", OpCodeFlags.None, "Fill path using nonzero winding number rule (obsolete)");
		fx = new OpCode("f*", OpCodeName.fx, 0, "eofill", OpCodeFlags.None, "Fill path using even-odd rule");
		G = new OpCode("G", OpCodeName.G, 1, "setgray", OpCodeFlags.None, "Set gray level for stroking operations");
		g = new OpCode("g", OpCodeName.g, 1, "setgray", OpCodeFlags.None, "Set gray level for nonstroking operations");
		gs = new OpCode("gs", OpCodeName.gs, 1, null, OpCodeFlags.None, "(PDF 1.2) Set parameters from graphics state parameter dictionary");
		h = new OpCode("h", OpCodeName.h, 0, "closepath", OpCodeFlags.None, "Close subpath");
		OpCodes.i = new OpCode("i", OpCodeName.i, 1, "setflat", OpCodeFlags.None, "Set flatness tolerance");
		ID = new OpCode("ID", OpCodeName.ID, 0, null, OpCodeFlags.None, "Begin inline image data");
		j = new OpCode("j", OpCodeName.j, 1, "setlinejoin", OpCodeFlags.None, "Set line join style");
		J = new OpCode("J", OpCodeName.J, 1, "setlinecap", OpCodeFlags.None, "Set line cap style");
		K = new OpCode("K", OpCodeName.K, 4, "setcmykcolor", OpCodeFlags.None, "Set CMYK color for stroking operations");
		k = new OpCode("k", OpCodeName.k, 4, "setcmykcolor", OpCodeFlags.None, "Set CMYK color for nonstroking operations");
		l = new OpCode("l", OpCodeName.l, 2, "lineto", OpCodeFlags.None, "Append straight line segment to path");
		m = new OpCode("m", OpCodeName.m, 2, "moveto", OpCodeFlags.None, "Begin new subpath");
		M = new OpCode("M", OpCodeName.M, 1, "setmiterlimit", OpCodeFlags.None, "Set miter limit");
		MP = new OpCode("MP", OpCodeName.MP, 1, null, OpCodeFlags.None, "(PDF 1.2) Define marked-content point");
		n = new OpCode("n", OpCodeName.n, 0, null, OpCodeFlags.None, "End path without filling or stroking");
		q = new OpCode("q", OpCodeName.q, 0, "gsave", OpCodeFlags.None, "Save graphics state");
		Q = new OpCode("Q", OpCodeName.Q, 0, "grestore", OpCodeFlags.None, "Restore graphics state");
		re = new OpCode("re", OpCodeName.re, 4, null, OpCodeFlags.None, "Append rectangle to path");
		RG = new OpCode("RG", OpCodeName.RG, 3, "setrgbcolor", OpCodeFlags.None, "Set RGB color for stroking operations");
		rg = new OpCode("rg", OpCodeName.rg, 3, "setrgbcolor", OpCodeFlags.None, "Set RGB color for nonstroking operations");
		ri = new OpCode("ri", OpCodeName.ri, 1, null, OpCodeFlags.None, "Set color rendering intent");
		s = new OpCode("s", OpCodeName.s, 0, "closepath,stroke", OpCodeFlags.None, "Close and stroke path");
		S = new OpCode("S", OpCodeName.S, 0, "stroke", OpCodeFlags.None, "Stroke path");
		SC = new OpCode("SC", OpCodeName.SC, -1, "setcolor", OpCodeFlags.None, "(PDF 1.1) Set color for stroking operations");
		sc = new OpCode("sc", OpCodeName.sc, -1, "setcolor", OpCodeFlags.None, "(PDF 1.1) Set color for nonstroking operations");
		SCN = new OpCode("SCN", OpCodeName.SCN, -1, "setcolor", OpCodeFlags.None, "(PDF 1.2) Set color for stroking operations (ICCBased and special color spaces)");
		scn = new OpCode("scn", OpCodeName.scn, -1, "setcolor", OpCodeFlags.None, "(PDF 1.2) Set color for nonstroking operations (ICCBased and special color spaces)");
		sh = new OpCode("sh", OpCodeName.sh, 1, "shfill", OpCodeFlags.None, "(PDF 1.3) Paint area defined by shading pattern");
		Tx = new OpCode("T*", OpCodeName.Tx, 0, null, OpCodeFlags.None, "Move to start of next text line");
		Tc = new OpCode("Tc", OpCodeName.Tc, 1, null, OpCodeFlags.None, "Set character spacing");
		Td = new OpCode("Td", OpCodeName.Td, 2, null, OpCodeFlags.None, "Move text position");
		TD = new OpCode("TD", OpCodeName.TD, 2, null, OpCodeFlags.None, "Move text position and set leading");
		Tf = new OpCode("Tf", OpCodeName.Tf, 2, "selectfont", OpCodeFlags.None, "Set text font and size");
		Tj = new OpCode("Tj", OpCodeName.Tj, 1, "show", OpCodeFlags.TextOut, "Show text");
		TJ = new OpCode("TJ", OpCodeName.TJ, 1, null, OpCodeFlags.TextOut, "Show text, allowing individual glyph positioning");
		TL = new OpCode("TL", OpCodeName.TL, 1, null, OpCodeFlags.None, "Set text leading");
		Tm = new OpCode("Tm", OpCodeName.Tm, 6, null, OpCodeFlags.None, "Set text matrix and text line matrix");
		Tr = new OpCode("Tr", OpCodeName.Tr, 1, null, OpCodeFlags.None, "Set text rendering mode");
		Ts = new OpCode("Ts", OpCodeName.Ts, 1, null, OpCodeFlags.None, "Set text rise");
		Tw = new OpCode("Tw", OpCodeName.Tw, 1, null, OpCodeFlags.None, "Set word spacing");
		Tz = new OpCode("Tz", OpCodeName.Tz, 1, null, OpCodeFlags.None, "Set horizontal text scaling");
		v = new OpCode("v", OpCodeName.v, 4, "curveto", OpCodeFlags.None, "Append curved segment to path (initial point replicated)");
		w = new OpCode("w", OpCodeName.w, 1, "setlinewidth", OpCodeFlags.None, "Set line width");
		W = new OpCode("W", OpCodeName.W, 0, "clip", OpCodeFlags.None, "Set clipping path using nonzero winding number rule");
		Wx = new OpCode("W*", OpCodeName.Wx, 0, "eoclip", OpCodeFlags.None, "Set clipping path using even-odd rule");
		y = new OpCode("y", OpCodeName.y, 4, "curveto", OpCodeFlags.None, "Append curved segment to path (final point replicated)");
		QuoteSingle = new OpCode("'", OpCodeName.QuoteSingle, 1, null, OpCodeFlags.TextOut, "Move to next line and show text");
		QuoteDbl = new OpCode("\"", OpCodeName.QuoteDbl, 3, null, OpCodeFlags.TextOut, "Set word and character spacing, move to next line, and show text");
		ops = new OpCode[74]
		{
			Dictionary,
			b,
			B,
			bx,
			Bx,
			BDC,
			BI,
			BMC,
			BT,
			BX,
			c,
			cm,
			CS,
			cs,
			d,
			d0,
			d1,
			Do,
			DP,
			EI,
			EMC,
			ET,
			EX,
			f,
			F,
			fx,
			G,
			g,
			gs,
			h,
			OpCodes.i,
			ID,
			j,
			J,
			K,
			k,
			l,
			m,
			M,
			MP,
			n,
			q,
			Q,
			re,
			RG,
			rg,
			ri,
			s,
			S,
			SC,
			sc,
			SCN,
			scn,
			sh,
			Tx,
			Tc,
			Td,
			TD,
			Tf,
			Tj,
			TJ,
			TL,
			Tm,
			Tr,
			Ts,
			Tw,
			Tz,
			v,
			w,
			W,
			Wx,
			y,
			QuoteSingle,
			QuoteDbl
		};
		StringToOpCode = new Dictionary<string, OpCode>();
		for (int i = 0; i < ops.Length; i++)
		{
			OpCode opCode = ops[i];
			StringToOpCode.Add(opCode.Name, opCode);
		}
	}
}
