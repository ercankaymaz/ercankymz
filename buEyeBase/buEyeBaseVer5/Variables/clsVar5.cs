// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Variables.clsVar5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Variables;

public class clsVar5
{
  public const buFile5.PLYToSchematic.\u0001 \u0013 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0014 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0015 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0016 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0017 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0018 = ; // Unable to render the field
  public List<buFile5.PLYToSchematic.\u0001> \u0001;
  public int \u0001;
  public int \u0002;
  public bool \u0001;
  public List<Pnt3D> \u0001;
  public List<TriangleIndex> \u0001;

  public TextStyleKeyedCollection TextStyleCopy(TextStyleKeyedCollection baseItem)
  {
    TextStyleKeyedCollection styleKeyedCollection = new TextStyleKeyedCollection();
    styleKeyedCollection.Clear();
    for (int index1 = 0; index1 <= baseItem.Count - 1; ++index1)
    {
      bool flag = true;
      for (int index2 = 0; index2 <= styleKeyedCollection.Count - 1; ++index2)
      {
        if (baseItem[index1].Name == styleKeyedCollection[index2].Name)
          flag = false;
      }
      if (flag)
      {
        TextStyle textStyle = (TextStyle) baseItem[index1].Clone();
        styleKeyedCollection.Add(textStyle);
      }
    }
    return styleKeyedCollection;
  }

  public BlockKeyedCollection BlcokCopy(BlockKeyedCollection baseItem)
  {
    BlockKeyedCollection blockKeyedCollection = new BlockKeyedCollection();
    blockKeyedCollection.Clear();
    for (int index1 = 0; index1 <= baseItem.Count - 1; ++index1)
    {
      bool flag = true;
      for (int index2 = 0; index2 <= blockKeyedCollection.Count - 1; ++index2)
      {
        if (baseItem[index1].Name == blockKeyedCollection[index2].Name)
          flag = false;
      }
      if (baseItem[index1].Name == "RootBlock")
        flag = false;
      if (flag)
      {
        Block block = (Block) baseItem[index1].Clone();
        blockKeyedCollection.Add(block);
      }
    }
    return blockKeyedCollection;
  }
}
