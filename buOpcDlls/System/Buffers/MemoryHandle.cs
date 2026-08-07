// Decompiled with JetBrains decompiler
// Type: System.Buffers.MemoryHandle
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[ComVisible(true)]
[method: CLSCompliant(false)]
public struct MemoryHandle(void* pointer, GCHandle handle = default (GCHandle), IPinnable pinnable = null) : 
  IDisposable
{
  private unsafe void* _pointer = pointer;
  private GCHandle _handle = handle;
  private IPinnable _pinnable = pinnable;

  [CLSCompliant(false)]
  public unsafe void* Pointer => this._pointer;

  public unsafe void Dispose()
  {
    if (this._handle.IsAllocated)
      this._handle.Free();
    if (this._pinnable != null)
    {
      this._pinnable.Unpin();
      this._pinnable = (IPinnable) null;
    }
    this._pointer = (void*) null;
  }
}
