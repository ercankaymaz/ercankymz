using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcControl", 76)]
public abstract class IfcControl : IfcObject, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcControl>
{
	private IfcIdentifier? _identification;

	[CrossSchemaAttribute(typeof(IIfcControl), 6)]
	IfcIdentifier? IIfcControl.Identification
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

	IEnumerable<IIfcRelAssignsToControl> IIfcControl.Controls => base.Model.Instances.Where((IIfcRelAssignsToControl e) => e.RelatingControl as IfcControl == this, "RelatingControl", this);

	[InverseProperty("RelatingControl")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcRelAssignsToControl> Controls => base.Model.Instances.Where((IfcRelAssignsToControl e) => Equals(e.RelatingControl), "RelatingControl", this);

	internal IfcControl(IModel model, int label, bool activated)
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

	public bool Equals(IfcControl other)
	{
		return this == other;
	}
}
