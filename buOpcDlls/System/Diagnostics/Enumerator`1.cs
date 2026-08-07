// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Enumerator`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis.System.Diagnostics.DiagnosticSource3462135;

#nullable disable
namespace System.Diagnostics;

internal struct Enumerator<T>(DiagNode<T> head) : IEnumerator<T>, IDisposable, IEnumerator
{
  private DiagNode<T> _nextNode = head;
  [AllowNull]
  [MaybeNull]
  private T _currentItem = default (T);

  public T Current => this._currentItem;

  object IEnumerator.Current => (object) this.Current;

  public bool MoveNext()
  {
    if (this._nextNode == null)
    {
      this._currentItem = default (T);
      return false;
    }
    this._currentItem = this._nextNode.Value;
    this._nextNode = this._nextNode.Next;
    return true;
  }

  public void Reset() => throw new NotSupportedException();

  public void Dispose()
  {
  }
}
