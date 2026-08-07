// Decompiled with JetBrains decompiler
// Type: buClass.Properties.Resource1
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace buClass.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resource1
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal Resource1()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (Resource1.resourceMan == null)
        Resource1.resourceMan = new ResourceManager("buClass.Properties.Resource1", typeof (Resource1).Assembly);
      return Resource1.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => Resource1.resourceCulture;
    set => Resource1.resourceCulture = value;
  }
}
