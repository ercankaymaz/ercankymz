namespace System.ServiceModel.Channels;

internal class RecycledMessageState
{
	private MessageHeaders _recycledHeaders;

	private MessageProperties _recycledProperties;

	private UriCache _uriCache;

	private HeaderInfoCache _headerInfoCache;

	public HeaderInfoCache HeaderInfoCache
	{
		get
		{
			if (_headerInfoCache == null)
			{
				_headerInfoCache = new HeaderInfoCache();
			}
			return _headerInfoCache;
		}
	}

	public UriCache UriCache
	{
		get
		{
			if (_uriCache == null)
			{
				_uriCache = new UriCache();
			}
			return _uriCache;
		}
	}

	public MessageProperties TakeProperties()
	{
		MessageProperties recycledProperties = _recycledProperties;
		_recycledProperties = null;
		return recycledProperties;
	}

	public void ReturnProperties(MessageProperties properties)
	{
		if (properties.CanRecycle)
		{
			properties.Recycle();
			_recycledProperties = properties;
		}
	}

	public MessageHeaders TakeHeaders()
	{
		MessageHeaders recycledHeaders = _recycledHeaders;
		_recycledHeaders = null;
		return recycledHeaders;
	}

	public void ReturnHeaders(MessageHeaders headers)
	{
		if (headers.CanRecycle)
		{
			headers.Recycle(HeaderInfoCache);
			_recycledHeaders = headers;
		}
	}
}
