// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.DataMatrixImage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

internal class DataMatrixImage
{
  private string _encoding;
  private readonly string _text;
  private readonly int _rows;
  private readonly int _columns;
  private static DataMatrixImage.Ecc200Block[] ecc200Sizes = new DataMatrixImage.Ecc200Block[31 /*0x1F*/]
  {
    new DataMatrixImage.Ecc200Block(10, 10, 10, 10, 3, 3, 5),
    new DataMatrixImage.Ecc200Block(12, 12, 12, 12, 5, 5, 7),
    new DataMatrixImage.Ecc200Block(8, 18, 8, 18, 5, 5, 7),
    new DataMatrixImage.Ecc200Block(14, 14, 14, 14, 8, 8, 10),
    new DataMatrixImage.Ecc200Block(8, 32 /*0x20*/, 8, 16 /*0x10*/, 10, 10, 11),
    new DataMatrixImage.Ecc200Block(16 /*0x10*/, 16 /*0x10*/, 16 /*0x10*/, 16 /*0x10*/, 12, 12, 12),
    new DataMatrixImage.Ecc200Block(12, 26, 12, 26, 16 /*0x10*/, 16 /*0x10*/, 14),
    new DataMatrixImage.Ecc200Block(18, 18, 18, 18, 18, 18, 14),
    new DataMatrixImage.Ecc200Block(20, 20, 20, 20, 22, 22, 18),
    new DataMatrixImage.Ecc200Block(12, 36, 12, 18, 22, 22, 18),
    new DataMatrixImage.Ecc200Block(22, 22, 22, 22, 30, 30, 20),
    new DataMatrixImage.Ecc200Block(16 /*0x10*/, 36, 16 /*0x10*/, 18, 32 /*0x20*/, 32 /*0x20*/, 24),
    new DataMatrixImage.Ecc200Block(24, 24, 24, 24, 36, 36, 24),
    new DataMatrixImage.Ecc200Block(26, 26, 26, 26, 44, 44, 28),
    new DataMatrixImage.Ecc200Block(16 /*0x10*/, 48 /*0x30*/, 16 /*0x10*/, 24, 49, 49, 28),
    new DataMatrixImage.Ecc200Block(32 /*0x20*/, 32 /*0x20*/, 16 /*0x10*/, 16 /*0x10*/, 62, 62, 36),
    new DataMatrixImage.Ecc200Block(36, 36, 18, 18, 86, 86, 42),
    new DataMatrixImage.Ecc200Block(40, 40, 20, 20, 114, 114, 48 /*0x30*/),
    new DataMatrixImage.Ecc200Block(44, 44, 22, 22, 144 /*0x90*/, 144 /*0x90*/, 56),
    new DataMatrixImage.Ecc200Block(48 /*0x30*/, 48 /*0x30*/, 24, 24, 174, 174, 68),
    new DataMatrixImage.Ecc200Block(52, 52, 26, 26, 204, 102, 42),
    new DataMatrixImage.Ecc200Block(64 /*0x40*/, 64 /*0x40*/, 16 /*0x10*/, 16 /*0x10*/, 280, 140, 56),
    new DataMatrixImage.Ecc200Block(72, 72, 18, 18, 368, 92, 36),
    new DataMatrixImage.Ecc200Block(80 /*0x50*/, 80 /*0x50*/, 20, 20, 456, 114, 48 /*0x30*/),
    new DataMatrixImage.Ecc200Block(88, 88, 22, 22, 576, 144 /*0x90*/, 56),
    new DataMatrixImage.Ecc200Block(96 /*0x60*/, 96 /*0x60*/, 24, 24, 696, 174, 68),
    new DataMatrixImage.Ecc200Block(104, 104, 26, 26, 816, 136, 56),
    new DataMatrixImage.Ecc200Block(120, 120, 20, 20, 1050, 175, 68),
    new DataMatrixImage.Ecc200Block(132, 132, 22, 22, 1304, 163, 62),
    new DataMatrixImage.Ecc200Block(144 /*0x90*/, 144 /*0x90*/, 24, 24, 1558, 156, 62),
    new DataMatrixImage.Ecc200Block(0, 0, 0, 0, 0, 0, 0)
  };
  private static int gfpoly;
  private static int symsize;
  private static int logmod;
  private static int rlen;
  private static int[] log = (int[]) null;
  private static int[] alog = (int[]) null;
  private static int[] rspoly = (int[]) null;

