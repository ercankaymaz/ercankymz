// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServiceResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServiceResult
{
  private static readonly ServiceResult s_Good = new ServiceResult();
  private uint m_code;
  private string m_symbolicId;
  private string m_namespaceUri;
  private LocalizedText m_localizedText;
  private string m_additionalInfo;
  private ServiceResult m_innerResult;

  private ServiceResult() => this.Code = 0U;

  public ServiceResult(
    StatusCode code,
    string symbolicId,
    string namespaceUri,
    LocalizedText localizedText,
    string additionalInfo,
    ServiceResult innerResult)
  {
    this.StatusCode = code;
    this.SymbolicId = symbolicId;
    this.NamespaceUri = namespaceUri;
    this.LocalizedText = localizedText;
    this.AdditionalInfo = additionalInfo;
    this.InnerResult = innerResult;
  }

  public ServiceResult(ServiceResult outerResult, ServiceResult innerResult = null)
    : this((StatusCode) outerResult.Code, outerResult.SymbolicId, outerResult.NamespaceUri, outerResult.LocalizedText, outerResult.AdditionalInfo, innerResult)
  {
  }

  public ServiceResult(StatusCode code, ServiceResult innerResult)
    : this(code, (string) null, (string) null, (LocalizedText) null, (string) null, innerResult)
  {
  }

  public ServiceResult(
    StatusCode code,
    string symbolicId,
    string namespaceUri,
    LocalizedText localizedText,
    string additionalInfo)
    : this(code, symbolicId, namespaceUri, localizedText, additionalInfo, (ServiceResult) null)
  {
  }

  public ServiceResult(
    StatusCode code,
    string symbolicId,
    string namespaceUri,
    LocalizedText localizedText)
    : this(code, symbolicId, namespaceUri, localizedText, (string) null, (ServiceResult) null)
  {
  }

  public ServiceResult(StatusCode code, string symbolicId, string namespaceUri)
    : this(code, symbolicId, namespaceUri, (LocalizedText) (string) null, (string) null, (ServiceResult) null)
  {
  }

  public ServiceResult(StatusCode code, XmlQualifiedName symbolicId, LocalizedText localizedText)
    : this(code, symbolicId != (XmlQualifiedName) null ? symbolicId.Name : (string) null, symbolicId != (XmlQualifiedName) null ? symbolicId.Namespace : (string) null, localizedText, (string) null, (ServiceResult) null)
  {
  }

  public ServiceResult(StatusCode code, LocalizedText localizedText)
    : this(code, (string) null, (string) null, localizedText, (string) null, (ServiceResult) null)
  {
  }

  public ServiceResult(StatusCode status) => this.m_code = status.Code;

  public ServiceResult(uint code) => this.m_code = code;

  public ServiceResult(
    StatusCode code,
    string symbolicId,
    string namespaceUri,
    LocalizedText localizedText,
    string additionalInfo,
    Exception innerException)
  {
    ServiceResult serviceResult = new ServiceResult(innerException);
    if ((int) code.Code == (int) serviceResult.Code && symbolicId == null && localizedText == (LocalizedText) null && additionalInfo == null)
    {
      this.m_code = serviceResult.Code;
      this.m_symbolicId = serviceResult.SymbolicId;
      this.m_namespaceUri = serviceResult.NamespaceUri;
      this.m_localizedText = serviceResult.LocalizedText;
      this.m_additionalInfo = serviceResult.AdditionalInfo;
      this.m_innerResult = serviceResult.InnerResult;
    }
    else
    {
      this.m_code = code.Code;
      this.m_symbolicId = symbolicId;
      this.m_namespaceUri = namespaceUri;
      this.m_localizedText = localizedText;
      this.m_additionalInfo = additionalInfo;
      this.m_innerResult = serviceResult;
    }
  }

  public ServiceResult(
    StatusCode code,
    string symbolicId,
    string namespaceUri,
    LocalizedText localizedText,
    Exception innerException)
    : this(code, symbolicId, namespaceUri, localizedText, (string) null, innerException)
  {
  }

  public ServiceResult(
    StatusCode code,
    string symbolicId,
    string namespaceUri,
    Exception innerException)
    : this(code, symbolicId, namespaceUri, (LocalizedText) null, (string) null, innerException)
  {
  }

  public ServiceResult(StatusCode code, LocalizedText localizedText, Exception innerException)
    : this(code, (string) null, (string) null, localizedText, (string) null, innerException)
  {
  }

  public ServiceResult(StatusCode code, Exception innerException)
    : this(code, (string) null, (string) null, (LocalizedText) null, (string) null, innerException)
  {
  }

  public ServiceResult(
    Exception e,
    uint defaultCode,
    string defaultSymbolicId,
    string defaultNamespaceUri,
    LocalizedText defaultLocalizedText)
  {
    if (e is ServiceResultException serviceResultException)
    {
      this.m_code = serviceResultException.StatusCode;
      this.m_namespaceUri = serviceResultException.NamespaceUri;
      this.m_symbolicId = serviceResultException.SymbolicId;
      this.m_localizedText = serviceResultException.LocalizedText;
      this.m_innerResult = serviceResultException.Result.InnerResult;
      if (LocalizedText.IsNullOrEmpty(this.m_localizedText))
        this.m_localizedText = defaultLocalizedText;
    }
    else
    {
      this.m_code = defaultCode;
      this.m_symbolicId = defaultSymbolicId;
      this.m_namespaceUri = defaultNamespaceUri;
      this.m_localizedText = defaultLocalizedText;
    }
    this.m_additionalInfo = ServiceResult.BuildExceptionTrace(e);
  }

  public ServiceResult(Exception exception, uint defaultCode, LocalizedText defaultLocalizedText)
    : this(exception, defaultCode, (string) null, (string) null, defaultLocalizedText)
  {
  }

  public ServiceResult(
    Exception exception,
    uint defaultCode,
    string defaultSymbolicId,
    string defaultNamespaceUri)
    : this(exception, defaultCode, defaultSymbolicId, defaultNamespaceUri, (LocalizedText) null)
  {
  }

  public ServiceResult(Exception exception, uint defaultCode)
    : this(exception, defaultCode, (string) null, (string) null, (LocalizedText) ServiceResult.GetDefaultMessage(exception))
  {
  }

  public ServiceResult(Exception exception)
    : this(exception, 2147483648U /*0x80000000*/, (string) null, (string) null, (LocalizedText) ServiceResult.GetDefaultMessage(exception))
  {
  }

  public ServiceResult(StatusCode code, DiagnosticInfo diagnosticInfo, IList<string> stringTable)
  {
    this.m_code = (uint) code;
    if (diagnosticInfo == null)
      return;
    this.m_namespaceUri = ServiceResult.LookupString(stringTable, diagnosticInfo.NamespaceUri);
    this.m_symbolicId = ServiceResult.LookupString(stringTable, diagnosticInfo.SymbolicId);
    this.m_localizedText = new LocalizedText(ServiceResult.LookupString(stringTable, diagnosticInfo.Locale), ServiceResult.LookupString(stringTable, diagnosticInfo.LocalizedText));
    this.m_additionalInfo = diagnosticInfo.AdditionalInfo;
    if (StatusCode.IsGood(diagnosticInfo.InnerStatusCode))
      return;
    this.m_innerResult = new ServiceResult(diagnosticInfo.InnerStatusCode, diagnosticInfo.InnerDiagnosticInfo, stringTable);
  }

  public ServiceResult(
    StatusCode code,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    IList<string> stringTable)
  {
    this.m_code = (uint) code;
    if (index < 0 || diagnosticInfos == null || index >= diagnosticInfos.Count)
      return;
    DiagnosticInfo diagnosticInfo = diagnosticInfos[index];
    if (diagnosticInfo == null)
      return;
    this.m_namespaceUri = ServiceResult.LookupString(stringTable, diagnosticInfo.NamespaceUri);
    this.m_symbolicId = ServiceResult.LookupString(stringTable, diagnosticInfo.SymbolicId);
    this.m_localizedText = new LocalizedText(ServiceResult.LookupString(stringTable, diagnosticInfo.Locale), ServiceResult.LookupString(stringTable, diagnosticInfo.LocalizedText));
    this.m_additionalInfo = diagnosticInfo.AdditionalInfo;
    if (StatusCode.IsGood(diagnosticInfo.InnerStatusCode))
      return;
    this.m_innerResult = new ServiceResult(diagnosticInfo.InnerStatusCode, diagnosticInfo.InnerDiagnosticInfo, stringTable);
  }

  public static ServiceResult Good => ServiceResult.s_Good;

  public static ServiceResult Create(uint code, TranslationInfo translation)
  {
    return translation == null ? new ServiceResult(code) : new ServiceResult((StatusCode) code, new LocalizedText(translation));
  }

  public static ServiceResult Create(Exception e, TranslationInfo translation, uint defaultCode)
  {
    if (e is ServiceResultException serviceResultException)
      defaultCode = serviceResultException.StatusCode;
    return translation == null ? new ServiceResult(e, defaultCode) : new ServiceResult((StatusCode) defaultCode, new LocalizedText(translation), e);
  }

  public static ServiceResult Create(uint code, string format, params object[] args)
  {
    if (format == null)
      return new ServiceResult(code);
    return args != null && args.Length != 0 ? new ServiceResult((StatusCode) code, (LocalizedText) Utils.Format(format, args)) : new ServiceResult((StatusCode) code, (LocalizedText) format);
  }

  public static ServiceResult Create(
    Exception e,
    uint defaultCode,
    string format,
    params object[] args)
  {
    if (e is ServiceResultException serviceResultException)
      defaultCode = serviceResultException.StatusCode;
    if (format == null)
      return new ServiceResult(e, defaultCode);
    return args != null && args.Length != 0 ? new ServiceResult((StatusCode) defaultCode, (LocalizedText) Utils.Format(format, args), e) : new ServiceResult((StatusCode) defaultCode, (LocalizedText) format, e);
  }

  public static bool IsGood(ServiceResult status)
  {
    return status == null || StatusCode.IsGood((StatusCode) status.m_code);
  }

  public static bool IsNotGood(ServiceResult status)
  {
    return status == null || StatusCode.IsNotGood((StatusCode) status.m_code);
  }

  public static bool IsUncertain(ServiceResult status)
  {
    return status != null && StatusCode.IsUncertain((StatusCode) status.m_code);
  }

  public static bool IsNotUncertain(ServiceResult status)
  {
    return status == null || StatusCode.IsNotUncertain((StatusCode) status.m_code);
  }

  public static bool IsBad(ServiceResult status)
  {
    return status != null && StatusCode.IsBad((StatusCode) status.m_code);
  }

  public static bool IsNotBad(ServiceResult status)
  {
    return status == null || StatusCode.IsNotBad((StatusCode) status.m_code);
  }

  public static implicit operator ServiceResult(uint code) => new ServiceResult(code);

  public static implicit operator ServiceResult(StatusCode code) => new ServiceResult(code);

  public static explicit operator uint(ServiceResult status) => status == null ? 0U : status.Code;

  public static string LookupSymbolicId(uint code) => StatusCodes.GetBrowseName(code & 4294901760U);

  public static string BuildExceptionTrace(Exception exception)
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (; exception != null; exception = exception.InnerException)
    {
      if (stringBuilder.Length > 0)
      {
        stringBuilder.AppendLine();
        stringBuilder.AppendLine();
      }
      stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, ">>> {0}", (object) exception.Message);
      if (!string.IsNullOrEmpty(exception.StackTrace))
      {
        string[] strArray = exception.StackTrace.Split(Environment.NewLine.ToCharArray());
        for (int index = 0; index < strArray.Length; ++index)
        {
          if (strArray[index] != null && strArray[index].Length > 0)
          {
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "--- {0}", (object) strArray[index]);
          }
        }
      }
    }
    return stringBuilder.ToString();
  }

  public uint Code
  {
    get => this.m_code;
    private set => this.m_code = value;
  }

  [DataMember(Order = 1)]
  public StatusCode StatusCode
  {
    get => (StatusCode) this.m_code;
    private set => this.m_code = value.Code;
  }

  [DataMember(Order = 2)]
  public string NamespaceUri
  {
    get => this.m_namespaceUri;
    private set => this.m_namespaceUri = value;
  }

  [DataMember(Order = 3)]
  public string SymbolicId
  {
    get => this.m_symbolicId;
    private set => this.m_symbolicId = value;
  }

  [DataMember(Order = 4)]
  public LocalizedText LocalizedText
  {
    get => this.m_localizedText;
    private set => this.m_localizedText = value;
  }

  [DataMember(Order = 5)]
  public string AdditionalInfo
  {
    get => this.m_additionalInfo;
    private set => this.m_additionalInfo = value;
  }

  [DataMember(Order = 6)]
  public ServiceResult InnerResult
  {
    get => this.m_innerResult;
    private set => this.m_innerResult = value;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(ServiceResult.LookupSymbolicId(this.m_code));
    if (!string.IsNullOrEmpty(this.m_symbolicId))
    {
      if (!string.IsNullOrEmpty(this.m_namespaceUri))
        stringBuilder.AppendFormat(" ({0}:{1})", (object) this.m_namespaceUri, (object) this.m_symbolicId);
      else if (this.m_symbolicId != stringBuilder.ToString())
        stringBuilder.AppendFormat(" ({0})", (object) this.m_symbolicId);
    }
    if (!LocalizedText.IsNullOrEmpty(this.m_localizedText))
      stringBuilder.AppendFormat(" '{0}'", (object) this.m_localizedText);
    if (((int) ushort.MaxValue & (int) this.Code) != 0)
      stringBuilder.AppendFormat(" [{0:X4}]", (object) (uint) ((int) ushort.MaxValue & (int) this.Code));
    return stringBuilder.ToString();
  }

  public string ToLongString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("Id: ");
    stringBuilder.Append(StatusCodes.GetBrowseName(this.m_code));
    if (!string.IsNullOrEmpty(this.m_symbolicId))
    {
      stringBuilder.AppendLine();
      stringBuilder.Append("SymbolicId: ");
      stringBuilder.Append(this.m_symbolicId);
    }
    if (!LocalizedText.IsNullOrEmpty(this.m_localizedText))
    {
      stringBuilder.AppendLine();
      stringBuilder.Append("Description: ");
      stringBuilder.Append((object) this.m_localizedText);
    }
    if (this.AdditionalInfo != null && this.AdditionalInfo.Length > 0)
    {
      stringBuilder.AppendLine();
      stringBuilder.Append(this.AdditionalInfo);
    }
    ServiceResult innerResult = this.m_innerResult;
    if (innerResult != null)
    {
      stringBuilder.AppendLine();
      stringBuilder.Append("===");
      stringBuilder.AppendLine();
      stringBuilder.Append(innerResult.ToLongString());
    }
    return stringBuilder.ToString();
  }

  private static string LookupString(IList<string> stringTable, int index)
  {
    return index >= 0 && stringTable != null && index < stringTable.Count ? stringTable[index] : (string) null;
  }

  private static string GetDefaultMessage(Exception exception)
  {
    if (exception == null || exception.Message == null)
      return string.Empty;
    return !exception.Message.StartsWith("[") && !(exception is ServiceResultException) ? string.Format((IFormatProvider) CultureInfo.InvariantCulture, "[{0}] {1}", (object) exception.GetType().Name, (object) exception.Message) : exception.Message;
  }
}
