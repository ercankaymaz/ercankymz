// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Range
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace buMutliTextbox;

public class Range : IEnumerable<Place>, IEnumerable
{
  internal Place start;
  internal Place end;
  public readonly buMultiTextBox tb;
  internal int int_0 = -1;
  internal int int_1 = 0;
  internal string string_0;
  internal List<Place> list_0;
  internal int int_2 = -1;
  private bool bool_0;

  public Range(buMultiTextBox tb) => this.tb = tb;

  public virtual bool IsEmpty
  {
    get => !this.ColumnSelectionMode ? this.Start == this.End : this.Start.iChar == this.End.iChar;
  }

  public bool ColumnSelectionMode
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public Range(buMultiTextBox tb, int iStartChar, int iStartLine, int iEndChar, int iEndLine)
    : this(tb)
  {
    this.start = new Place(iStartChar, iStartLine);
    this.end = new Place(iEndChar, iEndLine);
  }

  public Range(buMultiTextBox tb, Place start, Place end)
    : this(tb)
  {
    this.start = start;
    this.end = end;
  }

  public Range(buMultiTextBox tb, int iLine)
    : this(tb)
  {
    this.start = new Place(0, iLine);
    this.end = new Place(tb[iLine].Count, iLine);
  }

  public bool Contains(Place place)
  {
    bool flag;
    if (place.iLine < Math.Min(this.start.iLine, this.end.iLine))
      flag = false;
    else if (place.iLine > Math.Max(this.start.iLine, this.end.iLine))
    {
      flag = false;
    }
    else
    {
      Place place1 = this.start;
      Place place2 = this.end;
      if ((place1.iLine > place2.iLine ? 1 : (place1.iLine != place2.iLine ? 0 : (place1.iChar > place2.iChar ? 1 : 0))) != 0)
      {
        Place place3 = place1;
        place1 = place2;
        place2 = place3;
      }
      if (this.bool_0)
      {
        if ((place.iChar < place1.iChar ? 1 : (place.iChar > place2.iChar ? 1 : 0)) != 0)
        {
          flag = false;
          goto label_14;
        }
      }
      else
      {
        if ((place.iLine != place1.iLine ? 0 : (place.iChar < place1.iChar ? 1 : 0)) != 0)
        {
          flag = false;
          goto label_14;
        }
        if ((place.iLine != place2.iLine ? 0 : (place.iChar > place2.iChar ? 1 : 0)) != 0)
        {
          flag = false;
          goto label_14;
        }
      }
      flag = true;
    }
label_14:
    return flag;
  }

  public virtual Range GetIntersectionWith(Range range)
  {
    Range intersectionWith;
    if (this.ColumnSelectionMode)
    {
      intersectionWith = Class39.smethod_552(range, this);
    }
    else
    {
      Range range1 = this.Clone();
      Range range2 = range.Clone();
      range1.Normalize();
      range2.Normalize();
      Place fromPlace = range1.Start > range2.Start ? range1.Start : range2.Start;
      Place toPlace = range1.End < range2.End ? range1.End : range2.End;
      intersectionWith = !(toPlace < fromPlace) ? this.tb.GetRange(fromPlace, toPlace) : new Range(this.tb, this.start, this.start);
    }
    return intersectionWith;
  }

  public Range GetUnionWith(Range range)
  {
    Range range1 = this.Clone();
    Range range2 = range.Clone();
    range1.Normalize();
    range2.Normalize();
    return this.tb.GetRange(range1.Start < range2.Start ? range1.Start : range2.Start, range1.End > range2.End ? range1.End : range2.End);
  }

  public void SelectAll()
  {
    this.ColumnSelectionMode = false;
    this.Start = new Place(0, 0);
    if (this.tb.LinesCount == 0)
    {
      this.Start = new Place(0, 0);
    }
    else
    {
      this.end = new Place(0, 0);
      this.start = new Place(this.tb[this.tb.LinesCount - 1].Count, this.tb.LinesCount - 1);
    }
    if (this != this.tb.Selection)
      return;
    this.tb.Invalidate();
  }

  public Place Start
  {
    get => this.start;
    set
    {
      this.end = this.start = value;
      this.int_0 = -1;
      Class39.smethod_27(this);
    }
  }

  public Place End
  {
    get => this.end;
    set
    {
      this.end = value;
      Class39.smethod_27(this);
    }
  }