  public static XImage GenerateMatrixImage(string text, string encoding, int rows, int columns)
  {
    return new DataMatrixImage(text, encoding, rows, columns).DrawMatrix();
  }

  public DataMatrixImage(string text, string encoding, int rows, int columns)
  {
    this._text = text;
    this._encoding = encoding;
    this._rows = rows;
    this._columns = columns;
  }

  public XImage DrawMatrix() => this.CreateImage(this.DataMatrix(), this._rows, this._columns);

  internal char[] DataMatrix()
  {
    int columns = this._columns;
    int rows = this._rows;
    int num = 200;
    if (string.IsNullOrEmpty(this._encoding))
      this._encoding = new string('a', this._text.Length);
    int len = 0;
    int max = 0;
    int ecc = 0;
    if ((columns == 0 || rows == 0 || (columns & 1) == 0 || (rows & 1) == 0 ? 0 : (num == 200 ? 1 : 0)) != 0)
      throw new ArgumentException(BcgSR.DataMatrixNotSupported);
    char[] chArray = this.Iec16022Ecc200(columns, rows, this._encoding, this._text.Length, this._text, len, max, ecc);
    return (chArray == null ? 1 : (columns == 0 ? 1 : 0)) == 0 ? chArray : throw new ArgumentException(BcgSR.DataMatrixNull);
  }

  internal char[] Iec16022Ecc200(
    int columns,
    int rows,
    string encoding,
    int barcodeLength,
    string barcode,
    int len,
    int max,
    int ecc)
  {
    char[] t = new char[3000];
    DataMatrixImage.Ecc200Block ecc200Block = new DataMatrixImage.Ecc200Block(0, 0, 0, 0, 0, 0, 0);
    for (int index = 0; index < 3000; ++index)
      t[index] = char.MinValue;
    foreach (DataMatrixImage.Ecc200Block ecc200Siz in DataMatrixImage.ecc200Sizes)
    {
      ecc200Block = ecc200Siz;
      if ((ecc200Block.Width != columns ? 0 : (ecc200Block.Height == rows ? 1 : 0)) != 0)
        break;
    }
    if (ecc200Block.Width == 0)
      throw new ArgumentException(BcgSR.DataMatrixInvalid(columns, rows));
    if (!this.Ecc200Encode(ref t, ecc200Block.Bytes, barcode, barcodeLength, encoding, ref len))
      throw new ArgumentException(BcgSR.DataMatrixTooBig);
    this.Ecc200(t, ecc200Block.Bytes, ecc200Block.DataBlock, ecc200Block.RSBlock);
    int NC = columns - 2 * (columns / ecc200Block.CellWidth);
    int NR = rows - 2 * (rows / ecc200Block.CellHeight);
    int[] array = new int[NC * NR];
    this.Ecc200Placement(ref array, NR, NC);
    char[] chArray = new char[columns * rows];
    for (int index1 = 0; index1 < rows; index1 += ecc200Block.CellHeight)
    {
      for (int index2 = 0; index2 < columns; ++index2)
        chArray[index1 * columns + index2] = '\u0001';
      for (int index3 = 0; index3 < columns; index3 += 2)
        chArray[(index1 + ecc200Block.CellHeight - 1) * columns + index3] = '\u0001';
    }
    for (int index4 = 0; index4 < columns; index4 += ecc200Block.CellWidth)
    {
      for (int index5 = 0; index5 < rows; ++index5)
        chArray[index5 * columns + index4] = '\u0001';
      for (int index6 = 0; index6 < rows; index6 += 2)
        chArray[index6 * columns + index4 + ecc200Block.CellWidth - 1] = '\u0001';
    }
    for (int index7 = 0; index7 < NR; ++index7)
    {
      for (int index8 = 0; index8 < NC; ++index8)
      {
        int num = array[(NR - index7 - 1) * NC + index8];
        if ((num == 1 ? 1 : (num <= 7 ? 0 : (((uint) t[(num >> 3) - 1] & (uint) (1 << (num & 7))) > 0U ? 1 : 0))) != 0)
          chArray[(1 + index7 + 2 * (index7 / (ecc200Block.CellHeight - 2))) * columns + 1 + index8 + 2 * (index8 / (ecc200Block.CellWidth - 2))] = '\u0001';
      }
    }
    return chArray;
  }

