using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcClassificationReference", 209)]
public class IfcClassificationReference : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IfcClassificationNotationSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcClassificationReference>, IIfcClassificationReference, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect
{
	private IfcClassification _referencedSource;

	private IIfcClassificationReferenceSelect _referencedSource4;

	private IfcText? _description;

	private IfcIdentifier? _sort;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcClassification ReferencedSource
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
			SetValue(delegate(IfcClassification v)
			{
				_referencedSource = v;
			}, _referencedSource, value, "ReferencedSource", 4);
		}
	}

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

	[CrossSchemaAttribute(typeof(IIfcClassificationReference), 4)]
	IIfcClassificationReferenceSelect IIfcClassificationReference.ReferencedSource
	{
		get
		{
			return _referencedSource4 ?? ReferencedSource;
		}
		set
		{
			if (value == null)
			{
				ReferencedSource = null;
				if (_referencedSource4 != null)
				{
					SetValue(delegate(IIfcClassificationReferenceSelect v)
					{
						_referencedSource4 = v;
					}, _referencedSource4, null, "ReferencedSource", -4);
				}
				return;
			}
			IfcClassification ifcClassification = value as IfcClassification;
			if (ifcClassification != null)
			{
				ReferencedSource = ifcClassification;
				if (_referencedSource4 != null)
				{
					SetValue(delegate(IIfcClassificationReferenceSelect v)
					{
						_referencedSource4 = v;
					}, _referencedSource4, null, "ReferencedSource", -4);
				}
			}
			else
			{
				if (ReferencedSource != null)
				{
					ReferencedSource = null;
				}
				SetValue(delegate(IIfcClassificationReferenceSelect v)
				{
					_referencedSource4 = v;
				}, _referencedSource4, value, "ReferencedSource", -4);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassificationReference), 5)]
	IfcText? IIfcClassificationReference.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -5);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcClassificationReference), 6)]
	IfcIdentifier? IIfcClassificationReference.Sort
	{
		get
		{
			return _sort;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_sort = v;
			}, _sort, value, "Sort", -6);
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
			_referencedSource = (IfcClassification)value.EntityVal;
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
