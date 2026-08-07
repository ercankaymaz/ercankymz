// Decompiled with JetBrains decompiler
// Type: MarbleCNC.Properties.Resources
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace MarbleCNC.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal Resources()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (MarbleCNC.Properties.Resources.resourceMan == null)
        MarbleCNC.Properties.Resources.resourceMan = new ResourceManager("MarbleCNC.Properties.Resources", typeof (MarbleCNC.Properties.Resources).Assembly);
      return MarbleCNC.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => MarbleCNC.Properties.Resources.resourceCulture;
    set => MarbleCNC.Properties.Resources.resourceCulture = value;
  }
}
