using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Tokens;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class SendSecurityHeader : SecurityHeader, IMessageHeaderWithSharedNamespace
{
	private bool _encryptSignature;

	private bool _primarySignatureDone;

	private SignatureConfirmations _signatureValuesGenerated;

	private SignatureConfirmations _signatureConfirmationsToSend;

	private int _idCounter;

	private string _idPrefix;

	private MessagePartSpecification _signatureParts;

	private List<SecurityTokenParameters> _basicSupportingTokenParameters;

	private List<SecurityTokenParameters> _endorsingTokenParameters;

	private List<SecurityTokenParameters> _signedEndorsingTokenParameters;

	private List<SecurityTokenParameters> _signedTokenParameters;

	private byte[] _primarySignatureValue;

	private bool _shouldProtectTokens;

	private BufferManager _bufferManager;

	private SecurityProtocolCorrelationState _correlationState;

	private bool _signThenEncrypt = true;

	private static readonly string[] s_ids = new string[10] { "_0", "_1", "_2", "_3", "_4", "_5", "_6", "_7", "_8", "_9" };

	public SendSecurityHeaderElementContainer ElementContainer { get; }

	public BufferManager StreamBufferManager
	{
		get
		{
			if (_bufferManager == null)
			{
				_bufferManager = BufferManager.CreateBufferManager(0L, int.MaxValue);
			}
			return _bufferManager;
		}
		set
		{
			_bufferManager = value;
		}
	}

	protected SecurityAppliedMessage SecurityAppliedMessage => (SecurityAppliedMessage)base.Message;

	public bool SignThenEncrypt
	{
		get
		{
			return _signThenEncrypt;
		}
		set
		{
			ThrowIfProcessingStarted();
			_signThenEncrypt = value;
		}
	}

	public bool ShouldProtectTokens
	{
		get
		{
			return _shouldProtectTokens;
		}
		set
		{
			ThrowIfProcessingStarted();
			_shouldProtectTokens = value;
		}
	}

	public bool EncryptPrimarySignature
	{
		get
		{
			return _encryptSignature;
		}
		set
		{
			ThrowIfProcessingStarted();
			if (value)
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
			_encryptSignature = value;
		}
	}

	XmlDictionaryString IMessageHeaderWithSharedNamespace.SharedNamespace => XD.UtilityDictionary.Namespace;

	XmlDictionaryString IMessageHeaderWithSharedNamespace.SharedPrefix => XD.UtilityDictionary.Prefix;

	public string IdPrefix
	{
		get
		{
			return _idPrefix;
		}
		set
		{
			ThrowIfProcessingStarted();
			_idPrefix = ((string.IsNullOrEmpty(value) || value == "_") ? null : value);
		}
	}

	protected internal SecurityTokenParameters SigningTokenParameters { get; }

	protected bool ShouldSignToHeader { get; private set; }

	public override string Name => base.StandardsManager.SecurityVersion.HeaderName.Value;

	public override string Namespace => base.StandardsManager.SecurityVersion.HeaderNamespace.Value;

	public SecurityTimestamp Timestamp => ElementContainer.Timestamp;

	protected SendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection transferDirection)
		: base(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, transferDirection)
	{
		ElementContainer = new SendSecurityHeaderElementContainer();
	}

	public void AddBasicSupportingToken(SecurityToken token, SecurityTokenParameters parameters)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		ThrowIfProcessingStarted();
		SendSecurityHeaderElement sendSecurityHeaderElement = new SendSecurityHeaderElement(token.Id, new TokenElement(token, base.StandardsManager));
		sendSecurityHeaderElement.MarkedForEncryption = true;
		ElementContainer.AddBasicSupportingToken(sendSecurityHeaderElement);
		AddParameters(ref _basicSupportingTokenParameters, parameters);
	}

	public void AddEndorsingSupportingToken(SecurityToken token, SecurityTokenParameters parameters)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		ThrowIfProcessingStarted();
		ElementContainer.AddEndorsingSupportingToken(token);
		ShouldSignToHeader |= !base.RequireMessageProtection && SecurityUtils.GetSecurityKey<AsymmetricSecurityKey>(token) != null;
		AddParameters(ref _endorsingTokenParameters, parameters);
	}

	public void AddSignedEndorsingSupportingToken(SecurityToken token, SecurityTokenParameters parameters)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		ThrowIfProcessingStarted();
		ElementContainer.AddSignedEndorsingSupportingToken(token);
		AddParameters(ref _signedEndorsingTokenParameters, parameters);
	}

	public void AddSignedSupportingToken(SecurityToken token, SecurityTokenParameters parameters)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		ThrowIfProcessingStarted();
		ElementContainer.AddSignedSupportingToken(token);
		AddParameters(ref _signedTokenParameters, parameters);
	}

	protected bool ShouldUseStrTransformForToken(SecurityToken securityToken, int position, SecurityTokenAttachmentMode mode, out SecurityKeyIdentifierClause keyIdentifierClause)
	{
		keyIdentifierClause = null;
		return false;
	}

	private void AddParameters(ref List<SecurityTokenParameters> list, SecurityTokenParameters item)
	{
		if (list == null)
		{
			list = new List<SecurityTokenParameters>();
		}
		list.Add(item);
	}

	public abstract void ApplyBodySecurity(XmlDictionaryWriter writer, IPrefixGenerator prefixGenerator);

	public abstract void ApplySecurityAndWriteHeaders(MessageHeaders headers, XmlDictionaryWriter writer, IPrefixGenerator prefixGenerator);

	protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		base.StandardsManager.SecurityVersion.WriteStartHeader(writer);
		WriteHeaderAttributes(writer, messageVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		if (ElementContainer.Timestamp != null && base.Layout != SecurityHeaderLayout.LaxTimestampLast)
		{
			base.StandardsManager.WSUtilitySpecificationVersion.WriteTimestamp(writer, ElementContainer.Timestamp);
		}
		if (ElementContainer.PrerequisiteToken != null)
		{
			base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, ElementContainer.PrerequisiteToken);
		}
		if (ElementContainer.SourceSigningToken != null && ShouldSerializeToken(SigningTokenParameters, base.MessageDirection))
		{
			base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, ElementContainer.SourceSigningToken);
			if (ShouldProtectTokens)
			{
				WriteSecurityTokenReferencyEntry(writer, ElementContainer.SourceSigningToken, SigningTokenParameters);
			}
		}
		if (ElementContainer.DerivedSigningToken != null)
		{
			base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, ElementContainer.DerivedSigningToken);
		}
		if (ElementContainer.WrappedEncryptionToken != null)
		{
			base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, ElementContainer.WrappedEncryptionToken);
		}
		if (ElementContainer.DerivedEncryptionToken != null)
		{
			base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, ElementContainer.DerivedEncryptionToken);
		}
		if (SignThenEncrypt && ElementContainer.ReferenceList != null)
		{
			ElementContainer.ReferenceList.WriteTo(writer, ServiceModelDictionaryManager.Instance);
		}
		SecurityToken[] signedSupportingTokens = ElementContainer.GetSignedSupportingTokens();
		if (signedSupportingTokens != null)
		{
			for (int i = 0; i < signedSupportingTokens.Length; i++)
			{
				base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, signedSupportingTokens[i]);
				WriteSecurityTokenReferencyEntry(writer, signedSupportingTokens[i], _signedTokenParameters[i]);
			}
		}
		SendSecurityHeaderElement[] basicSupportingTokens = ElementContainer.GetBasicSupportingTokens();
		if (basicSupportingTokens != null)
		{
			for (int j = 0; j < basicSupportingTokens.Length; j++)
			{
				basicSupportingTokens[j].Item.WriteTo(writer, ServiceModelDictionaryManager.Instance);
				if (SignThenEncrypt)
				{
					WriteSecurityTokenReferencyEntry(writer, null, _basicSupportingTokenParameters[j]);
				}
			}
		}
		SecurityToken[] endorsingSupportingTokens = ElementContainer.GetEndorsingSupportingTokens();
		if (endorsingSupportingTokens != null)
		{
			for (int k = 0; k < endorsingSupportingTokens.Length; k++)
			{
				if (ShouldSerializeToken(_endorsingTokenParameters[k], base.MessageDirection))
				{
					base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, endorsingSupportingTokens[k]);
				}
			}
		}
		SecurityToken[] endorsingDerivedSupportingTokens = ElementContainer.GetEndorsingDerivedSupportingTokens();
		if (endorsingDerivedSupportingTokens != null)
		{
			for (int l = 0; l < endorsingDerivedSupportingTokens.Length; l++)
			{
				base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, endorsingDerivedSupportingTokens[l]);
			}
		}
		SecurityToken[] signedEndorsingSupportingTokens = ElementContainer.GetSignedEndorsingSupportingTokens();
		if (signedEndorsingSupportingTokens != null)
		{
			for (int m = 0; m < signedEndorsingSupportingTokens.Length; m++)
			{
				base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, signedEndorsingSupportingTokens[m]);
				WriteSecurityTokenReferencyEntry(writer, signedEndorsingSupportingTokens[m], _signedEndorsingTokenParameters[m]);
			}
		}
		SecurityToken[] signedEndorsingDerivedSupportingTokens = ElementContainer.GetSignedEndorsingDerivedSupportingTokens();
		if (signedEndorsingDerivedSupportingTokens != null)
		{
			for (int n = 0; n < signedEndorsingDerivedSupportingTokens.Length; n++)
			{
				base.StandardsManager.SecurityTokenSerializer.WriteToken(writer, signedEndorsingDerivedSupportingTokens[n]);
			}
		}
		SendSecurityHeaderElement[] signatureConfirmations = ElementContainer.GetSignatureConfirmations();
		if (signatureConfirmations != null)
		{
			for (int num = 0; num < signatureConfirmations.Length; num++)
			{
				signatureConfirmations[num].Item.WriteTo(writer, ServiceModelDictionaryManager.Instance);
			}
		}
		if (ElementContainer.PrimarySignature != null && ElementContainer.PrimarySignature.Item != null)
		{
			ElementContainer.PrimarySignature.Item.WriteTo(writer, ServiceModelDictionaryManager.Instance);
		}
		SendSecurityHeaderElement[] endorsingSignatures = ElementContainer.GetEndorsingSignatures();
		if (endorsingSignatures != null)
		{
			for (int num2 = 0; num2 < endorsingSignatures.Length; num2++)
			{
				endorsingSignatures[num2].Item.WriteTo(writer, ServiceModelDictionaryManager.Instance);
			}
		}
		if (!SignThenEncrypt && ElementContainer.ReferenceList != null)
		{
			ElementContainer.ReferenceList.WriteTo(writer, ServiceModelDictionaryManager.Instance);
		}
		if (ElementContainer.Timestamp != null && base.Layout == SecurityHeaderLayout.LaxTimestampLast)
		{
			base.StandardsManager.WSUtilitySpecificationVersion.WriteTimestamp(writer, ElementContainer.Timestamp);
		}
	}

	public void AddTimestamp(TimeSpan timestampValidityDuration)
	{
		DateTime utcNow = DateTime.UtcNow;
		string id = (base.RequireMessageProtection ? SecurityUtils.GenerateId() : GenerateId());
		AddTimestamp(new SecurityTimestamp(utcNow, utcNow + timestampValidityDuration, id));
	}

	public void AddTimestamp(SecurityTimestamp timestamp)
	{
		ThrowIfProcessingStarted();
		if (ElementContainer.Timestamp != null)
		{
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.TimestampAlreadySetForSecurityHeader), base.Message);
		}
		ElementContainer.Timestamp = timestamp ?? throw TraceUtility.ThrowHelperArgumentNull("timestamp", base.Message);
	}

	protected abstract void WriteSecurityTokenReferencyEntry(XmlDictionaryWriter writer, SecurityToken securityToken, SecurityTokenParameters securityTokenParameters);

	public Message SetupExecution()
	{
		ThrowIfProcessingStarted();
		SetProcessingStarted();
		bool signBody = false;
		if (ElementContainer.SourceSigningToken != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		bool encryptBody = false;
		if (ElementContainer.SourceEncryptionToken != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		return base.Message = new SecurityAppliedMessage(base.Message, this, signBody, encryptBody);
	}

	protected virtual ISignatureValueSecurityElement[] CreateSignatureConfirmationElements(SignatureConfirmations signatureConfirmations)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SignatureConfirmationNotSupported));
	}

	private void StartEncryption()
	{
		if (ElementContainer.SourceEncryptionToken == null)
		{
			return;
		}
		throw ExceptionHelper.PlatformNotSupported();
	}

	private void CompleteEncryption()
	{
	}

	internal void StartSecurityApplication()
	{
		if (SignThenEncrypt)
		{
			StartSignature();
			StartEncryption();
			return;
		}
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal void CompleteSecurityApplication()
	{
		if (SignThenEncrypt)
		{
			CompleteSignature();
			SignWithSupportingTokens();
			CompleteEncryption();
			if (_correlationState != null)
			{
				_correlationState.SignatureConfirmations = GetSignatureValues();
			}
			return;
		}
		throw ExceptionHelper.PlatformNotSupported();
	}

	public void RemoveSignatureEncryptionIfAppropriate()
	{
	}

	public string GenerateId()
	{
		int num = _idCounter++;
		if (_idPrefix != null)
		{
			return _idPrefix + num;
		}
		if (num < s_ids.Length)
		{
			return s_ids[num];
		}
		return "_" + num;
	}

	private SignatureConfirmations GetSignatureValues()
	{
		return _signatureValuesGenerated;
	}

	internal static bool ShouldSerializeToken(SecurityTokenParameters parameters, MessageDirection transferDirection)
	{
		switch (parameters.InclusionMode)
		{
		case SecurityTokenInclusionMode.AlwaysToInitiator:
			return transferDirection == MessageDirection.Output;
		case SecurityTokenInclusionMode.AlwaysToRecipient:
		case SecurityTokenInclusionMode.Once:
			return transferDirection == MessageDirection.Input;
		case SecurityTokenInclusionMode.Never:
			return false;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedTokenInclusionMode, parameters.InclusionMode)));
		}
	}

	protected internal SecurityTokenReferenceStyle GetTokenReferenceStyle(SecurityTokenParameters parameters)
	{
		if (!ShouldSerializeToken(parameters, base.MessageDirection))
		{
			return SecurityTokenReferenceStyle.External;
		}
		return SecurityTokenReferenceStyle.Internal;
	}

	private void StartSignature()
	{
		if (ElementContainer.SourceSigningToken == null)
		{
			return;
		}
		SecurityTokenReferenceStyle tokenReferenceStyle = GetTokenReferenceStyle(SigningTokenParameters);
		SecurityKeyIdentifierClause securityKeyIdentifierClause = SigningTokenParameters.CreateKeyIdentifierClause(ElementContainer.SourceSigningToken, tokenReferenceStyle);
		if (securityKeyIdentifierClause == null)
		{
			throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.TokenManagerCannotCreateTokenReference), base.Message);
		}
		if (SigningTokenParameters.RequireDerivedKeys && !SigningTokenParameters.HasAsymmetricKey)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		SecurityToken sourceSigningToken = ElementContainer.SourceSigningToken;
		SecurityKeyIdentifierClause securityKeyIdentifierClause2 = securityKeyIdentifierClause;
		SecurityKeyIdentifier identifier = new SecurityKeyIdentifier(securityKeyIdentifierClause2);
		if (_signatureConfirmationsToSend != null && _signatureConfirmationsToSend.Count > 0)
		{
			ISecurityElement[] array = CreateSignatureConfirmationElements(_signatureConfirmationsToSend);
			ISecurityElement[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				SendSecurityHeaderElement sendSecurityHeaderElement = new SendSecurityHeaderElement(array2[i].Id, array2[i]);
				sendSecurityHeaderElement.MarkedForEncryption = _signatureConfirmationsToSend.IsMarkedForEncryption;
				ElementContainer.AddSignatureConfirmation(sendSecurityHeaderElement);
			}
		}
		bool generateTargettablePrimarySignature = _endorsingTokenParameters != null || _signedEndorsingTokenParameters != null;
		StartPrimarySignatureCore(sourceSigningToken, identifier, _signatureParts, generateTargettablePrimarySignature);
	}

	private void CompleteSignature()
	{
		ISignatureValueSecurityElement signatureValueSecurityElement = CompletePrimarySignatureCore(ElementContainer.GetSignatureConfirmations(), ElementContainer.GetSignedEndorsingSupportingTokens(), ElementContainer.GetSignedSupportingTokens(), ElementContainer.GetBasicSupportingTokens(), isPrimarySignature: true);
		if (signatureValueSecurityElement != null)
		{
			ElementContainer.PrimarySignature = new SendSecurityHeaderElement(signatureValueSecurityElement.Id, signatureValueSecurityElement);
			ElementContainer.PrimarySignature.MarkedForEncryption = _encryptSignature;
			AddGeneratedSignatureValue(signatureValueSecurityElement.GetSignatureValue(), EncryptPrimarySignature);
			_primarySignatureDone = true;
			_primarySignatureValue = signatureValueSecurityElement.GetSignatureValue();
		}
	}

	protected abstract void StartPrimarySignatureCore(SecurityToken token, SecurityKeyIdentifier identifier, MessagePartSpecification signatureParts, bool generateTargettablePrimarySignature);

	protected abstract ISignatureValueSecurityElement CompletePrimarySignatureCore(SendSecurityHeaderElement[] signatureConfirmations, SecurityToken[] signedEndorsingTokens, SecurityToken[] signedTokens, SendSecurityHeaderElement[] basicTokens, bool isPrimarySignature);

	protected abstract ISignatureValueSecurityElement CreateSupportingSignature(SecurityToken token, SecurityKeyIdentifier identifier);

	protected abstract ISignatureValueSecurityElement CreateSupportingSignature(SecurityToken token, SecurityKeyIdentifier identifier, ISecurityElement primarySignature);

	private void SignWithSupportingToken(SecurityToken token, SecurityKeyIdentifierClause identifierClause)
	{
		if (token == null)
		{
			throw TraceUtility.ThrowHelperArgumentNull("token", base.Message);
		}
		if (identifierClause == null)
		{
			throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.TokenManagerCannotCreateTokenReference), base.Message);
		}
		if (!base.RequireMessageProtection)
		{
			if (ElementContainer.Timestamp == null)
			{
				throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.SigningWithoutPrimarySignatureRequiresTimestamp), base.Message);
			}
		}
		else
		{
			if (!_primarySignatureDone)
			{
				throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.PrimarySignatureMustBeComputedBeforeSupportingTokenSignatures), base.Message);
			}
			if (ElementContainer.PrimarySignature.Item == null)
			{
				throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.SupportingTokenSignaturesNotExpected), base.Message);
			}
		}
		SecurityKeyIdentifier identifier = new SecurityKeyIdentifier(identifierClause);
		ISignatureValueSecurityElement signatureValueSecurityElement = (base.RequireMessageProtection ? CreateSupportingSignature(token, identifier, ElementContainer.PrimarySignature.Item) : CreateSupportingSignature(token, identifier));
		AddGeneratedSignatureValue(signatureValueSecurityElement.GetSignatureValue(), _encryptSignature);
		SendSecurityHeaderElement sendSecurityHeaderElement = new SendSecurityHeaderElement(signatureValueSecurityElement.Id, signatureValueSecurityElement);
		sendSecurityHeaderElement.MarkedForEncryption = _encryptSignature;
		ElementContainer.AddEndorsingSignature(sendSecurityHeaderElement);
	}

	private void SignWithSupportingTokens()
	{
		SecurityToken[] endorsingSupportingTokens = ElementContainer.GetEndorsingSupportingTokens();
		if (endorsingSupportingTokens != null)
		{
			for (int i = 0; i < endorsingSupportingTokens.Length; i++)
			{
				SecurityToken securityToken = endorsingSupportingTokens[i];
				SecurityKeyIdentifierClause securityKeyIdentifierClause = _endorsingTokenParameters[i].CreateKeyIdentifierClause(securityToken, GetTokenReferenceStyle(_endorsingTokenParameters[i]));
				if (securityKeyIdentifierClause == null)
				{
					throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.TokenManagerCannotCreateTokenReference), base.Message);
				}
				if (_endorsingTokenParameters[i].RequireDerivedKeys && !_endorsingTokenParameters[i].HasAsymmetricKey)
				{
					throw ExceptionHelper.PlatformNotSupported();
				}
				SecurityToken token = securityToken;
				SecurityKeyIdentifierClause identifierClause = securityKeyIdentifierClause;
				SignWithSupportingToken(token, identifierClause);
			}
		}
		SecurityToken[] signedEndorsingSupportingTokens = ElementContainer.GetSignedEndorsingSupportingTokens();
		if (signedEndorsingSupportingTokens == null)
		{
			return;
		}
		for (int j = 0; j < signedEndorsingSupportingTokens.Length; j++)
		{
			SecurityToken securityToken2 = signedEndorsingSupportingTokens[j];
			SecurityKeyIdentifierClause securityKeyIdentifierClause2 = _signedEndorsingTokenParameters[j].CreateKeyIdentifierClause(securityToken2, GetTokenReferenceStyle(_signedEndorsingTokenParameters[j]));
			if (securityKeyIdentifierClause2 == null)
			{
				throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.TokenManagerCannotCreateTokenReference), base.Message);
			}
			if (_signedEndorsingTokenParameters[j].RequireDerivedKeys && !_signedEndorsingTokenParameters[j].HasAsymmetricKey)
			{
				throw ExceptionHelper.PlatformNotSupported();
			}
			SecurityToken token2 = securityToken2;
			SecurityKeyIdentifierClause identifierClause2 = securityKeyIdentifierClause2;
			SignWithSupportingToken(token2, identifierClause2);
		}
	}

	private void AddGeneratedSignatureValue(byte[] signatureValue, bool wasEncrypted)
	{
		if (base.MaintainSignatureConfirmationState && _signatureConfirmationsToSend == null)
		{
			if (_signatureValuesGenerated == null)
			{
				_signatureValuesGenerated = new SignatureConfirmations();
			}
			_signatureValuesGenerated.AddConfirmation(signatureValue, wasEncrypted);
		}
	}
}
