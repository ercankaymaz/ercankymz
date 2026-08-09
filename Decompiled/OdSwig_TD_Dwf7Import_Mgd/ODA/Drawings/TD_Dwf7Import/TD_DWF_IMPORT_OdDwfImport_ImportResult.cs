using System;

namespace ODA.Drawings.TD_Dwf7Import;

[Flags]
public enum TD_DWF_IMPORT_OdDwfImport_ImportResult
{
	success = 0,
	fail = 1,
	bad_password = 2,
	bad_file = 3,
	bad_database = 4,
	encrypted_file = 5
}
