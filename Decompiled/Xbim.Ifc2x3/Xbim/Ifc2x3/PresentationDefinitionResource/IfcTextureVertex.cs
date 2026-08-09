using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcTextureVertex", 735)]
public class IfcTextureVertex : PersistEntity, IIfcTextureVertex, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcTextureVertex>
{
	private readonly ItemSet<Xbim.Ifc2x3.MeasureResource.IfcParameterValue> _coordinates;

	[CrossSchemaAttribute(typeof(IIfcTextureVertex), 1)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue> IIfcTextureVertex.Coordinates => new ProxyValueSet<Xbim.Ifc2x3.MeasureResource.IfcParameterValue, Xbim.Ifc4.MeasureResource.IfcParameterValue>(Coordinates, (Xbim.Ifc2x3.MeasureResource.IfcParameterValue s) => new Xbim.Ifc4.MeasureResource.IfcParameterValue(s), (Xbim.Ifc4.MeasureResource.IfcParameterValue t) => new Xbim.Ifc2x3.MeasureResource.IfcParameterValue(t));

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 2 }, 1)]
	public IItemSet<Xbim.Ifc2x3.MeasureResource.IfcParameterValue> Coordinates
	{
		get
		{
			if (_activated)
			{
				return _coordinates;
			}
			Activate();
			return _coordinates;
		}
	}

	internal IfcTextureVertex(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordinates = new ItemSet<Xbim.Ifc2x3.MeasureResource.IfcParameterValue>(this, 2, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_coordinates.InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTextureVertex other)
	{
		return this == other;
	}
}
