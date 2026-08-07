// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.AbstractF2mFieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class AbstractF2mFieldElement : ECFieldElement
{
  public virtual ECFieldElement HalfTrace()
  {
    int fieldSize = this.FieldSize;
    if ((fieldSize & 1) == 0)
      throw new InvalidOperationException("Half-trace only defined for odd m");
    int i = fieldSize + 1 >> 1;
    int num1 = 31 /*0x1F*/ - Integers.NumberOfLeadingZeros(i);
    int num2 = 1;
    ECFieldElement b = (ECFieldElement) this;
    while (num1 > 0)
    {
      b = b.SquarePow(num2 << 1).Add(b);
      num2 = i >> --num1;
      if ((num2 & 1) != 0)
        b = b.SquarePow(2).Add((ECFieldElement) this);
    }
    return b;
  }

  public virtual bool HasFastTrace => false;

  public virtual int Trace()
  {
    int fieldSize = this.FieldSize;
    int num = 31 /*0x1F*/ - Integers.NumberOfLeadingZeros(fieldSize);
    int pow = 1;
    ECFieldElement b = (ECFieldElement) this;
    while (num > 0)
    {
      b = b.SquarePow(pow).Add(b);
      pow = fieldSize >> --num;
      if ((pow & 1) != 0)
        b = b.Square().Add((ECFieldElement) this);
    }
    if (b.IsZero)
      return 0;
    if (!b.IsOne)
      throw new InvalidOperationException("Internal error in trace calculation");
    return 1;
  }
}
