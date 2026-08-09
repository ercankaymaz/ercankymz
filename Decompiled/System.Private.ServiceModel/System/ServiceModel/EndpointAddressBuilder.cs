using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

public class EndpointAddressBuilder
{
	private XmlBuffer _extensionBuffer;

	private XmlBuffer _metadataBuffer;

	private bool _hasExtension;

	private bool _hasMetadata;

	private EndpointAddress _epr;

	public Uri Uri { get; set; }

	public EndpointIdentity Identity { get; set; }

	public Collection<AddressHeader> Headers { get; }

	public EndpointAddressBuilder()
	{
		Headers = new Collection<AddressHeader>();
	}

	public EndpointAddressBuilder(EndpointAddress address)
	{
		_epr = address ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		Uri = address.Uri;
		Identity = address.Identity;
		Headers = new Collection<AddressHeader>();
		for (int i = 0; i < address.Headers.Count; i++)
		{
			Headers.Add(address.Headers[i]);
		}
	}

	public XmlDictionaryReader GetReaderAtMetadata()
	{
		if (!_hasMetadata)
		{
			if (!(_epr == null))
			{
				return _epr.GetReaderAtMetadata();
			}
			return null;
		}
		if (_metadataBuffer == null)
		{
			return null;
		}
		XmlDictionaryReader reader = _metadataBuffer.GetReader(0);
		reader.MoveToContent();
		reader.Read();
		return reader;
	}

	public void SetMetadataReader(XmlDictionaryReader reader)
	{
		_hasMetadata = true;
		_metadataBuffer = null;
		if (reader != null)
		{
			_metadataBuffer = new XmlBuffer(32767);
			XmlDictionaryWriter xmlDictionaryWriter = _metadataBuffer.OpenSection(reader.Quotas);
			xmlDictionaryWriter.WriteStartElement("Dummy", "http://Dummy");
			EndpointAddress.Copy(xmlDictionaryWriter, reader);
			_metadataBuffer.CloseSection();
			_metadataBuffer.Close();
		}
	}

	public XmlDictionaryReader GetReaderAtExtensions()
	{
		if (!_hasExtension)
		{
			if (!(_epr == null))
			{
				return _epr.GetReaderAtExtensions();
			}
			return null;
		}
		if (_extensionBuffer == null)
		{
			return null;
		}
		XmlDictionaryReader reader = _extensionBuffer.GetReader(0);
		reader.MoveToContent();
		reader.Read();
		return reader;
	}

	public void SetExtensionReader(XmlDictionaryReader reader)
	{
		_hasExtension = true;
		_extensionBuffer = EndpointAddress.ReadExtensions(reader, null, null, out var identity, out var _);
		if (_extensionBuffer != null)
		{
			_extensionBuffer.Close();
		}
		if (identity != null)
		{
			Identity = identity;
		}
	}

	public EndpointAddress ToEndpointAddress()
	{
		return new EndpointAddress(Uri, Identity, new AddressHeaderCollection(Headers), GetReaderAtMetadata(), GetReaderAtExtensions(), (_epr == null) ? null : _epr.GetReaderAtPsp());
	}
}
