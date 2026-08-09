using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[Serializable]
[DataContract]
[ComVisible(true)]
public class ServiceResultException : Exception
{
	private static class Strings
	{
		public const string DefaultMessage = "A UA specific error occurred.";
	}

	private ServiceResult m_status;

	public uint StatusCode => m_status.Code;

	public string NamespaceUri => m_status.NamespaceUri;

	public string SymbolicId => m_status.SymbolicId;

	public LocalizedText LocalizedText => m_status.LocalizedText;

	public string AdditionalInfo => m_status.AdditionalInfo;

	public ServiceResult Result => m_status;

	public ServiceResult InnerResult => m_status.InnerResult;

	public ServiceResultException()
		: base("A UA specific error occurred.")
	{
		m_status = 2147483648u;
	}

	public ServiceResultException(string message)
		: base(message)
	{
		m_status = 2147483648u;
	}

	public ServiceResultException(Exception e, uint defaultCode)
		: base(e.Message, e)
	{
		m_status = ServiceResult.Create(e, defaultCode, string.Empty);
	}

	public ServiceResultException(string message, Exception e)
		: base(message, e)
	{
		m_status = 2147483648u;
	}

	public ServiceResultException(uint statusCode)
		: base(GetMessage(statusCode))
	{
		m_status = new ServiceResult(statusCode);
	}

	public ServiceResultException(uint statusCode, string message)
		: base(message)
	{
		m_status = new ServiceResult(statusCode, message);
	}

	public ServiceResultException(uint statusCode, Exception e)
		: base(GetMessage(statusCode), e)
	{
		m_status = new ServiceResult(statusCode, e);
	}

	public ServiceResultException(uint statusCode, string message, Exception e)
		: base(message, e)
	{
		m_status = new ServiceResult(statusCode, message, e);
	}

	public ServiceResultException(ServiceResult status)
		: base(GetMessage(status))
	{
		if (status != null)
		{
			m_status = status;
		}
		else
		{
			m_status = new ServiceResult(2147483648u);
		}
	}

	public string ToLongString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(Message);
		stringBuilder.Append(m_status.ToLongString());
		return stringBuilder.ToString();
	}

	public static ServiceResultException Create(uint code, string format, params object[] args)
	{
		if (format == null)
		{
			return new ServiceResultException(code);
		}
		return new ServiceResultException(code, Utils.Format(format, args));
	}

	public static ServiceResultException Create(uint code, Exception e, string format, params object[] args)
	{
		if (format == null)
		{
			return new ServiceResultException(code, e);
		}
		return new ServiceResultException(code, Utils.Format(format, args), e);
	}

	public static ServiceResultException Create(StatusCode code, int index, DiagnosticInfoCollection diagnosticInfos, IList<string> stringTable)
	{
		return new ServiceResultException(new ServiceResult(code, index, diagnosticInfos, stringTable));
	}

	private static string GetMessage(ServiceResult status)
	{
		if (status == null)
		{
			return "A UA specific error occurred.";
		}
		if (!LocalizedText.IsNullOrEmpty(status.LocalizedText))
		{
			return status.LocalizedText.Text;
		}
		return status.ToString();
	}
}
