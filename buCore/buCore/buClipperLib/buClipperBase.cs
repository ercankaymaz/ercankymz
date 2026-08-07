// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.buClipperBase
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns10;
using ns6;
using ns7;
using ns9;
using System.Collections.Generic;

#nullable disable
namespace buCore.buClipperLib;

public class buClipperBase
{
  public const long loRange = 1073741823 /*0x3FFFFFFF*/;
  public const long hiRange = 4611686018427387903 /*0x3FFFFFFFFFFFFFFF*/;
  internal Class23 class23_0;
  internal Class23 class23_1;
  internal List<List<Class22>> list_0 = new List<List<Class22>>();
  internal Class24 class24_0;
  internal List<Class26> list_1;
  internal Class22 class22_0;
  internal bool bool_0;
  internal bool bool_1;

  public bool PreserveCollinear { get; set; }

  public void Swap(ref long val1, ref long val2)
  {
    long num = val1;
    val1 = val2;
    val2 = num;
  }

  internal buClipperBase()
  {
    this.class23_0 = (Class23) null;
    this.class23_1 = (Class23) null;
    this.bool_0 = false;
    this.bool_1 = false;
  }

  public virtual void Clear()
  {
    Class30.smethod_286(this);
    for (int index1 = 0; index1 < this.list_0.Count; ++index1)
    {
      for (int index2 = 0; index2 < this.list_0[index1].Count; ++index2)
        this.list_0[index1][index2] = (Class22) null;
      this.list_0[index1].Clear();
    }
    this.list_0.Clear();
    this.bool_0 = false;
    this.bool_1 = false;
  }

