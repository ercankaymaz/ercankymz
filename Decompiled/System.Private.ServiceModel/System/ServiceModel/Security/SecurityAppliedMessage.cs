using System.IO;
using System.IdentityModel;
using System.Runtime;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

internal sealed class SecurityAppliedMessage : DelegatingMessage
{
	private enum BodyState
	{
		Created,
		Signed,
		SignedThenEncrypted,
		EncryptedThenSigned,
		Encrypted,
		Disposed
	}

	private sealed class MessagePrefixGenerator : IPrefixGenerator
	{
		private XmlWriter _writer;

		public MessagePrefixGenerator(XmlWriter writer)
		{
			_writer = writer;
		}

		public string GetPrefix(string namespaceUri, int depth, bool isForAttribute)
		{
			return _writer.LookupPrefix(namespaceUri);
		}
	}

	private bool _bodyIdInserted;

	private string _bodyPrefix = "s";

	private XmlBuffer _fullBodyBuffer;

	private XmlAttributeHolder[] _bodyAttributes;

	private bool _delayedApplicationHandled;

	private BodyState _state;

	private readonly SendSecurityHeader _securityHeader;

	private MemoryStream _startBodyFragment;

	private MemoryStream _endBodyFragment;

	private byte[] _fullBodyFragment;

	private int _fullBodyFragmentLength;

	public string BodyId { get; private set; }

	public MessagePartProtectionMode BodyProtectionMode { get; }

	public SecurityAppliedMessage(Message messageToProcess, SendSecurityHeader securityHeader, bool signBody, bool encryptBody)
		: base(messageToProcess)
	{
		_securityHeader = securityHeader;
		BodyProtectionMode = MessagePartProtectionModeHelper.GetProtectionMode(signBody, encryptBody, securityHeader.SignThenEncrypt);
	}

	private Exception CreateBadStateException(string operation)
	{
		return new InvalidOperationException(System.SR.Format(System.SR.MessageBodyOperationNotValidInBodyState, operation, _state));
	}

