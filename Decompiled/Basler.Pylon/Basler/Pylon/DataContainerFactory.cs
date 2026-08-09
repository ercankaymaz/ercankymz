using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Baselibs;
using GenICam_3_1_Basler_pylon;
using Pylon;
using PylonInternal;
using std;

namespace Basler.Pylon;

public class DataContainerFactory
{
	public unsafe static IDataContainer CreateFromFile(string filename)
	{
		uint num = 0u;
		uint num2 = (uint)global::_003CModule_003E.__CxxQueryExceptionSize();
		int num3 = (int)stackalloc byte[(int)(num2 << 1)];
		if (!string.IsNullOrEmpty(filename) && !string.IsNullOrWhiteSpace(filename))
		{
			if (!File.Exists(filename))
			{
				throw new InvalidOperationException("The file does not exist.");
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out int num4);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr14);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException* ptr15);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out AccessException* ptr16);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenICam_3_1_Basler_pylon.TimeoutException* ptr17);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out LogicalErrorException* ptr18);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException* ptr19);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException* ptr20);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out DynamicCastException* ptr21);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out GenericException* ptr22);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out exception* ptr23);
			try
			{
				num4 = (int)num2 + num3;
				uint num5 = (uint)new FileInfo(filename).Length;
				if (num5 == 0)
				{
					throw new InvalidOperationException("The file is too small.");
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &filename);
				byte b = 0;
				try
				{
					CNativeBufferFactory* ptr = (CNativeBufferFactory*)global::_003CModule_003E.@new(16u);
					CNativeBufferFactory* ptr2;
					try
					{
						ptr2 = ((ptr == null) ? null : global::_003CModule_003E.Basler_002EPylon_002ECNativeBufferFactory_002E_007Bctor_007D(ptr, null, new BufferReleaser()));
						CNativeBufferFactory* ptr3 = ptr2;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.delete(ptr, 16u);
						throw;
					}
					CNativeBufferFactory* ptr4 = ptr2;
					void* ptr5 = null;
					int num6 = 0;
					((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void**, int*, void>)(int)(*(uint*)(*(int*)ptr2 + 4)))((nint)ptr2, num5, &ptr5, &num6);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E obj);
					global::_003CModule_003E.std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(&obj, 1);
					byte b2 = 0;
					try
					{
						global::_003CModule_003E.std_002Eios_base_002Eexceptions((ios_base*)((ref *(_003F*)(*(int*)(*(int*)(&obj) + 4))) + (ref *(_003F*)(&obj))), 6);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E);
						StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E* ptr6 = global::_003CModule_003E.Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bctor_007D(&stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E, global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_002EPBD(&gcstring2));
						try
						{
							global::_003CModule_003E.std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(&obj, global::_003CModule_003E.Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002Ec_str(ptr6), 33, 64);
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E*, void>)(&global::_003CModule_003E.Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bdtor_007D), &stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E);
							throw;
						}
						global::_003CModule_003E.Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bdtor_007D(&stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E);
						global::_003CModule_003E.std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eread((basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)(&obj), (sbyte*)ptr5, num5);
						if (global::_003CModule_003E.std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose((basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16))) == null)
						{
							global::_003CModule_003E.std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetstate((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((ref *(_003F*)(*(int*)(*(int*)(&obj) + 4))) + (ref *(_003F*)(&obj))), 2, false);
						}
						System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException* ptr13);
						try
						{
							MockGrabResult* ptr7 = (MockGrabResult*)global::_003CModule_003E.@new(160u);
							MockGrabResult* ptr10;
							try
							{
								if (ptr7 != null)
								{
									void* ptr8 = (void*)num6;
									void* ptr9 = ptr5;
									global::_003CModule_003E.Pylon_002EGrabResult_002E_007Bctor_007D((global::Pylon.GrabResult*)ptr7);
									try
									{
										((int*)ptr7)[1] = 0;
										((int*)ptr7)[2] = (int)ptr9;
										*(int*)ptr7 = (int)ptr8;
										((int*)ptr7)[4] = 2;
										((int*)ptr7)[5] = 4;
										global::_003CModule_003E.Pylon_002EGrabResultPrivate_002ESetPayloadSize((GrabResultPrivate*)ptr7, num5);
										((int*)ptr7)[3] = (int)num5;
									}
									catch
									{
										//try-fault
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<GrabResultPrivate*, void>)(&global::_003CModule_003E.Pylon_002EGrabResultPrivate_002E_007Bdtor_007D), ptr7);
										throw;
									}
									ptr10 = ptr7;
								}
								else
								{
									ptr10 = null;
								}
								MockGrabResult* ptr11 = ptr10;
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.delete(ptr7, 160u);
								throw;
							}
							MockGrabResult* ptr12 = ptr10;
							System.Runtime.CompilerServices.Unsafe.SkipInit(out CPylonDataContainer cPylonDataContainer);
							global::_003CModule_003E.Pylon_002EGrabResult_002EGetDataContainer((global::Pylon.GrabResult*)ptr10, &cPylonDataContainer);
							IDataContainer dataContainer;
							try
							{
								System.Runtime.CompilerServices.Unsafe.SkipInit(out CGrabResultPtr cGrabResultPtr);
								global::_003CModule_003E.PylonInternal_002EMockGrabResult_002EGetGrabResultPtr(ptr10, &cGrabResultPtr);
								try
								{
									dataContainer = new DataContainer(&cPylonDataContainer, &cGrabResultPtr);
									IDataContainer dataContainer2 = dataContainer;
								}
								catch
								{
									//try-fault
									global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CGrabResultPtr*, void>)(&global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bdtor_007D), &cGrabResultPtr);
									throw;
								}
								global::_003CModule_003E.Pylon_002ECGrabResultPtr_002E_007Bdtor_007D(&cGrabResultPtr);
							}
							catch
							{
								//try-fault
								global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPylonDataContainer*, void>)(&global::_003CModule_003E.Pylon_002ECPylonDataContainer_002E_007Bdtor_007D), &cPylonDataContainer);
								throw;
							}
							global::_003CModule_003E.Pylon_002ECPylonDataContainer_002E_007Bdtor_007D(&cPylonDataContainer);
							b2 = 1;
							global::_003CModule_003E.std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 112)));
							global::_003CModule_003E.std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 112)));
							b = 1;
							global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
							return dataContainer;
						}
						catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr13) != 0)
						{
							uint num7 = 0u;
							global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num3);
							try
							{
								try
								{
									InvalidArgumentException* intPtr = ptr13;
									System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
									gcstring* from_obj = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 12)))((nint)intPtr));
									Exception ex;
									try
									{
										ex = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj));
									}
									catch
									{
										//try-fault
										global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
										throw;
									}
									global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
									ex.Source = "DataContainerFactory";
									throw ex;
								}
								catch when (((Func<bool>)delegate
								{
									// Could not convert BlockContainer to single expression
									num7 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
									return (byte)num7 != 0;
								}).Invoke())
								{
								}
								if (num7 != 0)
								{
									throw;
								}
							}
							finally
							{
								global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num3, (int)num7);
							}
						}
					}
					catch
					{
						//try-fault
						if (b2 == 0)
						{
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor), &obj);
						}
						throw;
					}
					global::_003CModule_003E.std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 112)));
					global::_003CModule_003E.std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 112)));
				}
				catch
				{
					//try-fault
					if (b == 0)
					{
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					}
					throw;
				}
				global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr14) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						InvalidArgumentException* intPtr2 = ptr14;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
						gcstring* from_obj2 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring4, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr2 + 12)))((nint)intPtr2));
						Exception ex2;
						try
						{
							ex2 = new ArgumentException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj2));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
						ex2.Source = "DataContainerFactory";
						throw ex2;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr15) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						OutOfRangeException* intPtr3 = ptr15;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
						gcstring* from_obj3 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring5, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr3 + 12)))((nint)intPtr3));
						Exception ex3;
						try
						{
							ex3 = new ArgumentOutOfRangeException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj3));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
						ex3.Source = "DataContainerFactory";
						throw ex3;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr16) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						AccessException* intPtr4 = ptr16;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring6);
						gcstring* from_obj4 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring6, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr4 + 12)))((nint)intPtr4));
						Exception ex4;
						try
						{
							ex4 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj4));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring6);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring6);
						ex4.Source = "DataContainerFactory";
						throw ex4;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr17) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						GenICam_3_1_Basler_pylon.TimeoutException* intPtr5 = ptr17;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring7);
						gcstring* from_obj5 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring7, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr5 + 12)))((nint)intPtr5));
						Exception ex5;
						try
						{
							ex5 = new System.TimeoutException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj5));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring7);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring7);
						ex5.Source = "DataContainerFactory";
						throw ex5;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr18) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						LogicalErrorException* intPtr6 = ptr18;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring8);
						gcstring* from_obj6 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring8, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr6 + 12)))((nint)intPtr6));
						Exception ex6;
						try
						{
							ex6 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj6));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring8);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring8);
						ex6.Source = "DataContainerFactory";
						throw ex6;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr19) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						BadAllocException* intPtr7 = ptr19;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring9);
						gcstring* from_obj7 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring9, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr7 + 12)))((nint)intPtr7));
						Exception ex7;
						try
						{
							ex7 = new OutOfMemoryException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj7));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring9);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring9);
						ex7.Source = "DataContainerFactory";
						throw ex7;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr20) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						RuntimeException* intPtr8 = ptr20;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring10);
						gcstring* from_obj8 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring10, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr8 + 12)))((nint)intPtr8));
						Exception ex8;
						try
						{
							ex8 = new InvalidOperationException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj8));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring10);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring10);
						ex8.Source = "DataContainerFactory";
						throw ex8;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr21) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						DynamicCastException* intPtr9 = ptr21;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring11);
						gcstring* from_obj9 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring11, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr9 + 12)))((nint)intPtr9));
						Exception ex9;
						try
						{
							ex9 = new InvalidCastException(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj9));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring11);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring11);
						ex9.Source = "DataContainerFactory";
						throw ex9;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408), 9, &ptr22) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						GenericException* intPtr10 = ptr22;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring12);
						gcstring* from_obj10 = global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring12, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr10 + 12)))((nint)intPtr10));
						Exception ex10;
						try
						{
							ex10 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(from_obj10));
						}
						catch
						{
							//try-fault
							global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring12);
							throw;
						}
						global::_003CModule_003E.GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring12);
						ex10.Source = "DataContainerFactory";
						throw ex10;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			catch when (global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVexception_0040std_0040_0040_00408), 9, &ptr23) != 0)
			{
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						exception* intPtr11 = ptr23;
						Exception ex11 = new Exception(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr11 + 4)))((nint)intPtr11)));
						ex11.Source = "DataContainerFactory";
						throw ex11;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
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
				uint num8 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num4);
				try
				{
					try
					{
						Exception ex13 = new Exception("Unknown exception");
						ex13.Source = "DataContainerFactory";
						throw ex13;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num8 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num8 != 0;
					}).Invoke())
					{
					}
					if (num8 != 0)
					{
						throw;
					}
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num4, (int)num8);
				}
			}
			return null;
		}
		throw new ArgumentException("The filename must be specified.");
	}
}
