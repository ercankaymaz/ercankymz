// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.OpCodes
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

public static class OpCodes
{
  private static readonly System.Collections.Generic.Dictionary<string, OpCode> StringToOpCode;
  private static readonly OpCode Dictionary = new OpCode(nameof (Dictionary), OpCodeName.Dictionary, -1, "name, dictionary", OpCodeFlags.None, "E.g.: /Name << ... >>");
  private static readonly OpCode b = new OpCode(nameof (b), OpCodeName.b, 0, "closepath, fill, stroke", OpCodeFlags.None, "Close, fill, and stroke path using nonzero winding number");
  private static readonly OpCode B = new OpCode(nameof (B), OpCodeName.B, 0, "fill, stroke", OpCodeFlags.None, "Fill and stroke path using nonzero winding number rule");
  private static readonly OpCode bx = new OpCode("b*", OpCodeName.bx, 0, "closepath, eofill, stroke", OpCodeFlags.None, "Close, fill, and stroke path using even-odd rule");
  private static readonly OpCode Bx = new OpCode("B*", OpCodeName.Bx, 0, "eofill, stroke", OpCodeFlags.None, "Fill and stroke path using even-odd rule");
  private static readonly OpCode BDC = new OpCode(nameof (BDC), OpCodeName.BDC, -1, (string) null, OpCodeFlags.None, "(PDF 1.2) Begin marked-content sequence with property list");
  private static readonly OpCode BI = new OpCode(nameof (BI), OpCodeName.BI, 0, (string) null, OpCodeFlags.None, "Begin inline image object");
  private static readonly OpCode BMC = new OpCode(nameof (BMC), OpCodeName.BMC, 1, (string) null, OpCodeFlags.None, "(PDF 1.2) Begin marked-content sequence");
  private static readonly OpCode BT = new OpCode(nameof (BT), OpCodeName.BT, 0, (string) null, OpCodeFlags.None, "Begin text object");
  private static readonly OpCode BX = new OpCode(nameof (BX), OpCodeName.BX, 0, (string) null, OpCodeFlags.None, "(PDF 1.1) Begin compatibility section");
  private static readonly OpCode c = new OpCode(nameof (c), OpCodeName.c, 6, "curveto", OpCodeFlags.None, "Append curved segment to path (three control points)");
  private static readonly OpCode cm = new OpCode(nameof (cm), OpCodeName.cm, 6, "concat", OpCodeFlags.None, "Concatenate matrix to current transformation matrix");
  private static readonly OpCode CS = new OpCode(nameof (CS), OpCodeName.CS, 1, "setcolorspace", OpCodeFlags.None, "(PDF 1.1) Set color space for stroking operations");
  private static readonly OpCode cs = new OpCode(nameof (cs), OpCodeName.cs, 1, "setcolorspace", OpCodeFlags.None, "(PDF 1.1) Set color space for nonstroking operations");
  private static readonly OpCode d = new OpCode(nameof (d), OpCodeName.d, 2, "setdash", OpCodeFlags.None, "Set line dash pattern");
  private static readonly OpCode d0 = new OpCode(nameof (d0), OpCodeName.d0, 2, "setcharwidth", OpCodeFlags.None, "Set glyph width in Type 3 font");
  private static readonly OpCode d1 = new OpCode(nameof (d1), OpCodeName.d1, 6, "setcachedevice", OpCodeFlags.None, "Set glyph width and bounding box in Type 3 font");
  private static readonly OpCode Do = new OpCode(nameof (Do), OpCodeName.Do, 1, (string) null, OpCodeFlags.None, "Invoke named XObject");
  private static readonly OpCode DP = new OpCode(nameof (DP), OpCodeName.DP, 2, (string) null, OpCodeFlags.None, "(PDF 1.2) Define marked-content point with property list");
  private static readonly OpCode EI = new OpCode(nameof (EI), OpCodeName.EI, 0, (string) null, OpCodeFlags.None, "End inline image object");
  private static readonly OpCode EMC = new OpCode(nameof (EMC), OpCodeName.EMC, 0, (string) null, OpCodeFlags.None, "(PDF 1.2) End marked-content sequence");
  private static readonly OpCode ET = new OpCode(nameof (ET), OpCodeName.ET, 0, (string) null, OpCodeFlags.None, "End text object");
  private static readonly OpCode EX = new OpCode(nameof (EX), OpCodeName.EX, 0, (string) null, OpCodeFlags.None, "(PDF 1.1) End compatibility section");
  private static readonly OpCode f = new OpCode(nameof (f), OpCodeName.f, 0, "fill", OpCodeFlags.None, "Fill path using nonzero winding number rule");
  private static readonly OpCode F = new OpCode(nameof (F), OpCodeName.F, 0, "fill", OpCodeFlags.None, "Fill path using nonzero winding number rule (obsolete)");
  private static readonly OpCode fx = new OpCode("f*", OpCodeName.fx, 0, "eofill", OpCodeFlags.None, "Fill path using even-odd rule");
  private static readonly OpCode G = new OpCode(nameof (G), OpCodeName.G, 1, "setgray", OpCodeFlags.None, "Set gray level for stroking operations");
  private static readonly OpCode g = new OpCode(nameof (g), OpCodeName.g, 1, "setgray", OpCodeFlags.None, "Set gray level for nonstroking operations");
  private static readonly OpCode gs = new OpCode(nameof (gs), OpCodeName.gs, 1, (string) null, OpCodeFlags.None, "(PDF 1.2) Set parameters from graphics state parameter dictionary");
  private static readonly OpCode h = new OpCode(nameof (h), OpCodeName.h, 0, "closepath", OpCodeFlags.None, "Close subpath");
  private static readonly OpCode i = new OpCode(nameof (i), OpCodeName.i, 1, "setflat", OpCodeFlags.None, "Set flatness tolerance");
  private static readonly OpCode ID = new OpCode(nameof (ID), OpCodeName.ID, 0, (string) null, OpCodeFlags.None, "Begin inline image data");
  private static readonly OpCode j = new OpCode(nameof (j), OpCodeName.j, 1, "setlinejoin", OpCodeFlags.None, "Set line join style");
  private static readonly OpCode J = new OpCode(nameof (J), OpCodeName.J, 1, "setlinecap", OpCodeFlags.None, "Set line cap style");
  private static readonly OpCode K = new OpCode(nameof (K), OpCodeName.K, 4, "setcmykcolor", OpCodeFlags.None, "Set CMYK color for stroking operations");
  private static readonly OpCode k = new OpCode(nameof (k), OpCodeName.k, 4, "setcmykcolor", OpCodeFlags.None, "Set CMYK color for nonstroking operations");
  private static readonly OpCode l = new OpCode(nameof (l), OpCodeName.l, 2, "lineto", OpCodeFlags.None, "Append straight line segment to path");
  private static readonly OpCode m = new OpCode(nameof (m), OpCodeName.m, 2, "moveto", OpCodeFlags.None, "Begin new subpath");
  private static readonly OpCode M = new OpCode(nameof (M), OpCodeName.M, 1, "setmiterlimit", OpCodeFlags.None, "Set miter limit");
  private static readonly OpCode MP = new OpCode(nameof (MP), OpCodeName.MP, 1, (string) null, OpCodeFlags.None, "(PDF 1.2) Define marked-content point");
  private static readonly OpCode n = new OpCode(nameof (n), OpCodeName.n, 0, (string) null, OpCodeFlags.None, "End path without filling or stroking");
  private static readonly OpCode q = new OpCode(nameof (q), OpCodeName.q, 0, "gsave", OpCodeFlags.None, "Save graphics state");
  private static readonly OpCode Q = new OpCode(nameof (Q), OpCodeName.Q, 0, "grestore", OpCodeFlags.None, "Restore graphics state");
  private static readonly OpCode re = new OpCode(nameof (re), OpCodeName.re, 4, (string) null, OpCodeFlags.None, "Append rectangle to path");
  private static readonly OpCode RG = new OpCode(nameof (RG), OpCodeName.RG, 3, "setrgbcolor", OpCodeFlags.None, "Set RGB color for stroking operations");
  private static readonly OpCode rg = new OpCode(nameof (rg), OpCodeName.rg, 3, "setrgbcolor", OpCodeFlags.None, "Set RGB color for nonstroking operations");
  private static readonly OpCode ri = new OpCode(nameof (ri), OpCodeName.ri, 1, (string) null, OpCodeFlags.None, "Set color rendering intent");
  private static readonly OpCode s = new OpCode(nameof (s), OpCodeName.s, 0, "closepath,stroke", OpCodeFlags.None, "Close and stroke path");
  private static readonly OpCode S = new OpCode(nameof (S), OpCodeName.S, 0, "stroke", OpCodeFlags.None, "Stroke path");
  private static readonly OpCode SC = new OpCode(nameof (SC), OpCodeName.SC, -1, "setcolor", OpCodeFlags.None, "(PDF 1.1) Set color for stroking operations");
  private static readonly OpCode sc = new OpCode(nameof (sc), OpCodeName.sc, -1, "setcolor", OpCodeFlags.None, "(PDF 1.1) Set color for nonstroking operations");
  private static readonly OpCode SCN = new OpCode(nameof (SCN), OpCodeName.SCN, -1, "setcolor", OpCodeFlags.None, "(PDF 1.2) Set color for stroking operations (ICCBased and special color spaces)");
  private static readonly OpCode scn = new OpCode(nameof (scn), OpCodeName.scn, -1, "setcolor", OpCodeFlags.None, "(PDF 1.2) Set color for nonstroking operations (ICCBased and special color spaces)");
  private static readonly OpCode sh = new OpCode(nameof (sh), OpCodeName.sh, 1, "shfill", OpCodeFlags.None, "(PDF 1.3) Paint area defined by shading pattern");
  private static readonly OpCode Tx = new OpCode("T*", OpCodeName.Tx, 0, (string) null, OpCodeFlags.None, "Move to start of next text line");
  private static readonly OpCode Tc = new OpCode(nameof (Tc), OpCodeName.Tc, 1, (string) null, OpCodeFlags.None, "Set character spacing");
  private static readonly OpCode Td = new OpCode(nameof (Td), OpCodeName.Td, 2, (string) null, OpCodeFlags.None, "Move text position");
  private static readonly OpCode TD = new OpCode(nameof (TD), OpCodeName.TD, 2, (string) null, OpCodeFlags.None, "Move text position and set leading");
  private static readonly OpCode Tf = new OpCode(nameof (Tf), OpCodeName.Tf, 2, "selectfont", OpCodeFlags.None, "Set text font and size");
  private static readonly OpCode Tj = new OpCode(nameof (Tj), OpCodeName.Tj, 1, "show", OpCodeFlags.TextOut, "Show text");
  private static readonly OpCode TJ = new OpCode(nameof (TJ), OpCodeName.TJ, 1, (string) null, OpCodeFlags.TextOut, "Show text, allowing individual glyph positioning");
  private static readonly OpCode TL = new OpCode(nameof (TL), OpCodeName.TL, 1, (string) null, OpCodeFlags.None, "Set text leading");
  private static readonly OpCode Tm = new OpCode(nameof (Tm), OpCodeName.Tm, 6, (string) null, OpCodeFlags.None, "Set text matrix and text line matrix");
  private static readonly OpCode Tr = new OpCode(nameof (Tr), OpCodeName.Tr, 1, (string) null, OpCodeFlags.None, "Set text rendering mode");
  private static readonly OpCode Ts = new OpCode(nameof (Ts), OpCodeName.Ts, 1, (string) null, OpCodeFlags.None, "Set text rise");
  private static readonly OpCode Tw = new OpCode(nameof (Tw), OpCodeName.Tw, 1, (string) null, OpCodeFlags.None, "Set word spacing");
  private static readonly OpCode Tz = new OpCode(nameof (Tz), OpCodeName.Tz, 1, (string) null, OpCodeFlags.None, "Set horizontal text scaling");
  private static readonly OpCode v = new OpCode(nameof (v), OpCodeName.v, 4, "curveto", OpCodeFlags.None, "Append curved segment to path (initial point replicated)");
  private static readonly OpCode w = new OpCode(nameof (w), OpCodeName.w, 1, "setlinewidth", OpCodeFlags.None, "Set line width");
  private static readonly OpCode W = new OpCode(nameof (W), OpCodeName.W, 0, "clip", OpCodeFlags.None, "Set clipping path using nonzero winding number rule");
  private static readonly OpCode Wx = new OpCode("W*", OpCodeName.Wx, 0, "eoclip", OpCodeFlags.None, "Set clipping path using even-odd rule");
  private static readonly OpCode y = new OpCode(nameof (y), OpCodeName.y, 4, "curveto", OpCodeFlags.None, "Append curved segment to path (final point replicated)");
  private static readonly OpCode QuoteSingle = new OpCode("'", OpCodeName.QuoteSingle, 1, (string) null, OpCodeFlags.TextOut, "Move to next line and show text");
  private static readonly OpCode QuoteDbl = new OpCode("\"", OpCodeName.QuoteDbl, 3, (string) null, OpCodeFlags.TextOut, "Set word and character spacing, move to next line, and show text");
  private static readonly OpCode[] ops = new OpCode[74]
  {
    OpCodes.Dictionary,
    OpCodes.b,
    OpCodes.B,
    OpCodes.bx,
    OpCodes.Bx,
    OpCodes.BDC,
    OpCodes.BI,
    OpCodes.BMC,
    OpCodes.BT,
    OpCodes.BX,
    OpCodes.c,
    OpCodes.cm,
    OpCodes.CS,
    OpCodes.cs,
    OpCodes.d,
    OpCodes.d0,
    OpCodes.d1,
    OpCodes.Do,
    OpCodes.DP,
    OpCodes.EI,
    OpCodes.EMC,
    OpCodes.ET,
    OpCodes.EX,
    OpCodes.f,
    OpCodes.F,
    OpCodes.fx,
    OpCodes.G,
    OpCodes.g,
    OpCodes.gs,
    OpCodes.h,
    OpCodes.i,
    OpCodes.ID,
    OpCodes.j,
    OpCodes.J,
    OpCodes.K,
    OpCodes.k,
    OpCodes.l,
    OpCodes.m,
    OpCodes.M,
    OpCodes.MP,
    OpCodes.n,
    OpCodes.q,
    OpCodes.Q,
    OpCodes.re,
    OpCodes.RG,
    OpCodes.rg,
    OpCodes.ri,
    OpCodes.s,
    OpCodes.S,
    OpCodes.SC,
    OpCodes.sc,
    OpCodes.SCN,
    OpCodes.scn,
    OpCodes.sh,
    OpCodes.Tx,
    OpCodes.Tc,
    OpCodes.Td,
    OpCodes.TD,
    OpCodes.Tf,
    OpCodes.Tj,
    OpCodes.TJ,
    OpCodes.TL,
    OpCodes.Tm,
    OpCodes.Tr,
    OpCodes.Ts,
    OpCodes.Tw,
    OpCodes.Tz,
    OpCodes.v,
    OpCodes.w,
    OpCodes.W,
    OpCodes.Wx,
    OpCodes.y,
    OpCodes.QuoteSingle,
    OpCodes.QuoteDbl
  };

  public static COperator OperatorFromName(string name)
  {
    COperator coperator = (COperator) null;
    OpCode opcode = OpCodes.StringToOpCode[name];
    if (opcode != null)
      coperator = new COperator(opcode);
    else
      Debug.Assert(false, "Unknown operator in PDF content stream.");
    return coperator;
  }

  static OpCodes()
  {
    OpCodes.StringToOpCode = new System.Collections.Generic.Dictionary<string, OpCode>();
    for (int index = 0; index < OpCodes.ops.Length; ++index)
    {
      OpCode op = OpCodes.ops[index];
      OpCodes.StringToOpCode.Add(op.Name, op);
    }
  }
}
