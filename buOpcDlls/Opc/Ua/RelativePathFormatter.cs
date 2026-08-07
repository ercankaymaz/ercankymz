// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RelativePathFormatter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class RelativePathFormatter : IFormattable
{
  private List<RelativePathFormatter.Element> m_elements;

  public RelativePathFormatter(RelativePath relativePath, ITypeTable typeTree)
  {
    this.m_elements = new List<RelativePathFormatter.Element>();
    if (relativePath == null)
      return;
    foreach (RelativePathElement element in (List<RelativePathElement>) relativePath.Elements)
      this.m_elements.Add(new RelativePathFormatter.Element(element, typeTree));
  }

  public RelativePathFormatter() => this.m_elements = new List<RelativePathFormatter.Element>();

  public List<RelativePathFormatter.Element> Elements => this.m_elements;

  public void UpdateNamespaceTable(NamespaceTable currentTable, NamespaceTable targetTable)
  {
    int[] numArray = new int[currentTable.Count];
    numArray[0] = 0;
    if (numArray.Length != 0)
      numArray[1] = 1;
    if (targetTable.Count <= 1)
      targetTable.Append("---");
    string[] strArray = new string[numArray.Length];
    for (int index = 2; index < numArray.Length; ++index)
    {
      strArray[index] = currentTable.GetString((uint) index);
      if (strArray[index] != null)
        numArray[index] = targetTable.GetIndex(strArray[index]);
    }
    foreach (RelativePathFormatter.Element element in this.m_elements)
    {
      QualifiedName referenceTypeName = element.ReferenceTypeName;
      if (referenceTypeName != (QualifiedName) null && referenceTypeName.NamespaceIndex > (ushort) 1 && (int) referenceTypeName.NamespaceIndex < numArray.Length && numArray[(int) referenceTypeName.NamespaceIndex] == -1)
        numArray[(int) referenceTypeName.NamespaceIndex] = (int) targetTable.GetIndexOrAppend(strArray[(int) referenceTypeName.NamespaceIndex]);
      QualifiedName targetName = element.TargetName;
      if (targetName != (QualifiedName) null && targetName.NamespaceIndex > (ushort) 1 && (int) targetName.NamespaceIndex < numArray.Length && numArray[(int) targetName.NamespaceIndex] == -1)
        numArray[(int) targetName.NamespaceIndex] = (int) targetTable.GetIndexOrAppend(strArray[(int) targetName.NamespaceIndex]);
    }
  }

  public void TranslateNamespaceIndexes(NamespaceTable currentTable, NamespaceTable targetTable)
  {
    int[] numArray = new int[currentTable.Count];
    numArray[0] = 0;
    string[] strArray = new string[numArray.Length];
    for (int index = 1; index < numArray.Length; ++index)
    {
      strArray[index] = currentTable.GetString((uint) index);
      if (strArray[index] != null)
        numArray[index] = targetTable.GetIndex(strArray[index]);
    }
    foreach (RelativePathFormatter.Element element in this.m_elements)
    {
      QualifiedName referenceTypeName = element.ReferenceTypeName;
      if (referenceTypeName != (QualifiedName) null && referenceTypeName.NamespaceIndex > (ushort) 0 && (int) referenceTypeName.NamespaceIndex < numArray.Length && numArray[(int) referenceTypeName.NamespaceIndex] > 0)
        element.ReferenceTypeName = new QualifiedName(referenceTypeName.Name, (ushort) numArray[(int) referenceTypeName.NamespaceIndex]);
      QualifiedName targetName = element.TargetName;
      if (targetName != (QualifiedName) null && targetName.NamespaceIndex > (ushort) 0 && (int) targetName.NamespaceIndex < numArray.Length && numArray[(int) targetName.NamespaceIndex] > 0)
        element.TargetName = new QualifiedName(targetName.Name, (ushort) numArray[(int) targetName.NamespaceIndex]);
    }
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RelativePathFormatter.Element element in this.m_elements)
        stringBuilder.AppendFormat("{0}", (object) element);
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public static bool IsEmpty(RelativePathFormatter relativePath)
  {
    return relativePath == null || relativePath.Elements.Count == 0;
  }

  public static RelativePathFormatter Parse(
    string textToParse,
    NamespaceTable currentTable,
    NamespaceTable targetTable)
  {
    RelativePathFormatter relativePathFormatter = RelativePathFormatter.Parse(textToParse);
    relativePathFormatter?.TranslateNamespaceIndexes(currentTable, targetTable);
    return relativePathFormatter;
  }

  public static RelativePathFormatter Parse(string textToParse)
  {
    if (string.IsNullOrEmpty(textToParse))
      return new RelativePathFormatter();
    RelativePathFormatter relativePathFormatter = new RelativePathFormatter();
    try
    {
      StringReader reader = new StringReader(textToParse);
      while (reader.Peek() != -1)
      {
        RelativePathFormatter.Element element = RelativePathFormatter.Element.Parse(reader);
        relativePathFormatter.m_elements.Add(element);
      }
    }
    catch (Exception ex)
    {
      throw new ServiceResultException(2151022592U /*0x80360000*/, Utils.Format("Cannot parse relative path: '{0}'.", (object) textToParse), ex);
    }
    return relativePathFormatter;
  }

  public class Element : IFormattable
  {
    private RelativePathFormatter.ElementType m_elementType;
    private bool m_includeSubtypes;
    private QualifiedName m_referenceTypeName;
    private QualifiedName m_targetName;

    public Element(RelativePathElement element, ITypeTable typeTree)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      if (typeTree == null)
        throw new ArgumentNullException(nameof (typeTree));
      this.m_referenceTypeName = (QualifiedName) null;
      this.m_targetName = element.TargetName;
      this.m_elementType = RelativePathFormatter.ElementType.ForwardReference;
      this.m_includeSubtypes = element.IncludeSubtypes;
      if (!element.IsInverse && element.IncludeSubtypes)
      {
        if (element.ReferenceTypeId == (object) ReferenceTypeIds.HierarchicalReferences)
          this.m_elementType = RelativePathFormatter.ElementType.AnyHierarchical;
        else if (element.ReferenceTypeId == (object) ReferenceTypeIds.Aggregates)
          this.m_elementType = RelativePathFormatter.ElementType.AnyComponent;
        else
          this.m_referenceTypeName = typeTree.FindReferenceTypeName(element.ReferenceTypeId);
      }
      else
      {
        if (element.IsInverse)
          this.m_elementType = RelativePathFormatter.ElementType.InverseReference;
        this.m_referenceTypeName = typeTree.FindReferenceTypeName(element.ReferenceTypeId);
      }
    }

    public Element()
    {
      this.m_elementType = RelativePathFormatter.ElementType.AnyHierarchical;
      this.m_referenceTypeName = (QualifiedName) null;
      this.m_includeSubtypes = true;
      this.m_targetName = (QualifiedName) null;
    }

    public RelativePathFormatter.ElementType ElementType
    {
      get => this.m_elementType;
      set => this.m_elementType = value;
    }

    public QualifiedName ReferenceTypeName
    {
      get => this.m_referenceTypeName;
      set => this.m_referenceTypeName = value;
    }

    public bool IncludeSubtypes
    {
      get => this.m_includeSubtypes;
      set => this.m_includeSubtypes = value;
    }

    public QualifiedName TargetName
    {
      get => this.m_targetName;
      set => this.m_targetName = value;
    }

    public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

    public string ToString(string format, IFormatProvider formatProvider)
    {
      if (format == null)
      {
        StringBuilder path = new StringBuilder();
        switch (this.m_elementType)
        {
          case RelativePathFormatter.ElementType.AnyHierarchical:
            path.Append('/');
            break;
          case RelativePathFormatter.ElementType.AnyComponent:
            path.Append('.');
            break;
          case RelativePathFormatter.ElementType.ForwardReference:
          case RelativePathFormatter.ElementType.InverseReference:
            if (this.m_referenceTypeName != (QualifiedName) null && !string.IsNullOrEmpty(this.m_referenceTypeName.Name))
            {
              path.Append('<');
              if (!this.m_includeSubtypes)
                path.Append('#');
              if (this.m_elementType == RelativePathFormatter.ElementType.InverseReference)
                path.Append('!');
              if (this.m_referenceTypeName.NamespaceIndex != (ushort) 0)
                path.AppendFormat("{0}:", (object) this.m_referenceTypeName.NamespaceIndex);
              RelativePathFormatter.Element.EncodeName(path, this.m_referenceTypeName.Name);
              path.Append('>');
              break;
            }
            break;
        }
        if (this.m_targetName != (QualifiedName) null && !string.IsNullOrEmpty(this.m_targetName.Name))
        {
          if (this.m_targetName.NamespaceIndex != (ushort) 0)
            path.AppendFormat("{0}:", (object) this.m_targetName.NamespaceIndex);
          RelativePathFormatter.Element.EncodeName(path, this.m_targetName.Name);
        }
        return path.ToString();
      }
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    }

    public static RelativePathFormatter.Element Parse(StringReader reader)
    {
      RelativePathFormatter.Element element = new RelativePathFormatter.Element();
      switch (reader.Peek())
      {
        case 46:
          element.ElementType = RelativePathFormatter.ElementType.AnyComponent;
          reader.Read();
          break;
        case 47:
          element.ElementType = RelativePathFormatter.ElementType.AnyHierarchical;
          reader.Read();
          break;
        case 60:
          element.ElementType = RelativePathFormatter.ElementType.ForwardReference;
          reader.Read();
          if (reader.Peek() == 35)
          {
            element.IncludeSubtypes = false;
            reader.Read();
          }
          if (reader.Peek() == 33)
          {
            element.ElementType = RelativePathFormatter.ElementType.InverseReference;
            reader.Read();
          }
          element.ReferenceTypeName = RelativePathFormatter.Element.ParseName(reader, true);
          break;
        default:
          element.ElementType = RelativePathFormatter.ElementType.AnyHierarchical;
          break;
      }
      element.TargetName = RelativePathFormatter.Element.ParseName(reader, false);
      return element;
    }

    private static QualifiedName ParseName(StringReader reader, bool referenceName)
    {
      ushort namespaceIndex = 0;
      StringBuilder stringBuilder = new StringBuilder();
      int num1 = reader.Peek();
      int c = num1;
      while (c != -1)
      {
        if (char.IsDigit((char) c))
        {
          stringBuilder.Append((char) c);
          reader.Read();
          c = reader.Peek();
          num1 = c;
        }
        else
        {
          if (c == 58)
          {
            reader.Read();
            namespaceIndex = Convert.ToUInt16(stringBuilder.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
            stringBuilder.Length = 0;
            num1 = reader.Peek();
            break;
          }
          break;
        }
      }
      for (int index = num1; index != -1; index = reader.Peek())
      {
        num1 = index;
        if (referenceName)
        {
          if (index == 62)
          {
            reader.Read();
            break;
          }
        }
        else if (index == 60 || index == 47 || index == 46)
          break;
        if (index == 38)
        {
          int num2 = reader.Read() != -1 ? reader.Read() : throw new ServiceResultException(2159411200U /*0x80B60000*/, "Unexpected end after escape character '&'.");
          switch (num2)
          {
            case 33:
            case 35:
            case 38:
            case 46:
            case 47:
            case 58:
            case 60:
            case 62:
              stringBuilder.Append((char) num2);
              continue;
            default:
              throw new ServiceResultException(2159411200U /*0x80B60000*/, Utils.Format("Invalid escape sequence '&{0}' in browse path.", (object) num2));
          }
        }
        else if (index != 33 && index != 58 && index != 60 && index != 62 && index != 47 && index != 46 && index != 35 && index != 38)
        {
          stringBuilder.Append((char) index);
          reader.Read();
        }
        else
          throw new ServiceResultException(2159411200U /*0x80B60000*/, Utils.Format("Unexpected character '{0}' in browse path.", (object) index));
      }
      if (referenceName && num1 != 62)
        throw new ServiceResultException(2159411200U /*0x80B60000*/, Utils.Format("Missing closing '>' for reference type name in browse path."));
      if (stringBuilder.Length == 0)
      {
        if (referenceName)
          throw new ServiceResultException(2159411200U /*0x80B60000*/, Utils.Format("Reference type name is null in browse path."));
        if (namespaceIndex == (ushort) 0)
          return (QualifiedName) null;
      }
      return new QualifiedName(stringBuilder.ToString(), namespaceIndex);
    }

    private static void EncodeName(StringBuilder path, string name)
    {
      for (int index = 0; index < name.Length; ++index)
      {
        switch (name[index])
        {
          case '!':
          case '&':
          case '.':
          case '/':
          case ':':
          case '<':
          case '>':
            path.Append('&');
            break;
        }
        path.Append(name[index]);
      }
    }
  }

  public enum ElementType
  {
    AnyHierarchical = 1,
    AnyComponent = 2,
    ForwardReference = 3,
    InverseReference = 4,
  }
}
