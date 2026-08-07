// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDCartesianCoordinatesCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfThreeDCartesianCoordinates", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDCartesianCoordinates")]
[ComVisible(true)]
public class ThreeDCartesianCoordinatesCollection : List<ThreeDCartesianCoordinates>, ICloneable
{
  public ThreeDCartesianCoordinatesCollection()
  {
  }

  public ThreeDCartesianCoordinatesCollection(int capacity)
    : base(capacity)
  {
  }

  public ThreeDCartesianCoordinatesCollection(IEnumerable<ThreeDCartesianCoordinates> collection)
    : base(collection)
  {
  }

  public static implicit operator ThreeDCartesianCoordinatesCollection(
    ThreeDCartesianCoordinates[] values)
  {
    return values != null ? new ThreeDCartesianCoordinatesCollection((IEnumerable<ThreeDCartesianCoordinates>) values) : new ThreeDCartesianCoordinatesCollection();
  }

  public static explicit operator ThreeDCartesianCoordinates[](
    ThreeDCartesianCoordinatesCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ThreeDCartesianCoordinatesCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDCartesianCoordinatesCollection coordinatesCollection = new ThreeDCartesianCoordinatesCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      coordinatesCollection.Add((ThreeDCartesianCoordinates) Utils.Clone((object) this[index]));
    return (object) coordinatesCollection;
  }
}
