// Decompiled with JetBrains decompiler
// Type: System.System.Buffers3459908.SR
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Resources;

#nullable disable
namespace System;

internal static class System\u002EBuffers3459908\u002ESR
{
  private static ResourceManager s_resourceManager;

  private static ResourceManager ResourceManager
  {
    get
    {
      return System.System.Buffers3459908.SR.s_resourceManager ?? (System.System.Buffers3459908.SR.s_resourceManager = new ResourceManager(System.System.Buffers3459908.SR.ResourceType));
    }
  }

  private static bool UsingResourceKeys() => false;

  internal static string GetResourceString(string resourceKey, string defaultString)
  {
    string str = (string) null;
    try
    {
      str = System.System.Buffers3459908.SR.ResourceManager.GetString(resourceKey);
    }
    catch (MissingManifestResourceException ex)
    {
    }
    return defaultString != null && resourceKey.Equals(str, StringComparison.Ordinal) ? defaultString : str;
  }

  internal static string Format(string resourceFormat, params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return System.System.Buffers3459908.SR.UsingResourceKeys() ? resourceFormat + string.Join(", ", args) : string.Format(resourceFormat, args);
  }

  internal static string Format(string resourceFormat, object p1)
  {
    if (!System.System.Buffers3459908.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(string resourceFormat, object p1, object p2)
  {
    if (!System.System.Buffers3459908.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  internal static string Format(string resourceFormat, object p1, object p2, object p3)
  {
    if (!System.System.Buffers3459908.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static Type ResourceType { get; } = typeof (FxResources.System.Buffers.SR);

  internal static string ArgumentException_BufferNotFromPool
  {
    get
    {
      return System.System.Buffers3459908.SR.GetResourceString(nameof (ArgumentException_BufferNotFromPool), (string) null);
    }
  }
}
