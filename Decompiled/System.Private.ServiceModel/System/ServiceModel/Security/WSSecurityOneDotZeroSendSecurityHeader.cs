using System.IO;
using System.IdentityModel;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Security;

internal class WSSecurityOneDotZeroSendSecurityHeader : SendSecurityHeader
{
	internal class SignatureValue : ISignatureValueSecurityElement, ISecurityElement
	{
		private Signature _signature;

		public bool HasId => true;

		public string Id => _signature.Id;

		public SignatureValue(Signature signature)
		{
			_signature = signature;
		}

		public void WriteTo(XmlDictionaryWriter writer, DictionaryManager dictionaryManager)
		{
			_signature.GetXml().WriteTo(writer);
		}

		public byte[] GetSignatureValue()
		{
			return _signature.SignatureValue;
		}
	}

	private HashStream _hashStream;

	private SignedXml _signedXml;

	private KeyedHashAlgorithm _signingKey;

	private MessagePartSpecification _effectiveSignatureParts;

	private Stream _toHeaderStream;

	private string _toHeaderId;

	protected string EncryptionAlgorithm => base.AlgorithmSuite.DefaultEncryptionAlgorithm;

	protected XmlDictionaryString EncryptionAlgorithmDictionaryString => base.AlgorithmSuite.DefaultEncryptionAlgorithmDictionaryString;

	public WSSecurityOneDotZeroSendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
		: base(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, direction)
	{
	}

	private void AddEncryptionReference(MessageHeader header, string headerId, IPrefixGenerator prefixGenerator, bool sign, out MemoryStream plainTextStream, out string encryptedDataId)
	{
		throw new PlatformNotSupportedException();
	}

	private void AddSignatureReference(SecurityToken token, int position, SecurityTokenAttachmentMode mode)
	{
		SecurityKeyIdentifierClause keyIdentifierClause = null;
		bool strTransformEnabled = ShouldUseStrTransformForToken(token, position, mode, out keyIdentifierClause);
		AddTokenSignatureReference(token, keyIdentifierClause, strTransformEnabled);
	}

	private void AddPrimaryTokenSignatureReference(SecurityToken token, SecurityTokenParameters securityTokenParameters)
	{
	}

	private void AddTokenSignatureReference(SecurityToken token, SecurityKeyIdentifierClause keyIdentifierClause, bool strTransformEnabled)
	{
		throw new PlatformNotSupportedException();
	}

