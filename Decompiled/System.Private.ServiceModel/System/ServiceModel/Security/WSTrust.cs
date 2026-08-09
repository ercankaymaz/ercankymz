using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.Runtime;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class WSTrust : WSSecurityTokenSerializer.SerializerEntries
{
	private class BinarySecretTokenEntry : WSSecurityTokenSerializer.TokenEntry
	{
		private WSTrust _parent;

		private TrustDictionary _otherDictionary;

		protected override XmlDictionaryString LocalName => _parent.SerializerDictionary.BinarySecret;

		protected override XmlDictionaryString NamespaceUri => _parent.SerializerDictionary.Namespace;

		public override string TokenTypeUri => null;

		protected override string ValueTypeUri => null;

		public BinarySecretTokenEntry(WSTrust parent)
		{
			_parent = parent;
			_otherDictionary = null;
			if (parent.SerializerDictionary is TrustDec2005Dictionary)
			{
				_otherDictionary = XD.TrustFeb2005Dictionary;
			}
			if (parent.SerializerDictionary is TrustFeb2005Dictionary)
			{
				_otherDictionary = DXD.TrustDec2005Dictionary;
			}
			if (_otherDictionary == null)
			{
				_otherDictionary = _parent.SerializerDictionary;
			}
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(BinarySecretSecurityToken) };
		}

		public override bool CanReadTokenCore(XmlElement element)
		{
			string text = null;
			if (element.HasAttribute("ValueType", null))
			{
				text = element.GetAttribute("ValueType", null);
			}
			if (element.LocalName == LocalName.Value && (element.NamespaceURI == NamespaceUri.Value || element.NamespaceURI == _otherDictionary.Namespace.Value))
			{
				return text == ValueTypeUri;
			}
			return false;
		}

		public override bool CanReadTokenCore(XmlDictionaryReader reader)
		{
			if (reader.IsStartElement(LocalName, NamespaceUri) || reader.IsStartElement(LocalName, _otherDictionary.Namespace))
			{
				return reader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null) == ValueTypeUri;
			}
			return false;
		}

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle)
		{
			TokenReferenceStyleHelper.Validate(tokenReferenceStyle);
			return tokenReferenceStyle switch
			{
				SecurityTokenReferenceStyle.Internal => WSSecurityTokenSerializer.TokenEntry.CreateDirectReference(issuedTokenXml, "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", typeof(GenericXmlSecurityToken)), 
				SecurityTokenReferenceStyle.External => null, 
				_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenReferenceStyle")), 
			};
		}

		public override SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			string attribute = reader.GetAttribute(XD.SecurityJan2004Dictionary.TypeAttribute, null);
			string attribute2 = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			bool flag = false;
			if (attribute != null && attribute.Length > 0)
			{
				if (attribute == _parent.SerializerDictionary.NonceBinarySecret.Value || attribute == _otherDictionary.NonceBinarySecret.Value)
				{
					flag = true;
				}
				else if (attribute != _parent.SerializerDictionary.SymmetricKeyBinarySecret.Value && attribute != _otherDictionary.SymmetricKeyBinarySecret.Value)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnexpectedBinarySecretType, _parent.SerializerDictionary.SymmetricKeyBinarySecret.Value, attribute)));
				}
			}
			byte[] key = reader.ReadElementContentAsBase64();
			if (flag)
			{
				return new NonceToken(attribute2, key);
			}
			return new BinarySecretSecurityToken(attribute2, key);
		}

		public override void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token)
		{
			BinarySecretSecurityToken binarySecretSecurityToken = token as BinarySecretSecurityToken;
			byte[] keyBytes = binarySecretSecurityToken.GetKeyBytes();
			writer.WriteStartElement(_parent.SerializerDictionary.Prefix.Value, _parent.SerializerDictionary.BinarySecret, _parent.SerializerDictionary.Namespace);
			if (binarySecretSecurityToken.Id != null)
			{
				writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, binarySecretSecurityToken.Id);
			}
			if (token is NonceToken)
			{
				writer.WriteAttributeString(XD.SecurityJan2004Dictionary.TypeAttribute, null, _parent.SerializerDictionary.NonceBinarySecret.Value);
			}
			writer.WriteBase64(keyBytes, 0, keyBytes.Length);
			writer.WriteEndElement();
		}
	}

	public abstract class Driver : TrustDriver
	{
		private static readonly string s_base64Uri = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

		private static readonly string s_hexBinaryUri = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary";

		private SecurityStandardsManager _standardsManager;

		private List<SecurityTokenAuthenticator> _entropyAuthenticators;

		public abstract TrustDictionary DriverDictionary { get; }

		public override XmlDictionaryString RequestSecurityTokenAction => DriverDictionary.RequestSecurityTokenIssuance;

		public override XmlDictionaryString RequestSecurityTokenResponseAction => DriverDictionary.RequestSecurityTokenIssuanceResponse;

		public override string RequestTypeIssue => DriverDictionary.RequestTypeIssue.Value;

		public override string ComputedKeyAlgorithm => DriverDictionary.Psha1ComputedKeyUri.Value;

		public override SecurityStandardsManager StandardsManager => _standardsManager;

		public override XmlDictionaryString Namespace => DriverDictionary.Namespace;

		public Driver(SecurityStandardsManager standardsManager)
		{
			_standardsManager = standardsManager;
			_entropyAuthenticators = new List<SecurityTokenAuthenticator>(2);
		}

		public override RequestSecurityToken CreateRequestSecurityToken(XmlReader xmlReader)
		{
			XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(xmlReader);
			xmlDictionaryReader.MoveToStartElement(DriverDictionary.RequestSecurityToken, DriverDictionary.Namespace);
			string context = null;
			string tokenType = null;
			string requestType = null;
			int keySize = 0;
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.ReadNode(xmlDictionaryReader) as XmlElement;
			SecurityKeyIdentifierClause renewTarget = null;
			SecurityKeyIdentifierClause closeTarget = null;
			for (int i = 0; i < xmlElement.Attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = xmlElement.Attributes[i];
				if (xmlAttribute.LocalName == DriverDictionary.Context.Value)
				{
					context = xmlAttribute.Value;
				}
			}
			for (int j = 0; j < xmlElement.ChildNodes.Count; j++)
			{
				if (xmlElement.ChildNodes[j] is XmlElement xmlElement2)
				{
					if (xmlElement2.LocalName == DriverDictionary.TokenType.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						tokenType = XmlHelper.ReadTextElementAsTrimmedString(xmlElement2);
					}
					else if (xmlElement2.LocalName == DriverDictionary.RequestType.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						requestType = XmlHelper.ReadTextElementAsTrimmedString(xmlElement2);
					}
					else if (xmlElement2.LocalName == DriverDictionary.KeySize.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						keySize = int.Parse(XmlHelper.ReadTextElementAsTrimmedString(xmlElement2), NumberFormatInfo.InvariantInfo);
					}
				}
			}
			ReadTargets(xmlElement, out renewTarget, out closeTarget);
			return new RequestSecurityToken(_standardsManager, xmlElement, context, tokenType, requestType, keySize, renewTarget, closeTarget);
		}

		private XmlBuffer GetIssuedTokenBuffer(XmlBuffer rstrBuffer)
		{
			XmlBuffer xmlBuffer = null;
			using (XmlDictionaryReader xmlDictionaryReader = rstrBuffer.GetReader(0))
			{
				xmlDictionaryReader.ReadFullStartElement();
				while (xmlDictionaryReader.IsStartElement())
				{
					if (xmlDictionaryReader.IsStartElement(DriverDictionary.RequestedSecurityToken, DriverDictionary.Namespace))
					{
						xmlDictionaryReader.ReadStartElement();
						xmlDictionaryReader.MoveToContent();
						xmlBuffer = new XmlBuffer(int.MaxValue);
						using (XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(xmlDictionaryReader.Quotas))
						{
							xmlDictionaryWriter.WriteNode(xmlDictionaryReader, defattr: false);
							xmlBuffer.CloseSection();
							xmlBuffer.Close();
						}
						xmlDictionaryReader.ReadEndElement();
						break;
					}
					xmlDictionaryReader.Skip();
				}
			}
			return xmlBuffer;
		}

		public override RequestSecurityTokenResponse CreateRequestSecurityTokenResponse(XmlReader xmlReader)
		{
			if (xmlReader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("xmlReader");
			}
			XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(xmlReader);
			if (!xmlDictionaryReader.IsStartElement(DriverDictionary.RequestSecurityTokenResponse, DriverDictionary.Namespace))
			{
				XmlHelper.OnRequiredElementMissing(DriverDictionary.RequestSecurityTokenResponse.Value, DriverDictionary.Namespace.Value);
			}
			XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
			using (XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(xmlDictionaryReader.Quotas))
			{
				xmlDictionaryWriter.WriteNode(xmlDictionaryReader, defattr: false);
				xmlBuffer.CloseSection();
				xmlBuffer.Close();
			}
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement;
			using (XmlReader reader = xmlBuffer.GetReader(0))
			{
				xmlElement = xmlDocument.ReadNode(reader) as XmlElement;
			}
			XmlBuffer issuedTokenBuffer = GetIssuedTokenBuffer(xmlBuffer);
			string context = null;
			string tokenType = null;
			int keySize = 0;
			SecurityKeyIdentifierClause requestedAttachedReference = null;
			SecurityKeyIdentifierClause requestedUnattachedReference = null;
			bool computeKey = false;
			DateTime validFrom = DateTime.UtcNow;
			DateTime validTo = SecurityUtils.MaxUtcDateTime;
			bool flag = false;
			for (int i = 0; i < xmlElement.Attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = xmlElement.Attributes[i];
				if (xmlAttribute.LocalName == DriverDictionary.Context.Value)
				{
					context = xmlAttribute.Value;
				}
			}
			for (int j = 0; j < xmlElement.ChildNodes.Count; j++)
			{
				if (!(xmlElement.ChildNodes[j] is XmlElement xmlElement2))
				{
					continue;
				}
				if (xmlElement2.LocalName == DriverDictionary.TokenType.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					tokenType = XmlHelper.ReadTextElementAsTrimmedString(xmlElement2);
				}
				else if (xmlElement2.LocalName == DriverDictionary.KeySize.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					keySize = int.Parse(XmlHelper.ReadTextElementAsTrimmedString(xmlElement2), NumberFormatInfo.InvariantInfo);
				}
				else if (xmlElement2.LocalName == DriverDictionary.RequestedProofToken.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					XmlElement childElement = XmlHelper.GetChildElement(xmlElement2);
					if (childElement.LocalName == DriverDictionary.ComputedKey.Value && childElement.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						string text = XmlHelper.ReadTextElementAsTrimmedString(childElement);
						if (text != DriverDictionary.Psha1ComputedKeyUri.Value)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SecurityNegotiationException(System.SR.Format(System.SR.UnknownComputedKeyAlgorithm, text)));
						}
						computeKey = true;
					}
				}
				else if (xmlElement2.LocalName == DriverDictionary.Lifetime.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					XmlElement childElement2 = XmlHelper.GetChildElement(xmlElement2, "Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
					if (childElement2 != null)
					{
						validFrom = DateTime.ParseExact(XmlHelper.ReadTextElementAsTrimmedString(childElement2), WSUtilitySpecificationVersion.AcceptedDateTimeFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None).ToUniversalTime();
					}
					XmlElement childElement3 = XmlHelper.GetChildElement(xmlElement2, "Expires", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
					if (childElement3 != null)
					{
						validTo = DateTime.ParseExact(XmlHelper.ReadTextElementAsTrimmedString(childElement3), WSUtilitySpecificationVersion.AcceptedDateTimeFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None).ToUniversalTime();
					}
				}
			}
			flag = ReadRequestedTokenClosed(xmlElement);
			ReadReferences(xmlElement, out requestedAttachedReference, out requestedUnattachedReference);
			return new RequestSecurityTokenResponse(_standardsManager, xmlElement, context, tokenType, keySize, requestedAttachedReference, requestedUnattachedReference, computeKey, validFrom, validTo, flag, issuedTokenBuffer);
		}

		public override RequestSecurityTokenResponseCollection CreateRequestSecurityTokenResponseCollection(XmlReader xmlReader)
		{
			XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(xmlReader);
			List<RequestSecurityTokenResponse> list = new List<RequestSecurityTokenResponse>(2);
			string name = xmlDictionaryReader.Name;
			xmlDictionaryReader.ReadStartElement(DriverDictionary.RequestSecurityTokenResponseCollection, DriverDictionary.Namespace);
			while (xmlDictionaryReader.IsStartElement(DriverDictionary.RequestSecurityTokenResponse.Value, DriverDictionary.Namespace.Value))
			{
				RequestSecurityTokenResponse item = CreateRequestSecurityTokenResponse(xmlDictionaryReader);
				list.Add(item);
			}
			xmlDictionaryReader.ReadEndElement();
			if (list.Count == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.NoRequestSecurityTokenResponseElements));
			}
			return new RequestSecurityTokenResponseCollection(list.AsReadOnly(), StandardsManager);
		}

		private T GetAppliesTo<T>(XmlElement rootXml, XmlObjectSerializer serializer)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		public override T GetAppliesTo<T>(RequestSecurityToken rst, XmlObjectSerializer serializer)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		public override T GetAppliesTo<T>(RequestSecurityTokenResponse rstr, XmlObjectSerializer serializer)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		public override bool IsAppliesTo(string localName, string namespaceUri)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		public override void GetAppliesToQName(RequestSecurityToken rst, out string localName, out string namespaceUri)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		public override void GetAppliesToQName(RequestSecurityTokenResponse rstr, out string localName, out string namespaceUri)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}

		public override byte[] GetAuthenticator(RequestSecurityTokenResponse rstr)
		{
			if (rstr != null && rstr.RequestSecurityTokenResponseXml != null && rstr.RequestSecurityTokenResponseXml.ChildNodes != null)
			{
				for (int i = 0; i < rstr.RequestSecurityTokenResponseXml.ChildNodes.Count; i++)
				{
					if (rstr.RequestSecurityTokenResponseXml.ChildNodes[i] is XmlElement xmlElement && xmlElement.LocalName == DriverDictionary.Authenticator.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						XmlElement childElement = XmlHelper.GetChildElement(xmlElement);
						if (childElement.LocalName == DriverDictionary.CombinedHash.Value && childElement.NamespaceURI == DriverDictionary.Namespace.Value)
						{
							string s = XmlHelper.ReadTextElementAsTrimmedString(childElement);
							return Convert.FromBase64String(s);
						}
					}
				}
			}
			return null;
		}

		public override BinaryNegotiation GetBinaryNegotiation(RequestSecurityTokenResponse rstr)
		{
			if (rstr == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstr");
			}
			return GetBinaryNegotiation(rstr.RequestSecurityTokenResponseXml);
		}

		public override BinaryNegotiation GetBinaryNegotiation(RequestSecurityToken rst)
		{
			if (rst == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rst");
			}
			return GetBinaryNegotiation(rst.RequestSecurityTokenXml);
		}

		private BinaryNegotiation GetBinaryNegotiation(XmlElement rootElement)
		{
			if (rootElement == null)
			{
				return null;
			}
			for (int i = 0; i < rootElement.ChildNodes.Count; i++)
			{
				if (rootElement.ChildNodes[i] is XmlElement xmlElement && xmlElement.LocalName == DriverDictionary.BinaryExchange.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					return ReadBinaryNegotiation(xmlElement);
				}
			}
			return null;
		}

		public override SecurityToken GetEntropy(RequestSecurityToken rst, SecurityTokenResolver resolver)
		{
			if (rst == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rst");
			}
			return GetEntropy(rst.RequestSecurityTokenXml, resolver);
		}

		public override SecurityToken GetEntropy(RequestSecurityTokenResponse rstr, SecurityTokenResolver resolver)
		{
			if (rstr == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstr");
			}
			return GetEntropy(rstr.RequestSecurityTokenResponseXml, resolver);
		}

		private SecurityToken GetEntropy(XmlElement rootElement, SecurityTokenResolver resolver)
		{
			if (rootElement == null || rootElement.ChildNodes == null)
			{
				return null;
			}
			for (int i = 0; i < rootElement.ChildNodes.Count; i++)
			{
				if (rootElement.ChildNodes[i] is XmlElement xmlElement && xmlElement.LocalName == DriverDictionary.Entropy.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					XmlElement childElement = XmlHelper.GetChildElement(xmlElement);
					string attribute = xmlElement.GetAttribute("ValueType");
					if (attribute.Length == 0)
					{
						attribute = null;
					}
					return _standardsManager.SecurityTokenSerializer.ReadToken(new XmlNodeReader(childElement), resolver);
				}
			}
			return null;
		}

		private void GetIssuedAndProofXml(RequestSecurityTokenResponse rstr, out XmlElement issuedTokenXml, out XmlElement proofTokenXml)
		{
			issuedTokenXml = null;
			proofTokenXml = null;
			if (rstr.RequestSecurityTokenResponseXml == null || rstr.RequestSecurityTokenResponseXml.ChildNodes == null)
			{
				return;
			}
			for (int i = 0; i < rstr.RequestSecurityTokenResponseXml.ChildNodes.Count; i++)
			{
				if (!(rstr.RequestSecurityTokenResponseXml.ChildNodes[i] is XmlElement xmlElement))
				{
					continue;
				}
				if (xmlElement.LocalName == DriverDictionary.RequestedSecurityToken.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					if (issuedTokenXml != null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.RstrHasMultipleIssuedTokens));
					}
					issuedTokenXml = XmlHelper.GetChildElement(xmlElement);
				}
				else if (xmlElement.LocalName == DriverDictionary.RequestedProofToken.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					if (proofTokenXml != null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.RstrHasMultipleProofTokens));
					}
					proofTokenXml = XmlHelper.GetChildElement(xmlElement);
				}
			}
		}

		public override GenericXmlSecurityToken GetIssuedToken(RequestSecurityTokenResponse rstr, SecurityTokenResolver resolver, IList<SecurityTokenAuthenticator> allowedAuthenticators, SecurityKeyEntropyMode keyEntropyMode, byte[] requestorEntropy, string expectedTokenType, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies, int defaultKeySize, bool isBearerKeyType)
		{
			SecurityKeyEntropyModeHelper.Validate(keyEntropyMode);
			if (defaultKeySize < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("defaultKeySize", System.SR.ValueMustBeNonNegative));
			}
			if (rstr == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstr");
			}
			if (rstr.TokenType != null)
			{
				if (expectedTokenType != null && expectedTokenType != rstr.TokenType)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BadIssuedTokenType, rstr.TokenType, expectedTokenType)));
				}
				string tokenType = rstr.TokenType;
			}
			else
			{
				string tokenType = expectedTokenType;
			}
			DateTime validFrom = rstr.ValidFrom;
			DateTime validTo = rstr.ValidTo;
			GetIssuedAndProofXml(rstr, out var issuedTokenXml, out var proofTokenXml);
			if (issuedTokenXml == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.NoLicenseXml));
			}
			if (isBearerKeyType)
			{
				if (proofTokenXml != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.BearerKeyTypeCannotHaveProofKey));
				}
				return new GenericXmlSecurityToken(issuedTokenXml, null, validFrom, validTo, rstr.RequestedAttachedReference, rstr.RequestedUnattachedReference, authorizationPolicies);
			}
			SecurityToken entropy = GetEntropy(rstr, resolver);
			SecurityToken proofToken;
			switch (keyEntropyMode)
			{
			case SecurityKeyEntropyMode.ClientEntropy:
				if (requestorEntropy == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeRequiresRequestorEntropy, keyEntropyMode)));
				}
				if (proofTokenXml != null || entropy != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeCannotHaveProofTokenOrIssuerEntropy, keyEntropyMode)));
				}
				proofToken = new BinarySecretSecurityToken(requestorEntropy);
				break;
			case SecurityKeyEntropyMode.ServerEntropy:
			{
				if (requestorEntropy != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeCannotHaveRequestorEntropy, keyEntropyMode)));
				}
				if (rstr.ComputeKey || entropy != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeCannotHaveComputedKey, keyEntropyMode)));
				}
				if (proofTokenXml == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeRequiresProofToken, keyEntropyMode)));
				}
				string attribute = proofTokenXml.GetAttribute("ValueType");
				if (attribute.Length == 0)
				{
					attribute = null;
				}
				proofToken = _standardsManager.SecurityTokenSerializer.ReadToken(new XmlNodeReader(proofTokenXml), resolver);
				break;
			}
			default:
			{
				if (!rstr.ComputeKey)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeRequiresComputedKey, keyEntropyMode)));
				}
				if (entropy == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeRequiresIssuerEntropy, keyEntropyMode)));
				}
				if (requestorEntropy == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeRequiresRequestorEntropy, keyEntropyMode)));
				}
				if (rstr.KeySize == 0 && defaultKeySize == 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.RstrKeySizeNotProvided));
				}
				int keySizeInBits = ((rstr.KeySize != 0) ? rstr.KeySize : defaultKeySize);
				if (entropy is BinarySecretSecurityToken)
				{
					byte[] keyBytes = ((BinarySecretSecurityToken)entropy).GetKeyBytes();
					byte[] key = RequestSecurityTokenResponse.ComputeCombinedKey(requestorEntropy, keyBytes, keySizeInBits);
					proofToken = new BinarySecretSecurityToken(key);
					break;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.UnsupportedIssuerEntropyType));
			}
			}
			SecurityKeyIdentifierClause requestedAttachedReference = rstr.RequestedAttachedReference;
			SecurityKeyIdentifierClause requestedUnattachedReference = rstr.RequestedUnattachedReference;
			return new BufferedGenericXmlSecurityToken(issuedTokenXml, proofToken, validFrom, validTo, requestedAttachedReference, requestedUnattachedReference, authorizationPolicies, rstr.IssuedTokenBuffer);
		}

		public override bool IsAtRequestSecurityTokenResponse(XmlReader reader)
		{
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
			}
			return reader.IsStartElement(DriverDictionary.RequestSecurityTokenResponse.Value, DriverDictionary.Namespace.Value);
		}

		public override bool IsAtRequestSecurityTokenResponseCollection(XmlReader reader)
		{
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
			}
			return reader.IsStartElement(DriverDictionary.RequestSecurityTokenResponseCollection.Value, DriverDictionary.Namespace.Value);
		}

		public override bool IsRequestedSecurityTokenElement(string name, string nameSpace)
		{
			if (name == DriverDictionary.RequestedSecurityToken.Value)
			{
				return nameSpace == DriverDictionary.Namespace.Value;
			}
			return false;
		}

		public override bool IsRequestedProofTokenElement(string name, string nameSpace)
		{
			if (name == DriverDictionary.RequestedProofToken.Value)
			{
				return nameSpace == DriverDictionary.Namespace.Value;
			}
			return false;
		}

		public static BinaryNegotiation ReadBinaryNegotiation(XmlElement elem)
		{
			if (elem == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("elem");
			}
			string text = null;
			string text2 = null;
			byte[] array = null;
			if (elem.Attributes != null)
			{
				for (int i = 0; i < elem.Attributes.Count; i++)
				{
					XmlAttribute xmlAttribute = elem.Attributes[i];
					if (xmlAttribute.LocalName == "EncodingType" && xmlAttribute.NamespaceURI.Length == 0)
					{
						text = xmlAttribute.Value;
						if (text != s_base64Uri && text != s_hexBinaryUri)
						{
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnsupportedBinaryEncoding, text)));
						}
					}
					else if (xmlAttribute.LocalName == "ValueType" && xmlAttribute.NamespaceURI.Length == 0)
					{
						text2 = xmlAttribute.Value;
					}
				}
			}
			if (text == null)
			{
				XmlHelper.OnRequiredAttributeMissing("EncodingType", elem.Name);
			}
			if (text2 == null)
			{
				XmlHelper.OnRequiredAttributeMissing("ValueType", elem.Name);
			}
			string text3 = XmlHelper.ReadTextElementAsTrimmedString(elem);
			array = ((!(text == s_base64Uri)) ? SoapHexBinary.Parse(text3).Value : Convert.FromBase64String(text3));
			return new BinaryNegotiation(text2, array);
		}

		protected virtual void ReadReferences(XmlElement rstrXml, out SecurityKeyIdentifierClause requestedAttachedReference, out SecurityKeyIdentifierClause requestedUnattachedReference)
		{
			XmlElement xmlElement = null;
			requestedAttachedReference = null;
			requestedUnattachedReference = null;
			for (int i = 0; i < rstrXml.ChildNodes.Count; i++)
			{
				if (rstrXml.ChildNodes[i] is XmlElement xmlElement2)
				{
					if (xmlElement2.LocalName == DriverDictionary.RequestedSecurityToken.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						xmlElement = XmlHelper.GetChildElement(xmlElement2);
					}
					else if (xmlElement2.LocalName == DriverDictionary.RequestedTokenReference.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						requestedUnattachedReference = GetKeyIdentifierXmlReferenceClause(XmlHelper.GetChildElement(xmlElement2));
					}
				}
			}
			if (xmlElement == null)
			{
				return;
			}
			requestedAttachedReference = _standardsManager.CreateKeyIdentifierClauseFromTokenXml(xmlElement, SecurityTokenReferenceStyle.Internal);
			if (requestedUnattachedReference == null)
			{
				try
				{
					requestedUnattachedReference = _standardsManager.CreateKeyIdentifierClauseFromTokenXml(xmlElement, SecurityTokenReferenceStyle.External);
				}
				catch (XmlException)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.TrustDriverIsUnableToCreatedNecessaryAttachedOrUnattachedReferences, xmlElement.ToString())));
				}
			}
		}

		internal bool TryReadKeyIdentifierClause(XmlNodeReader reader, out SecurityKeyIdentifierClause keyIdentifierClause)
		{
			keyIdentifierClause = null;
			try
			{
				keyIdentifierClause = _standardsManager.SecurityTokenSerializer.ReadKeyIdentifierClause(reader);
			}
			catch (XmlException exception)
			{
				if (Fx.IsFatal(exception))
				{
					throw;
				}
				keyIdentifierClause = null;
				return false;
			}
			catch (Exception exception2)
			{
				if (Fx.IsFatal(exception2))
				{
					throw;
				}
				keyIdentifierClause = null;
				return false;
			}
			return true;
		}

		internal SecurityKeyIdentifierClause CreateGenericXmlSecurityKeyIdentifierClause(XmlNodeReader reader, XmlElement keyIdentifierReferenceXmlElement)
		{
			SecurityKeyIdentifierClause securityKeyIdentifierClause = null;
			XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader);
			string attribute = xmlDictionaryReader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			securityKeyIdentifierClause = new GenericXmlSecurityKeyIdentifierClause(keyIdentifierReferenceXmlElement);
			if (!string.IsNullOrEmpty(attribute))
			{
				securityKeyIdentifierClause.Id = attribute;
			}
			return securityKeyIdentifierClause;
		}

		internal SecurityKeyIdentifierClause GetKeyIdentifierXmlReferenceClause(XmlElement keyIdentifierReferenceXmlElement)
		{
			SecurityKeyIdentifierClause keyIdentifierClause = null;
			XmlNodeReader reader = new XmlNodeReader(keyIdentifierReferenceXmlElement);
			if (!TryReadKeyIdentifierClause(reader, out keyIdentifierClause))
			{
				keyIdentifierClause = CreateGenericXmlSecurityKeyIdentifierClause(new XmlNodeReader(keyIdentifierReferenceXmlElement), keyIdentifierReferenceXmlElement);
			}
			return keyIdentifierClause;
		}

		protected virtual bool ReadRequestedTokenClosed(XmlElement rstrXml)
		{
			return false;
		}

		protected virtual void ReadTargets(XmlElement rstXml, out SecurityKeyIdentifierClause renewTarget, out SecurityKeyIdentifierClause closeTarget)
		{
			renewTarget = null;
			closeTarget = null;
		}

		private void WriteAppliesTo(object appliesTo, Type appliesToType, XmlObjectSerializer serializer, XmlWriter xmlWriter)
		{
			XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
			xmlDictionaryWriter.WriteStartElement("wsp", DriverDictionary.AppliesTo.Value, "http://schemas.xmlsoap.org/ws/2004/09/policy");
			lock (serializer)
			{
				serializer.WriteObject(xmlDictionaryWriter, appliesTo);
			}
			xmlDictionaryWriter.WriteEndElement();
		}

		public void WriteBinaryNegotiation(BinaryNegotiation negotiation, XmlWriter xmlWriter)
		{
			if (negotiation == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("negotiation");
			}
			XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
			negotiation.WriteTo(writer, DriverDictionary.Prefix.Value, DriverDictionary.BinaryExchange, DriverDictionary.Namespace, XD.SecurityJan2004Dictionary.ValueType, null);
		}

		public override void WriteRequestSecurityToken(RequestSecurityToken rst, XmlWriter xmlWriter)
		{
			if (rst == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rst");
			}
			if (xmlWriter == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("xmlWriter");
			}
			XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
			if (rst.IsReceiver)
			{
				rst.WriteTo(xmlDictionaryWriter);
				return;
			}
			xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestSecurityToken, DriverDictionary.Namespace);
			XmlHelper.AddNamespaceDeclaration(xmlDictionaryWriter, DriverDictionary.Prefix.Value, DriverDictionary.Namespace);
			if (rst.Context != null)
			{
				xmlDictionaryWriter.WriteAttributeString(DriverDictionary.Context, null, rst.Context);
			}
			rst.OnWriteCustomAttributes(xmlDictionaryWriter);
			if (rst.TokenType != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.TokenType, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteString(rst.TokenType);
				xmlDictionaryWriter.WriteEndElement();
			}
			if (rst.RequestType != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestType, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteString(rst.RequestType);
				xmlDictionaryWriter.WriteEndElement();
			}
			if (rst.AppliesTo != null)
			{
				WriteAppliesTo(rst.AppliesTo, rst.AppliesToType, rst.AppliesToSerializer, xmlDictionaryWriter);
			}
			SecurityToken requestorEntropy = rst.GetRequestorEntropy();
			if (requestorEntropy != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.Entropy, DriverDictionary.Namespace);
				_standardsManager.SecurityTokenSerializer.WriteToken(xmlDictionaryWriter, requestorEntropy);
				xmlDictionaryWriter.WriteEndElement();
			}
			if (rst.KeySize != 0)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.KeySize, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteValue(rst.KeySize);
				xmlDictionaryWriter.WriteEndElement();
			}
			BinaryNegotiation binaryNegotiation = rst.GetBinaryNegotiation();
			if (binaryNegotiation != null)
			{
				WriteBinaryNegotiation(binaryNegotiation, xmlDictionaryWriter);
			}
			WriteTargets(rst, xmlDictionaryWriter);
			if (rst.RequestProperties != null)
			{
				foreach (XmlElement requestProperty in rst.RequestProperties)
				{
					requestProperty.WriteTo(xmlDictionaryWriter);
				}
			}
			rst.OnWriteCustomElements(xmlDictionaryWriter);
			xmlDictionaryWriter.WriteEndElement();
		}

		protected virtual void WriteTargets(RequestSecurityToken rst, XmlDictionaryWriter writer)
		{
		}

		protected virtual void WriteReferences(RequestSecurityTokenResponse rstr, XmlDictionaryWriter writer)
		{
			if (rstr.RequestedUnattachedReference != null)
			{
				writer.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestedTokenReference, DriverDictionary.Namespace);
				_standardsManager.SecurityTokenSerializer.WriteKeyIdentifierClause(writer, rstr.RequestedUnattachedReference);
				writer.WriteEndElement();
			}
		}

		protected virtual void WriteRequestedTokenClosed(RequestSecurityTokenResponse rstr, XmlDictionaryWriter writer)
		{
		}

		public override void WriteRequestSecurityTokenResponse(RequestSecurityTokenResponse rstr, XmlWriter xmlWriter)
		{
			if (rstr == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstr");
			}
			if (xmlWriter == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("xmlWriter");
			}
			XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
			if (rstr.IsReceiver)
			{
				rstr.WriteTo(xmlDictionaryWriter);
				return;
			}
			xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestSecurityTokenResponse, DriverDictionary.Namespace);
			if (rstr.Context != null)
			{
				xmlDictionaryWriter.WriteAttributeString(DriverDictionary.Context, null, rstr.Context);
			}
			XmlHelper.AddNamespaceDeclaration(xmlDictionaryWriter, "u", XD.UtilityDictionary.Namespace);
			rstr.OnWriteCustomAttributes(xmlDictionaryWriter);
			if (rstr.TokenType != null)
			{
				xmlDictionaryWriter.WriteElementString(DriverDictionary.Prefix.Value, DriverDictionary.TokenType, DriverDictionary.Namespace, rstr.TokenType);
			}
			if (rstr.RequestedSecurityToken != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestedSecurityToken, DriverDictionary.Namespace);
				_standardsManager.SecurityTokenSerializer.WriteToken(xmlDictionaryWriter, rstr.RequestedSecurityToken);
				xmlDictionaryWriter.WriteEndElement();
			}
			if (rstr.AppliesTo != null)
			{
				WriteAppliesTo(rstr.AppliesTo, rstr.AppliesToType, rstr.AppliesToSerializer, xmlDictionaryWriter);
			}
			WriteReferences(rstr, xmlDictionaryWriter);
			if (rstr.ComputeKey || rstr.RequestedProofToken != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestedProofToken, DriverDictionary.Namespace);
				if (rstr.ComputeKey)
				{
					xmlDictionaryWriter.WriteElementString(DriverDictionary.Prefix.Value, DriverDictionary.ComputedKey, DriverDictionary.Namespace, DriverDictionary.Psha1ComputedKeyUri.Value);
				}
				else
				{
					_standardsManager.SecurityTokenSerializer.WriteToken(xmlDictionaryWriter, rstr.RequestedProofToken);
				}
				xmlDictionaryWriter.WriteEndElement();
			}
			SecurityToken issuerEntropy = rstr.GetIssuerEntropy();
			if (issuerEntropy != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.Entropy, DriverDictionary.Namespace);
				_standardsManager.SecurityTokenSerializer.WriteToken(xmlDictionaryWriter, issuerEntropy);
				xmlDictionaryWriter.WriteEndElement();
			}
			if (rstr.IsLifetimeSet || rstr.RequestedSecurityToken != null)
			{
				DateTime dateTime = SecurityUtils.MinUtcDateTime;
				DateTime dateTime2 = SecurityUtils.MaxUtcDateTime;
				if (rstr.IsLifetimeSet)
				{
					dateTime = rstr.ValidFrom.ToUniversalTime();
					dateTime2 = rstr.ValidTo.ToUniversalTime();
				}
				else if (rstr.RequestedSecurityToken != null)
				{
					dateTime = rstr.RequestedSecurityToken.ValidFrom.ToUniversalTime();
					dateTime2 = rstr.RequestedSecurityToken.ValidTo.ToUniversalTime();
				}
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.Lifetime, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteStartElement(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.CreatedElement, XD.UtilityDictionary.Namespace);
				xmlDictionaryWriter.WriteString(dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture.DateTimeFormat));
				xmlDictionaryWriter.WriteEndElement();
				xmlDictionaryWriter.WriteStartElement(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.ExpiresElement, XD.UtilityDictionary.Namespace);
				xmlDictionaryWriter.WriteString(dateTime2.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture.DateTimeFormat));
				xmlDictionaryWriter.WriteEndElement();
				xmlDictionaryWriter.WriteEndElement();
			}
			byte[] authenticator = rstr.GetAuthenticator();
			if (authenticator != null)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.Authenticator, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.CombinedHash, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteBase64(authenticator, 0, authenticator.Length);
				xmlDictionaryWriter.WriteEndElement();
				xmlDictionaryWriter.WriteEndElement();
			}
			if (rstr.KeySize > 0)
			{
				xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.KeySize, DriverDictionary.Namespace);
				xmlDictionaryWriter.WriteValue(rstr.KeySize);
				xmlDictionaryWriter.WriteEndElement();
			}
			WriteRequestedTokenClosed(rstr, xmlDictionaryWriter);
			BinaryNegotiation binaryNegotiation = rstr.GetBinaryNegotiation();
			if (binaryNegotiation != null)
			{
				WriteBinaryNegotiation(binaryNegotiation, xmlDictionaryWriter);
			}
			rstr.OnWriteCustomElements(xmlDictionaryWriter);
			xmlDictionaryWriter.WriteEndElement();
		}

		public override void WriteRequestSecurityTokenResponseCollection(RequestSecurityTokenResponseCollection rstrCollection, XmlWriter xmlWriter)
		{
			if (rstrCollection == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstrCollection");
			}
			XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
			xmlDictionaryWriter.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestSecurityTokenResponseCollection, DriverDictionary.Namespace);
			foreach (RequestSecurityTokenResponse item in rstrCollection.RstrCollection)
			{
				item.WriteTo(xmlDictionaryWriter);
			}
			xmlDictionaryWriter.WriteEndElement();
		}

		protected void SetProtectionLevelForFederation(OperationDescriptionCollection operations)
		{
			foreach (OperationDescription operation in operations)
			{
				foreach (MessageDescription message in operation.Messages)
				{
					if (message.Body.Parts.Count > 0)
					{
						foreach (MessagePartDescription part in message.Body.Parts)
						{
							part.ProtectionLevel = ProtectionLevel.EncryptAndSign;
						}
					}
					if (OperationFormatter.IsValidReturnValue(message.Body.ReturnValue))
					{
						message.Body.ReturnValue.ProtectionLevel = ProtectionLevel.EncryptAndSign;
					}
				}
			}
		}

		public bool TryParseSymmetricKeyElement(XmlElement element)
		{
			if (element == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
			}
			if (element.LocalName == DriverDictionary.KeyType.Value && element.NamespaceURI == DriverDictionary.Namespace.Value)
			{
				return element.InnerText == DriverDictionary.SymmetricKeyType.Value;
			}
			return false;
		}

		private XmlElement CreateSymmetricKeyTypeElement()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement(DriverDictionary.Prefix.Value, DriverDictionary.KeyType.Value, DriverDictionary.Namespace.Value);
			xmlElement.AppendChild(xmlDocument.CreateTextNode(DriverDictionary.SymmetricKeyType.Value));
			return xmlElement;
		}

		private bool TryParsePublicKeyElement(XmlElement element)
		{
			if (element == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
			}
			if (element.LocalName == DriverDictionary.KeyType.Value && element.NamespaceURI == DriverDictionary.Namespace.Value)
			{
				return element.InnerText == DriverDictionary.PublicKeyType.Value;
			}
			return false;
		}

		private XmlElement CreatePublicKeyTypeElement()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement(DriverDictionary.Prefix.Value, DriverDictionary.KeyType.Value, DriverDictionary.Namespace.Value);
			xmlElement.AppendChild(xmlDocument.CreateTextNode(DriverDictionary.PublicKeyType.Value));
			return xmlElement;
		}

		internal static void ValidateRequestedKeySize(int keySize, SecurityAlgorithmSuite algorithmSuite)
		{
			if (keySize % 8 == 0 && algorithmSuite.IsSymmetricKeyLengthSupported(keySize))
			{
				return;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SecurityNegotiationException(System.SR.Format(System.SR.InvalidKeyLengthRequested, keySize)));
		}

		private static void ValidateRequestorEntropy(SecurityToken entropy, SecurityKeyEntropyMode mode)
		{
			if ((mode == SecurityKeyEntropyMode.ClientEntropy || mode == SecurityKeyEntropyMode.CombinedEntropy) && entropy == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeRequiresRequestorEntropy, mode)));
			}
			if (mode == SecurityKeyEntropyMode.ServerEntropy && entropy != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.EntropyModeCannotHaveRequestorEntropy, mode)));
			}
		}
	}

	public WSSecurityTokenSerializer WSSecurityTokenSerializer { get; }

	public abstract TrustDictionary SerializerDictionary { get; }

	public WSTrust(WSSecurityTokenSerializer tokenSerializer)
	{
		WSSecurityTokenSerializer = tokenSerializer;
	}

	public override void PopulateTokenEntries(IList<WSSecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		tokenEntryList.Add(new BinarySecretTokenEntry(this));
	}
}
