using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcProcess", 73)]
public abstract class IfcProcess : IfcObject, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IEquatable<IfcProcess>
{
	private IfcIdentifier? _identification;

	private IfcText? _longDescription;

	[CrossSchemaAttribute(typeof(IIfcProcess), 6)]
	IfcIdentifier? IIfcProcess.Identification
	{
		get
		{
			return _identification;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", -6);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProcess), 7)]
	IfcText? IIfcProcess.LongDescription
	{
		get
		{
			return _longDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_longDescription = v;
			}, _longDescription, value, "LongDescription", -7);
		}
	}

	IEnumerable<IIfcRelSequence> IIfcProcess.IsPredecessorTo => base.Model.Instances.Where((IIfcRelSequence e) => e.RelatingProcess as IfcProcess == this, "RelatingProcess", this);

	IEnumerable<IIfcRelSequence> IIfcProcess.IsSuccessorFrom => base.Model.Instances.Where((IIfcRelSequence e) => e.RelatedProcess as IfcProcess == this, "RelatedProcess", this);

	IEnumerable<IIfcRelAssignsToProcess> IIfcProcess.OperatesOn => base.Model.Instances.Where((IIfcRelAssignsToProcess e) => e.RelatingProcess as IfcProcess == this, "RelatingProcess", this);

	[InverseProperty("RelatingProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcRelAssignsToProcess> OperatesOn => base.Model.Instances.Where((IfcRelAssignsToProcess e) => Equals(e.RelatingProcess), "RelatingProcess", this);

	[InverseProperty("RelatedProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 12)]
	public IEnumerable<IfcRelSequence> IsSuccessorFrom => base.Model.Instances.Where((IfcRelSequence e) => Equals(e.RelatedProcess), "RelatedProcess", this);

	[InverseProperty("RelatingProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 13)]
	public IEnumerable<IfcRelSequence> IsPredecessorTo => base.Model.Instances.Where((IfcRelSequence e) => Equals(e.RelatingProcess), "RelatingProcess", this);

	internal IfcProcess(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 4u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcProcess other)
	{
		return this == other;
	}
}
