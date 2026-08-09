using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcRelConnectsPathElements", 668)]
public class IfcRelConnectsPathElements : IfcRelConnectsElements, IIfcRelConnectsPathElements, IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsPathElements>
{
	private readonly ItemSet<long> _relatingPriorities;

	private readonly ItemSet<long> _relatedPriorities;

	private IfcConnectionTypeEnum _relatedConnectionType;

	private IfcConnectionTypeEnum _relatingConnectionType;

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 8)]
	IItemSet<IfcInteger> IIfcRelConnectsPathElements.RelatingPriorities => new ProxyValueSet<long, IfcInteger>(RelatingPriorities, (long s) => new IfcInteger(s), (IfcInteger t) => t);

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 9)]
	IItemSet<IfcInteger> IIfcRelConnectsPathElements.RelatedPriorities => new ProxyValueSet<long, IfcInteger>(RelatedPriorities, (long s) => new IfcInteger(s), (IfcInteger t) => t);

	[CrossSchemaAttribute(typeof(IIfcRelConnectsPathElements), 10)]
	Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum IIfcRelConnectsPathElements.RelatedConnectionType
	{
		get
		{
			return RelatedConnectionType switch
			{
				IfcConnectionTypeEnum.ATPATH => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATPATH, 
				IfcConnectionTypeEnum.ATSTART => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATSTART, 
				IfcConnectionTypeEnum.ATEND => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATEND, 
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
				IfcConnectionTypeEnum.ATPATH => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATPATH, 
				IfcConnectionTypeEnum.ATSTART => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATSTART, 
				IfcConnectionTypeEnum.ATEND => Xbim.Ifc4.Interfaces.IfcConnectionTypeEnum.ATEND, 
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
	public IItemSet<long> RelatingPriorities
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
	public IItemSet<long> RelatedPriorities
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
		_relatingPriorities = new ItemSet<long>(this, 0, 8);
		_relatedPriorities = new ItemSet<long>(this, 0, 9);
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