	private void EnsureUniqueSecurityApplication()
	{
		if (_delayedApplicationHandled)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.DelayedSecurityApplicationAlreadyCompleted));
		}
		_delayedApplicationHandled = true;
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		if (_state == BodyState.Created || _fullBodyFragment != null)
		{
			base.OnBodyToString(writer);
		}
		else
		{
			OnWriteBodyContents(writer);
		}
	}

	protected override void OnClose()
	{
		try
		{
			base.InnerMessage.Close();
		}
		finally
		{
			_fullBodyBuffer = null;
			_bodyAttributes = null;
			_state = BodyState.Disposed;
		}
	}

	protected override void OnWriteStartBody(XmlDictionaryWriter writer)
	{
		if (_startBodyFragment != null || _fullBodyFragment != null)
		{
			WriteStartInnerMessageWithId(writer);
			return;
		}
		switch (_state)
		{
		case BodyState.Created:
		case BodyState.Encrypted:
			base.InnerMessage.WriteStartBody(writer);
			break;
		case BodyState.Signed:
		case BodyState.EncryptedThenSigned:
		{
			XmlDictionaryReader reader = _fullBodyBuffer.GetReader(0);
			writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
			writer.WriteAttributes(reader, defattr: false);
			reader.Close();
			break;
		}
		case BodyState.SignedThenEncrypted:
			writer.WriteStartElement(_bodyPrefix, XD.MessageDictionary.Body, Version.Envelope.DictionaryNamespace);
			if (_bodyAttributes != null)
			{
				XmlAttributeHolder.WriteAttributes(_bodyAttributes, writer);
			}
			break;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBadStateException("OnWriteStartBody"));
		}
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		switch (_state)
		{
		case BodyState.Created:
			base.InnerMessage.WriteBodyContents(writer);
			break;
		case BodyState.Signed:
		case BodyState.EncryptedThenSigned:
		{
			XmlDictionaryReader reader = _fullBodyBuffer.GetReader(0);
			reader.ReadStartElement();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				writer.WriteNode(reader, defattr: false);
			}
			reader.ReadEndElement();
			reader.Close();
			break;
		}
		case BodyState.SignedThenEncrypted:
		case BodyState.Encrypted:
			throw ExceptionHelper.PlatformNotSupported();
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBadStateException("OnWriteBodyContents"));
		}
	}

	protected override async Task OnWriteBodyContentsAsync(XmlDictionaryWriter writer)
	{
		switch (_state)
		{
		case BodyState.Created:
			await base.InnerMessage.WriteBodyContentsAsync(writer);
			break;
		case BodyState.Signed:
		case BodyState.EncryptedThenSigned:
		{
			XmlDictionaryReader reader = _fullBodyBuffer.GetReader(0);
			reader.ReadStartElement();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				await writer.WriteNodeAsync(reader, defattr: false);
			}
			reader.ReadEndElement();
			reader.Close();
			break;
		}
		case BodyState.SignedThenEncrypted:
		case BodyState.Encrypted:
			throw ExceptionHelper.PlatformNotSupported();
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBadStateException("OnWriteBodyContentsAsync"));
		}
	}

	protected override void OnWriteMessage(XmlDictionaryWriter writer)
	{
		AttachChannelBindingTokenIfFound();
		EnsureUniqueSecurityApplication();
		MessagePrefixGenerator prefixGenerator = new MessagePrefixGenerator(writer);
		_securityHeader.StartSecurityApplication();
		Headers.Add(_securityHeader);
		base.InnerMessage.WriteStartEnvelope(writer);
		Headers.RemoveAt(Headers.Count - 1);
		_securityHeader.ApplyBodySecurity(writer, prefixGenerator);
		base.InnerMessage.WriteStartHeaders(writer);
		_securityHeader.ApplySecurityAndWriteHeaders(Headers, writer, prefixGenerator);
		_securityHeader.RemoveSignatureEncryptionIfAppropriate();
		_securityHeader.CompleteSecurityApplication();
		_securityHeader.WriteHeader(writer, Version);
		writer.WriteEndElement();
		if (_fullBodyFragment != null)
		{
			((IFragmentCapableXmlDictionaryWriter)writer).WriteFragment(_fullBodyFragment, 0, _fullBodyFragmentLength);
		}
		else
		{
			if (_startBodyFragment != null)
			{
				((IFragmentCapableXmlDictionaryWriter)writer).WriteFragment(_startBodyFragment.GetBuffer(), 0, (int)_startBodyFragment.Length);
			}
			else
			{
				OnWriteStartBody(writer);
			}
			OnWriteBodyContents(writer);
			if (_endBodyFragment != null)
			{
				((IFragmentCapableXmlDictionaryWriter)writer).WriteFragment(_endBodyFragment.GetBuffer(), 0, (int)_endBodyFragment.Length);
			}
			else
			{
				writer.WriteEndElement();
			}
		}
		writer.WriteEndElement();
	}

	public override async Task OnWriteMessageAsync(XmlDictionaryWriter writer)
	{
		AttachChannelBindingTokenIfFound();
		EnsureUniqueSecurityApplication();
		MessagePrefixGenerator prefixGenerator = new MessagePrefixGenerator(writer);
		_securityHeader.StartSecurityApplication();
		Headers.Add(_securityHeader);
		base.InnerMessage.WriteStartEnvelope(writer);
		Headers.RemoveAt(Headers.Count - 1);
		_securityHeader.ApplyBodySecurity(writer, prefixGenerator);
		base.InnerMessage.WriteStartHeaders(writer);
		_securityHeader.ApplySecurityAndWriteHeaders(Headers, writer, prefixGenerator);
		_securityHeader.RemoveSignatureEncryptionIfAppropriate();
		_securityHeader.CompleteSecurityApplication();
		_securityHeader.WriteHeader(writer, Version);
		await writer.WriteEndElementAsync();
		if (_fullBodyFragment != null)
		{
			((IFragmentCapableXmlDictionaryWriter)writer).WriteFragment(_fullBodyFragment, 0, _fullBodyFragmentLength);
		}
		else
		{
			if (_startBodyFragment != null)
			{
				((IFragmentCapableXmlDictionaryWriter)writer).WriteFragment(_startBodyFragment.GetBuffer(), 0, (int)_startBodyFragment.Length);
			}
			else
			{
				OnWriteStartBody(writer);
			}
			await OnWriteBodyContentsAsync(writer);
			if (_endBodyFragment != null)
			{
				((IFragmentCapableXmlDictionaryWriter)writer).WriteFragment(_endBodyFragment.GetBuffer(), 0, (int)_endBodyFragment.Length);
			}
			else
			{
				writer.WriteEndElement();
			}
		}
		await writer.WriteEndElementAsync();
	}

	private void AttachChannelBindingTokenIfFound()
	{
	}

	private void SetBodyId()
	{
		BodyId = base.InnerMessage.GetBodyAttribute("Id", _securityHeader.StandardsManager.IdManager.DefaultIdNamespaceUri);
		if (BodyId == null)
		{
			BodyId = _securityHeader.GenerateId();
			_bodyIdInserted = true;
		}
	}

	public void WriteBodyToSign(Stream canonicalStream)
	{
		SetBodyId();
		_fullBodyBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter xmlDictionaryWriter = _fullBodyBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		xmlDictionaryWriter.StartCanonicalization(canonicalStream, includeComments: false, null);
		WriteInnerMessageWithId(xmlDictionaryWriter);
		xmlDictionaryWriter.EndCanonicalization();
		xmlDictionaryWriter.Flush();
		_fullBodyBuffer.CloseSection();
		_fullBodyBuffer.Close();
		_state = BodyState.Signed;
	}

	public void WriteBodyToSignWithFragments(Stream stream, bool includeComments, string[] inclusivePrefixes, XmlDictionaryWriter writer)
	{
		IFragmentCapableXmlDictionaryWriter fragmentCapableXmlDictionaryWriter = (IFragmentCapableXmlDictionaryWriter)writer;
		SetBodyId();
		BufferedOutputStream bufferedOutputStream = new BufferManagerOutputStream(System.SR.XmlBufferQuotaExceeded, 1024, int.MaxValue, _securityHeader.StreamBufferManager);
		writer.StartCanonicalization(stream, includeComments, inclusivePrefixes);
		fragmentCapableXmlDictionaryWriter.StartFragment(bufferedOutputStream, generateSelfContainedTextFragment: false);
		WriteStartInnerMessageWithId(writer);
		base.InnerMessage.WriteBodyContents(writer);
		writer.WriteEndElement();
		fragmentCapableXmlDictionaryWriter.EndFragment();
		writer.EndCanonicalization();
		_fullBodyFragment = bufferedOutputStream.ToArray(out _fullBodyFragmentLength);
		_state = BodyState.Signed;
	}

	private void WriteInnerMessageWithId(XmlDictionaryWriter writer)
	{
		WriteStartInnerMessageWithId(writer);
		base.InnerMessage.WriteBodyContents(writer);
		writer.WriteEndElement();
	}

	private void WriteStartInnerMessageWithId(XmlDictionaryWriter writer)
	{
		base.InnerMessage.WriteStartBody(writer);
		if (_bodyIdInserted)
		{
			_securityHeader.StandardsManager.IdManager.WriteIdAttribute(writer, BodyId);
		}
	}
}
