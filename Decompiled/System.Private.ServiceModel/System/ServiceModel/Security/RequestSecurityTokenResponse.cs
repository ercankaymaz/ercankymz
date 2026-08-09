using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IdentityModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace System.ServiceModel.Security;

internal class RequestSecurityTokenResponse : BodyWriter
{
	private static int s_minSaneKeySizeInBits = 64;

	private static int s_maxSaneKeySizeInBits = 131072;

	private SecurityStandardsManager _standardsManager;

	private string _context;

	private int _keySize;

	private bool _computeKey;

	private string _tokenType;

	private SecurityKeyIdentifierClause _requestedAttachedReference;

	private SecurityKeyIdentifierClause _requestedUnattachedReference;

	private SecurityToken _issuedToken;

	private SecurityToken _proofToken;

	private BinaryNegotiation _negotiationData;

	private XmlElement _rstrXml;

	private DateTime _expirationTime;

	private bool _isLifetimeSet;

	private byte[] _authenticator;

	private bool _isReadOnly;

	private ArraySegment<byte> _cachedWriteBuffer;

	private int _cachedWriteBufferLength;

	private bool _isRequestedTokenClosed;

	private object _appliesTo;

	private XmlObjectSerializer _appliesToSerializer;

	private Type _appliesToType;

	private XmlBuffer _issuedTokenBuffer;

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

	public SecurityKeyIdentifierClause RequestedAttachedReference
	{
		get
		{
			return _requestedAttachedReference;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_requestedAttachedReference = value;
		}
	}

	public SecurityKeyIdentifierClause RequestedUnattachedReference
	{
		get
		{
			return _requestedUnattachedReference;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_requestedUnattachedReference = value;
		}
	}

	public DateTime ValidFrom { get; private set; }

	public DateTime ValidTo => _expirationTime;

