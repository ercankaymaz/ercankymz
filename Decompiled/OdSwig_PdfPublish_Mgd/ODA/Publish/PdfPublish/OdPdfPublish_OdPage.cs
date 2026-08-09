using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdPage : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdPage_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdPage_1();

	public delegate void SwigDelegateOdPdfPublish_OdPage_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdPage_3();

	public delegate bool SwigDelegateOdPdfPublish_OdPage_4();

	public delegate void SwigDelegateOdPdfPublish_OdPage_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdPage_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdPage_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdPage_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdPage_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdPage_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdPage_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdPage(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdPage obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdPage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdPage()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdPage(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdPage) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdPage cast(OdRxObject pObj)
	{
		OdPdfPublish_OdPage rXObject = Helpers.GetRXObject<OdPdfPublish_OdPage>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_isASwigExplicitOdPdfPublish_OdPage(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_queryXSwigExplicitOdPdfPublish_OdPage(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdPage createObject()
	{
		OdPdfPublish_OdPage rXObject = Helpers.GetRXObject<OdPdfPublish_OdPage>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setFormat(OdPdfPublish_Page_Format format)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_setFormat(swigCPtr, (int)format);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOrientation(OdPdfPublish_Page_Orientation orientation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_setOrientation(swigCPtr, (int)orientation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPaperSize(OdPdfPublish_Page_PaperUnits units, double width, double height)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_setPaperSize(swigCPtr, (int)units, width, height);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addAnnotation(OdPdfPublish_OdAnnotation annotation, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addAnnotation(swigCPtr, OdPdfPublish_OdAnnotation.getCPtr(annotation), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addText(OdPdfPublish_OdText text, OdGsDCRect location, double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addText__SWIG_0(swigCPtr, OdPdfPublish_OdText.getCPtr(text), OdGsDCRect.getCPtr(location), rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addText(OdPdfPublish_OdText text, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addText__SWIG_1(swigCPtr, OdPdfPublish_OdText.getCPtr(text), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addImage(OdPdfPublish_OdImage image, OdGsDCRect location, double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addImage__SWIG_0(swigCPtr, OdPdfPublish_OdImage.getCPtr(image), OdGsDCRect.getCPtr(location), rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addImage(OdPdfPublish_OdImage image, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addImage__SWIG_1(swigCPtr, OdPdfPublish_OdImage.getCPtr(image), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addTable(OdPdfPublish_OdTable table, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addTable(swigCPtr, OdPdfPublish_OdTable.getCPtr(table), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLink(OdPdfPublish_OdLink link, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addLink(swigCPtr, OdPdfPublish_OdLink.getCPtr(link), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addButton(OdPdfPublish_OdButton button, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addButton(swigCPtr, OdPdfPublish_OdButton.getCPtr(button), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addTextField(OdPdfPublish_OdTextField text_field, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addTextField(swigCPtr, OdPdfPublish_OdTextField.getCPtr(text_field), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addSlideTable(OdPdfPublish_OdSlideTable slide_table, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addSlideTable(swigCPtr, OdPdfPublish_OdSlideTable.getCPtr(slide_table), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCheckBox(OdPdfPublish_OdCheckBox check_box, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addCheckBox(swigCPtr, OdPdfPublish_OdCheckBox.getCPtr(check_box), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addRadioButton(OdPdfPublish_OdRadioButton radio_button, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addRadioButton(swigCPtr, OdPdfPublish_OdRadioButton.getCPtr(radio_button), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addListBox(OdPdfPublish_OdListBox list_box, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addListBox(swigCPtr, OdPdfPublish_OdListBox.getCPtr(list_box), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addDropDownList(OdPdfPublish_OdDropDownList drop_down_list, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addDropDownList(swigCPtr, OdPdfPublish_OdDropDownList.getCPtr(drop_down_list), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addSignatureField(OdPdfPublish_OdSignatureField signature_field, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addSignatureField(swigCPtr, OdPdfPublish_OdSignatureField.getCPtr(signature_field), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void add2dGeometry(OdPdfPublish_Od2dGeometryReference geom, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_add2dGeometry__SWIG_0(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(geom), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void add2dGeometry(OdPdfPublish_Od2dGeometryReference geom)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_add2dGeometry__SWIG_1(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(geom));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCADReference(OdPdfPublish_OdCADReference CADreferense, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addCADReference__SWIG_0(swigCPtr, OdPdfPublish_OdCADReference.getCPtr(CADreferense), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCADReference(OdPdfPublish_OdCADReference CADreferense)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addCADReference__SWIG_1(swigCPtr, OdPdfPublish_OdCADReference.getCPtr(CADreferense));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addStickyNote(OdPdfPublish_OdStickyNote note, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addStickyNote(swigCPtr, OdPdfPublish_OdStickyNote.getCPtr(note), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addStampAnnotation(OdPdfPublish_OdStampAnnotation stamp, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addStampAnnotation(swigCPtr, OdPdfPublish_OdStampAnnotation.getCPtr(stamp), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addInkAnnotation(OdPdfPublish_OdInkAnnotation ink, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addInkAnnotation(swigCPtr, OdPdfPublish_OdInkAnnotation.getCPtr(ink), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLineAnnotation(OdPdfPublish_OdLineAnnotation line, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addLineAnnotation(swigCPtr, OdPdfPublish_OdLineAnnotation.getCPtr(line), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCircleAnnotation(OdPdfPublish_OdCircleAnnotation circle, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addCircleAnnotation(swigCPtr, OdPdfPublish_OdCircleAnnotation.getCPtr(circle), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addSquareAnnotation(OdPdfPublish_OdSquareAnnotation square, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addSquareAnnotation(swigCPtr, OdPdfPublish_OdSquareAnnotation.getCPtr(square), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addPolylineAnnotation(OdPdfPublish_OdPolylineAnnotation polyline, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addPolylineAnnotation(swigCPtr, OdPdfPublish_OdPolylineAnnotation.getCPtr(polyline), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addPolygonAnnotation(OdPdfPublish_OdPolygonAnnotation polygon, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addPolygonAnnotation(swigCPtr, OdPdfPublish_OdPolygonAnnotation.getCPtr(polygon), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addWatermark(OdPdfPublish_OdWatermark watermark, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addWatermark(swigCPtr, OdPdfPublish_OdWatermark.getCPtr(watermark), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addJavaScriptActionByField(string field_name, string source, OdPdfPublish_Action_Type action_type, OdPdfPublish_Source_Type source_type)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addJavaScriptActionByField__SWIG_0(swigCPtr, field_name, source, (int)action_type, (int)source_type);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addJavaScriptActionByField(string field_name, string source, OdPdfPublish_Action_Type action_type)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_addJavaScriptActionByField__SWIG_1(swigCPtr, field_name, source, (int)action_type);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFormat(out OdPdfPublish_Page_Format format)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getFormat(swigCPtr, out format);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getOrientation(out OdPdfPublish_Page_Orientation orientation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getOrientation(swigCPtr, out orientation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPaperSize(OdPdfPublish_Page_PaperUnits units, out double width, out double height)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getPaperSize(swigCPtr, (int)units, out width, out height);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getAnnotations(OdPdfPublish_OdAnnotationPtrArray annotations, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getAnnotations(swigCPtr, OdPdfPublish_OdAnnotationPtrArray.getCPtr(annotations), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTexts(OdPdfPublish_OdTextPtrArray texts, OdPdfPublish_OdRectArray locations, OdDoubleArray rotations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getTexts(swigCPtr, OdPdfPublish_OdTextPtrArray.getCPtr(texts), OdPdfPublish_OdRectArray.getCPtr(locations), OdDoubleArray.getCPtr(rotations).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getImages(OdPdfPublish_OdImagePtrArray images, OdPdfPublish_OdRectArray locations, OdDoubleArray rotations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getImages(swigCPtr, OdPdfPublish_OdImagePtrArray.getCPtr(images), OdPdfPublish_OdRectArray.getCPtr(locations), OdDoubleArray.getCPtr(rotations).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTables(OdPdfPublish_OdTablePtrArray tables, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getTables(swigCPtr, OdPdfPublish_OdTablePtrArray.getCPtr(tables), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLinks(OdPdfPublish_OdLinkPtrArray links, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getLinks(swigCPtr, OdPdfPublish_OdLinkPtrArray.getCPtr(links), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getButtons(OdPdfPublish_OdButtonPtrArray buttons, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getButtons(swigCPtr, OdPdfPublish_OdButtonPtrArray.getCPtr(buttons), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCheckBoxes(OdPdfPublish_OdCheckBoxPtrArray check_boxes, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getCheckBoxes(swigCPtr, OdPdfPublish_OdCheckBoxPtrArray.getCPtr(check_boxes), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getRadioButtons(OdPdfPublish_OdRadioButtonPtrArray radio_buttons, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getRadioButtons(swigCPtr, OdPdfPublish_OdRadioButtonPtrArray.getCPtr(radio_buttons), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getListBoxes(OdPdfPublish_OdListBoxPtrArray list_boxes, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getListBoxes(swigCPtr, OdPdfPublish_OdListBoxPtrArray.getCPtr(list_boxes), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDropDownLists(OdPdfPublish_OdDropDownListPtrArray drop_down_lists, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getDropDownLists(swigCPtr, OdPdfPublish_OdDropDownListPtrArray.getCPtr(drop_down_lists), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSignatureFields(OdPdfPublish_OdSignatureFieldPtrArray signature_fields, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getSignatureFields(swigCPtr, OdPdfPublish_OdSignatureFieldPtrArray.getCPtr(signature_fields), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextFields(OdPdfPublish_OdTextFieldPtrArray text_fields, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getTextFields(swigCPtr, OdPdfPublish_OdTextFieldPtrArray.getCPtr(text_fields), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSlideTables(OdPdfPublish_OdSlideTablePtrArray slide_tables, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getSlideTables(swigCPtr, OdPdfPublish_OdSlideTablePtrArray.getCPtr(slide_tables), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getJavaScriptActionsByField(string field_name, OdStringArray sources, OdPdfPublish_OdActionTypeArray action_types, OdPdfPublish_OdSourceTypeArray source_types)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getJavaScriptActionsByField(swigCPtr, field_name, OdStringArray.getCPtr(sources).Handle, OdPdfPublish_OdActionTypeArray.getCPtr(action_types), OdPdfPublish_OdSourceTypeArray.getCPtr(source_types));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get2dGeoms(OdPdfPublish_Od2dGeometryReferencePtrArray geoms, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_get2dGeoms(swigCPtr, OdPdfPublish_Od2dGeometryReferencePtrArray.getCPtr(geoms), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCADReferences(OdPdfPublish_OdCADReferencePtrArray CADreferenses, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getCADReferences(swigCPtr, OdPdfPublish_OdCADReferencePtrArray.getCPtr(CADreferenses), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getStickyNotes(OdPdfPublish_OdStickyNotePtrArray notes, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getStickyNotes(swigCPtr, OdPdfPublish_OdStickyNotePtrArray.getCPtr(notes), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getWatermarks(OdPdfPublish_OdWatermarkPtrArray watermarks, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getWatermarks(swigCPtr, OdPdfPublish_OdWatermarkPtrArray.getCPtr(watermarks), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getStampAnnotations(OdPdfPublish_OdStampAnnotationPtrArray stamps, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getStampAnnotations(swigCPtr, OdPdfPublish_OdStampAnnotationPtrArray.getCPtr(stamps), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getInkAnnotations(OdPdfPublish_OdInkAnnotationPtrArray inks, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getInkAnnotations(swigCPtr, OdPdfPublish_OdInkAnnotationPtrArray.getCPtr(inks), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLineAnnotations(OdPdfPublish_OdLineAnnotationPtrArray lines, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getLineAnnotations(swigCPtr, OdPdfPublish_OdLineAnnotationPtrArray.getCPtr(lines), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCircleAnnotations(OdPdfPublish_OdCircleAnnotationPtrArray circles, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getCircleAnnotations(swigCPtr, OdPdfPublish_OdCircleAnnotationPtrArray.getCPtr(circles), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getSquareAnnotations(OdPdfPublish_OdSquareAnnotationPtrArray squares, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getSquareAnnotations(swigCPtr, OdPdfPublish_OdSquareAnnotationPtrArray.getCPtr(squares), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPolylineAnnotations(OdPdfPublish_OdPolylineAnnotationPtrArray polylines, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getPolylineAnnotations(swigCPtr, OdPdfPublish_OdPolylineAnnotationPtrArray.getCPtr(polylines), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPolygonAnnotations(OdPdfPublish_OdPolygonAnnotationPtrArray polygons, OdPdfPublish_OdRectArray locations)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getPolygonAnnotations(swigCPtr, OdPdfPublish_OdPolygonAnnotationPtrArray.getCPtr(polygons), OdPdfPublish_OdRectArray.getCPtr(locations));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisEmpty;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodclear;
		}
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdPage_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdPage));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisEmpty()
	{
		return isEmpty();
	}

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
		}
		catch (OdEdEmptyInput err)
		{
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
