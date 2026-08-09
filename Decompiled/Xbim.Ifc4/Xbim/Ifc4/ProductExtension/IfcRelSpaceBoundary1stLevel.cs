using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelSpaceBoundary1stLevel", 1253)]
public class IfcRelSpaceBoundary1stLevel : IfcRelSpaceBoundary, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelSpaceBoundary1stLevel, IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSpaceBoundary1stLevel>
{
	private IfcRelSpaceBoundary1stLevel _parentBoundary;

	IIfcRelSpaceBoundary1stLevel IIfcRelSpaceBoundary1stLevel.ParentBoundary
	{
		get
		{
			return ParentBoundary;
		}
		set
		{
			ParentBoundary = value as IfcRelSpaceBoundary1stLevel;
		}
	}

	IEnumerable<IIfcRelSpaceBoundary1stLevel> IIfcRelSpaceBoundary1stLevel.InnerBoundaries => InnerBoundaries;

	[IndexedProperty]
	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcRelSpaceBoundary1stLevel ParentBoundary
	{
		get
		{
			if (_activated)
			{
				return _parentBoundary;
			}
			Activate();
			return _parentBoundary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRelSpaceBoundary1stLevel v)
			{
				_parentBoundary = v;
			}, _parentBoundary, value, "ParentBoundary", 10);
		}
	}

	[InverseProperty("ParentBoundary")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcRelSpaceBoundary1stLevel> InnerBoundaries => base.Model.Instances.Where((IfcRelSpaceBoundary1stLevel e) => Equals(e.ParentBoundary), "ParentBoundary", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.RelatingSpace != null)
			{
				yield return base.RelatingSpace;
			}
			if (base.RelatedBuildingElement != null)
			{
				yield return base.RelatedBuildingElement;
			}
			if (base.ConnectionGeometry != null)
			{
				yield return base.ConnectionGeometry;
			}
			if (ParentBoundary != null)
			{
				yield return ParentBoundary;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingSpace != null)
			{
				yield return base.RelatingSpace;
			}
			if (base.RelatedBuildingElement != null)
			{
				yield return base.RelatedBuildingElement;
			}
			if (ParentBoundary != null)
			{
				yield return ParentBoundary;
			}
		}
	}

	internal IfcRelSpaceBoundary1stLevel(IModel model, int label, bool activated)
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
		case 5:
		case 6:
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_parentBoundary = (IfcRelSpaceBoundary1stLevel)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelSpaceBoundary1stLevel other)
	{
		return this == other;
	}
}
