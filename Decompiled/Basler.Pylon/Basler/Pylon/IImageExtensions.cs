using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GenICam_3_1_Basler_pylon;
using Pylon;
using bclog;
using std;

namespace Basler.Pylon;

public static class IImageExtensions
{
	public static void Display(this IImage image, int windowIndex)
	{
		ImageWindow.DisplayImage(windowIndex, image);
	}

	public unsafe static int? ComputeStride(this IImage image)
	{
		uint num = 0u;
		int num2 = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (image.IsValid)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr4);
			try
			{
				uint num3 = 0u;
				if (global::_003CModule_003E.Pylon_002EComputeStride(&num3, (EPixelType)image.PixelTypeValue, (uint)image.Width, (uint)image.PaddingX))
				{
					int num4 = (int)num3;
					return (int)num3;
				}
			}
			catch (Exception ex)
			{
				string source = ex.Source;
				string message = ex.Message;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				gcstring* ptr = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &source);
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
					gcstring* ptr2 = global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring3, &message);
					try
					{
						global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetImageCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0FL_0040MFKIOCJI_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr2 + 44)))((nint)ptr2), ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)ptr + 44)))((nint)ptr)));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						uint num6 = global::_003CModule_003E.Basler_002EPylon_002EGetImageCatID();
						GenericException* intPtr = ptr3;
						global::_003CModule_003E.bclog_002ELogTrace(num6, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EN_0040NIEGAGOG_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr)));
						goto end_IL_00fa;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num5 != 0;
					}).Invoke())
					{
					}
					if (num5 != 0)
					{
						throw;
					}
					end_IL_00fa:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						uint num7 = global::_003CModule_003E.Basler_002EPylon_002EGetImageCatID();
						exception* intPtr2 = ptr4;
						global::_003CModule_003E.bclog_002ELogTrace(num7, (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EF_0040HDKOHCAB_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 4)))((nint)intPtr2)));
						goto end_IL_016c;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num5 != 0;
					}).Invoke())
					{
					}
					if (num5 != 0)
					{
						throw;
					}
					end_IL_016c:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
				try
				{
					try
					{
						global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetImageCatID(), (LogLevel)256, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0EC_0040HJAIIOK_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040), __arglist());
						goto end_IL_01db;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num5 != 0;
					}).Invoke())
					{
					}
					if (num5 != 0)
					{
						throw;
					}
					end_IL_01db:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num5);
				}
			}
		}
		return null;
	}
}
