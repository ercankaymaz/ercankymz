using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProcessExtension;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcProcess", 73)]
public abstract class IfcProcess : IfcObject, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IEquatable<IfcProcess>
{
	private IfcIdentifier? _identification;

	private IfcText? _longDescription;

	IfcIdentifier? IIfcProcess.Identification
	{
		get
		{
			return Identification;
		}
		set
		{
			Identification = value;
		}
	}

	IfcText? IIfcProcess.LongDescription
	{
		get
		{
			return LongDescription;
		}
		set
		{
			LongDescription = value;
		}
	}

	IEnumerable<IIfcRelSequence> IIfcProcess.IsPredecessorTo => IsPredecessorTo;

	IEnumerable<IIfcRelSequence> IIfcProcess.IsSuccessorFrom => IsSuccessorFrom;

	IEnumerable<IIfcRelAssignsToProcess> IIfcProcess.OperatesOn => OperatesOn;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcIdentifier? Identification
	{
		get
		{
			if (_activated)
			{
				return _identification;
			}
			Activate();
			return _identification;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public IfcText? LongDescription
	{
		get
		{
			if (_activated)
			{
				return _longDescription;
			}
			Activate();
			return _longDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", 7);
		}
	}

	[InverseProperty("RelatingProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 19)]
	public IEnumerable<IfcRelSequence> IsPredecessorTo => base.Model.Instances.Where((IfcRelSequence e) => Equals(e.RelatingProcess), "RelatingProcess", this);

	[InverseProperty("RelatedProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 20)]
	public IEnumerable<IfcRelSequence> IsSuccessorFrom => base.Model.Instances.Where((IfcRelSequence e) => Equals(e.RelatedProcess), "RelatedProcess", this);

	[InverseProperty("RelatingProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 21)]
	public IEnumerable<IfcRelAssignsToProcess> OperatesOn => base.Model.Instances.Where((IfcRelAssignsToProcess e) => Equals(e.RelatingProcess), "RelatingProcess", this);

	internal IfcProcess(IModel model, int label, bool activated)
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
			_identification = value.StringVal;
			break;
		case 6:
			_longDescription = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProcess other)
	{
		return this == other;
	}
}
