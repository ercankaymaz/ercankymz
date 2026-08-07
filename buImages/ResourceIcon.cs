// Decompiled with JetBrains decompiler
// Type: buImages.ResourceIcon
// Assembly: buImages, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 4BC72BCB-1E38-41C2-AA66-8A319B82EB04
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buImages.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace buImages;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class ResourceIcon
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal ResourceIcon()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public static ResourceManager ResourceManager
  {
    get
    {
      if (ResourceIcon.resourceMan == null)
        ResourceIcon.resourceMan = new ResourceManager("buImages.ResourceIcon", typeof (ResourceIcon).Assembly);
      return ResourceIcon.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public static CultureInfo Culture
  {
    get => ResourceIcon.resourceCulture;
    set => ResourceIcon.resourceCulture = value;
  }

  public static Icon CamContourCenter2
  {
    get
    {
      return (Icon) ResourceIcon.ResourceManager.GetObject(nameof (CamContourCenter2), ResourceIcon.resourceCulture);
    }
  }

  public static Icon CamContourOpenCenter2
  {
    get
    {
      return (Icon) ResourceIcon.ResourceManager.GetObject(nameof (CamContourOpenCenter2), ResourceIcon.resourceCulture);
    }
  }
}
