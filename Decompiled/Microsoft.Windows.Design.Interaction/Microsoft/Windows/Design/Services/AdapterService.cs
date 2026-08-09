using System;
using Microsoft.Windows.Design.Interaction;

namespace Microsoft.Windows.Design.Services;

public abstract class AdapterService
{
	public TAdapterType GetAdapter<TAdapterType>(Type itemType) where TAdapterType : Adapter
	{
		if ((object)itemType == null)
		{
			throw new ArgumentNullException("itemType");
		}
		return GetAdapter(typeof(TAdapterType), itemType) as TAdapterType;
	}

	public abstract Adapter GetAdapter(Type adapterType, Type itemType);
}
