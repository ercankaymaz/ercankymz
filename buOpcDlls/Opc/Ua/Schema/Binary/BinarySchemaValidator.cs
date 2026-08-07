// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.BinarySchemaValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Schema.Binary;

[ComVisible(true)]
public class BinarySchemaValidator : SchemaValidator
{
  protected static readonly string[][] WellKnownDictionaries = new string[3][]
  {
    new string[2]
    {
      "http://opcfoundation.org/BinarySchema/",
      "Opc.Ua.Types.Schemas.StandardTypes.bsd"
    },
    new string[2]
    {
      "http://opcfoundation.org/UA/BuiltInTypes/",
      "Opc.Ua.Types.Schemas.BuiltInTypes.bsd"
    },
    new string[2]
    {
      "http://opcfoundation.org/UA/",
      "Opc.Ua.Schema.Opc.Ua.Types.bsd"
    }
  };
  private System.Collections.Generic.Dictionary<XmlQualifiedName, TypeDescription> m_descriptions;
  private List<TypeDescription> m_validatedDescriptions;
  private List<string> m_warnings;

  public BinarySchemaValidator()
  {
    this.SetResourcePaths(BinarySchemaValidator.WellKnownDictionaries);
  }

  public BinarySchemaValidator(IDictionary<string, string> fileTable)
    : base(fileTable)
  {
    this.SetResourcePaths(BinarySchemaValidator.WellKnownDictionaries);
  }

  public BinarySchemaValidator(IDictionary<string, byte[]> importTable)
    : base(importTable)
  {
    this.SetResourcePaths(BinarySchemaValidator.WellKnownDictionaries);
  }

  public TypeDictionary Dictionary { get; private set; }

  public IList<TypeDescription> ValidatedDescriptions
  {
    get => (IList<TypeDescription>) this.m_validatedDescriptions;
  }

  public ICollection<string> Warnings => (ICollection<string>) this.m_warnings;

  public void Validate(Stream stream)
  {
    this.Dictionary = (TypeDictionary) this.LoadInput(typeof (TypeDictionary), stream);
    this.Validate();
  }

  public void Validate(string inputPath)
  {
    this.Dictionary = (TypeDictionary) this.LoadInput(typeof (TypeDictionary), inputPath);
    this.Validate();
  }

  public override string GetSchema(string typeName)
  {
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    MemoryStream output = new MemoryStream();
    XmlWriter xmlWriter = XmlWriter.Create((Stream) output, settings);
    try
    {
      if (typeName == null)
      {
        new XmlSerializer(typeof (TypeDictionary)).Serialize(xmlWriter, (object) this.Dictionary);
      }
      else
      {
        TypeDescription o = (TypeDescription) null;
        if (!this.m_descriptions.TryGetValue(new XmlQualifiedName(typeName, this.Dictionary.TargetNamespace), out o))
          new XmlSerializer(typeof (TypeDictionary)).Serialize(xmlWriter, (object) this.Dictionary);
        else
          new XmlSerializer(typeof (TypeDescription)).Serialize(xmlWriter, (object) o);
      }
    }
    finally
    {
      xmlWriter.Flush();
      xmlWriter.Dispose();
    }
    return Encoding.UTF8.GetString(output.ToArray(), 0, (int) output.Length);
  }

