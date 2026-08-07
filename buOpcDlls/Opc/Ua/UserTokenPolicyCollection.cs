// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UserTokenPolicyCollection
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
[CollectionDataContract(Name = "ListOfUserTokenPolicy", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UserTokenPolicy")]
[ComVisible(true)]
public class UserTokenPolicyCollection : List<UserTokenPolicy>, ICloneable
{
  public UserTokenPolicyCollection()
  {
  }

  public UserTokenPolicyCollection(int capacity)
    : base(capacity)
  {
  }

  public UserTokenPolicyCollection(IEnumerable<UserTokenPolicy> collection)
    : base(collection)
  {
  }

  public static implicit operator UserTokenPolicyCollection(UserTokenPolicy[] values)
  {
    return values != null ? new UserTokenPolicyCollection((IEnumerable<UserTokenPolicy>) values) : new UserTokenPolicyCollection();
  }

  public static explicit operator UserTokenPolicy[](UserTokenPolicyCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (UserTokenPolicyCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UserTokenPolicyCollection policyCollection = new UserTokenPolicyCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      policyCollection.Add((UserTokenPolicy) Utils.Clone((object) this[index]));
    return (object) policyCollection;
  }
}