  public virtual string Text
  {
    get
    {
      string text;
      if (this.ColumnSelectionMode)
      {
        text = Class39.smethod_109(this);
      }
      else
      {
        int num1 = Math.Min(this.end.iLine, this.start.iLine);
        int num2 = Math.Max(this.end.iLine, this.start.iLine);
        int num3 = Class39.smethod_113(this);
        int num4 = Class39.smethod_236(this);
        if (num1 < 0)
        {
          text = (string) null;
        }
        else
        {
          StringBuilder stringBuilder = new StringBuilder();
          for (int iLine = num1; iLine <= num2; ++iLine)
          {
            int num5 = iLine == num1 ? num3 : 0;
            int num6 = iLine == num2 ? Math.Min(this.tb[iLine].Count - 1, num4 - 1) : this.tb[iLine].Count - 1;
            for (int index = num5; index <= num6; ++index)
              stringBuilder.Append(this.tb[iLine][index].c);
            if ((iLine == num2 ? 0 : (num1 != num2 ? 1 : 0)) != 0)
              stringBuilder.AppendLine();
          }
          text = stringBuilder.ToString();
        }
      }
      return text;
    }
  }

  public int Length
  {
    get
    {
      int length;
      if (this.ColumnSelectionMode)
      {
        length = Class39.smethod_447(false, this);
      }
      else
      {
        int num1 = Math.Min(this.end.iLine, this.start.iLine);
        int num2 = Math.Max(this.end.iLine, this.start.iLine);
        int num3 = 0;
        if (num1 < 0)
        {
          length = 0;
        }
        else
        {
          for (int iLine = num1; iLine <= num2; ++iLine)
          {
            int num4 = iLine == num1 ? Class39.smethod_113(this) : 0;
            int num5 = iLine == num2 ? Math.Min(this.tb[iLine].Count - 1, Class39.smethod_236(this) - 1) : this.tb[iLine].Count - 1;
            num3 += num5 - num4 + 1;
            if ((iLine == num2 ? 0 : (num1 != num2 ? 1 : 0)) != 0)
              num3 += Environment.NewLine.Length;
          }
          length = num3;
        }
      }
      return length;
    }
  }

  public int TextLength
  {
    get => !this.ColumnSelectionMode ? this.Length : Class39.smethod_447(true, this);
  }

  public char CharAfterStart
  {
    get
    {
      return this.Start.iChar < this.tb[this.Start.iLine].Count ? this.tb[this.Start.iLine][this.Start.iChar].c : '\n';
    }
  }

  public char CharBeforeStart
  {
    get
    {
      return this.Start.iChar <= this.tb[this.Start.iLine].Count ? (this.Start.iChar > 0 ? this.tb[this.Start.iLine][this.Start.iChar - 1].c : '\n') : '\n';
    }
  }

  public string GetCharsBeforeStart(int charsCount)
  {
    int pos = this.tb.PlaceToPosition(this.Start) - charsCount;
    if (pos < 0)
      pos = 0;
    return new Range(this.tb, this.tb.PositionToPlace(pos), this.Start).Text;
  }

  public string GetCharsAfterStart(int charsCount) => this.GetCharsBeforeStart(-charsCount);

  public Range Clone() => (Range) this.MemberwiseClone();

  public int FromLine => Math.Min(this.Start.iLine, this.End.iLine);

  public int ToLine => Math.Max(this.Start.iLine, this.End.iLine);

  public bool GoRight()
  {
    Place start = this.start;
    this.GoRight(false);
    return start != this.start;
  }

