using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[ComVisible(true)]
public class BinarySchemaValidator : SchemaValidator
{
	protected static readonly string[][] WellKnownDictionaries = new string[3][]
	{
		new string[2] { "http://opcfoundation.org/BinarySchema/", "Opc.Ua.Types.Schemas.StandardTypes.bsd" },
		new string[2] { "http://opcfoundation.org/UA/BuiltInTypes/", "Opc.Ua.Types.Schemas.BuiltInTypes.bsd" },
		new string[2] { "http://opcfoundation.org/UA/", "Opc.Ua.Schema.Opc.Ua.Types.bsd" }
	};

	private Dictionary<XmlQualifiedName, TypeDescription> m_descriptions;

	private List<TypeDescription> m_validatedDescriptions;

	private List<string> m_warnings;

	public TypeDictionary Dictionary { get; private set; }

	public IList<TypeDescription> ValidatedDescriptions => m_validatedDescriptions;

	public ICollection<string> Warnings => m_warnings;

	public BinarySchemaValidator()
	{
		SetResourcePaths(WellKnownDictionaries);
	}

	public BinarySchemaValidator(IDictionary<string, string> fileTable)
		: base(fileTable)
	{
		SetResourcePaths(WellKnownDictionaries);
	}

	public BinarySchemaValidator(IDictionary<string, byte[]> importTable)
		: base(importTable)
	{
		SetResourcePaths(WellKnownDictionaries);
	}

	public void Validate(Stream stream)
	{
		Dictionary = (TypeDictionary)LoadInput(typeof(TypeDictionary), stream);
		Validate();
	}

	public void Validate(string inputPath)
	{
		Dictionary = (TypeDictionary)LoadInput(typeof(TypeDictionary), inputPath);
		Validate();
	}

