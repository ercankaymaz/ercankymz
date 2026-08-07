// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.FileTextSource
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class FileTextSource : TextSource, IDisposable
{
  internal List<int> list_0 = new List<int>();
  internal FileStream fileStream_0;
  internal Encoding encoding_0;
  private Timer timer_0 = new Timer();

  public event EventHandler<LineNeededEventArgs> LineNeeded;

  public event EventHandler<LinePushedEventArgs> LinePushed;

  public FileTextSource(buMultiTextBox currentTB)
    : base(currentTB)
  {
    this.timer_0.Interval = 10000;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_0.Enabled = true;
    this.SaveEOL = Environment.NewLine;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.timer_0.Enabled = false;
    try
    {
      Class39.smethod_696(this);
    }
    finally
    {
      this.timer_0.Enabled = true;
    }
  }

  public void OpenFile(string fileName, Encoding enc)
  {
    this.Clear();
    if (this.fileStream_0 != null)
      this.fileStream_0.Dispose();
    this.SaveEOL = Environment.NewLine;
    this.fileStream_0 = new FileStream(fileName, FileMode.Open);
    long length = this.fileStream_0.Length;
    enc = Class39.smethod_432(enc, this.fileStream_0);
    Class39.smethod_196(enc, this);
    this.list_0.Add((int) this.fileStream_0.Position);
    this.lines.Add((Line) null);
    this.list_0.Capacity = (int) (length / 7L + 1000L);
    int num1 = 0;
    int num2 = 0;
    BinaryReader binaryReader = new BinaryReader((Stream) this.fileStream_0, enc);
    while (this.fileStream_0.Position < length)
    {
      num2 = (int) this.fileStream_0.Position;
      char ch = binaryReader.ReadChar();
      if (ch == '\n')
      {
        this.list_0.Add((int) this.fileStream_0.Position);
        this.lines.Add((Line) null);
      }
      else if (num1 == 13)
      {
        this.list_0.Add(num2);
        this.lines.Add((Line) null);
        this.SaveEOL = "\r";
      }
      num1 = (int) ch;
    }
    if (num1 == 13)
    {
      this.list_0.Add(num2);
      this.lines.Add((Line) null);
    }
    if (length > 2000000L)
      GC.Collect();
    Line[] collection1 = new Line[100];
    int count1 = this.lines.Count;
    this.lines.AddRange((IEnumerable<Line>) collection1);
    this.lines.TrimExcess();
    this.lines.RemoveRange(count1, collection1.Length);
    int[] collection2 = new int[100];
    int count2 = this.lines.Count;
    this.list_0.AddRange((IEnumerable<int>) collection2);
    this.list_0.TrimExcess();
    this.list_0.RemoveRange(count2, collection1.Length);
    this.encoding_0 = enc;
    this.OnLineInserted(0, this.Count);
    int num3 = Math.Min(this.lines.Count, this.CurrentTB.ClientRectangle.Height / this.CurrentTB.CharHeight);
    for (int int_0 = 0; int_0 < num3; ++int_0)
      Class39.smethod_430(this, int_0);
    this.NeedRecalc(new TextSource.TextChangedEventArgs(0, num3 - 1));
    if (!this.CurrentTB.WordWrap)
      return;
    this.OnRecalcWordWrap(new TextSource.TextChangedEventArgs(0, num3 - 1));
  }

  public void CloseFile()
  {
    if (this.fileStream_0 != null)
    {
      try
      {
        this.fileStream_0.Dispose();
      }
      catch
      {
      }
    }
    this.fileStream_0 = (FileStream) null;
  }

  public string SaveEOL { get; set; }

  public override void SaveToFile(string fileName, Encoding enc)
  {
    List<int> intList = new List<int>(this.Count);
    string str1 = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".tmp");
    StreamReader streamReader_0 = new StreamReader((Stream) this.fileStream_0, this.encoding_0);
    using (FileStream fileStream = new FileStream(str1, FileMode.Create))
    {
      using (StreamWriter streamWriter = new StreamWriter((Stream) fileStream, enc))
      {
        streamWriter.Flush();
        for (int index = 0; index < this.Count; ++index)
        {
          intList.Add((int) fileStream.Length);
          string sourceLineText = Class39.smethod_795(streamReader_0, index, this);
          bool flag;
          string str2 = !(flag = this.lines[index] != null && this.lines[index].IsChanged) ? sourceLineText : this.lines[index].Text;
          // ISSUE: reference to a compiler-generated field
          if (this.eventHandler_8 != null)
          {
            LinePushedEventArgs e = new LinePushedEventArgs(sourceLineText, index, flag ? str2 : (string) null);
            // ISSUE: reference to a compiler-generated field
            this.eventHandler_8((object) this, e);
            if (e.SavedText != null)
              str2 = e.SavedText;
          }
          streamWriter.Write(str2);
          if (index < this.Count - 1)
            streamWriter.Write(this.SaveEOL);
          streamWriter.Flush();
        }
      }
    }
    for (int index = 0; index < this.Count; ++index)
      this.lines[index] = (Line) null;
    streamReader_0.Dispose();
    this.fileStream_0.Dispose();
    if (File.Exists(fileName))
      File.Delete(fileName);
    File.Move(str1, fileName);
    this.list_0 = intList;
    this.fileStream_0 = new FileStream(fileName, FileMode.Open);
    this.encoding_0 = enc;
  }

  public override void ClearIsChanged()
  {
    foreach (Line line in this.lines)
    {
      if (line != null)
        line.IsChanged = false;
    }
  }

  public override Line this[int i]
  {
    get
    {
      Line line;
      if (this.lines[i] != null)
      {
        line = this.lines[i];
      }
      else
      {
        Class39.smethod_430(this, i);
        line = this.lines[i];
      }
      return line;
    }
    set => throw new NotImplementedException();
  }

  public override void InsertLine(int index, Line line)
  {
    this.list_0.Insert(index, -1);
    base.InsertLine(index, line);
  }

  public override void RemoveLine(int index, int count)
  {
    this.list_0.RemoveRange(index, count);
    base.RemoveLine(index, count);
  }

  public override void Clear() => base.Clear();

  public override int GetLineLength(int i) => this.lines[i] != null ? this.lines[i].Count : 0;

  public override bool LineHasFoldingStartMarker(int iLine)
  {
    return this.lines[iLine] != null && !string.IsNullOrEmpty(this.lines[iLine].FoldingStartMarker);
  }

  public override bool LineHasFoldingEndMarker(int iLine)
  {
    return this.lines[iLine] != null && !string.IsNullOrEmpty(this.lines[iLine].FoldingEndMarker);
  }

  public override void Dispose()
  {
    if (this.fileStream_0 != null)
      this.fileStream_0.Dispose();
    this.timer_0.Dispose();
  }
}
