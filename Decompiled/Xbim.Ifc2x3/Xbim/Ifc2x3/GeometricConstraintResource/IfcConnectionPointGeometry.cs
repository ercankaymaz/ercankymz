using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.TopologyResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcConnectionPointGeometry", 71)]
public class IfcConnectionPointGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConnectionPointGeometry>, IIfcConnectionPointGeometry, IIfcConnectionGeometry
{
	private IfcPointOrVertexPoint _pointOnRelatingElement;

	private IfcPointOrVertexPoint _pointOnRelatedElement;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcPointOrVertexPoint PointOnRelatingElement
	{
		get
		{
			if (_activated)
			{
				return _pointOnRelatingElement;
			}
			Activate();
			return _pointOnRelatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPointOrVertexPoint v)
			{
				_pointOnRelatingElement = v;
			}, _pointOnRelatingElement, value, "PointOnRelatingElement", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcPointOrVertexPoint PointOnRelatedElement
	{
		get
		{
			if (_activated)
			{
				return _pointOnRelatedElement;
			}
			Activate();
			return _pointOnRelatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPointOrVertexPoint v)
			{
				_pointOnRelatedElement = v;
			}, _pointOnRelatedElement, value, "PointOnRelatedElement", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (PointOnRelatingElement != null)
			{
				yield return PointOnRelatingElement;
			}
			if (PointOnRelatedElement != null)
			{
				yield return PointOnRelatedElement;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionPointGeometry), 1)]
	IIfcPointOrVertexPoint IIfcConnectionPointGeometry.PointOnRelatingElement
	{
		get
		{
			if (PointOnRelatingElement == null)
			{
				return null;
			}
			IfcPoint ifcPoint = PointOnRelatingElement as IfcPoint;
			if (ifcPoint != null)
			{
				return ifcPoint;
			}
			IfcVertexPoint ifcVertexPoint = PointOnRelatingElement as IfcVertexPoint;
			if (ifcVertexPoint != null)
			{
				return ifcVertexPoint;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				PointOnRelatingElement = null;
				return;
			}
			IfcPoint ifcPoint = value as IfcPoint;
			if (ifcPoint != null)
			{
				PointOnRelatingElement = ifcPoint;
				return;
			}
			IfcVertexPoint ifcVertexPoint = value as IfcVertexPoint;
			if (ifcVertexPoint != null)
			{
				PointOnRelatingElement = ifcVertexPoint;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionPointGeometry), 2)]
	IIfcPointOrVertexPoint IIfcConnectionPointGeometry.PointOnRelatedElement
	{
		get
		{
			if (PointOnRelatedElement == null)
			{
				return null;
			}
			IfcPoint ifcPoint = PointOnRelatedElement as IfcPoint;
			if (ifcPoint != null)
			{
				return ifcPoint;
			}
			IfcVertexPoint ifcVertexPoint = PointOnRelatedElement as IfcVertexPoint;
			if (ifcVertexPoint != null)
			{
				return ifcVertexPoint;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				PointOnRelatedElement = null;
				return;
			}
			IfcPoint ifcPoint = value as IfcPoint;
			if (ifcPoint != null)
			{
				PointOnRelatedElement = ifcPoint;
				return;
			}
			IfcVertexPoint ifcVertexPoint = value as IfcVertexPoint;
			if (ifcVertexPoint != null)
			{
				PointOnRelatedElement = ifcVertexPoint;
			}
		}
	}

	internal IfcConnectionPointGeometry(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_pointOnRelatingElement = (IfcPointOrVertexPoint)value.EntityVal;
			break;
		case 1:
			_pointOnRelatedElement = (IfcPointOrVertexPoint)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConnectionPointGeometry other)
	{
		return this == other;
	}
}
