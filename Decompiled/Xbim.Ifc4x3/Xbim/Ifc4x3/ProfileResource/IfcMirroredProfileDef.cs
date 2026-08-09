using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcMirroredProfileDef", 1215)]
public class IfcMirroredProfileDef : IfcDerivedProfileDef, IIfcMirroredProfileDef, IIfcDerivedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcMirroredProfileDef>
{
	[EntityAttribute(4, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcCartesianTransformationOperator2D Operator
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property Operator in IfcMirroredProfileDef");
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ParentProfile != null)
			{
				yield return base.ParentProfile;
			}
			if (Operator != null)
			{
				yield return Operator;
			}
		}
	}

	internal IfcMirroredProfileDef(IModel model, int label, bool activated)
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

	public bool Equals(IfcMirroredProfileDef other)
	{
		return this == other;
	}
}
