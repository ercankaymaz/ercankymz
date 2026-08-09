using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcArbitraryProfileDefWithVoids", 116)]
public class IfcArbitraryProfileDefWithVoids : IfcArbitraryClosedProfileDef, IIfcArbitraryProfileDefWithVoids, IIfcArbitraryClosedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcArbitraryProfileDefWithVoids>
{
	private readonly ItemSet<IfcCurve> _innerCurves;

	[CrossSchemaAttribute(typeof(IIfcArbitraryProfileDefWithVoids), 4)]
	IItemSet<IIfcCurve> IIfcArbitraryProfileDefWithVoids.InnerCurves => new ProxyItemSet<IfcCurve, IIfcCurve>(InnerCurves);

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcCurve> InnerCurves
	{
		get
		{
			if (_activated)
			{
				return _innerCurves;
			}
			Activate();
			return _innerCurves;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OuterCurve != null)
			{
				yield return base.OuterCurve;
			}
			foreach (IfcCurve innerCurf in InnerCurves)
			{
				yield return innerCurf;
			}
		}
	}

	internal IfcArbitraryProfileDefWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerCurves = new ItemSet<IfcCurve>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_innerCurves.InternalAdd((IfcCurve)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcArbitraryProfileDefWithVoids other)
	{
		return this == other;
	}
}
