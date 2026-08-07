// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Bzip2.CBZip2OutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Bzip2;

public class CBZip2OutputStream : BaseOutputStream
{
  protected const int SETMASK = 2097152 /*0x200000*/;
  protected const int CLEARMASK = -2097153;
  protected const int GREATER_ICOST = 15;
  protected const int LESSER_ICOST = 0;
  protected const int SMALL_THRESH = 20;
  protected const int DEPTH_THRESH = 10;
  internal static readonly ushort[] RNums = new ushort[512 /*0x0200*/]
  {
    (ushort) 619,
    (ushort) 720,
    (ushort) sbyte.MaxValue,
    (ushort) 481,
    (ushort) 931,
    (ushort) 816,
    (ushort) 813,
    (ushort) 233,
    (ushort) 566,
    (ushort) 247,
    (ushort) 985,
    (ushort) 724,
    (ushort) 205,
    (ushort) 454,
    (ushort) 863,
    (ushort) 491,
    (ushort) 741,
    (ushort) 242,
    (ushort) 949,
    (ushort) 214,
    (ushort) 733,
    (ushort) 859,
    (ushort) 335,
    (ushort) 708,
    (ushort) 621,
    (ushort) 574,
    (ushort) 73,
    (ushort) 654,
    (ushort) 730,
    (ushort) 472,
    (ushort) 419,
    (ushort) 436,
    (ushort) 278,
    (ushort) 496,
    (ushort) 867,
    (ushort) 210,
    (ushort) 399,
    (ushort) 680,
    (ushort) 480,
    (ushort) 51,
    (ushort) 878,
    (ushort) 465,
    (ushort) 811,
    (ushort) 169,
    (ushort) 869,
    (ushort) 675,
    (ushort) 611,
    (ushort) 697,
    (ushort) 867,
    (ushort) 561,
    (ushort) 862,
    (ushort) 687,
    (ushort) 507,
    (ushort) 283,
    (ushort) 482,
    (ushort) 129,
    (ushort) 807,
    (ushort) 591,
    (ushort) 733,
    (ushort) 623,
    (ushort) 150,
    (ushort) 238,
    (ushort) 59,
    (ushort) 379,
    (ushort) 684,
    (ushort) 877,
    (ushort) 625,
    (ushort) 169,
    (ushort) 643,
    (ushort) 105,
    (ushort) 170,
    (ushort) 607,
    (ushort) 520,
    (ushort) 932,
    (ushort) 727,
    (ushort) 476,
    (ushort) 693,
    (ushort) 425,
    (ushort) 174,
    (ushort) 647,
    (ushort) 73,
    (ushort) 122,
    (ushort) 335,
    (ushort) 530,
    (ushort) 442,
    (ushort) 853,
    (ushort) 695,
    (ushort) 249,
    (ushort) 445,
    (ushort) 515,
    (ushort) 909,
    (ushort) 545,
    (ushort) 703,
    (ushort) 919,
    (ushort) 874,
    (ushort) 474,
    (ushort) 882,
    (ushort) 500,
    (ushort) 594,
    (ushort) 612,
    (ushort) 641,
    (ushort) 801,
    (ushort) 220,
    (ushort) 162,
    (ushort) 819,
    (ushort) 984,
    (ushort) 589,
    (ushort) 513,
    (ushort) 495,
    (ushort) 799,
    (ushort) 161,
    (ushort) 604,
    (ushort) 958,
    (ushort) 533,
    (ushort) 221,
    (ushort) 400,
    (ushort) 386,
    (ushort) 867,
    (ushort) 600,
    (ushort) 782,
    (ushort) 382,
    (ushort) 596,
    (ushort) 414,
    (ushort) 171,
    (ushort) 516,
    (ushort) 375,
    (ushort) 682,
    (ushort) 485,
    (ushort) 911,
    (ushort) 276,
    (ushort) 98,
    (ushort) 553,
    (ushort) 163,
    (ushort) 354,
    (ushort) 666,
    (ushort) 933,
    (ushort) 424,
    (ushort) 341,
    (ushort) 533,
    (ushort) 870,
    (ushort) 227,
    (ushort) 730,
    (ushort) 475,
    (ushort) 186,
    (ushort) 263,
    (ushort) 647,
    (ushort) 537,
    (ushort) 686,
    (ushort) 600,
    (ushort) 224 /*0xE0*/,
    (ushort) 469,
    (ushort) 68,
    (ushort) 770,
    (ushort) 919,
    (ushort) 190,
    (ushort) 373,
    (ushort) 294,
    (ushort) 822,
    (ushort) 808,
    (ushort) 206,
    (ushort) 184,
    (ushort) 943,
    (ushort) 795,
    (ushort) 384,
    (ushort) 383,
    (ushort) 461,
    (ushort) 404,
    (ushort) 758,
    (ushort) 839,
    (ushort) 887,
    (ushort) 715,
    (ushort) 67,
    (ushort) 618,
    (ushort) 276,
    (ushort) 204,
    (ushort) 918,
    (ushort) 873,
    (ushort) 777,
    (ushort) 604,
    (ushort) 560,
    (ushort) 951,
    (ushort) 160 /*0xA0*/,
    (ushort) 578,
    (ushort) 722,
    (ushort) 79,
    (ushort) 804,
    (ushort) 96 /*0x60*/,
    (ushort) 409,
    (ushort) 713,
    (ushort) 940,
    (ushort) 652,
    (ushort) 934,
    (ushort) 970,
    (ushort) 447,
    (ushort) 318,
    (ushort) 353,
    (ushort) 859,
    (ushort) 672,
    (ushort) 112 /*0x70*/,
    (ushort) 785,
    (ushort) 645,
    (ushort) 863,
    (ushort) 803,
    (ushort) 350,
    (ushort) 139,
    (ushort) 93,
    (ushort) 354,
    (ushort) 99,
    (ushort) 820,
    (ushort) 908,
    (ushort) 609,
    (ushort) 772,
    (ushort) 154,
    (ushort) 274,
    (ushort) 580,
    (ushort) 184,
    (ushort) 79,
    (ushort) 626,
    (ushort) 630,
    (ushort) 742,
    (ushort) 653,
    (ushort) 282,
    (ushort) 762,
    (ushort) 623,
    (ushort) 680,
    (ushort) 81,
    (ushort) 927,
    (ushort) 626,
    (ushort) 789,
    (ushort) 125,
    (ushort) 411,
    (ushort) 521,
    (ushort) 938,
    (ushort) 300,
    (ushort) 821,
    (ushort) 78,
    (ushort) 343,
    (ushort) 175,
    (ushort) 128 /*0x80*/,
    (ushort) 250,
    (ushort) 170,
    (ushort) 774,
    (ushort) 972,
    (ushort) 275,
    (ushort) 999,
    (ushort) 639,
    (ushort) 495,
    (ushort) 78,
    (ushort) 352,
    (ushort) 126,
    (ushort) 857,
    (ushort) 956,
    (ushort) 358,
    (ushort) 619,
    (ushort) 580,
    (ushort) 124,
    (ushort) 737,
    (ushort) 594,
    (ushort) 701,
    (ushort) 612,
    (ushort) 669,
    (ushort) 112 /*0x70*/,
    (ushort) 134,
    (ushort) 694,
    (ushort) 363,
    (ushort) 992,
    (ushort) 809,
    (ushort) 743,
    (ushort) 168,
    (ushort) 974,
    (ushort) 944,
    (ushort) 375,
    (ushort) 748,
    (ushort) 52,
    (ushort) 600,
    (ushort) 747,
    (ushort) 642,
    (ushort) 182,
    (ushort) 862,
    (ushort) 81,
    (ushort) 344,
    (ushort) 805,
    (ushort) 988,
    (ushort) 739,
    (ushort) 511 /*0x01FF*/,
    (ushort) 655,
    (ushort) 814,
    (ushort) 334,
    (ushort) 249,
    (ushort) 515,
    (ushort) 897,
    (ushort) 955,
    (ushort) 664,
    (ushort) 981,
    (ushort) 649,
    (ushort) 113,
    (ushort) 974,
    (ushort) 459,
    (ushort) 893,
    (ushort) 228,
    (ushort) 433,
    (ushort) 837,
    (ushort) 553,
    (ushort) 268,
    (ushort) 926,
    (ushort) 240 /*0xF0*/,
    (ushort) 102,
    (ushort) 654,
    (ushort) 459,
    (ushort) 51,
    (ushort) 686,
    (ushort) 754,
    (ushort) 806,
    (ushort) 760,
    (ushort) 493,
    (ushort) 403,
    (ushort) 415,
    (ushort) 394,
    (ushort) 687,
    (ushort) 700,
    (ushort) 946,
    (ushort) 670,
    (ushort) 656,
    (ushort) 610,
    (ushort) 738,
    (ushort) 392,
    (ushort) 760,
    (ushort) 799,
    (ushort) 887,
    (ushort) 653,
    (ushort) 978,
    (ushort) 321,
    (ushort) 576,
    (ushort) 617,
    (ushort) 626,
    (ushort) 502,
    (ushort) 894,
    (ushort) 679,
    (ushort) 243,
    (ushort) 440,
    (ushort) 680,
    (ushort) 879,
    (ushort) 194,
    (ushort) 572,
    (ushort) 640,
    (ushort) 724,
    (ushort) 926,
    (ushort) 56,
    (ushort) 204,
    (ushort) 700,
    (ushort) 707,
    (ushort) 151,
    (ushort) 457,
    (ushort) 449,
    (ushort) 797,
    (ushort) 195,
    (ushort) 791,
    (ushort) 558,
    (ushort) 945,
    (ushort) 679,
    (ushort) 297,
    (ushort) 59,
    (ushort) 87,
    (ushort) 824,
    (ushort) 713,
    (ushort) 663,
    (ushort) 412,
    (ushort) 693,
    (ushort) 342,
    (ushort) 606,
    (ushort) 134,
    (ushort) 108,
    (ushort) 571,
    (ushort) 364,
    (ushort) 631,
    (ushort) 212,
    (ushort) 174,
    (ushort) 643,
    (ushort) 304,
    (ushort) 329,
    (ushort) 343,
    (ushort) 97,
    (ushort) 430,
    (ushort) 751,
    (ushort) 497,
    (ushort) 314,
    (ushort) 983,
    (ushort) 374,
    (ushort) 822,
    (ushort) 928,
    (ushort) 140,
    (ushort) 206,
    (ushort) 73,
    (ushort) 263,
    (ushort) 980,
    (ushort) 736,
    (ushort) 876,
    (ushort) 478,
    (ushort) 430,
    (ushort) 305,
    (ushort) 170,
    (ushort) 514,
    (ushort) 364,
    (ushort) 692,
    (ushort) 829,
    (ushort) 82,
    (ushort) 855,
    (ushort) 953,
    (ushort) 676,
    (ushort) 246,
    (ushort) 369,
    (ushort) 970,
    (ushort) 294,
    (ushort) 750,
    (ushort) 807,
    (ushort) 827,
    (ushort) 150,
    (ushort) 790,
    (ushort) 288,
    (ushort) 923,
    (ushort) 804,
    (ushort) 378,
    (ushort) 215,
    (ushort) 828,
    (ushort) 592,
    (ushort) 281,
    (ushort) 565,
    (ushort) 555,
    (ushort) 710,
    (ushort) 82,
    (ushort) 896,
    (ushort) 831,
    (ushort) 547,
    (ushort) 261,
    (ushort) 524,
    (ushort) 462,
    (ushort) 293,
    (ushort) 465,
    (ushort) 502,
    (ushort) 56,
    (ushort) 661,
    (ushort) 821,
    (ushort) 976,
    (ushort) 991,
    (ushort) 658,
    (ushort) 869,
    (ushort) 905,
    (ushort) 758,
    (ushort) 745,
    (ushort) 193,
    (ushort) 768 /*0x0300*/,
    (ushort) 550,
    (ushort) 608,
    (ushort) 933,
    (ushort) 378,
    (ushort) 286,
    (ushort) 215,
    (ushort) 979,
    (ushort) 792,
    (ushort) 961,
    (ushort) 61,
    (ushort) 688,
    (ushort) 793,
    (ushort) 644,
    (ushort) 986,
    (ushort) 403,
    (ushort) 106,
    (ushort) 366,
    (ushort) 905,
    (ushort) 644,
    (ushort) 372,
    (ushort) 567,
    (ushort) 466,
    (ushort) 434,
    (ushort) 645,
    (ushort) 210,
    (ushort) 389,
    (ushort) 550,
    (ushort) 919,
    (ushort) 135,
    (ushort) 780,
    (ushort) 773,
    (ushort) 635,
    (ushort) 389,
    (ushort) 707,
    (ushort) 100,
    (ushort) 626,
    (ushort) 958,
    (ushort) 165,
    (ushort) 504,
    (ushort) 920,
    (ushort) 176 /*0xB0*/,
    (ushort) 193,
    (ushort) 713,
    (ushort) 857,
    (ushort) 265,
    (ushort) 203,
    (ushort) 50,
    (ushort) 668,
    (ushort) 108,
    (ushort) 645,
    (ushort) 990,
    (ushort) 626,
    (ushort) 197,
    (ushort) 510,
    (ushort) 357,
    (ushort) 358,
    (ushort) 850,
    (ushort) 858,
    (ushort) 364,
    (ushort) 936,
    (ushort) 638
  };
  private static readonly int[] Incs = new int[14]
  {
    1,
    4,
    13,
    40,
    121,
    364,
    1093,
    3280,
    9841,
    29524,
    88573,
    265720,
    797161,
    2391484
  };
  private bool finished;
  private int count;
  private int origPtr;
  private readonly int blockSize100k;
  private readonly int allowableBlockSize;
  private bool blockRandomised;
  private readonly IList<CBZip2OutputStream.StackElem> blocksortStack = (IList<CBZip2OutputStream.StackElem>) new List<CBZip2OutputStream.StackElem>();
  private int bsBuff;
  private int bsLivePos;
  private readonly CRC m_blockCrc = new CRC();
  private bool[] inUse = new bool[256 /*0x0100*/];
  private int nInUse;
  private byte[] m_selectors = new byte[18002];
  private byte[] blockBytes;
  private ushort[] quadrantShorts;
  private int[] zptr;
  private int[] szptr;
  private int[] ftab;
  private int nMTF;
  private int[] mtfFreq = new int[258];
  private int workFactor;
  private int workDone;
  private int workLimit;
  private bool firstAttempt;
  private int currentByte = -1;
  private int runLength;
  private int m_streamCrc;
  private bool closed;
  private Stream bsStream;

