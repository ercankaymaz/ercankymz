// Decompiled with JetBrains decompiler
// Type: System.System.Formats.Asn13538873.SR
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Resources;

#nullable disable
namespace System;

internal static class System\u002EFormats\u002EAsn13538873\u002ESR
{
  private static readonly bool s_usingResourceKeys;
  private static ResourceManager s_resourceManager;

  internal static bool UsingResourceKeys()
  {
    return System.System.Formats.Asn13538873.SR.s_usingResourceKeys;
  }

  private static string GetResourceString(string resourceKey)
  {
    if (System.System.Formats.Asn13538873.SR.UsingResourceKeys())
      return resourceKey;
    string resourceString = (string) null;
    try
    {
      resourceString = System.System.Formats.Asn13538873.SR.ResourceManager.GetString(resourceKey);
    }
    catch (MissingManifestResourceException ex)
    {
    }
    return resourceString;
  }

  private static string GetResourceString(string resourceKey, string defaultString)
  {
    string resourceString = System.System.Formats.Asn13538873.SR.GetResourceString(resourceKey);
    return !(resourceKey == resourceString) && resourceString != null ? resourceString : defaultString;
  }

  internal static string Format(string resourceFormat, object p1)
  {
    if (!System.System.Formats.Asn13538873.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(string resourceFormat, object p1, object p2)
  {
    if (!System.System.Formats.Asn13538873.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2);
    return string.Join(", ", (object) resourceFormat, p1, p2);
  }

  internal static string Format(string resourceFormat, object p1, object p2, object p3)
  {
    if (!System.System.Formats.Asn13538873.SR.UsingResourceKeys())
      return string.Format(resourceFormat, p1, p2, p3);
    return string.Join(", ", (object) resourceFormat, p1, p2, p3);
  }

  internal static string Format(string resourceFormat, params object[] args)
  {
    if (args == null)
      return resourceFormat;
    return System.System.Formats.Asn13538873.SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(resourceFormat, args);
  }

  internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
  {
    if (!System.System.Formats.Asn13538873.SR.UsingResourceKeys())
      return string.Format(provider, resourceFormat, p1);
    return string.Join(", ", (object) resourceFormat, p1);
  }

  internal static string Format(
    IFormatProvider provider,
    string resourceFormat,
    object p1,
    object p2)
  {
    if (!System.System.Formats.Asn13538873.SR.UsingResourceKeys())
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
    if (!System.System.Formats.Asn13538873.SR.UsingResourceKeys())
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
    return System.System.Formats.Asn13538873.SR.UsingResourceKeys() ? $"{resourceFormat}, {string.Join(", ", args)}" : string.Format(provider, resourceFormat, args);
  }

  internal static ResourceManager ResourceManager
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.s_resourceManager ?? (System.System.Formats.Asn13538873.SR.s_resourceManager = new ResourceManager(typeof (FxResources.System.Formats.Asn1.SR)));
    }
  }

  internal static string Argument_DestinationTooShort
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_DestinationTooShort));
    }
  }

  internal static string Argument_EnumeratedValueRequiresNonFlagsEnum
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_EnumeratedValueRequiresNonFlagsEnum));
    }
  }

  internal static string Argument_EnumeratedValueBackingTypeNotSupported
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_EnumeratedValueBackingTypeNotSupported));
    }
  }

  internal static string Argument_InvalidOidValue
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_InvalidOidValue));
    }
  }

  internal static string Argument_NamedBitListRequiresFlagsEnum
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_NamedBitListRequiresFlagsEnum));
    }
  }

  internal static string Argument_SourceOverlapsDestination
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_SourceOverlapsDestination));
    }
  }

  internal static string Argument_Tag_NotCharacterString
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_Tag_NotCharacterString));
    }
  }

  internal static string Argument_IntegerCannotBeEmpty
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_IntegerCannotBeEmpty));
    }
  }

  internal static string Argument_IntegerRedundantByte
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_IntegerRedundantByte));
    }
  }

  internal static string Argument_UniversalValueIsFixed
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_UniversalValueIsFixed));
    }
  }

  internal static string Argument_UnusedBitCountMustBeZero
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_UnusedBitCountMustBeZero));
    }
  }

  internal static string Argument_UnusedBitCountRange
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_UnusedBitCountRange));
    }
  }

  internal static string Argument_UnusedBitWasSet
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_UnusedBitWasSet));
    }
  }

  internal static string Argument_WriteEncodedValue_OneValueAtATime
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (Argument_WriteEncodedValue_OneValueAtATime));
    }
  }

  internal static string ArgumentOutOfRange_NeedNonNegNum
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ArgumentOutOfRange_NeedNonNegNum));
    }
  }

  internal static string AsnWriter_EncodeUnbalancedStack
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (AsnWriter_EncodeUnbalancedStack));
    }
  }

  internal static string AsnWriter_PopWrongTag
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (AsnWriter_PopWrongTag));
    }
  }

  internal static string ContentException_CerRequiresIndefiniteLength
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_CerRequiresIndefiniteLength));
    }
  }

  internal static string ContentException_ConstructedEncodingRequired
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_ConstructedEncodingRequired));
    }
  }

  internal static string ContentException_DefaultMessage
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_DefaultMessage));
    }
  }

  internal static string ContentException_EnumeratedValueTooBig
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_EnumeratedValueTooBig));
    }
  }

  internal static string ContentException_InvalidUnderCer_TryBerOrDer
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_InvalidUnderCer_TryBerOrDer));
    }
  }

  internal static string ContentException_InvalidUnderCerOrDer_TryBer
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_InvalidUnderCerOrDer_TryBer));
    }
  }

  internal static string ContentException_InvalidUnderDer_TryBerOrCer
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_InvalidUnderDer_TryBerOrCer));
    }
  }

  internal static string ContentException_InvalidTag
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_InvalidTag));
    }
  }

  internal static string ContentException_LengthExceedsPayload
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_LengthExceedsPayload));
    }
  }

  internal static string ContentException_LengthRuleSetConstraint
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_LengthRuleSetConstraint));
    }
  }

  internal static string ContentException_LengthTooBig
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_LengthTooBig));
    }
  }

  internal static string ContentException_NamedBitListValueTooBig
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_NamedBitListValueTooBig));
    }
  }

  internal static string ContentException_PrimitiveEncodingRequired
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_PrimitiveEncodingRequired));
    }
  }

  internal static string ContentException_SetOfNotSorted
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_SetOfNotSorted));
    }
  }

  internal static string ContentException_TooMuchData
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_TooMuchData));
    }
  }

  internal static string ContentException_WrongTag
  {
    get
    {
      return System.System.Formats.Asn13538873.SR.GetResourceString(nameof (ContentException_WrongTag));
    }
  }

  static System\u002EFormats\u002EAsn13538873\u002ESR()
  {
    bool isEnabled;
    System.System.Formats.Asn13538873.SR.s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out isEnabled) && isEnabled;
  }
}