  private void Validate()
  {
    this.m_descriptions = new System.Collections.Generic.Dictionary<XmlQualifiedName, TypeDescription>();
    this.m_validatedDescriptions = new List<TypeDescription>();
    this.m_warnings = new List<string>();
    if (this.Dictionary.Import != null)
    {
      foreach (ImportDirective directive in this.Dictionary.Import)
        this.Import(directive);
    }
    else if (!((IEnumerable<string[]>) BinarySchemaValidator.WellKnownDictionaries).Any<string[]>((Func<string[], bool>) (n => string.Equals(n[0], this.Dictionary.TargetNamespace, StringComparison.Ordinal))))
      this.Import(new ImportDirective()
      {
        Namespace = "http://opcfoundation.org/UA/"
      });
    foreach (TypeDescription description in this.m_descriptions.Values)
      this.ValidateDescription(description);
    if (this.Dictionary.Items == null)
      return;
    foreach (TypeDescription description in this.Dictionary.Items)
    {
      this.ImportDescription(description, this.Dictionary.TargetNamespace);
      this.m_validatedDescriptions.Add(description);
    }
    foreach (TypeDescription validatedDescription in this.m_validatedDescriptions)
    {
      this.ValidateDescription(validatedDescription);
      this.m_warnings.Add(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0} '{1}' validated.", (object) validatedDescription.GetType().Name, (object) validatedDescription.Name));
    }
  }

  private void Import(ImportDirective directive)
  {
    if (this.LoadedFiles.ContainsKey(directive.Namespace))
      return;
    TypeDictionary typeDictionary = (TypeDictionary) this.Load(typeof (TypeDictionary), directive.Namespace, directive.Location);
    if (!string.IsNullOrEmpty(typeDictionary.TargetNamespace) && directive.Namespace != typeDictionary.TargetNamespace)
      throw SchemaValidator.Exception("Imported dictionary '{0}' does not match uri specified: '{1}'.", (object) typeDictionary.TargetNamespace, (object) directive.Namespace);
    this.LoadedFiles.Add(typeDictionary.TargetNamespace, (object) typeDictionary);
    if (typeDictionary.Import != null)
    {
      for (int index = 0; index < typeDictionary.Import.Length; ++index)
        this.Import(typeDictionary.Import[index]);
    }
    if (typeDictionary.Items == null)
      return;
    foreach (TypeDescription description in typeDictionary.Items)
      this.ImportDescription(description, typeDictionary.TargetNamespace);
  }

  private static bool IsNull(Documentation documentation)
  {
    if (documentation == null)
      return true;
    if (documentation.Text != null && documentation.Text.Length != 0)
    {
      for (int index = 0; index < documentation.Text.Length; ++index)
      {
        if (!string.IsNullOrEmpty(documentation.Text[index]))
          return false;
      }
    }
    return documentation.Items == null || documentation.Items.Length == 0;
  }

  private bool IsIntegerType(FieldType field)
  {
    TypeDescription typeDescription = (TypeDescription) null;
    if (!this.m_descriptions.TryGetValue(field.TypeName, out typeDescription))
      return false;
    switch (typeDescription)
    {
      case EnumeratedType _:
        return true;
      case OpaqueType opaqueType:
        if (opaqueType.LengthInBitsSpecified)
          return true;
        break;
    }
    return false;
  }

  private int GetFieldLength(FieldType field)
  {
    TypeDescription typeDescription = (TypeDescription) null;
    if (!this.m_descriptions.TryGetValue(field.TypeName, out typeDescription))
      return -1;
    uint num = 1;
    if (field.LengthSpecified)
    {
      num = field.Length;
      if (field.IsLengthInBytes)
        num *= 8U;
    }
    switch (typeDescription)
    {
      case EnumeratedType enumeratedType:
        if (enumeratedType.LengthInBitsSpecified)
          return enumeratedType.LengthInBits * (int) num;
        break;
      case OpaqueType opaqueType:
        if (opaqueType.LengthInBitsSpecified)
          return opaqueType.LengthInBits * (int) num;
        break;
    }
    return -1;
  }

  private static bool IsValidName(string name)
  {
    if (string.IsNullOrEmpty(name) || !char.IsLetter(name[0]) && name[0] != '_' && name[0] != '"')
      return false;
    bool flag = name[0] == '"';
    for (int index = 1; index < name.Length; ++index)
    {
      if (!char.IsLetter(name[index]) && !char.IsDigit(name[index]))
      {
        if (name[index] == '"')
          flag = !flag;
        else if (name[index] != '.' && name[index] != '-' && name[index] != '_' && !(name[index] == ' ' & flag))
          return false;
      }
    }
    return true;
  }

