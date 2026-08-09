using System.IdentityModel.Tokens;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Security;

internal sealed class ReceiveSecurityHeaderElementManager
{
	private const int InitialCapacity = 8;

	private readonly ReceiveSecurityHeader _securityHeader;

	private ReceiveSecurityHeaderEntry[] _elements;

	private readonly string[] _headerIds;

	public int Count { get; private set; }

	public bool IsPrimaryTokenSigned { get; set; }

	public ReceiveSecurityHeaderElementManager(ReceiveSecurityHeader securityHeader)
	{
		_securityHeader = securityHeader;
		_elements = new ReceiveSecurityHeaderEntry[8];
		if (securityHeader.RequireMessageProtection)
		{
			_headerIds = new string[securityHeader.ProcessedMessage.Headers.Count];
		}
	}

	public void AppendElement(ReceiveSecurityHeaderElementCategory elementCategory, object element, ReceiveSecurityHeaderBindingModes bindingMode, string id, TokenTracker supportingTokenTracker)
	{
		if (id != null)
		{
			VerifyIdUniquenessInSecurityHeader(id);
		}
		EnsureCapacityToAdd();
		_elements[Count++].SetElement(elementCategory, element, bindingMode, id, encrypted: false, null, supportingTokenTracker);
	}

	public void AppendTimestamp(SecurityTimestamp timestamp)
	{
		AppendElement(ReceiveSecurityHeaderElementCategory.Timestamp, timestamp, ReceiveSecurityHeaderBindingModes.Unknown, timestamp.Id, null);
	}

	public void AppendToken(SecurityToken token, ReceiveSecurityHeaderBindingModes mode, TokenTracker supportingTokenTracker)
	{
		AppendElement(ReceiveSecurityHeaderElementCategory.Token, token, mode, token.Id, supportingTokenTracker);
	}

	private void EnsureCapacityToAdd()
	{
		if (Count == _elements.Length)
		{
			ReceiveSecurityHeaderEntry[] array = new ReceiveSecurityHeaderEntry[_elements.Length * 2];
			Array.Copy(_elements, 0, array, 0, Count);
			_elements = array;
		}
	}

	public object GetElement(int index)
	{
		return _elements[index]._element;
	}

	public void GetElementEntry(int index, out ReceiveSecurityHeaderEntry element)
	{
		element = _elements[index];
	}

	public ReceiveSecurityHeaderElementCategory GetElementCategory(int index)
	{
		return _elements[index]._elementCategory;
	}

	internal XmlDictionaryReader GetReader(int index, bool requiresEncryptedFormReader)
	{
		if (!requiresEncryptedFormReader)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		XmlDictionaryReader xmlDictionaryReader = _securityHeader.CreateSecurityHeaderReader();
		xmlDictionaryReader.ReadStartElement();
		int num = 0;
		while (xmlDictionaryReader.IsStartElement() && num < index)
		{
			xmlDictionaryReader.Skip();
			num++;
		}
		return xmlDictionaryReader;
	}

	private void OnDuplicateId(string id)
	{
		throw TraceUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.DuplicateIdInMessageToBeVerified, id)), _securityHeader.SecurityVerifiedMessage);
	}

	public void SetBindingMode(int index, ReceiveSecurityHeaderBindingModes bindingMode)
	{
		_elements[index]._bindingMode = bindingMode;
	}

	public void SetElementAfterDecryption(int index, ReceiveSecurityHeaderElementCategory elementCategory, object element, ReceiveSecurityHeaderBindingModes bindingMode, string id, byte[] decryptedBuffer, TokenTracker supportingTokenTracker)
	{
		if (id != null)
		{
			VerifyIdUniquenessInSecurityHeader(id);
		}
		_elements[index].PreserveIdBeforeDecryption();
		_elements[index].SetElement(elementCategory, element, bindingMode, id, encrypted: true, decryptedBuffer, supportingTokenTracker);
	}

	public void SetTokenAfterDecryption(int index, SecurityToken token, ReceiveSecurityHeaderBindingModes mode, byte[] decryptedBuffer, TokenTracker supportingTokenTracker)
	{
		SetElementAfterDecryption(index, ReceiveSecurityHeaderElementCategory.Token, token, mode, token.Id, decryptedBuffer, supportingTokenTracker);
	}

	private void VerifyIdUniquenessInSecurityHeader(string id)
	{
		for (int i = 0; i < Count; i++)
		{
			if (_elements[i]._id == id || _elements[i]._encryptedFormId == id)
			{
				OnDuplicateId(id);
			}
		}
	}
}
