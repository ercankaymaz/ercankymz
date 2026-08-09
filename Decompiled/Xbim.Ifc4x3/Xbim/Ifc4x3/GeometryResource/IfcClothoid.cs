using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcClothoid", 1421)]
public class IfcClothoid : IfcSpiral, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcClothoid>
{
	private IfcLengthMeasure _clothoidConstant;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure ClothoidConstant
	{
		get
		{
			if (_activated)
			{
				return _clothoidConstant;
			}
			Activate();
			return _clothoidConstant;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_clothoidConstant = v;
			}, _clothoidConstant, value, "ClothoidConstant", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcClothoid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_clothoidConstant = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcClothoid other)
	{
		return this == other;
	}
}
