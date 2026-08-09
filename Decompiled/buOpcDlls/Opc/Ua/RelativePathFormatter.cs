using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Opc.Ua;

[ComVisible(true)]
public class RelativePathFormatter : IFormattable
{
	public class Element : IFormattable
	{
		private ElementType m_elementType;

		private bool m_includeSubtypes;

		private QualifiedName m_referenceTypeName;

		private QualifiedName m_targetName;

		public ElementType ElementType
		{
			get
			{
				return m_elementType;
			}
			set
			{
				m_elementType = value;
			}
		}

		public QualifiedName ReferenceTypeName
		{
			get
			{
				return m_referenceTypeName;
			}
			set
			{
				m_referenceTypeName = value;
			}
		}

		public bool IncludeSubtypes
		{
			get
			{
				return m_includeSubtypes;
			}
			set
			{
				m_includeSubtypes = value;
			}
		}

		public QualifiedName TargetName
		{
			get
			{
				return m_targetName;
			}
			set
			{
				m_targetName = value;
			}
		}

		public Element(RelativePathElement element, ITypeTable typeTree)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (typeTree == null)
			{
				throw new ArgumentNullException("typeTree");
			}
			m_referenceTypeName = null;
			m_targetName = element.TargetName;
			m_elementType = ElementType.ForwardReference;
			m_includeSubtypes = element.IncludeSubtypes;
			if (!element.IsInverse && element.IncludeSubtypes)
			{
				if (element.ReferenceTypeId == ReferenceTypeIds.HierarchicalReferences)
				{
					m_elementType = ElementType.AnyHierarchical;
				}
				else if (element.ReferenceTypeId == ReferenceTypeIds.Aggregates)
				{
					m_elementType = ElementType.AnyComponent;
				}
				else
				{
					m_referenceTypeName = typeTree.FindReferenceTypeName(element.ReferenceTypeId);
				}
			}
			else
			{
				if (element.IsInverse)
				{
					m_elementType = ElementType.InverseReference;
				}
				m_referenceTypeName = typeTree.FindReferenceTypeName(element.ReferenceTypeId);
			}
		}

		public Element()
		{
			m_elementType = ElementType.AnyHierarchical;
			m_referenceTypeName = null;
			m_includeSubtypes = true;
			m_targetName = null;
		}

