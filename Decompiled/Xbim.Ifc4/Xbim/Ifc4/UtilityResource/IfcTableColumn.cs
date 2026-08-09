using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.UtilityResource;

[ExpressType("IfcTableColumn", 1292)]
public class IfcTableColumn : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcTableColumn, IContainsEntityReferences, IEquatable<IfcTableColumn>
{
	private IfcIdentifier? _identifier;

	private IfcLabel? _name;

	private IfcText? _description;

	private IfcUnit _unit;

	private IfcReference _referencePath;

	IfcIdentifier? IIfcTableColumn.Identifier
	{
		get
		{
			return Identifier;
		}
		set
		{
			Identifier = value;
		}
	}

	IfcLabel? IIfcTableColumn.Name
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

	IfcText? IIfcTableColumn.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IIfcUnit IIfcTableColumn.Unit
	{
		get
		{
			return Unit;
		}
		set
		{
			Unit = value as IfcUnit;
		}
	}

	IIfcReference IIfcTableColumn.ReferencePath
	{
		get
		{
			return ReferencePath;
		}
		set
		{
			ReferencePath = value as IfcReference;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcIdentifier? Identifier
	{
		get
		{
			if (_activated)
			{
				return _identifier;
			}
			Activate();
			return _identifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcUnit Unit
	{
		get
		{
			if (_activated)
			{
				return _unit;
			}
			Activate();
			return _unit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcReference ReferencePath
	{
		get
		{
			if (_activated)
			{
				return _referencePath;
			}
			Activate();
			return _referencePath;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcReference v)
			{
				_referencePath = v;
			}, _referencePath, value, "ReferencePath", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Unit != null)
			{
				yield return Unit;
			}
			if (ReferencePath != null)
			{
				yield return ReferencePath;
			}
		}
	}

	internal IfcTableColumn(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_identifier = value.StringVal;
			break;
		case 1:
			_name = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_unit = (IfcUnit)value.EntityVal;
			break;
		case 4:
			_referencePath = (IfcReference)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTableColumn other)
	{
		return this == other;
	}
}
