using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcRelSpaceBoundary2ndLevel", 1254)]
public class IfcRelSpaceBoundary2ndLevel : IfcRelSpaceBoundary1stLevel, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelSpaceBoundary2ndLevel, IIfcRelSpaceBoundary1stLevel, IIfcRelSpaceBoundary, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSpaceBoundary2ndLevel>
{
	private IfcRelSpaceBoundary2ndLevel _correspondingBoundary;

	IIfcRelSpaceBoundary2ndLevel IIfcRelSpaceBoundary2ndLevel.CorrespondingBoundary
	{
		get
		{
			return CorrespondingBoundary;
		}
		set
		{
			CorrespondingBoundary = value as IfcRelSpaceBoundary2ndLevel;
		}
	}

	IEnumerable<IIfcRelSpaceBoundary2ndLevel> IIfcRelSpaceBoundary2ndLevel.Corresponds => Corresponds;

	[IndexedProperty]
	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcRelSpaceBoundary2ndLevel CorrespondingBoundary
	{
		get
		{
			if (_activated)
			{
				return _correspondingBoundary;
			}
			Activate();
			return _correspondingBoundary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRelSpaceBoundary2ndLevel v)
			{
				_correspondingBoundary = v;
			}, _correspondingBoundary, value, "CorrespondingBoundary", 11);
		}
	}

	[InverseProperty("CorrespondingBoundary")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 13)]
	public IEnumerable<IfcRelSpaceBoundary2ndLevel> Corresponds => base.Model.Instances.Where((IfcRelSpaceBoundary2ndLevel e) => Equals(e.CorrespondingBoundary), "CorrespondingBoundary", this);

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
			if (base.ParentBoundary != null)
			{
				yield return base.ParentBoundary;
			}
			if (CorrespondingBoundary != null)
			{
				yield return CorrespondingBoundary;
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
			if (base.ParentBoundary != null)
			{
				yield return base.ParentBoundary;
			}
			if (CorrespondingBoundary != null)
			{
				yield return CorrespondingBoundary;
			}
		}
	}

	internal IfcRelSpaceBoundary2ndLevel(IModel model, int label, bool activated)
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
		case 9:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_correspondingBoundary = (IfcRelSpaceBoundary2ndLevel)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelSpaceBoundary2ndLevel other)
	{
		return this == other;
	}
}