  public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
  {
    if ((Closed ? 0 : (polyType == PolyType.ptClip ? 1 : 0)) != 0)
      throw new Exception0("AddPath: Open paths must be subject.");
    int index1 = pg.Count - 1;
    if (Closed)
    {
      while ((index1 <= 0 ? 0 : (pg[index1] == pg[0] ? 1 : 0)) != 0)
        --index1;
    }
    while ((index1 <= 0 ? 0 : (pg[index1] == pg[index1 - 1] ? 1 : 0)) != 0)
      --index1;
    bool flag1;
    if ((!Closed || index1 >= 2 ? (Closed ? 0 : (index1 < 1 ? 1 : 0)) : 1) != 0)
    {
      flag1 = false;
    }
    else
    {
      List<Class22> class22List = new List<Class22>(index1 + 1);
      for (int index2 = 0; index2 <= index1; ++index2)
        class22List.Add(new Class22());
      bool flag2 = true;
      class22List[1].intPoint_1 = pg[1];
      Class30.smethod_15(pg[0], ref this.bool_0, this);
      Class30.smethod_15(pg[index1], ref this.bool_0, this);
      Class30.smethod_48(class22List[0], this, class22List[1], class22List[index1], pg[0]);
      Class30.smethod_48(class22List[index1], this, class22List[0], class22List[index1 - 1], pg[index1]);
      for (int index3 = index1 - 1; index3 >= 1; --index3)
      {
        Class30.smethod_15(pg[index3], ref this.bool_0, this);
        Class30.smethod_48(class22List[index3], this, class22List[index3 + 1], class22List[index3 - 1], pg[index3]);
      }
      Class22 class220 = class22List[0];
      Class22 class22_0_1 = class220;
      Class22 class22_1 = class220;
      while (true)
      {
        while ((!(class22_0_1.intPoint_1 == class22_0_1.class22_0.intPoint_1) ? 0 : (Closed ? 1 : (class22_0_1.class22_0 != class220 ? 1 : 0))) == 0)
        {
          if (class22_0_1.class22_1 != class22_0_1.class22_0)
          {
            int num;
            if (Closed)
            {
              IntPoint intPoint1 = class22_0_1.class22_1.intPoint_1;
              if (Class30.smethod_103(this.bool_0, class22_0_1.intPoint_1, class22_0_1.class22_0.intPoint_1, intPoint1))
              {
                num = !this.PreserveCollinear ? 1 : (!Class30.smethod_32(class22_0_1.class22_1.intPoint_1, class22_0_1.intPoint_1, this, class22_0_1.class22_0.intPoint_1) ? 1 : 0);
                goto label_25;
              }
            }
            num = 0;
label_25:
            if (num != 0)
            {
              if (class22_0_1 == class220)
                class220 = class22_0_1.class22_0;
              class22_0_1 = Class30.smethod_202(this, class22_0_1).class22_1;
              class22_1 = class22_0_1;
            }
            else
            {
              class22_0_1 = class22_0_1.class22_0;
              if ((class22_0_1 == class22_1 ? 1 : (Closed ? 0 : (class22_0_1.class22_0 == class220 ? 1 : 0))) != 0)
                goto label_31;
            }
          }
          else
            goto label_31;
        }
        if (class22_0_1 != class22_0_1.class22_0)
        {
          if (class22_0_1 == class220)
            class220 = class22_0_1.class22_0;
          class22_0_1 = Class30.smethod_202(this, class22_0_1);
          class22_1 = class22_0_1;
        }
        else
          break;
      }
label_31:
      if ((Closed || class22_0_1 != class22_0_1.class22_0 ? (!Closed ? 0 : (class22_0_1.class22_1 == class22_0_1.class22_0 ? 1 : 0)) : 1) != 0)
      {
        flag1 = false;
      }
      else
      {
        if (!Closed)
        {
          this.bool_1 = true;
          class220.class22_1.int_3 = -2;
        }
        Class22 class22_0_2 = class220;
        do
        {
          Class30.smethod_74(polyType, class22_0_2, this);
          class22_0_2 = class22_0_2.class22_0;
          if ((!flag2 ? 0 : (class22_0_2.intPoint_1.Y != class220.intPoint_1.Y ? 1 : 0)) != 0)
            flag2 = false;
        }
        while (class22_0_2 != class220);
        if (flag2)
        {
          if (Closed)
          {
            flag1 = false;
          }
          else
          {
            class22_0_2.class22_1.int_3 = -2;
            Class23 class23_0 = new Class23()
            {
              class23_0 = (Class23) null,
              long_0 = class22_0_2.intPoint_0.Y,
              class22_0 = (Class22) null,
              class22_1 = class22_0_2
            };
            class23_0.class22_1.enum2_0 = Enum2.const_1;
            class23_0.class22_1.int_0 = 0;
            while (true)
            {
              if (class22_0_2.intPoint_0.X != class22_0_2.class22_1.intPoint_2.X)
                goto label_45;
label_43:
              if (class22_0_2.class22_0.int_3 != -2)
              {
                class22_0_2.class22_2 = class22_0_2.class22_0;
                class22_0_2 = class22_0_2.class22_0;
                continue;
              }
              break;
label_45:
              Class30.smethod_284(this, class22_0_2);
              goto label_43;
            }
            Class30.smethod_92(this, class23_0);
            this.list_0.Add(class22List);
            flag1 = true;
          }
        }
        else
        {
          this.list_0.Add(class22List);
          Class22 class22_2 = (Class22) null;
          if (class22_0_2.class22_1.intPoint_0 == class22_0_2.class22_1.intPoint_2)
            class22_0_2 = class22_0_2.class22_0;
          while (true)
          {
            bool bool_0;
            Class22 class22_0_3;
            do
            {
              Class22 class22_3 = Class30.smethod_105(class22_0_2, this);
              if (class22_3 != class22_2)
              {
                if (class22_2 == null)
                  class22_2 = class22_3;
                Class23 class23_0 = new Class23();
                class23_0.class23_0 = (Class23) null;
                class23_0.long_0 = class22_3.intPoint_0.Y;
                if (class22_3.double_0 < class22_3.class22_1.double_0)
                {
                  class23_0.class22_0 = class22_3.class22_1;
                  class23_0.class22_1 = class22_3;
                  bool_0 = false;
                }
                else
                {
                  class23_0.class22_0 = class22_3;
                  class23_0.class22_1 = class22_3.class22_1;
                  bool_0 = true;
                }
                class23_0.class22_0.enum2_0 = Enum2.const_0;
                class23_0.class22_1.enum2_0 = Enum2.const_1;
                class23_0.class22_0.int_0 = Closed ? (class23_0.class22_0.class22_0 != class23_0.class22_1 ? 1 : -1) : 0;
                class23_0.class22_1.int_0 = -class23_0.class22_0.int_0;
                class22_0_2 = Class30.smethod_243(this, class23_0.class22_0, bool_0);
                if (class22_0_2.int_3 == -2)
                  class22_0_2 = Class30.smethod_243(this, class22_0_2, bool_0);
                class22_0_3 = Class30.smethod_243(this, class23_0.class22_1, !bool_0);
                if (class22_0_3.int_3 == -2)
                  class22_0_3 = Class30.smethod_243(this, class22_0_3, !bool_0);
                if (class23_0.class22_0.int_3 == -2)
                  class23_0.class22_0 = (Class22) null;
                else if (class23_0.class22_1.int_3 == -2)
                  class23_0.class22_1 = (Class22) null;
                Class30.smethod_92(this, class23_0);
              }
              else
                goto label_66;
            }
            while (bool_0);
            class22_0_2 = class22_0_3;
          }
label_66:
          flag1 = true;
        }
      }
    }
    return flag1;
  }

