using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public interface PDFExportBaseParams
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	void setDatabase(OdRxObject pDb);

	OdRxObject database();

	void setSelectionSetsArray(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator pSSets);

	OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator getSelectionSetsArray();

	void setLayouts(OdStringArray layouts, OdRxObjectPtrArray pDbArray);

	void setLayouts(OdStringArray layouts);

	void addLayout(string s);

	OdStringArray layouts();

	OdRxObjectPtrArray databases();

	void clearMultipleDbSettings();
}
