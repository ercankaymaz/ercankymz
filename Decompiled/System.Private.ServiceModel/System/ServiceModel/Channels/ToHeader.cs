using System.Xml;

namespace System.ServiceModel.Channels;

internal class ToHeader : AddressingHeader
{
	private class AnonymousToHeader : ToHeader
	{
		public AnonymousToHeader(AddressingVersion version)
			: base(version.AnonymousUri, version)
		{
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteString(base.Version.DictionaryAnonymous);
		}
	}

	internal class DictionaryToHeader : ToHeader
	{
		private XmlDictionaryString _dictionaryTo;

		public DictionaryToHeader(Uri to, XmlDictionaryString dictionaryTo, AddressingVersion version)
			: base(to, version)
		{
			_dictionaryTo = dictionaryTo;
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteString(_dictionaryTo);
		}
	}

	internal class FullToHeader : ToHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullToHeader(Uri to, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(to, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}
	}

	private const bool mustUnderstandValue = true;

	private static ToHeader s_anonymousToHeader10;

	private static ToHeader s_anonymousToHeader200408;

	private static ToHeader AnonymousTo10
	{
		get
		{
			if (s_anonymousToHeader10 == null)
			{
				s_anonymousToHeader10 = new AnonymousToHeader(AddressingVersion.WSAddressing10);
			}
			return s_anonymousToHeader10;
		}
	}

	private static ToHeader AnonymousTo200408
	{
		get
		{
			if (s_anonymousToHeader200408 == null)
			{
				s_anonymousToHeader200408 = new AnonymousToHeader(AddressingVersion.WSAddressingAugust2004);
			}
			return s_anonymousToHeader200408;
		}
	}

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.To;

	public override bool MustUnderstand => true;

	public Uri To { get; }

	protected ToHeader(Uri to, AddressingVersion version)
		: base(version)
	{
		To = to;
	}

	public static ToHeader Create(Uri toUri, XmlDictionaryString dictionaryTo, AddressingVersion addressingVersion)
	{
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		if ((object)toUri == addressingVersion.AnonymousUri)
		{
			if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				return AnonymousTo10;
			}
			return AnonymousTo200408;
		}
		return new DictionaryToHeader(toUri, dictionaryTo, addressingVersion);
	}

	public static ToHeader Create(Uri to, AddressingVersion addressingVersion)
	{
		if ((object)to == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("to"));
		}
		if ((object)to == addressingVersion.AnonymousUri)
		{
			if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				return AnonymousTo10;
			}
			return AnonymousTo200408;
		}
		return new ToHeader(to, addressingVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteString(To.AbsoluteUri);
	}

	public static Uri ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion version)
	{
		return ReadHeaderValue(reader, version, null);
	}

	public static Uri ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion version, UriCache uriCache)
	{
		string text = reader.ReadElementContentAsString();
		if ((object)text == version.Anonymous)
		{
			return version.AnonymousUri;
		}
		if (uriCache == null)
		{
			return new Uri(text);
		}
		return uriCache.CreateUri(text);
	}

	public static ToHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, UriCache uriCache, string actor, bool mustUnderstand, bool relay)
	{
		Uri uri = ReadHeaderValue(reader, version, uriCache);
		if (actor.Length == 0 && mustUnderstand && !relay)
		{
			if ((object)uri == version.Anonymous)
			{
				if (version == AddressingVersion.WSAddressing10)
				{
					return AnonymousTo10;
				}
				if (version == AddressingVersion.WSAddressingAugust2004)
				{
					return AnonymousTo200408;
				}
				throw ExceptionHelper.PlatformNotSupported();
			}
			return new ToHeader(uri, version);
		}
		return new FullToHeader(uri, actor, mustUnderstand, relay, version);
	}
}
