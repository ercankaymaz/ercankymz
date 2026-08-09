using System.Collections.Generic;

namespace System.ServiceModel;

public class UriSchemeKeyedCollection : SynchronizedKeyedCollection<string, Uri>
{
	internal UriSchemeKeyedCollection(object syncRoot)
		: base(syncRoot)
	{
	}

	public UriSchemeKeyedCollection(params Uri[] addresses)
	{
		if (addresses == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addresses");
		}
		for (int i = 0; i < addresses.Length; i++)
		{
			Add(addresses[i]);
		}
	}

	protected override string GetKeyForItem(Uri item)
	{
		return item.Scheme;
	}

	protected override void InsertItem(int index, Uri item)
	{
		ValidateBaseAddress(item, "item");
		if (Contains(item.Scheme))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("item", System.SR.Format(System.SR.BaseAddressDuplicateScheme, item.Scheme));
		}
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, Uri item)
	{
		ValidateBaseAddress(item, "item");
		if (base[index].Scheme != item.Scheme && Contains(item.Scheme))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("item", System.SR.Format(System.SR.BaseAddressDuplicateScheme, item.Scheme));
		}
		base.SetItem(index, item);
	}

	internal static void ValidateBaseAddress(Uri uri, string argumentName)
	{
		if (uri == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(argumentName);
		}
		if (!uri.IsAbsoluteUri)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(argumentName, System.SR.BaseAddressMustBeAbsolute);
		}
		if (!string.IsNullOrEmpty(uri.UserInfo))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(argumentName, System.SR.BaseAddressCannotHaveUserInfo);
		}
		if (!string.IsNullOrEmpty(uri.Query))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(argumentName, System.SR.BaseAddressCannotHaveQuery);
		}
		if (!string.IsNullOrEmpty(uri.Fragment))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(argumentName, System.SR.BaseAddressCannotHaveFragment);
		}
	}
}
