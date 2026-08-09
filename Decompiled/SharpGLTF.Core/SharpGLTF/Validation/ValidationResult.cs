using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using SharpGLTF.Schema2;

namespace SharpGLTF.Validation;

[DebuggerStepThrough]
public sealed class ValidationResult
{
	private readonly ModelRoot _Root;

	private readonly ValidationMode _Mode;

	private readonly bool _InstantThrow;

	private readonly List<Exception> _Errors = new List<Exception>();

	public ModelRoot Root => _Root;

	public ValidationMode Mode => _Mode;

	public IEnumerable<Exception> Errors => _Errors;

	public bool HasErrors => _Errors.Count > 0;

	public ValidationResult(ModelRoot root, ValidationMode mode, bool instantThrow = false)
	{
		_Root = root;
		_Mode = mode;
		_InstantThrow = instantThrow;
	}

	public ValidationContext GetContext()
	{
		return new ValidationContext(this);
	}

	public void SetSchemaError(EndOfStreamException ex)
	{
		Guard.NotNull(ex, "ex");
		SetError(new SchemaException(null, ex.Message));
	}

	public void SetSchemaError(ModelRoot model, string error)
	{
		SetError(new SchemaException(model, error));
	}

	public void SetSchemaError(ModelRoot model, JsonException ex)
	{
		SetError(new SchemaException(model, ex));
	}

	public void SetModelError(FormatException ex)
	{
		SetError(new ModelException(null, ex));
	}

	public void SetModelError(ModelRoot model, ArgumentException ex)
	{
		SetError(new ModelException(model, ex));
	}

	public void SetError(ModelException ex)
	{
		if (_InstantThrow)
		{
			throw ex;
		}
		_Errors.Add(ex);
	}
}
