using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;

namespace Xbim.Ifc2x3.ArchitectureDomain;

[ExpressType("IfcSpaceProgram", 709)]
public class IfcSpaceProgram : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSpaceProgram>
{
	private IfcIdentifier _spaceProgramIdentifier;

	private IfcAreaMeasure? _maxRequiredArea;

	private IfcAreaMeasure? _minRequiredArea;

	private IfcSpatialStructureElement _requestedLocation;

	private IfcAreaMeasure _standardRequiredArea;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcIdentifier SpaceProgramIdentifier
	{
		get
		{
			if (_activated)
			{
				return _spaceProgramIdentifier;
			}
			Activate();
			return _spaceProgramIdentifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier v)
			{
				_spaceProgramIdentifier = v;
			}, _spaceProgramIdentifier, value, "SpaceProgramIdentifier", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcAreaMeasure? MaxRequiredArea
	{
		get
		{
			if (_activated)
			{
				return _maxRequiredArea;
			}
			Activate();
			return _maxRequiredArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_maxRequiredArea = v;
			}, _maxRequiredArea, value, "MaxRequiredArea", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcAreaMeasure? MinRequiredArea
	{
		get
		{
			if (_activated)
			{
				return _minRequiredArea;
			}
			Activate();
			return _minRequiredArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure? v)
			{
				_minRequiredArea = v;
			}, _minRequiredArea, value, "MinRequiredArea", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 15)]
	public IfcSpatialStructureElement RequestedLocation
	{
		get
		{
			if (_activated)
			{
				return _requestedLocation;
			}
			Activate();
			return _requestedLocation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialStructureElement v)
			{
				_requestedLocation = v;
			}, _requestedLocation, value, "RequestedLocation", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcAreaMeasure StandardRequiredArea
	{
		get
		{
			if (_activated)
			{
				return _standardRequiredArea;
			}
			Activate();
			return _standardRequiredArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure v)
			{
				_standardRequiredArea = v;
			}, _standardRequiredArea, value, "StandardRequiredArea", 10);
		}
	}

	[InverseProperty("RelatedSpaceProgram")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 17)]
	public IEnumerable<IfcRelInteractionRequirements> HasInteractionReqsFrom => base.Model.Instances.Where((IfcRelInteractionRequirements e) => Equals(e.RelatedSpaceProgram), "RelatedSpaceProgram", this);

	[InverseProperty("RelatingSpaceProgram")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelInteractionRequirements> HasInteractionReqsTo => base.Model.Instances.Where((IfcRelInteractionRequirements e) => Equals(e.RelatingSpaceProgram), "RelatingSpaceProgram", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (RequestedLocation != null)
			{
				yield return RequestedLocation;
			}
		}
	}

	internal IfcSpaceProgram(IModel model, int label, bool activated)
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
			_spaceProgramIdentifier = value.StringVal;
			break;
		case 6:
			_maxRequiredArea = value.RealVal;
			break;
		case 7:
			_minRequiredArea = value.RealVal;
			break;
		case 8:
			_requestedLocation = (IfcSpatialStructureElement)value.EntityVal;
			break;
		case 9:
			_standardRequiredArea = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpaceProgram other)
	{
		return this == other;
	}
}
