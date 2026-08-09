using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.FacilitiesMgmtDomain;

[ExpressType("IfcPermit", 189)]
public class IfcPermit : Xbim.Ifc2x3.Kernel.IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPermit>, IIfcPermit, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _permitID;

	private IfcPermitTypeEnum? _predefinedType;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4.MeasureResource.IfcText? _longDescription;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier PermitID
	{
		get
		{
			if (_activated)
			{
				return _permitID;
			}
			Activate();
			return _permitID;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_permitID = v;
			}, _permitID, value, "PermitID", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermit), 7)]
	IfcPermitTypeEnum? IIfcPermit.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcPermitTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -7);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermit), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPermit.Status
	{
		get
		{
			return _status;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", -8);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPermit), 9)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcPermit.LongDescription
	{
		get
		{
			return _longDescription;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", -9);
		}
	}

	internal IfcPermit(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_permitID = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPermit other)
	{
		return this == other;
	}
}