	private void AddSignatureReference(SendSecurityHeaderElement[] elements)
	{
		if (elements == null)
		{
			return;
		}
		for (int i = 0; i < elements.Length; i++)
		{
			SecurityKeyIdentifierClause keyIdentifierClause = null;
			bool flag = elements[i].Item is TokenElement tokenElement && base.SignThenEncrypt && ShouldUseStrTransformForToken(tokenElement.Token, i, SecurityTokenAttachmentMode.SignedEncrypted, out keyIdentifierClause);
			if (!flag && elements[i].Id == null)
			{
				throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.ElementToSignMustHaveId), base.Message);
			}
			MemoryStream memoryStream = new MemoryStream();
			XmlDictionaryWriter xmlDictionaryWriter = TakeUtf8Writer();
			xmlDictionaryWriter.StartCanonicalization(memoryStream, includeComments: false, null);
			elements[i].Item.WriteTo(xmlDictionaryWriter, ServiceModelDictionaryManager.Instance);
			xmlDictionaryWriter.EndCanonicalization();
			memoryStream.Position = 0L;
			if (flag)
			{
				throw new PlatformNotSupportedException("StrTransform not supported yet");
			}
			AddReference("#" + elements[i].Id, memoryStream);
		}
	}

	private void AddSignatureReference(SecurityToken[] tokens, SecurityTokenAttachmentMode mode)
	{
		if (tokens != null)
		{
			for (int i = 0; i < tokens.Length; i++)
			{
				AddSignatureReference(tokens[i], i, mode);
			}
		}
	}

	private string GetSignatureHash(MessageHeader header, string headerId, IPrefixGenerator prefixGenerator, XmlDictionaryWriter writer, out byte[] hash)
	{
		HashStream hashStream = TakeHashStream();
		XmlBuffer xmlBuffer = null;
		XmlDictionaryWriter xmlDictionaryWriter;
		if (writer.CanCanonicalize)
		{
			xmlDictionaryWriter = writer;
		}
		else
		{
			xmlBuffer = new XmlBuffer(int.MaxValue);
			xmlDictionaryWriter = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		}
		xmlDictionaryWriter.StartCanonicalization(hashStream, includeComments: false, null);
		header.WriteStartHeader(xmlDictionaryWriter, base.Version);
		if (headerId == null)
		{
			headerId = GenerateId();
			base.StandardsManager.IdManager.WriteIdAttribute(xmlDictionaryWriter, headerId);
		}
		header.WriteHeaderContents(xmlDictionaryWriter, base.Version);
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.EndCanonicalization();
		xmlDictionaryWriter.Flush();
		if (xmlDictionaryWriter != writer)
		{
			xmlBuffer.CloseSection();
			xmlBuffer.Close();
			XmlDictionaryReader reader = xmlBuffer.GetReader(0);
			writer.WriteNode(reader, defattr: false);
			reader.Close();
		}
		hash = hashStream.FlushHashAndGetValue();
		return headerId;
	}

	private string GetSignatureStream(MessageHeader header, string headerId, IPrefixGenerator prefixGenerator, XmlDictionaryWriter writer, out Stream stream)
	{
		stream = new MemoryStream();
		XmlBuffer xmlBuffer = null;
		XmlDictionaryWriter xmlDictionaryWriter;
		if (writer.CanCanonicalize)
		{
			xmlDictionaryWriter = writer;
		}
		else
		{
			xmlBuffer = new XmlBuffer(int.MaxValue);
			xmlDictionaryWriter = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		}
		xmlDictionaryWriter.StartCanonicalization(stream, includeComments: false, null);
		header.WriteStartHeader(xmlDictionaryWriter, base.Version);
		if (headerId == null)
		{
			headerId = GenerateId();
			base.StandardsManager.IdManager.WriteIdAttribute(xmlDictionaryWriter, headerId);
		}
		header.WriteHeaderContents(xmlDictionaryWriter, base.Version);
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.EndCanonicalization();
		xmlDictionaryWriter.Flush();
		if (xmlDictionaryWriter != writer)
		{
			xmlBuffer.CloseSection();
			xmlBuffer.Close();
			XmlDictionaryReader reader = xmlBuffer.GetReader(0);
			writer.WriteNode(reader, defattr: false);
			reader.Close();
		}
		stream.Position = 0L;
		return headerId;
	}

	private void AddReference(string id, Stream contents)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		Reference val = new Reference(contents);
		val.Uri = id;
		val.DigestMethod = base.AlgorithmSuite.DefaultDigestAlgorithm;
		val.AddTransform((Transform)new XmlDsigExcC14NTransform());
		_signedXml.AddReference(val);
	}

	private void AddSignatureReference(MessageHeader header, string headerId, IPrefixGenerator prefixGenerator, XmlDictionaryWriter writer)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		headerId = GetSignatureHash(header, headerId, prefixGenerator, writer, out var hash);
		Reference val = new Reference();
		val.DigestMethod = base.AlgorithmSuite.DefaultDigestAlgorithm;
		val.DigestValue = hash;
		val.Id = headerId;
		_signedXml.AddReference(val);
	}

	private void ApplySecurityAndWriteHeader(MessageHeader header, string headerId, XmlDictionaryWriter writer, IPrefixGenerator prefixGenerator)
	{
		if (!base.RequireMessageProtection && base.ShouldSignToHeader && header.Name == XD.AddressingDictionary.To.Value && header.Namespace == base.Message.Version.Addressing.Namespace)
		{
			if (_toHeaderStream == null)
			{
				headerId = GetSignatureStream(header, headerId, prefixGenerator, writer, out var stream);
				_toHeaderStream = stream;
				_toHeaderId = headerId;
				return;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.TransportSecuredMessageHasMoreThanOneToHeader));
		}
		switch (GetProtectionMode(header))
		{
		case MessagePartProtectionMode.None:
			header.WriteHeader(writer, base.Version);
			break;
		case MessagePartProtectionMode.Sign:
			AddSignatureReference(header, headerId, prefixGenerator, writer);
			break;
		case MessagePartProtectionMode.Encrypt:
		case MessagePartProtectionMode.SignThenEncrypt:
		case MessagePartProtectionMode.EncryptThenSign:
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	public override void ApplySecurityAndWriteHeaders(MessageHeaders headers, XmlDictionaryWriter writer, IPrefixGenerator prefixGenerator)
	{
		string[] array = ((!base.RequireMessageProtection && !base.ShouldSignToHeader) ? null : headers.GetHeaderAttributes("Id", base.StandardsManager.IdManager.DefaultIdNamespaceUri));
		for (int i = 0; i < headers.Count; i++)
		{
			MessageHeader messageHeader = headers.GetMessageHeader(i);
			if ((base.Version.Addressing != AddressingVersion.None || !(messageHeader.Namespace == AddressingVersion.None.Namespace)) && messageHeader != this)
			{
				ApplySecurityAndWriteHeader(messageHeader, (array == null) ? null : array[i], writer, prefixGenerator);
			}
		}
	}

	private static bool CanCanonicalizeAndFragment(XmlDictionaryWriter writer)
	{
		if (!writer.CanCanonicalize)
		{
			return false;
		}
		if (writer is IFragmentCapableXmlDictionaryWriter fragmentCapableXmlDictionaryWriter)
		{
			return fragmentCapableXmlDictionaryWriter.CanFragment;
		}
		return false;
	}

	public override void ApplyBodySecurity(XmlDictionaryWriter writer, IPrefixGenerator prefixGenerator)
	{
		SecurityAppliedMessage securityAppliedMessage = base.SecurityAppliedMessage;
		switch (securityAppliedMessage.BodyProtectionMode)
		{
		case MessagePartProtectionMode.None:
			break;
		case MessagePartProtectionMode.Sign:
		{
			MemoryStream memoryStream = new MemoryStream();
			if (CanCanonicalizeAndFragment(writer))
			{
				securityAppliedMessage.WriteBodyToSignWithFragments(memoryStream, includeComments: false, null, writer);
			}
			else
			{
				securityAppliedMessage.WriteBodyToSign(memoryStream);
			}
			memoryStream.Position = 0L;
			AddReference("#" + securityAppliedMessage.BodyId, memoryStream);
			break;
		}
		case MessagePartProtectionMode.SignThenEncrypt:
			throw new PlatformNotSupportedException();
		case MessagePartProtectionMode.Encrypt:
			throw new PlatformNotSupportedException();
		case MessagePartProtectionMode.EncryptThenSign:
			throw new PlatformNotSupportedException();
		}
	}

	protected override ISignatureValueSecurityElement CompletePrimarySignatureCore(SendSecurityHeaderElement[] signatureConfirmations, SecurityToken[] signedEndorsingTokens, SecurityToken[] signedTokens, SendSecurityHeaderElement[] basicTokens, bool isPrimarySignature)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		if (_signedXml == null)
		{
			return null;
		}
		SecurityTimestamp timestamp = base.Timestamp;
		if (timestamp != null)
		{
			if (timestamp.Id == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TimestampToSignHasNoId));
			}
			byte[] buffer = new byte[64];
			MemoryStream memoryStream = new MemoryStream();
			base.StandardsManager.WSUtilitySpecificationVersion.WriteTimestampCanonicalForm(memoryStream, timestamp, buffer);
			memoryStream.Position = 0L;
			AddReference("#" + timestamp.Id, memoryStream);
			Reference val = new Reference((Stream)memoryStream);
		}
		if (base.ShouldSignToHeader && (_signingKey != null || _signedXml.SigningKey != null) && base.Version.Addressing != AddressingVersion.None)
		{
			if (_toHeaderStream == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TransportSecurityRequireToHeader));
			}
			AddReference("#" + _toHeaderId, _toHeaderStream);
		}
		AddSignatureReference(signatureConfirmations);
		if (isPrimarySignature && base.ShouldProtectTokens)
		{
			AddPrimaryTokenSignatureReference(base.ElementContainer.SourceSigningToken, base.SigningTokenParameters);
		}
		if (base.RequireMessageProtection)
		{
			throw new PlatformNotSupportedException("RequireMessageProtection");
		}
		if (_signedXml.SignedInfo.References.Count == 0)
		{
			throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.NoPartsOfMessageMatchedPartsToSign), base.Message);
		}
		try
		{
			if (_signingKey != null)
			{
				_signedXml.ComputeSignature(_signingKey);
			}
			else
			{
				_signedXml.ComputeSignature();
			}
			return new SignatureValue(_signedXml.Signature);
		}
		finally
		{
			_hashStream = null;
			_signingKey = null;
			_signedXml = null;
			_effectiveSignatureParts = null;
		}
	}

	private HashStream TakeHashStream()
	{
		HashStream hashStream = null;
		if (_hashStream == null)
		{
			hashStream = (_hashStream = new HashStream(CryptoHelper.CreateHashAlgorithm(base.AlgorithmSuite.DefaultDigestAlgorithm)));
		}
		else
		{
			hashStream = _hashStream;
			hashStream.Reset();
		}
		return hashStream;
	}

	private XmlDictionaryWriter TakeUtf8Writer()
	{
		throw new PlatformNotSupportedException();
	}

	private MessagePartProtectionMode GetProtectionMode(MessageHeader header)
	{
		if (!base.RequireMessageProtection)
		{
			return MessagePartProtectionMode.None;
		}
		bool sign = _signedXml != null && _effectiveSignatureParts.IsHeaderIncluded(header);
		bool encrypt = false;
		return MessagePartProtectionModeHelper.GetProtectionMode(sign, encrypt, base.SignThenEncrypt);
	}

	protected override void StartPrimarySignatureCore(SecurityToken token, SecurityKeyIdentifier keyIdentifier, MessagePartSpecification signatureParts, bool generateTargettableSignature)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		SecurityAlgorithmSuite algorithmSuite = base.AlgorithmSuite;
		string defaultCanonicalizationAlgorithm = algorithmSuite.DefaultCanonicalizationAlgorithm;
		if (defaultCanonicalizationAlgorithm != "http://www.w3.org/2001/10/xml-exc-c14n#")
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnsupportedCanonicalizationAlgorithm, algorithmSuite.DefaultCanonicalizationAlgorithm)));
		}
		algorithmSuite.GetSignatureAlgorithmAndKey(token, out var signatureAlgorithm, out var key, out var _);
		AsymmetricAlgorithm asymmetricAlgorithm = null;
		GetSigningAlgorithm(key, signatureAlgorithm, out _signingKey, out asymmetricAlgorithm);
		_signedXml = new SignedXml();
		_signedXml.SignedInfo.CanonicalizationMethod = defaultCanonicalizationAlgorithm;
		_signedXml.SignedInfo.SignatureMethod = signatureAlgorithm;
		_signedXml.SigningKey = asymmetricAlgorithm;
		if (keyIdentifier != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(memoryStream, Encoding.UTF8, ownsStream: false))
			{
				base.StandardsManager.SecurityTokenSerializer.WriteKeyIdentifier(writer, keyIdentifier);
			}
			memoryStream.Position = 0L;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(memoryStream);
			KeyInfo val = new KeyInfo();
			val.LoadXml(xmlDocument.DocumentElement);
			_signedXml.KeyInfo = val;
		}
		if (generateTargettableSignature)
		{
			_signedXml.Signature.Id = GenerateId();
		}
		_effectiveSignatureParts = signatureParts;
	}

	private void GetSigningAlgorithm(SecurityKey signatureKey, string algorithmName, out KeyedHashAlgorithm symmetricAlgorithm, out AsymmetricAlgorithm asymmetricAlgorithm)
	{
		symmetricAlgorithm = null;
		asymmetricAlgorithm = null;
		if (signatureKey is SymmetricSecurityKey symmetricSecurityKey)
		{
			_signingKey = symmetricSecurityKey.GetKeyedHashAlgorithm(algorithmName);
			if (_signingKey == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.UnableToCreateKeyedHashAlgorithm, symmetricSecurityKey, algorithmName)));
			}
			return;
		}
		if (!(signatureKey is AsymmetricSecurityKey asymmetricSecurityKey))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.UnknownICryptoType, _signingKey)));
		}
		asymmetricAlgorithm = asymmetricSecurityKey.GetAsymmetricAlgorithm(algorithmName, privateKey: true);
		if (asymmetricAlgorithm == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.UnableToCreateHashAlgorithmFromAsymmetricCrypto, algorithmName, asymmetricSecurityKey)));
		}
	}

	protected override ISignatureValueSecurityElement CreateSupportingSignature(SecurityToken token, SecurityKeyIdentifier identifier)
	{
		StartPrimarySignatureCore(token, identifier, MessagePartSpecification.NoParts, false);
		return CompletePrimarySignatureCore(null, null, null, null, isPrimarySignature: false);
	}

	protected override ISignatureValueSecurityElement CreateSupportingSignature(SecurityToken token, SecurityKeyIdentifier identifier, ISecurityElement elementToSign)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		base.AlgorithmSuite.GetSignatureAlgorithmAndKey(token, out var signatureAlgorithm, out var key, out var _);
		SignedXml val = new SignedXml();
		SignedInfo signedInfo = val.SignedInfo;
		signedInfo.CanonicalizationMethod = base.AlgorithmSuite.DefaultCanonicalizationAlgorithm;
		signedInfo.SignatureMethod = signatureAlgorithm;
		if (elementToSign.Id == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ElementToSignMustHaveId));
		}
		MemoryStream memoryStream = new MemoryStream();
		XmlDictionaryWriter xmlDictionaryWriter = TakeUtf8Writer();
		xmlDictionaryWriter.StartCanonicalization(memoryStream, includeComments: false, null);
		elementToSign.WriteTo(xmlDictionaryWriter, ServiceModelDictionaryManager.Instance);
		xmlDictionaryWriter.EndCanonicalization();
		memoryStream.Position = 0L;
		AddReference("#" + elementToSign.Id, memoryStream);
		AsymmetricAlgorithm asymmetricAlgorithm = null;
		KeyedHashAlgorithm symmetricAlgorithm = null;
		GetSigningAlgorithm(key, signatureAlgorithm, out symmetricAlgorithm, out asymmetricAlgorithm);
		if (symmetricAlgorithm != null)
		{
			val.ComputeSignature(symmetricAlgorithm);
		}
		else
		{
			val.SigningKey = asymmetricAlgorithm;
			val.ComputeSignature();
		}
		SetKeyInfo(val, identifier);
		return new SignatureValue(val.Signature);
	}

	private void SetKeyInfo(SignedXml signedXml, SecurityKeyIdentifier identifier)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		if (identifier != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(memoryStream, Encoding.UTF8, ownsStream: false))
			{
				base.StandardsManager.SecurityTokenSerializer.WriteKeyIdentifier(writer, identifier);
			}
			memoryStream.Position = 0L;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(memoryStream);
			KeyInfo val = new KeyInfo();
			val.LoadXml(xmlDocument.DocumentElement);
			signedXml.KeyInfo = val;
		}
	}

	protected override void WriteSecurityTokenReferencyEntry(XmlDictionaryWriter writer, SecurityToken securityToken, SecurityTokenParameters securityTokenParameters)
	{
	}
}