  private void ImportDescription(TypeDescription description, string targetNamespace)
  {
    if (description == null)
      return;
    if (!BinarySchemaValidator.IsValidName(description.Name))
      throw SchemaValidator.Exception("'{0}' is not a valid qualified name.", (object) description.Name);
    description.QName = new XmlQualifiedName(description.Name, targetNamespace);
    if (this.m_descriptions.ContainsKey(description.QName))
      throw SchemaValidator.Exception("The description name '{0}' already used by another description.", (object) description.Name);
    this.m_descriptions.Add(description.QName, description);
  }

  private void ValidateDescription(TypeDescription description)
  {
    if (description is OpaqueType opaqueType)
    {
      if (!opaqueType.LengthInBitsSpecified)
        this.m_warnings.Add(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Warning: The opaque type '{0}' does not have a length specified.", (object) description.Name));
      if (BinarySchemaValidator.IsNull(opaqueType.Documentation))
        this.m_warnings.Add(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Warning: The opaque type '{0}' does not have any documentation.", (object) description.Name));
    }
    if (description is EnumeratedType enumeratedType && !enumeratedType.LengthInBitsSpecified)
      throw SchemaValidator.Exception("The enumerated type '{0}' does not have a length specified.", (object) description.Name);
    if (!(description is StructuredType description1))
      return;
    if (description1.Field == null || description1.Field.Length == 0)
      description1.Field = Array.Empty<FieldType>();
    int num = 0;
    System.Collections.Generic.Dictionary<string, FieldType> fields = new System.Collections.Generic.Dictionary<string, FieldType>();
    for (int index = 0; index < description1.Field.Length; ++index)
    {
      FieldType field = description1.Field[index];
      this.ValidateField(description1, fields, field);
      int fieldLength = this.GetFieldLength(field);
      if (fieldLength == -1)
        num = num % 8 == 0 ? 0 : throw SchemaValidator.Exception("Field '{1}' in structured type '{0}' is not aligned on a byte boundary .", (object) description.Name, (object) field.Name);
      else
        num += fieldLength;
      fields.Add(field.Name, field);
    }
  }

  private void ValidateField(
    StructuredType description,
    System.Collections.Generic.Dictionary<string, FieldType> fields,
    FieldType field)
  {
    if (field == null || string.IsNullOrEmpty(field.Name))
      throw SchemaValidator.Exception("The structured type '{0}' has an unnamed field.", (object) description.Name);
    if (fields.ContainsKey(field.Name))
      throw SchemaValidator.Exception("The structured type '{0}' has a duplicate field name '{1}'.", (object) description.Name, (object) field.Name);
    if (SchemaValidator.IsNull(field.TypeName))
      throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' has no type specified.", (object) field.Name, (object) description.Name);
    if (!this.m_descriptions.ContainsKey(field.TypeName))
      throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' has an unrecognized type '{2}'.", (object) field.Name, (object) description.Name, (object) field.TypeName);
    if (!string.IsNullOrEmpty(field.LengthField))
    {
      if (!fields.ContainsKey(field.LengthField))
        throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references an unknownn length field '{2}'.", (object) field.Name, (object) description.Name, (object) field.LengthField);
      if (!this.IsIntegerType(fields[field.LengthField]))
        throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references a length field '{2}' which is not an integer value.", (object) field.Name, (object) description.Name, (object) field.SwitchField);
    }
    if (string.IsNullOrEmpty(field.SwitchField))
      return;
    if (!fields.ContainsKey(field.SwitchField))
      throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references an unknownn switch field '{2}'.", (object) field.Name, (object) description.Name, (object) field.SwitchField);
    if (!this.IsIntegerType(fields[field.SwitchField]))
      throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references a switch field '{2}' which is not an integer value.", (object) field.Name, (object) description.Name, (object) field.SwitchField);
  }
}
