using System.Collections.Generic;

namespace System.Text.Json.Serialization.Metadata;

internal sealed class PropertyRefCacheBuilder(PropertyRef[] originalCache)
{
	public const int MaxCapacity = 64;

	private readonly List<PropertyRef> _propertyRefs = new List<PropertyRef>();

	private readonly HashSet<PropertyRef> _added = new HashSet<PropertyRef>();

	public readonly PropertyRef[] OriginalCache = originalCache;

	public int Count => _propertyRefs.Count;

	public int TotalCount => OriginalCache.Length + _propertyRefs.Count;

	public PropertyRef[] ToArray()
	{
		PropertyRef[] originalCache = OriginalCache;
		List<PropertyRef> propertyRefs = _propertyRefs;
		int num = 0;
		PropertyRef[] array = new PropertyRef[originalCache.Length + propertyRefs.Count];
		ReadOnlySpan<PropertyRef> readOnlySpan = new ReadOnlySpan<PropertyRef>(originalCache);
		readOnlySpan.CopyTo(new Span<PropertyRef>(array).Slice(num, readOnlySpan.Length));
		num += readOnlySpan.Length;
		foreach (PropertyRef item in propertyRefs)
		{
			array[num] = item;
			num++;
		}
		return array;
	}

	public void TryAdd(PropertyRef propertyRef)
	{
		if (_added.Add(propertyRef))
		{
			_propertyRefs.Add(propertyRef);
		}
	}
}