  internal bool Ecc200Encode(
    ref char[] t,
    int targetLength,
    string s,
    int sourceLength,
    string encoding,
    ref int len)
  {
    char ch1 = 'a';
    int position1 = 0;
    int index1 = 0;
    bool flag;
    if (encoding.Length < sourceLength)
    {
      flag = false;
    }
    else
    {
      while ((index1 >= sourceLength ? 0 : (position1 < targetLength ? 1 : 0)) != 0)
      {
        if ((targetLength - position1 > 1 || ch1 != 'c' && ch1 != 't' ? (targetLength - position1 > 2 ? 0 : (ch1 == 'x' ? 1 : 0)) : 1) != 0)
          ch1 = 'a';
        char lower = char.ToLower(encoding[index1]);
        switch (lower)
        {
          case 'a':
            if ((int) ch1 != (int) lower)
            {
              int num = ch1 == 'c' || ch1 == 't' ? 1 : (ch1 == 'x' ? 1 : 0);
              t[position1++] = num == 0 ? '|' : 'þ';
            }
            ch1 = 'a';
            if ((sourceLength - index1 < 2 || !char.IsDigit(s[index1]) ? 0 : (char.IsDigit(s[index1 + 1]) ? 1 : 0)) != 0)
            {
              t[position1++] = (char) (((int) s[index1] - 48 /*0x30*/) * 10 + (int) s[index1 + 1] - 48 /*0x30*/ + 130);
              index1 += 2;
              continue;
            }
            if (s[index1] > '\u007F')
            {
              char[] chArray1 = t;
              int index2 = position1;
              int num1 = index2 + 1;
              chArray1[index2] = 'ë';
              char[] chArray2 = t;
              int index3 = num1;
              position1 = index3 + 1;
              int num2 = (int) (ushort) ((uint) s[index1++] - (uint) sbyte.MaxValue);
              chArray2[index3] = (char) num2;
              continue;
            }
            t[position1++] = (char) ((uint) s[index1++] + 1U);
            continue;
          case 'b':
            int num3 = 0;
            if (encoding != null)
            {
              for (int index4 = index1; (index4 >= sourceLength ? 0 : (char.ToLower(encoding[index4]) == 'b' ? 1 : 0)) != 0; ++index4)
                ++num3;
            }
            char[] chArray3 = t;
            int index5 = position1;
            int position2 = index5 + 1;
            chArray3[index5] = 'ç';
            if (num3 < 250)
            {
              t[position2] = (char) this.State255(num3, position2);
              position1 = position2 + 1;
            }
            else
            {
              t[position2] = (char) this.State255(249 + num3 / 250, position2);
              int position3 = position2 + 1;
              t[position3] = (char) this.State255(num3 % 250, position3);
              position1 = position3 + 1;
            }
            for (; (num3-- == 0 ? 0 : (position1 < targetLength ? 1 : 0)) != 0; ++position1)
              t[position1] = (char) this.State255((int) s[index1++], position1);
            ch1 = 'a';
            continue;
          case 'c':
          case 't':
          case 'x':
            char[] chArray4 = new char[6];
            char ch2 = char.MinValue;
            string str1 = (string) null;
            string str2 = "!\"#$%&'()*+,-./:;<=>?@[\\]_";
            string str3 = (string) null;
            if (lower == 'c')
            {
              str1 = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
              str3 = "`abcdefghijklmnopqrstuvwxyz{|}~±";
            }
            if (lower == 't')
            {
              str1 = " 0123456789abcdefghijklmnopqrstuvwxyz";
              str3 = "`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~±";
            }
            if (lower == 'x')
              str1 = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ\r*>";
            do
            {
              char ch3 = s[index1++];
              if (((uint) ch3 & 128U /*0x80*/) > 0U)
                goto label_54;
label_28:
              char ch4 = str1.IndexOf(ch3) == -1 ? char.MinValue : str1[str1.IndexOf(ch3)];
              if (ch4 > char.MinValue)
                chArray4[(int) ch2++] = (char) ((str1.IndexOf(ch4) + 3) % 40);
              else if (lower != 'x')
              {
                if (ch3 < ' ')
                {
                  char[] chArray5 = chArray4;
                  int index6 = (int) ch2;
                  char ch5 = (char) (index6 + 1);
                  chArray5[index6] = char.MinValue;
                  char[] chArray6 = chArray4;
                  int index7 = (int) ch5;
                  ch2 = (char) (index7 + 1);
                  int num4 = (int) ch3;
                  chArray6[index7] = (char) num4;
                }
                else
                {
                  char ch6 = str2.IndexOf(ch3) == -1 ? char.MinValue : (char) str2.IndexOf(ch3);
                  if (ch6 > char.MinValue)
                  {
                    char[] chArray7 = chArray4;
                    int index8 = (int) ch2;
                    char ch7 = (char) (index8 + 1);
                    chArray7[index8] = '\u0001';
                    char[] chArray8 = chArray4;
                    int index9 = (int) ch7;
                    ch2 = (char) (index9 + 1);
                    int num5 = (int) ch6;
                    chArray8[index9] = (char) num5;
                  }
                  else
                  {
                    char ch8 = str3.IndexOf(ch3) == -1 ? char.MinValue : (char) str3.IndexOf(ch3);
                    if (ch8 > char.MinValue)
                    {
                      char[] chArray9 = chArray4;
                      int index10 = (int) ch2;
                      char ch9 = (char) (index10 + 1);
                      chArray9[index10] = '\u0002';
                      char[] chArray10 = chArray4;
                      int index11 = (int) ch9;
                      ch2 = (char) (index11 + 1);
                      int num6 = (int) ch8;
                      chArray10[index11] = (char) num6;
                    }
                    else
                      goto label_80;
                  }
                }
              }
              else
                goto label_79;
              if ((ch2 != '\u0002' || position1 + 2 != targetLength ? 0 : (index1 == sourceLength ? 1 : 0)) != 0)
                chArray4[(int) ch2++] = char.MinValue;
              while (ch2 >= '\u0003')
              {
                int num7 = (int) chArray4[0] * 1600 + (int) chArray4[1] * 40 + (int) chArray4[2] + 1;
                if ((int) ch1 != (int) lower)
                {
                  if ((ch1 == 'c' || ch1 == 't' ? 1 : (ch1 == 'x' ? 1 : 0)) != 0)
                    t[position1++] = 'þ';
                  else if (ch1 == 'x')
                    t[position1++] = '|';
                  if (lower == 'c')
                    t[position1++] = 'æ';
                  if (lower == 't')
                    t[position1++] = 'ï';
                  if (lower == 'x')
                    t[position1++] = 'î';
                  ch1 = lower;
                }
                char[] chArray11 = t;
                int index12 = position1;
                int num8 = index12 + 1;
                int num9 = (int) (ushort) (num7 >> 8);
                chArray11[index12] = (char) num9;
                char[] chArray12 = t;
                int index13 = num8;
                position1 = index13 + 1;
                int num10 = (int) (ushort) (num7 & (int) byte.MaxValue);
                chArray12[index13] = (char) num10;
                ch2 -= '\u0003';
                chArray4[0] = chArray4[3];
                chArray4[1] = chArray4[4];
                chArray4[2] = chArray4[5];
              }
              continue;
label_54:
              if (lower != 'x')
              {
                ch3 &= '\u007F';
                char[] chArray13 = chArray4;
                int index14 = (int) ch2;
                char ch10 = (char) (index14 + 1);
                chArray13[index14] = '\u0001';
                char[] chArray14 = chArray4;
                int index15 = (int) ch10;
                ch2 = (char) (index15 + 1);
                chArray14[index15] = '\u001E';
                goto label_28;
              }
              goto label_78;
            }
            while ((ch2 == char.MinValue ? 0 : (index1 < sourceLength ? 1 : 0)) != 0);
            continue;
label_78:
            flag = false;
            goto label_81;
label_79:
            flag = false;
            goto label_81;
label_80:
            flag = false;
            goto label_81;
          case 'e':
            char[] chArray15 = new char[4];
            char minValue = char.MinValue;
            if ((int) ch1 != (int) lower)
            {
              t[position1++] = 'þ';
              ch1 = 'a';
            }
            while ((index1 >= sourceLength || char.ToLower(encoding[index1]) != 'e' ? 0 : (minValue < '\u0004' ? 1 : 0)) != 0)
              chArray15[(int) minValue++] = s[index1++];
            if (minValue < '\u0004')
            {
              chArray15[(int) minValue++] = '\u001F';
              ch1 = 'a';
            }
            t[position1] = (char) (((int) s[0] & 63 /*0x3F*/) << 2);
            char[] chArray16 = t;
            int index16 = position1;
            int index17 = index16 + 1;
            chArray16[index16] |= (char) (((int) s[1] & 48 /*0x30*/) >> 4);
            t[index17] = (char) (((int) s[1] & 15) << 4);
            if (minValue == '\u0002')
            {
              position1 = index17 + 1;
              continue;
            }
            char[] chArray17 = t;
            int index18 = index17;
            int index19 = index18 + 1;
            chArray17[index18] |= (char) (((int) s[2] & 60) >> 2);
            t[index19] = (char) (((int) s[2] & 3) << 6);
            char[] chArray18 = t;
            int index20 = index19;
            position1 = index20 + 1;
            chArray18[index20] |= (char) ((uint) s[3] & 63U /*0x3F*/);
            continue;
          default:
            continue;
        }
      }
      if (len != 0)
        len = position1;
      if ((position1 >= targetLength ? 0 : (ch1 != 'a' ? 1 : 0)) != 0)
      {
        int num = ch1 == 'c' || ch1 == 'x' ? 1 : (ch1 == 't' ? 1 : 0);
        t[position1++] = num == 0 ? '|' : 'þ';
      }
      if (position1 < targetLength)
        t[position1++] = '\u0081';
      int num11;
      for (; position1 < targetLength; t[position1++] = (char) num11)
      {
        num11 = 129 + (position1 + 1) * 149 % 253 + 1;
        if (num11 > 254)
          num11 -= 254;
      }
      flag = (position1 > targetLength ? 1 : (index1 < sourceLength ? 1 : 0)) == 0;
    }
label_81:
    return flag;
  }

