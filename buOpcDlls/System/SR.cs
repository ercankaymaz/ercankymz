// Decompiled with JetBrains decompiler
// Type: System.SR
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Resources;

#nullable disable
namespace System;

internal static class SR
{
  private static ResourceManager s_resourceManager;

  private static bool UsingResourceKeys() => false;

  internal static string GetResourceString(string resourceKey, string defaultString = null)
  {
    if (SR.UsingResourceKeys())
      return defaultString ?? resourceKey;
    string str = (string) null;
    try
    {
      str = SR.ResourceManager.GetString(resourceKey);
    }
    catch (MissingManifestResourceException ex)
    {
    }
    return defaultString != null && resourceKey.Equals(str) ? defaultString : str;
  }

  internal static string Format(string resourceFormat, object p1)
  {
    if (!SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(string resourceFormat, object p1, object p2)
  {
    if (!SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  internal static string Format(string resourceFormat, object p1, object p2, object p3)
  {
    if (!SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static string Format(string resourceFormat, params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(resourceFormat, args);
  }

  internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
  {
    if (!SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(
    IFormatProvider provider,
    string resourceFormat,
    object p1,
    object p2)
  {
    if (!SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  internal static string Format(
    IFormatProvider provider,
    string resourceFormat,
    object p1,
    object p2,
    object p3)
  {
    if (!SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static string Format(
    IFormatProvider provider,
    string resourceFormat,
    params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(provider, resourceFormat, args);
  }

  internal static ResourceManager ResourceManager
  {
    get => SR.s_resourceManager ?? (SR.s_resourceManager = new ResourceManager(typeof (FxResources.Microsoft.Bcl.HashCode.SR)));
  }

  internal static string HashCode_EqualityNotSupported
  {
    get => SR.GetResourceString(nameof (HashCode_EqualityNotSupported));
  }

  internal static string HashCode_HashCodeNotSupported
  {
    get => SR.GetResourceString(nameof (HashCode_HashCodeNotSupported));
  }
}
