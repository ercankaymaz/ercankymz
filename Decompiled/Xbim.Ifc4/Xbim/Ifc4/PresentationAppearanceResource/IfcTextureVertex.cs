using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextureVertex", 735)]
public class IfcTextureVertex : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextureVertex, IIfcPresentationItem, IEquatable<IfcTextureVertex>
{
	private readonly ItemSet<IfcParameterValue> _coordinates;

	IItemSet<IfcParameterValue> IIfcTextureVertex.Coordinates => Coordinates;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 2 }, 1)]
	public IItemSet<IfcParameterValue> Coordinates
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
		_coordinates = new ItemSet<IfcParameterValue>(this, 2, 1);
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