  private int State255(int value, int position)
  {
    return (value + (position + 1) * 149 % (int) byte.MaxValue + 1) % 256 /*0x0100*/;
  }

  private void Ecc200Placement(ref int[] array, int NR, int NC)
  {
    for (int index1 = 0; index1 < NR; ++index1)
    {
      for (int index2 = 0; index2 < NC; ++index2)
        array[index1 * NC + index2] = 0;
    }
    int num = 1;
    int r1 = 4;
    int c1 = 0;
    do
    {
      if ((r1 != NR ? 0 : (c1 == 0 ? 1 : 0)) != 0)
        this.Ecc200PlacementCornerA(ref array, NR, NC, num++);
      if ((r1 != NR - 2 || c1 != 0 ? 0 : (NC % 4 != 0 ? 1 : 0)) != 0)
        this.Ecc200PlacementCornerB(ref array, NR, NC, num++);
      if ((r1 != NR - 2 || c1 != 0 ? 0 : (NC % 8 == 4 ? 1 : 0)) != 0)
        this.Ecc200PlacementCornerC(ref array, NR, NC, num++);
      if ((r1 != NR + 4 || c1 != 2 ? 0 : (NC % 8 == 0 ? 1 : 0)) != 0)
        this.Ecc200PlacementCornerD(ref array, NR, NC, num++);
      do
      {
        if ((r1 >= NR || c1 < 0 ? 0 : (array[r1 * NC + c1] == 0 ? 1 : 0)) != 0)
          this.Ecc200PlacementBlock(ref array, NR, NC, r1, c1, num++);
        r1 -= 2;
        c1 += 2;
      }
      while ((r1 < 0 ? 0 : (c1 < NC ? 1 : 0)) != 0);
      int r2 = r1 + 1;
      int c2 = c1 + 3;
      do
      {
        if ((r2 < 0 || c2 >= NC ? 0 : (array[r2 * NC + c2] == 0 ? 1 : 0)) != 0)
          this.Ecc200PlacementBlock(ref array, NR, NC, r2, c2, num++);
        r2 += 2;
        c2 -= 2;
      }
      while ((r2 >= NR ? 0 : (c2 >= 0 ? 1 : 0)) != 0);
      r1 = r2 + 3;
      c1 = c2 + 1;
    }
    while ((r1 < NR ? 1 : (c1 < NC ? 1 : 0)) != 0);
    if (array[NR * NC - 1] != 0)
      return;
    int[] numArray = array;
    int index = NR * NC - 1;
    array[NR * NC - NC - 2] = 1;
    numArray[index] = 1;
  }

