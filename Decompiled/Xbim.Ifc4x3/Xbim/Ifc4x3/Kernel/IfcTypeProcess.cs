using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcTypeProcess", 1306)]
public abstract class IfcTypeProcess : IfcTypeObject, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IfcProcessSelect, IEquatable<IfcTypeProcess>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identification;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _longDescription;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _processType;

	[CrossSchemaAttribute(typeof(IIfcTypeProcess), 7)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcTypeProcess.Identification
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

	[CrossSchemaAttribute(typeof(IIfcTypeProcess), 8)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcTypeProcess.LongDescription
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

	[CrossSchemaAttribute(typeof(IIfcTypeProcess), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTypeProcess.ProcessType
	{
		get
		{
			if (!ProcessType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ProcessType.Value);
		}
		set
		{
			ProcessType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelAssignsToProcess> IIfcTypeProcess.OperatesOn => base.Model.Instances.Where((IIfcRelAssignsToProcess e) => e.RelatingProcess as IfcTypeProcess == this, "RelatingProcess", this);

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
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
			}, _identification, value, "Identification", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
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
			}, _longDescription, value, "LongDescription", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ProcessType
	{
		get
		{
			if (_activated)
			{
				return _processType;
			}
			Activate();
			return _processType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_processType = v;
			}, _processType, value, "ProcessType", 9);
		}
	}

	[InverseProperty("RelatingProcess")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelAssignsToProcess> OperatesOn => base.Model.Instances.Where((IfcRelAssignsToProcess e) => Equals(e.RelatingProcess), "RelatingProcess", this);

	internal IfcTypeProcess(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_identification = value.StringVal;
			break;
		case 7:
			_longDescription = value.StringVal;
			break;
		case 8:
			_processType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTypeProcess other)
	{
		return this == other;
	}
}
