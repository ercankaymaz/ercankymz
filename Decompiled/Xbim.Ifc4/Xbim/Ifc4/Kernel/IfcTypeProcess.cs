using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcTypeProcess", 1306)]
public abstract class IfcTypeProcess : IfcTypeObject, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IEquatable<IfcTypeProcess>
{
	private IfcIdentifier? _identification;

	private IfcText? _longDescription;

	private IfcLabel? _processType;

	IfcIdentifier? IIfcTypeProcess.Identification
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

	IfcText? IIfcTypeProcess.LongDescription
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

	IfcLabel? IIfcTypeProcess.ProcessType
	{
		get
		{
			return ProcessType;
		}
		set
		{
			ProcessType = value;
		}
	}

	IEnumerable<IIfcRelAssignsToProcess> IIfcTypeProcess.OperatesOn => OperatesOn;

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
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
			}, _identification, value, "Identification", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
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
			}, _longDescription, value, "LongDescription", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcLabel? ProcessType
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
			SetValue(delegate(IfcLabel? v)
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
