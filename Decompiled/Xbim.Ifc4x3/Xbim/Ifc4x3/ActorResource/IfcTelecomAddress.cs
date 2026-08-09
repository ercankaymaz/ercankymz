using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ActorResource;

[ExpressType("IfcTelecomAddress", 553)]
public class IfcTelecomAddress : IfcAddress, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcTelecomAddress>, IIfcTelecomAddress, IIfcAddress, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType
{
	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> _telephoneNumbers;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> _facsimileNumbers;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _pagerNumber;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> _electronicMailAddresses;

	private Xbim.Ifc4x3.MeasureResource.IfcURIReference? _wWWHomePageURL;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcURIReference> _messagingIDs;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 6)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> TelephoneNumbers
	{
		get
		{
			if (_activated)
			{
				return _telephoneNumbers;
			}
			Activate();
			return _telephoneNumbers;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> FacsimileNumbers
	{
		get
		{
			if (_activated)
			{
				return _facsimileNumbers;
			}
			Activate();
			return _facsimileNumbers;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? PagerNumber
	{
		get
		{
			if (_activated)
			{
				return _pagerNumber;
			}
			Activate();
			return _pagerNumber;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_pagerNumber = v;
			}, _pagerNumber, value, "PagerNumber", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 9)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> ElectronicMailAddresses
	{
		get
		{
			if (_activated)
			{
				return _electronicMailAddresses;
			}
			Activate();
			return _electronicMailAddresses;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcURIReference? WWWHomePageURL
	{
		get
		{
			if (_activated)
			{
				return _wWWHomePageURL;
			}
			Activate();
			return _wWWHomePageURL;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcURIReference? v)
			{
				_wWWHomePageURL = v;
			}, _wWWHomePageURL, value, "WWWHomePageURL", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 11)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcURIReference> MessagingIDs
	{
		get
		{
			if (_activated)
			{
				return _messagingIDs;
			}
			Activate();
			return _messagingIDs;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTelecomAddress), 4)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcTelecomAddress.TelephoneNumbers => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(TelephoneNumbers, (Xbim.Ifc4x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc4x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcTelecomAddress), 5)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcTelecomAddress.FacsimileNumbers => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(FacsimileNumbers, (Xbim.Ifc4x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc4x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcTelecomAddress), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTelecomAddress.PagerNumber
	{
		get
		{
			if (!PagerNumber.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(PagerNumber.Value);
		}
		set
		{
			PagerNumber = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTelecomAddress), 7)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcTelecomAddress.ElectronicMailAddresses => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(ElectronicMailAddresses, (Xbim.Ifc4x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc4x3.MeasureResource.IfcLabel(t));

	[CrossSchemaAttribute(typeof(IIfcTelecomAddress), 8)]
	Xbim.Ifc4.ExternalReferenceResource.IfcURIReference? IIfcTelecomAddress.WWWHomePageURL
	{
		get
		{
			if (!WWWHomePageURL.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.ExternalReferenceResource.IfcURIReference(WWWHomePageURL.Value);
		}
		set
		{
			WWWHomePageURL = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcURIReference?(new Xbim.Ifc4x3.MeasureResource.IfcURIReference(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcURIReference?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTelecomAddress), 9)]
	IItemSet<Xbim.Ifc4.ExternalReferenceResource.IfcURIReference> IIfcTelecomAddress.MessagingIDs => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcURIReference, Xbim.Ifc4.ExternalReferenceResource.IfcURIReference>(MessagingIDs, (Xbim.Ifc4x3.MeasureResource.IfcURIReference s) => new Xbim.Ifc4.ExternalReferenceResource.IfcURIReference(s), (Xbim.Ifc4.ExternalReferenceResource.IfcURIReference t) => new Xbim.Ifc4x3.MeasureResource.IfcURIReference(t));

	internal IfcTelecomAddress(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_telephoneNumbers = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel>(this, 0, 4);
		_facsimileNumbers = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel>(this, 0, 5);
		_electronicMailAddresses = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel>(this, 0, 7);
		_messagingIDs = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcURIReference>(this, 0, 9);
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
			_telephoneNumbers.InternalAdd(value.StringVal);
			break;
		case 4:
			_facsimileNumbers.InternalAdd(value.StringVal);
			break;
		case 5:
			_pagerNumber = value.StringVal;
			break;
		case 6:
			_electronicMailAddresses.InternalAdd(value.StringVal);
			break;
		case 7:
			_wWWHomePageURL = value.StringVal;
			break;
		case 8:
			_messagingIDs.InternalAdd(value.StringVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTelecomAddress other)
	{
		return this == other;
	}
}
