using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using GenApi_3_1_Basler_pylon;
using GenICam_3_1_Basler_pylon;
using std;

namespace Basler.Pylon;

internal class FileAdapterStream : Stream
{
	private unsafe ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* m_pOutputFilestream;

	private unsafe IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* m_InputFileStream;

	private unsafe gcstring* m_strFilename;

	private Camera m_parent;

	public override long Position
	{
		get
		{
			throw new NotSupportedException("Cannot get the position of the stream.");
		}
		set
		{
			throw new NotSupportedException("Cannot set the position of the stream.");
		}
	}

	public override long Length
	{
		get
		{
			throw new NotSupportedException("Cannot get  the length of the stream.");
		}
	}

	public unsafe override bool CanWrite
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return (byte)((m_pOutputFilestream != null) ? 1u : 0u) != 0;
		}
	}

	public override bool CanSeek
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return false;
		}
	}

	public unsafe override bool CanRead
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return (byte)((m_InputFileStream != null) ? 1u : 0u) != 0;
		}
	}

	public unsafe FileAdapterStream(Camera parent, INodeMap* pNodeMap, string filename, FileAccess direction)
	{
		uint num = (uint)global::_003CModule_003E.__CxxQueryExceptionSize();
		int num2 = (int)stackalloc byte[(int)(num << 1)];
		m_pOutputFilestream = null;
		m_InputFileStream = null;
		m_strFilename = null;
		m_parent = parent;
		base._002Ector();
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out int num3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr12);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr13);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr14);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr15);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr16);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr17);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr18);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr19);
			try
			{
				num3 = (int)num + num2;
				gcstring* ptr = (gcstring*)global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002Enew(72u);
				gcstring* ptr2;
				try
				{
					if (ptr != null)
					{
						global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(ptr, &filename);
						*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_Sgcstring_0040GenICam_3_1_Basler_pylon_0040_00406B_0040);
						ptr2 = ptr;
					}
					else
					{
						ptr2 = null;
					}
					gcstring* ptr3 = ptr2;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDelDtor((delegate*<void*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002Edelete), (void*)ptr);
					throw;
				}
				m_strFilename = ptr2;
				CFileAdapterStreamList.Add(m_parent, filename);
				try
				{
					switch (direction)
					{
					case FileAccess.Read:
					{
						IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr7 = (IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)global::_003CModule_003E.@new(256u);
						IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr8;
						try
						{
							ptr8 = ((ptr7 == null) ? null : global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(ptr7, 1));
							IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr9 = ptr8;
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.delete(ptr7, 256u);
							throw;
						}
						m_InputFileStream = ptr8;
						gcstring* strFilename = m_strFilename;
						IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* inputFileStream = m_InputFileStream;
						gcstring* intPtr2 = strFilename;
						global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(inputFileStream, pNodeMap, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 44)))((nint)intPtr2), 1);
						IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* inputFileStream2 = m_InputFileStream;
						if (global::_003CModule_003E.std_002Eios_base_002Efail((ios_base*)(*(int*)(*(int*)inputFileStream2 + 4) + (byte*)inputFileStream2)))
						{
							throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("Failed to open file for reading."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CE_0040PJHNKPMC_0040_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_003F_0024AAA_003F_0024AAd_003F_0024AAa_003F_0024AAp_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAt_003F_0024AAr_003F_0024AAe_0040));
						}
						break;
					}
					case FileAccess.Write:
					{
						ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr4 = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)global::_003CModule_003E.@new(168u);
						ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr5;
						try
						{
							ptr5 = ((ptr4 == null) ? null : global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(ptr4, 1));
							ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr6 = ptr5;
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.delete(ptr4, 168u);
							throw;
						}
						m_pOutputFilestream = ptr5;
						gcstring* strFilename = m_strFilename;
						ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* pOutputFilestream = m_pOutputFilestream;
						gcstring* intPtr = strFilename;
						global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(pOutputFilestream, pNodeMap, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 44)))((nint)intPtr), 18);
						ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* pOutputFilestream2 = m_pOutputFilestream;
						if (global::_003CModule_003E.std_002Eios_base_002Efail((ios_base*)(*(int*)(*(int*)pOutputFilestream2 + 4) + (byte*)pOutputFilestream2)))
						{
							throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("Fail to open file for writing."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CE_0040PJHNKPMC_0040_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_003F_0024AAA_003F_0024AAd_003F_0024AAa_003F_0024AAp_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAt_003F_0024AAr_003F_0024AAe_0040));
						}
						break;
					}
					default:
						throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException("File access is not supported"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CE_0040PJHNKPMC_0040_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_003F_0024AAA_003F_0024AAd_003F_0024AAa_003F_0024AAp_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAt_003F_0024AAr_003F_0024AAe_0040));
					}
					return;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					uint num4 = 0u;
					global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num2);
					try
					{
						try
						{
							CFileAdapterStreamList.Remove(m_parent);
							global::_003CModule_003E._CxxThrowException(null, null);
							return;
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num4 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num4 != 0;
						}).Invoke())
						{
						}
						if (num4 != 0)
						{
							throw;
						}
						return;
					}
					finally
					{
						global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num2, (int)num4);
					}
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						InvalidArgumentException* intPtr3 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						Exception ex;
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
						ex.Source = "FileAdapterStream";
						throw ex;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						OutOfRangeException* intPtr4 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						Exception ex2;
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						ex2.Source = "FileAdapterStream";
						throw ex2;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						AccessException* intPtr5 = ptr12;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						Exception ex3;
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex3.Source = "FileAdapterStream";
						throw ex3;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr6 = ptr13;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						Exception ex4;
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex4.Source = "FileAdapterStream";
						throw ex4;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						LogicalErrorException* intPtr7 = ptr14;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						Exception ex5;
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex5.Source = "FileAdapterStream";
						throw ex5;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr15) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						BadAllocException* intPtr8 = ptr15;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						Exception ex6;
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex6.Source = "FileAdapterStream";
						throw ex6;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr16) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						RuntimeException* intPtr9 = ptr16;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						Exception ex7;
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex7.Source = "FileAdapterStream";
						throw ex7;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr17) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						DynamicCastException* intPtr10 = ptr17;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 12)))((nint)intPtr10));
						Exception ex8;
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex8.Source = "FileAdapterStream";
						throw ex8;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr18) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						GenericException* intPtr11 = ptr18;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr11 + 12)))((nint)intPtr11));
						Exception ex9;
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex9.Source = "FileAdapterStream";
						throw ex9;
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr19) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						exception* intPtr12 = ptr19;
						throw new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr12 + 4)))((nint)intPtr12)))
						{
							Source = "FileAdapterStream"
						};
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode2 = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
				try
				{
					try
					{
						throw new Exception("Unknown exception")
						{
							Source = "FileAdapterStream"
						};
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
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num5);
				}
			}
		}
		catch
		{
			//try-fault
			base.Dispose(disposing: true);
			throw;
		}
	}

	private unsafe void _0021FileAdapterStream()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (m_pOutputFilestream != null)
		{
			try
			{
				global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose(m_pOutputFilestream);
				ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* pOutputFilestream = m_pOutputFilestream;
				ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = pOutputFilestream;
				if (pOutputFilestream != null)
				{
					ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)pOutputFilestream + *(int*)(*(int*)pOutputFilestream + 4));
					void* ptr3 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)ptr2)))((nint)ptr2, 1u);
				}
				else
				{
					void* ptr3 = null;
				}
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						goto end_IL_0073;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					end_IL_0073:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			finally
			{
				m_pOutputFilestream = null;
			}
		}
		if (m_InputFileStream != null)
		{
			try
			{
				global::_003CModule_003E.GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose(m_InputFileStream);
				IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* inputFileStream = m_InputFileStream;
				IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr4 = inputFileStream;
				if (inputFileStream != null)
				{
					IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr5 = (IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)inputFileStream + *(int*)(*(int*)inputFileStream + 4));
					void* ptr6 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)ptr5)))((nint)ptr5, 1u);
				}
				else
				{
					void* ptr6 = null;
				}
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						goto end_IL_010b;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					end_IL_010b:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			finally
			{
				m_InputFileStream = null;
			}
		}
		if (m_strFilename != null)
		{
			try
			{
				gcstring* strFilename = m_strFilename;
				gcstring* ptr7 = strFilename;
				if (strFilename != null)
				{
					void* ptr8 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)strFilename)))((nint)strFilename, 1u);
				}
				else
				{
					void* ptr8 = null;
				}
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						goto end_IL_018f;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					end_IL_018f:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			finally
			{
				m_strFilename = null;
			}
		}
		CFileAdapterStreamList.Remove(m_parent);
	}

	private void _007EFileAdapterStream()
	{
		_0021FileAdapterStream();
	}

	public unsafe override void Flush()
	{
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr4);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr5);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr6);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr7);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr8);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr9);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr10);
		try
		{
			ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* pOutputFilestream = m_pOutputFilestream;
			if (pOutputFilestream != null)
			{
				global::_003CModule_003E.std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eflush((basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)pOutputFilestream);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					InvalidArgumentException* intPtr = ptr;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
					gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
					Exception ex;
					try
					{
						ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
					ex.Source = "FileAdapterStream";
					throw ex;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr2) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					OutOfRangeException* intPtr2 = ptr2;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
					gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
					Exception ex2;
					try
					{
						ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
					ex2.Source = "FileAdapterStream";
					throw ex2;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					AccessException* intPtr3 = ptr3;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
					gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
					Exception ex3;
					try
					{
						ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
					ex3.Source = "FileAdapterStream";
					throw ex3;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr4;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
					gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
					Exception ex4;
					try
					{
						ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
					ex4.Source = "FileAdapterStream";
					throw ex4;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					LogicalErrorException* intPtr5 = ptr5;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
					gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
					Exception ex5;
					try
					{
						ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
					ex5.Source = "FileAdapterStream";
					throw ex5;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					BadAllocException* intPtr6 = ptr6;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
					gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
					Exception ex6;
					try
					{
						ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
					ex6.Source = "FileAdapterStream";
					throw ex6;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					RuntimeException* intPtr7 = ptr7;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
					gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
					Exception ex7;
					try
					{
						ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
					ex7.Source = "FileAdapterStream";
					throw ex7;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					DynamicCastException* intPtr8 = ptr8;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
					gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
					Exception ex8;
					try
					{
						ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
					ex8.Source = "FileAdapterStream";
					throw ex8;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					GenericException* intPtr9 = ptr9;
					System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
					gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
					Exception ex9;
					try
					{
						ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
						throw;
					}
					global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
					ex9.Source = "FileAdapterStream";
					throw ex9;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr10) != 0)
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					exception* intPtr10 = ptr10;
					Exception ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
					ex10.Source = "FileAdapterStream";
					throw ex10;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		catch (Exception)
		{
			throw;
		}
		catch when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
		}).Invoke())
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					Exception ex12 = new Exception("Unknown exception");
					ex12.Source = "FileAdapterStream";
					throw ex12;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
	}

	public override void SetLength(long A_0)
	{
		throw new NotSupportedException("Cannot set the length of the stream.");
	}

	public override long Seek(long A_0, SeekOrigin A_1)
	{
		throw new NotSupportedException("Cannot seek on the stream.");
	}

	public unsafe override int Read(byte[] buffer, int index, int length)
	{
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		if (buffer.GetUpperBound(0) >= length + index - 1 && buffer.GetLowerBound(0) <= index && length >= 1)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr6);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr8);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr9);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr10);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr11);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr12);
			try
			{
				fixed (byte* ptr = &buffer[index])
				{
					long num2 = 0L;
					long num3 = 0L;
					long num4 = length;
					sbyte* ptr2 = (sbyte*)ptr;
					while (true)
					{
						IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* inputFileStream = m_InputFileStream;
						if (!global::_003CModule_003E.std_002Eios_base_002Egood((ios_base*)(*(int*)(*(int*)inputFileStream + 4) + (byte*)inputFileStream)) || num4 <= 0)
						{
							break;
						}
						global::_003CModule_003E.std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eread((basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)m_InputFileStream, ptr2, num4);
						num2 = global::_003CModule_003E.std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egcount((basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)m_InputFileStream);
						ptr2 = (int)num2 + ptr2;
						num3 += num2;
						num4 -= num2;
					}
					return (int)num3;
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr3;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
						ex.Source = "FileAdapterStream";
						throw ex;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr4;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						ex2.Source = "FileAdapterStream";
						throw ex2;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr5;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex3.Source = "FileAdapterStream";
						throw ex3;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex4.Source = "FileAdapterStream";
						throw ex4;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex5.Source = "FileAdapterStream";
						throw ex5;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex6.Source = "FileAdapterStream";
						throw ex6;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex7.Source = "FileAdapterStream";
						throw ex7;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex8.Source = "FileAdapterStream";
						throw ex8;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex9.Source = "FileAdapterStream";
						throw ex9;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr12;
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "FileAdapterStream";
						throw ex10;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ex11 = new Exception("Unknown exception");
						ex11.Source = "FileAdapterStream";
						throw ex11;
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
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			return 0;
		}
		throw new ArgumentOutOfRangeException("Trying to access buffer beyond bounds.");
	}

	public unsafe override void Write(byte[] buffer, int index, int length)
	{
		Exception ex = null;
		Exception ex2 = null;
		Exception ex3 = null;
		Exception ex4 = null;
		Exception ex5 = null;
		Exception ex6 = null;
		Exception ex7 = null;
		Exception ex8 = null;
		Exception ex9 = null;
		Exception ex10 = null;
		Exception ex11 = null;
		int num = (int)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr3);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr4);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr5);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr6);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr7);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr8);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr9);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr10);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr11);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr12);
		if (buffer.GetUpperBound(0) >= length + index - 1 && buffer.GetLowerBound(0) <= index && length > 1)
		{
			try
			{
				fixed (byte* ptr = &buffer[index])
				{
					sbyte* ptr2 = (sbyte*)ptr;
					global::_003CModule_003E.std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Ewrite((basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)m_pOutputFilestream, ptr2, length);
					ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* pOutputFilestream = m_pOutputFilestream;
					if (!global::_003CModule_003E.std_002Eios_base_002Efail((ios_base*)(*(int*)(*(int*)pOutputFilestream + 4) + (byte*)pOutputFilestream)))
					{
						pOutputFilestream = m_pOutputFilestream;
						if (!global::_003CModule_003E.std_002Eios_base_002Eeof((ios_base*)(*(int*)(*(int*)pOutputFilestream + 4) + (byte*)pOutputFilestream)))
						{
							return;
						}
					}
					throw new IOException("Failed to write file.");
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr3) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						InvalidArgumentException* intPtr = ptr3;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
						gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
						try
						{
							ex = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
						ex.Source = "FileAdapterStream";
						throw ex;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr4) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						OutOfRangeException* intPtr2 = ptr4;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						try
						{
							ex2 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
						ex2.Source = "FileAdapterStream";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr5) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						AccessException* intPtr3 = ptr5;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						try
						{
							ex3 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex3.Source = "FileAdapterStream";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr6) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr4 = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						try
						{
							ex4 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex4.Source = "FileAdapterStream";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr7) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						LogicalErrorException* intPtr5 = ptr7;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						try
						{
							ex5 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex5.Source = "FileAdapterStream";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr8) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						BadAllocException* intPtr6 = ptr8;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						try
						{
							ex6 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex6.Source = "FileAdapterStream";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr9) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						RuntimeException* intPtr7 = ptr9;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						try
						{
							ex7 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex7.Source = "FileAdapterStream";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr10) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						DynamicCastException* intPtr8 = ptr10;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						try
						{
							ex8 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex8.Source = "FileAdapterStream";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr11) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						GenericException* intPtr9 = ptr11;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						try
						{
							ex9 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex9.Source = "FileAdapterStream";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr12) != 0)
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						exception* intPtr10 = ptr12;
						ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 4)))((nint)intPtr10)));
						ex10.Source = "FileAdapterStream";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			catch (Exception)
			{
				throw;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ex11 = new Exception("Unknown exception");
						ex11.Source = "FileAdapterStream";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
					return;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
		}
		throw new ArgumentOutOfRangeException("Trying to access buffer beyond bounds.");
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				_007EFileAdapterStream();
				return;
			}
			finally
			{
				base.Dispose(disposing: true);
			}
		}
		try
		{
			_0021FileAdapterStream();
		}
		finally
		{
			base.Dispose(disposing: false);
		}
	}

	~FileAdapterStream()
	{
		Dispose(A_0: false);
	}
}