  protected static void HbMakeCodeLengths(byte[] len, int[] freq, int alphaSize, int maxLen)
  {
    int[] numArray1 = new int[260];
    int[] numArray2 = new int[516];
    int[] numArray3 = new int[516];
    for (int index = 0; index < alphaSize; ++index)
      numArray2[index + 1] = (freq[index] == 0 ? 1 : freq[index]) << 8;
label_38:
    int index1 = alphaSize;
    int num1 = 0;
    numArray1[0] = 0;
    numArray2[0] = 0;
    numArray3[0] = -2;
    for (int index2 = 1; index2 <= alphaSize; ++index2)
    {
      numArray3[index2] = -1;
      numArray1[++num1] = index2;
      int index3 = num1;
      int index4;
      for (index4 = numArray1[index3]; numArray2[index4] < numArray2[numArray1[index3 >> 1]]; index3 >>= 1)
        numArray1[index3] = numArray1[index3 >> 1];
      numArray1[index3] = index4;
    }
    if (num1 >= 260)
      throw new InvalidOperationException();
    while (num1 > 1)
    {
      int index5 = numArray1[1];
      int[] numArray4 = numArray1;
      int[] numArray5 = numArray1;
      int index6 = num1;
      int num2 = index6 - 1;
      int num3 = numArray5[index6];
      numArray4[1] = num3;
      int index7 = 1;
      int index8 = numArray1[1];
      while (true)
      {
        int index9 = index7 << 1;
        if (index9 <= num2)
        {
          if (index9 < num2 && numArray2[numArray1[index9 + 1]] < numArray2[numArray1[index9]])
            ++index9;
          if (numArray2[index8] >= numArray2[numArray1[index9]])
          {
            numArray1[index7] = numArray1[index9];
            index7 = index9;
          }
          else
            break;
        }
        else
          break;
      }
      numArray1[index7] = index8;
      int index10 = numArray1[1];
      int[] numArray6 = numArray1;
      int[] numArray7 = numArray1;
      int index11 = num2;
      int num4 = index11 - 1;
      int num5 = numArray7[index11];
      numArray6[1] = num5;
      int index12 = 1;
      int index13 = numArray1[1];
      while (true)
      {
        int index14 = index12 << 1;
        if (index14 <= num4)
        {
          if (index14 < num4 && numArray2[numArray1[index14 + 1]] < numArray2[numArray1[index14]])
            ++index14;
          if (numArray2[index13] >= numArray2[numArray1[index14]])
          {
            numArray1[index12] = numArray1[index14];
            index12 = index14;
          }
          else
            break;
        }
        else
          break;
      }
      numArray1[index12] = index13;
      ++index1;
      numArray3[index5] = numArray3[index10] = index1;
      numArray2[index1] = (int) (uint) (((long) numArray2[index5] & 4294967040L) + ((long) numArray2[index10] & 4294967040L)) | 1 + ((numArray2[index5] & (int) byte.MaxValue) > (numArray2[index10] & (int) byte.MaxValue) ? numArray2[index5] & (int) byte.MaxValue : numArray2[index10] & (int) byte.MaxValue);
      numArray3[index1] = -1;
      numArray1[num1 = num4 + 1] = index1;
      int index15 = num1;
      int index16;
      for (index16 = numArray1[index15]; numArray2[index16] < numArray2[numArray1[index15 >> 1]]; index15 >>= 1)
        numArray1[index15] = numArray1[index15 >> 1];
      numArray1[index15] = index16;
    }
    if (index1 >= 516)
      throw new InvalidOperationException();
    int num6 = 0;
    for (int index17 = 1; index17 <= alphaSize; ++index17)
    {
      int num7 = 0;
      int index18 = index17;
      while (numArray3[index18] >= 0)
      {
        index18 = numArray3[index18];
        ++num7;
      }
      len[index17 - 1] = (byte) num7;
      num6 |= maxLen - num7;
    }
    if (num6 >= 0)
      return;
    for (int index19 = 1; index19 <= alphaSize; ++index19)
    {
      int num8 = 1 + (numArray2[index19] >> 8) / 2;
      numArray2[index19] = num8 << 8;
    }
    goto label_38;
  }

