// Decompiled with JetBrains decompiler
// Type: System.Microsoft.Extensions.Logging.Abstractions1462476.SR
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Resources;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;

#nullable disable
namespace System;

[NullableContext(1)]
[Nullable(0)]
internal static class Microsoft\u002EExtensions\u002ELogging\u002EAbstractions1462476\u002ESR
{
  private static readonly bool s_usingResourceKeys;
  private static ResourceManager s_resourceManager;

  private static bool UsingResourceKeys()
  {
    return System.Microsoft.Extensions.Logging.Abstractions1462476.SR.s_usingResourceKeys;
  }

  internal static string GetResourceString(string resourceKey)
  {
    if (System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return resourceKey;
    string resourceString = (string) null;
    try
    {
      resourceString = System.Microsoft.Extensions.Logging.Abstractions1462476.SR.ResourceManager.GetString(resourceKey);
    }
    catch (MissingManifestResourceException ex)
    {
    }
    return resourceString;
  }

  internal static string GetResourceString(string resourceKey, string defaultString)
  {
    string resourceString = System.Microsoft.Extensions.Logging.Abstractions1462476.SR.GetResourceString(resourceKey);
    return !(resourceKey == resourceString) && resourceString != null ? resourceString : defaultString;
  }

  internal static string Format(string resourceFormat, [Nullable(2)] object p1)
  {
    if (!System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(string resourceFormat, [Nullable(2)] object p1, [Nullable(2)] object p2)
  {
    if (!System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  internal static string Format([Nullable(1)] string resourceFormat, object p1, object p2, object p3)
  {
    if (!System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static string Format(string resourceFormat, [Nullable(2)] params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(resourceFormat, args);
  }

  internal static string Format([Nullable(2)] IFormatProvider provider, string resourceFormat, [Nullable(2)] object p1)
  {
    if (!System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  internal static string Format(
    IFormatProvider provider,
    [Nullable(1)] string resourceFormat,
    object p1,
    object p2)
  {
    if (!System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  internal static string Format(
    IFormatProvider provider,
    [Nullable(1)] string resourceFormat,
    object p1,
    object p2,
    object p3)
  {
    if (!System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static string Format(
    [Nullable(2)] IFormatProvider provider,
    string resourceFormat,
    [Nullable(2)] params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(provider, resourceFormat, args);
  }

  [Nullable(0)]
  internal static ResourceManager ResourceManager
  {
    [NullableContext(0)] get
    {
      return System.Microsoft.Extensions.Logging.Abstractions1462476.SR.s_resourceManager ?? (System.Microsoft.Extensions.Logging.Abstractions1462476.SR.s_resourceManager = new ResourceManager(typeof (FxResources.Microsoft.Extensions.Logging.Abstractions.SR)));
    }
  }

  [Nullable(0)]
  internal static string UnexpectedNumberOfNamedParameters
  {
    [NullableContext(0)] get
    {
      return System.Microsoft.Extensions.Logging.Abstractions1462476.SR.GetResourceString(nameof (UnexpectedNumberOfNamedParameters));
    }
  }

  static Microsoft\u002EExtensions\u002ELogging\u002EAbstractions1462476\u002ESR()
  {
    bool isEnabled;
    System.Microsoft.Extensions.Logging.Abstractions1462476.SR.s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out isEnabled) && isEnabled;
  }
}
