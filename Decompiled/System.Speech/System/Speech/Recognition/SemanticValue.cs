using System.Collections;
using System.Collections.Generic;

namespace System.Speech.Recognition;

public sealed class SemanticValue : ICollection<KeyValuePair<string, SemanticValue>>, IEnumerable<KeyValuePair<string, SemanticValue>>, IEnumerable, IDictionary<string, SemanticValue>
{
	public float Confidence
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public int Count
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public SemanticValue this[string key]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	bool ICollection<KeyValuePair<string, SemanticValue>>.IsReadOnly
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	ICollection<string> IDictionary<string, SemanticValue>.Keys
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	ICollection<SemanticValue> IDictionary<string, SemanticValue>.Values
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public object Value
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
		}
	}

	public SemanticValue(object value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public SemanticValue(string keyName, object value, float confidence)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public bool Contains(KeyValuePair<string, SemanticValue> item)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public bool ContainsKey(string key)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public override bool Equals(object obj)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	public override int GetHashCode()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	void ICollection<KeyValuePair<string, SemanticValue>>.Add(KeyValuePair<string, SemanticValue> key)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	void ICollection<KeyValuePair<string, SemanticValue>>.Clear()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	void ICollection<KeyValuePair<string, SemanticValue>>.CopyTo(KeyValuePair<string, SemanticValue>[] array, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	bool ICollection<KeyValuePair<string, SemanticValue>>.Remove(KeyValuePair<string, SemanticValue> key)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	void IDictionary<string, SemanticValue>.Add(string key, SemanticValue value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	bool IDictionary<string, SemanticValue>.Remove(string key)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	bool IDictionary<string, SemanticValue>.TryGetValue(string key, out SemanticValue value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	IEnumerator<KeyValuePair<string, SemanticValue>> IEnumerable<KeyValuePair<string, SemanticValue>>.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemSpeech);
	}
}
