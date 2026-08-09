using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime.Serialization;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Security;

internal class RequestSecurityToken : BodyWriter
{
	private string _context;

	private string _tokenType;

	private string _requestType;

	private SecurityToken _entropyToken;

	private BinaryNegotiation _negotiationData;

	private XmlElement _rstXml;

	private IList<XmlElement> _requestProperties;

	private ArraySegment<byte> _cachedWriteBuffer;

	private int _cachedWriteBufferLength;

	private int _keySize;

	private SecurityKeyIdentifierClause _renewTarget;

	private SecurityKeyIdentifierClause _closeTarget;

	private SecurityStandardsManager _standardsManager;

	private bool _isReadOnly;

	private object _appliesTo;

	private DataContractSerializer _appliesToSerializer;

	private Type _appliesToType;

	private object _thisLock = new object();

	public Message Message { get; set; }

	public string Context
	{
		get
		{
			return _context;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_context = value;
		}
	}

	public string TokenType
	{
		get
		{
			return _tokenType;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_tokenType = value;
		}
	}

	public int KeySize
	{
		get
		{
			return _keySize;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.ValueMustBeNonNegative));
			}
			_keySize = value;
		}
	}

	public bool IsReadOnly => _isReadOnly;

	public IEnumerable<XmlElement> RequestProperties
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRST, "RequestProperties")));
			}
			return _requestProperties;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			if (value != null)
			{
				int num = 0;
				Collection<XmlElement> collection = new Collection<XmlElement>();
				foreach (XmlElement item in value)
				{
					if (item == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException(string.Format(CultureInfo.InvariantCulture, "value[{0}]", num)));
					}
					collection.Add(item);
					num++;
				}
				_requestProperties = collection;
			}
			else
			{
				_requestProperties = null;
			}
		}
	}

	public string RequestType
	{
		get
		{
			return _requestType;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_requestType = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public SecurityKeyIdentifierClause RenewTarget
	{
		get
		{
			return _renewTarget;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_renewTarget = value;
		}
	}

	public SecurityKeyIdentifierClause CloseTarget
	{
		get
		{
			return _closeTarget;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_closeTarget = value;
		}
	}

	public XmlElement RequestSecurityTokenXml
	{
		get
		{
			if (!IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemAvailableInDeserializedRSTOnly, "RequestSecurityTokenXml")));
			}
			return _rstXml;
		}
	}

	internal bool IsReceiver { get; }

	internal object AppliesTo
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRST, "AppliesTo")));
			}
			return _appliesTo;
		}
	}

	internal DataContractSerializer AppliesToSerializer
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRST, "AppliesToSerializer")));
			}
			return _appliesToSerializer;
		}
	}

	internal Type AppliesToType
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRST, "AppliesToType")));
			}
			return _appliesToType;
		}
	}

	public RequestSecurityToken()
		: this(SecurityStandardsManager.DefaultInstance)
	{
	}

	public RequestSecurityToken(MessageSecurityVersion messageSecurityVersion, SecurityTokenSerializer securityTokenSerializer)
		: this(SecurityUtils.CreateSecurityStandardsManager(messageSecurityVersion, securityTokenSerializer))
	{
	}

	public RequestSecurityToken(MessageSecurityVersion messageSecurityVersion, SecurityTokenSerializer securityTokenSerializer, XmlElement requestSecurityTokenXml, string context, string tokenType, string requestType, int keySize, SecurityKeyIdentifierClause renewTarget, SecurityKeyIdentifierClause closeTarget)
		: this(SecurityUtils.CreateSecurityStandardsManager(messageSecurityVersion, securityTokenSerializer), requestSecurityTokenXml, context, tokenType, requestType, keySize, renewTarget, closeTarget)
	{
	}

	public RequestSecurityToken(XmlElement requestSecurityTokenXml, string context, string tokenType, string requestType, int keySize, SecurityKeyIdentifierClause renewTarget, SecurityKeyIdentifierClause closeTarget)
		: this(SecurityStandardsManager.DefaultInstance, requestSecurityTokenXml, context, tokenType, requestType, keySize, renewTarget, closeTarget)
	{
	}

	internal RequestSecurityToken(SecurityStandardsManager standardsManager, XmlElement rstXml, string context, string tokenType, string requestType, int keySize, SecurityKeyIdentifierClause renewTarget, SecurityKeyIdentifierClause closeTarget)
		: base(isBuffered: true)
	{
		_standardsManager = standardsManager ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("standardsManager"));
		_rstXml = rstXml ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstXml");
		_context = context;
		_tokenType = tokenType;
		_keySize = keySize;
		_requestType = requestType;
		_renewTarget = renewTarget;
		_closeTarget = closeTarget;
		IsReceiver = true;
		_isReadOnly = true;
	}

	internal RequestSecurityToken(SecurityStandardsManager standardsManager)
		: this(standardsManager, isBuffered: true)
	{
	}

	internal RequestSecurityToken(SecurityStandardsManager standardsManager, bool isBuffered)
		: base(isBuffered)
	{
		_standardsManager = standardsManager ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("standardsManager"));
		_requestType = _standardsManager.TrustDriver.RequestTypeIssue;
		_requestProperties = null;
		IsReceiver = false;
		_isReadOnly = false;
	}

	public ChannelBinding GetChannelBinding()
	{
		if (Message == null)
		{
			return null;
		}
		ChannelBindingMessageProperty property = null;
		ChannelBindingMessageProperty.TryGet(Message, out property);
		ChannelBinding result = null;
		if (property != null)
		{
			result = property.ChannelBinding;
		}
		return result;
	}

	internal BinaryNegotiation GetBinaryNegotiation()
	{
		if (IsReceiver)
		{
			return _standardsManager.TrustDriver.GetBinaryNegotiation(this);
		}
		return _negotiationData;
	}

	public SecurityToken GetRequestorEntropy()
	{
		return GetRequestorEntropy(null);
	}

	internal SecurityToken GetRequestorEntropy(SecurityTokenResolver resolver)
	{
		if (IsReceiver)
		{
			return _standardsManager.TrustDriver.GetEntropy(this, resolver);
		}
		return _entropyToken;
	}

	public void SetRequestorEntropy(byte[] entropy)
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
		_entropyToken = ((entropy != null) ? new NonceToken(entropy) : null);
	}

	public T GetAppliesTo<T>(XmlObjectSerializer serializer)
	{
		if (IsReceiver)
		{
			if (serializer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serializer");
			}
			return _standardsManager.TrustDriver.GetAppliesTo<T>(this, serializer);
		}
		return (T)_appliesTo;
	}

	private void OnWriteTo(XmlWriter writer)
	{
		if (IsReceiver)
		{
			_rstXml.WriteTo(writer);
		}
		else
		{
			_standardsManager.TrustDriver.WriteRequestSecurityToken(this, writer);
		}
	}

	public void WriteTo(XmlWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (IsReadOnly)
		{
			if (_cachedWriteBuffer.Array == null)
			{
				MemoryStream memoryStream = new MemoryStream();
				using XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(memoryStream, XD.Dictionary);
				OnWriteTo(xmlDictionaryWriter);
				xmlDictionaryWriter.Flush();
				memoryStream.Flush();
				memoryStream.Seek(0L, SeekOrigin.Begin);
				if (!memoryStream.TryGetBuffer(out _cachedWriteBuffer))
				{
					throw new UnauthorizedAccessException(System.SR.UnauthorizedAccess_MemStreamBuffer);
				}
				_cachedWriteBufferLength = (int)memoryStream.Length;
			}
			writer.WriteNode(XmlDictionaryReader.CreateBinaryReader(_cachedWriteBuffer.Array, 0, _cachedWriteBufferLength, XD.Dictionary, XmlDictionaryReaderQuotas.Max), defattr: false);
		}
		else
		{
			OnWriteTo(writer);
		}
	}

	internal static RequestSecurityToken CreateFrom(SecurityStandardsManager standardsManager, XmlReader reader)
	{
		return standardsManager.TrustDriver.CreateRequestSecurityToken(reader);
	}

	public void MakeReadOnly()
	{
		if (!_isReadOnly)
		{
			_isReadOnly = true;
			if (_requestProperties != null)
			{
				_requestProperties = new ReadOnlyCollection<XmlElement>(_requestProperties);
			}
			OnMakeReadOnly();
		}
	}

	protected internal virtual void OnWriteCustomAttributes(XmlWriter writer)
	{
	}

	protected internal virtual void OnWriteCustomElements(XmlWriter writer)
	{
	}

	protected internal virtual void OnMakeReadOnly()
	{
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		WriteTo(writer);
	}
}
