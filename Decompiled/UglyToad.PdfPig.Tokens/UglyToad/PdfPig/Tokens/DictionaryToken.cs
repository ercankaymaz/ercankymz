using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Tokens;

public class DictionaryToken : IDataToken<IReadOnlyDictionary<string, IToken>>, IToken, IEquatable<IToken>, IEquatable<DictionaryToken>
{
	public IReadOnlyDictionary<string, IToken> Data { get; }

	public DictionaryToken(IReadOnlyDictionary<NameToken, IToken> data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		Dictionary<string, IToken> dictionary = new Dictionary<string, IToken>(data.Count);
		foreach (KeyValuePair<NameToken, IToken> datum in data)
		{
			dictionary[datum.Key.Data] = datum.Value;
		}
		Data = dictionary;
	}

	private DictionaryToken(IReadOnlyDictionary<string, IToken> data)
	{
		Data = data;
	}

	public bool TryGet(NameToken name, out IToken token)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		return Data.TryGetValue(name.Data, out token);
	}

	public bool TryGet<T>(NameToken name, out T token) where T : IToken
	{
		token = default(T);
		if (!TryGet(name, out var token2) || !(token2 is T val))
		{
			return false;
		}
		token = val;
		return true;
	}

	public bool ContainsKey(NameToken name)
	{
		return Data.ContainsKey(name.Data);
	}

	public DictionaryToken With(NameToken key, IToken value)
	{
		return With(key.Data, value);
	}

	public DictionaryToken With(string key, IToken value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		Dictionary<string, IToken> dictionary = new Dictionary<string, IToken>(Data.Count + 1);
		foreach (KeyValuePair<string, IToken> datum in Data)
		{
			dictionary[datum.Key] = datum.Value;
		}
		dictionary[key] = value;
		return new DictionaryToken(dictionary);
	}

	public DictionaryToken Without(NameToken key)
	{
		return Without(key.Data);
	}

	public DictionaryToken Without(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		Dictionary<string, IToken> dictionary = new Dictionary<string, IToken>(Data.ContainsKey(key) ? (Data.Count - 1) : Data.Count);
		foreach (KeyValuePair<string, IToken> item in Data.Where((KeyValuePair<string, IToken> x) => !x.Key.Equals(key)))
		{
			dictionary[item.Key] = item.Value;
		}
		return new DictionaryToken(dictionary);
	}

	public static DictionaryToken With(IReadOnlyDictionary<string, IToken> data)
	{
		return new DictionaryToken(data ?? throw new ArgumentNullException("data"));
	}

	public bool Equals(IToken obj)
	{
		return Equals(obj as DictionaryToken);
	}

	public bool Equals(DictionaryToken other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Data.Count != other.Data.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, IToken> datum in other.Data)
		{
			if (!Data.TryGetValue(datum.Key, out var value) || !value.Equals(datum.Value))
			{
				return false;
			}
		}
		return true;
	}

	public override string ToString()
	{
		return string.Join(", ", Data.Select((KeyValuePair<string, IToken> x) => $"<{x.Key}, {x.Value}>"));
	}
}
