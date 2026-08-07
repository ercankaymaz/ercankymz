// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.Resources
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class Resources
{
  private static Cursor cursor_0;
  private static Cursor cursor_1;

  static Resources()
  {
    using (MemoryStream memoryStream = new MemoryStream(Class39.smethod_585()))
      Resources.cursor_0 = new Cursor((Stream) memoryStream);
    using (MemoryStream memoryStream = new MemoryStream(Class39.smethod_814()))
      Resources.cursor_1 = new Cursor((Stream) memoryStream);
  }

  public static Icon IconSortDown => Class39.smethod_726();

  public static Icon IconSortUp => Class39.smethod_748();

  public static Cursor CursorRightArrow => Resources.cursor_0;

  public static Cursor CursorLeftArrow => Resources.cursor_1;
}
