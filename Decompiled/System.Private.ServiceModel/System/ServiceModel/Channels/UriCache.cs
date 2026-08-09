namespace System.ServiceModel.Channels;

internal class UriCache
{
	internal struct Entry(string key, Uri value)
	{
		private Uri _value = value;

		public string Key { get; } = key;

		public Uri Value => _value;
	}

	private const int MaxKeyLength = 128;

	private const int MaxEntries = 8;

	private Entry[] _entries;

	private int _count;

	public UriCache()
	{
		_entries = new Entry[8];
	}

	public Uri CreateUri(string uriString)
	{
		Uri uri = Get(uriString);
		if (uri == null)
		{
			uri = new Uri(uriString);
			Set(uriString, uri);
		}
		return uri;
	}

	private Uri Get(string key)
	{
		if (key.Length > 128)
		{
			return null;
		}
		for (int num = _count - 1; num >= 0; num--)
		{
			if (_entries[num].Key == key)
			{
				return _entries[num].Value;
			}
		}
		return null;
	}

	private void Set(string key, Uri value)
	{
		if (key.Length <= 128)
		{
			if (_count < _entries.Length)
			{
				_entries[_count++] = new Entry(key, value);
				return;
			}
			Array.Copy(_entries, 1, _entries, 0, _entries.Length - 1);
			_entries[_count - 1] = new Entry(key, value);
		}
	}
}
