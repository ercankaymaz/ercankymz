using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProcessExtension;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcProcess", 73)]
public abstract class IfcProcess : IfcObject, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IfcProcessSelect, IEquatable<IfcProcess>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identification;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _longDescription;

	[CrossSchemaAttribute(typeof(IIfcProcess), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcProcess.Identification
	{
		get
		{
			if (!Identification.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Identification.Value);
		}
		set
		{
			Identification = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProcess), 7)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcProcess.LongDescription
	{
		get
		{
			if (!LongDescription.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(LongDescription.Value);
		}
		set
		{
			LongDescription = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	IEnumerable<IIfcRelSequence> IIfcProcess.IsPredecessorTo => base.Model.Instances.Where((IIfcRelSequence e) => e.RelatingProcess as IfcProcess == this, "RelatingProcess", this);

	IEnumerable<IIfcRelSequence> IIfcProcess.IsSuccessorFrom => base.Model.Instances.Where((IIfcRelSequence e) => e.RelatedProcess as IfcProcess == this, "RelatedProcess", this);

	IEnumerable<IIfcRelAssignsToProcess> IIfcProcess.OperatesOn => base.Model.Instances.Where((IIfcRelAssignsToProcess e) => e.RelatingProcess as IfcProcess == this, "RelatingProcess", this);

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Identification
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? LongDescription
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
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