  public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
  {
    bool flag = false;
    for (int index = 0; index < ppg.Count; ++index)
    {
      if (this.AddPath(ppg[index], polyType, closed))
        flag = true;
    }
    return flag;
  }

  internal virtual void vmethod_0()
  {
    this.class23_1 = this.class23_0;
    if (this.class23_1 == null)
      return;
    this.class24_0 = (Class24) null;
    for (Class23 class230 = this.class23_0; class230 != null; class230 = class230.class23_0)
    {
      Class30.smethod_232(this, class230.long_0);
      Class22 class220 = class230.class22_0;
      if (class220 != null)
      {
        class220.intPoint_1 = class220.intPoint_0;
        class220.int_3 = -1;
      }
      Class22 class221 = class230.class22_1;
      if (class221 != null)
      {
        class221.intPoint_1 = class221.intPoint_0;
        class221.int_3 = -1;
      }
    }
    this.class22_0 = (Class22) null;
  }

  public static IntRect GetBounds(List<List<IntPoint>> paths)
  {
    int index1 = 0;
    int count = paths.Count;
    while ((index1 >= count ? 0 : (paths[index1].Count == 0 ? 1 : 0)) != 0)
      ++index1;
    IntRect bounds;
    if (index1 == count)
    {
      bounds = new IntRect(0L, 0L, 0L, 0L);
    }
    else
    {
      IntRect intRect = new IntRect()
      {
        left = paths[index1][0].X
      };
      intRect.right = intRect.left;
      intRect.top = paths[index1][0].Y;
      intRect.bottom = intRect.top;
      for (; index1 < count; ++index1)
      {
        for (int index2 = 0; index2 < paths[index1].Count; ++index2)
        {
          if (paths[index1][index2].X < intRect.left)
            intRect.left = paths[index1][index2].X;
          else if (paths[index1][index2].X > intRect.right)
            intRect.right = paths[index1][index2].X;
          if (paths[index1][index2].Y < intRect.top)
            intRect.top = paths[index1][index2].Y;
          else if (paths[index1][index2].Y > intRect.bottom)
            intRect.bottom = paths[index1][index2].Y;
        }
      }
      bounds = intRect;
    }
    return bounds;
  }
}
