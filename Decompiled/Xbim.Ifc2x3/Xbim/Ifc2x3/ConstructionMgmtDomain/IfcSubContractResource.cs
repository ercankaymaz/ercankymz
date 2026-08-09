using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ConstructionMgmtDomain;

[ExpressType("IfcSubContractResource", 594)]
public class IfcSubContractResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSubContractResource>, IIfcSubContractResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcActorSelect _subContractor;

	private IfcText? _jobDescription;

	private IfcSubContractResourceTypeEnum? _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 16)]
	public IfcActorSelect SubContractor
	{
		get
		{
			if (_activated)
			{
				return _subContractor;
			}
			Activate();
			return _subContractor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_subContractor = v;
			}, _subContractor, value, "SubContractor", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcText? JobDescription
	{
		get
		{
			if (_activated)
			{
				return _jobDescription;
			}
			Activate();
			return _jobDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_jobDescription = v;
			}, _jobDescription, value, "JobDescription", 11);
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
			if (base.BaseQuantity != null)
			{
				yield return base.BaseQuantity;
			}
			if (SubContractor != null)
			{
				yield return SubContractor;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSubContractResource), 11)]
	IfcSubContractResourceTypeEnum? IIfcSubContractResource.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcSubContractResourceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -11);
		}
	}

	internal IfcSubContractResource(IModel model, int label, bool activated)
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
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_subContractor = (IfcActorSelect)value.EntityVal;
			break;
		case 10:
			_jobDescription = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSubContractResource other)
	{
		return this == other;
	}
}
