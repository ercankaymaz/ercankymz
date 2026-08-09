using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcDirection", 344)]
public class IfcDirection : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcDirection, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGridPlacementDirectionSelect, IIfcGridPlacementDirectionSelect, IfcVectorOrDirection, IIfcVectorOrDirection, IEquatable<IfcDirection>, IExpressValidatable
{
	public enum IfcDirectionClause
	{
		MagnitudeGreaterZero
	}

	private readonly ItemSet<IfcReal> _directionRatios;

	IItemSet<IfcReal> IIfcDirection.DirectionRatios => DirectionRatios;

	IfcDimensionCount IIfcDirection.Dim => Dim;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 3 }, 3)]
	public IItemSet<IfcReal> DirectionRatios
	{
		get
		{
			if (_activated)
			{
				return _directionRatios;
			}
			Activate();
			return _directionRatios;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => DirectionRatios.Count;

	public double X
	{
		get
		{
			if (DirectionRatios.Count != 0)
			{
				return DirectionRatios[0];
			}
			return double.NaN;
		}
		set
		{
			if (DirectionRatios.Count == 0)
			{
				DirectionRatios.Add(value);
			}
			else
			{
				DirectionRatios[0] = value;
			}
		}
	}

	public double Y
	{
		get
		{
			if (DirectionRatios.Count >= 2)
			{
				return DirectionRatios[1];
			}
			return double.NaN;
		}
		set
		{
			if (DirectionRatios.Count < 2)
			{
				if (DirectionRatios.Count == 0)
				{
					DirectionRatios.Add(double.NaN);
				}
				DirectionRatios.Add(value);
			}
			else
			{
				DirectionRatios[1] = value;
			}
		}
	}

	public double Z
	{
		get
		{
			if (DirectionRatios.Count >= 3)
			{
				return DirectionRatios[2];
			}
			return double.NaN;
		}
		set
		{
			if (DirectionRatios.Count < 3)
			{
				if (DirectionRatios.Count == 0)
				{
					DirectionRatios.Add(double.NaN);
				}
				if (DirectionRatios.Count == 1)
				{
					DirectionRatios.Add(double.NaN);
				}
				DirectionRatios.Add(value);
			}
			else
			{
				DirectionRatios[2] = value;
			}
		}
	}

	internal IfcDirection(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_directionRatios = new ItemSet<IfcReal>(this, 3, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_directionRatios.InternalAdd(value.RealVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcDirection other)
	{
		return this == other;
	}

	public static implicit operator IfcDirection(XbimVector3D vector)
	{
		IfcDirection ifcDirection = new IfcDirection(null, -1, activated: true);
		ifcDirection._directionRatios.InternalAdd(vector.X);
		ifcDirection._directionRatios.InternalAdd(vector.Y);
		if (!double.IsNaN(vector.Z))
		{
			ifcDirection._directionRatios.InternalAdd(vector.Z);
		}
		return ifcDirection;
	}

	public XbimVector3D XbimVector3D()
	{
		return new XbimVector3D(X, Y, double.IsNaN(Z) ? 0.0 : Z);
	}

	public XbimVector3D Normalise()
	{
		if (Dim == 3L)
		{
			XbimVector3D result = new XbimVector3D(X, Y, Z);
			result.Normalized();
			return result;
		}
		double num = X;
		double num2 = Y;
		double num3 = Z;
		if (double.IsNaN(num))
		{
			num = 0.0;
		}
		if (double.IsNaN(num2))
		{
			num2 = 0.0;
		}
		if (double.IsNaN(num3))
		{
			num3 = 0.0;
		}
		XbimVector3D result2 = new XbimVector3D(num, num2, num3);
		result2.Normalized();
		return result2;
	}

	public void SetXY(double x, double y)
	{
		DirectionRatios.Clear();
		DirectionRatios.Add(x);
		DirectionRatios.Add(y);
	}

	public void SetXYZ(double x, double y, double z)
	{
		DirectionRatios.Clear();
		DirectionRatios.Add(x);
		DirectionRatios.Add(y);
		DirectionRatios.Add(z);
	}

	public bool ValidateClause(IfcDirectionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDirectionClause.MagnitudeGreaterZero)
			{
				result = Functions.SIZEOF(Enumerable.Where(DirectionRatios, (IfcReal Tmp) => Tmp != 0.0)) > 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDirection>()?.LogError($"Exception thrown evaluating where-clause 'IfcDirection.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDirectionClause.MagnitudeGreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDirection.MagnitudeGreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
