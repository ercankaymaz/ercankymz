// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CartesianCoordinatesCollection
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
[CollectionDataContract(Name = "ListOfCartesianCoordinates", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CartesianCoordinates")]
[ComVisible(true)]
public class CartesianCoordinatesCollection : List<CartesianCoordinates>, ICloneable
{
  public CartesianCoordinatesCollection()
  {
  }

  public CartesianCoordinatesCollection(int capacity)
    : base(capacity)
  {
  }

  public CartesianCoordinatesCollection(IEnumerable<CartesianCoordinates> collection)
    : base(collection)
  {
  }

  public static implicit operator CartesianCoordinatesCollection(CartesianCoordinates[] values)
  {
    return values != null ? new CartesianCoordinatesCollection((IEnumerable<CartesianCoordinates>) values) : new CartesianCoordinatesCollection();
  }

  public static explicit operator CartesianCoordinates[](CartesianCoordinatesCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (CartesianCoordinatesCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CartesianCoordinatesCollection coordinatesCollection = new CartesianCoordinatesCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      coordinatesCollection.Add((CartesianCoordinates) Utils.Clone((object) this[index]));
    return (object) coordinatesCollection;
  }
}
