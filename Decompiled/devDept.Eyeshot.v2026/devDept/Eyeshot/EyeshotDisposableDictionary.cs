using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class EyeshotDisposableDictionary<T> : Dictionary<string, T> where T : IDisposable
{
	[NonSerialized]
	protected Document Document;

	public new virtual T this[string name]
	{
		get
		{
			return base[name];
		}
		set
		{
			if (TryGetValue(name, out var value2))
			{
				value2.Dispose();
			}
			base[name] = value;
		}
	}

	internal EyeshotDisposableDictionary(Document _0023_003DzoPlwCJA_003D, StringComparer _0023_003Dz_0024HlsdlcK5yd4)
		: base((IEqualityComparer<string>)_0023_003Dz_0024HlsdlcK5yd4)
	{
		Document = _0023_003DzoPlwCJA_003D;
	}

	protected EyeshotDisposableDictionary(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal IWorkspaceInternal _0023_003Dzo60vEkkaRGxX()
	{
		return Document?.workspace;
	}

	internal void _0023_003DzXQYa2Ko_003D(Document _0023_003DzoPlwCJA_003D)
	{
		Document = _0023_003DzoPlwCJA_003D;
	}

	public new bool Remove(string name)
	{
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid())
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
		}
		if (TryGetValue(name, out var value))
		{
			value.Dispose();
		}
		return base.Remove(name);
	}

	internal void _0023_003DzFU90HuI_003D(string _0023_003DzS_00246o7tc_003D)
	{
		base.Remove(_0023_003DzS_00246o7tc_003D);
	}

	public new void Clear()
	{
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid(_0023_003Dzo60vEkkaRGxX().RenderContext))
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
		}
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.Dispose();
			}
		}
		base.Clear();
	}

	internal void _0023_003DzhM3qURBkRYYd()
	{
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Value.Dispose();
		}
	}
}
