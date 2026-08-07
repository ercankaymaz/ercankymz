// Decompiled with JetBrains decompiler
// Type: System.System.Memory3568249.SR
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Resources;

#nullable disable
namespace System;

internal static class System\u002EMemory3568249\u002ESR
{
  private static ResourceManager s_resourceManager;

  private static ResourceManager ResourceManager
  {
    get
    {
      return System.System.Memory3568249.SR.s_resourceManager ?? (System.System.Memory3568249.SR.s_resourceManager = new ResourceManager(System.System.Memory3568249.SR.ResourceType));
    }
  }

  private static bool UsingResourceKeys() => false;

  internal static string GetResourceString(string resourceKey, string defaultString)
  {
    string str = (string) null;
    try
    {
      str = System.System.Memory3568249.SR.ResourceManager.GetString(resourceKey);
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
    return System.System.Memory3568249.SR.UsingResourceKeys() ? resourceFormat + string.Join(", ", args) : string.Format(resourceFormat, args);
  }

  internal static string Format(string resourceFormat, object p1)
  {
    if (!System.System.Memory3568249.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(string resourceFormat, object p1, object p2)
  {
    if (!System.System.Memory3568249.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  internal static string Format(string resourceFormat, object p1, object p2, object p3)
  {
    if (!System.System.Memory3568249.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static Type ResourceType { get; } = typeof (FxResources.System.Memory.SR);

  internal static string NotSupported_CannotCallEqualsOnSpan
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (NotSupported_CannotCallEqualsOnSpan), (string) null);
    }
  }

  internal static string NotSupported_CannotCallGetHashCodeOnSpan
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (NotSupported_CannotCallGetHashCodeOnSpan), (string) null);
    }
  }

  internal static string Argument_InvalidTypeWithPointersNotSupported
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_InvalidTypeWithPointersNotSupported), (string) null);
    }
  }

  internal static string Argument_DestinationTooShort
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_DestinationTooShort), (string) null);
    }
  }

  internal static string MemoryDisposed
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (MemoryDisposed), (string) null);
    }
  }

  internal static string OutstandingReferences
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (OutstandingReferences), (string) null);
    }
  }

  internal static string Argument_BadFormatSpecifier
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_BadFormatSpecifier), (string) null);
    }
  }

  internal static string Argument_GWithPrecisionNotSupported
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_GWithPrecisionNotSupported), (string) null);
    }
  }

  internal static string Argument_CannotParsePrecision
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_CannotParsePrecision), (string) null);
    }
  }

  internal static string Argument_PrecisionTooLarge
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_PrecisionTooLarge), (string) null);
    }
  }

  internal static string Argument_OverlapAlignmentMismatch
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (Argument_OverlapAlignmentMismatch), (string) null);
    }
  }

  internal static string EndPositionNotReached
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (EndPositionNotReached), (string) null);
    }
  }

  internal static string UnexpectedSegmentType
  {
    get
    {
      return System.System.Memory3568249.SR.GetResourceString(nameof (UnexpectedSegmentType), (string) null);
    }
  }
}
