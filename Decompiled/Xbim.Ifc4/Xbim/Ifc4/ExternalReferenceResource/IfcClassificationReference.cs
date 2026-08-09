using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.ExternalReferenceResource;

[ExpressType("IfcClassificationReference", 209)]
public class IfcClassificationReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IIfcClassificationReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcClassificationReference>
{
	private IfcClassificationReferenceSelect _referencedSource;

	private IfcText? _description;

	private IfcIdentifier? _sort;

	IIfcClassificationReferenceSelect IIfcClassificationReference.ReferencedSource
	{
		get
		{
			return ReferencedSource;
		}
		set
		{
			ReferencedSource = value as IfcClassificationReferenceSelect;
		}
	}

	IfcText? IIfcClassificationReference.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IfcIdentifier? IIfcClassificationReference.Sort
	{
		get
		{
			return Sort;
		}
		set
		{
			Sort = value;
		}
	}

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassificationReference.ClassificationRefForObjects => ClassificationRefForObjects;

	IEnumerable<IIfcClassificationReference> IIfcClassificationReference.HasReferences => HasReferences;

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcClassificationReferenceSelect ReferencedSource
	{
		get
		{
			if (_activated)
			{
				return _referencedSource;
			}
			Activate();
			return _referencedSource;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcClassificationReferenceSelect v)
			{
				_referencedSource = v;
			}, _referencedSource, value, "ReferencedSource", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcIdentifier? Sort
	{
		get
		{
			if (_activated)
			{
				return _sort;
			}
			Activate();
			return _sort;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_sort = v;
			}, _sort, value, "Sort", 6);
		}
	}

	[InverseProperty("RelatingClassification")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcRelAssociatesClassification> ClassificationRefForObjects => base.Model.Instances.Where((IfcRelAssociatesClassification e) => Equals(e.RelatingClassification), "RelatingClassification", this);

	[InverseProperty("ReferencedSource")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcClassificationReference> HasReferences => base.Model.Instances.Where((IfcClassificationReference e) => Equals(e.ReferencedSource), "ReferencedSource", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ReferencedSource != null)
			{
				yield return ReferencedSource;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ReferencedSource != null)
			{
				yield return ReferencedSource;
			}
		}
	}

	internal IfcClassificationReference(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_referencedSource = (IfcClassificationReferenceSelect)value.EntityVal;
			break;
		case 4:
			_description = value.StringVal;
			break;
		case 5:
			_sort = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcClassificationReference other)
	{
		return this == other;
	}
}
