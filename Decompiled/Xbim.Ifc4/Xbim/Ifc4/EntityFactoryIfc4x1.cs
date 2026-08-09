using System;
using System.Collections.Generic;
using System.Reflection;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc4;

public sealed class EntityFactoryIfc4x1 : IEntityFactory
{
	private static readonly Assembly _assembly;

	private static readonly IEnumerable<IEntityFactory> _references;

	private static readonly List<string> _schemasIds;

	public IEnumerable<string> SchemasIds => _schemasIds;

	public XbimSchemaVersion SchemaVersion => XbimSchemaVersion.Ifc4x1;

	static EntityFactoryIfc4x1()
	{
		_schemasIds = new List<string> { "IFC4X1" };
		_assembly = typeof(EntityFactoryIfc4x1).Assembly;
		_references = new IEntityFactory[1]
		{
			new EntityFactoryIfc4()
		};
	}

	public T New<T>(IModel model, int entityLabel, bool activated) where T : IInstantiableEntity
	{
		return (T)New(model, typeof(T), entityLabel, activated);
	}

	public T New<T>(IModel model, Action<T> init, int entityLabel, bool activated) where T : IInstantiableEntity
	{
		T val = New<T>(model, entityLabel, activated);
		init?.Invoke(val);
		return val;
	}

	public IInstantiableEntity New(IModel model, Type t, int entityLabel, bool activated)
	{
		if (t.Assembly != _assembly)
		{
			throw new Exception("This factory only creates types from its assembly");
		}
		return New(model, t.Name, entityLabel, activated);
	}

	public IInstantiableEntity New(IModel model, string typeName, int entityLabel, bool activated)
	{
		if (model == null || string.IsNullOrWhiteSpace(typeName) || entityLabel < 0)
		{
			throw new ArgumentNullException();
		}
		foreach (IEntityFactory reference in _references)
		{
			IInstantiableEntity instantiableEntity = reference.New(model, typeName, entityLabel, activated);
			if (instantiableEntity != null)
			{
				return instantiableEntity;
			}
		}
		return typeName.ToUpperInvariant() switch
		{
			"IFCALIGNMENT" => new IfcAlignment(model, entityLabel, activated), 
			"IFCALIGNMENT2DHORIZONTAL" => new IfcAlignment2DHorizontal(model, entityLabel, activated), 
			"IFCALIGNMENT2DHORIZONTALSEGMENT" => new IfcAlignment2DHorizontalSegment(model, entityLabel, activated), 
			"IFCALIGNMENT2DVERSEGCIRCULARARC" => new IfcAlignment2DVerSegCircularArc(model, entityLabel, activated), 
			"IFCALIGNMENT2DVERSEGLINE" => new IfcAlignment2DVerSegLine(model, entityLabel, activated), 
			"IFCALIGNMENT2DVERSEGPARABOLICARC" => new IfcAlignment2DVerSegParabolicArc(model, entityLabel, activated), 
			"IFCALIGNMENT2DVERTICAL" => new IfcAlignment2DVertical(model, entityLabel, activated), 
			"IFCALIGNMENTCURVE" => new IfcAlignmentCurve(model, entityLabel, activated), 
			"IFCCIRCULARARCSEGMENT2D" => new IfcCircularArcSegment2D(model, entityLabel, activated), 
			"IFCDISTANCEEXPRESSION" => new IfcDistanceExpression(model, entityLabel, activated), 
			"IFCLINESEGMENT2D" => new IfcLineSegment2D(model, entityLabel, activated), 
			"IFCLINEARPLACEMENT" => new IfcLinearPlacement(model, entityLabel, activated), 
			"IFCOFFSETCURVEBYDISTANCES" => new IfcOffsetCurveByDistances(model, entityLabel, activated), 
			"IFCORIENTATIONEXPRESSION" => new IfcOrientationExpression(model, entityLabel, activated), 
			"IFCREFERENT" => new IfcReferent(model, entityLabel, activated), 
			"IFCSECTIONEDSOLIDHORIZONTAL" => new IfcSectionedSolidHorizontal(model, entityLabel, activated), 
			"IFCTRANSITIONCURVESEGMENT2D" => new IfcTransitionCurveSegment2D(model, entityLabel, activated), 
			"IFCTRIANGULATEDIRREGULARNETWORK" => new IfcTriangulatedIrregularNetwork(model, entityLabel, activated), 
			_ => null, 
		};
	}

	public IInstantiableEntity New(IModel model, int typeId, int entityLabel, bool activated)
	{
		if (model == null)
		{
			throw new ArgumentNullException();
		}
		foreach (IEntityFactory reference in _references)
		{
			IInstantiableEntity instantiableEntity = reference.New(model, typeId, entityLabel, activated);
			if (instantiableEntity != null)
			{
				return instantiableEntity;
			}
		}
		return typeId switch
		{
			1330 => new IfcAlignment(model, entityLabel, activated), 
			1332 => new IfcAlignment2DHorizontal(model, entityLabel, activated), 
			1333 => new IfcAlignment2DHorizontalSegment(model, entityLabel, activated), 
			1335 => new IfcAlignment2DVerSegCircularArc(model, entityLabel, activated), 
			1336 => new IfcAlignment2DVerSegLine(model, entityLabel, activated), 
			1337 => new IfcAlignment2DVerSegParabolicArc(model, entityLabel, activated), 
			1338 => new IfcAlignment2DVertical(model, entityLabel, activated), 
			1347 => new IfcAlignmentCurve(model, entityLabel, activated), 
			1340 => new IfcCircularArcSegment2D(model, entityLabel, activated), 
			1348 => new IfcDistanceExpression(model, entityLabel, activated), 
			1343 => new IfcLineSegment2D(model, entityLabel, activated), 
			1349 => new IfcLinearPlacement(model, entityLabel, activated), 
			1351 => new IfcOffsetCurveByDistances(model, entityLabel, activated), 
			1352 => new IfcOrientationExpression(model, entityLabel, activated), 
			1353 => new IfcReferent(model, entityLabel, activated), 
			1355 => new IfcSectionedSolidHorizontal(model, entityLabel, activated), 
			1356 => new IfcTransitionCurveSegment2D(model, entityLabel, activated), 
			1357 => new IfcTriangulatedIrregularNetwork(model, entityLabel, activated), 
			_ => null, 
		};
	}

	public IExpressValueType New(string typeName)
	{
		if (typeName == null)
		{
			throw new ArgumentNullException();
		}
		foreach (IEntityFactory reference in _references)
		{
			IExpressValueType expressValueType = reference.New(typeName);
			if (expressValueType != null)
			{
				return expressValueType;
			}
		}
		typeName.ToUpperInvariant();
		return null;
	}
}