	public bool ComputeKey
	{
		get
		{
			return _computeKey;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_computeKey = value;
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

	public bool IsRequestedTokenClosed
	{
		get
		{
			return _isRequestedTokenClosed;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_isRequestedTokenClosed = value;
		}
	}

	public bool IsReadOnly => _isReadOnly;

	protected object ThisLock { get; } = new object();

	internal bool IsReceiver { get; }

	internal SecurityStandardsManager StandardsManager
	{
		get
		{
			return _standardsManager;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_standardsManager = ((value != null) ? value : SecurityStandardsManager.DefaultInstance);
		}
	}

	public SecurityToken EntropyToken
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRSTR, "EntropyToken")));
			}
			return null;
		}
	}

	public SecurityToken RequestedSecurityToken
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRSTR, "IssuedToken")));
			}
			return _issuedToken;
		}
		set
		{
			if (_isReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_issuedToken = value;
		}
	}

	public SecurityToken RequestedProofToken
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRSTR, "ProofToken")));
			}
			return _proofToken;
		}
		set
		{
			if (_isReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_proofToken = value;
		}
	}

	public XmlElement RequestSecurityTokenResponseXml
	{
		get
		{
			if (!IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemAvailableInDeserializedRSTROnly, "RequestSecurityTokenXml")));
			}
			return _rstrXml;
		}
	}

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

	internal XmlObjectSerializer AppliesToSerializer
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

	internal bool IsLifetimeSet
	{
		get
		{
			if (IsReceiver)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemNotAvailableInDeserializedRSTR, "IsLifetimeSet")));
			}
			return _isLifetimeSet;
		}
	}

	internal XmlBuffer IssuedTokenBuffer => _issuedTokenBuffer;

	public RequestSecurityTokenResponse()
		: this(SecurityStandardsManager.DefaultInstance)
	{
	}

	public RequestSecurityTokenResponse(MessageSecurityVersion messageSecurityVersion, SecurityTokenSerializer securityTokenSerializer)
		: this(SecurityUtils.CreateSecurityStandardsManager(messageSecurityVersion, securityTokenSerializer))
	{
	}

	public RequestSecurityTokenResponse(XmlElement requestSecurityTokenResponseXml, string context, string tokenType, int keySize, SecurityKeyIdentifierClause requestedAttachedReference, SecurityKeyIdentifierClause requestedUnattachedReference, bool computeKey, DateTime validFrom, DateTime validTo, bool isRequestedTokenClosed)
		: this(SecurityStandardsManager.DefaultInstance, requestSecurityTokenResponseXml, context, tokenType, keySize, requestedAttachedReference, requestedUnattachedReference, computeKey, validFrom, validTo, isRequestedTokenClosed, null)
	{
	}

	public RequestSecurityTokenResponse(MessageSecurityVersion messageSecurityVersion, SecurityTokenSerializer securityTokenSerializer, XmlElement requestSecurityTokenResponseXml, string context, string tokenType, int keySize, SecurityKeyIdentifierClause requestedAttachedReference, SecurityKeyIdentifierClause requestedUnattachedReference, bool computeKey, DateTime validFrom, DateTime validTo, bool isRequestedTokenClosed)
		: this(SecurityUtils.CreateSecurityStandardsManager(messageSecurityVersion, securityTokenSerializer), requestSecurityTokenResponseXml, context, tokenType, keySize, requestedAttachedReference, requestedUnattachedReference, computeKey, validFrom, validTo, isRequestedTokenClosed, null)
	{
	}

	internal RequestSecurityTokenResponse(SecurityStandardsManager standardsManager)
		: base(isBuffered: true)
	{
		_standardsManager = standardsManager ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("standardsManager"));
		ValidFrom = SecurityUtils.MinUtcDateTime;
		_expirationTime = SecurityUtils.MaxUtcDateTime;
		_isRequestedTokenClosed = false;
		_isLifetimeSet = false;
		IsReceiver = false;
		_isReadOnly = false;
	}

	internal RequestSecurityTokenResponse(SecurityStandardsManager standardsManager, XmlElement rstrXml, string context, string tokenType, int keySize, SecurityKeyIdentifierClause requestedAttachedReference, SecurityKeyIdentifierClause requestedUnattachedReference, bool computeKey, DateTime validFrom, DateTime validTo, bool isRequestedTokenClosed, XmlBuffer issuedTokenBuffer)
		: base(isBuffered: true)
	{
		_standardsManager = standardsManager ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("standardsManager"));
		_rstrXml = rstrXml ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstrXml");
		_context = context;
		_tokenType = tokenType;
		_keySize = keySize;
		_requestedAttachedReference = requestedAttachedReference;
		_requestedUnattachedReference = requestedUnattachedReference;
		_computeKey = computeKey;
		ValidFrom = validFrom.ToUniversalTime();
		_expirationTime = validTo.ToUniversalTime();
		_isLifetimeSet = true;
		_isRequestedTokenClosed = isRequestedTokenClosed;
		_issuedTokenBuffer = issuedTokenBuffer;
		IsReceiver = true;
		_isReadOnly = true;
	}

	public SecurityToken GetIssuerEntropy()
	{
		return GetIssuerEntropy(null);
	}

	internal SecurityToken GetIssuerEntropy(SecurityTokenResolver resolver)
	{
		if (IsReceiver)
		{
			return _standardsManager.TrustDriver.GetEntropy(this, resolver);
		}
		return null;
	}

	public void SetLifetime(DateTime validFrom, DateTime validTo)
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
		if (validFrom.ToUniversalTime() > validTo.ToUniversalTime())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.EffectiveGreaterThanExpiration);
		}
		ValidFrom = validFrom.ToUniversalTime();
		_expirationTime = validTo.ToUniversalTime();
		_isLifetimeSet = true;
	}

	public void SetAppliesTo<T>(T appliesTo, XmlObjectSerializer serializer)
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
		if (appliesTo != null && serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serializer");
		}
		_appliesTo = appliesTo;
		_appliesToSerializer = serializer;
		_appliesToType = typeof(T);
	}

	public void GetAppliesToQName(out string localName, out string namespaceUri)
	{
		if (!IsReceiver)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemAvailableInDeserializedRSTOnly, "MatchesAppliesTo")));
		}
		_standardsManager.TrustDriver.GetAppliesToQName(this, out localName, out namespaceUri);
	}

	public T GetAppliesTo<T>()
	{
		return GetAppliesTo<T>(DataContractSerializerDefaults.CreateSerializer(typeof(T), int.MaxValue));
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

	internal BinaryNegotiation GetBinaryNegotiation()
	{
		if (IsReceiver)
		{
			return _standardsManager.TrustDriver.GetBinaryNegotiation(this);
		}
		return _negotiationData;
	}

	internal byte[] GetAuthenticator()
	{
		if (IsReceiver)
		{
			return _standardsManager.TrustDriver.GetAuthenticator(this);
		}
		if (_authenticator == null)
		{
			return null;
		}
		byte[] array = Fx.AllocateByteArray(_authenticator.Length);
		Buffer.BlockCopy(_authenticator, 0, array, 0, _authenticator.Length);
		return array;
	}

	private void OnWriteTo(XmlWriter w)
	{
		if (IsReceiver)
		{
			_rstrXml.WriteTo(w);
		}
		else
		{
			_standardsManager.TrustDriver.WriteRequestSecurityTokenResponse(this, w);
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

	public static RequestSecurityTokenResponse CreateFrom(XmlReader reader)
	{
		return CreateFrom(SecurityStandardsManager.DefaultInstance, reader);
	}

	public static RequestSecurityTokenResponse CreateFrom(XmlReader reader, MessageSecurityVersion messageSecurityVersion, SecurityTokenSerializer securityTokenSerializer)
	{
		return CreateFrom(SecurityUtils.CreateSecurityStandardsManager(messageSecurityVersion, securityTokenSerializer), reader);
	}

	internal static RequestSecurityTokenResponse CreateFrom(SecurityStandardsManager standardsManager, XmlReader reader)
	{
		return standardsManager.TrustDriver.CreateRequestSecurityTokenResponse(reader);
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		WriteTo(writer);
	}

	public void MakeReadOnly()
	{
		if (!_isReadOnly)
		{
			_isReadOnly = true;
			OnMakeReadOnly();
		}
	}

	public virtual GenericXmlSecurityToken GetIssuedToken(SecurityTokenResolver resolver, IList<SecurityTokenAuthenticator> allowedAuthenticators, SecurityKeyEntropyMode keyEntropyMode, byte[] requestorEntropy, string expectedTokenType, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies, int defaultKeySize, bool isBearerKeyType)
	{
		if (!IsReceiver)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ItemAvailableInDeserializedRSTROnly, "GetIssuedToken")));
		}
		return _standardsManager.TrustDriver.GetIssuedToken(this, resolver, allowedAuthenticators, keyEntropyMode, requestorEntropy, expectedTokenType, authorizationPolicies, defaultKeySize, isBearerKeyType);
	}

	protected internal virtual void OnWriteCustomAttributes(XmlWriter writer)
	{
	}

	protected internal virtual void OnWriteCustomElements(XmlWriter writer)
	{
	}

	protected virtual void OnMakeReadOnly()
	{
	}

	public static byte[] ComputeCombinedKey(byte[] requestorEntropy, byte[] issuerEntropy, int keySizeInBits)
	{
		if (requestorEntropy == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("requestorEntropy");
		}
		if (issuerEntropy == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("issuerEntropy");
		}
		if (keySizeInBits < s_minSaneKeySizeInBits || keySizeInBits > s_maxSaneKeySizeInBits)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityNegotiationException(System.SR.Format(System.SR.InvalidKeySizeSpecifiedInNegotiation, keySizeInBits, s_minSaneKeySizeInBits, s_maxSaneKeySizeInBits)));
		}
		Psha1DerivedKeyGenerator psha1DerivedKeyGenerator = new Psha1DerivedKeyGenerator(requestorEntropy);
		return psha1DerivedKeyGenerator.GenerateDerivedKey(new byte[0], issuerEntropy, keySizeInBits, 0);
	}
}
