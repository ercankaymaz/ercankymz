// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StringTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class StringTable
{
  private readonly object m_lock = new object();
  private List<string> m_strings;

  public StringTable() => this.m_strings = new List<string>();

  public StringTable(bool shared) => this.m_strings = new List<string>();

  public StringTable(IEnumerable<string> strings) => this.Update(strings);

  public object SyncRoot => this.m_lock;

  public int InstanceId => 0;

  public void Update(IEnumerable<string> strings)
  {
    if (strings == null)
      throw new ArgumentNullException(nameof (strings));
    lock (this.m_lock)
      this.m_strings = new List<string>(strings);
  }

  public int Append(string value)
  {
    if (string.IsNullOrEmpty(value))
      throw new ArgumentNullException(nameof (value));
    lock (this.m_lock)
    {
      this.m_strings.Add(value);
      return this.m_strings.Count - 1;
    }
  }

  public string GetString(uint index)
  {
    lock (this.m_lock)
      return (long) index < (long) this.m_strings.Count ? this.m_strings[(int) index] : (string) null;
  }

  public int GetIndex(string value)
  {
    lock (this.m_lock)
      return string.IsNullOrEmpty(value) ? -1 : this.m_strings.IndexOf(value);
  }

  public ushort GetIndexOrAppend(string value)
  {
    if (string.IsNullOrEmpty(value))
      throw new ArgumentNullException(nameof (value));
    lock (this.m_lock)
    {
      int indexOrAppend = this.m_strings.IndexOf(value);
      if (indexOrAppend != -1)
        return (ushort) indexOrAppend;
      this.m_strings.Add(value);
      return (ushort) (this.m_strings.Count - 1);
    }
  }

  public string[] ToArray()
  {
    lock (this.m_lock)
      return this.m_strings.ToArray();
  }

  public int Count
  {
    get
    {
      lock (this.m_lock)
        return this.m_strings.Count;
    }
  }

  public ushort[] CreateMapping(StringTable source, bool updateTable)
  {
    if (source == null)
      return (ushort[]) null;
    ushort[] mapping = new ushort[source.Count];
    for (uint index = 0; (long) index < (long) source.Count; ++index)
    {
      string str = source.GetString(index);
      int num = this.GetIndex(str);
      if (num < 0)
      {
        if (!updateTable)
        {
          mapping[(int) index] = ushort.MaxValue;
          continue;
        }
        num = this.Append(str);
      }
      mapping[(int) index] = (ushort) num;
    }
    return mapping;
  }
}
