// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.Utilities
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class Utilities
{
  public static HorizontalAlignment ContentToHorizontalAlignment(ContentAlignment a)
  {
    return !DevAge.Drawing.Utilities.IsLeft(a) ? (!DevAge.Drawing.Utilities.IsRight(a) ? HorizontalAlignment.Center : HorizontalAlignment.Right) : HorizontalAlignment.Left;
  }

  public static TextFormatFlags ContentAligmentToTextFormatFlags(ContentAlignment a)
  {
    TextFormatFlags textFormatFlags1 = TextFormatFlags.Default;
    TextFormatFlags textFormatFlags2 = !DevAge.Drawing.Utilities.IsBottom(a) ? (!DevAge.Drawing.Utilities.IsTop(a) ? textFormatFlags1 | TextFormatFlags.VerticalCenter : textFormatFlags1 | TextFormatFlags.Default) : textFormatFlags1 | TextFormatFlags.Bottom;
    return !DevAge.Drawing.Utilities.IsLeft(a) ? (!DevAge.Drawing.Utilities.IsRight(a) ? textFormatFlags2 | TextFormatFlags.HorizontalCenter : textFormatFlags2 | TextFormatFlags.Right) : textFormatFlags2 | TextFormatFlags.Default;
  }
}
