using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdGiConveyorContext
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	OdGiContext giContext();

	OdGiSubEntityTraits subEntityTraits();

	OdGiSubEntityTraitsData effectiveTraits();

	void setEffectiveTraits(OdGiSubEntityTraitsData traits, OdGeVector3d fillNormal);

	void setEffectiveTraits(OdGiSubEntityTraitsData traits);

	bool effectivelyVisible();

	OdGiDrawableDesc currentDrawableDesc();

	OdGiDrawable currentDrawable();

	OdGiViewport giViewport();

	OdGsView gsView();

	void onTraitsModified();

	void onTextProcessing(OdGePoint3d arg0, OdGeVector3d arg1, OdGeVector3d arg2);

	bool regenAbort();

	OdGiPathNode currentGiPath();

	OdGiDeviation worldDeviation();

	OdGiDeviation modelDeviation();

	OdGiDeviation eyeDeviation();

	OdGeMatrix3d getModelToWorldTransform();

	OdGeMatrix3d getWorldToModelTransform();

	OdGiLineweightOverride currentLineweightOverride();

	uint drawContextFlags();

	double annotationScale();
}
