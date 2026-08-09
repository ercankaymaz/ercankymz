using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssociatesLibrary", 522)]
public class IfcRelAssociatesLibrary : IfcRelAssociates, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssociatesLibrary, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociatesLibrary>
{
	private IfcLibrarySelect _relatingLibrary;

	IIfcLibrarySelect IIfcRelAssociatesLibrary.RelatingLibrary
	{
		get
		{
			return RelatingLibrary;
		}
		set
		{
			RelatingLibrary = value as IfcLibrarySelect;
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcLibrarySelect RelatingLibrary
	{
		get
		{
			if (_activated)
			{
				return _relatingLibrary;
			}
			Activate();
			return _relatingLibrary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLibrarySelect v)
			{
				_relatingLibrary = v;
			}, _relatingLibrary, value, "RelatingLibrary", 6);
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
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingLibrary != null)
			{
				yield return RelatingLibrary;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcDefinitionSelect relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingLibrary != null)
			{
				yield return RelatingLibrary;
			}
		}
	}

	internal IfcRelAssociatesLibrary(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingLibrary = (IfcLibrarySelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociatesLibrary other)
	{
		return this == other;
	}
}
