using System;
using System.Reflection;
using MS.Internal.Metadata;

namespace Microsoft.Windows.Design.Metadata;

public class AttributeTableBuilder
{
	private MutableAttributeTable _table = new MutableAttributeTable();

	private bool _cloneOnUse;

	private MutableAttributeTable MutableTable
	{
		get
		{
			if (_cloneOnUse)
			{
				MutableAttributeTable mutableAttributeTable = new MutableAttributeTable();
				mutableAttributeTable.AddTable(_table);
				_table = mutableAttributeTable;
				_cloneOnUse = false;
			}
			return _table;
		}
	}

	public void AddCallback(Type type, AttributeCallback callback)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		MutableTable.AddCallback(type, callback);
	}

	public void AddCustomAttributes(Assembly assembly, params Attribute[] attributes)
	{
		if ((object)assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		if (attributes == null)
		{
			throw new ArgumentNullException("attributes");
		}
		MutableTable.AddCustomAttributes(assembly, attributes);
	}

	public void AddCustomAttributes(Type type, params Attribute[] attributes)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (attributes == null)
		{
			throw new ArgumentNullException("attributes");
		}
		MutableTable.AddCustomAttributes(type, attributes);
	}

	public void AddCustomAttributes(Type ownerType, string memberName, params Attribute[] attributes)
	{
		if ((object)ownerType == null)
		{
			throw new ArgumentNullException("ownerType");
		}
		if (memberName == null)
		{
			throw new ArgumentNullException("memberName");
		}
		if (attributes == null)
		{
			throw new ArgumentNullException("attributes");
		}
		MutableTable.AddCustomAttributes(ownerType, memberName, attributes);
	}

	public void AddTable(AttributeTable table)
	{
		if (table == null)
		{
			throw new ArgumentNullException("table");
		}
		MutableTable.AddTable(table.MutableTable);
	}

	public AttributeTable CreateTable()
	{
		_cloneOnUse = true;
		return new AttributeTable(_table);
	}

	public void ValidateTable()
	{
		MutableTable.ValidateTable();
	}
}