	public override string GetSchema(string typeName)
	{
		XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
		MemoryStream memoryStream = new MemoryStream();
		XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings);
		try
		{
			if (typeName == null)
			{
				new XmlSerializer(typeof(TypeDictionary)).Serialize(xmlWriter, Dictionary);
			}
			else
			{
				TypeDescription value = null;
				if (!m_descriptions.TryGetValue(new XmlQualifiedName(typeName, Dictionary.TargetNamespace), out value))
				{
					new XmlSerializer(typeof(TypeDictionary)).Serialize(xmlWriter, Dictionary);
				}
				else
				{
					new XmlSerializer(typeof(TypeDescription)).Serialize(xmlWriter, value);
				}
			}
		}
		finally
		{
			xmlWriter.Flush();
			xmlWriter.Dispose();
		}
		return Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
	}

	private void Validate()
	{
		m_descriptions = new Dictionary<XmlQualifiedName, TypeDescription>();
		m_validatedDescriptions = new List<TypeDescription>();
		m_warnings = new List<string>();
		if (Dictionary.Import != null)
		{
			ImportDirective[] import = Dictionary.Import;
			foreach (ImportDirective directive in import)
			{
				Import(directive);
			}
		}
		else if (!WellKnownDictionaries.Any((string[] n) => string.Equals(n[0], Dictionary.TargetNamespace, StringComparison.Ordinal)))
		{
			ImportDirective directive2 = new ImportDirective
			{
				Namespace = "http://opcfoundation.org/UA/"
			};
			Import(directive2);
		}
		foreach (TypeDescription value in m_descriptions.Values)
		{
			ValidateDescription(value);
		}
		if (Dictionary.Items == null)
		{
			return;
		}
		TypeDescription[] items = Dictionary.Items;
		foreach (TypeDescription typeDescription in items)
		{
			ImportDescription(typeDescription, Dictionary.TargetNamespace);
			m_validatedDescriptions.Add(typeDescription);
		}
		foreach (TypeDescription validatedDescription in m_validatedDescriptions)
		{
			ValidateDescription(validatedDescription);
			m_warnings.Add(string.Format(CultureInfo.InvariantCulture, "{0} '{1}' validated.", validatedDescription.GetType().Name, validatedDescription.Name));
		}
	}

	private void Import(ImportDirective directive)
	{
		if (base.LoadedFiles.ContainsKey(directive.Namespace))
		{
			return;
		}
		TypeDictionary typeDictionary = (TypeDictionary)Load(typeof(TypeDictionary), directive.Namespace, directive.Location);
		if (!string.IsNullOrEmpty(typeDictionary.TargetNamespace) && directive.Namespace != typeDictionary.TargetNamespace)
		{
			throw SchemaValidator.Exception("Imported dictionary '{0}' does not match uri specified: '{1}'.", typeDictionary.TargetNamespace, directive.Namespace);
		}
		base.LoadedFiles.Add(typeDictionary.TargetNamespace, typeDictionary);
		if (typeDictionary.Import != null)
		{
			for (int i = 0; i < typeDictionary.Import.Length; i++)
			{
				Import(typeDictionary.Import[i]);
			}
		}
		if (typeDictionary.Items != null)
		{
			TypeDescription[] items = typeDictionary.Items;
			foreach (TypeDescription description in items)
			{
				ImportDescription(description, typeDictionary.TargetNamespace);
			}
		}
	}

	private static bool IsNull(Documentation documentation)
	{
		if (documentation == null)
		{
			return true;
		}
		if (documentation.Text != null && documentation.Text.Length != 0)
		{
			for (int i = 0; i < documentation.Text.Length; i++)
			{
				if (!string.IsNullOrEmpty(documentation.Text[i]))
				{
					return false;
				}
			}
		}
		if (documentation.Items != null && documentation.Items.Length != 0)
		{
			return false;
		}
		return true;
	}

	private bool IsIntegerType(FieldType field)
	{
		TypeDescription value = null;
		if (!m_descriptions.TryGetValue(field.TypeName, out value))
		{
			return false;
		}
		if (value is EnumeratedType)
		{
			return true;
		}
		if (value is OpaqueType { LengthInBitsSpecified: not false })
		{
			return true;
		}
		return false;
	}

	private int GetFieldLength(FieldType field)
	{
		TypeDescription value = null;
		if (!m_descriptions.TryGetValue(field.TypeName, out value))
		{
			return -1;
		}
		uint num = 1u;
		if (field.LengthSpecified)
		{
			num = field.Length;
			if (field.IsLengthInBytes)
			{
				num *= 8;
			}
		}
		if (value is EnumeratedType enumeratedType)
		{
			if (enumeratedType.LengthInBitsSpecified)
			{
				return enumeratedType.LengthInBits * (int)num;
			}
		}
		else if (value is OpaqueType { LengthInBitsSpecified: not false } opaqueType)
		{
			return opaqueType.LengthInBits * (int)num;
		}
		return -1;
	}

	private static bool IsValidName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return false;
		}
		if (!char.IsLetter(name[0]) && name[0] != '_' && name[0] != '"')
		{
			return false;
		}
		bool flag = name[0] == '"';
		for (int i = 1; i < name.Length; i++)
		{
			if (!char.IsLetter(name[i]) && !char.IsDigit(name[i]))
			{
				if (name[i] == '"')
				{
					flag = !flag;
				}
				else if (name[i] != '.' && name[i] != '-' && name[i] != '_' && !(name[i] == ' ' && flag))
				{
					return false;
				}
			}
		}
		return true;
	}

	private void ImportDescription(TypeDescription description, string targetNamespace)
	{
		if (description != null)
		{
			if (!IsValidName(description.Name))
			{
				throw SchemaValidator.Exception("'{0}' is not a valid qualified name.", description.Name);
			}
			description.QName = new XmlQualifiedName(description.Name, targetNamespace);
			if (m_descriptions.ContainsKey(description.QName))
			{
				throw SchemaValidator.Exception("The description name '{0}' already used by another description.", description.Name);
			}
			m_descriptions.Add(description.QName, description);
		}
	}

	private void ValidateDescription(TypeDescription description)
	{
		if (description is OpaqueType opaqueType)
		{
			if (!opaqueType.LengthInBitsSpecified)
			{
				m_warnings.Add(string.Format(CultureInfo.InvariantCulture, "Warning: The opaque type '{0}' does not have a length specified.", description.Name));
			}
			if (IsNull(opaqueType.Documentation))
			{
				m_warnings.Add(string.Format(CultureInfo.InvariantCulture, "Warning: The opaque type '{0}' does not have any documentation.", description.Name));
			}
		}
		if (description is EnumeratedType { LengthInBitsSpecified: false })
		{
			throw SchemaValidator.Exception("The enumerated type '{0}' does not have a length specified.", description.Name);
		}
		if (!(description is StructuredType structuredType))
		{
			return;
		}
		if (structuredType.Field == null || structuredType.Field.Length == 0)
		{
			structuredType.Field = Array.Empty<FieldType>();
		}
		int num = 0;
		Dictionary<string, FieldType> dictionary = new Dictionary<string, FieldType>();
		for (int i = 0; i < structuredType.Field.Length; i++)
		{
			FieldType fieldType = structuredType.Field[i];
			ValidateField(structuredType, dictionary, fieldType);
			int fieldLength = GetFieldLength(fieldType);
			if (fieldLength == -1)
			{
				if (num % 8 != 0)
				{
					throw SchemaValidator.Exception("Field '{1}' in structured type '{0}' is not aligned on a byte boundary .", description.Name, fieldType.Name);
				}
				num = 0;
			}
			else
			{
				num += fieldLength;
			}
			dictionary.Add(fieldType.Name, fieldType);
		}
	}

	private void ValidateField(StructuredType description, Dictionary<string, FieldType> fields, FieldType field)
	{
		if (field == null || string.IsNullOrEmpty(field.Name))
		{
			throw SchemaValidator.Exception("The structured type '{0}' has an unnamed field.", description.Name);
		}
		if (fields.ContainsKey(field.Name))
		{
			throw SchemaValidator.Exception("The structured type '{0}' has a duplicate field name '{1}'.", description.Name, field.Name);
		}
		if (SchemaValidator.IsNull(field.TypeName))
		{
			throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' has no type specified.", field.Name, description.Name);
		}
		if (!m_descriptions.ContainsKey(field.TypeName))
		{
			throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' has an unrecognized type '{2}'.", field.Name, description.Name, field.TypeName);
		}
		if (!string.IsNullOrEmpty(field.LengthField))
		{
			if (!fields.ContainsKey(field.LengthField))
			{
				throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references an unknownn length field '{2}'.", field.Name, description.Name, field.LengthField);
			}
			if (!IsIntegerType(fields[field.LengthField]))
			{
				throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references a length field '{2}' which is not an integer value.", field.Name, description.Name, field.SwitchField);
			}
		}
		if (!string.IsNullOrEmpty(field.SwitchField))
		{
			if (!fields.ContainsKey(field.SwitchField))
			{
				throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references an unknownn switch field '{2}'.", field.Name, description.Name, field.SwitchField);
			}
			if (!IsIntegerType(fields[field.SwitchField]))
			{
				throw SchemaValidator.Exception("Field '{0}' in structured type '{1}' references a switch field '{2}' which is not an integer value.", field.Name, description.Name, field.SwitchField);
			}
		}
	}
}
