using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

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

	public static ServiceResult Good => s_Good;

	public uint Code
	{
		get
		{
			return m_code;
		}
		private set
		{
			m_code = value;
		}
	}

	[DataMember(Order = 1)]
	public StatusCode StatusCode
	{
		get
		{
			return m_code;
		}
		private set
		{
			m_code = value.Code;
		}
	}

	[DataMember(Order = 2)]
	public string NamespaceUri
	{
		get
		{
			return m_namespaceUri;
		}
		private set
		{
			m_namespaceUri = value;
		}
	}

	[DataMember(Order = 3)]
	public string SymbolicId
	{
		get
		{
			return m_symbolicId;
		}
		private set
		{
			m_symbolicId = value;
		}
	}

	[DataMember(Order = 4)]
	public LocalizedText LocalizedText
	{
		get
		{
			return m_localizedText;
		}
		private set
		{
			m_localizedText = value;
		}
	}

	[DataMember(Order = 5)]
	public string AdditionalInfo
	{
		get
		{
			return m_additionalInfo;
		}
		private set
		{
			m_additionalInfo = value;
		}
	}

	[DataMember(Order = 6)]
	public ServiceResult InnerResult
	{
		get
		{
			return m_innerResult;
		}
		private set
		{
			m_innerResult = value;
		}
	}

	private ServiceResult()
	{
		Code = 0u;
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri, LocalizedText localizedText, string additionalInfo, ServiceResult innerResult)
	{
		StatusCode = code;
		SymbolicId = symbolicId;
		NamespaceUri = namespaceUri;
		LocalizedText = localizedText;
		AdditionalInfo = additionalInfo;
		InnerResult = innerResult;
	}

	public ServiceResult(ServiceResult outerResult, ServiceResult innerResult = null)
		: this(outerResult.Code, outerResult.SymbolicId, outerResult.NamespaceUri, outerResult.LocalizedText, outerResult.AdditionalInfo, innerResult)
	{
	}

	public ServiceResult(StatusCode code, ServiceResult innerResult)
		: this(code, null, null, null, null, innerResult)
	{
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri, LocalizedText localizedText, string additionalInfo)
		: this(code, symbolicId, namespaceUri, localizedText, additionalInfo, (ServiceResult)null)
	{
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri, LocalizedText localizedText)
		: this(code, symbolicId, namespaceUri, localizedText, (string)null, (ServiceResult)null)
	{
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri)
		: this(code, symbolicId, namespaceUri, (LocalizedText)(string)null, (string)null, (ServiceResult)null)
	{
	}

	public ServiceResult(StatusCode code, XmlQualifiedName symbolicId, LocalizedText localizedText)
		: this(code, (symbolicId != null) ? symbolicId.Name : null, (symbolicId != null) ? symbolicId.Namespace : null, localizedText, (string)null, (ServiceResult)null)
	{
	}

	public ServiceResult(StatusCode code, LocalizedText localizedText)
		: this(code, (string)null, (string)null, localizedText, (string)null, (ServiceResult)null)
	{
	}

	public ServiceResult(StatusCode status)
	{
		m_code = status.Code;
	}

	public ServiceResult(uint code)
	{
		m_code = code;
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri, LocalizedText localizedText, string additionalInfo, Exception innerException)
	{
		ServiceResult serviceResult = new ServiceResult(innerException);
		if (code.Code == serviceResult.Code && symbolicId == null && localizedText == null && additionalInfo == null)
		{
			m_code = serviceResult.Code;
			m_symbolicId = serviceResult.SymbolicId;
			m_namespaceUri = serviceResult.NamespaceUri;
			m_localizedText = serviceResult.LocalizedText;
			m_additionalInfo = serviceResult.AdditionalInfo;
			m_innerResult = serviceResult.InnerResult;
		}
		else
		{
			m_code = code.Code;
			m_symbolicId = symbolicId;
			m_namespaceUri = namespaceUri;
			m_localizedText = localizedText;
			m_additionalInfo = additionalInfo;
			m_innerResult = serviceResult;
		}
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri, LocalizedText localizedText, Exception innerException)
		: this(code, symbolicId, namespaceUri, localizedText, null, innerException)
	{
	}

	public ServiceResult(StatusCode code, string symbolicId, string namespaceUri, Exception innerException)
		: this(code, symbolicId, namespaceUri, null, null, innerException)
	{
	}

	public ServiceResult(StatusCode code, LocalizedText localizedText, Exception innerException)
		: this(code, null, null, localizedText, null, innerException)
	{
	}

	public ServiceResult(StatusCode code, Exception innerException)
		: this(code, null, null, null, null, innerException)
	{
	}

	public ServiceResult(Exception e, uint defaultCode, string defaultSymbolicId, string defaultNamespaceUri, LocalizedText defaultLocalizedText)
	{
		if (e is ServiceResultException ex)
		{
			m_code = ex.StatusCode;
			m_namespaceUri = ex.NamespaceUri;
			m_symbolicId = ex.SymbolicId;
			m_localizedText = ex.LocalizedText;
			m_innerResult = ex.Result.InnerResult;
			if (LocalizedText.IsNullOrEmpty(m_localizedText))
			{
				m_localizedText = defaultLocalizedText;
			}
		}
		else
		{
			m_code = defaultCode;
			m_symbolicId = defaultSymbolicId;
			m_namespaceUri = defaultNamespaceUri;
			m_localizedText = defaultLocalizedText;
		}
		m_additionalInfo = BuildExceptionTrace(e);
	}

	public ServiceResult(Exception exception, uint defaultCode, LocalizedText defaultLocalizedText)
		: this(exception, defaultCode, null, null, defaultLocalizedText)
	{
	}

	public ServiceResult(Exception exception, uint defaultCode, string defaultSymbolicId, string defaultNamespaceUri)
		: this(exception, defaultCode, defaultSymbolicId, defaultNamespaceUri, null)
	{
	}

	public ServiceResult(Exception exception, uint defaultCode)
		: this(exception, defaultCode, null, null, GetDefaultMessage(exception))
	{
	}

	public ServiceResult(Exception exception)
		: this(exception, 2147483648u, null, null, GetDefaultMessage(exception))
	{
	}

	public ServiceResult(StatusCode code, DiagnosticInfo diagnosticInfo, IList<string> stringTable)
	{
		m_code = (uint)code;
		if (diagnosticInfo != null)
		{
			m_namespaceUri = LookupString(stringTable, diagnosticInfo.NamespaceUri);
			m_symbolicId = LookupString(stringTable, diagnosticInfo.SymbolicId);
			string locale = LookupString(stringTable, diagnosticInfo.Locale);
			string text = LookupString(stringTable, diagnosticInfo.LocalizedText);
			m_localizedText = new LocalizedText(locale, text);
			m_additionalInfo = diagnosticInfo.AdditionalInfo;
			if (!StatusCode.IsGood(diagnosticInfo.InnerStatusCode))
			{
				m_innerResult = new ServiceResult(diagnosticInfo.InnerStatusCode, diagnosticInfo.InnerDiagnosticInfo, stringTable);
			}
		}
	}

	public ServiceResult(StatusCode code, int index, DiagnosticInfoCollection diagnosticInfos, IList<string> stringTable)
	{
		m_code = (uint)code;
		if (index < 0 || diagnosticInfos == null || index >= diagnosticInfos.Count)
		{
			return;
		}
		DiagnosticInfo diagnosticInfo = diagnosticInfos[index];
		if (diagnosticInfo != null)
		{
			m_namespaceUri = LookupString(stringTable, diagnosticInfo.NamespaceUri);
			m_symbolicId = LookupString(stringTable, diagnosticInfo.SymbolicId);
			string locale = LookupString(stringTable, diagnosticInfo.Locale);
			string text = LookupString(stringTable, diagnosticInfo.LocalizedText);
			m_localizedText = new LocalizedText(locale, text);
			m_additionalInfo = diagnosticInfo.AdditionalInfo;
			if (!StatusCode.IsGood(diagnosticInfo.InnerStatusCode))
			{
				m_innerResult = new ServiceResult(diagnosticInfo.InnerStatusCode, diagnosticInfo.InnerDiagnosticInfo, stringTable);
			}
		}
	}

	public static ServiceResult Create(uint code, TranslationInfo translation)
	{
		if (translation == null)
		{
			return new ServiceResult(code);
		}
		return new ServiceResult(code, new LocalizedText(translation));
	}

	public static ServiceResult Create(Exception e, TranslationInfo translation, uint defaultCode)
	{
		if (e is ServiceResultException ex)
		{
			defaultCode = ex.StatusCode;
		}
		if (translation == null)
		{
			return new ServiceResult(e, defaultCode);
		}
		return new ServiceResult(defaultCode, new LocalizedText(translation), e);
	}

	public static ServiceResult Create(uint code, string format, params object[] args)
	{
		if (format == null)
		{
			return new ServiceResult(code);
		}
		if (args == null || args.Length == 0)
		{
			return new ServiceResult(code, format);
		}
		return new ServiceResult(code, Utils.Format(format, args));
	}

	public static ServiceResult Create(Exception e, uint defaultCode, string format, params object[] args)
	{
		if (e is ServiceResultException ex)
		{
			defaultCode = ex.StatusCode;
		}
		if (format == null)
		{
			return new ServiceResult(e, defaultCode);
		}
		if (args == null || args.Length == 0)
		{
			return new ServiceResult(defaultCode, format, e);
		}
		return new ServiceResult(defaultCode, Utils.Format(format, args), e);
	}

	public static bool IsGood(ServiceResult status)
	{
		if (status != null)
		{
			return StatusCode.IsGood(status.m_code);
		}
		return true;
	}

	public static bool IsNotGood(ServiceResult status)
	{
		if (status != null)
		{
			return StatusCode.IsNotGood(status.m_code);
		}
		return true;
	}

	public static bool IsUncertain(ServiceResult status)
	{
		if (status != null)
		{
			return StatusCode.IsUncertain(status.m_code);
		}
		return false;
	}

	public static bool IsNotUncertain(ServiceResult status)
	{
		if (status != null)
		{
			return StatusCode.IsNotUncertain(status.m_code);
		}
		return true;
	}

	public static bool IsBad(ServiceResult status)
	{
		if (status != null)
		{
			return StatusCode.IsBad(status.m_code);
		}
		return false;
	}

	public static bool IsNotBad(ServiceResult status)
	{
		if (status != null)
		{
			return StatusCode.IsNotBad(status.m_code);
		}
		return true;
	}

	public static implicit operator ServiceResult(uint code)
	{
		return new ServiceResult(code);
	}

	public static implicit operator ServiceResult(StatusCode code)
	{
		return new ServiceResult(code);
	}

	public static explicit operator uint(ServiceResult status)
	{
		return status?.Code ?? 0;
	}

	public static string LookupSymbolicId(uint code)
	{
		return StatusCodes.GetBrowseName(code & 0xFFFF0000u);
	}

	public static string BuildExceptionTrace(Exception exception)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (exception != null)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine();
			}
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, ">>> {0}", exception.Message);
			if (!string.IsNullOrEmpty(exception.StackTrace))
			{
				string[] array = exception.StackTrace.Split(Environment.NewLine.ToCharArray());
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null && array[i].Length > 0)
					{
						stringBuilder.AppendLine();
						stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "--- {0}", array[i]);
					}
				}
			}
			exception = exception.InnerException;
		}
		return stringBuilder.ToString();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LookupSymbolicId(m_code));
		if (!string.IsNullOrEmpty(m_symbolicId))
		{
			if (!string.IsNullOrEmpty(m_namespaceUri))
			{
				stringBuilder.AppendFormat(" ({0}:{1})", m_namespaceUri, m_symbolicId);
			}
			else if (m_symbolicId != stringBuilder.ToString())
			{
				stringBuilder.AppendFormat(" ({0})", m_symbolicId);
			}
		}
		if (!LocalizedText.IsNullOrEmpty(m_localizedText))
		{
			stringBuilder.AppendFormat(" '{0}'", m_localizedText);
		}
		if ((0xFFFF & Code) != 0)
		{
			stringBuilder.AppendFormat(" [{0:X4}]", 0xFFFF & Code);
		}
		return stringBuilder.ToString();
	}

	public string ToLongString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Id: ");
		stringBuilder.Append(StatusCodes.GetBrowseName(m_code));
		if (!string.IsNullOrEmpty(m_symbolicId))
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("SymbolicId: ");
			stringBuilder.Append(m_symbolicId);
		}
		if (!LocalizedText.IsNullOrEmpty(m_localizedText))
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("Description: ");
			stringBuilder.Append(m_localizedText);
		}
		if (AdditionalInfo != null && AdditionalInfo.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append(AdditionalInfo);
		}
		ServiceResult innerResult = m_innerResult;
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
		if (index < 0 || stringTable == null || index >= stringTable.Count)
		{
			return null;
		}
		return stringTable[index];
	}

	private static string GetDefaultMessage(Exception exception)
	{
		if (exception != null && exception.Message != null)
		{
			if (exception.Message.StartsWith("[") || exception is ServiceResultException)
			{
				return exception.Message;
			}
			return string.Format(CultureInfo.InvariantCulture, "[{0}] {1}", exception.GetType().Name, exception.Message);
		}
		return string.Empty;
	}
}
