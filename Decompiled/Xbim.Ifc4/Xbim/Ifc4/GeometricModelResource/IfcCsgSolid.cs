using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcCsgSolid", 548)]
public class IfcCsgSolid : IfcSolidModel, IInstantiableEntity, IPersistEntity, IPersist, IIfcCsgSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcCsgSolid>
{
	private IfcCsgSelect _treeRootExpression;

	IIfcCsgSelect IIfcCsgSolid.TreeRootExpression
	{
		get
		{
			return TreeRootExpression;
		}
		set
		{
			TreeRootExpression = value as IfcCsgSelect;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCsgSelect TreeRootExpression
	{
		get
		{
			if (_activated)
			{
				return _treeRootExpression;
			}
			Activate();
			return _treeRootExpression;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCsgSelect v)
			{
				_treeRootExpression = v;
			}, _treeRootExpression, value, "TreeRootExpression", 1);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (TreeRootExpression != null)
			{
				yield return TreeRootExpression;
			}
		}
	}

	internal IfcCsgSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_treeRootExpression = (IfcCsgSelect)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCsgSolid other)
	{
		return this == other;
	}
}
