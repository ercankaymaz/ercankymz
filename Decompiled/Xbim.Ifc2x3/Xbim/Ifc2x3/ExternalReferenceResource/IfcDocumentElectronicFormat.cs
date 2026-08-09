using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcDocumentElectronicFormat", 599)]
public class IfcDocumentElectronicFormat : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcDocumentElectronicFormat>, IExpressValidatable
{
	public enum IfcDocumentElectronicFormatClause
	{
		WR1
	}

	private IfcLabel? _fileExtension;

	private IfcLabel? _mimeContentType;

	private IfcLabel? _mimeSubtype;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? FileExtension
	{
		get
		{
			if (_activated)
			{
				return _fileExtension;
			}
			Activate();
			return _fileExtension;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_fileExtension = v;
			}, _fileExtension, value, "FileExtension", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? MimeContentType
	{
		get
		{
			if (_activated)
			{
				return _mimeContentType;
			}
			Activate();
			return _mimeContentType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_mimeContentType = v;
			}, _mimeContentType, value, "MimeContentType", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? MimeSubtype
	{
		get
		{
			if (_activated)
			{
				return _mimeSubtype;
			}
			Activate();
			return _mimeSubtype;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_mimeSubtype = v;
			}, _mimeSubtype, value, "MimeSubtype", 3);
		}
	}

	internal IfcDocumentElectronicFormat(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_fileExtension = value.StringVal;
			break;
		case 1:
			_mimeContentType = value.StringVal;
			break;
		case 2:
			_mimeSubtype = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDocumentElectronicFormat other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDocumentElectronicFormatClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDocumentElectronicFormatClause.WR1)
			{
				result = Functions.EXISTS(FileExtension) || Functions.EXISTS(MimeContentType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDocumentElectronicFormat>()?.LogError($"Exception thrown evaluating where-clause 'IfcDocumentElectronicFormat.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDocumentElectronicFormatClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDocumentElectronicFormat.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
