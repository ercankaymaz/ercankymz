using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	[DataMember(Order = 1, IsRequired = false)]
	public int SymbolicId
	{
		get
		{
			return m_symbolicId;
		}
		set
		{
			m_symbolicId = value;
		}
	}

	[DataMember(Order = 2, IsRequired = false)]
	public int NamespaceUri
	{
		get
		{
			return m_namespaceUri;
		}
		set
		{
			m_namespaceUri = value;
		}
	}

	[DataMember(Order = 3, IsRequired = false)]
	public int Locale
	{
		get
		{
			return m_locale;
		}
		set
		{
			m_locale = value;
		}
	}

	[DataMember(Order = 4, IsRequired = false)]
	public int LocalizedText
	{
		get
		{
			return m_localizedText;
		}
		set
		{
			m_localizedText = value;
		}
	}

	[DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
	public string AdditionalInfo
	{
		get
		{
			return m_additionalInfo;
		}
		set
		{
			m_additionalInfo = value;
		}
	}

	[DataMember(Order = 6, IsRequired = false)]
	public StatusCode InnerStatusCode
	{
		get
		{
			return m_innerStatusCode;
		}
		set
		{
			m_innerStatusCode = value;
		}
	}

	[DataMember(Order = 7, IsRequired = false, EmitDefaultValue = false)]
	public DiagnosticInfo InnerDiagnosticInfo
	{
		get
		{
			return m_innerDiagnosticInfo;
		}
		set
		{
			m_innerDiagnosticInfo = value;
		}
	}

	public bool IsNullDiagnosticInfo
	{
		get
		{
			if (m_symbolicId == -1 && m_locale == -1 && m_localizedText == -1 && m_namespaceUri == -1 && m_additionalInfo == null && m_innerDiagnosticInfo == null && m_innerStatusCode == 0u)
			{
				return true;
			}
			return false;
		}
	}

	public DiagnosticInfo()
	{
		Initialize();
	}

	public DiagnosticInfo(DiagnosticInfo value)
		: this(value, 0)
	{
	}

	private DiagnosticInfo(DiagnosticInfo value, int depth)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_symbolicId = value.m_symbolicId;
		m_namespaceUri = value.m_namespaceUri;
		m_locale = value.m_locale;
		m_localizedText = value.m_localizedText;
		m_additionalInfo = value.m_additionalInfo;
		m_innerStatusCode = value.m_innerStatusCode;
		if (value.m_innerDiagnosticInfo != null && depth < MaxInnerDepth)
		{
			m_innerDiagnosticInfo = new DiagnosticInfo(value.m_innerDiagnosticInfo, depth + 1);
		}
	}

	public DiagnosticInfo(int symbolicId, int namespaceUri, int locale, int localizedText, string additionalInfo)
	{
		m_symbolicId = symbolicId;
		m_namespaceUri = namespaceUri;
		m_locale = locale;
		m_localizedText = localizedText;
		m_additionalInfo = additionalInfo;
	}

	public DiagnosticInfo(ServiceResult result, DiagnosticsMasks diagnosticsMask, bool serviceLevel, StringTable stringTable)
		: this(result, diagnosticsMask, serviceLevel, stringTable, 0)
	{
	}

	private DiagnosticInfo(ServiceResult result, DiagnosticsMasks diagnosticsMask, bool serviceLevel, StringTable stringTable, int depth)
	{
		uint num = (uint)diagnosticsMask;
		if (!serviceLevel)
		{
			num >>= 5;
		}
		diagnosticsMask = (DiagnosticsMasks)num;
		Initialize(result, diagnosticsMask, stringTable, depth);
	}

	public DiagnosticInfo(Exception exception, DiagnosticsMasks diagnosticsMask, bool serviceLevel, StringTable stringTable)
	{
		uint num = (uint)diagnosticsMask;
		if (!serviceLevel)
		{
			num >>= 5;
		}
		diagnosticsMask = (DiagnosticsMasks)num;
		Initialize(new ServiceResult(exception), diagnosticsMask, stringTable, 0);
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_symbolicId = -1;
		m_namespaceUri = -1;
		m_locale = -1;
		m_localizedText = -1;
		m_additionalInfo = null;
		m_innerStatusCode = 0u;
		m_innerDiagnosticInfo = null;
	}

	private void Initialize(ServiceResult result, DiagnosticsMasks diagnosticsMask, StringTable stringTable, int depth)
	{
		if (stringTable == null)
		{
			throw new ArgumentNullException("stringTable");
		}
		Initialize();
		if ((DiagnosticsMasks.ServiceSymbolicId & diagnosticsMask) != DiagnosticsMasks.None)
		{
			string symbolicId = result.SymbolicId;
			string namespaceUri = result.NamespaceUri;
			if (!string.IsNullOrEmpty(symbolicId))
			{
				m_symbolicId = stringTable.GetIndex(result.SymbolicId);
				if (m_symbolicId == -1)
				{
					m_symbolicId = stringTable.Count;
					stringTable.Append(symbolicId);
				}
				if (!string.IsNullOrEmpty(namespaceUri))
				{
					m_namespaceUri = stringTable.GetIndex(namespaceUri);
					if (m_namespaceUri == -1)
					{
						m_namespaceUri = stringTable.Count;
						stringTable.Append(namespaceUri);
					}
				}
			}
		}
		if ((DiagnosticsMasks.ServiceLocalizedText & diagnosticsMask) != DiagnosticsMasks.None && !Opc.Ua.LocalizedText.IsNullOrEmpty(result.LocalizedText))
		{
			if (!string.IsNullOrEmpty(result.LocalizedText.Locale))
			{
				m_locale = stringTable.GetIndex(result.LocalizedText.Locale);
				if (m_locale == -1)
				{
					m_locale = stringTable.Count;
					stringTable.Append(result.LocalizedText.Locale);
				}
			}
			m_localizedText = stringTable.GetIndex(result.LocalizedText.Text);
			if (m_localizedText == -1)
			{
				m_localizedText = stringTable.Count;
				stringTable.Append(result.LocalizedText.Text);
			}
		}
		if ((DiagnosticsMasks.ServiceAdditionalInfo & diagnosticsMask) != DiagnosticsMasks.None && (0x80000000u & (uint)diagnosticsMask) != 0)
		{
			m_additionalInfo = result.AdditionalInfo;
		}
		if (result.InnerResult == null)
		{
			return;
		}
		if ((DiagnosticsMasks.ServiceInnerStatusCode & diagnosticsMask) != DiagnosticsMasks.None)
		{
			m_innerStatusCode = result.InnerResult.StatusCode;
		}
		if ((DiagnosticsMasks.ServiceInnerDiagnostics & diagnosticsMask) != DiagnosticsMasks.None)
		{
			if (depth < MaxInnerDepth)
			{
				m_innerDiagnosticInfo = new DiagnosticInfo(result.InnerResult, diagnosticsMask, serviceLevel: true, stringTable, depth + 1);
				return;
			}
			Utils.LogWarning("Inner diagnostics truncated. Max depth of {0} exceeded.", MaxInnerDepth);
		}
	}

	public override bool Equals(object obj)
	{
		return Equals(obj, 0);
	}

	public override int GetHashCode()
	{
		HashCode hash = default(HashCode);
		GetHashCode(ref hash, 0);
		return hash.ToHashCode();
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return Utils.Format("{0}:{1}:{2}:{3}", m_symbolicId, m_namespaceUri, m_locale, m_localizedText);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new DiagnosticInfo(this);
	}

	private void GetHashCode(ref HashCode hash, int depth)
	{
		hash.Add(m_symbolicId);
		hash.Add(m_namespaceUri);
		hash.Add(m_locale);
		hash.Add(m_localizedText);
		if (m_additionalInfo != null)
		{
			hash.Add(m_additionalInfo);
		}
		hash.Add(m_innerStatusCode);
		if (m_innerDiagnosticInfo != null && depth < MaxInnerDepth)
		{
			m_innerDiagnosticInfo.GetHashCode(ref hash, depth + 1);
		}
	}

	private bool Equals(object obj, int depth)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj == null && IsNullDiagnosticInfo)
		{
			return true;
		}
		if (obj is DiagnosticInfo diagnosticInfo)
		{
			if (m_symbolicId != diagnosticInfo.m_symbolicId)
			{
				return false;
			}
			if (m_namespaceUri != diagnosticInfo.m_namespaceUri)
			{
				return false;
			}
			if (m_locale != diagnosticInfo.m_locale)
			{
				return false;
			}
			if (m_localizedText != diagnosticInfo.m_localizedText)
			{
				return false;
			}
			if (m_additionalInfo != diagnosticInfo.m_additionalInfo)
			{
				return false;
			}
			if (m_innerStatusCode != diagnosticInfo.m_innerStatusCode)
			{
				return false;
			}
			if (m_innerDiagnosticInfo != null)
			{
				if (depth < MaxInnerDepth)
				{
					return m_innerDiagnosticInfo.Equals(diagnosticInfo.m_innerDiagnosticInfo, depth + 1);
				}
				return true;
			}
			return diagnosticInfo.m_innerDiagnosticInfo == null;
		}
		return false;
	}
}
