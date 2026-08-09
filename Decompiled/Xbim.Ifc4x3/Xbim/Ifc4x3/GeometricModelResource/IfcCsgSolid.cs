using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcCsgSolid", 548)]
public class IfcCsgSolid : IfcSolidModel, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCsgSolid>, IIfcCsgSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcCsgSelect _treeRootExpression;

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

	[CrossSchemaAttribute(typeof(IIfcCsgSolid), 1)]
	IIfcCsgSelect IIfcCsgSolid.TreeRootExpression
	{
		get
		{
			if (TreeRootExpression == null)
			{
				return null;
			}
			IfcBooleanResult ifcBooleanResult = TreeRootExpression as IfcBooleanResult;
			if (ifcBooleanResult != null)
			{
				return ifcBooleanResult;
			}
			IfcCsgPrimitive3D ifcCsgPrimitive3D = TreeRootExpression as IfcCsgPrimitive3D;
			if (ifcCsgPrimitive3D != null)
			{
				return ifcCsgPrimitive3D;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TreeRootExpression = null;
				return;
			}
			IfcBooleanResult ifcBooleanResult = value as IfcBooleanResult;
			if (ifcBooleanResult != null)
			{
				TreeRootExpression = ifcBooleanResult;
				return;
			}
			IfcCsgPrimitive3D ifcCsgPrimitive3D = value as IfcCsgPrimitive3D;
			if (ifcCsgPrimitive3D != null)
			{
				TreeRootExpression = ifcCsgPrimitive3D;
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
