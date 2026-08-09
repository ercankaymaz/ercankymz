using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ComponentModel.Composition;

internal static class MetadataServices
{
	public static readonly IDictionary<string, object?> EmptyMetadata = new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(0));

	public static IDictionary<string, object?> AsReadOnly(this IDictionary<string, object?>? metadata)
	{
		if (metadata == null)
		{
			return EmptyMetadata;
		}
		if (metadata is ReadOnlyDictionary<string, object>)
		{
			return metadata;
		}
		return new ReadOnlyDictionary<string, object>(metadata);
	}

	public static T? GetValue<T>(this IDictionary<string, object?> metadata, string key)
	{
		ArgumentNullException.ThrowIfNull(metadata, "metadata");
		if (metadata.TryGetValue(key, out object value) && value is T)
		{
			return (T)value;
		}
		return default(T);
	}
}
