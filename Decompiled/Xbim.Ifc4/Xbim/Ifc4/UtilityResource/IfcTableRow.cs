using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.UtilityResource;

[ExpressType("IfcTableRow", 661)]
public class IfcTableRow : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcTableRow, IEquatable<IfcTableRow>
{
	private readonly OptionalItemSet<IfcValue> _rowCells;

	private IfcBoolean? _isHeading;

	IItemSet<IIfcValue> IIfcTableRow.RowCells => new ProxyItemSet<IfcValue, IIfcValue>(RowCells);

	IfcBoolean? IIfcTableRow.IsHeading
	{
		get
		{
			return IsHeading;
		}
		set
		{
			IsHeading = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IOptionalItemSet<IfcValue> RowCells
	{
		get
		{
			if (_activated)
			{
				return _rowCells;
			}
			Activate();
			return _rowCells;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcBoolean? IsHeading
	{
		get
		{
			if (_activated)
			{
				return _isHeading;
			}
			Activate();
			return _isHeading;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_isHeading = v;
			}, _isHeading, value, "IsHeading", 2);
		}
	}

	internal IfcTableRow(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_rowCells = new OptionalItemSet<IfcValue>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_rowCells.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 1:
			_isHeading = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTableRow other)
	{
		return this == other;
	}
}
