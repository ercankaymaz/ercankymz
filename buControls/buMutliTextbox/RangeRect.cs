// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.RangeRect
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace buMutliTextbox;

public struct RangeRect(int iStartLine, int iStartChar, int iEndLine, int iEndChar)
{
  public int iStartLine = iStartLine;
  public int iStartChar = iStartChar;
  public int iEndLine = iEndLine;
  public int iEndChar = iEndChar;
}
