using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcRelConnectsStructuralActivity", 211)]
public class IfcRelConnectsStructuralActivity : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelConnectsStructuralActivity, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelConnectsStructuralActivity>
{
	private IfcStructuralActivityAssignmentSelect _relatingElement;

	private IfcStructuralActivity _relatedStructuralActivity;

	IIfcStructuralActivityAssignmentSelect IIfcRelConnectsStructuralActivity.RelatingElement
	{
		get
		{
			return RelatingElement;
		}
		set
		{
			RelatingElement = value as IfcStructuralActivityAssignmentSelect;
		}
	}

	IIfcStructuralActivity IIfcRelConnectsStructuralActivity.RelatedStructuralActivity
	{
		get
		{
			return RelatedStructuralActivity;
		}
		set
		{
			RelatedStructuralActivity = value as IfcStructuralActivity;
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcStructuralActivityAssignmentSelect RelatingElement
	{
		get
		{
			if (_activated)
			{
				return _relatingElement;
			}
			Activate();
			return _relatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralActivityAssignmentSelect v)
			{
				_relatingElement = v;
			}, _relatingElement, value, "RelatingElement", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcStructuralActivity RelatedStructuralActivity
	{
		get
		{
			if (_activated)
			{
				return _relatedStructuralActivity;
			}
			Activate();
			return _relatedStructuralActivity;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralActivity v)
			{
				_relatedStructuralActivity = v;
			}, _relatedStructuralActivity, value, "RelatedStructuralActivity", 6);
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
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			if (RelatedStructuralActivity != null)
			{
				yield return RelatedStructuralActivity;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingElement != null)
			{
				yield return RelatingElement;
			}
			if (RelatedStructuralActivity != null)
			{
				yield return RelatedStructuralActivity;
			}
		}
	}

	internal IfcRelConnectsStructuralActivity(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingElement = (IfcStructuralActivityAssignmentSelect)value.EntityVal;
			break;
		case 5:
			_relatedStructuralActivity = (IfcStructuralActivity)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelConnectsStructuralActivity other)
	{
		return this == other;
	}
}
