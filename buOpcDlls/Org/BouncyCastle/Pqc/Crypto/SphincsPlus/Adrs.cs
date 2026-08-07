// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.Adrs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class Adrs
{
  internal static uint WOTS_HASH = 0;
  internal static uint WOTS_PK = 1;
  internal static uint TREE = 2;
  internal static uint FORS_TREE = 3;
  internal static uint FORS_PK = 4;
  internal static uint WOTS_PRF = 5;
  internal static uint FORS_PRF = 6;
  internal static int OFFSET_LAYER = 0;
  internal static int OFFSET_TREE = 4;
  internal static int OFFSET_TREE_HGT = 24;
  internal static int OFFSET_TREE_INDEX = 28;
  internal static int OFFSET_TYPE = 16 /*0x10*/;
  internal static int OFFSET_KP_ADDR = 20;
  internal static int OFFSET_CHAIN_ADDR = 24;
  internal static int OFFSET_HASH_ADDR = 28;
  internal readonly byte[] value = new byte[32 /*0x20*/];

  internal Adrs()
  {
  }

  internal Adrs(Adrs adrs)
  {
    Array.Copy((Array) adrs.value, 0, (Array) this.value, 0, adrs.value.Length);
  }

  internal void SetLayerAddress(uint layer)
  {
    Pack.UInt32_To_BE(layer, this.value, Adrs.OFFSET_LAYER);
  }

  internal uint GetLayerAddress() => Pack.BE_To_UInt32(this.value, Adrs.OFFSET_LAYER);

  internal void SetTreeAddress(ulong tree)
  {
    Pack.UInt64_To_BE(tree, this.value, Adrs.OFFSET_TREE + 4);
  }

  internal ulong GetTreeAddress() => Pack.BE_To_UInt64(this.value, Adrs.OFFSET_TREE + 4);

  internal void SetTreeHeight(uint height)
  {
    Pack.UInt32_To_BE(height, this.value, Adrs.OFFSET_TREE_HGT);
  }

  internal uint GetTreeHeight() => Pack.BE_To_UInt32(this.value, Adrs.OFFSET_TREE_HGT);

  internal void SetTreeIndex(uint index)
  {
    Pack.UInt32_To_BE(index, this.value, Adrs.OFFSET_TREE_INDEX);
  }

  internal uint GetTreeIndex() => Pack.BE_To_UInt32(this.value, Adrs.OFFSET_TREE_INDEX);

  internal void SetAdrsType(uint adrsType)
  {
    Pack.UInt32_To_BE(adrsType, this.value, Adrs.OFFSET_TYPE);
    Arrays.Fill(this.value, Adrs.OFFSET_TYPE + 4, this.value.Length, (byte) 0);
  }

  internal void ChangeAdrsType(uint adrsType)
  {
    Pack.UInt32_To_BE(adrsType, this.value, Adrs.OFFSET_TYPE);
  }

  internal uint GetAdrsType() => Pack.BE_To_UInt32(this.value, Adrs.OFFSET_TYPE);

  internal void SetKeyPairAddress(uint keyPairAddr)
  {
    Pack.UInt32_To_BE(keyPairAddr, this.value, Adrs.OFFSET_KP_ADDR);
  }

  internal uint GetKeyPairAddress() => Pack.BE_To_UInt32(this.value, Adrs.OFFSET_KP_ADDR);

  internal void SetHashAddress(uint hashAddr)
  {
    Pack.UInt32_To_BE(hashAddr, this.value, Adrs.OFFSET_HASH_ADDR);
  }

  public void SetChainAddress(uint chainAddr)
  {
    Pack.UInt32_To_BE(chainAddr, this.value, Adrs.OFFSET_CHAIN_ADDR);
  }
}
