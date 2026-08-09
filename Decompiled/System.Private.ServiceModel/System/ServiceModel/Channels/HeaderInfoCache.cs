using System.Xml;

namespace System.ServiceModel.Channels;

internal class HeaderInfoCache
{
	internal class HeaderInfo : MessageHeaderInfo
	{
		private string _name;

		private string _ns;

		private string _actor;

		private bool _isReferenceParameter;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Name => _name;

		public override string Namespace => _ns;

		public override bool IsReferenceParameter => _isReferenceParameter;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public HeaderInfo(XmlDictionaryReader reader, string actor, bool mustUnderstand, bool relay, bool isReferenceParameter)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
			_isReferenceParameter = isReferenceParameter;
			_name = reader.LocalName;
			_ns = reader.NamespaceURI;
		}

		public bool Matches(XmlDictionaryReader reader, string actor, bool mustUnderstand, bool relay, bool isRefParam)
		{
			if (reader.IsStartElement(_name, _ns) && _actor == actor && _mustUnderstand == mustUnderstand && _relay == relay)
			{
				return _isReferenceParameter == isRefParam;
			}
			return false;
		}
	}

	private const int maxHeaderInfos = 4;

	private HeaderInfo[] _headerInfos;

	private int _index;

	public MessageHeaderInfo TakeHeaderInfo(XmlDictionaryReader reader, string actor, bool mustUnderstand, bool relay, bool isRefParam)
	{
		if (_headerInfos != null)
		{
			int num = _index;
			do
			{
				HeaderInfo headerInfo = _headerInfos[num];
				if (headerInfo != null && headerInfo.Matches(reader, actor, mustUnderstand, relay, isRefParam))
				{
					_headerInfos[num] = null;
					_index = (num + 1) % 4;
					return headerInfo;
				}
				num = (num + 1) % 4;
			}
			while (num != _index);
		}
		return new HeaderInfo(reader, actor, mustUnderstand, relay, isRefParam);
	}

	public void ReturnHeaderInfo(MessageHeaderInfo headerInfo)
	{
		if (!(headerInfo is HeaderInfo headerInfo2))
		{
			return;
		}
		if (_headerInfos == null)
		{
			_headerInfos = new HeaderInfo[4];
		}
		int num = _index;
		while (_headerInfos[num] != null)
		{
			num = (num + 1) % 4;
			if (num == _index)
			{
				break;
			}
		}
		_headerInfos[num] = headerInfo2;
		_index = (num + 1) % 4;
	}
}
