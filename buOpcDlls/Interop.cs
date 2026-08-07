// Decompiled with JetBrains decompiler
// Type: Interop
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
internal class Interop
{
  internal static unsafe void GetRandomBytes(byte* buffer, int length)
  {
    if (LocalAppContextSwitches.UseNonRandomizedHashSeed)
      return;
    using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
    {
      byte[] numArray = new byte[length];
      randomNumberGenerator.GetBytes(numArray);
      Marshal.Copy(numArray, 0, (IntPtr) (void*) buffer, length);
    }
  }
}
