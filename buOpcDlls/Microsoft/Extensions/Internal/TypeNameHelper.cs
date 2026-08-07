// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Internal.TypeNameHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Text;

#nullable disable
namespace Microsoft.Extensions.Internal;

internal static class TypeNameHelper
{
  private const char DefaultNestedTypeDelimiter = '+';
  private static readonly Dictionary<Type, string> _builtInTypeNames = new Dictionary<Type, string>()
  {
    {
      typeof (void),
      "void"
    },
    {
      typeof (bool),
      "bool"
    },
    {
      typeof (byte),
      "byte"
    },
    {
      typeof (char),
      "char"
    },
    {
      typeof (Decimal),
      "decimal"
    },
    {
      typeof (double),
      "double"
    },
    {
      typeof (float),
      "float"
    },
    {
      typeof (int),
      "int"
    },
    {
      typeof (long),
      "long"
    },
    {
      typeof (object),
      "object"
    },
    {
      typeof (sbyte),
      "sbyte"
    },
    {
      typeof (short),
      "short"
    },
    {
      typeof (string),
      "string"
    },
    {
      typeof (uint),
      "uint"
    },
    {
      typeof (ulong),
      "ulong"
    },
    {
      typeof (ushort),
      "ushort"
    }
  };

  [NullableContext(2)]
  [return: NotNullIfNotNull("item")]
  public static string GetTypeDisplayName(object item, bool fullName = true)
  {
    return item != null ? TypeNameHelper.GetTypeDisplayName(item.GetType(), fullName) : (string) null;
  }

  [NullableContext(1)]
  public static string GetTypeDisplayName(
    Type type,
    bool fullName = true,
    bool includeGenericParameterNames = false,
    bool includeGenericParameters = true,
    char nestedTypeDelimiter = '+')
  {
    StringBuilder builder = new StringBuilder();
    TypeNameHelper.ProcessType(builder, type, new TypeNameHelper.DisplayNameOptions(fullName, includeGenericParameterNames, includeGenericParameters, nestedTypeDelimiter));
    return builder.ToString();
  }

  private static void ProcessType(
    StringBuilder builder,
    Type type,
    in TypeNameHelper.DisplayNameOptions options)
  {
    if (type.IsGenericType)
    {
      Type[] genericArguments = type.GetGenericArguments();
      TypeNameHelper.ProcessGenericType(builder, type, genericArguments, genericArguments.Length, in options);
    }
    else if (type.IsArray)
    {
      TypeNameHelper.ProcessArrayType(builder, type, in options);
    }
    else
    {
      string str1;
      if (TypeNameHelper._builtInTypeNames.TryGetValue(type, out str1))
        builder.Append(str1);
      else if (type.IsGenericParameter)
      {
        if (!options.IncludeGenericParameterNames)
          return;
        builder.Append(type.Name);
      }
      else
      {
        string str2 = options.FullName ? type.FullName : type.Name;
        builder.Append(str2);
        if (options.NestedTypeDelimiter == '+')
          return;
        builder.Replace('+', options.NestedTypeDelimiter, builder.Length - str2.Length, str2.Length);
      }
    }
  }

  private static void ProcessArrayType(
    StringBuilder builder,
    Type type,
    in TypeNameHelper.DisplayNameOptions options)
  {
    Type type1 = type;
    while (type1.IsArray)
      type1 = type1.GetElementType();
    TypeNameHelper.ProcessType(builder, type1, in options);
    for (; type.IsArray; type = type.GetElementType())
    {
      builder.Append('[');
      builder.Append(',', type.GetArrayRank() - 1);
      builder.Append(']');
    }
  }

  private static void ProcessGenericType(
    StringBuilder builder,
    Type type,
    Type[] genericArguments,
    int length,
    in TypeNameHelper.DisplayNameOptions options)
  {
    int length1 = 0;
    if (type.IsNested)
      length1 = type.DeclaringType.GetGenericArguments().Length;
    if (options.FullName)
    {
      if (type.IsNested)
      {
        TypeNameHelper.ProcessGenericType(builder, type.DeclaringType, genericArguments, length1, in options);
        builder.Append(options.NestedTypeDelimiter);
      }
      else if (!string.IsNullOrEmpty(type.Namespace))
      {
        builder.Append(type.Namespace);
        builder.Append('.');
      }
    }
    int count = type.Name.IndexOf('`');
    if (count <= 0)
    {
      builder.Append(type.Name);
    }
    else
    {
      builder.Append(type.Name, 0, count);
      if (!options.IncludeGenericParameters)
        return;
      builder.Append('<');
      for (int index = length1; index < length; ++index)
      {
        TypeNameHelper.ProcessType(builder, genericArguments[index], in options);
        if (index + 1 != length)
        {
          builder.Append(',');
          if (options.IncludeGenericParameterNames || !genericArguments[index + 1].IsGenericParameter)
            builder.Append(' ');
        }
      }
      builder.Append('>');
    }
  }

  private readonly struct DisplayNameOptions(
    bool fullName,
    bool includeGenericParameterNames,
    bool includeGenericParameters,
    char nestedTypeDelimiter)
  {
    public bool FullName { get; } = fullName;

    public bool IncludeGenericParameters { get; } = includeGenericParameters;

    public bool IncludeGenericParameterNames { get; } = includeGenericParameterNames;

    public char NestedTypeDelimiter { get; } = nestedTypeDelimiter;
  }
}
