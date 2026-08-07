// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.Packing
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class Packing
{
  public static byte[] PackPublicKey(PolyVecK t1, DilithiumEngine Engine)
  {
    byte[] destinationArray = new byte[Engine.CryptoPublicKeyBytes - 32 /*0x20*/];
    for (int index = 0; index < Engine.K; ++index)
      Array.Copy((Array) t1.Vec[index].PolyT1Pack(), 0, (Array) destinationArray, index * 320, 320);
    return destinationArray;
  }

  public static PolyVecK UnpackPublicKey(PolyVecK t1, byte[] pk, DilithiumEngine Engine)
  {
    for (int index = 0; index < Engine.K; ++index)
      t1.Vec[index].PolyT1Unpack(Arrays.CopyOfRange(pk, index * 320, 32 /*0x20*/ + (index + 1) * 320));
    return t1;
  }

  public static void PackSecretKey(
    byte[] t0_,
    byte[] s1_,
    byte[] s2_,
    PolyVecK t0,
    PolyVecL s1,
    PolyVecK s2,
    DilithiumEngine Engine)
  {
    for (int index = 0; index < Engine.L; ++index)
      s1.Vec[index].PolyEtaPack(s1_, index * Engine.PolyEtaPackedBytes);
    for (int index = 0; index < Engine.K; ++index)
      s2.Vec[index].PolyEtaPack(s2_, index * Engine.PolyEtaPackedBytes);
    for (int index = 0; index < Engine.K; ++index)
      t0.Vec[index].PolyT0Pack(t0_, index * 416);
  }

  public static void UnpackSecretKey(
    PolyVecK t0,
    PolyVecL s1,
    PolyVecK s2,
    byte[] t0Enc,
    byte[] s1Enc,
    byte[] s2Enc,
    DilithiumEngine Engine)
  {
    for (int index = 0; index < Engine.L; ++index)
      s1.Vec[index].PolyEtaUnpack(s1Enc, index * Engine.PolyEtaPackedBytes);
    for (int index = 0; index < Engine.K; ++index)
      s2.Vec[index].PolyEtaUnpack(s2Enc, index * Engine.PolyEtaPackedBytes);
    for (int index = 0; index < Engine.K; ++index)
      t0.Vec[index].PolyT0Unpack(t0Enc, index * 416);
  }

  public static void PackSignature(
    byte[] sig,
    byte[] c,
    PolyVecL z,
    PolyVecK h,
    DilithiumEngine engine)
  {
    Array.Copy((Array) c, 0, (Array) sig, 0, 32 /*0x20*/);
    int num1 = 32 /*0x20*/;
    for (int index = 0; index < engine.L; ++index)
      z.Vec[index].PackZ(sig, num1 + index * engine.PolyZPackedBytes);
    int num2 = num1 + engine.L * engine.PolyZPackedBytes;
    for (int index = 0; index < engine.Omega + engine.K; ++index)
      sig[num2 + index] = (byte) 0;
    int num3 = 0;
    for (int index1 = 0; index1 < engine.K; ++index1)
    {
      for (int index2 = 0; index2 < 256 /*0x0100*/; ++index2)
      {
        if (h.Vec[index1].Coeffs[index2] != 0)
          sig[num2 + num3++] = (byte) index2;
      }
      sig[num2 + engine.Omega + index1] = (byte) num3;
    }
  }

  public static bool UnpackSignature(PolyVecL z, PolyVecK h, byte[] sig, DilithiumEngine Engine)
  {
    int num1 = 32 /*0x20*/;
    for (int index = 0; index < Engine.L; ++index)
      z.Vec[index].UnpackZ(Arrays.CopyOfRange(sig, num1 + index * Engine.PolyZPackedBytes, num1 + (index + 1) * Engine.PolyZPackedBytes));
    int num2 = num1 + Engine.L * Engine.PolyZPackedBytes;
    int num3 = 0;
    for (int index1 = 0; index1 < Engine.K; ++index1)
    {
      for (int index2 = 0; index2 < 256 /*0x0100*/; ++index2)
        h.Vec[index1].Coeffs[index2] = 0;
      if (((int) sig[num2 + Engine.Omega + index1] & (int) byte.MaxValue) < num3 || ((int) sig[num2 + Engine.Omega + index1] & (int) byte.MaxValue) > Engine.Omega)
        return false;
      for (int index3 = num3; index3 < ((int) sig[num2 + Engine.Omega + index1] & (int) byte.MaxValue); ++index3)
      {
        if (index3 > num3 && ((int) sig[num2 + index3] & (int) byte.MaxValue) <= ((int) sig[num2 + index3 - 1] & (int) byte.MaxValue))
          return false;
        h.Vec[index1].Coeffs[(int) sig[num2 + index3] & (int) byte.MaxValue] = 1;
      }
      num3 = (int) sig[num2 + Engine.Omega + index1];
    }
    for (int index = num3; index < Engine.Omega; ++index)
    {
      if (((int) sig[num2 + index] & (int) byte.MaxValue) != 0)
        return false;
    }
    return true;
  }
}
