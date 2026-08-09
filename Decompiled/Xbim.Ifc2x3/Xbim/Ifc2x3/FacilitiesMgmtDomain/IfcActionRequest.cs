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

[ExpressType("IfcActionRequest", 516)]
public class IfcActionRequest : Xbim.Ifc2x3.Kernel.IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcActionRequest>, IIfcActionRequest, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _requestID;

	private IfcActionRequestTypeEnum? _predefinedType;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4.MeasureResource.IfcText? _longDescription;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier RequestID
	{
		get
		{
			if (_activated)
			{
				return _requestID;
			}
			Activate();
			return _requestID;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_requestID = v;
			}, _requestID, value, "RequestID", 6);
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

	[CrossSchemaAttribute(typeof(IIfcActionRequest), 7)]
	IfcActionRequestTypeEnum? IIfcActionRequest.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcActionRequestTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -7);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcActionRequest), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcActionRequest.Status
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

	[CrossSchemaAttribute(typeof(IIfcActionRequest), 9)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcActionRequest.LongDescription
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

	internal IfcActionRequest(IModel model, int label, bool activated)
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
			_requestID = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcActionRequest other)
	{
		return this == other;
	}
}
