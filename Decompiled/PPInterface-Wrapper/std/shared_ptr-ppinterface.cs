using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AVectord_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAxis_003E
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(shared_ptr_003Cppinterface_003A_003AAxis_003E* A_0, shared_ptr_003Cppinterface_003A_003AAxis_003E* A_1)
	{
		if (A_0 != null)
		{
			*(int*)A_0 = 0;
			((int*)A_0)[1] = 0;
			*(int*)A_0 = *(int*)A_1;
			((int*)A_0)[1] = ((int*)A_1)[1];
			*(int*)A_1 = 0;
			((int*)A_1)[1] = 0;
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(shared_ptr_003Cppinterface_003A_003AAxis_003E* A_0)
	{
		uint num = ((uint*)A_0)[1];
		if (num != 0)
		{
			global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)num);
		}
	}
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ACancelHandler_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOperationNode_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AMachine_003E
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(shared_ptr_003Cppinterface_003A_003AMachine_003E* A_0, shared_ptr_003Cppinterface_003A_003AMachine_003E* A_1)
	{
		if (A_0 != null)
		{
			*(int*)A_0 = 0;
			((int*)A_0)[1] = 0;
			*(int*)A_0 = *(int*)A_1;
			((int*)A_0)[1] = ((int*)A_1)[1];
			*(int*)A_1 = 0;
			((int*)A_1)[1] = 0;
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(shared_ptr_003Cppinterface_003A_003AMachine_003E* A_0)
	{
		uint num = ((uint*)A_0)[1];
		if (num != 0)
		{
			global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)num);
		}
	}
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AMachineSettings_003E
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* A_0, shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* A_1)
	{
		if (A_0 != null)
		{
			*(int*)A_0 = 0;
			((int*)A_0)[1] = 0;
			*(int*)A_0 = *(int*)A_1;
			((int*)A_0)[1] = ((int*)A_1)[1];
			*(int*)A_1 = 0;
			((int*)A_1)[1] = 0;
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(shared_ptr_003Cppinterface_003A_003AMachineSettings_003E* A_0)
	{
		uint num = ((uint*)A_0)[1];
		if (num != 0)
		{
			global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)num);
		}
	}
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AMoveMarker_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AMove_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003APPFrameworkInput_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASpindleSettings_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AToolDescription_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAbrasiveCuttingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOperation_003E
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(shared_ptr_003Cppinterface_003A_003AOperation_003E* A_0, shared_ptr_003Cppinterface_003A_003AOperation_003E* A_1)
	{
		if (A_0 != null)
		{
			*(int*)A_0 = 0;
			((int*)A_0)[1] = 0;
			*(int*)A_0 = *(int*)A_1;
			((int*)A_0)[1] = ((int*)A_1)[1];
			*(int*)A_1 = 0;
			((int*)A_1)[1] = 0;
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(shared_ptr_003Cppinterface_003A_003AOperation_003E* A_0)
	{
		uint num = ((uint*)A_0)[1];
		if (num != 0)
		{
			global::_003CModule_003E.std_002E_Ref_count_base_002E_Decref((_Ref_count_base*)(int)num);
		}
	}
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAdditionalData_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAdditiveFDMOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAdditiveManufacturingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAdditiveSLMOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AArbor_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AAutomatic3Plus2RoughingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ACutter_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ABarrelMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ABullMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ACAMInformation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AChamferMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AContouringOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ADeburringOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AHoleMakingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ADrillingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AExistingToolpathOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AGeodesicOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AHammeringOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ALAMCladdingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ALAMCombinedOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AMultiBladeOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AMultiaxisOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOpticOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOrthoticsOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003APortOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AReamingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ARotaryOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASawOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASpeedShapingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASurfacesOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASwarfOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AThreadMillingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AThreadTappingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ATriangleMeshOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ATurnMillingOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ATurningOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AWireframeOperation_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOperationGroup_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ARotationalAxis_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASpindle_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ATranslationalAxis_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AConvexTipMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ADoveMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ADrillMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AEndMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AFlyCutMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AHolder_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ALollipopMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOpticParameters_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AToolPathParameters_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003AOpticDiamondCutter_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003APostSettings_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASlotMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ASphereMill_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003Cppinterface_003A_003ATaperMill_003E
{
}
