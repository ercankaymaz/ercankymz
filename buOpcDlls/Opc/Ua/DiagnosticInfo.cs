// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiagnosticInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public sealed class DiagnosticInfo : ICloneable, IFormattable
{
  public static readonly int MaxInnerDepth = 5;
  private int m_symbolicId;
  private int m_namespaceUri;
  private int m_locale;
  private int m_localizedText;
  private string m_additionalInfo;
  private StatusCode m_innerStatusCode;
  private DiagnosticInfo m_innerDiagnosticInfo;

  public DiagnosticInfo() => this.Initialize();

  public DiagnosticInfo(DiagnosticInfo value)
    : this(value, 0)
  {
  }

  private DiagnosticInfo(DiagnosticInfo value, int depth)
  {
    this.m_symbolicId = value != null ? value.m_symbolicId : throw new ArgumentNullException(nameof (value));
    this.m_namespaceUri = value.m_namespaceUri;
    this.m_locale = value.m_locale;
    this.m_localizedText = value.m_localizedText;
    this.m_additionalInfo = value.m_additionalInfo;
    this.m_innerStatusCode = value.m_innerStatusCode;
    if (value.m_innerDiagnosticInfo == null || depth >= DiagnosticInfo.MaxInnerDepth)
      return;
    this.m_innerDiagnosticInfo = new DiagnosticInfo(value.m_innerDiagnosticInfo, depth + 1);
  }

  public DiagnosticInfo(
    int symbolicId,
    int namespaceUri,
    int locale,
    int localizedText,
    string additionalInfo)
  {
    this.m_symbolicId = symbolicId;
    this.m_namespaceUri = namespaceUri;
    this.m_locale = locale;
    this.m_localizedText = localizedText;
    this.m_additionalInfo = additionalInfo;
  }

  public DiagnosticInfo(
    ServiceResult result,
    DiagnosticsMasks diagnosticsMask,
    bool serviceLevel,
    StringTable stringTable)
    : this(result, diagnosticsMask, serviceLevel, stringTable, 0)
  {
  }

  private DiagnosticInfo(
    ServiceResult result,
    DiagnosticsMasks diagnosticsMask,
    bool serviceLevel,
    StringTable stringTable,
    int depth)
  {
    uint num = (uint) diagnosticsMask;
    if (!serviceLevel)
      num >>= 5;
    diagnosticsMask = (DiagnosticsMasks) num;
    this.Initialize(result, diagnosticsMask, stringTable, depth);
  }

  public DiagnosticInfo(
    Exception exception,
    DiagnosticsMasks diagnosticsMask,
    bool serviceLevel,
    StringTable stringTable)
  {
    uint num = (uint) diagnosticsMask;
    if (!serviceLevel)
      num >>= 5;
    diagnosticsMask = (DiagnosticsMasks) num;
    this.Initialize(new ServiceResult(exception), diagnosticsMask, stringTable, 0);
  }

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_symbolicId = -1;
    this.m_namespaceUri = -1;
    this.m_locale = -1;
    this.m_localizedText = -1;
    this.m_additionalInfo = (string) null;
    this.m_innerStatusCode = (StatusCode) 0U;
    this.m_innerDiagnosticInfo = (DiagnosticInfo) null;
  }

  private void Initialize(
    ServiceResult result,
    DiagnosticsMasks diagnosticsMask,
    StringTable stringTable,
    int depth)
  {
    if (stringTable == null)
      throw new ArgumentNullException(nameof (stringTable));
    this.Initialize();
    if ((DiagnosticsMasks.ServiceSymbolicId & diagnosticsMask) != DiagnosticsMasks.None)
    {
      string symbolicId = result.SymbolicId;
      string namespaceUri = result.NamespaceUri;
      if (!string.IsNullOrEmpty(symbolicId))
      {
        this.m_symbolicId = stringTable.GetIndex(result.SymbolicId);
        if (this.m_symbolicId == -1)
        {
          this.m_symbolicId = stringTable.Count;
          stringTable.Append(symbolicId);
        }
        if (!string.IsNullOrEmpty(namespaceUri))
        {
          this.m_namespaceUri = stringTable.GetIndex(namespaceUri);
          if (this.m_namespaceUri == -1)
          {
            this.m_namespaceUri = stringTable.Count;
            stringTable.Append(namespaceUri);
          }
        }
      }
    }
    if ((DiagnosticsMasks.ServiceLocalizedText & diagnosticsMask) != DiagnosticsMasks.None && !Opc.Ua.LocalizedText.IsNullOrEmpty(result.LocalizedText))
    {
      if (!string.IsNullOrEmpty(result.LocalizedText.Locale))
      {
        this.m_locale = stringTable.GetIndex(result.LocalizedText.Locale);
        if (this.m_locale == -1)
        {
          this.m_locale = stringTable.Count;
          stringTable.Append(result.LocalizedText.Locale);
        }
      }
      this.m_localizedText = stringTable.GetIndex(result.LocalizedText.Text);
      if (this.m_localizedText == -1)
      {
        this.m_localizedText = stringTable.Count;
        stringTable.Append(result.LocalizedText.Text);
      }
    }
    if ((DiagnosticsMasks.ServiceAdditionalInfo & diagnosticsMask) != DiagnosticsMasks.None && (DiagnosticsMasks.UserPermissionAdditionalInfo & diagnosticsMask) != DiagnosticsMasks.None)
      this.m_additionalInfo = result.AdditionalInfo;
    if (result.InnerResult == null)
      return;
    if ((DiagnosticsMasks.ServiceInnerStatusCode & diagnosticsMask) != DiagnosticsMasks.None)
      this.m_innerStatusCode = result.InnerResult.StatusCode;
    if ((DiagnosticsMasks.ServiceInnerDiagnostics & diagnosticsMask) == DiagnosticsMasks.None)
      return;
    if (depth < DiagnosticInfo.MaxInnerDepth)
      this.m_innerDiagnosticInfo = new DiagnosticInfo(result.InnerResult, diagnosticsMask, true, stringTable, depth + 1);
    else
      Utils.LogWarning("Inner diagnostics truncated. Max depth of {0} exceeded.", (object) DiagnosticInfo.MaxInnerDepth);
  }

  [DataMember(Order = 1, IsRequired = false)]
  public int SymbolicId
  {
    get => this.m_symbolicId;
    set => this.m_symbolicId = value;
  }

  [DataMember(Order = 2, IsRequired = false)]
  public int NamespaceUri
  {
    get => this.m_namespaceUri;
    set => this.m_namespaceUri = value;
  }

  [DataMember(Order = 3, IsRequired = false)]
  public int Locale
  {
    get => this.m_locale;
    set => this.m_locale = value;
  }

  [DataMember(Order = 4, IsRequired = false)]
  public int LocalizedText
  {
    get => this.m_localizedText;
    set => this.m_localizedText = value;
  }

  [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
  public string AdditionalInfo
  {
    get => this.m_additionalInfo;
    set => this.m_additionalInfo = value;
  }

  [DataMember(Order = 6, IsRequired = false)]
  public StatusCode InnerStatusCode
  {
    get => this.m_innerStatusCode;
    set => this.m_innerStatusCode = value;
  }

  [DataMember(Order = 7, IsRequired = false, EmitDefaultValue = false)]
  public DiagnosticInfo InnerDiagnosticInfo
  {
    get => this.m_innerDiagnosticInfo;
    set => this.m_innerDiagnosticInfo = value;
  }

  public bool IsNullDiagnosticInfo
  {
    get
    {
      return this.m_symbolicId == -1 && this.m_locale == -1 && this.m_localizedText == -1 && this.m_namespaceUri == -1 && this.m_additionalInfo == null && this.m_innerDiagnosticInfo == null && this.m_innerStatusCode == 0U;
    }
  }

  public override bool Equals(object obj) => this.Equals(obj, 0);

  public override int GetHashCode()
  {
    HashCode hash = new HashCode();
    this.GetHashCode(ref hash, 0);
    return hash.ToHashCode();
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return Utils.Format("{0}:{1}:{2}:{3}", (object) this.m_symbolicId, (object) this.m_namespaceUri, (object) this.m_locale, (object) this.m_localizedText);
  }

  public object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new DiagnosticInfo(this);

  private void GetHashCode(ref HashCode hash, int depth)
  {
    hash.Add<int>(this.m_symbolicId);
    hash.Add<int>(this.m_namespaceUri);
    hash.Add<int>(this.m_locale);
    hash.Add<int>(this.m_localizedText);
    if (this.m_additionalInfo != null)
      hash.Add<string>(this.m_additionalInfo);
    hash.Add<StatusCode>(this.m_innerStatusCode);
    if (this.m_innerDiagnosticInfo == null || depth >= DiagnosticInfo.MaxInnerDepth)
      return;
    this.m_innerDiagnosticInfo.GetHashCode(ref hash, depth + 1);
  }

  private bool Equals(object obj, int depth)
  {
    if (this == obj || obj == null && this.IsNullDiagnosticInfo)
      return true;
    if (!(obj is DiagnosticInfo diagnosticInfo) || this.m_symbolicId != diagnosticInfo.m_symbolicId || this.m_namespaceUri != diagnosticInfo.m_namespaceUri || this.m_locale != diagnosticInfo.m_locale || this.m_localizedText != diagnosticInfo.m_localizedText || this.m_additionalInfo != diagnosticInfo.m_additionalInfo || this.m_innerStatusCode != diagnosticInfo.m_innerStatusCode)
      return false;
    if (this.m_innerDiagnosticInfo == null)
      return diagnosticInfo.m_innerDiagnosticInfo == null;
    return depth >= DiagnosticInfo.MaxInnerDepth || this.m_innerDiagnosticInfo.Equals((object) diagnosticInfo.m_innerDiagnosticInfo, depth + 1);
  }
}
