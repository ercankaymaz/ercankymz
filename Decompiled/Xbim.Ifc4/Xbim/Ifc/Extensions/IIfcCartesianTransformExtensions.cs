using System;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Extensions;

public static class IIfcCartesianTransformExtensions
{
	public static XbimMatrix3D ToMatrix3D(this IIfcCartesianTransformationOperator ct)
	{
		if (ct is IIfcCartesianTransformationOperator3DnonUniform)
		{
			return ((IIfcCartesianTransformationOperator3DnonUniform)ct).ToMatrix3D();
		}
		if (ct is IIfcCartesianTransformationOperator3D)
		{
			return ((IIfcCartesianTransformationOperator3D)ct).ToMatrix3D();
		}
		throw new ArgumentException("ToMatrix3D", "ct");
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcCartesianTransformationOperator3D ct3D)
	{
		return ConvertCartesianTranformOperator3D(ct3D);
	}

	private static XbimMatrix3D ConvertCartesianTranformOperator3D(IIfcCartesianTransformationOperator3D ct3D)
	{
		XbimMatrix3D result = ConvertCartesianTransform3D(ct3D);
		result.Scale(ct3D.Scl);
		return result;
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcCartesianTransformationOperator3DnonUniform ct3D)
	{
		return ConvertCartesianTransformationOperator3DnonUniform(ct3D);
	}

	private static XbimMatrix3D ConvertCartesianTransformationOperator3DnonUniform(IIfcCartesianTransformationOperator3DnonUniform ct3D)
	{
		XbimVector3D xbimVector3D;
		if (ct3D.Axis3 != null)
		{
			IIfcDirection axis = ct3D.Axis3;
			xbimVector3D = new XbimVector3D(axis.X, axis.Y, axis.Z).Normalized();
		}
		else
		{
			xbimVector3D = new XbimVector3D(0.0, 0.0, 1.0);
		}
		XbimVector3D xbimVector3D2;
		if (ct3D.Axis1 != null)
		{
			IIfcDirection axis2 = ct3D.Axis1;
			xbimVector3D2 = new XbimVector3D(axis2.X, axis2.Y, axis2.Z).Normalized();
		}
		else
		{
			XbimVector3D xbimVector3D3 = new XbimVector3D(1.0, 0.0, 0.0);
			xbimVector3D2 = ((xbimVector3D != xbimVector3D3) ? xbimVector3D3 : new XbimVector3D(0.0, 1.0, 0.0));
		}
		XbimVector3D vector = XbimVector3D.Multiply(XbimVector3D.DotProduct(xbimVector3D2, xbimVector3D), xbimVector3D);
		XbimVector3D xbimVector3D4 = XbimVector3D.Subtract(xbimVector3D2, vector).Normalized();
		XbimVector3D xbimVector3D5;
		if (ct3D.Axis2 != null)
		{
			IIfcDirection axis3 = ct3D.Axis2;
			xbimVector3D5 = new XbimVector3D(axis3.X, axis3.Y, axis3.Z).Normalized();
		}
		else
		{
			xbimVector3D5 = new XbimVector3D(0.0, 1.0, 0.0);
		}
		XbimVector3D vector2 = XbimVector3D.Multiply(XbimVector3D.DotProduct(xbimVector3D5, xbimVector3D), xbimVector3D);
		XbimVector3D vector3 = XbimVector3D.Subtract(xbimVector3D5, vector2);
		vector2 = XbimVector3D.Multiply(XbimVector3D.DotProduct(xbimVector3D5, xbimVector3D4), xbimVector3D4);
		vector3 = XbimVector3D.Subtract(vector3, vector2).Normalized();
		xbimVector3D5 = vector3;
		xbimVector3D2 = xbimVector3D4;
		XbimPoint3D xbimPoint3D = new XbimPoint3D(ct3D.LocalOrigin.X, ct3D.LocalOrigin.Y, ct3D.LocalOrigin.Z);
		XbimMatrix3D result = new XbimMatrix3D(xbimVector3D2.X, xbimVector3D2.Y, xbimVector3D2.Z, 0.0, xbimVector3D5.X, xbimVector3D5.Y, xbimVector3D5.Z, 0.0, xbimVector3D.X, xbimVector3D.Y, xbimVector3D.Z, 0.0, xbimPoint3D.X, xbimPoint3D.Y, xbimPoint3D.Z, 1.0);
		result.Scale(new XbimVector3D(ct3D.Scl, ct3D.Scl2, ct3D.Scl3));
		return result;
	}

	private static XbimMatrix3D ConvertCartesianTransform3D(IIfcCartesianTransformationOperator3D ct3D)
	{
		XbimVector3D xbimVector3D;
		if (ct3D.Axis3 != null)
		{
			IIfcDirection axis = ct3D.Axis3;
			xbimVector3D = new XbimVector3D(axis.X, axis.Y, axis.Z).Normalized();
		}
		else
		{
			xbimVector3D = new XbimVector3D(0.0, 0.0, 1.0);
		}
		XbimVector3D xbimVector3D2;
		if (ct3D.Axis1 != null)
		{
			IIfcDirection axis2 = ct3D.Axis1;
			xbimVector3D2 = new XbimVector3D(axis2.X, axis2.Y, axis2.Z).Normalized();
		}
		else
		{
			XbimVector3D xbimVector3D3 = new XbimVector3D(1.0, 0.0, 0.0);
			xbimVector3D2 = ((xbimVector3D != xbimVector3D3) ? xbimVector3D3 : new XbimVector3D(0.0, 1.0, 0.0));
		}
		XbimVector3D vector = XbimVector3D.Multiply(XbimVector3D.DotProduct(xbimVector3D2, xbimVector3D), xbimVector3D);
		XbimVector3D xbimVector3D4 = XbimVector3D.Subtract(xbimVector3D2, vector).Normalized();
		XbimVector3D xbimVector3D5;
		if (ct3D.Axis2 != null)
		{
			IIfcDirection axis3 = ct3D.Axis2;
			xbimVector3D5 = new XbimVector3D(axis3.X, axis3.Y, axis3.Z).Normalized();
		}
		else
		{
			xbimVector3D5 = new XbimVector3D(0.0, 1.0, 0.0);
		}
		XbimVector3D vector2 = XbimVector3D.Multiply(XbimVector3D.DotProduct(xbimVector3D5, xbimVector3D), xbimVector3D);
		XbimVector3D vector3 = XbimVector3D.Subtract(xbimVector3D5, vector2);
		vector2 = XbimVector3D.Multiply(XbimVector3D.DotProduct(xbimVector3D5, xbimVector3D4), xbimVector3D4);
		vector3 = XbimVector3D.Subtract(vector3, vector2).Normalized();
		xbimVector3D5 = vector3;
		xbimVector3D2 = xbimVector3D4;
		XbimPoint3D xbimPoint3D = new XbimPoint3D(ct3D.LocalOrigin.X, ct3D.LocalOrigin.Y, ct3D.LocalOrigin.Z);
		return new XbimMatrix3D(xbimVector3D2.X, xbimVector3D2.Y, xbimVector3D2.Z, 0.0, xbimVector3D5.X, xbimVector3D5.Y, xbimVector3D5.Z, 0.0, xbimVector3D.X, xbimVector3D.Y, xbimVector3D.Z, 0.0, xbimPoint3D.X, xbimPoint3D.Y, xbimPoint3D.Z, 1.0);
	}
}
