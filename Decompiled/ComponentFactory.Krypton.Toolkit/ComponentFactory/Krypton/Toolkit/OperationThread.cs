using System;

namespace ComponentFactory.Krypton.Toolkit;

internal class OperationThread : GlobalId
{
	private Operation _op;

	private object _parameter;

	private int _state;

	private object _result;

	private Exception _exception;

	public int State
	{
		get
		{
			lock (this)
			{
				return _state;
			}
		}
	}

	public object Result => _result;

	public Exception Exception => _exception;

	public OperationThread(Operation op, object parameter)
	{
		_op = op;
		_parameter = parameter;
		_state = 0;
	}

	public void Run()
	{
		try
		{
			_result = _op(_parameter);
			lock (this)
			{
				_state = 1;
			}
		}
		catch (Exception exception)
		{
			_exception = exception;
			lock (this)
			{
				_state = 2;
			}
		}
	}
}