  public virtual bool GoRightThroughFolded()
  {
    bool flag;
    if (this.ColumnSelectionMode)
      flag = Class39.smethod_732(this);
    else if ((this.start.iLine < this.tb.LinesCount - 1 ? 0 : (this.start.iChar >= this.tb[this.tb.LinesCount - 1].Count ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      if (this.start.iChar < this.tb[this.start.iLine].Count)
        this.start.Offset(1, 0);
      else
        this.start = new Place(0, this.start.iLine + 1);
      this.int_0 = -1;
      this.end = this.start;
      Class39.smethod_27(this);
      flag = true;
    }
    return flag;
  }

  public bool GoLeft()
  {
    this.ColumnSelectionMode = false;
    Place start = this.start;
    this.GoLeft(false);
    return start != this.start;
  }

  public bool GoLeftThroughFolded()
  {
    this.ColumnSelectionMode = false;
    bool flag;
    if ((this.start.iChar != 0 ? 0 : (this.start.iLine == 0 ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      if (this.start.iChar > 0)
        this.start.Offset(-1, 0);
      else
        this.start = new Place(this.tb[this.start.iLine - 1].Count, this.start.iLine - 1);
      this.int_0 = -1;
      this.end = this.start;
      Class39.smethod_27(this);
      flag = true;
    }
    return flag;
  }

  public void GoLeft(bool shift)
  {
    this.ColumnSelectionMode = false;
    if (!shift && this.start > this.end)
    {
      this.Start = this.End;
    }
    else
    {
      if ((this.start.iChar != 0 ? 1 : (this.start.iLine != 0 ? 1 : 0)) != 0)
      {
        if ((this.start.iChar <= 0 ? 0 : (this.tb.LineInfos[this.start.iLine].VisibleState == VisibleState.Visible ? 1 : 0)) != 0)
        {
          this.start.Offset(-1, 0);
        }
        else
        {
          int iLine = Class39.smethod_735(this.tb, this.start.iLine);
          if (iLine == this.start.iLine)
            return;
          this.start = new Place(this.tb[iLine].Count, iLine);
        }
      }
      if (!shift)
        this.end = this.start;
      Class39.smethod_27(this);
      this.int_0 = -1;
    }
  }

  public void GoRight(bool shift)
  {
    this.ColumnSelectionMode = false;
    if (!shift && this.start < this.end)
    {
      this.Start = this.End;
    }
    else
    {
      if ((this.start.iLine < this.tb.LinesCount - 1 ? 1 : (this.start.iChar < this.tb[this.tb.LinesCount - 1].Count ? 1 : 0)) != 0)
      {
        if ((this.start.iChar >= this.tb[this.start.iLine].Count ? 0 : (this.tb.LineInfos[this.start.iLine].VisibleState == VisibleState.Visible ? 1 : 0)) != 0)
        {
          this.start.Offset(1, 0);
        }
        else
        {
          int iLine = Class39.smethod_97(this.tb, this.start.iLine);
          if (iLine == this.start.iLine)
            return;
          this.start = new Place(0, iLine);
        }
      }
      if (!shift)
        this.end = this.start;
      Class39.smethod_27(this);
      this.int_0 = -1;
    }
  }

  public void SetStyle(Style style)
  {
    this.SetStyle(Range.ToStyleIndex(Class39.smethod_241(this.tb, style)));
    this.tb.Invalidate();
  }

  public void SetStyle(Style style, string regexPattern)
  {
    this.SetStyle(Range.ToStyleIndex(Class39.smethod_241(this.tb, style)), regexPattern, RegexOptions.None);
  }

  public void SetStyle(Style style, Regex regex)
  {
    this.SetStyle(Range.ToStyleIndex(Class39.smethod_241(this.tb, style)), regex);
  }

  public void SetStyle(Style style, string regexPattern, RegexOptions options)
  {
    this.SetStyle(Range.ToStyleIndex(Class39.smethod_241(this.tb, style)), regexPattern, options);
  }

  public void SetStyle(StyleIndex styleLayer, string regexPattern, RegexOptions options)
  {
    if (Math.Abs(this.Start.iLine - this.End.iLine) > 1000)
      options |= SyntaxHighlighter.RegexCompiledOption;
    foreach (Range range in this.GetRanges(regexPattern, options))
      range.SetStyle(styleLayer);
    this.tb.Invalidate();
  }

  public void SetStyle(StyleIndex styleLayer, Regex regex)
  {
    foreach (Range range in this.GetRanges(regex))
      range.SetStyle(styleLayer);
    this.tb.Invalidate();
  }

  public void SetStyle(StyleIndex styleIndex)
  {
    int num1 = Math.Min(this.End.iLine, this.Start.iLine);
    int num2 = Math.Max(this.End.iLine, this.Start.iLine);
    int num3 = Class39.smethod_113(this);
    int num4 = Class39.smethod_236(this);
    if (num1 < 0)
      return;
    for (int iLine = num1; iLine <= num2; ++iLine)
    {
      int num5 = iLine == num1 ? num3 : 0;
      int num6 = iLine == num2 ? Math.Min(num4 - 1, this.tb[iLine].Count - 1) : this.tb[iLine].Count - 1;
      for (int index = num5; index <= num6; ++index)
      {
        Char @char = this.tb[iLine][index];
        @char.style |= styleIndex;
        this.tb[iLine][index] = @char;
      }
    }
  }

  public void SetFoldingMarkers(string startFoldingPattern, string finishFoldingPattern)
  {
    this.SetFoldingMarkers(startFoldingPattern, finishFoldingPattern, SyntaxHighlighter.RegexCompiledOption);
  }

  public void SetFoldingMarkers(
    string startFoldingPattern,
    string finishFoldingPattern,
    RegexOptions options)
  {
    if (startFoldingPattern == finishFoldingPattern)
    {
      this.SetFoldingMarkers(startFoldingPattern, options);
    }
    else
    {
      foreach (Range range in this.GetRanges(startFoldingPattern, options))
        this.tb[range.Start.iLine].FoldingStartMarker = startFoldingPattern;
      foreach (Range range in this.GetRanges(finishFoldingPattern, options))
        this.tb[range.Start.iLine].FoldingEndMarker = startFoldingPattern;
      this.tb.Invalidate();
    }
  }

  public void SetFoldingMarkers(string foldingPattern, RegexOptions options)
  {
    foreach (Range range in this.GetRanges(foldingPattern, options))
    {
      if (range.Start.iLine > 0)
        this.tb[range.Start.iLine - 1].FoldingEndMarker = foldingPattern;
      this.tb[range.Start.iLine].FoldingStartMarker = foldingPattern;
    }
    this.tb.Invalidate();
  }

  public IEnumerable<Range> GetRanges(string regexPattern)
  {
    return this.GetRanges(regexPattern, RegexOptions.None);
  }

  public IEnumerable<Range> GetRanges(string regexPattern, RegexOptions options)
  {
    Range range_0 = this;
    string input;
    ref string local1 = ref input;
    List<Place> placeList;
    ref List<Place> local2 = ref placeList;
    Class39.smethod_302(out local1, range_0, ref local2);
    Regex regex = new Regex(regexPattern, options);
    foreach (Match match_0 in regex.Matches(input))
    {
      Range range = new Range(this.tb);
      Group group = match_0.Groups["range"];
      if (!group.Success)
        group = match_0.Groups[0];
      range.Start = placeList[group.Index];
      range.End = placeList[group.Index + group.Length];
      yield return range;
      range = (Range) null;
      group = (Group) null;
    }
    Class39.smethod_220(this);
    IEnumerator enumerator = (IEnumerator) null;
  }

  public IEnumerable<Range> GetRangesByLines(string regexPattern, RegexOptions options)
  {
    Regex regex = new Regex(regexPattern, options);
    IEnumerator<Range> enumerator = this.GetRangesByLines(regex).GetEnumerator();
    while (enumerator.MoveNext())
    {
      Range rangesByLine = enumerator.Current;
      yield return rangesByLine;
      rangesByLine = (Range) null;
    }
    Class39.smethod_557(this);
    enumerator = (IEnumerator<Range>) null;
  }

  public IEnumerable<Range> GetRangesByLines(Regex regex)
  {
    this.Normalize();
    FileTextSource textSource = this.tb.TextSource as FileTextSource;
    for (int iLine = this.Start.iLine; iLine <= this.End.iLine; ++iLine)
    {
      bool flag = textSource == null || textSource.IsLineLoaded(iLine);
      Range range = new Range(this.tb, new Place(0, iLine), new Place(this.tb[iLine].Count, iLine));
      if ((iLine == this.Start.iLine ? 1 : (iLine == this.End.iLine ? 1 : 0)) != 0)
        range = range.GetIntersectionWith(this);
      IEnumerator<Range> enumerator = range.GetRanges(regex).GetEnumerator();
      while (enumerator.MoveNext())
      {
        Range rangesByLine = enumerator.Current;
        yield return rangesByLine;
        rangesByLine = (Range) null;
      }
      Class39.smethod_395(this);
      enumerator = (IEnumerator<Range>) null;
      if (!flag)
        Class39.smethod_656(textSource, iLine);
      range = (Range) null;
    }
  }

  public IEnumerable<Range> GetRangesByLinesReversed(string regexPattern, RegexOptions options)
  {
    this.Normalize();
    Regex regex = new Regex(regexPattern, options);
    FileTextSource textSource = this.tb.TextSource as FileTextSource;
    for (int iLine = this.End.iLine; iLine >= this.Start.iLine; --iLine)
    {
      bool flag = textSource == null || textSource.IsLineLoaded(iLine);
      Range range = new Range(this.tb, new Place(0, iLine), new Place(this.tb[iLine].Count, iLine));
      if ((iLine == this.Start.iLine ? 1 : (iLine == this.End.iLine ? 1 : 0)) != 0)
        range = range.GetIntersectionWith(this);
      List<Range> rangeList = new List<Range>();
      foreach (Range range_3 in range.GetRanges(regex))
        rangeList.Add(range_3);
      for (int index = rangeList.Count - 1; index >= 0; --index)
        yield return rangeList[index];
      if (!flag)
        Class39.smethod_656(textSource, iLine);
      range = (Range) null;
      rangeList = (List<Range>) null;
    }
  }

  public IEnumerable<Range> GetRanges(Regex regex)
  {
    Range range_0 = this;
    string input;
    ref string local1 = ref input;
    List<Place> placeList;
    ref List<Place> local2 = ref placeList;
    Class39.smethod_302(out local1, range_0, ref local2);
    foreach (Match match_0 in regex.Matches(input))
    {
      Range range = new Range(this.tb);
      Group group = match_0.Groups["range"];
      if (!group.Success)
        group = match_0.Groups[0];
      range.Start = placeList[group.Index];
      range.End = placeList[group.Index + group.Length];
      yield return range;
      range = (Range) null;
      group = (Group) null;
    }
    Class39.smethod_145(this);
    IEnumerator enumerator = (IEnumerator) null;
  }

  public void ClearStyle(params Style[] styles)
  {
    try
    {
      this.ClearStyle(this.tb.GetStyleIndexMask(styles));
    }
    catch
    {
    }
  }

  public void ClearStyle(StyleIndex styleIndex)
  {
    int num1 = Math.Min(this.End.iLine, this.Start.iLine);
    int num2 = Math.Max(this.End.iLine, this.Start.iLine);
    int num3 = Class39.smethod_113(this);
    int num4 = Class39.smethod_236(this);
    if (num1 < 0)
      return;
    for (int iLine = num1; iLine <= num2; ++iLine)
    {
      int num5 = iLine == num1 ? num3 : 0;
      int num6 = iLine == num2 ? Math.Min(num4 - 1, this.tb[iLine].Count - 1) : this.tb[iLine].Count - 1;
      for (int index = num5; index <= num6; ++index)
      {
        Char @char = this.tb[iLine][index];
        @char.style &= ~styleIndex;
        this.tb[iLine][index] = @char;
      }
    }
    this.tb.Invalidate();
  }

  public void ClearFoldingMarkers()
  {
    int num1 = Math.Min(this.End.iLine, this.Start.iLine);
    int num2 = Math.Max(this.End.iLine, this.Start.iLine);
    if (num1 < 0)
      return;
    for (int iLine = num1; iLine <= num2; ++iLine)
      this.tb[iLine].ClearFoldingMarkers();
    this.tb.Invalidate();
  }

  public void BeginUpdate() => ++this.int_1;

  public void EndUpdate()
  {
    --this.int_1;
    if (this.int_1 != 0)
      return;
    Class39.smethod_27(this);
  }

  public override string ToString()
  {
    Place place = this.Start;
    string str1 = place.ToString();
    place = this.End;
    string str2 = place.ToString();
    return $"Start: {str1} End: {str2}";
  }

  public void Normalize()
  {
    if (!(this.Start > this.End))
      return;
    this.Inverse();
  }

  public void Inverse()
  {
    Place start = this.start;
    this.start = this.end;
    this.end = start;
  }

  public void Expand()
  {
    this.Normalize();
    this.start = new Place(0, this.start.iLine);
    this.end = new Place(this.tb.GetLineLength(this.end.iLine), this.end.iLine);
  }

  IEnumerator<Place> IEnumerable<Place>.GetEnumerator()
  {
    if (this.ColumnSelectionMode)
    {
      IEnumerator<Place> enumerator = this.method_0().GetEnumerator();
      while (enumerator.MoveNext())
      {
        Place current = enumerator.Current;
        yield return current;
      }
      Class39.smethod_251(this);
      enumerator = (IEnumerator<Place>) null;
    }
    else
    {
      int num1 = Math.Min(this.end.iLine, this.start.iLine);
      int num2 = Math.Max(this.end.iLine, this.start.iLine);
      int num3 = Class39.smethod_113(this);
      int num4 = Class39.smethod_236(this);
      if (num1 >= 0)
      {
        for (int iLine = num1; iLine <= num2; ++iLine)
        {
          int num5 = iLine == num1 ? num3 : 0;
          int num6 = iLine == num2 ? Math.Min(num4 - 1, this.tb[iLine].Count - 1) : this.tb[iLine].Count - 1;
          for (int iChar = num5; iChar <= num6; ++iChar)
            yield return new Place(iChar, iLine);
        }
      }
    }
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return (IEnumerator) ((IEnumerable<Place>) this).GetEnumerator();
  }

  public IEnumerable<Char> Chars
  {
    get
    {
      if (this.ColumnSelectionMode)
      {
        IEnumerator<Place> enumerator = this.method_0().GetEnumerator();
        while (enumerator.MoveNext())
        {
          Place current = enumerator.Current;
          yield return this.tb[current];
        }
        Class39.smethod_548(this);
        enumerator = (IEnumerator<Place>) null;
      }
      else
      {
        int num1 = Math.Min(this.end.iLine, this.start.iLine);
        int num2 = Math.Max(this.end.iLine, this.start.iLine);
        int num3 = Class39.smethod_113(this);
        int num4 = Class39.smethod_236(this);
        if (num1 >= 0)
        {
          for (int iLine = num1; iLine <= num2; ++iLine)
          {
            int num5 = iLine == num1 ? num3 : 0;
            int num6 = iLine == num2 ? Math.Min(num4 - 1, this.tb[iLine].Count - 1) : this.tb[iLine].Count - 1;
            Line line = this.tb[iLine];
            for (int index = num5; index <= num6; ++index)
              yield return line[index];
            line = (Line) null;
          }
        }
      }
    }
  }

  public Range GetFragment(string allowedSymbolsPattern)
  {
    return this.GetFragment(allowedSymbolsPattern, RegexOptions.None);
  }

  public Range GetFragment(Style style, bool allowLineBreaks)
  {
    StyleIndex styleIndexMask = this.tb.GetStyleIndexMask(new Style[1]
    {
      style
    });
    Range range = new Range(this.tb);
    range.Start = this.Start;
    while (range.GoLeftThroughFolded() && (allowLineBreaks ? 0 : (range.CharAfterStart == '\n' ? 1 : 0)) == 0)
    {
      if (range.Start.iChar < this.tb.GetLineLength(range.Start.iLine) && (this.tb[range.Start].style & styleIndexMask) == StyleIndex.None)
      {
        range.GoRightThroughFolded();
        break;
      }
    }
    Place start1 = range.Start;
    range.Start = this.Start;
    do
      ;
    while ((allowLineBreaks ? 0 : (range.CharAfterStart == '\n' ? 1 : 0)) == 0 && (range.Start.iChar >= this.tb.GetLineLength(range.Start.iLine) || (this.tb[range.Start].style & styleIndexMask) != StyleIndex.None) && range.GoRightThroughFolded());
    Place start2 = range.Start;
    return new Range(this.tb, start1, start2);
  }

  public Range GetFragment(string allowedSymbolsPattern, RegexOptions options)
  {
    Range range = new Range(this.tb);
    range.Start = this.Start;
    Regex regex = new Regex(allowedSymbolsPattern, options);
    while (range.GoLeftThroughFolded())
    {
      if (!regex.IsMatch(range.CharAfterStart.ToString()))
      {
        range.GoRightThroughFolded();
        break;
      }
    }
    Place start1 = range.Start;
    range.Start = this.Start;
    do
      ;
    while (regex.IsMatch(range.CharAfterStart.ToString()) && range.GoRightThroughFolded());
    Place start2 = range.Start;
    return new Range(this.tb, start1, start2);
  }

  public void GoWordLeft(bool shift)
  {
    this.ColumnSelectionMode = false;
    if ((shift ? 0 : (this.start > this.end ? 1 : 0)) != 0)
    {
      this.Start = this.End;
    }
    else
    {
      Range range = this.Clone();
      bool flag1 = false;
      while (Class39.smethod_47(this, range.CharBeforeStart))
      {
        flag1 = true;
        range.GoLeft(shift);
      }
      bool flag2 = false;
      while (Class39.smethod_254(this, range.CharBeforeStart))
      {
        flag2 = true;
        range.GoLeft(shift);
      }
      if ((flag2 ? 0 : (!flag1 ? 1 : (range.CharBeforeStart != '\n' ? 1 : 0))) != 0)
        range.GoLeft(shift);
      this.Start = range.Start;
      this.End = range.End;
      if (this.tb.LineInfos[this.Start.iLine].VisibleState == 0)
        return;
      this.GoRight(shift);
    }
  }

  public void GoWordRight(bool shift, bool goToStartOfNextWord = false)
  {
    this.ColumnSelectionMode = false;
    if ((shift ? 0 : (this.start < this.end ? 1 : 0)) != 0)
    {
      this.Start = this.End;
    }
    else
    {
      Range range = this.Clone();
      bool flag1 = false;
      if (range.CharAfterStart == '\n')
      {
        range.GoRight(shift);
        flag1 = true;
      }
      bool flag2 = false;
      while (Class39.smethod_47(this, range.CharAfterStart))
      {
        flag2 = true;
        range.GoRight(shift);
      }
      if (!((flag2 | flag1) & goToStartOfNextWord))
      {
        bool flag3 = false;
        while (Class39.smethod_254(this, range.CharAfterStart))
        {
          flag3 = true;
          range.GoRight(shift);
        }
        if (!flag3)
          range.GoRight(shift);
        if ((!goToStartOfNextWord ? 0 : (!flag2 ? 1 : 0)) != 0)
        {
          while (Class39.smethod_47(this, range.CharAfterStart))
            range.GoRight(shift);
        }
      }
      this.Start = range.Start;
      this.End = range.End;
      if (this.tb.LineInfos[this.Start.iLine].VisibleState == 0)
        return;
      this.GoLeft(shift);
    }
  }

  public static StyleIndex ToStyleIndex(int i) => (StyleIndex) (1 << i);

  public RangeRect Bounds
  {
    get
    {
      int iStartChar = Math.Min(this.Start.iChar, this.End.iChar);
      int iStartLine = Math.Min(this.Start.iLine, this.End.iLine);
      int iEndChar = Math.Max(this.Start.iChar, this.End.iChar);
      int iEndLine = Math.Max(this.Start.iLine, this.End.iLine);
      return new RangeRect(iStartLine, iStartChar, iEndLine, iEndChar);
    }
  }

  public IEnumerable<Range> GetSubRanges(bool includeEmpty)
  {
    if (!this.ColumnSelectionMode)
    {
      yield return this;
    }
    else
    {
      RangeRect bounds = this.Bounds;
      for (int iStartLine = bounds.iStartLine; iStartLine <= bounds.iEndLine; ++iStartLine)
      {
        if ((bounds.iStartChar <= this.tb[iStartLine].Count ? 0 : (!includeEmpty ? 1 : 0)) != 0)
          continue;
        Range subRange = new Range(this.tb, bounds.iStartChar, iStartLine, Math.Min(bounds.iEndChar, this.tb[iStartLine].Count), iStartLine);
        yield return subRange;
        subRange = (Range) null;
      }
    }
  }

  public bool ReadOnly
  {
    get
    {
      bool flag;
      if (this.tb.ReadOnly)
      {
        flag = true;
      }
      else
      {
        ReadOnlyStyle readOnlyStyle = (ReadOnlyStyle) null;
        foreach (Style style in this.tb.Styles)
        {
          if (style is ReadOnlyStyle)
          {
            readOnlyStyle = (ReadOnlyStyle) style;
            break;
          }
        }
        if (readOnlyStyle != null)
        {
          StyleIndex styleIndex = Range.ToStyleIndex(this.tb.GetStyleIndex((Style) readOnlyStyle));
          if (this.IsEmpty)
          {
            Line line1 = this.tb[this.start.iLine];
            if (this.bool_0)
            {
              foreach (Range subRange in this.GetSubRanges(false))
              {
                Line line2 = this.tb[subRange.start.iLine];
                if ((subRange.start.iChar >= line2.Count ? 0 : (subRange.start.iChar > 0 ? 1 : 0)) != 0)
                {
                  Char char1 = line2[subRange.start.iChar - 1];
                  Char char2 = line2[subRange.start.iChar];
                  if (((char1.style & styleIndex) == StyleIndex.None ? 0 : ((char2.style & styleIndex) != 0 ? 1 : 0)) != 0)
                  {
                    flag = true;
                    goto label_31;
                  }
                }
              }
            }
            else if ((this.start.iChar >= line1.Count ? 0 : (this.start.iChar > 0 ? 1 : 0)) != 0)
            {
              Char char3 = line1[this.start.iChar - 1];
              Char char4 = line1[this.start.iChar];
              if (((char3.style & styleIndex) == StyleIndex.None ? 0 : ((char4.style & styleIndex) != 0 ? 1 : 0)) != 0)
              {
                flag = true;
                goto label_31;
              }
            }
          }
          else
          {
            foreach (Char @char in this.Chars)
            {
              if ((@char.style & styleIndex) != 0)
              {
                flag = true;
                goto label_31;
              }
            }
          }
        }
        flag = false;
      }
label_31:
      return flag;
    }
    set
    {
      ReadOnlyStyle readOnlyStyle = (ReadOnlyStyle) null;
      foreach (Style style in this.tb.Styles)
      {
        if (style is ReadOnlyStyle)
        {
          readOnlyStyle = (ReadOnlyStyle) style;
          break;
        }
      }
      if (readOnlyStyle == null)
        readOnlyStyle = new ReadOnlyStyle();
      if (value)
        this.SetStyle((Style) readOnlyStyle);
      else
        this.ClearStyle((Style) readOnlyStyle);
    }
  }

  public bool IsReadOnlyLeftChar()
  {
    bool flag;
    if (this.tb.ReadOnly)
    {
      flag = true;
    }
    else
    {
      Range range_0 = this.Clone();
      range_0.Normalize();
      if (range_0.start.iChar == 0)
      {
        flag = false;
      }
      else
      {
        if (this.ColumnSelectionMode)
          Class39.smethod_198(range_0);
        else
          range_0.GoLeft(true);
        flag = range_0.ReadOnly;
      }
    }
    return flag;
  }

  public bool IsReadOnlyRightChar()
  {
    bool flag;
    if (this.tb.ReadOnly)
    {
      flag = true;
    }
    else
    {
      Range range_0 = this.Clone();
      range_0.Normalize();
      if (range_0.end.iChar >= this.tb[this.end.iLine].Count)
      {
        flag = false;
      }
      else
      {
        if (this.ColumnSelectionMode)
          Class39.smethod_847(range_0);
        else
          range_0.GoRight(true);
        flag = range_0.ReadOnly;
      }
    }
    return flag;
  }

  public IEnumerable<Place> GetPlacesCyclic(Place startPlace, bool backward = false)
  {
    if (backward)
    {
      Range range = new Range(this.tb, startPlace, startPlace);
      while ((!range.GoLeft() ? 0 : (range.start >= this.Start ? 1 : 0)) != 0)
      {
        if (range.Start.iChar < this.tb[range.Start.iLine].Count)
          yield return range.Start;
      }
      range = new Range(this.tb, this.End, this.End);
      while ((!range.GoLeft() ? 0 : (range.start >= startPlace ? 1 : 0)) != 0)
      {
        if (range.Start.iChar < this.tb[range.Start.iLine].Count)
          yield return range.Start;
      }
      range = (Range) null;
    }
    else
    {
      Range range = new Range(this.tb, startPlace, startPlace);
      if (startPlace < this.End)
      {
        do
        {
          if (range.Start.iChar < this.tb[range.Start.iLine].Count)
            goto label_14;
label_12:
          continue;
label_14:
          yield return range.Start;
          goto label_12;
        }
        while (range.GoRight());
      }
      range = new Range(this.tb, this.Start, this.Start);
      if (range.Start < startPlace)
      {
        do
        {
          if (range.Start.iChar < this.tb[range.Start.iLine].Count)
            goto label_18;
label_16:
          continue;
label_18:
          yield return range.Start;
          goto label_16;
        }
        while ((!range.GoRight() ? 0 : (range.Start < startPlace ? 1 : 0)) != 0);
      }
      range = (Range) null;
    }
  }

  private IEnumerable<Place> method_0()
  {
    RangeRect bounds = this.Bounds;
    if (bounds.iStartLine >= 0)
    {
      for (int iStartLine = bounds.iStartLine; iStartLine <= bounds.iEndLine; ++iStartLine)
      {
        for (int iStartChar = bounds.iStartChar; iStartChar < bounds.iEndChar; ++iStartChar)
        {
          if (iStartChar >= this.tb[iStartLine].Count)
            continue;
          yield return new Place(iStartChar, iStartLine);
        }
      }
    }
  }
}
