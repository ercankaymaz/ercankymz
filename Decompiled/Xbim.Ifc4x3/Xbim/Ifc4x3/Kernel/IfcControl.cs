using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcControl", 76)]
public abstract class IfcControl : IfcObject, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcControl>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identification;

	[CrossSchemaAttribute(typeof(IIfcControl), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcControl.Identification
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

	IEnumerable<IIfcRelAssignsToControl> IIfcControl.Controls => base.Model.Instances.Where((IIfcRelAssignsToControl e) => e.RelatingControl as IfcControl == this, "RelatingControl", this);

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

	[InverseProperty("RelatingControl")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelAssignsToControl> Controls => base.Model.Instances.Where((IfcRelAssignsToControl e) => Equals(e.RelatingControl), "RelatingControl", this);

	internal IfcControl(IModel model, int label, bool activated)
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcControl other)
	{
		return this == other;
	}
}
