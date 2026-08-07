// Decompiled with JetBrains decompiler
// Type: System.System.Diagnostics.DiagnosticSource3462135.SR
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Resources;

#nullable disable
namespace System;

internal static class System\u002EDiagnostics\u002EDiagnosticSource3462135\u002ESR
{
  private static readonly bool s_usingResourceKeys;
  private static ResourceManager s_resourceManager;

  private static bool UsingResourceKeys()
  {
    return System.System.Diagnostics.DiagnosticSource3462135.SR.s_usingResourceKeys;
  }

  internal static string GetResourceString(string resourceKey)
  {
    if (System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
      return resourceKey;
    string resourceString = (string) null;
    try
    {
      resourceString = System.System.Diagnostics.DiagnosticSource3462135.SR.ResourceManager.GetString(resourceKey);
    }
    catch (MissingManifestResourceException ex)
    {
    }
    return resourceString;
  }

  internal static string GetResourceString(string resourceKey, string defaultString)
  {
    string resourceString = System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(resourceKey);
    return !(resourceKey == resourceString) && resourceString != null ? resourceString : defaultString;
  }

  internal static string Format(string resourceFormat, object p1)
  {
    if (!System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(string resourceFormat, object p1, object p2)
  {
    if (!System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  internal static string Format(string resourceFormat, object p1, object p2, object p3)
  {
    if (!System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static string Format(string resourceFormat, params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(resourceFormat, args);
  }

  internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
  {
    if (!System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(
    IFormatProvider provider,
    string resourceFormat,
    object p1,
    object p2)
  {
    if (!System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
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
    if (!System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys())
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
    return System.System.Diagnostics.DiagnosticSource3462135.SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(provider, resourceFormat, args);
  }

  internal static ResourceManager ResourceManager
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.s_resourceManager ?? (System.System.Diagnostics.DiagnosticSource3462135.SR.s_resourceManager = new ResourceManager(typeof (FxResources.System.Diagnostics.DiagnosticSource.SR)));
    }
  }

  internal static string ActivityIdFormatInvalid
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (ActivityIdFormatInvalid));
    }
  }

  internal static string ActivityNotRunning
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (ActivityNotRunning));
    }
  }

  internal static string ActivityNotStarted
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (ActivityNotStarted));
    }
  }

  internal static string ActivityStartAlreadyStarted
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (ActivityStartAlreadyStarted));
    }
  }

  internal static string EndTimeNotUtc
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (EndTimeNotUtc));
    }
  }

  internal static string OperationNameInvalid
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (OperationNameInvalid));
    }
  }

  internal static string ParentIdAlreadySet
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (ParentIdAlreadySet));
    }
  }

  internal static string ParentIdInvalid
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (ParentIdInvalid));
    }
  }

  internal static string SetFormatOnStartedActivity
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (SetFormatOnStartedActivity));
    }
  }

  internal static string SetLinkInvalid
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (SetLinkInvalid));
    }
  }

  internal static string SetParentIdOnActivityWithParent
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (SetParentIdOnActivityWithParent));
    }
  }

  internal static string StartTimeNotUtc
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (StartTimeNotUtc));
    }
  }

  internal static string KeyAlreadyExist
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (KeyAlreadyExist));
    }
  }

  internal static string InvalidTraceParent
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (InvalidTraceParent));
    }
  }

  internal static string UnableAccessServicePointTable
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (UnableAccessServicePointTable));
    }
  }

  internal static string UnableToInitialize
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (UnableToInitialize));
    }
  }

  internal static string UnsupportedType
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (UnsupportedType));
    }
  }

  internal static string Arg_BufferTooSmall
  {
    get
    {
      return System.System.Diagnostics.DiagnosticSource3462135.SR.GetResourceString(nameof (Arg_BufferTooSmall));
    }
  }

  static System\u002EDiagnostics\u002EDiagnosticSource3462135\u002ESR()
  {
    bool isEnabled;
    System.System.Diagnostics.DiagnosticSource3462135.SR.s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out isEnabled) && isEnabled;
  }
}
