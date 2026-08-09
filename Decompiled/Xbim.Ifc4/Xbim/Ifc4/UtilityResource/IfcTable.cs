using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.UtilityResource;

[ExpressType("IfcTable", 377)]
public class IfcTable : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcTable, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IContainsEntityReferences, IEquatable<IfcTable>, IExpressValidatable
{
	public enum IfcTableClause
	{
		WR1,
		WR2
	}

	private IfcLabel? _name;

	private readonly OptionalItemSet<IfcTableRow> _rows;

	private readonly OptionalItemSet<IfcTableColumn> _columns;

	IfcLabel? IIfcTable.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IItemSet<IIfcTableRow> IIfcTable.Rows => new ProxyItemSet<IfcTableRow, IIfcTableRow>(Rows);

	IItemSet<IIfcTableColumn> IIfcTable.Columns => new ProxyItemSet<IfcTableColumn, IIfcTableColumn>(Columns);

	IfcInteger IIfcTable.NumberOfCellsInRow => NumberOfCellsInRow;

	IfcInteger IIfcTable.NumberOfHeadings => NumberOfHeadings;

	IfcInteger IIfcTable.NumberOfDataRows => NumberOfDataRows;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IOptionalItemSet<IfcTableRow> Rows
	{
		get
		{
			if (_activated)
			{
				return _rows;
			}
			Activate();
			return _rows;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IOptionalItemSet<IfcTableColumn> Columns
	{
		get
		{
			if (_activated)
			{
				return _columns;
			}
			Activate();
			return _columns;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger NumberOfCellsInRow => (Rows != null) ? Rows[0].RowCells.Count : 0;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger NumberOfHeadings => Rows.Count((IfcTableRow r) => r.IsHeading == true);

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger NumberOfDataRows => Rows.Count(delegate(IfcTableRow r)
	{
		IfcBoolean? isHeading = r.IsHeading;
		return (isHeading.HasValue ? new bool?(!isHeading.GetValueOrDefault()) : ((bool?)null)) != true;
	});

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcTableRow row in Rows)
			{
				yield return row;
			}
			foreach (IfcTableColumn column in Columns)
			{
				yield return column;
			}
		}
	}

	internal IfcTable(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_rows = new OptionalItemSet<IfcTableRow>(this, 0, 2);
		_columns = new OptionalItemSet<IfcTableColumn>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_rows.InternalAdd((IfcTableRow)value.EntityVal);
			break;
		case 2:
			_columns.InternalAdd((IfcTableColumn)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTable other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTableClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTableClause.WR1:
				result = Functions.SIZEOF(Enumerable.Where(Rows, (IfcTableRow Temp) => Functions.HIINDEX(Temp.RowCells) != Functions.HIINDEX(Rows.ItemAt(0L).RowCells))) == 0;
				break;
			case IfcTableClause.WR2:
				result = 0 <= (long)NumberOfHeadings && (long)NumberOfHeadings <= 1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTable>()?.LogError($"Exception thrown evaluating where-clause 'IfcTable.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTableClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTable.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTableClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTable.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