  public CBZip2OutputStream(Stream outStream)
    : this(outStream, 9)
  {
  }

  public CBZip2OutputStream(Stream outStream, int blockSize)
  {
    this.blockBytes = (byte[]) null;
    this.quadrantShorts = (ushort[]) null;
    this.zptr = (int[]) null;
    this.ftab = (int[]) null;
    outStream.WriteByte((byte) 66);
    outStream.WriteByte((byte) 90);
    this.bsStream = outStream;
    this.bsBuff = 0;
    this.bsLivePos = 32 /*0x20*/;
    this.workFactor = 50;
    if (blockSize > 9)
      blockSize = 9;
    else if (blockSize < 1)
      blockSize = 1;
    this.blockSize100k = blockSize;
    this.allowableBlockSize = 100000 * this.blockSize100k - 20;
    int length = 100000 * this.blockSize100k;
    this.blockBytes = new byte[length + 1 + 20];
    this.quadrantShorts = new ushort[length + 1 + 20];
    this.zptr = new int[length];
    this.ftab = new int[65537 /*0x010001*/];
    this.szptr = this.zptr;
    outStream.WriteByte((byte) 104);
    outStream.WriteByte((byte) (48 /*0x30*/ + this.blockSize100k));
    this.m_streamCrc = 0;
    this.InitBlock();
  }

