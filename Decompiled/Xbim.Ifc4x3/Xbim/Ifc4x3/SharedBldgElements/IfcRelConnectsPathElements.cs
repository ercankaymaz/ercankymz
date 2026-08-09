using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcRelConnectsPathElements", 668)]
public class IfcRelConnectsPathElements : IfcRelConnectsElements, IIfcRelConnectsPathElements, IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsPathElements>
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _relatingPriorities;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _relatedPriorities;

	private IfcConnectionTypeEnum _relatedConnectionType;

	private IfcConnectionTypeEnum _relatingConnectionType;

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 8)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcRelConnectsPathElements.RelatingPriorities => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(RelatingPriorities, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 9)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcRelConnectsPathElements.RelatedPriorities => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(RelatedPriorities, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 10)]
	Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum IIfcRelConnectsPathElements.RelatedConnectionType
	{
		get
		{
			return RelatedConnectionType switch
			{
				IfcConnectionTypeEnum.ATEND => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATEND, 
				IfcConnectionTypeEnum.ATPATH => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATPATH, 
				IfcConnectionTypeEnum.ATSTART => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATSTART, 
				IfcConnectionTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATPATH:
				RelatedConnectionType = IfcConnectionTypeEnum.ATPATH;
				break;
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATSTART:
				RelatedConnectionType = IfcConnectionTypeEnum.ATSTART;
				break;
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATEND:
				RelatedConnectionType = IfcConnectionTypeEnum.ATEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.NOTDEFINED:
				RelatedConnectionType = IfcConnectionTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 11)]
	Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum IIfcRelConnectsPathElements.RelatingConnectionType
	{
		get
		{
			return RelatingConnectionType switch
			{
				IfcConnectionTypeEnum.ATEND => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATEND, 
				IfcConnectionTypeEnum.ATPATH => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATPATH, 
				IfcConnectionTypeEnum.ATSTART => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATSTART, 
				IfcConnectionTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATPATH:
				RelatingConnectionType = IfcConnectionTypeEnum.ATPATH;
				break;
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATSTART:
				RelatingConnectionType = IfcConnectionTypeEnum.ATSTART;
				break;
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATEND:
				RelatingConnectionType = IfcConnectionTypeEnum.ATEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.NOTDEFINED:
				RelatingConnectionType = IfcConnectionTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 0 }, new int[] { -1 }, 8)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> RelatingPriorities
	{
		get
		{
			if (_activated)
			{
				return _relatingPriorities;
			}
			Activate();
			return _relatingPriorities;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 0 }, new int[] { -1 }, 9)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> RelatedPriorities
	{
		get
		{
			if (_activated)
			{
				return _relatedPriorities;
			}
			Activate();
			return _relatedPriorities;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcConnectionTypeEnum RelatedConnectionType
	{
		get
		{
			if (_activated)
			{
				return _relatedConnectionType;
			}
			Activate();
			return _relatedConnectionType;
		}
		set
		{
			SetValue(delegate(IfcConnectionTypeEnum v)
			{
				_relatedConnectionType = v;
			}, _relatedConnectionType, value, "RelatedConnectionType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcConnectionTypeEnum RelatingConnectionType
	{
		get
		{
			if (_activated)
			{
				return _relatingConnectionType;
			}
			Activate();
			return _relatingConnectionType;
		}
		set
		{
			SetValue(delegate(IfcConnectionTypeEnum v)
			{
				_relatingConnectionType = v;
			}, _relatingConnectionType, value, "RelatingConnectionType", 11);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ConnectionGeometry != null)
			{
				yield return base.ConnectionGeometry;
			}
			if (base.RelatingElement != null)
			{
				yield return base.RelatingElement;
			}
			if (base.RelatedElement != null)
			{
				yield return base.RelatedElement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingElement != null)
			{
				yield return base.RelatingElement;
			}
			if (base.RelatedElement != null)
			{
				yield return base.RelatedElement;
			}
		}
	}

	internal IfcRelConnectsPathElements(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatingPriorities = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 8);
		_relatedPriorities = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 9);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_relatingPriorities.InternalAdd(value.IntegerVal);
			break;
		case 8:
			_relatedPriorities.InternalAdd(value.IntegerVal);
			break;
		case 9:
			_relatedConnectionType = (IfcConnectionTypeEnum)Enum.Parse(typeof(IfcConnectionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_relatingConnectionType = (IfcConnectionTypeEnum)Enum.Parse(typeof(IfcConnectionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsPathElements other)
	{
		return this == other;
	}
}
