using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Common.Step21;
using Xbim.Common.XbimExtensions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IfcStoreGeometryExtensions
{
	public const int WexBimId = 94132117;

	public static void SaveAsWexBim(this IModel model, BinaryWriter binaryStream, IEnumerable<IIfcProduct> products = null, IVector3D translation = null, double? scale = null, XbimQuaternion? rotation = null)
	{
		double num = scale ?? 1.0;
		if (num == 0.0)
		{
			throw new ArgumentException("Scale cannot be zero", "scale");
		}
		XbimVector3D xbimVector3D = new XbimVector3D(num);
		XbimQuaternion valueOrDefault = rotation.GetValueOrDefault();
		IVector3D translation2 = (IVector3D)(translation ?? ((object)XbimVector3D.Zero));
		XbimMatrix3D transformation = XbimMatrix3D.FromScaleRotationTranslation(xbimVector3D, valueOrDefault, translation2);
		products = products ?? model.Instances.OfType<IIfcProduct>();
		if (model.GeometryStore == null)
		{
			throw new XbimException("Geometry store has not been initialised");
		}
		XbimColourMap xbimColourMap = new XbimColourMap();
		using IGeometryStoreReader geometryStoreReader = model.GeometryStore.BeginRead();
		IEnumerable<XbimShapeGeometry> shapeGeometries = geometryStoreReader.ShapeGeometries;
		ISet<int> styleIds = geometryStoreReader.StyleIds;
		List<XbimRegion> list = geometryStoreReader.ContextRegions.SelectMany((XbimRegionCollection r) => r).ToList();
		List<int> list2 = geometryStoreReader.ShapeInstances.Select((XbimShapeInstance i) => -i.IfcTypeId).Distinct().Concat(styleIds)
			.ToList();
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int count = list2.Count;
		binaryStream.Write(94132117);
		binaryStream.Write((byte)2);
		int offset = (int)binaryStream.Seek(0, SeekOrigin.Current);
		binaryStream.Write(0);
		binaryStream.Write(0);
		binaryStream.Write(0);
		binaryStream.Write(0);
		binaryStream.Write(0);
		binaryStream.Write(count);
		binaryStream.Write(Convert.ToSingle(model.ModelFactors.OneMetre / num));
		binaryStream.Write(Convert.ToInt16(list.Count));
		XbimMatrix3D identity = XbimMatrix3D.Identity;
		identity = ApplyTransformation(identity, transformation);
		foreach (XbimRegion item in list)
		{
			binaryStream.Write(item.Population);
			XbimRect3D xbimRect3D = item.ToXbimRect3D();
			XbimPoint3D xbimPoint3D = identity.Transform(item.Centre);
			binaryStream.Write((float)xbimPoint3D.X);
			binaryStream.Write((float)xbimPoint3D.Y);
			binaryStream.Write((float)xbimPoint3D.Z);
			binaryStream.Write(xbimRect3D.ToFloatArray());
		}
		foreach (int item2 in list2)
		{
			XbimColour xbimColour;
			if (item2 > 0)
			{
				xbimColour = XbimTexture.Create((IIfcSurfaceStyle)model.Instances[item2]).ColourMap.FirstOrDefault();
			}
			else
			{
				Type type = model.Metadata.GetType((short)Math.Abs(item2));
				xbimColour = xbimColourMap[type.Name];
			}
			if (xbimColour == null)
			{
				xbimColour = XbimColour.DefaultColour;
			}
			binaryStream.Write(item2);
			binaryStream.Write(xbimColour.Red);
			binaryStream.Write(xbimColour.Green);
			binaryStream.Write(xbimColour.Blue);
			binaryStream.Write(xbimColour.Alpha);
		}
		HashSet<int> prodIds = new HashSet<int>();
		foreach (IIfcProduct product in products)
		{
			if (product is IIfcFeatureElement)
			{
				continue;
			}
			prodIds.Add(product.EntityLabel);
			XbimRect3D xbimRect3D2 = XbimRect3D.Empty;
			foreach (XbimShapeInstance item3 in geometryStoreReader.ShapeInstancesOfEntity(product))
			{
				XbimRect3D xbimRect3D3 = XbimRect3D.TransformBy(m: ApplyTransformation(item3.Transformation, transformation), rect3d: item3.BoundingBox);
				if (xbimRect3D2.IsEmpty)
				{
					xbimRect3D2 = xbimRect3D3;
				}
				else
				{
					xbimRect3D2.Union(xbimRect3D3);
				}
			}
			if (!xbimRect3D2.IsEmpty)
			{
				binaryStream.Write(product.EntityLabel);
				binaryStream.Write((ushort)model.Metadata.ExpressTypeId(product));
				binaryStream.Write(xbimRect3D2.ToFloatArray());
				num6++;
			}
		}
		short[] toIgnore = new short[4];
		toIgnore[0] = model.Metadata.ExpressTypeId("IFCOPENINGELEMENT");
		toIgnore[1] = model.Metadata.ExpressTypeId("IFCPROJECTIONELEMENT");
		if (model.SchemaVersion == XbimSchemaVersion.Ifc4 || model.SchemaVersion == XbimSchemaVersion.Ifc4x1 || model.SchemaVersion == XbimSchemaVersion.Ifc4x3)
		{
			toIgnore[2] = model.Metadata.ExpressTypeId("IFCVOIDINGFEATURE");
			toIgnore[3] = model.Metadata.ExpressTypeId("IFCSURFACEFEATURE");
		}
		foreach (XbimShapeGeometry item4 in shapeGeometries)
		{
			if (item4.ShapeData.Length <= 0)
			{
				continue;
			}
			List<XbimShapeInstance> list3 = (from si in geometryStoreReader.ShapeInstancesOfGeometry(item4.ShapeLabel)
				where !Enumerable.Contains(toIgnore, si.IfcTypeId) && si.RepresentationType == XbimGeometryRepresentationType.OpeningsAndAdditionsIncluded && prodIds.Contains(si.IfcProductLabel)
				select si).ToList();
			if (!list3.Any())
			{
				continue;
			}
			num2++;
			binaryStream.Write(list3.Count);
			if (list3.Count > 1)
			{
				foreach (XbimShapeInstance item5 in list3)
				{
					binaryStream.Write(((IXbimShapeInstanceData)item5).IfcProductLabel);
					binaryStream.Write((ushort)((IXbimShapeInstanceData)item5).IfcTypeId);
					binaryStream.Write((uint)((IXbimShapeInstanceData)item5).InstanceLabel);
					binaryStream.Write((((IXbimShapeInstanceData)item5).StyleLabel > 0) ? ((IXbimShapeInstanceData)item5).StyleLabel : (((IXbimShapeInstanceData)item5).IfcTypeId * -1));
					binaryStream.Write(ApplyTransformation(XbimMatrix3D.FromArray(((IXbimShapeInstanceData)item5).Transformation), transformation).ToArray());
					num4 += XbimShapeTriangulation.TriangleCount(((IXbimShapeGeometryData)item4).ShapeData);
					num5++;
				}
				num3 += XbimShapeTriangulation.VerticesCount(((IXbimShapeGeometryData)item4).ShapeData);
				new BinaryReader(new MemoryStream(((IXbimShapeGeometryData)item4).ShapeData)).ReadShapeTriangulation().Write(binaryStream);
			}
			else
			{
				XbimShapeInstance xbimShapeInstance = list3[0];
				binaryStream.Write(xbimShapeInstance.IfcProductLabel);
				binaryStream.Write((ushort)xbimShapeInstance.IfcTypeId);
				binaryStream.Write(xbimShapeInstance.InstanceLabel);
				binaryStream.Write((xbimShapeInstance.StyleLabel > 0) ? xbimShapeInstance.StyleLabel : (xbimShapeInstance.IfcTypeId * -1));
				XbimShapeTriangulation xbimShapeTriangulation = new BinaryReader(new MemoryStream(((IXbimShapeGeometryData)item4).ShapeData)).ReadShapeTriangulation();
				XbimMatrix3D matrix3D = ApplyTransformation(xbimShapeInstance.Transformation, transformation);
				xbimShapeTriangulation.Transform(matrix3D).Write(binaryStream);
				num4 += XbimShapeTriangulation.TriangleCount(((IXbimShapeGeometryData)item4).ShapeData);
				num3 += XbimShapeTriangulation.VerticesCount(((IXbimShapeGeometryData)item4).ShapeData);
			}
		}
		binaryStream.Seek(offset, SeekOrigin.Begin);
		binaryStream.Write(num2);
		binaryStream.Write(num3);
		binaryStream.Write(num4);
		binaryStream.Write(num5);
		binaryStream.Write(num6);
		binaryStream.Seek(0, SeekOrigin.End);
	}

	private static XbimMatrix3D ApplyTransformation(XbimMatrix3D matrix, XbimMatrix3D transformation)
	{
		if (transformation.IsIdentity)
		{
			return matrix;
		}
		return XbimMatrix3D.Multiply(matrix, transformation);
	}
}