  public override void WriteByte(byte value)
  {
    if (this.currentByte == (int) value)
    {
      if (++this.runLength <= 254)
        return;
      this.WriteRun();
      this.currentByte = -1;
      this.runLength = 0;
    }
    else
    {
      if (this.currentByte >= 0)
        this.WriteRun();
      this.currentByte = (int) value;
      this.runLength = 1;
    }
  }

  private void WriteRun()
  {
    if (this.count > this.allowableBlockSize)
    {
      this.EndBlock();
      this.InitBlock();
    }
    this.inUse[this.currentByte] = true;
    switch (this.runLength)
    {
      case 1:
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.m_blockCrc.Update((byte) this.currentByte);
        break;
      case 2:
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.m_blockCrc.Update((byte) this.currentByte);
        this.m_blockCrc.Update((byte) this.currentByte);
        break;
      case 3:
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.m_blockCrc.Update((byte) this.currentByte);
        this.m_blockCrc.Update((byte) this.currentByte);
        this.m_blockCrc.Update((byte) this.currentByte);
        break;
      default:
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) this.currentByte;
        this.blockBytes[++this.count] = (byte) (this.runLength - 4);
        this.inUse[this.runLength - 4] = true;
        this.m_blockCrc.UpdateRun((byte) this.currentByte, this.runLength);
        break;
    }
  }

  protected void Detach(bool disposing)
  {
    if (disposing)
      this.ImplDisposing(false);
    base.Dispose(disposing);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.ImplDisposing(true);
    base.Dispose(disposing);
  }

  private void ImplDisposing(bool disposeOutput)
  {
    if (this.closed)
      return;
    this.Finish();
    this.closed = true;
    if (!disposeOutput)
      return;
    this.bsStream.Dispose();
  }

  public void Finish()
  {
    if (this.finished)
      return;
    if (this.runLength > 0)
      this.WriteRun();
    this.currentByte = -1;
    if (this.count > 0)
      this.EndBlock();
    this.EndCompression();
    this.finished = true;
    this.Flush();
  }

  public override void Flush() => this.bsStream.Flush();

  private void InitBlock()
  {
    this.m_blockCrc.Initialise();
    this.count = 0;
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.inUse[index] = false;
  }

  private void EndBlock()
  {
    int final = this.m_blockCrc.GetFinal();
    this.m_streamCrc = Integers.RotateLeft(this.m_streamCrc, 1) ^ final;
    this.DoReversibleTransformation();
    this.BsPutLong48(54156738319193L);
    this.BsPutInt32(final);
    this.BsPutBit(this.blockRandomised ? 1 : 0);
    this.MoveToFrontCodeAndSend();
  }

  private void EndCompression()
  {
    this.BsPutLong48(25779555029136L);
    this.BsPutInt32(this.m_streamCrc);
    this.BsFinishedWithStream();
  }

  private void HbAssignCodes(int[] code, byte[] length, int minLen, int maxLen, int alphaSize)
  {
    int num = 0;
    for (int index1 = minLen; index1 <= maxLen; ++index1)
    {
      for (int index2 = 0; index2 < alphaSize; ++index2)
      {
        if ((int) length[index2] == index1)
          code[index2] = num++;
      }
      num <<= 1;
    }
  }

  private void BsFinishedWithStream()
  {
    if (this.bsLivePos >= 32 /*0x20*/)
      return;
    this.bsStream.WriteByte((byte) (this.bsBuff >> 24));
    this.bsBuff = 0;
    this.bsLivePos = 32 /*0x20*/;
  }

  private void BsPutBit(int v)
  {
    --this.bsLivePos;
    this.bsBuff |= v << this.bsLivePos;
    if (this.bsLivePos > 24)
      return;
    this.bsStream.WriteByte((byte) (this.bsBuff >> 24));
    this.bsBuff <<= 8;
    this.bsLivePos += 8;
  }

  private void BsPutBits(int n, int v)
  {
    this.bsLivePos -= n;
    this.bsBuff |= v << this.bsLivePos;
    for (; this.bsLivePos <= 24; this.bsLivePos += 8)
    {
      this.bsStream.WriteByte((byte) (this.bsBuff >> 24));
      this.bsBuff <<= 8;
    }
  }

  private void BsPutBitsSmall(int n, int v)
  {
    this.bsLivePos -= n;
    this.bsBuff |= v << this.bsLivePos;
    if (this.bsLivePos > 24)
      return;
    this.bsStream.WriteByte((byte) (this.bsBuff >> 24));
    this.bsBuff <<= 8;
    this.bsLivePos += 8;
  }

  private void BsPutInt32(int u)
  {
    this.BsPutBits(16 /*0x10*/, u >> 16 /*0x10*/ & (int) ushort.MaxValue);
    this.BsPutBits(16 /*0x10*/, u & (int) ushort.MaxValue);
  }

  private void BsPutLong48(long u)
  {
    this.BsPutBits(24, (int) (u >> 24) & 16777215 /*0xFFFFFF*/);
    this.BsPutBits(24, (int) u & 16777215 /*0xFFFFFF*/);
  }

  private void SendMtfValues()
  {
    int num1 = this.nInUse + 2;
    if (this.nMTF <= 0)
      throw new InvalidOperationException();
    int num2 = this.nMTF >= 200 ? (this.nMTF >= 600 ? (this.nMTF >= 1200 ? (this.nMTF >= 2400 ? 6 : 5) : 4) : 3) : 2;
    byte[][] byteArray = CBZip2OutputStream.CreateByteArray(num2, num1);
    for (int index = 0; index < num2; ++index)
      Arrays.Fill(byteArray[index], (byte) 15);
    int num3 = num2;
    int nMtf = this.nMTF;
    int num4 = -1;
    while (num3 > 0)
    {
      int num5 = num4 + 1;
      int num6 = 0;
      int num7 = nMtf / num3;
      while (num6 < num7 && num4 < num1 - 1)
        num6 += this.mtfFreq[++num4];
      if (num4 > num5 && num3 != num2 && num3 != 1 && (num2 - num3) % 2 == 1)
        num6 -= this.mtfFreq[num4--];
      byte[] numArray = byteArray[num3 - 1];
      for (int index = 0; index < num1; ++index)
        numArray[index] = index < num5 || index > num4 ? (byte) 15 : (byte) 0;
      --num3;
      nMtf -= num6;
    }
    int[][] intArray1 = CBZip2InputStream.CreateIntArray(6, 258);
    int[] numArray1 = new int[6];
    short[] numArray2 = new short[6];
    int v = 0;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < num2; ++index2)
      {
        numArray1[index2] = 0;
        int[] numArray3 = intArray1[index2];
        for (int index3 = 0; index3 < num1; ++index3)
          numArray3[index3] = 0;
      }
      v = 0;
      int num8;
      for (int index4 = 0; index4 < this.nMTF; index4 = num8 + 1)
      {
        num8 = Math.Min(index4 + 50 - 1, this.nMTF - 1);
        if (num2 == 6)
        {
          byte[] numArray4 = byteArray[0];
          byte[] numArray5 = byteArray[1];
          byte[] numArray6 = byteArray[2];
          byte[] numArray7 = byteArray[3];
          byte[] numArray8 = byteArray[4];
          byte[] numArray9 = byteArray[5];
          short num9 = 0;
          short num10 = 0;
          short num11 = 0;
          short num12 = 0;
          short num13 = 0;
          short num14 = 0;
          for (int index5 = index4; index5 <= num8; ++index5)
          {
            int index6 = this.szptr[index5];
            num9 += (short) numArray4[index6];
            num10 += (short) numArray5[index6];
            num11 += (short) numArray6[index6];
            num12 += (short) numArray7[index6];
            num13 += (short) numArray8[index6];
            num14 += (short) numArray9[index6];
          }
          numArray2[0] = num9;
          numArray2[1] = num10;
          numArray2[2] = num11;
          numArray2[3] = num12;
          numArray2[4] = num13;
          numArray2[5] = num14;
        }
        else
        {
          for (int index7 = 0; index7 < num2; ++index7)
            numArray2[index7] = (short) 0;
          for (int index8 = index4; index8 <= num8; ++index8)
          {
            int index9 = this.szptr[index8];
            for (int index10 = 0; index10 < num2; ++index10)
              numArray2[index10] += (short) byteArray[index10][index9];
          }
        }
        int num15 = (int) numArray2[0];
        int index11 = 0;
        for (int index12 = 1; index12 < num2; ++index12)
        {
          short num16 = numArray2[index12];
          if ((int) num16 < num15)
          {
            num15 = (int) num16;
            index11 = index12;
          }
        }
        ++numArray1[index11];
        this.m_selectors[v] = (byte) index11;
        ++v;
        int[] numArray10 = intArray1[index11];
        for (int index13 = index4; index13 <= num8; ++index13)
          ++numArray10[this.szptr[index13]];
      }
      for (int index14 = 0; index14 < num2; ++index14)
        CBZip2OutputStream.HbMakeCodeLengths(byteArray[index14], intArray1[index14], num1, 17);
    }
    if (num2 >= 8 || num2 > 6)
      throw new InvalidOperationException();
    if (v >= 32768 /*0x8000*/ || v > 18002)
      throw new InvalidOperationException();
    int[][] intArray2 = CBZip2InputStream.CreateIntArray(6, 258);
    for (int index15 = 0; index15 < num2; ++index15)
    {
      int num17 = 0;
      int num18 = 32 /*0x20*/;
      byte[] length = byteArray[index15];
      for (int index16 = 0; index16 < num1; ++index16)
      {
        int val2 = (int) length[index16];
        num17 = Math.Max(num17, val2);
        num18 = Math.Min(num18, val2);
      }
      if (num18 < 1 | num17 > 17)
        throw new InvalidOperationException();
      this.HbAssignCodes(intArray2[index15], length, num18, num17, num1);
    }
    bool[] flagArray = new bool[16 /*0x10*/];
    for (int index17 = 0; index17 < 16 /*0x10*/; ++index17)
    {
      flagArray[index17] = false;
      int num19 = index17 * 16 /*0x10*/;
      for (int index18 = 0; index18 < 16 /*0x10*/; ++index18)
      {
        if (this.inUse[num19 + index18])
        {
          flagArray[index17] = true;
          break;
        }
      }
    }
    for (int index = 0; index < 16 /*0x10*/; ++index)
      this.BsPutBit(flagArray[index] ? 1 : 0);
    for (int index19 = 0; index19 < 16 /*0x10*/; ++index19)
    {
      if (flagArray[index19])
      {
        int num20 = index19 * 16 /*0x10*/;
        for (int index20 = 0; index20 < 16 /*0x10*/; ++index20)
          this.BsPutBit(this.inUse[num20 + index20] ? 1 : 0);
      }
    }
    this.BsPutBitsSmall(3, num2);
    this.BsPutBits(15, v);
    int num21 = 6636321;
    for (int index = 0; index < v; ++index)
    {
      int num22 = (int) this.m_selectors[index] << 2;
      int n = num21 >> num22 & 15;
      if (n != 1)
      {
        int num23 = 8947848 /*0x888888*/ - num21 + 1118481 /*0x111111*/ * n & 8947848 /*0x888888*/;
        num21 = num21 - (n << num22) + (num23 >> 3);
      }
      this.BsPutBitsSmall(n, (1 << n) - 2);
    }
    for (int index21 = 0; index21 < num2; ++index21)
    {
      byte[] numArray11 = byteArray[index21];
      int num24 = (int) numArray11[0];
      this.BsPutBitsSmall(6, num24 << 1);
      for (int index22 = 1; index22 < num1; ++index22)
      {
        int num25;
        for (num25 = (int) numArray11[index22]; num24 < num25; ++num24)
          this.BsPutBitsSmall(2, 2);
        for (; num24 > num25; --num24)
          this.BsPutBitsSmall(2, 3);
        this.BsPutBit(0);
      }
    }
    int index23 = 0;
    int num26 = 0;
    while (num26 < this.nMTF)
    {
      int num27 = Math.Min(num26 + 50 - 1, this.nMTF - 1);
      int selector = (int) this.m_selectors[index23];
      byte[] numArray12 = byteArray[selector];
      int[] numArray13 = intArray2[selector];
      for (int index24 = num26; index24 <= num27; ++index24)
      {
        int index25 = this.szptr[index24];
        this.BsPutBits((int) numArray12[index25], numArray13[index25]);
      }
      num26 = num27 + 1;
      ++index23;
    }
    if (index23 != v)
      throw new InvalidOperationException();
  }

  private void MoveToFrontCodeAndSend()
  {
    this.BsPutBits(24, this.origPtr);
    this.GenerateMtfValues();
    this.SendMtfValues();
  }

  private void SimpleSort(int lo, int hi, int d)
  {
    int num1 = hi - lo + 1;
    if (num1 < 2)
      return;
    int index1 = 0;
    while (CBZip2OutputStream.Incs[index1] < num1)
      ++index1;
    for (int index2 = index1 - 1; index2 >= 0; --index2)
    {
      int inc = CBZip2OutputStream.Incs[index2];
      int index3 = lo + inc;
      while (index3 <= hi)
      {
        int num2 = this.zptr[index3];
        int index4 = index3;
        while (this.FullGtU(this.zptr[index4 - inc] + d, num2 + d))
        {
          this.zptr[index4] = this.zptr[index4 - inc];
          index4 -= inc;
          if (index4 <= lo + inc - 1)
            break;
        }
        this.zptr[index4] = num2;
        int index5;
        if ((index5 = index3 + 1) <= hi)
        {
          int num3 = this.zptr[index5];
          int index6 = index5;
          while (this.FullGtU(this.zptr[index6 - inc] + d, num3 + d))
          {
            this.zptr[index6] = this.zptr[index6 - inc];
            index6 -= inc;
            if (index6 <= lo + inc - 1)
              break;
          }
          this.zptr[index6] = num3;
          int index7;
          if ((index7 = index5 + 1) <= hi)
          {
            int num4 = this.zptr[index7];
            int index8 = index7;
            while (this.FullGtU(this.zptr[index8 - inc] + d, num4 + d))
            {
              this.zptr[index8] = this.zptr[index8 - inc];
              index8 -= inc;
              if (index8 <= lo + inc - 1)
                break;
            }
            this.zptr[index8] = num4;
            index3 = index7 + 1;
            if (this.workDone > this.workLimit && this.firstAttempt)
              return;
          }
          else
            break;
        }
        else
          break;
      }
    }
  }

  private void Vswap(int p1, int p2, int n)
  {
    while (--n >= 0)
    {
      int num1 = this.zptr[p1];
      int num2 = this.zptr[p2];
      this.zptr[p1++] = num2;
      this.zptr[p2++] = num1;
    }
  }

  private int Med3(int a, int b, int c)
  {
    if (a <= b)
    {
      if (c < a)
        return a;
      return c <= b ? c : b;
    }
    if (c < b)
      return b;
    return c <= a ? c : a;
  }

  private static void PushStackElem(
    IList<CBZip2OutputStream.StackElem> stack,
    int stackCount,
    int ll,
    int hh,
    int dd)
  {
    CBZip2OutputStream.StackElem stackElem;
    if (stackCount < stack.Count)
    {
      stackElem = stack[stackCount];
    }
    else
    {
      stackElem = new CBZip2OutputStream.StackElem();
      stack.Add(stackElem);
    }
    stackElem.ll = ll;
    stackElem.hh = hh;
    stackElem.dd = dd;
  }

  private void QSort3(int loSt, int hiSt, int dSt)
  {
    IList<CBZip2OutputStream.StackElem> blocksortStack = this.blocksortStack;
    int num1 = 0;
    int index1 = loSt;
    int hi = hiSt;
    int d = dSt;
    while (true)
    {
      CBZip2OutputStream.StackElem stackElem;
      for (; hi - index1 < 20 || d > 10; d = stackElem.dd)
      {
        this.SimpleSort(index1, hi, d);
        if (num1 < 1 || this.workDone > this.workLimit && this.firstAttempt)
          return;
        stackElem = blocksortStack[--num1];
        index1 = stackElem.ll;
        hi = stackElem.hh;
      }
      int num2 = d + 1;
      int num3 = this.Med3((int) this.blockBytes[this.zptr[index1] + num2], (int) this.blockBytes[this.zptr[hi] + num2], (int) this.blockBytes[this.zptr[index1 + hi >> 1] + num2]);
      int index2;
      int p1 = index2 = index1;
      int index3;
      int index4 = index3 = hi;
      while (true)
      {
        for (; p1 <= index4; ++p1)
        {
          int num4 = this.zptr[p1];
          int num5 = (int) this.blockBytes[num4 + num2] - num3;
          if (num5 <= 0)
          {
            if (num5 == 0)
            {
              this.zptr[p1] = this.zptr[index2];
              this.zptr[index2++] = num4;
            }
          }
          else
            break;
        }
        for (; p1 <= index4; --index4)
        {
          int num6 = this.zptr[index4];
          int num7 = (int) this.blockBytes[num6 + num2] - num3;
          if (num7 >= 0)
          {
            if (num7 == 0)
            {
              this.zptr[index4] = this.zptr[index3];
              this.zptr[index3--] = num6;
            }
          }
          else
            break;
        }
        if (p1 <= index4)
        {
          int num8 = this.zptr[p1];
          this.zptr[p1++] = this.zptr[index4];
          this.zptr[index4--] = num8;
        }
        else
          break;
      }
      if (index3 < index2)
      {
        d = num2;
      }
      else
      {
        int n1 = Math.Min(index2 - index1, p1 - index2);
        this.Vswap(index1, p1 - n1, n1);
        int n2 = Math.Min(hi - index3, index3 - index4);
        this.Vswap(p1, hi - n2 + 1, n2);
        int num9 = index1 + (p1 - index2);
        int num10 = hi - (index3 - index4);
        IList<CBZip2OutputStream.StackElem> stack1 = blocksortStack;
        int stackCount1 = num1;
        int num11 = stackCount1 + 1;
        int ll1 = index1;
        int hh1 = num9 - 1;
        int dd1 = d;
        CBZip2OutputStream.PushStackElem(stack1, stackCount1, ll1, hh1, dd1);
        IList<CBZip2OutputStream.StackElem> stack2 = blocksortStack;
        int stackCount2 = num11;
        num1 = stackCount2 + 1;
        int ll2 = num9;
        int hh2 = num10;
        int dd2 = num2;
        CBZip2OutputStream.PushStackElem(stack2, stackCount2, ll2, hh2, dd2);
        index1 = num10 + 1;
      }
    }
  }

  private void MainSort()
  {
    int[] numArray1 = new int[256 /*0x0100*/];
    int[] numArray2 = new int[256 /*0x0100*/];
    bool[] flagArray = new bool[256 /*0x0100*/];
    for (int index = 0; index < 20; ++index)
      this.blockBytes[this.count + index + 1] = this.blockBytes[index % this.count + 1];
    for (int index = 0; index <= this.count + 20; ++index)
      this.quadrantShorts[index] = (ushort) 0;
    this.blockBytes[0] = this.blockBytes[this.count];
    if (this.count <= 4000)
    {
      for (int index = 0; index < this.count; ++index)
        this.zptr[index] = index;
      this.firstAttempt = false;
      this.workLimit = 0;
      this.workDone = 0;
      this.SimpleSort(0, this.count - 1, 0);
    }
    else
    {
      for (int index = 0; index <= (int) byte.MaxValue; ++index)
        flagArray[index] = false;
      for (int index = 0; index <= 65536 /*0x010000*/; ++index)
        this.ftab[index] = 0;
      int num1 = (int) this.blockBytes[0];
      for (int index = 1; index <= this.count; ++index)
      {
        int blockByte = (int) this.blockBytes[index];
        ++this.ftab[(num1 << 8) + blockByte];
        num1 = blockByte;
      }
      for (int index = 0; index < 65536 /*0x010000*/; ++index)
        this.ftab[index + 1] += this.ftab[index];
      int num2 = (int) this.blockBytes[1];
      for (int index1 = 0; index1 < this.count - 1; ++index1)
      {
        int blockByte = (int) this.blockBytes[index1 + 2];
        int index2 = (num2 << 8) + blockByte;
        num2 = blockByte;
        --this.ftab[index2];
        this.zptr[this.ftab[index2]] = index1;
      }
      int index3 = ((int) this.blockBytes[this.count] << 8) + (int) this.blockBytes[1];
      --this.ftab[index3];
      this.zptr[this.ftab[index3]] = this.count - 1;
      for (int index4 = 0; index4 <= (int) byte.MaxValue; ++index4)
        numArray1[index4] = index4;
      int num3 = 1;
      do
      {
        num3 = 3 * num3 + 1;
      }
      while (num3 <= 256 /*0x0100*/);
      do
      {
        num3 /= 3;
        for (int index5 = num3; index5 <= (int) byte.MaxValue; ++index5)
        {
          int num4 = numArray1[index5];
          int index6 = index5;
          while (this.ftab[numArray1[index6 - num3] + 1 << 8] - this.ftab[numArray1[index6 - num3] << 8] > this.ftab[num4 + 1 << 8] - this.ftab[num4 << 8])
          {
            numArray1[index6] = numArray1[index6 - num3];
            index6 -= num3;
            if (index6 < num3)
              break;
          }
          numArray1[index6] = num4;
        }
      }
      while (num3 != 1);
      for (int index7 = 0; index7 <= (int) byte.MaxValue; ++index7)
      {
        int index8 = numArray1[index7];
        for (int index9 = 0; index9 <= (int) byte.MaxValue; ++index9)
        {
          int index10 = (index8 << 8) + index9;
          if ((this.ftab[index10] & 2097152 /*0x200000*/) != 2097152 /*0x200000*/)
          {
            int loSt = this.ftab[index10] & -2097153;
            int hiSt = (this.ftab[index10 + 1] & -2097153) - 1;
            if (hiSt > loSt)
            {
              this.QSort3(loSt, hiSt, 2);
              if (this.workDone > this.workLimit && this.firstAttempt)
                return;
            }
            this.ftab[index10] |= 2097152 /*0x200000*/;
          }
        }
        flagArray[index8] = true;
        if (index7 < (int) byte.MaxValue)
        {
          int num5 = this.ftab[index8 << 8] & -2097153;
          int num6 = (this.ftab[index8 + 1 << 8] & -2097153) - num5;
          int num7 = 0;
          while (num6 >> num7 > 65534)
            ++num7;
          for (int index11 = 0; index11 < num6; ++index11)
          {
            int index12 = this.zptr[num5 + index11] + 1;
            ushort num8 = (ushort) (index11 >> num7);
            this.quadrantShorts[index12] = num8;
            if (index12 <= 20)
              this.quadrantShorts[index12 + this.count] = num8;
          }
          if (num6 - 1 >> num7 > (int) ushort.MaxValue)
            throw new InvalidOperationException();
        }
        for (int index13 = 0; index13 <= (int) byte.MaxValue; ++index13)
          numArray2[index13] = this.ftab[(index13 << 8) + index8] & -2097153;
        for (int index14 = this.ftab[index8 << 8] & -2097153; index14 < (this.ftab[index8 + 1 << 8] & -2097153); ++index14)
        {
          int index15 = this.zptr[index14];
          int blockByte = (int) this.blockBytes[index15];
          if (!flagArray[blockByte])
          {
            this.zptr[numArray2[blockByte]] = (index15 == 0 ? this.count : index15) - 1;
            ++numArray2[blockByte];
          }
        }
        for (int index16 = 0; index16 <= (int) byte.MaxValue; ++index16)
          this.ftab[(index16 << 8) + index8] |= 2097152 /*0x200000*/;
      }
    }
  }

  private void RandomiseBlock()
  {
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      this.inUse[index] = false;
    int num1 = 0;
    int num2 = 0;
    for (int index1 = 1; index1 <= this.count; ++index1)
    {
      if (num1 == 0)
      {
        ushort[] rnums = CBZip2OutputStream.RNums;
        int index2 = num2;
        int num3 = index2 + 1;
        num1 = (int) rnums[index2];
        num2 = num3 & 511 /*0x01FF*/;
      }
      --num1;
      this.blockBytes[index1] ^= num1 == 1 ? (byte) 1 : (byte) 0;
      this.inUse[(int) this.blockBytes[index1]] = true;
    }
  }

  private void DoReversibleTransformation()
  {
    this.workLimit = this.workFactor * (this.count - 1);
    this.workDone = 0;
    this.blockRandomised = false;
    this.firstAttempt = true;
    this.MainSort();
    if (this.workDone > this.workLimit && this.firstAttempt)
    {
      this.RandomiseBlock();
      this.workDone = 0;
      this.workLimit = 0;
      this.blockRandomised = true;
      this.firstAttempt = false;
      this.MainSort();
    }
    this.origPtr = -1;
    for (int index = 0; index < this.count; ++index)
    {
      if (this.zptr[index] == 0)
      {
        this.origPtr = index;
        break;
      }
    }
    if (this.origPtr == -1)
      throw new InvalidOperationException();
  }

  private bool FullGtU(int i1, int i2)
  {
    int blockByte1 = (int) this.blockBytes[++i1];
    int blockByte2 = (int) this.blockBytes[++i2];
    if (blockByte1 != blockByte2)
      return blockByte1 > blockByte2;
    int blockByte3 = (int) this.blockBytes[++i1];
    int blockByte4 = (int) this.blockBytes[++i2];
    if (blockByte3 != blockByte4)
      return blockByte3 > blockByte4;
    int blockByte5 = (int) this.blockBytes[++i1];
    int blockByte6 = (int) this.blockBytes[++i2];
    if (blockByte5 != blockByte6)
      return blockByte5 > blockByte6;
    int blockByte7 = (int) this.blockBytes[++i1];
    int blockByte8 = (int) this.blockBytes[++i2];
    if (blockByte7 != blockByte8)
      return blockByte7 > blockByte8;
    int blockByte9 = (int) this.blockBytes[++i1];
    int blockByte10 = (int) this.blockBytes[++i2];
    if (blockByte9 != blockByte10)
      return blockByte9 > blockByte10;
    int blockByte11 = (int) this.blockBytes[++i1];
    int blockByte12 = (int) this.blockBytes[++i2];
    if (blockByte11 != blockByte12)
      return blockByte11 > blockByte12;
    int count = this.count;
    int quadrantShort1;
    int quadrantShort2;
    int blockByte13;
    int blockByte14;
    int quadrantShort3;
    int quadrantShort4;
    int blockByte15;
    int blockByte16;
    int quadrantShort5;
    int quadrantShort6;
    int blockByte17;
    int blockByte18;
    int quadrantShort7;
    int quadrantShort8;
    int blockByte19;
    int blockByte20;
    do
    {
      blockByte19 = (int) this.blockBytes[++i1];
      blockByte20 = (int) this.blockBytes[++i2];
      if (blockByte19 == blockByte20)
      {
        quadrantShort1 = (int) this.quadrantShorts[i1];
        quadrantShort2 = (int) this.quadrantShorts[i2];
        if (quadrantShort1 == quadrantShort2)
        {
          blockByte13 = (int) this.blockBytes[++i1];
          blockByte14 = (int) this.blockBytes[++i2];
          if (blockByte13 == blockByte14)
          {
            quadrantShort3 = (int) this.quadrantShorts[i1];
            quadrantShort4 = (int) this.quadrantShorts[i2];
            if (quadrantShort3 == quadrantShort4)
            {
              blockByte15 = (int) this.blockBytes[++i1];
              blockByte16 = (int) this.blockBytes[++i2];
              if (blockByte15 == blockByte16)
              {
                quadrantShort5 = (int) this.quadrantShorts[i1];
                quadrantShort6 = (int) this.quadrantShorts[i2];
                if (quadrantShort5 == quadrantShort6)
                {
                  blockByte17 = (int) this.blockBytes[++i1];
                  blockByte18 = (int) this.blockBytes[++i2];
                  if (blockByte17 == blockByte18)
                  {
                    quadrantShort7 = (int) this.quadrantShorts[i1];
                    quadrantShort8 = (int) this.quadrantShorts[i2];
                    if (quadrantShort7 == quadrantShort8)
                    {
                      if (i1 >= this.count)
                        i1 -= this.count;
                      if (i2 >= this.count)
                        i2 -= this.count;
                      count -= 4;
                      ++this.workDone;
                    }
                    else
                      goto label_33;
                  }
                  else
                    goto label_32;
                }
                else
                  goto label_31;
              }
              else
                goto label_30;
            }
            else
              goto label_29;
          }
          else
            goto label_28;
        }
        else
          goto label_27;
      }
      else
        goto label_26;
    }
    while (count >= 0);
    goto label_34;
label_26:
    return blockByte19 > blockByte20;
label_27:
    return quadrantShort1 > quadrantShort2;
label_28:
    return blockByte13 > blockByte14;
label_29:
    return quadrantShort3 > quadrantShort4;
label_30:
    return blockByte15 > blockByte16;
label_31:
    return quadrantShort5 > quadrantShort6;
label_32:
    return blockByte17 > blockByte18;
label_33:
    return quadrantShort7 > quadrantShort8;
label_34:
    return false;
  }

  private void GenerateMtfValues()
  {
    this.nInUse = 0;
    byte[] numArray = new byte[256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
    {
      if (this.inUse[index])
        numArray[this.nInUse++] = (byte) index;
    }
    int index1 = this.nInUse + 1;
    for (int index2 = 0; index2 <= index1; ++index2)
      this.mtfFreq[index2] = 0;
    int num1 = 0;
    int num2 = 0;
    for (int index3 = 0; index3 < this.count; ++index3)
    {
      byte blockByte = this.blockBytes[this.zptr[index3]];
      byte num3 = numArray[0];
      if ((int) blockByte == (int) num3)
      {
        ++num2;
      }
      else
      {
        int index4 = 1;
        do
        {
          byte num4 = num3;
          num3 = numArray[index4];
          numArray[index4++] = num4;
        }
        while ((int) blockByte != (int) num3);
        numArray[0] = num3;
        int num5;
        for (; num2 > 0; num2 = num5 >> 1)
        {
          int index5 = (num5 = num2 - 1) & 1;
          this.szptr[num1++] = index5;
          ++this.mtfFreq[index5];
        }
        this.szptr[num1++] = index4;
        ++this.mtfFreq[index4];
      }
    }
    int num6;
    for (; num2 > 0; num2 = num6 >> 1)
    {
      int index6 = (num6 = num2 - 1) & 1;
      this.szptr[num1++] = index6;
      ++this.mtfFreq[index6];
    }
    int[] szptr = this.szptr;
    int index7 = num1;
    int num7 = index7 + 1;
    int num8 = index1;
    szptr[index7] = num8;
    ++this.mtfFreq[index1];
    this.nMTF = num7;
  }

  internal static byte[][] CreateByteArray(int n1, int n2)
  {
    byte[][] byteArray = new byte[n1][];
    for (int index = 0; index < n1; ++index)
      byteArray[index] = new byte[n2];
    return byteArray;
  }

  internal class StackElem
  {
    internal int ll;
    internal int hh;
    internal int dd;
  }
}
