// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.Tree
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal sealed class Tree
{
  private static int MAX_SEED_SIZE_BYTES = 32 /*0x20*/;
  private uint MAX_AUX_BYTES;
  private uint depth;
  internal byte[][] nodes;
  private int dataSize;
  private bool[] haveNode;
  private byte[] exists;
  private uint numNodes;
  private uint numLeaves;
  private PicnicEngine engine;

  internal byte[][] GetLeaves() => this.nodes;

  internal uint GetLeavesOffset() => this.numNodes - this.numLeaves;

  internal Tree(PicnicEngine engine, uint numLeaves, int dataSize)
  {
    this.engine = engine;
    this.MAX_AUX_BYTES = (PicnicEngine.LOWMC_MAX_AND_GATES + PicnicEngine.LOWMC_MAX_KEY_BITS) / 8U + 1U;
    this.depth = PicnicUtilities.ceil_log2(numLeaves) + 1U;
    this.numNodes = (uint) ((ulong) ((1 << (int) this.depth) - 1) - ((ulong) (1 << (int) this.depth - 1) - (ulong) numLeaves));
    this.numLeaves = numLeaves;
    this.dataSize = dataSize;
    this.nodes = new byte[(int) this.numNodes][];
    for (int index = 0; (long) index < (long) this.numNodes; ++index)
      this.nodes[index] = new byte[dataSize];
    this.haveNode = new bool[(int) this.numNodes];
    this.exists = new byte[(int) this.numNodes];
    Arrays.Fill(this.exists, (int) this.numNodes - (int) this.numLeaves, (int) this.numNodes, (byte) 1);
    for (uint index = this.numNodes - this.numLeaves; index > 0U; --index)
    {
      if (this.Exists((uint) (2 * (int) index + 1)) || this.Exists((uint) (2 * (int) index + 2)))
        this.exists[(int) index] = (byte) 1;
    }
    this.exists[0] = (byte) 1;
  }

  internal void BuildMerkleTree(byte[][] leafData, byte[] salt)
  {
    uint num = this.numNodes - this.numLeaves;
    for (int index = 0; (long) index < (long) this.numLeaves; ++index)
    {
      if (leafData[index] != null)
      {
        Array.Copy((Array) leafData[index], 0, (Array) this.nodes[(long) num + (long) index], 0, this.dataSize);
        this.haveNode[(long) num + (long) index] = true;
      }
    }
    for (uint numNodes = this.numNodes; numNodes > 0U; --numNodes)
      this.ComputeParentHash(numNodes, salt);
  }

  internal int VerifyMerkleTree(byte[][] leafData, byte[] salt)
  {
    uint num = this.numNodes - this.numLeaves;
    for (int index = 0; (long) index < (long) this.numLeaves; ++index)
    {
      if (leafData[index] != null)
      {
        if (this.haveNode[(long) num + (long) index])
          return -1;
        if (leafData[index] != null)
        {
          Array.Copy((Array) leafData[index], 0, (Array) this.nodes[(long) num + (long) index], 0, this.dataSize);
          this.haveNode[(long) num + (long) index] = true;
        }
      }
    }
    for (uint numNodes = this.numNodes; numNodes > 0U; --numNodes)
      this.ComputeParentHash(numNodes, salt);
    return !this.haveNode[0] ? -1 : 0;
  }

  internal int ReconstructSeeds(
    uint[] hideList,
    uint hideListSize,
    byte[] input,
    uint inputLen,
    byte[] salt,
    uint repIndex)
  {
    int num1 = 0;
    uint num2 = inputLen;
    uint[] outputSize = new uint[1]{ 0U };
    uint[] revealedNodes = this.GetRevealedNodes(hideList, hideListSize, outputSize);
    for (int index = 0; (long) index < (long) outputSize[0]; ++index)
    {
      num2 -= (uint) this.engine.seedSizeBytes;
      Array.Copy((Array) input, index * this.engine.seedSizeBytes, (Array) this.nodes[(int) revealedNodes[index]], 0, this.engine.seedSizeBytes);
      this.haveNode[(int) revealedNodes[index]] = true;
    }
    this.ExpandSeeds(salt, repIndex);
    return num1;
  }

  internal byte[] OpenMerkleTree(
    uint[] missingLeaves,
    uint missingLeavesSize,
    int[] outputSizeBytes)
  {
    uint[] outputSize = new uint[1];
    uint[] revealedMerkleNodes = this.GetRevealedMerkleNodes(missingLeaves, missingLeavesSize, outputSize);
    outputSizeBytes[0] = (int) outputSize[0] * this.dataSize;
    byte[] destinationArray = new byte[outputSizeBytes[0]];
    byte[] numArray = destinationArray;
    for (int index = 0; (long) index < (long) outputSize[0]; ++index)
      Array.Copy((Array) this.nodes[(int) revealedMerkleNodes[index]], 0, (Array) destinationArray, index * this.dataSize, this.dataSize);
    return numArray;
  }

  private uint[] GetRevealedNodes(uint[] hideList, uint hideListSize, uint[] outputSize)
  {
    uint length = this.depth - 1U;
    uint[][] numArray = new uint[(int) length][];
    for (int index = 0; (long) index < (long) length; ++index)
      numArray[index] = new uint[(int) hideListSize];
    for (int index1 = 0; (long) index1 < (long) hideListSize; ++index1)
    {
      uint node = hideList[index1] + (this.numNodes - this.numLeaves);
      numArray[0][index1] = node;
      uint index2 = 1;
      while ((node = this.GetParent(node)) != 0U)
      {
        numArray[(int) index2][index1] = node;
        ++index2;
      }
    }
    uint[] list = new uint[(int) this.numLeaves];
    uint len = 0;
    for (int index3 = 0; (long) index3 < (long) length; ++index3)
    {
      for (int index4 = 0; (long) index4 < (long) hideListSize; ++index4)
      {
        if (this.HasSibling(numArray[index3][index4]))
        {
          uint node = this.GetSibling(numArray[index3][index4]);
          if (!this.Contains(numArray[index3], hideListSize, node))
          {
            while (!this.HasRightChild(node) && !this.IsLeafNode(node))
              node = (uint) (2 * (int) node + 1);
            if (!this.Contains(list, len, node))
            {
              list[(int) len] = node;
              ++len;
            }
          }
        }
      }
    }
    outputSize[0] = len;
    return list;
  }

  private uint GetSibling(uint node)
  {
    if (!this.IsLeftChild(node))
      return node - 1U;
    if (node + 1U < this.numNodes)
      return node + 1U;
    Console.Error.Write("getSibling: request for node with not sibling");
    return 0;
  }

  private bool IsLeafNode(uint node) => (uint) (2 * (int) node + 1) >= this.numNodes;

  private bool HasSibling(uint node)
  {
    return this.Exists(node) && (!this.IsLeftChild(node) || this.Exists(node + 1U));
  }

  internal uint RevealSeedsSize(uint[] hideList, uint hideListSize)
  {
    uint[] outputSize = new uint[1]{ 0U };
    this.GetRevealedNodes(hideList, hideListSize, outputSize);
    return outputSize[0] * (uint) this.engine.seedSizeBytes;
  }

  internal int RevealSeeds(uint[] hideList, uint hideListSize, byte[] output, int outputSize)
  {
    uint[] outputSize1 = new uint[1]{ 0U };
    int num = outputSize;
    uint[] revealedNodes = this.GetRevealedNodes(hideList, hideListSize, outputSize1);
    for (int index = 0; (long) index < (long) outputSize1[0]; ++index)
    {
      num -= this.engine.seedSizeBytes;
      if (num >= 0)
      {
        Array.Copy((Array) this.nodes[(int) revealedNodes[index]], 0, (Array) output, index * this.engine.seedSizeBytes, this.engine.seedSizeBytes);
      }
      else
      {
        Console.Error.Write("Insufficient sized buffer provided to revealSeeds");
        return 0;
      }
    }
    return output.Length - num;
  }

  internal uint OpenMerkleTreeSize(uint[] missingLeaves, uint missingLeavesSize)
  {
    uint[] outputSize = new uint[1];
    this.GetRevealedMerkleNodes(missingLeaves, missingLeavesSize, outputSize);
    return outputSize[0] * (uint) this.engine.digestSizeBytes;
  }

  private uint[] GetRevealedMerkleNodes(
    uint[] missingLeaves,
    uint missingLeavesSize,
    uint[] outputSize)
  {
    uint num = this.numNodes - this.numLeaves;
    bool[] flagArray = new bool[(int) this.numNodes];
    for (int index = 0; (long) index < (long) missingLeavesSize; ++index)
      flagArray[(int) num + (int) missingLeaves[index]] = true;
    for (uint parent = this.GetParent(this.numNodes - 1U); parent > 0U; --parent)
    {
      if (this.Exists(parent))
      {
        if (this.Exists((uint) (2 * (int) parent + 2)))
        {
          if (flagArray[2 * (int) parent + 1] && flagArray[2 * (int) parent + 2])
            flagArray[(int) parent] = true;
        }
        else if (flagArray[2 * (int) parent + 1])
          flagArray[(int) parent] = true;
      }
    }
    uint[] list = new uint[(int) this.numLeaves];
    uint len = 0;
label_19:
    for (int index = 0; (long) index < (long) missingLeavesSize; ++index)
    {
      uint node = missingLeaves[index] + num;
      while (flagArray[(int) this.GetParent(node)])
      {
        if ((node = this.GetParent(node)) == 0U)
          goto label_19;
      }
      if (!this.Contains(list, len, node))
      {
        list[(int) len] = node;
        ++len;
      }
    }
    outputSize[0] = len;
    return list;
  }

  private bool Contains(uint[] list, uint len, uint value)
  {
    for (int index = 0; (long) index < (long) len; ++index)
    {
      if ((int) list[index] == (int) value)
        return true;
    }
    return false;
  }

  private void ComputeParentHash(uint child, byte[] salt)
  {
    if (!this.Exists(child))
      return;
    uint parent = this.GetParent(child);
    if (this.haveNode[(int) parent] || !this.haveNode[2 * (int) parent + 1] || this.Exists((uint) (2 * (int) parent + 2)) && !this.haveNode[2 * (int) parent + 2])
      return;
    this.engine.digest.Update((byte) 3);
    this.engine.digest.BlockUpdate(this.nodes[2 * (int) parent + 1], 0, this.engine.digestSizeBytes);
    if (this.HasRightChild(parent))
      this.engine.digest.BlockUpdate(this.nodes[2 * (int) parent + 2], 0, this.engine.digestSizeBytes);
    this.engine.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
    this.engine.digest.BlockUpdate(Pack.UInt32_To_LE(parent), 0, 2);
    this.engine.digest.OutputFinal(this.nodes[(int) parent], 0, this.engine.digestSizeBytes);
    this.haveNode[(int) parent] = true;
  }

  internal byte[] GetLeaf(uint leafIndex)
  {
    return this.nodes[(int) (this.numNodes - this.numLeaves) + (int) leafIndex];
  }

  internal int AddMerkleNodes(
    uint[] missingLeaves,
    uint missingLeavesSize,
    byte[] input,
    uint inputSize)
  {
    int num = (int) inputSize;
    uint[] outputSize = new uint[1]{ 0U };
    uint[] revealedMerkleNodes = this.GetRevealedMerkleNodes(missingLeaves, missingLeavesSize, outputSize);
    for (int index = 0; (long) index < (long) outputSize[0]; ++index)
    {
      num -= this.dataSize;
      if (num < 0)
        return -1;
      Array.Copy((Array) input, index * this.dataSize, (Array) this.nodes[(int) revealedMerkleNodes[index]], 0, this.dataSize);
      this.haveNode[(int) revealedMerkleNodes[index]] = true;
    }
    return num != 0 ? -1 : 0;
  }

  internal void GenerateSeeds(byte[] rootSeed, byte[] salt, uint repIndex)
  {
    this.nodes[0] = rootSeed;
    this.haveNode[0] = true;
    this.ExpandSeeds(salt, repIndex);
  }

  private void ExpandSeeds(byte[] salt, uint repIndex)
  {
    byte[] numArray = new byte[2 * Tree.MAX_SEED_SIZE_BYTES];
    uint parent = this.GetParent(this.numNodes - 1U);
    for (uint nodeIndex = 0; nodeIndex <= parent; ++nodeIndex)
    {
      if (this.haveNode[(int) nodeIndex])
      {
        this.HashSeed(numArray, this.nodes[(int) nodeIndex], salt, (byte) 1, repIndex, nodeIndex);
        if (!this.haveNode[2 * (int) nodeIndex + 1])
        {
          Array.Copy((Array) numArray, 0, (Array) this.nodes[2 * (int) nodeIndex + 1], 0, this.engine.seedSizeBytes);
          this.haveNode[2 * (int) nodeIndex + 1] = true;
        }
        if (this.Exists((uint) (2 * (int) nodeIndex + 2)) && !this.haveNode[2 * (int) nodeIndex + 2])
        {
          Array.Copy((Array) numArray, this.engine.seedSizeBytes, (Array) this.nodes[2 * (int) nodeIndex + 2], 0, this.engine.seedSizeBytes);
          this.haveNode[2 * (int) nodeIndex + 2] = true;
        }
      }
    }
  }

  private void HashSeed(
    byte[] digest_arr,
    byte[] inputSeed,
    byte[] salt,
    byte hashPrefix,
    uint repIndex,
    uint nodeIndex)
  {
    this.engine.digest.Update(hashPrefix);
    this.engine.digest.BlockUpdate(inputSeed, 0, this.engine.seedSizeBytes);
    this.engine.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
    this.engine.digest.BlockUpdate(Pack.UInt16_To_LE((ushort) (repIndex & (uint) ushort.MaxValue)), 0, 2);
    this.engine.digest.BlockUpdate(Pack.UInt16_To_LE((ushort) (nodeIndex & (uint) ushort.MaxValue)), 0, 2);
    this.engine.digest.OutputFinal(digest_arr, 0, 2 * this.engine.seedSizeBytes);
  }

  private bool IsLeftChild(uint node) => node % 2U == 1U;

  private bool HasRightChild(uint node)
  {
    return (uint) (2 * (int) node + 2) < this.numNodes && this.Exists(node);
  }

  private uint GetParent(uint node) => this.IsLeftChild(node) ? (node - 1U) / 2U : (node - 2U) / 2U;

  private bool Exists(uint i) => i < this.numNodes && this.exists[(int) i] == (byte) 1;
}
