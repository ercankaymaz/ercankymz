using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Internal;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition;

[DebuggerTypeProxy(typeof(CompositionExceptionDebuggerProxy))]
[DebuggerDisplay("{Message}")]
public class CompositionException : Exception
{
	private struct VisitContext
	{
		public Stack<CompositionError> Path;

		public Action<Stack<CompositionError>> LeafVisitor;
	}

	private readonly ReadOnlyCollection<CompositionError> _errors;

	public ReadOnlyCollection<CompositionError> Errors => _errors;

	public override string Message
	{
		get
		{
			if (Errors.Count == 0)
			{
				return base.Message;
			}
			return BuildDefaultMessage();
		}
	}

	public ReadOnlyCollection<Exception> RootCauses
	{
		get
		{
			List<Exception> list = new List<Exception>();
			foreach (CompositionError error in Errors)
			{
				if (error.Exception != null)
				{
					if (error.Exception is CompositionException ex && ex.RootCauses.Count > 0)
					{
						list.AddRange(ex.RootCauses);
					}
					else
					{
						list.Add(error.Exception);
					}
				}
			}
			return list.ToReadOnlyCollection();
		}
	}

	public CompositionException()
		: this(null, null, null)
	{
	}

	public CompositionException(string? message)
		: this(message, null, null)
	{
	}

	public CompositionException(string? message, Exception? innerException)
		: this(message, innerException, null)
	{
	}

	internal CompositionException(CompositionError error)
		: this(new CompositionError[1] { error })
	{
	}

	public CompositionException(IEnumerable<CompositionError>? errors)
		: this(null, null, errors)
	{
	}

	internal CompositionException(string? message, Exception? innerException, IEnumerable<CompositionError>? errors)
		: base(message, innerException)
	{
		Requires.NullOrNotNullElements(errors, "errors");
		_errors = Array.AsReadOnly((errors == null) ? Array.Empty<CompositionError>() : errors.ToArray());
	}

	private string BuildDefaultMessage()
	{
		List<Stack<CompositionError>> list = CalculatePaths(this);
		StringBuilder stringBuilder = new StringBuilder();
		WriteHeader(stringBuilder, Errors.Count, list.Count);
		WritePaths(stringBuilder, list);
		return stringBuilder.ToString();
	}

	private static void WriteHeader(StringBuilder writer, int errorsCount, int pathCount)
	{
		if (errorsCount > 1 && pathCount > 1)
		{
			writer.AppendFormat(CultureInfo.CurrentCulture, System.SR.CompositionException_MultipleErrorsWithMultiplePaths, pathCount);
		}
		else if (errorsCount == 1 && pathCount > 1)
		{
			writer.AppendFormat(CultureInfo.CurrentCulture, System.SR.CompositionException_SingleErrorWithMultiplePaths, pathCount);
		}
		else
		{
			if (errorsCount != 1 || pathCount != 1)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			writer.AppendFormat(CultureInfo.CurrentCulture, System.SR.CompositionException_SingleErrorWithSinglePath, pathCount);
		}
		writer.Append(' ');
		writer.AppendLine(System.SR.CompositionException_ReviewErrorProperty);
	}

	private static void WritePaths(StringBuilder writer, List<Stack<CompositionError>> paths)
	{
		int num = 0;
		foreach (Stack<CompositionError> path in paths)
		{
			num++;
			WritePath(writer, path, num);
		}
	}

	private static void WritePath(StringBuilder writer, Stack<CompositionError> path, int ordinal)
	{
		writer.AppendLine();
		writer.Append(ordinal.ToString(CultureInfo.CurrentCulture));
		writer.Append(System.SR.CompositionException_PathsCountSeparator);
		writer.Append(' ');
		bool flag = false;
		foreach (CompositionError item in path)
		{
			if (flag)
			{
				writer.AppendLine().Append(System.SR.CompositionException_ErrorPrefix).Append(' ');
			}
			flag = true;
			WriteError(writer, item);
		}
	}

	private static void WriteError(StringBuilder writer, CompositionError error)
	{
		writer.AppendLine(error.Description);
		if (error.Element != null)
		{
			WriteElementGraph(writer, error.Element);
		}
	}

	private static void WriteElementGraph(StringBuilder writer, ICompositionElement element)
	{
		writer.AppendFormat(CultureInfo.CurrentCulture, System.SR.CompositionException_ElementPrefix, element.DisplayName);
		while ((element = element.Origin) != null)
		{
			writer.AppendFormat(CultureInfo.CurrentCulture, System.SR.CompositionException_OriginFormat, System.SR.CompositionException_OriginSeparator, element.DisplayName);
		}
		writer.AppendLine();
	}

	private static List<Stack<CompositionError>> CalculatePaths(CompositionException exception)
	{
		List<Stack<CompositionError>> paths = new List<Stack<CompositionError>>();
		VisitCompositionException(exception, new VisitContext
		{
			Path = new Stack<CompositionError>(),
			LeafVisitor = delegate(Stack<CompositionError> path)
			{
				paths.Add(path.Copy());
			}
		});
		return paths;
	}

	private static void VisitCompositionException(CompositionException exception, VisitContext context)
	{
		foreach (CompositionError error in exception.Errors)
		{
			VisitError(error, context);
		}
		if (exception.InnerException != null)
		{
			VisitException(exception.InnerException, context);
		}
	}

	private static void VisitError(CompositionError error, VisitContext context)
	{
		context.Path.Push(error);
		if (error.Exception == null)
		{
			context.LeafVisitor(context.Path);
		}
		else
		{
			VisitException(error.Exception, context);
		}
		context.Path.Pop();
	}

	private static void VisitException(Exception exception, VisitContext context)
	{
		if (exception is CompositionException exception2)
		{
			VisitCompositionException(exception2, context);
		}
		else
		{
			VisitError(new CompositionError(exception.Message, exception.InnerException), context);
		}
	}
}
