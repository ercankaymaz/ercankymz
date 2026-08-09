using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralLoadResource;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralActivity", 41)]
public abstract class IfcStructuralActivity : IfcProduct, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcStructuralActivity>
{
	private IfcStructuralLoad _appliedLoad;

	private IfcGlobalOrLocalEnum _globalOrLocal;

	IIfcStructuralLoad IIfcStructuralActivity.AppliedLoad
	{
		get
		{
			return AppliedLoad;
		}
		set
		{
			AppliedLoad = value as IfcStructuralLoad;
		}
	}

	IfcGlobalOrLocalEnum IIfcStructuralActivity.GlobalOrLocal
	{
		get
		{
			return GlobalOrLocal;
		}
		set
		{
			GlobalOrLocal = value;
		}
	}

	IEnumerable<IIfcRelConnectsStructuralActivity> IIfcStructuralActivity.AssignedToStructuralItem => AssignedToStructuralItem;

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcStructuralLoad AppliedLoad
	{
		get
		{
			if (_activated)
			{
				return _appliedLoad;
			}
			Activate();
			return _appliedLoad;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralLoad v)
			{
				_appliedLoad = v;
			}, _appliedLoad, value, "AppliedLoad", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcGlobalOrLocalEnum GlobalOrLocal
	{
		get
		{
			if (_activated)
			{
				return _globalOrLocal;
			}
			Activate();
			return _globalOrLocal;
		}
		set
		{
			SetValue(delegate(IfcGlobalOrLocalEnum v)
			{
				_globalOrLocal = v;
			}, _globalOrLocal, value, "GlobalOrLocal", 9);
		}
	}

	[InverseProperty("RelatedStructuralActivity")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 22)]
	public IEnumerable<IfcRelConnectsStructuralActivity> AssignedToStructuralItem => base.Model.Instances.Where((IfcRelConnectsStructuralActivity e) => Equals(e.RelatedStructuralActivity), "RelatedStructuralActivity", this);

	internal IfcStructuralActivity(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_appliedLoad = (IfcStructuralLoad)value.EntityVal;
			break;
		case 8:
			_globalOrLocal = (IfcGlobalOrLocalEnum)Enum.Parse(typeof(IfcGlobalOrLocalEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralActivity other)
	{
		return this == other;
	}
}
