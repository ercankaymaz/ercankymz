#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCheckSet), "ToolboxBitmaps.KryptonCheckSet.bmp")]
[DefaultEvent("CheckedButtonChanged")]
[DefaultProperty("CheckButtons")]
[DesignerCategory("code")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonCheckSetDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Provide exclusive checked logic for a set of KryptonCheckButton controls.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonCheckSet : Component, ISupportInitialize
{
	public class KryptonCheckButtonCollection : CollectionBase
	{
		private KryptonCheckSet _owner;

		public KryptonCheckButton this[int index]
		{
			get
			{
				if (index < 0 || index > base.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return (KryptonCheckButton)base.List[index];
			}
		}

		public KryptonCheckButtonCollection(KryptonCheckSet owner)
		{
			Debug.Assert(owner != null);
			_owner = owner;
		}

		public int Add(KryptonCheckButton checkButton)
		{
			Debug.Assert(checkButton != null);
			if (checkButton == null)
			{
				throw new ArgumentNullException("checkButton");
			}
			if (Contains(checkButton))
			{
				throw new ArgumentException("Reference already exists in the collection");
			}
			base.List.Add(checkButton);
			return base.List.Count - 1;
		}

		public bool Contains(KryptonCheckButton checkButton)
		{
			return base.List.Contains(checkButton);
		}

		public int IndexOf(KryptonCheckButton checkButton)
		{
			return base.List.IndexOf(checkButton);
		}

		public void Insert(int index, KryptonCheckButton checkButton)
		{
			Debug.Assert(checkButton != null);
			if (checkButton == null)
			{
				throw new ArgumentNullException("checkButton");
			}
			if (index < 0 || index > base.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (Contains(checkButton))
			{
				throw new ArgumentException("Reference already in collection");
			}
			base.List.Insert(index, checkButton);
		}

		public void Remove(KryptonCheckButton checkButton)
		{
			Debug.Assert(checkButton != null);
			if (checkButton == null)
			{
				throw new ArgumentNullException("checkButton");
			}
			if (!Contains(checkButton))
			{
				throw new ArgumentException("No matching reference to remove");
			}
			base.List.Remove(checkButton);
		}

		protected override void OnClear()
		{
			foreach (KryptonCheckButton item in base.List)
			{
				_owner.CheckButtonRemoved(item);
			}
			base.OnClear();
		}

		protected override void OnInsertComplete(int index, object value)
		{
			_owner.CheckButtonAdded(value as KryptonCheckButton);
			base.OnInsertComplete(index, value);
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			_owner.CheckButtonRemoved(value as KryptonCheckButton);
			base.OnRemoveComplete(index, value);
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			_owner.CheckButtonRemoved(oldValue as KryptonCheckButton);
			_owner.CheckButtonAdded(newValue as KryptonCheckButton);
			base.OnSetComplete(index, oldValue, newValue);
		}
	}

	private bool _initializing;

	private bool _checkedChanged;

	private bool _ignoreEvents;

	private bool _allowUncheck;

	private KryptonCheckButton _checkedButton;

	private KryptonCheckButtonCollection _checkButtons;

	[Category("Behavior")]
	[Description("Is the current checked button allowed to be unchecked.")]
	[DefaultValue(false)]
	public bool AllowUncheck
	{
		get
		{
			return _allowUncheck;
		}
		set
		{
			_allowUncheck = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Determine which of the associated buttons is checked.")]
	[RefreshProperties(RefreshProperties.All)]
	[TypeConverter(typeof(KryptonCheckedButtonConverter))]
	[DefaultValue(null)]
	public KryptonCheckButton CheckedButton
	{
		get
		{
			return _checkedButton;
		}
		set
		{
			if (_checkedButton != value)
			{
				if (value != null && !CheckButtons.Contains(value))
				{
					throw new ArgumentOutOfRangeException("value", "Provided value is not a KryptonCheckButton associated with this set.");
				}
				_ignoreEvents = true;
				if (_checkedButton != null)
				{
					_checkedButton.Checked = false;
				}
				_checkedButton = value;
				if (_checkedButton != null)
				{
					_checkedButton.Checked = true;
				}
				_ignoreEvents = false;
				OnCheckedButtonChanged(EventArgs.Empty);
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Determine the index of the checked button.")]
	[RefreshProperties(RefreshProperties.All)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(-1)]
	public int CheckedIndex
	{
		get
		{
			if (CheckedButton == null)
			{
				return -1;
			}
			return CheckButtons.IndexOf(CheckedButton);
		}
		set
		{
			if (value < -1 || value >= CheckButtons.Count)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value == -1)
			{
				CheckedButton = null;
			}
			else
			{
				CheckedButton = CheckButtons[value];
			}
		}
	}

	[Category("Behavior")]
	[Description("Determine which of the associated buttons is checked.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("ComponentFactory.Krypton.Toolkit.KryptonCheckButtonCollectionEditor, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	[RefreshProperties(RefreshProperties.All)]
	public KryptonCheckButtonCollection CheckButtons => _checkButtons;

	[Category("Property Changed")]
	[Description("Occurs whenever the CheckedButton property has changed.")]
	public event EventHandler CheckedButtonChanged;

	public KryptonCheckSet()
	{
		_checkButtons = new KryptonCheckButtonCollection(this);
	}

	public KryptonCheckSet(IContainer container)
		: this()
	{
		Debug.Assert(container != null);
		if (container == null)
		{
			throw new ArgumentNullException("container");
		}
		container.Add(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	public void BeginInit()
	{
		_checkedChanged = false;
		_initializing = true;
	}

	public void EndInit()
	{
		_initializing = false;
		if (_checkedChanged)
		{
			OnCheckedButtonChanged(EventArgs.Empty);
		}
	}

	protected virtual void OnCheckedButtonChanged(EventArgs e)
	{
		if (!_initializing)
		{
			if (this.CheckedButtonChanged != null)
			{
				this.CheckedButtonChanged(this, e);
			}
		}
		else
		{
			_checkedChanged = true;
		}
	}

	private void CheckButtonAdded(KryptonCheckButton checkButton)
	{
		if (checkButton.Checked)
		{
			if (_checkedButton != null)
			{
				checkButton.Checked = false;
			}
			else
			{
				_checkedButton = checkButton;
				OnCheckedButtonChanged(EventArgs.Empty);
			}
		}
		checkButton.CheckedChanging += OnCheckedChanging;
		checkButton.CheckedChanged += OnCheckedChanged;
	}

	private void CheckButtonRemoved(KryptonCheckButton checkButton)
	{
		checkButton.CheckedChanging -= OnCheckedChanging;
		checkButton.CheckedChanged -= OnCheckedChanged;
		if (_checkedButton == checkButton)
		{
			_checkedButton = null;
			OnCheckedButtonChanged(EventArgs.Empty);
		}
	}

	private void OnCheckedChanging(object sender, CancelEventArgs e)
	{
		if (!_ignoreEvents)
		{
			KryptonCheckButton kryptonCheckButton = (KryptonCheckButton)sender;
			e.Cancel = kryptonCheckButton.Checked && !AllowUncheck;
		}
	}

	private void OnCheckedChanged(object sender, EventArgs e)
	{
		if (_ignoreEvents)
		{
			return;
		}
		KryptonCheckButton kryptonCheckButton = (KryptonCheckButton)sender;
		if (kryptonCheckButton.Checked)
		{
			if (_checkedButton != null)
			{
				_ignoreEvents = true;
				_checkedButton.Checked = false;
				_ignoreEvents = false;
			}
			_checkedButton = kryptonCheckButton;
		}
		else
		{
			_checkedButton = null;
		}
		OnCheckedButtonChanged(EventArgs.Empty);
	}
}
