using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

[Serializable]
internal abstract class GEntity
{
	public object EntityData;

	public abstract GEntitySurrogate ConvertToSurrogate();

	internal static List<Entity> CreateEntitiesFromPrimitives(IEnumerable<GEntity> primitives)
	{
		if (primitives == null)
		{
			return null;
		}
		List<Entity> list = new List<Entity>();
		foreach (GEntity primitive in primitives)
		{
			list.Add(CreateEntityFromPrimitive(primitive));
		}
		return list;
	}

	internal static Entity CreateEntityFromPrimitive(GEntity primitive)
	{
		if (primitive is GPoint gPoint)
		{
			return new Point(gPoint.Position);
		}
		if (primitive is GLine _0023_003DzQwa1qM0_003D)
		{
			return new Line(_0023_003DzQwa1qM0_003D);
		}
		if (primitive is GArc _0023_003DzQwa1qM0_003D2)
		{
			return new Arc(_0023_003DzQwa1qM0_003D2);
		}
		if (primitive is GCircle _0023_003DzQwa1qM0_003D3)
		{
			return new Circle(_0023_003DzQwa1qM0_003D3);
		}
		if (primitive is GEllipticalArc _0023_003DzQwa1qM0_003D4)
		{
			return new EllipticalArc(_0023_003DzQwa1qM0_003D4);
		}
		if (primitive is GEllipse _0023_003DzQwa1qM0_003D5)
		{
			return new Ellipse(_0023_003DzQwa1qM0_003D5);
		}
		if (primitive is GRegion _0023_003DzQwa1qM0_003D6)
		{
			return new Region(_0023_003DzQwa1qM0_003D6);
		}
		if (primitive is GPlanarEntity _0023_003DzQwa1qM0_003D7)
		{
			return new PlanarEntity(_0023_003DzQwa1qM0_003D7);
		}
		if (primitive is GLinearPath _0023_003DzQwa1qM0_003D8)
		{
			return new LinearPath(_0023_003DzQwa1qM0_003D8);
		}
		if (primitive is GCompositeCurve _0023_003DzQwa1qM0_003D9)
		{
			return new CompositeCurve(_0023_003DzQwa1qM0_003D9);
		}
		if (primitive is GSolid.Portion _0023_003DzQwa1qM0_003D10)
		{
			return new Solid.Portion(_0023_003DzQwa1qM0_003D10);
		}
		if (primitive is GTrimCurve _0023_003DzQwa1qM0_003D11)
		{
			return new TrimCurve(_0023_003DzQwa1qM0_003D11);
		}
		if (primitive is GCurve _0023_003DzQwa1qM0_003D12)
		{
			return new Curve(_0023_003DzQwa1qM0_003D12);
		}
		return null;
	}
}