  private void Ecc200PlacementBit(ref int[] array, int NR, int NC, int r, int c, int p, int b)
  {
    if (r < 0)
    {
      r += NR;
      c += 4 - (NR + 4) % 8;
    }
    if (c < 0)
    {
      c += NC;
      r += 4 - (NC + 4) % 8;
    }
    array[r * NC + c] = (p << 3) + b;
  }

  private void Ecc200PlacementBlock(ref int[] array, int NR, int NC, int r, int c, int p)
  {
    this.Ecc200PlacementBit(ref array, NR, NC, r - 2, c - 2, p, 7);
    this.Ecc200PlacementBit(ref array, NR, NC, r - 2, c - 1, p, 6);
    this.Ecc200PlacementBit(ref array, NR, NC, r - 1, c - 2, p, 5);
    this.Ecc200PlacementBit(ref array, NR, NC, r - 1, c - 1, p, 4);
    this.Ecc200PlacementBit(ref array, NR, NC, r - 1, c, p, 3);
    this.Ecc200PlacementBit(ref array, NR, NC, r, c - 2, p, 2);
    this.Ecc200PlacementBit(ref array, NR, NC, r, c - 1, p, 1);
    this.Ecc200PlacementBit(ref array, NR, NC, r, c, p, 0);
  }

