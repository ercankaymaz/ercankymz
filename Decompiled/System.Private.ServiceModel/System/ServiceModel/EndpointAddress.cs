using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

public class EndpointAddress
{
	private static Uri s_anonymousUri;

	private static Uri s_noneUri;

	private static EndpointAddress s_anonymousAddress;

	private AddressingVersion _addressingVersion;

	private AddressHeaderCollection _headers;

	private int _extensionSection;

	private int _metadataSection;

	private int _pspSection;

	private bool _isNone;

	internal const string DummyName = "Dummy";

	internal const string DummyNamespace = "http://Dummy";

	internal static EndpointAddress AnonymousAddress
	{
		get
		{
			if (s_anonymousAddress == null)
			{
				s_anonymousAddress = new EndpointAddress(AnonymousUri);
			}
			return s_anonymousAddress;
		}
	}

	public static Uri AnonymousUri
	{
		get
		{
			if (s_anonymousUri == null)
			{
				s_anonymousUri = new Uri("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous");
			}
			return s_anonymousUri;
		}
	}

	public static Uri NoneUri
	{
		get
		{
			if (s_noneUri == null)
			{
				s_noneUri = new Uri("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/None");
			}
			return s_noneUri;
		}
	}

	internal XmlBuffer Buffer { get; private set; }

	public AddressHeaderCollection Headers
	{
		get
		{
			if (_headers == null)
			{
				_headers = new AddressHeaderCollection();
			}
			return _headers;
		}
	}

	public EndpointIdentity Identity { get; private set; }

	public bool IsAnonymous { get; private set; }

	public bool IsNone => _isNone;

	public Uri Uri { get; private set; }

	private EndpointAddress(AddressingVersion version, Uri uri, EndpointIdentity identity, AddressHeaderCollection headers, XmlBuffer buffer, int metadataSection, int extensionSection, int pspSection)
	{
		Init(version, uri, identity, headers, buffer, metadataSection, extensionSection, pspSection);
	}

	public EndpointAddress(string uri)
	{
		if (uri == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("uri");
		}
		Uri uri2 = new Uri(uri);
		Init(uri2, null, null, null, -1, -1, -1);
	}

	public EndpointAddress(Uri uri, params AddressHeader[] addressHeaders)
		: this(uri, null, addressHeaders)
	{
	}

	public EndpointAddress(Uri uri, EndpointIdentity identity, params AddressHeader[] addressHeaders)
	{
		if (uri == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("uri");
		}
		Init(uri, identity, addressHeaders);
	}

	internal EndpointAddress(Uri newUri, EndpointAddress oldEndpointAddress)
	{
		Init(oldEndpointAddress._addressingVersion, newUri, oldEndpointAddress.Identity, oldEndpointAddress._headers, oldEndpointAddress.Buffer, oldEndpointAddress._metadataSection, oldEndpointAddress._extensionSection, oldEndpointAddress._pspSection);
	}

