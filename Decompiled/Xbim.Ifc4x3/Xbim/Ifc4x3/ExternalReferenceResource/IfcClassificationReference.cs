using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcClassificationReference", 209)]
public class IfcClassificationReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcClassificationReferenceSelect, IExpressSelectType, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcClassificationReference>, IIfcClassificationReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.ExternalReferenceResource.IfcClassificationReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcClassificationSelect
{
	private IfcClassificationReferenceSelect _referencedSource;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _sort;

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
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Sort
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
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

	[CrossSchemaAttribute(typeof(IIfcClassificationReference), 4)]
	IIfcClassificationReferenceSelect IIfcClassificationReference.ReferencedSource
	{
		get
		{
			if (ReferencedSource == null)
			{
				return null;
			}
			IfcClassification ifcClassification = ReferencedSource as IfcClassification;
			if (ifcClassification != null)
			{
				return ifcClassification;
			}
			IfcClassificationReference ifcClassificationReference = ReferencedSource as IfcClassificationReference;
			if (ifcClassificationReference != null)
			{
				return ifcClassificationReference;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				ReferencedSource = null;
				return;
			}
			IfcClassification ifcClassification = value as IfcClassification;
			if (ifcClassification != null)
			{
				ReferencedSource = ifcClassification;
				return;
			}
			IfcClassificationReference ifcClassificationReference = value as IfcClassificationReference;
			if (ifcClassificationReference != null)
			{
				ReferencedSource = ifcClassificationReference;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassificationReference), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcClassificationReference.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassificationReference), 6)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcClassificationReference.Sort
	{
		get
		{
			if (!Sort.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Sort.Value);
		}
		set
		{
			Sort = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	IEnumerable<IIfcRelAssociatesClassification> IIfcClassificationReference.ClassificationRefForObjects => base.Model.Instances.Where((IIfcRelAssociatesClassification e) => e.RelatingClassification as IfcClassificationReference == this, "RelatingClassification", this);

	IEnumerable<IIfcClassificationReference> IIfcClassificationReference.HasReferences => base.Model.Instances.Where((IIfcClassificationReference e) => e.ReferencedSource as IfcClassificationReference == this, "ReferencedSource", this);

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