  private void Ecc200PlacementCornerA(ref int[] array, int NR, int NC, int p)
  {
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 7);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 1, p, 6);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 2, p, 5);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
    this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 2);
    this.Ecc200PlacementBit(ref array, NR, NC, 2, NC - 1, p, 1);
    this.Ecc200PlacementBit(ref array, NR, NC, 3, NC - 1, p, 0);
  }

  private void Ecc200PlacementCornerB(ref int[] array, int NR, int NC, int p)
  {
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 3, 0, p, 7);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 2, 0, p, 6);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 5);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 4, p, 4);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 3, p, 3);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 2);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 1);
    this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 0);
  }

  private void Ecc200PlacementCornerC(ref int[] array, int NR, int NC, int p)
  {
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 3, 0, p, 7);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 2, 0, p, 6);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 5);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
    this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 2);
    this.Ecc200PlacementBit(ref array, NR, NC, 2, NC - 1, p, 1);
    this.Ecc200PlacementBit(ref array, NR, NC, 3, NC - 1, p, 0);
  }

  private void Ecc200PlacementCornerD(ref int[] array, int NR, int NC, int p)
  {
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 7);
    this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, NC - 1, p, 6);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 3, p, 5);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
    this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
    this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 3, p, 2);
    this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 2, p, 1);
    this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 0);
  }

  private void Ecc200(char[] binary, int bytes, int datablock, int rsblock)
  {
    int num1 = (bytes + 2) / datablock;
    DataMatrixImage.InitGalois(301);
    DataMatrixImage.InitReedSolomon(rsblock, 1);
    for (int index1 = 0; index1 < num1; ++index1)
    {
      int[] data = new int[256 /*0x0100*/];
      int[] result = new int[256 /*0x0100*/];
      int length = 0;
      for (int index2 = index1; index2 < bytes; index2 += num1)
        data[length++] = (int) binary[index2];
      this.EncodeReedSolomon(length, data, ref result);
      int num2 = rsblock - 1;
      for (int index3 = index1; index3 < rsblock * num1; index3 += num1)
        binary[bytes + index3] = (char) result[num2--];
    }
  }

  public static void InitGalois(int poly)
  {
    if (DataMatrixImage.log != null)
    {
      DataMatrixImage.log = (int[]) null;
      DataMatrixImage.alog = (int[]) null;
      DataMatrixImage.rspoly = (int[]) null;
    }
    int num1 = 1;
    int num2 = 0;
    for (; num1 <= poly; num1 <<= 1)
      ++num2;
    int num3 = num1 >> 1;
    int num4 = num2 - 1;
    DataMatrixImage.gfpoly = poly;
    DataMatrixImage.symsize = num4;
    DataMatrixImage.logmod = (1 << num4) - 1;
    DataMatrixImage.log = new int[DataMatrixImage.logmod + 1];
    DataMatrixImage.alog = new int[DataMatrixImage.logmod];
    int index1 = 1;
    for (int index2 = 0; index2 < DataMatrixImage.logmod; ++index2)
    {
      DataMatrixImage.alog[index2] = index1;
      DataMatrixImage.log[index1] = index2;
      index1 <<= 1;
      if ((index1 & num3) != 0)
        index1 ^= poly;
    }
  }

  public static void InitReedSolomon(int nsym, int index)
  {
    if (DataMatrixImage.rspoly != null)
      DataMatrixImage.rspoly = (int[]) null;
    DataMatrixImage.rspoly = new int[nsym + 1];
    DataMatrixImage.rlen = nsym;
    DataMatrixImage.rspoly[0] = 1;
    for (int index1 = 1; index1 <= nsym; ++index1)
    {
      DataMatrixImage.rspoly[index1] = 1;
      for (int index2 = index1 - 1; index2 > 0; --index2)
      {
        if (DataMatrixImage.rspoly[index2] != 0)
          DataMatrixImage.rspoly[index2] = DataMatrixImage.alog[(DataMatrixImage.log[DataMatrixImage.rspoly[index2]] + index) % DataMatrixImage.logmod];
        DataMatrixImage.rspoly[index2] ^= DataMatrixImage.rspoly[index2 - 1];
      }
      DataMatrixImage.rspoly[0] = DataMatrixImage.alog[(DataMatrixImage.log[DataMatrixImage.rspoly[0]] + index) % DataMatrixImage.logmod];
      ++index;
    }
  }

  public void EncodeReedSolomon(int length, int[] data, ref int[] result)
  {
    for (int index = 0; index < DataMatrixImage.rlen; ++index)
      result[index] = 0;
    for (int index1 = 0; index1 < length; ++index1)
    {
      int index2 = result[DataMatrixImage.rlen - 1] ^ data[index1];
      for (int index3 = DataMatrixImage.rlen - 1; index3 > 0; --index3)
      {
        int num = index2 == 0 ? 0 : (DataMatrixImage.rspoly[index3] != 0 ? 1 : 0);
        result[index3] = num == 0 ? result[index3 - 1] : result[index3 - 1] ^ DataMatrixImage.alog[(DataMatrixImage.log[index2] + DataMatrixImage.log[DataMatrixImage.rspoly[index3]]) % DataMatrixImage.logmod];
      }
      int num1 = index2 == 0 ? 0 : (DataMatrixImage.rspoly[0] != 0 ? 1 : 0);
      result[0] = num1 == 0 ? 0 : DataMatrixImage.alog[(DataMatrixImage.log[index2] + DataMatrixImage.log[DataMatrixImage.rspoly[0]]) % DataMatrixImage.logmod];
    }
  }

  public XImage CreateImage(char[] code, int size) => this.CreateImage(code, size, size, 10);

  public XImage CreateImage(char[] code, int rows, int columns)
  {
    return this.CreateImage(code, rows, columns, 10);
  }

  public XImage CreateImage(char[] code, int rows, int columns, int pixelsize) => (XImage) null;

  private struct Ecc200Block(
    int h,
    int w,
    int ch,
    int cw,
    int bytes,
    int dataBlock,
    int rsBlock)
  {
    public readonly int Height = h;
    public readonly int Width = w;
    public readonly int CellHeight = ch;
    public readonly int CellWidth = cw;
    public readonly int Bytes = bytes;
    public readonly int DataBlock = dataBlock;
    public readonly int RSBlock = rsBlock;
  }
}