	internal EndpointAddress(Uri uri, EndpointIdentity identity, AddressHeaderCollection headers, XmlDictionaryReader metadataReader, XmlDictionaryReader extensionReader, XmlDictionaryReader pspReader)
	{
		if (uri == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("uri");
		}
		XmlBuffer buffer = null;
		PossiblyPopulateBuffer(metadataReader, ref buffer, out _metadataSection);
		buffer = ReadExtensions(extensionReader, null, buffer, out var identity2, out var section);
		if (identity != null && identity2 != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.MultipleIdentities, "extensionReader"));
		}
		PossiblyPopulateBuffer(pspReader, ref buffer, out _pspSection);
		buffer?.Close();
		Init(uri, identity ?? identity2, headers, buffer, _metadataSection, section, _pspSection);
	}

	private void Init(Uri uri, EndpointIdentity identity, AddressHeader[] headers)
	{
		if (headers == null || headers.Length == 0)
		{
			Init(uri, identity, null, null, -1, -1, -1);
		}
		else
		{
			Init(uri, identity, new AddressHeaderCollection(headers), null, -1, -1, -1);
		}
	}

	private void Init(Uri uri, EndpointIdentity identity, AddressHeaderCollection headers, XmlBuffer buffer, int metadataSection, int extensionSection, int pspSection)
	{
		Init(null, uri, identity, headers, buffer, metadataSection, extensionSection, pspSection);
	}

	private void Init(AddressingVersion version, Uri uri, EndpointIdentity identity, AddressHeaderCollection headers, XmlBuffer buffer, int metadataSection, int extensionSection, int pspSection)
	{
		if (!uri.IsAbsoluteUri)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("uri", System.SR.UriMustBeAbsolute);
		}
		_addressingVersion = version;
		Uri = uri;
		Identity = identity;
		_headers = headers;
		Buffer = buffer;
		_metadataSection = metadataSection;
		_extensionSection = extensionSection;
		_pspSection = pspSection;
		if (version != null)
		{
			IsAnonymous = uri == version.AnonymousUri;
			_isNone = uri == version.NoneUri;
		}
		else
		{
			IsAnonymous = (object)uri == AnonymousUri || uri == AnonymousUri;
			_isNone = (object)uri == NoneUri || uri == NoneUri;
		}
		if (IsAnonymous)
		{
			Uri = AnonymousUri;
		}
		if (_isNone)
		{
			Uri = NoneUri;
		}
	}

	public void ApplyTo(Message message)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		Uri uri = Uri;
		if (IsAnonymous)
		{
			if (message.Version.Addressing == AddressingVersion.WSAddressing10)
			{
				message.Headers.To = null;
			}
			else
			{
				if (message.Version.Addressing != AddressingVersion.WSAddressingAugust2004)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.AddressingVersionNotSupported, message.Version.Addressing)));
				}
				message.Headers.To = message.Version.Addressing.AnonymousUri;
			}
		}
		else if (IsNone)
		{
			message.Headers.To = message.Version.Addressing.NoneUri;
		}
		else
		{
			message.Headers.To = uri;
		}
		message.Properties.Via = message.Headers.To;
		if (_headers != null)
		{
			_headers.AddHeadersTo(message);
		}
	}

	internal static bool UriEquals(Uri u1, Uri u2, bool ignoreCase, bool includeHostInComparison)
	{
		return UriEquals(u1, u2, ignoreCase, includeHostInComparison, includePortInComparison: true);
	}

	internal static bool UriEquals(Uri u1, Uri u2, bool ignoreCase, bool includeHostInComparison, bool includePortInComparison)
	{
		if (u1.Equals(u2))
		{
			return true;
		}
		if (u1.Scheme != u2.Scheme)
		{
			return false;
		}
		if (includePortInComparison && u1.Port != u2.Port)
		{
			return false;
		}
		if (includeHostInComparison && string.Compare(u1.Host, u2.Host, StringComparison.OrdinalIgnoreCase) != 0)
		{
			return false;
		}
		if (string.Compare(u1.AbsolutePath, u2.AbsolutePath, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) == 0)
		{
			return true;
		}
		string components = u1.GetComponents(UriComponents.Path, UriFormat.Unescaped);
		string components2 = u2.GetComponents(UriComponents.Path, UriFormat.Unescaped);
		int num = ((components.Length > 0 && components[components.Length - 1] == '/') ? (components.Length - 1) : components.Length);
		int num2 = ((components2.Length > 0 && components2[components2.Length - 1] == '/') ? (components2.Length - 1) : components2.Length);
		if (num2 != num)
		{
			return false;
		}
		return string.Compare(components, 0, components2, 0, num, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) == 0;
	}

	internal static int UriGetHashCode(Uri uri, bool includeHostInComparison)
	{
		return UriGetHashCode(uri, includeHostInComparison, includePortInComparison: true);
	}

	internal static int UriGetHashCode(Uri uri, bool includeHostInComparison, bool includePortInComparison)
	{
		UriComponents uriComponents = UriComponents.Scheme | UriComponents.Path;
		if (includePortInComparison)
		{
			uriComponents |= UriComponents.Port;
		}
		if (includeHostInComparison)
		{
			uriComponents |= UriComponents.Host;
		}
		string text = uri.GetComponents(uriComponents, UriFormat.Unescaped);
		if (text.Length > 0 && text[text.Length - 1] != '/')
		{
			text += "/";
		}
		return StringComparer.OrdinalIgnoreCase.GetHashCode(text);
	}

	internal bool EndpointEquals(EndpointAddress endpointAddress)
	{
		if (endpointAddress == null)
		{
			return false;
		}
		if ((object)this == endpointAddress)
		{
			return true;
		}
		Uri uri = Uri;
		Uri uri2 = endpointAddress.Uri;
		if (!UriEquals(uri, uri2, ignoreCase: false, includeHostInComparison: true))
		{
			return false;
		}
		if (Identity == null)
		{
			if (endpointAddress.Identity != null)
			{
				return false;
			}
		}
		else if (!Identity.Equals(endpointAddress.Identity))
		{
			return false;
		}
		if (!Headers.IsEquivalent(endpointAddress.Headers))
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		EndpointAddress endpointAddress = obj as EndpointAddress;
		if (endpointAddress == null)
		{
			return false;
		}
		return EndpointEquals(endpointAddress);
	}

	public override int GetHashCode()
	{
		return UriGetHashCode(Uri, includeHostInComparison: true);
	}

	internal XmlDictionaryReader GetReaderAtPsp()
	{
		return GetReaderAtSection(Buffer, _pspSection);
	}

	public XmlDictionaryReader GetReaderAtMetadata()
	{
		return GetReaderAtSection(Buffer, _metadataSection);
	}

	public XmlDictionaryReader GetReaderAtExtensions()
	{
		return GetReaderAtSection(Buffer, _extensionSection);
	}

	private static XmlDictionaryReader GetReaderAtSection(XmlBuffer buffer, int section)
	{
		if (buffer == null || section < 0)
		{
			return null;
		}
		XmlDictionaryReader reader = buffer.GetReader(section);
		reader.MoveToContent();
		reader.Read();
		return reader;
	}

	private void PossiblyPopulateBuffer(XmlDictionaryReader reader, ref XmlBuffer buffer, out int section)
	{
		if (reader == null)
		{
			section = -1;
			return;
		}
		if (buffer == null)
		{
			buffer = new XmlBuffer(32767);
		}
		section = buffer.SectionCount;
		XmlDictionaryWriter xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
		xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
		Copy(xmlDictionaryWriter, reader);
		buffer.CloseSection();
	}

	public static EndpointAddress ReadFrom(XmlDictionaryReader reader)
	{
		AddressingVersion version;
		return ReadFrom(reader, out version);
	}

	internal static EndpointAddress ReadFrom(XmlDictionaryReader reader, out AddressingVersion version)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
		}
		reader.ReadFullStartElement();
		reader.MoveToContent();
		if (reader.IsNamespaceUri(AddressingVersion.WSAddressing10.DictionaryNamespace))
		{
			version = AddressingVersion.WSAddressing10;
		}
		else
		{
			if (!reader.IsNamespaceUri(AddressingVersion.WSAddressingAugust2004.DictionaryNamespace))
			{
				if (reader.NodeType != XmlNodeType.Element)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("reader", System.SR.CannotDetectAddressingVersion);
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("reader", System.SR.Format(System.SR.AddressingVersionNotSupported, reader.NamespaceURI));
			}
			version = AddressingVersion.WSAddressingAugust2004;
		}
		EndpointAddress result = ReadFromDriver(version, reader);
		reader.ReadEndElement();
		return result;
	}

	public static EndpointAddress ReadFrom(AddressingVersion addressingVersion, XmlDictionaryReader reader)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		reader.ReadFullStartElement();
		EndpointAddress result = ReadFromDriver(addressingVersion, reader);
		reader.ReadEndElement();
		return result;
	}

	public static EndpointAddress ReadFrom(AddressingVersion addressingVersion, XmlDictionaryReader reader, XmlDictionaryString localName, XmlDictionaryString ns)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		reader.ReadFullStartElement(localName, ns);
		EndpointAddress result = ReadFromDriver(addressingVersion, reader);
		reader.ReadEndElement();
		return result;
	}

	private static EndpointAddress ReadFromDriver(AddressingVersion addressingVersion, XmlDictionaryReader reader)
	{
		int pspSection = -1;
		bool flag;
		Uri uri;
		AddressHeaderCollection headers;
		EndpointIdentity identity;
		XmlBuffer buffer;
		int metadataSection;
		int extensionSection;
		if (addressingVersion == AddressingVersion.WSAddressing10)
		{
			flag = ReadContentsFrom10(reader, out uri, out headers, out identity, out buffer, out metadataSection, out extensionSection);
		}
		else
		{
			if (addressingVersion != AddressingVersion.WSAddressingAugust2004)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("addressingVersion", System.SR.Format(System.SR.AddressingVersionNotSupported, addressingVersion));
			}
			flag = ReadContentsFrom200408(reader, out uri, out headers, out identity, out buffer, out metadataSection, out extensionSection, out pspSection);
		}
		if (flag && headers == null && identity == null && buffer == null)
		{
			return AnonymousAddress;
		}
		return new EndpointAddress(addressingVersion, uri, identity, headers, buffer, metadataSection, extensionSection, pspSection);
	}

	internal static XmlBuffer ReadExtensions(XmlDictionaryReader reader, AddressingVersion version, XmlBuffer buffer, out EndpointIdentity identity, out int section)
	{
		if (reader == null)
		{
			identity = null;
			section = -1;
			return buffer;
		}
		identity = null;
		XmlDictionaryWriter xmlDictionaryWriter = null;
		reader.MoveToContent();
		while (reader.IsStartElement())
		{
			if (reader.IsStartElement(XD.AddressingDictionary.Identity, XD.AddressingDictionary.IdentityExtensionNamespace))
			{
				if (identity != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateXmlException(reader, System.SR.Format(System.SR.UnexpectedDuplicateElement, XD.AddressingDictionary.Identity.Value, XD.AddressingDictionary.IdentityExtensionNamespace.Value)));
				}
				identity = EndpointIdentity.ReadIdentity(reader);
			}
			else
			{
				if (version != null && reader.NamespaceURI == version.Namespace)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateXmlException(reader, System.SR.Format(System.SR.AddressingExtensionInBadNS, reader.LocalName, reader.NamespaceURI)));
				}
				if (xmlDictionaryWriter == null)
				{
					if (buffer == null)
					{
						buffer = new XmlBuffer(32767);
					}
					xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
					xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
				}
				xmlDictionaryWriter.WriteNode(reader, defattr: true);
			}
			reader.MoveToContent();
		}
		if (xmlDictionaryWriter != null)
		{
			xmlDictionaryWriter.WriteEndElement();
			buffer.CloseSection();
			section = buffer.SectionCount - 1;
		}
		else
		{
			section = -1;
		}
		return buffer;
	}

	private static bool ReadContentsFrom200408(XmlDictionaryReader reader, out Uri uri, out AddressHeaderCollection headers, out EndpointIdentity identity, out XmlBuffer buffer, out int metadataSection, out int extensionSection, out int pspSection)
	{
		buffer = null;
		headers = null;
		extensionSection = -1;
		metadataSection = -1;
		pspSection = -1;
		reader.MoveToContent();
		if (!reader.IsStartElement(XD.AddressingDictionary.Address, AddressingVersion.WSAddressingAugust2004.DictionaryNamespace))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateXmlException(reader, System.SR.Format(System.SR.UnexpectedElementExpectingElement, reader.LocalName, reader.NamespaceURI, XD.AddressingDictionary.Address.Value, XD.Addressing200408Dictionary.Namespace.Value)));
		}
		string text = reader.ReadElementContentAsString();
		reader.MoveToContent();
		if (reader.IsStartElement(XD.AddressingDictionary.ReferenceProperties, AddressingVersion.WSAddressingAugust2004.DictionaryNamespace))
		{
			headers = AddressHeaderCollection.ReadServiceParameters(reader, isReferenceProperty: true);
		}
		reader.MoveToContent();
		if (reader.IsStartElement(XD.AddressingDictionary.ReferenceParameters, AddressingVersion.WSAddressingAugust2004.DictionaryNamespace))
		{
			if (headers != null)
			{
				List<AddressHeader> list = new List<AddressHeader>();
				foreach (AddressHeader header in headers)
				{
					list.Add(header);
				}
				AddressHeaderCollection addressHeaderCollection = AddressHeaderCollection.ReadServiceParameters(reader);
				foreach (AddressHeader item in addressHeaderCollection)
				{
					list.Add(item);
				}
				headers = new AddressHeaderCollection(list);
			}
			else
			{
				headers = AddressHeaderCollection.ReadServiceParameters(reader);
			}
		}
		XmlDictionaryWriter xmlDictionaryWriter = null;
		reader.MoveToContent();
		if (reader.IsStartElement(XD.AddressingDictionary.PortType, AddressingVersion.WSAddressingAugust2004.DictionaryNamespace))
		{
			if (xmlDictionaryWriter == null)
			{
				if (buffer == null)
				{
					buffer = new XmlBuffer(32767);
				}
				xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
				xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
			}
			xmlDictionaryWriter.WriteNode(reader, defattr: true);
		}
		reader.MoveToContent();
		if (reader.IsStartElement(XD.AddressingDictionary.ServiceName, AddressingVersion.WSAddressingAugust2004.DictionaryNamespace))
		{
			if (xmlDictionaryWriter == null)
			{
				if (buffer == null)
				{
					buffer = new XmlBuffer(32767);
				}
				xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
				xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
			}
			xmlDictionaryWriter.WriteNode(reader, defattr: true);
		}
		reader.MoveToContent();
		while (reader.IsNamespaceUri("http://schemas.xmlsoap.org/ws/2002/12/policy"))
		{
			if (xmlDictionaryWriter == null)
			{
				if (buffer == null)
				{
					buffer = new XmlBuffer(32767);
				}
				xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
				xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
			}
			xmlDictionaryWriter.WriteNode(reader, defattr: true);
			reader.MoveToContent();
		}
		if (xmlDictionaryWriter != null)
		{
			xmlDictionaryWriter.WriteEndElement();
			buffer.CloseSection();
			pspSection = buffer.SectionCount - 1;
			xmlDictionaryWriter = null;
		}
		else
		{
			pspSection = -1;
		}
		if (reader.IsStartElement("Metadata", "http://schemas.xmlsoap.org/ws/2004/09/mex"))
		{
			if (xmlDictionaryWriter == null)
			{
				if (buffer == null)
				{
					buffer = new XmlBuffer(32767);
				}
				xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
				xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
			}
			xmlDictionaryWriter.WriteNode(reader, defattr: true);
		}
		if (xmlDictionaryWriter != null)
		{
			xmlDictionaryWriter.WriteEndElement();
			buffer.CloseSection();
			metadataSection = buffer.SectionCount - 1;
			xmlDictionaryWriter = null;
		}
		else
		{
			metadataSection = -1;
		}
		reader.MoveToContent();
		buffer = ReadExtensions(reader, AddressingVersion.WSAddressingAugust2004, buffer, out identity, out extensionSection);
		if (buffer != null)
		{
			buffer.Close();
		}
		if (text == "http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous")
		{
			uri = AddressingVersion.WSAddressingAugust2004.AnonymousUri;
			if (headers == null && identity == null)
			{
				return true;
			}
		}
		else if (!Uri.TryCreate(text, UriKind.Absolute, out uri))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidUriValue, text, XD.AddressingDictionary.Address.Value, AddressingVersion.WSAddressingAugust2004.Namespace)));
		}
		return false;
	}

	private static bool ReadContentsFrom10(XmlDictionaryReader reader, out Uri uri, out AddressHeaderCollection headers, out EndpointIdentity identity, out XmlBuffer buffer, out int metadataSection, out int extensionSection)
	{
		buffer = null;
		extensionSection = -1;
		metadataSection = -1;
		if (!reader.IsStartElement(XD.AddressingDictionary.Address, XD.Addressing10Dictionary.Namespace))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateXmlException(reader, System.SR.Format(System.SR.UnexpectedElementExpectingElement, reader.LocalName, reader.NamespaceURI, XD.AddressingDictionary.Address.Value, XD.Addressing10Dictionary.Namespace.Value)));
		}
		string text = reader.ReadElementContentAsString();
		if (reader.IsStartElement(XD.AddressingDictionary.ReferenceParameters, XD.Addressing10Dictionary.Namespace))
		{
			headers = AddressHeaderCollection.ReadServiceParameters(reader);
		}
		else
		{
			headers = null;
		}
		if (reader.IsStartElement(XD.Addressing10Dictionary.Metadata, XD.Addressing10Dictionary.Namespace))
		{
			reader.ReadFullStartElement();
			buffer = new XmlBuffer(32767);
			metadataSection = 0;
			XmlDictionaryWriter xmlDictionaryWriter = buffer.OpenSection(reader.Quotas);
			xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
			while (reader.NodeType != XmlNodeType.EndElement && !reader.EOF)
			{
				xmlDictionaryWriter.WriteNode(reader, defattr: true);
			}
			xmlDictionaryWriter.Flush();
			buffer.CloseSection();
			reader.ReadEndElement();
		}
		buffer = ReadExtensions(reader, AddressingVersion.WSAddressing10, buffer, out identity, out extensionSection);
		if (buffer != null)
		{
			buffer.Close();
		}
		if (text == "http://www.w3.org/2005/08/addressing/anonymous")
		{
			uri = AddressingVersion.WSAddressing10.AnonymousUri;
			if (headers == null && identity == null)
			{
				return true;
			}
		}
		else
		{
			if (text == "http://www.w3.org/2005/08/addressing/none")
			{
				uri = AddressingVersion.WSAddressing10.NoneUri;
				return false;
			}
			if (!Uri.TryCreate(text, UriKind.Absolute, out uri))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidUriValue, text, XD.AddressingDictionary.Address.Value, XD.Addressing10Dictionary.Namespace.Value)));
			}
		}
		return false;
	}

	private static XmlException CreateXmlException(XmlDictionaryReader reader, string message)
	{
		if (reader is IXmlLineInfo xmlLineInfo)
		{
			return new XmlException(message, null, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
		}
		return new XmlException(message);
	}

	private static bool Done(XmlDictionaryReader reader)
	{
		reader.MoveToContent();
		if (reader.NodeType != XmlNodeType.EndElement)
		{
			return reader.EOF;
		}
		return true;
	}

	internal static void Copy(XmlDictionaryWriter writer, XmlDictionaryReader reader)
	{
		while (!Done(reader))
		{
			writer.WriteNode(reader, defattr: true);
		}
	}

	public override string ToString()
	{
		return Uri.ToString();
	}

	public void WriteContentsTo(AddressingVersion addressingVersion, XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		if (addressingVersion == AddressingVersion.WSAddressing10)
		{
			WriteContentsTo10(writer);
			return;
		}
		if (addressingVersion == AddressingVersion.WSAddressingAugust2004)
		{
			WriteContentsTo200408(writer);
			return;
		}
		if (addressingVersion == AddressingVersion.None)
		{
			WriteContentsToNone(writer);
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("addressingVersion", System.SR.Format(System.SR.AddressingVersionNotSupported, addressingVersion));
	}

	private void WriteContentsToNone(XmlDictionaryWriter writer)
	{
		writer.WriteString(Uri.AbsoluteUri);
	}

	private void WriteContentsTo200408(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement(XD.AddressingDictionary.Address, XD.Addressing200408Dictionary.Namespace);
		if (IsAnonymous)
		{
			writer.WriteString(XD.Addressing200408Dictionary.Anonymous);
		}
		else
		{
			if (IsNone)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("addressingVersion", System.SR.Format(System.SR.SFxNone2004));
			}
			writer.WriteString(Uri.AbsoluteUri);
		}
		writer.WriteEndElement();
		if (_headers != null && _headers.HasReferenceProperties)
		{
			writer.WriteStartElement(XD.AddressingDictionary.ReferenceProperties, XD.Addressing200408Dictionary.Namespace);
			_headers.WriteReferencePropertyContentsTo(writer);
			writer.WriteEndElement();
		}
		if (_headers != null && _headers.HasNonReferenceProperties)
		{
			writer.WriteStartElement(XD.AddressingDictionary.ReferenceParameters, XD.Addressing200408Dictionary.Namespace);
			_headers.WriteNonReferencePropertyContentsTo(writer);
			writer.WriteEndElement();
		}
		XmlDictionaryReader xmlDictionaryReader = null;
		if (_pspSection >= 0)
		{
			xmlDictionaryReader = GetReaderAtSection(Buffer, _pspSection);
			Copy(writer, xmlDictionaryReader);
		}
		xmlDictionaryReader = null;
		if (_metadataSection >= 0)
		{
			xmlDictionaryReader = GetReaderAtSection(Buffer, _metadataSection);
			Copy(writer, xmlDictionaryReader);
		}
		if (Identity != null)
		{
			Identity.WriteTo(writer);
		}
		if (_extensionSection < 0)
		{
			return;
		}
		xmlDictionaryReader = GetReaderAtSection(Buffer, _extensionSection);
		while (xmlDictionaryReader.IsStartElement())
		{
			if (xmlDictionaryReader.NamespaceURI == AddressingVersion.WSAddressingAugust2004.Namespace)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateXmlException(xmlDictionaryReader, System.SR.Format(System.SR.AddressingExtensionInBadNS, xmlDictionaryReader.LocalName, xmlDictionaryReader.NamespaceURI)));
			}
			writer.WriteNode(xmlDictionaryReader, defattr: true);
		}
	}

	private void WriteContentsTo10(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement(XD.AddressingDictionary.Address, XD.Addressing10Dictionary.Namespace);
		if (IsAnonymous)
		{
			writer.WriteString(XD.Addressing10Dictionary.Anonymous);
		}
		else if (_isNone)
		{
			writer.WriteString(XD.Addressing10Dictionary.NoneAddress);
		}
		else
		{
			writer.WriteString(Uri.AbsoluteUri);
		}
		writer.WriteEndElement();
		if (_headers != null && _headers.Count > 0)
		{
			writer.WriteStartElement(XD.AddressingDictionary.ReferenceParameters, XD.Addressing10Dictionary.Namespace);
			_headers.WriteContentsTo(writer);
			writer.WriteEndElement();
		}
		if (_metadataSection >= 0)
		{
			XmlDictionaryReader readerAtSection = GetReaderAtSection(Buffer, _metadataSection);
			writer.WriteStartElement(XD.Addressing10Dictionary.Metadata, XD.Addressing10Dictionary.Namespace);
			Copy(writer, readerAtSection);
			writer.WriteEndElement();
		}
		if (Identity != null)
		{
			Identity.WriteTo(writer);
		}
		if (_extensionSection < 0)
		{
			return;
		}
		XmlDictionaryReader readerAtSection2 = GetReaderAtSection(Buffer, _extensionSection);
		while (readerAtSection2.IsStartElement())
		{
			if (readerAtSection2.NamespaceURI == AddressingVersion.WSAddressing10.Namespace)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateXmlException(readerAtSection2, System.SR.Format(System.SR.AddressingExtensionInBadNS, readerAtSection2.LocalName, readerAtSection2.NamespaceURI)));
			}
			writer.WriteNode(readerAtSection2, defattr: true);
		}
	}

	public void WriteContentsTo(AddressingVersion addressingVersion, XmlWriter writer)
	{
		XmlDictionaryWriter writer2 = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		WriteContentsTo(addressingVersion, writer2);
	}

	public void WriteTo(AddressingVersion addressingVersion, XmlDictionaryWriter writer)
	{
		WriteTo(addressingVersion, writer, XD.AddressingDictionary.EndpointReference, addressingVersion.DictionaryNamespace);
	}

	public void WriteTo(AddressingVersion addressingVersion, XmlDictionaryWriter writer, XmlDictionaryString localName, XmlDictionaryString ns)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		if (localName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localName");
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ns");
		}
		writer.WriteStartElement(localName, ns);
		WriteContentsTo(addressingVersion, writer);
		writer.WriteEndElement();
	}

	public void WriteTo(AddressingVersion addressingVersion, XmlWriter writer)
	{
		XmlDictionaryString xmlDictionaryString = addressingVersion.DictionaryNamespace;
		if (xmlDictionaryString == null)
		{
			xmlDictionaryString = XD.AddressingDictionary.Empty;
		}
		WriteTo(addressingVersion, XmlDictionaryWriter.CreateDictionaryWriter(writer), XD.AddressingDictionary.EndpointReference, xmlDictionaryString);
	}

	public void WriteTo(AddressingVersion addressingVersion, XmlWriter writer, string localName, string ns)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		if (localName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localName");
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ns");
		}
		writer.WriteStartElement(localName, ns);
		WriteContentsTo(addressingVersion, writer);
		writer.WriteEndElement();
	}

	public static bool operator ==(EndpointAddress address1, EndpointAddress address2)
	{
		return address2?.Equals(address1) ?? ((object)address1 == null);
	}

	public static bool operator !=(EndpointAddress address1, EndpointAddress address2)
	{
		if ((object)address2 == null)
		{
			return (object)address1 != null;
		}
		return !address2.Equals(address1);
	}
}
