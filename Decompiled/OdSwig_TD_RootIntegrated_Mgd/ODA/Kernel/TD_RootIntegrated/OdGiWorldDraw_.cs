using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWorldDraw_ : OdGiWorldDraw
{
	private object locker = new object();

	private HandleRef swigCPtr;

	private OdGiWorldGeometry pWGeom;

	private OdGiWorldGeometry pOdGiGeometry1;

	private OdGiWorldGeometry WGeom
	{
		get
		{
			if (pWGeom == null)
			{
				pWGeom = new OdGiWorldGeometry_Internal(OdGiWorldDraw__OdGiWorldGeometry_Upcast(swigCPtr.Handle), cMemoryOwn: false);
			}
			return pWGeom;
		}
	}

	private OdGiWorldGeometry Geom
	{
		get
		{
			if (pOdGiGeometry1 == null)
			{
				pOdGiGeometry1 = new OdGiWorldGeometry_Internal(OdGiWorldDraw__OdGiGeometry_Upcast(swigCPtr.Handle), cMemoryOwn: false);
			}
			return pOdGiGeometry1;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiWorldDraw_(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw__SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiWorldDraw_ obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiWorldDraw_(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void setExtents(OdGePoint3d newExtents)
	{
		WGeom.setExtents(newExtents);
	}

	public virtual void startAttributesSegment()
	{
		WGeom.startAttributesSegment();
	}

	public virtual OdGeMatrix3d getModelToWorldTransform()
	{
		return Geom.getModelToWorldTransform();
	}

	public virtual OdGeMatrix3d getWorldToModelTransform()
	{
		return Geom.getWorldToModelTransform();
	}

	public virtual void pushModelTransform(OdGeVector3d normal)
	{
		Geom.pushModelTransform(normal);
	}

	public virtual void pushModelTransform(OdGeMatrix3d xfm)
	{
		Geom.pushModelTransform(xfm);
	}

	public virtual void popModelTransform()
	{
		Geom.popModelTransform();
	}

	public virtual void circle(OdGePoint3d center, double radius, OdGeVector3d normal)
	{
		Geom.circle(center, radius, normal);
	}

	public virtual void circle(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint)
	{
		Geom.circle(firstPoint, secondPoint, thirdPoint);
	}

	public virtual void circularArc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType)
	{
		Geom.circularArc(center, radius, normal, startVector, sweepAngle, arcType);
	}

	public virtual void circularArc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType)
	{
		Geom.circularArc(firstPoint, secondPoint, thirdPoint, arcType);
	}

	public virtual void polyline(OdGePoint3d[] numVertices, OdGeVector3d pNormal, IntPtr baseSubEntMarker)
	{
		Geom.polyline(numVertices, pNormal, baseSubEntMarker);
	}

	public virtual void polygon(OdGePoint3d[] numVertices)
	{
		Geom.polygon(numVertices);
	}

	public virtual void polygon(OdGePoint3d[] numVertices, OdGeVector3d pNormal)
	{
		Geom.polygon(numVertices, pNormal);
	}

	public virtual void pline(OdGiPolyline polyline, uint fromIndex, uint numSegs)
	{
		Geom.pline(polyline, fromIndex, numSegs);
	}

	public virtual void mesh(MeshData numRows)
	{
		Geom.mesh(numRows);
	}

	public virtual void shell(ShellData numVertices)
	{
		Geom.shell(numVertices);
	}

	public virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, string msg)
	{
		Geom.text(position, normal, direction, height, width, oblique, msg);
	}

	public virtual void text(OdGePoint3d position, OdGeVector3d normal, OdGeVector3d direction, string msg, bool raw, OdGiTextStyle pTextStyle)
	{
		Geom.text(position, normal, direction, msg, raw, pTextStyle);
	}

	public virtual void xline(OdGePoint3d firstPoint, OdGePoint3d secondPoint)
	{
		Geom.xline(firstPoint, secondPoint);
	}

	public virtual void ray(OdGePoint3d basePoint, OdGePoint3d throughPoint)
	{
		Geom.ray(basePoint, throughPoint);
	}

	public virtual void nurbs(OdGeNurbCurve3d nurbsCurve)
	{
		Geom.nurbs(nurbsCurve);
	}

	public virtual void draw(OdGiDrawable pDrawable)
	{
		Geom.draw(pDrawable);
	}

	public virtual void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		Geom.pushClipBoundary(pBoundary);
	}

	public virtual void popClipBoundary()
	{
		Geom.popClipBoundary();
	}

	public virtual void worldLine(OdGePoint3d startPoint, OdGePoint3d endPoint)
	{
		Geom.WorldLine(startPoint, endPoint);
	}

	public new virtual OdGiPathNode currentGiPath()
	{
		return Geom.currentGiPath();
	}

	public new virtual OdGiWorldGeometry geometry()
	{
		OdGiWorldGeometry rXObject = Helpers.GetRXObject<OdGiWorldGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw__geometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiPathNode getCurrentGiPath()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw__getCurrentGiPath(swigCPtr);
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw__getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static IntPtr OdGiWorldDraw__OdGiWorldGeometry_Upcast(IntPtr ptr)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw__OdGiWorldDraw__OdGiWorldGeometry_Upcast(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static IntPtr OdGiWorldDraw__OdGiGeometry_Upcast(IntPtr ptr)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWorldDraw__OdGiWorldDraw__OdGiGeometry_Upcast(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
