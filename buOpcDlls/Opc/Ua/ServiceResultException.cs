// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServiceResultException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Opc.Ua;

[DataContract]
[ComVisible(true)]
[Serializable]
public class ServiceResultException : Exception
{
  private ServiceResult m_status;

  public ServiceResultException()
    : base("A UA specific error occurred.")
  {
    this.m_status = (ServiceResult) 2147483648U /*0x80000000*/;
  }

  public ServiceResultException(string message)
    : base(message)
  {
    this.m_status = (ServiceResult) 2147483648U /*0x80000000*/;
  }

  public ServiceResultException(Exception e, uint defaultCode)
    : base(e.Message, e)
  {
    this.m_status = ServiceResult.Create(e, defaultCode, string.Empty);
  }

  public ServiceResultException(string message, Exception e)
    : base(message, e)
  {
    this.m_status = (ServiceResult) 2147483648U /*0x80000000*/;
  }

  public ServiceResultException(uint statusCode)
    : base(ServiceResultException.GetMessage((ServiceResult) statusCode))
  {
    this.m_status = new ServiceResult(statusCode);
  }

  public ServiceResultException(uint statusCode, string message)
    : base(message)
  {
    this.m_status = new ServiceResult((Opc.Ua.StatusCode) statusCode, (LocalizedText) message);
  }

  public ServiceResultException(uint statusCode, Exception e)
    : base(ServiceResultException.GetMessage((ServiceResult) statusCode), e)
  {
    this.m_status = new ServiceResult((Opc.Ua.StatusCode) statusCode, e);
  }

  public ServiceResultException(uint statusCode, string message, Exception e)
    : base(message, e)
  {
    this.m_status = new ServiceResult((Opc.Ua.StatusCode) statusCode, (LocalizedText) message, e);
  }

  public ServiceResultException(ServiceResult status)
    : base(ServiceResultException.GetMessage(status))
  {
    if (status != null)
      this.m_status = status;
    else
      this.m_status = new ServiceResult(2147483648U /*0x80000000*/);
  }

  public uint StatusCode => this.m_status.Code;

  public string NamespaceUri => this.m_status.NamespaceUri;

  public string SymbolicId => this.m_status.SymbolicId;

  public LocalizedText LocalizedText => this.m_status.LocalizedText;

  public string AdditionalInfo => this.m_status.AdditionalInfo;

  public ServiceResult Result => this.m_status;

  public ServiceResult InnerResult => this.m_status.InnerResult;

  public string ToLongString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine(this.Message);
    stringBuilder.Append(this.m_status.ToLongString());
    return stringBuilder.ToString();
  }

  public static ServiceResultException Create(uint code, string format, params object[] args)
  {
    return format == null ? new ServiceResultException(code) : new ServiceResultException(code, Utils.Format(format, args));
  }

  public static ServiceResultException Create(
    uint code,
    Exception e,
    string format,
    params object[] args)
  {
    return format == null ? new ServiceResultException(code, e) : new ServiceResultException(code, Utils.Format(format, args), e);
  }

  public static ServiceResultException Create(
    Opc.Ua.StatusCode code,
    int index,
    DiagnosticInfoCollection diagnosticInfos,
    IList<string> stringTable)
  {
    return new ServiceResultException(new ServiceResult(code, index, diagnosticInfos, stringTable));
  }

  private static string GetMessage(ServiceResult status)
  {
    if (status == null)
      return "A UA specific error occurred.";
    return !LocalizedText.IsNullOrEmpty(status.LocalizedText) ? status.LocalizedText.Text : status.ToString();
  }

  private static class Strings
  {
    public const string DefaultMessage = "A UA specific error occurred.";
  }
}
