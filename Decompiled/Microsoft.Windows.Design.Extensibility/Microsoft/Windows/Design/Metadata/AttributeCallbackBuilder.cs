using System;
using MS.Internal.Metadata;

namespace Microsoft.Windows.Design.Metadata;

public sealed class AttributeCallbackBuilder
{
	private MutableAttributeTable _table;

	private Type _callbackType;

	public Type CallbackType => _callbackType;

	internal AttributeCallbackBuilder(MutableAttributeTable table, Type callbackType)
	{
		_table = table;
		_callbackType = callbackType;
	}

	public void AddCustomAttributes(params Attribute[] attributes)
	{
		if (attributes == null)
		{
			throw new ArgumentNullException("attributes");
		}
		_table.AddCustomAttributes(_callbackType, attributes);
	}

	public void AddCustomAttributes(string memberName, params Attribute[] attributes)
	{
		if (memberName == null)
		{
			throw new ArgumentNullException("memberName");
		}
		if (attributes == null)
		{
			throw new ArgumentNullException("attributes");
		}
		_table.AddCustomAttributes(_callbackType, memberName, attributes);
	}
}
