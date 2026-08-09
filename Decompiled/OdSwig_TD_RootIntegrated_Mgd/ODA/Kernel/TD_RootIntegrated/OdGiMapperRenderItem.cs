using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMapperRenderItem : OdGiMapperItem
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMapperRenderItem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMapperRenderItem obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMapperRenderItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMapperRenderItem cast(OdRxObject pObj)
	{
		OdGiMapperRenderItem rXObject = Helpers.GetRXObject<OdGiMapperRenderItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiMapperRenderItem createObject()
	{
		OdGiMapperRenderItem rXObject = Helpers.GetRXObject<OdGiMapperRenderItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void setDiffuseMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setDiffuseMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDiffuseMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setDiffuseMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDiffuseMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setDiffuseMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDiffuseMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setDiffuseMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGiMapperItemEntry diffuseMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_diffuseMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setSpecularMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setSpecularMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSpecularMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setSpecularMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSpecularMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setSpecularMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSpecularMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setSpecularMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry specularMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_specularMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setReflectionMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setReflectionMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflectionMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setReflectionMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflectionMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setReflectionMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setReflectionMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setReflectionMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry reflectionMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_reflectionMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setOpacityMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setOpacityMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOpacityMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setOpacityMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOpacityMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setOpacityMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOpacityMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setOpacityMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry opacityMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_opacityMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setBumpMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setBumpMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBumpMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setBumpMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBumpMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setBumpMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBumpMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setBumpMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry bumpMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_bumpMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRefractionMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRefractionMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRefractionMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRefractionMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRefractionMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRefractionMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRefractionMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRefractionMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry refractionMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_refractionMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setNormalMapMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setNormalMapMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNormalMapMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setNormalMapMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNormalMapMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setNormalMapMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNormalMapMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setNormalMapMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry normalMapMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_normalMapMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setEmissionMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setEmissionMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEmissionMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setEmissionMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEmissionMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setEmissionMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEmissionMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setEmissionMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry emissionMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_emissionMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRoughnessMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRoughnessMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRoughnessMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRoughnessMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRoughnessMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRoughnessMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRoughnessMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setRoughnessMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry roughnessMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_roughnessMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setCutoutsMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setCutoutsMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCutoutsMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setCutoutsMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCutoutsMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setCutoutsMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCutoutsMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setCutoutsMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry cutoutsMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_cutoutsMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void setMapper(OdGiMaterialTraitsData traitsData, OdDbStub pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdDbStub pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setModelTransform(OdGeMatrix3d mtm, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setModelTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(mtm), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setModelTransform(OdGeMatrix3d mtm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setModelTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(mtm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setObjectTransform(OdGeMatrix3d otm, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setObjectTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(otm), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setObjectTransform(OdGeMatrix3d otm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setObjectTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(otm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setObjectTransform(int nCount, OdGePoint3d pPoints, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setObjectTransform__SWIG_2(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setObjectTransform(int nCount, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setObjectTransform__SWIG_3(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setObjectTransform(OdGeExtents3d exts, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setObjectTransform__SWIG_4(swigCPtr, OdGeExtents3d.getCPtr(exts), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setObjectTransform(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setObjectTransform__SWIG_5(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDeviceTransform(OdGeMatrix3d dtm, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setDeviceTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(dtm), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setDeviceTransform(OdGeMatrix3d dtm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setDeviceTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(dtm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isLastProcValid(OdDbStub pMaterial)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isLastProcValid__SWIG_0(swigCPtr, OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isLastProcValid(OdDbStub pMaterial, OdGeMatrix3d tm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isLastProcValid__SWIG_1(swigCPtr, OdDbStub.getCPtr(pMaterial), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isLastProcValid(OdGiMapper pMapper, OdDbStub pMaterial)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isLastProcValid__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isLastProcValid(OdGiMapper pMapper, OdDbStub pMaterial, OdGeMatrix3d tm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isLastProcValid__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdDbStub.getCPtr(pMaterial), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isLastProcValid(OdGeMatrix3d tm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isLastProcValid__SWIG_4(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isEntityMapper()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isEntityMapper(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isObjectMatrixNeed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isObjectMatrixNeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isModelMatrixNeed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isModelMatrixNeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isDependsFromObjectMatrix()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isDependsFromObjectMatrix(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isVertexTransformRequired()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_isVertexTransformRequired(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setVertexTransform(int nCount, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setVertexTransform__SWIG_0(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setVertexTransform(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setVertexTransform__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setInputTransform(OdGeMatrix3d tm, bool bVertexDependantOnly)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setInputTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(tm), bVertexDependantOnly);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setInputTransform(OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_setInputTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperRenderItem_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