		public override string ToString()
		{
			return ToString(null, null);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				switch (m_elementType)
				{
				case ElementType.AnyHierarchical:
					stringBuilder.Append('/');
					break;
				case ElementType.AnyComponent:
					stringBuilder.Append('.');
					break;
				case ElementType.ForwardReference:
				case ElementType.InverseReference:
					if (m_referenceTypeName != null && !string.IsNullOrEmpty(m_referenceTypeName.Name))
					{
						stringBuilder.Append('<');
						if (!m_includeSubtypes)
						{
							stringBuilder.Append('#');
						}
						if (m_elementType == ElementType.InverseReference)
						{
							stringBuilder.Append('!');
						}
						if (m_referenceTypeName.NamespaceIndex != 0)
						{
							stringBuilder.AppendFormat("{0}:", m_referenceTypeName.NamespaceIndex);
						}
						EncodeName(stringBuilder, m_referenceTypeName.Name);
						stringBuilder.Append('>');
					}
					break;
				}
				if (m_targetName != null && !string.IsNullOrEmpty(m_targetName.Name))
				{
					if (m_targetName.NamespaceIndex != 0)
					{
						stringBuilder.AppendFormat("{0}:", m_targetName.NamespaceIndex);
					}
					EncodeName(stringBuilder, m_targetName.Name);
				}
				return stringBuilder.ToString();
			}
			throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
		}

		public static Element Parse(StringReader reader)
		{
			Element element = new Element();
			switch (reader.Peek())
			{
			case 47:
				element.ElementType = ElementType.AnyHierarchical;
				reader.Read();
				break;
			case 46:
				element.ElementType = ElementType.AnyComponent;
				reader.Read();
				break;
			case 60:
				element.ElementType = ElementType.ForwardReference;
				reader.Read();
				if (reader.Peek() == 35)
				{
					element.IncludeSubtypes = false;
					reader.Read();
				}
				if (reader.Peek() == 33)
				{
					element.ElementType = ElementType.InverseReference;
					reader.Read();
				}
				element.ReferenceTypeName = ParseName(reader, referenceName: true);
				break;
			default:
				element.ElementType = ElementType.AnyHierarchical;
				break;
			}
			element.TargetName = ParseName(reader, referenceName: false);
			return element;
		}

		private static QualifiedName ParseName(StringReader reader, bool referenceName)
		{
			ushort num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = reader.Peek();
			int num3 = num2;
			while (num3 != -1)
			{
				if (!char.IsDigit((char)num3))
				{
					if (num3 == 58)
					{
						reader.Read();
						num = Convert.ToUInt16(stringBuilder.ToString(), CultureInfo.InvariantCulture);
						stringBuilder.Length = 0;
						num2 = reader.Peek();
					}
					break;
				}
				stringBuilder.Append((char)num3);
				reader.Read();
				num3 = reader.Peek();
				num2 = num3;
			}
			for (int num4 = num2; num4 != -1; num4 = reader.Peek())
			{
				num2 = num4;
				if (referenceName)
				{
					if (num4 == 62)
					{
						reader.Read();
						break;
					}
				}
				else if (num4 == 60 || num4 == 47 || num4 == 46)
				{
					break;
				}
				switch (num4)
				{
				case 38:
					num4 = reader.Read();
					if (num4 == -1)
					{
						throw new ServiceResultException(2159411200u, "Unexpected end after escape character '&'.");
					}
					num4 = reader.Read();
					if (num4 == 33 || num4 == 58 || num4 == 60 || num4 == 62 || num4 == 47 || num4 == 46 || num4 == 35 || num4 == 38)
					{
						stringBuilder.Append((char)num4);
						break;
					}
					throw new ServiceResultException(2159411200u, Utils.Format("Invalid escape sequence '&{0}' in browse path.", num4));
				default:
					if (num4 != 38)
					{
						stringBuilder.Append((char)num4);
						reader.Read();
						break;
					}
					goto case 33;
				case 33:
				case 35:
				case 46:
				case 47:
				case 58:
				case 60:
				case 62:
					throw new ServiceResultException(2159411200u, Utils.Format("Unexpected character '{0}' in browse path.", num4));
				}
			}
			if (referenceName && num2 != 62)
			{
				throw new ServiceResultException(2159411200u, Utils.Format("Missing closing '>' for reference type name in browse path."));
			}
			if (stringBuilder.Length == 0)
			{
				if (referenceName)
				{
					throw new ServiceResultException(2159411200u, Utils.Format("Reference type name is null in browse path."));
				}
				if (num == 0)
				{
					return null;
				}
			}
			return new QualifiedName(stringBuilder.ToString(), num);
		}

		private static void EncodeName(StringBuilder path, string name)
		{
			for (int i = 0; i < name.Length; i++)
			{
				switch (name[i])
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
				path.Append(name[i]);
			}
		}
	}

	public enum ElementType
	{
		AnyHierarchical = 1,
		AnyComponent,
		ForwardReference,
		InverseReference
	}

	private List<Element> m_elements;

	public List<Element> Elements => m_elements;

	public RelativePathFormatter(RelativePath relativePath, ITypeTable typeTree)
	{
		m_elements = new List<Element>();
		if (relativePath == null)
		{
			return;
		}
		foreach (RelativePathElement element in relativePath.Elements)
		{
			m_elements.Add(new Element(element, typeTree));
		}
	}

	public RelativePathFormatter()
	{
		m_elements = new List<Element>();
	}

	public void UpdateNamespaceTable(NamespaceTable currentTable, NamespaceTable targetTable)
	{
		int[] array = new int[currentTable.Count];
		array[0] = 0;
		if (array.Length != 0)
		{
			array[1] = 1;
		}
		if (targetTable.Count <= 1)
		{
			targetTable.Append("---");
		}
		string[] array2 = new string[array.Length];
		for (int i = 2; i < array.Length; i++)
		{
			array2[i] = currentTable.GetString((uint)i);
			if (array2[i] != null)
			{
				array[i] = targetTable.GetIndex(array2[i]);
			}
		}
		foreach (Element element in m_elements)
		{
			QualifiedName referenceTypeName = element.ReferenceTypeName;
			if (referenceTypeName != null && referenceTypeName.NamespaceIndex > 1 && referenceTypeName.NamespaceIndex < array.Length && array[referenceTypeName.NamespaceIndex] == -1)
			{
				array[referenceTypeName.NamespaceIndex] = targetTable.GetIndexOrAppend(array2[referenceTypeName.NamespaceIndex]);
			}
			referenceTypeName = element.TargetName;
			if (referenceTypeName != null && referenceTypeName.NamespaceIndex > 1 && referenceTypeName.NamespaceIndex < array.Length && array[referenceTypeName.NamespaceIndex] == -1)
			{
				array[referenceTypeName.NamespaceIndex] = targetTable.GetIndexOrAppend(array2[referenceTypeName.NamespaceIndex]);
			}
		}
	}

	public void TranslateNamespaceIndexes(NamespaceTable currentTable, NamespaceTable targetTable)
	{
		int[] array = new int[currentTable.Count];
		array[0] = 0;
		string[] array2 = new string[array.Length];
		for (int i = 1; i < array.Length; i++)
		{
			array2[i] = currentTable.GetString((uint)i);
			if (array2[i] != null)
			{
				array[i] = targetTable.GetIndex(array2[i]);
			}
		}
		foreach (Element element in m_elements)
		{
			QualifiedName referenceTypeName = element.ReferenceTypeName;
			if (referenceTypeName != null && referenceTypeName.NamespaceIndex > 0 && referenceTypeName.NamespaceIndex < array.Length && array[referenceTypeName.NamespaceIndex] > 0)
			{
				element.ReferenceTypeName = new QualifiedName(referenceTypeName.Name, (ushort)array[referenceTypeName.NamespaceIndex]);
			}
			referenceTypeName = element.TargetName;
			if (referenceTypeName != null && referenceTypeName.NamespaceIndex > 0 && referenceTypeName.NamespaceIndex < array.Length && array[referenceTypeName.NamespaceIndex] > 0)
			{
				element.TargetName = new QualifiedName(referenceTypeName.Name, (ushort)array[referenceTypeName.NamespaceIndex]);
			}
		}
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Element element in m_elements)
			{
				stringBuilder.AppendFormat("{0}", element);
			}
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public static bool IsEmpty(RelativePathFormatter relativePath)
	{
		if (relativePath != null)
		{
			return relativePath.Elements.Count == 0;
		}
		return true;
	}

	public static RelativePathFormatter Parse(string textToParse, NamespaceTable currentTable, NamespaceTable targetTable)
	{
		RelativePathFormatter relativePathFormatter = Parse(textToParse);
		relativePathFormatter?.TranslateNamespaceIndexes(currentTable, targetTable);
		return relativePathFormatter;
	}

	public static RelativePathFormatter Parse(string textToParse)
	{
		if (string.IsNullOrEmpty(textToParse))
		{
			return new RelativePathFormatter();
		}
		RelativePathFormatter relativePathFormatter = new RelativePathFormatter();
		try
		{
			StringReader stringReader = new StringReader(textToParse);
			while (stringReader.Peek() != -1)
			{
				Element item = Element.Parse(stringReader);
				relativePathFormatter.m_elements.Add(item);
			}
			return relativePathFormatter;
		}
		catch (Exception e)
		{
			throw new ServiceResultException(2151022592u, Utils.Format("Cannot parse relative path: '{0}'.", textToParse), e);
		}
	}
}
