using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AlarmConditionState(NodeState parent) : AcknowledgeableConditionState(parent)
{
	private const string SuppressedState_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFN1cHByZXNzZWRTdGF0ZQEA0SMALwEAIyPRIwAAABX/////AQEBAAAAAQAsIwEBAJ4jBAAAABVgiQoCAAAAAAACAAAASWQBANIjAC4ARNIjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEA1iMALgBE1iMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQDYIwAuAETYIwAAFQMCAAAAZW4KAAAAU3VwcHJlc3NlZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBANkjAC4ARNkjAAAVAwIAAABlbgwAAABVbnN1cHByZXNzZWQAFf////8BAf////8AAAAA";

	private const string OutOfServiceState_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAE91dE9mU2VydmljZVN0YXRlAQDzPwAvAQAjI/M/AAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEA9D8ALgBE9D8AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD4PwAuAET4PwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAPo/AC4ARPo/AAAVAwIAAABlbg4AAABPdXQgb2YgU2VydmljZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAPs/AC4ARPs/AAAVAwIAAABlbgoAAABJbiBTZXJ2aWNlABX/////AQH/////AAAAAA==";

	private const string ShelvingState_InitializationString = "//////////8EYIAKAQAAAAAADQAAAFNoZWx2aW5nU3RhdGUBANojAC8BAHEL2iMAAAEAAAABACwjAQEAniMGAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANsjAC8BAMgK2yMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDcIwAuAETcIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BAOAjAC8BAM8K4CMAAAAV/////wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQDhIwAuAEThIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAOQjAC4AROQjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEA5SMALgBE5SMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAP0jAC8BAIUL/SMAAAEBAQAAAAEA+QsAAQBVKwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD+IwAuAET+IwAAlgEAAAABACoBAXoAAAAMAAAAU2hlbHZpbmdUaW1lAQAiAf////8AAAAAAwAAAABVAAAASWYgbm90IDAsIHRoaXMgcGFyYW1ldGVyIHNwZWNpZmllcyBhIGZpeGVkIHRpbWUgZm9yIHdoaWNoIHRoZSBBbGFybSBpcyB0byBiZSBzaGVsdmVkLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAgAAABVbnNoZWx2ZQEA+yMALwEAgwv7IwAAAQEBAAAAAQD5CwABAFUrAAAAAARhggoEAAAAAAANAAAAT25lU2hvdFNoZWx2ZQEA/CMALwEAhAv8IwAAAQEBAAAAAQD5CwABAFUrAAAAAA==";

	private const string MaxTimeShelved_InitializationString = "//////////8VYIkKAgAAAAAADgAAAE1heFRpbWVTaGVsdmVkAQAAJAAuAEQAJAAAAQAiAf////8BAf////8AAAAA";

	private const string AudibleEnabled_InitializationString = "//////////8VYIkKAgAAAAAADgAAAEF1ZGlibGVFbmFibGVkAQAFQAAuAEQFQAAAAAH/////AQH/////AAAAAA==";

	private const string AudibleSound_InitializationString = "//////////8VYIkKAgAAAAAADAAAAEF1ZGlibGVTb3VuZAEABkAALwEAQkYGQAAAAQCzP/////8BAf////8AAAAA";

	private const string SilenceState_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFNpbGVuY2VTdGF0ZQEA/D8ALwEAIyP8PwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAP0/AC4ARP0/AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAAUAALgBEAUAAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQADQAAuAEQDQAAAFQMCAAAAZW4IAAAAU2lsZW5jZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAEQAAuAEQEQAAAFQMCAAAAZW4MAAAATm90IFNpbGVuY2VkABX/////AQH/////AAAAAA==";

	private const string OnDelay_InitializationString = "//////////8VYIkKAgAAAAAABwAAAE9uRGVsYXkBAAtAAC4ARAtAAAABACIB/////wEB/////wAAAAA=";

	private const string OffDelay_InitializationString = "//////////8VYIkKAgAAAAAACAAAAE9mZkRlbGF5AQAMQAAuAEQMQAAAAQAiAf////8BAf////8AAAAA";

	private const string FirstInGroupFlag_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAEZpcnN0SW5Hcm91cEZsYWcBAA1AAC8APw1AAAAAAf////8BAf////8AAAAA";

	private const string FirstInGroup_InitializationString = "//////////8EYIAKAQAAAAAADAAAAEZpcnN0SW5Hcm91cAEADkAALwEAFUAOQAAA/////wAAAAA=";

	private const string LatchedState_InitializationString = "//////////8VYIkKAgAAAAAADAAAAExhdGNoZWRTdGF0ZQEADkcALwEAIyMORwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAA9HAC4ARA9HAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAE0cALgBEE0cAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQAVRwAuAEQVRwAAFQMCAAAAZW4HAAAATGF0Y2hlZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBABZHAC4ARBZHAAAVAwIAAABlbgkAAABVbmxhdGNoZWQAFf////8BAf////8AAAAA";

	private const string ReAlarmTime_InitializationString = "//////////8VYIkKAgAAAAAACwAAAFJlQWxhcm1UaW1lAQAQQAAuAEQQQAAAAQAiAf////8BAf////8AAAAA";

	private const string ReAlarmRepeatCount_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAFJlQWxhcm1SZXBlYXRDb3VudAEAEUAALwA/EUAAAAAE/////wEB/////wAAAAA=";

	private const string Silence_InitializationString = "//////////8EYYIKBAAAAAAABwAAAFNpbGVuY2UBABJAAC8BABJAEkAAAAEBAQAAAAEA+QsAAQBaQwAAAAA=";

	private const string Suppress_InitializationString = "//////////8EYYIKBAAAAAAACAAAAFN1cHByZXNzAQATQAAvAQATQBNAAAABAQEAAAABAPkLAAEASUMAAAAA";

	private const string Unsuppress_InitializationString = "//////////8EYYIKBAAAAAAACgAAAFVuc3VwcHJlc3MBAMxFAC8BAMxFzEUAAAEBAQAAAAEA+QsAAQBJQwAAAAA=";

	private const string RemoveFromService_InitializationString = "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUZyb21TZXJ2aWNlAQDNRQAvAQDNRc1FAAABAQEAAAABAPkLAAEAa0MAAAAA";

	private const string PlaceInService_InitializationString = "//////////8EYYIKBAAAAAAADgAAAFBsYWNlSW5TZXJ2aWNlAQDORQAvAQDORc5FAAABAQEAAAABAPkLAAEAa0MAAAAA";

	private const string Reset_InitializationString = "//////////8EYYIKBAAAAAAABQAAAFJlc2V0AQAXRwAvAQAXRxdHAAABAQEAAAABAPkLAAEApToAAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGgAAAEFsYXJtQ29uZGl0aW9uVHlwZUluc3RhbmNlAQBjCwEAYwtjCwAA/////y4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKQVAC4ARKQVAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKUVAC4ARKUVAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCmFQAuAESmFQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApxUALgBEpxUAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKgVAC4ARKgVAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCpFQAuAESpFQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCrFQAuAESrFQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKwVAC4ARKwVAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQBuKwAuAERuKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQBvKwAuAERvKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAnCMALgBEnCMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQCdIwAuAESdIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQCtFQAuAEStFQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQCeIwAvAQAjI54jAAAAFf////8BAQUAAAABACwjAAEAsiMBACwjAAEAuyMBACwjAAEAyCMBACwjAAEA0SMBACwjAAEA2iMBAAAAFWCJCgIAAAAAAAIAAABJZAEAnyMALgBEnyMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAKcjAC8BACojpyMAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAqCMALgBEqCMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQCpIwAvAQAqI6kjAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAKojAC4ARKojAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAKsjAC8BACojqyMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEArCMALgBErCMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCtIwAuAEStIwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAryMALwEARCOvIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCuIwAvAQBDI64jAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCwIwAvAQBFI7AjAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAsSMALgBEsSMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCyIwAvAQAjI7IjAAAAFf////8BAQEAAAABACwjAQEAniMBAAAAFWCJCgIAAAAAAAIAAABJZAEAsyMALgBEsyMAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQDEIwAvAQCXI8QjAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAxSMALgBExSMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAyCMALwEAIyPIIwAAABX/////AQEBAAAAAQAsIwEBAJ4jBgAAABVgiQoCAAAAAAACAAAASWQBAMkjAC4ARMkjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAzCMALgBEzCMAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDNIwAuAETNIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAziMALgBEziMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQDPIwAuAETPIwAAFQMCAAAAZW4GAAAAQWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEA0CMALgBE0CMAABUDAgAAAGVuCAAAAEluYWN0aXZlABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASW5wdXROb2RlAQBwKwAuAERwKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU3VwcHJlc3NlZFN0YXRlAQDRIwAvAQAjI9EjAAAAFf////8BAQEAAAABACwjAQEAniMEAAAAFWCJCgIAAAAAAAIAAABJZAEA0iMALgBE0iMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDWIwAuAETWIwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBANgjAC4ARNgjAAAVAwIAAABlbgoAAABTdXBwcmVzc2VkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEA2SMALgBE2SMAABUDAgAAAGVuDAAAAFVuc3VwcHJlc3NlZAAV/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE91dE9mU2VydmljZVN0YXRlAQDzPwAvAQAjI/M/AAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEA9D8ALgBE9D8AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD4PwAuAET4PwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAPo/AC4ARPo/AAAVAwIAAABlbg4AAABPdXQgb2YgU2VydmljZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAPs/AC4ARPs/AAAVAwIAAABlbgoAAABJbiBTZXJ2aWNlABX/////AQH/////AAAAAARggAoBAAAAAAANAAAAU2hlbHZpbmdTdGF0ZQEA2iMALwEAcQvaIwAAAQAAAAEALCMBAQCeIwYAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEA2yMALwEAyArbIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBANwjAC4ARNwjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEA4CMALwEAzwrgIwAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAOEjAC4AROEjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEA5CMALgBE5CMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVW5zaGVsdmVUaW1lAQDlIwAuAETlIwAAAQAiAf////8BAf////8AAAAABGGCCgQAAAAAAAsAAABUaW1lZFNoZWx2ZQEA/SMALwEAhQv9IwAAAQEBAAAAAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAP4jAC4ARP4jAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQD7IwAvAQCDC/sjAAABAQEAAAABAPkLAAEAVSsAAAAABGGCCgQAAAAAAA0AAABPbmVTaG90U2hlbHZlAQD8IwAvAQCEC/wjAAABAQEAAAABAPkLAAEAVSsAAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQD/IwAuAET/IwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4VGltZVNoZWx2ZWQBAAAkAC4ARAAkAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAEF1ZGlibGVFbmFibGVkAQAFQAAuAEQFQAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQXVkaWJsZVNvdW5kAQAGQAAvAQBCRgZAAAABALM//////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFNpbGVuY2VTdGF0ZQEA/D8ALwEAIyP8PwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAP0/AC4ARP0/AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAAUAALgBEAUAAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQADQAAuAEQDQAAAFQMCAAAAZW4IAAAAU2lsZW5jZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAEQAAuAEQEQAAAFQMCAAAAZW4MAAAATm90IFNpbGVuY2VkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAT25EZWxheQEAC0AALgBEC0AAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2ZmRGVsYXkBAAxAAC4ARAxAAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEZpcnN0SW5Hcm91cEZsYWcBAA1AAC8APw1AAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAwAAABGaXJzdEluR3JvdXABAA5AAC8BABVADkAAAP////8AAAAAFWCJCgIAAAAAAAwAAABMYXRjaGVkU3RhdGUBAA5HAC8BACMjDkcAAAAV/////wEB/////wQAAAAVYIkKAgAAAAAAAgAAAElkAQAPRwAuAEQPRwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBABNHAC4ARBNHAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAFUcALgBEFUcAABUDAgAAAGVuBwAAAExhdGNoZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAWRwAuAEQWRwAAFQMCAAAAZW4JAAAAVW5sYXRjaGVkABX/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVBbGFybVRpbWUBABBAAC4ARBBAAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFJlQWxhcm1SZXBlYXRDb3VudAEAEUAALwA/EUAAAAAE/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAFNpbGVuY2UBABJAAC8BABJAEkAAAAEBAQAAAAEA+QsAAQBaQwAAAAAEYYIKBAAAAAAACAAAAFN1cHByZXNzAQATQAAvAQATQBNAAAABAQEAAAABAPkLAAEASUMAAAAABGGCCgQAAAAAAAoAAABVbnN1cHByZXNzAQDMRQAvAQDMRcxFAAABAQEAAAABAPkLAAEASUMAAAAABGGCCgQAAAAAABEAAABSZW1vdmVGcm9tU2VydmljZQEAzUUALwEAzUXNRQAAAQEBAAAAAQD5CwABAGtDAAAAAARhggoEAAAAAAAOAAAAUGxhY2VJblNlcnZpY2UBAM5FAC8BAM5FzkUAAAEBAQAAAAEA+QsAAQBrQwAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQAXRwAvAQAXRxdHAAABAQEAAAABAPkLAAEApToAAAAA";

	private TwoStateVariableState m_activeState;

	private PropertyState<NodeId> m_inputNode;

	private TwoStateVariableState m_suppressedState;

	private TwoStateVariableState m_outOfServiceState;

	private ShelvedStateMachineState m_shelvingState;

	private PropertyState<bool> m_suppressedOrShelved;

	private PropertyState<double> m_maxTimeShelved;

	private PropertyState<bool> m_audibleEnabled;

	private AudioVariableState m_audibleSound;

	private TwoStateVariableState m_silenceState;

	private PropertyState<double> m_onDelay;

	private PropertyState<double> m_offDelay;

	private BaseDataVariableState<bool> m_firstInGroupFlag;

	private AlarmGroupState m_firstInGroup;

	private TwoStateVariableState m_latchedState;

	private PropertyState<double> m_reAlarmTime;

	private BaseDataVariableState<short> m_reAlarmRepeatCount;

	private MethodState m_silenceMethod;

	private MethodState m_suppressMethod;

	private MethodState m_unsuppressMethod;

	private MethodState m_removeFromServiceMethod;

	private MethodState m_placeInServiceMethod;

	private MethodState m_resetMethod;

	public AlarmConditionShelveEventHandler OnShelve;

	public AlarmConditionTimedUnshelveEventHandler OnTimedUnshelve;

	public AlarmConditionUnshelveTimeValueEventHandler OnUpdateUnshelveTime;

	private DateTime m_unshelveTime;

	private bool m_oneShot;

	private Timer m_unshelveTimer;

	private Timer m_updateUnshelveTimer;

	private int m_unshelveTimeUpdateRate = 1000;

	public TwoStateVariableState ActiveState
	{
		get
		{
			return m_activeState;
		}
		set
		{
			if (m_activeState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_activeState = value;
		}
	}

	public PropertyState<NodeId> InputNode
	{
		get
		{
			return m_inputNode;
		}
		set
		{
			if (m_inputNode != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_inputNode = value;
		}
	}

	public TwoStateVariableState SuppressedState
	{
		get
		{
			return m_suppressedState;
		}
		set
		{
			if (m_suppressedState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_suppressedState = value;
		}
	}

	public TwoStateVariableState OutOfServiceState
	{
		get
		{
			return m_outOfServiceState;
		}
		set
		{
			if (m_outOfServiceState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_outOfServiceState = value;
		}
	}

	public ShelvedStateMachineState ShelvingState
	{
		get
		{
			return m_shelvingState;
		}
		set
		{
			if (m_shelvingState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_shelvingState = value;
		}
	}

	public PropertyState<bool> SuppressedOrShelved
	{
		get
		{
			return m_suppressedOrShelved;
		}
		set
		{
			if (m_suppressedOrShelved != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_suppressedOrShelved = value;
		}
	}

	public PropertyState<double> MaxTimeShelved
	{
		get
		{
			return m_maxTimeShelved;
		}
		set
		{
			if (m_maxTimeShelved != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxTimeShelved = value;
		}
	}

	public PropertyState<bool> AudibleEnabled
	{
		get
		{
			return m_audibleEnabled;
		}
		set
		{
			if (m_audibleEnabled != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_audibleEnabled = value;
		}
	}

	public AudioVariableState AudibleSound
	{
		get
		{
			return m_audibleSound;
		}
		set
		{
			if (m_audibleSound != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_audibleSound = value;
		}
	}

	public TwoStateVariableState SilenceState
	{
		get
		{
			return m_silenceState;
		}
		set
		{
			if (m_silenceState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_silenceState = value;
		}
	}

	public PropertyState<double> OnDelay
	{
		get
		{
			return m_onDelay;
		}
		set
		{
			if (m_onDelay != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_onDelay = value;
		}
	}

	public PropertyState<double> OffDelay
	{
		get
		{
			return m_offDelay;
		}
		set
		{
			if (m_offDelay != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_offDelay = value;
		}
	}

	public BaseDataVariableState<bool> FirstInGroupFlag
	{
		get
		{
			return m_firstInGroupFlag;
		}
		set
		{
			if (m_firstInGroupFlag != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_firstInGroupFlag = value;
		}
	}

	public AlarmGroupState FirstInGroup
	{
		get
		{
			return m_firstInGroup;
		}
		set
		{
			if (m_firstInGroup != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_firstInGroup = value;
		}
	}

	public TwoStateVariableState LatchedState
	{
		get
		{
			return m_latchedState;
		}
		set
		{
			if (m_latchedState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_latchedState = value;
		}
	}

	public PropertyState<double> ReAlarmTime
	{
		get
		{
			return m_reAlarmTime;
		}
		set
		{
			if (m_reAlarmTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_reAlarmTime = value;
		}
	}

	public BaseDataVariableState<short> ReAlarmRepeatCount
	{
		get
		{
			return m_reAlarmRepeatCount;
		}
		set
		{
			if (m_reAlarmRepeatCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_reAlarmRepeatCount = value;
		}
	}

	public MethodState Silence
	{
		get
		{
			return m_silenceMethod;
		}
		set
		{
			if (m_silenceMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_silenceMethod = value;
		}
	}

	public MethodState Suppress
	{
		get
		{
			return m_suppressMethod;
		}
		set
		{
			if (m_suppressMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_suppressMethod = value;
		}
	}

	public MethodState Unsuppress
	{
		get
		{
			return m_unsuppressMethod;
		}
		set
		{
			if (m_unsuppressMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_unsuppressMethod = value;
		}
	}

	public MethodState RemoveFromService
	{
		get
		{
			return m_removeFromServiceMethod;
		}
		set
		{
			if (m_removeFromServiceMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeFromServiceMethod = value;
		}
	}

	public MethodState PlaceInService
	{
		get
		{
			return m_placeInServiceMethod;
		}
		set
		{
			if (m_placeInServiceMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_placeInServiceMethod = value;
		}
	}

	public MethodState Reset
	{
		get
		{
			return m_resetMethod;
		}
		set
		{
			if (m_resetMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resetMethod = value;
		}
	}

	public int UnshelveTimeUpdateRate
	{
		get
		{
			return m_unshelveTimeUpdateRate;
		}
		set
		{
			m_unshelveTimeUpdateRate = value;
		}
	}

	public DateTime UnshelveTime => m_unshelveTime;

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2915u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGgAAAEFsYXJtQ29uZGl0aW9uVHlwZUluc3RhbmNlAQBjCwEAYwtjCwAA/////y4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKQVAC4ARKQVAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKUVAC4ARKUVAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCmFQAuAESmFQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApxUALgBEpxUAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKgVAC4ARKgVAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCpFQAuAESpFQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCrFQAuAESrFQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKwVAC4ARKwVAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQBuKwAuAERuKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQBvKwAuAERvKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAnCMALgBEnCMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQCdIwAuAESdIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQCtFQAuAEStFQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQCeIwAvAQAjI54jAAAAFf////8BAQUAAAABACwjAAEAsiMBACwjAAEAuyMBACwjAAEAyCMBACwjAAEA0SMBACwjAAEA2iMBAAAAFWCJCgIAAAAAAAIAAABJZAEAnyMALgBEnyMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAKcjAC8BACojpyMAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAqCMALgBEqCMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQCpIwAvAQAqI6kjAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAKojAC4ARKojAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAKsjAC8BACojqyMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEArCMALgBErCMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCtIwAuAEStIwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAryMALwEARCOvIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCuIwAvAQBDI64jAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCwIwAvAQBFI7AjAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAsSMALgBEsSMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCyIwAvAQAjI7IjAAAAFf////8BAQEAAAABACwjAQEAniMBAAAAFWCJCgIAAAAAAAIAAABJZAEAsyMALgBEsyMAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQDEIwAvAQCXI8QjAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAxSMALgBExSMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAyCMALwEAIyPIIwAAABX/////AQEBAAAAAQAsIwEBAJ4jBgAAABVgiQoCAAAAAAACAAAASWQBAMkjAC4ARMkjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAzCMALgBEzCMAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDNIwAuAETNIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAziMALgBEziMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQDPIwAuAETPIwAAFQMCAAAAZW4GAAAAQWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEA0CMALgBE0CMAABUDAgAAAGVuCAAAAEluYWN0aXZlABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASW5wdXROb2RlAQBwKwAuAERwKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU3VwcHJlc3NlZFN0YXRlAQDRIwAvAQAjI9EjAAAAFf////8BAQEAAAABACwjAQEAniMEAAAAFWCJCgIAAAAAAAIAAABJZAEA0iMALgBE0iMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDWIwAuAETWIwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBANgjAC4ARNgjAAAVAwIAAABlbgoAAABTdXBwcmVzc2VkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEA2SMALgBE2SMAABUDAgAAAGVuDAAAAFVuc3VwcHJlc3NlZAAV/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE91dE9mU2VydmljZVN0YXRlAQDzPwAvAQAjI/M/AAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEA9D8ALgBE9D8AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD4PwAuAET4PwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAPo/AC4ARPo/AAAVAwIAAABlbg4AAABPdXQgb2YgU2VydmljZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAPs/AC4ARPs/AAAVAwIAAABlbgoAAABJbiBTZXJ2aWNlABX/////AQH/////AAAAAARggAoBAAAAAAANAAAAU2hlbHZpbmdTdGF0ZQEA2iMALwEAcQvaIwAAAQAAAAEALCMBAQCeIwYAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEA2yMALwEAyArbIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBANwjAC4ARNwjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEA4CMALwEAzwrgIwAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAOEjAC4AROEjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEA5CMALgBE5CMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVW5zaGVsdmVUaW1lAQDlIwAuAETlIwAAAQAiAf////8BAf////8AAAAABGGCCgQAAAAAAAsAAABUaW1lZFNoZWx2ZQEA/SMALwEAhQv9IwAAAQEBAAAAAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAP4jAC4ARP4jAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQD7IwAvAQCDC/sjAAABAQEAAAABAPkLAAEAVSsAAAAABGGCCgQAAAAAAA0AAABPbmVTaG90U2hlbHZlAQD8IwAvAQCEC/wjAAABAQEAAAABAPkLAAEAVSsAAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQD/IwAuAET/IwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4VGltZVNoZWx2ZWQBAAAkAC4ARAAkAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAEF1ZGlibGVFbmFibGVkAQAFQAAuAEQFQAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQXVkaWJsZVNvdW5kAQAGQAAvAQBCRgZAAAABALM//////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFNpbGVuY2VTdGF0ZQEA/D8ALwEAIyP8PwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAP0/AC4ARP0/AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAAUAALgBEAUAAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQADQAAuAEQDQAAAFQMCAAAAZW4IAAAAU2lsZW5jZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAEQAAuAEQEQAAAFQMCAAAAZW4MAAAATm90IFNpbGVuY2VkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAT25EZWxheQEAC0AALgBEC0AAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2ZmRGVsYXkBAAxAAC4ARAxAAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEZpcnN0SW5Hcm91cEZsYWcBAA1AAC8APw1AAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAwAAABGaXJzdEluR3JvdXABAA5AAC8BABVADkAAAP////8AAAAAFWCJCgIAAAAAAAwAAABMYXRjaGVkU3RhdGUBAA5HAC8BACMjDkcAAAAV/////wEB/////wQAAAAVYIkKAgAAAAAAAgAAAElkAQAPRwAuAEQPRwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBABNHAC4ARBNHAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAFUcALgBEFUcAABUDAgAAAGVuBwAAAExhdGNoZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAWRwAuAEQWRwAAFQMCAAAAZW4JAAAAVW5sYXRjaGVkABX/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVBbGFybVRpbWUBABBAAC4ARBBAAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFJlQWxhcm1SZXBlYXRDb3VudAEAEUAALwA/EUAAAAAE/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAFNpbGVuY2UBABJAAC8BABJAEkAAAAEBAQAAAAEA+QsAAQBaQwAAAAAEYYIKBAAAAAAACAAAAFN1cHByZXNzAQATQAAvAQATQBNAAAABAQEAAAABAPkLAAEASUMAAAAABGGCCgQAAAAAAAoAAABVbnN1cHByZXNzAQDMRQAvAQDMRcxFAAABAQEAAAABAPkLAAEASUMAAAAABGGCCgQAAAAAABEAAABSZW1vdmVGcm9tU2VydmljZQEAzUUALwEAzUXNRQAAAQEBAAAAAQD5CwABAGtDAAAAAARhggoEAAAAAAAOAAAAUGxhY2VJblNlcnZpY2UBAM5FAC8BAM5FzkUAAAEBAQAAAAEA+QsAAQBrQwAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQAXRwAvAQAXRxdHAAABAQEAAAABAPkLAAEApToAAAAA");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
		if (SuppressedState != null)
		{
			SuppressedState.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFN1cHByZXNzZWRTdGF0ZQEA0SMALwEAIyPRIwAAABX/////AQEBAAAAAQAsIwEBAJ4jBAAAABVgiQoCAAAAAAACAAAASWQBANIjAC4ARNIjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEA1iMALgBE1iMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQDYIwAuAETYIwAAFQMCAAAAZW4KAAAAU3VwcHJlc3NlZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBANkjAC4ARNkjAAAVAwIAAABlbgwAAABVbnN1cHByZXNzZWQAFf////8BAf////8AAAAA");
		}
		if (OutOfServiceState != null)
		{
			OutOfServiceState.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAE91dE9mU2VydmljZVN0YXRlAQDzPwAvAQAjI/M/AAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEA9D8ALgBE9D8AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD4PwAuAET4PwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAPo/AC4ARPo/AAAVAwIAAABlbg4AAABPdXQgb2YgU2VydmljZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAPs/AC4ARPs/AAAVAwIAAABlbgoAAABJbiBTZXJ2aWNlABX/////AQH/////AAAAAA==");
		}
		if (ShelvingState != null)
		{
			ShelvingState.Initialize(context, "//////////8EYIAKAQAAAAAADQAAAFNoZWx2aW5nU3RhdGUBANojAC8BAHEL2iMAAAEAAAABACwjAQEAniMGAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANsjAC8BAMgK2yMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDcIwAuAETcIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BAOAjAC8BAM8K4CMAAAAV/////wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQDhIwAuAEThIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAOQjAC4AROQjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEA5SMALgBE5SMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAP0jAC8BAIUL/SMAAAEBAQAAAAEA+QsAAQBVKwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD+IwAuAET+IwAAlgEAAAABACoBAXoAAAAMAAAAU2hlbHZpbmdUaW1lAQAiAf////8AAAAAAwAAAABVAAAASWYgbm90IDAsIHRoaXMgcGFyYW1ldGVyIHNwZWNpZmllcyBhIGZpeGVkIHRpbWUgZm9yIHdoaWNoIHRoZSBBbGFybSBpcyB0byBiZSBzaGVsdmVkLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAgAAABVbnNoZWx2ZQEA+yMALwEAgwv7IwAAAQEBAAAAAQD5CwABAFUrAAAAAARhggoEAAAAAAANAAAAT25lU2hvdFNoZWx2ZQEA/CMALwEAhAv8IwAAAQEBAAAAAQD5CwABAFUrAAAAAA==");
		}
		if (MaxTimeShelved != null)
		{
			MaxTimeShelved.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAE1heFRpbWVTaGVsdmVkAQAAJAAuAEQAJAAAAQAiAf////8BAf////8AAAAA");
		}
		if (AudibleEnabled != null)
		{
			AudibleEnabled.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAEF1ZGlibGVFbmFibGVkAQAFQAAuAEQFQAAAAAH/////AQH/////AAAAAA==");
		}
		if (AudibleSound != null)
		{
			AudibleSound.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAEF1ZGlibGVTb3VuZAEABkAALwEAQkYGQAAAAQCzP/////8BAf////8AAAAA");
		}
		if (SilenceState != null)
		{
			SilenceState.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFNpbGVuY2VTdGF0ZQEA/D8ALwEAIyP8PwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAP0/AC4ARP0/AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAAUAALgBEAUAAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQADQAAuAEQDQAAAFQMCAAAAZW4IAAAAU2lsZW5jZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAEQAAuAEQEQAAAFQMCAAAAZW4MAAAATm90IFNpbGVuY2VkABX/////AQH/////AAAAAA==");
		}
		if (OnDelay != null)
		{
			OnDelay.Initialize(context, "//////////8VYIkKAgAAAAAABwAAAE9uRGVsYXkBAAtAAC4ARAtAAAABACIB/////wEB/////wAAAAA=");
		}
		if (OffDelay != null)
		{
			OffDelay.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAE9mZkRlbGF5AQAMQAAuAEQMQAAAAQAiAf////8BAf////8AAAAA");
		}
		if (FirstInGroupFlag != null)
		{
			FirstInGroupFlag.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEZpcnN0SW5Hcm91cEZsYWcBAA1AAC8APw1AAAAAAf////8BAf////8AAAAA");
		}
		if (FirstInGroup != null)
		{
			FirstInGroup.Initialize(context, "//////////8EYIAKAQAAAAAADAAAAEZpcnN0SW5Hcm91cAEADkAALwEAFUAOQAAA/////wAAAAA=");
		}
		if (LatchedState != null)
		{
			LatchedState.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAExhdGNoZWRTdGF0ZQEADkcALwEAIyMORwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAA9HAC4ARA9HAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAE0cALgBEE0cAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQAVRwAuAEQVRwAAFQMCAAAAZW4HAAAATGF0Y2hlZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBABZHAC4ARBZHAAAVAwIAAABlbgkAAABVbmxhdGNoZWQAFf////8BAf////8AAAAA");
		}
		if (ReAlarmTime != null)
		{
			ReAlarmTime.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAFJlQWxhcm1UaW1lAQAQQAAuAEQQQAAAAQAiAf////8BAf////8AAAAA");
		}
		if (ReAlarmRepeatCount != null)
		{
			ReAlarmRepeatCount.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAFJlQWxhcm1SZXBlYXRDb3VudAEAEUAALwA/EUAAAAAE/////wEB/////wAAAAA=");
		}
		if (Silence != null)
		{
			Silence.Initialize(context, "//////////8EYYIKBAAAAAAABwAAAFNpbGVuY2UBABJAAC8BABJAEkAAAAEBAQAAAAEA+QsAAQBaQwAAAAA=");
		}
		if (Suppress != null)
		{
			Suppress.Initialize(context, "//////////8EYYIKBAAAAAAACAAAAFN1cHByZXNzAQATQAAvAQATQBNAAAABAQEAAAABAPkLAAEASUMAAAAA");
		}
		if (Unsuppress != null)
		{
			Unsuppress.Initialize(context, "//////////8EYYIKBAAAAAAACgAAAFVuc3VwcHJlc3MBAMxFAC8BAMxFzEUAAAEBAQAAAAEA+QsAAQBJQwAAAAA=");
		}
		if (RemoveFromService != null)
		{
			RemoveFromService.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUZyb21TZXJ2aWNlAQDNRQAvAQDNRc1FAAABAQEAAAABAPkLAAEAa0MAAAAA");
		}
		if (PlaceInService != null)
		{
			PlaceInService.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFBsYWNlSW5TZXJ2aWNlAQDORQAvAQDORc5FAAABAQEAAAABAPkLAAEAa0MAAAAA");
		}
		if (Reset != null)
		{
			Reset.Initialize(context, "//////////8EYYIKBAAAAAAABQAAAFJlc2V0AQAXRwAvAQAXRxdHAAABAQEAAAABAPkLAAEApToAAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_activeState != null)
		{
			children.Add(m_activeState);
		}
		if (m_inputNode != null)
		{
			children.Add(m_inputNode);
		}
		if (m_suppressedState != null)
		{
			children.Add(m_suppressedState);
		}
		if (m_outOfServiceState != null)
		{
			children.Add(m_outOfServiceState);
		}
		if (m_shelvingState != null)
		{
			children.Add(m_shelvingState);
		}
		if (m_suppressedOrShelved != null)
		{
			children.Add(m_suppressedOrShelved);
		}
		if (m_maxTimeShelved != null)
		{
			children.Add(m_maxTimeShelved);
		}
		if (m_audibleEnabled != null)
		{
			children.Add(m_audibleEnabled);
		}
		if (m_audibleSound != null)
		{
			children.Add(m_audibleSound);
		}
		if (m_silenceState != null)
		{
			children.Add(m_silenceState);
		}
		if (m_onDelay != null)
		{
			children.Add(m_onDelay);
		}
		if (m_offDelay != null)
		{
			children.Add(m_offDelay);
		}
		if (m_firstInGroupFlag != null)
		{
			children.Add(m_firstInGroupFlag);
		}
		if (m_firstInGroup != null)
		{
			children.Add(m_firstInGroup);
		}
		if (m_latchedState != null)
		{
			children.Add(m_latchedState);
		}
		if (m_reAlarmTime != null)
		{
			children.Add(m_reAlarmTime);
		}
		if (m_reAlarmRepeatCount != null)
		{
			children.Add(m_reAlarmRepeatCount);
		}
		if (m_silenceMethod != null)
		{
			children.Add(m_silenceMethod);
		}
		if (m_suppressMethod != null)
		{
			children.Add(m_suppressMethod);
		}
		if (m_unsuppressMethod != null)
		{
			children.Add(m_unsuppressMethod);
		}
		if (m_removeFromServiceMethod != null)
		{
			children.Add(m_removeFromServiceMethod);
		}
		if (m_placeInServiceMethod != null)
		{
			children.Add(m_placeInServiceMethod);
		}
		if (m_resetMethod != null)
		{
			children.Add(m_resetMethod);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "ActiveState":
			if (createOrReplace && ActiveState == null)
			{
				if (replacement == null)
				{
					ActiveState = new TwoStateVariableState(this);
				}
				else
				{
					ActiveState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = ActiveState;
			break;
		case "InputNode":
			if (createOrReplace && InputNode == null)
			{
				if (replacement == null)
				{
					InputNode = new PropertyState<NodeId>(this);
				}
				else
				{
					InputNode = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = InputNode;
			break;
		case "SuppressedState":
			if (createOrReplace && SuppressedState == null)
			{
				if (replacement == null)
				{
					SuppressedState = new TwoStateVariableState(this);
				}
				else
				{
					SuppressedState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = SuppressedState;
			break;
		case "OutOfServiceState":
			if (createOrReplace && OutOfServiceState == null)
			{
				if (replacement == null)
				{
					OutOfServiceState = new TwoStateVariableState(this);
				}
				else
				{
					OutOfServiceState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = OutOfServiceState;
			break;
		case "ShelvingState":
			if (createOrReplace && ShelvingState == null)
			{
				if (replacement == null)
				{
					ShelvingState = new ShelvedStateMachineState(this);
				}
				else
				{
					ShelvingState = (ShelvedStateMachineState)replacement;
				}
			}
			baseInstanceState = ShelvingState;
			break;
		case "SuppressedOrShelved":
			if (createOrReplace && SuppressedOrShelved == null)
			{
				if (replacement == null)
				{
					SuppressedOrShelved = new PropertyState<bool>(this);
				}
				else
				{
					SuppressedOrShelved = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = SuppressedOrShelved;
			break;
		case "MaxTimeShelved":
			if (createOrReplace && MaxTimeShelved == null)
			{
				if (replacement == null)
				{
					MaxTimeShelved = new PropertyState<double>(this);
				}
				else
				{
					MaxTimeShelved = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = MaxTimeShelved;
			break;
		case "AudibleEnabled":
			if (createOrReplace && AudibleEnabled == null)
			{
				if (replacement == null)
				{
					AudibleEnabled = new PropertyState<bool>(this);
				}
				else
				{
					AudibleEnabled = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = AudibleEnabled;
			break;
		case "AudibleSound":
			if (createOrReplace && AudibleSound == null)
			{
				if (replacement == null)
				{
					AudibleSound = new AudioVariableState(this);
				}
				else
				{
					AudibleSound = (AudioVariableState)replacement;
				}
			}
			baseInstanceState = AudibleSound;
			break;
		case "SilenceState":
			if (createOrReplace && SilenceState == null)
			{
				if (replacement == null)
				{
					SilenceState = new TwoStateVariableState(this);
				}
				else
				{
					SilenceState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = SilenceState;
			break;
		case "OnDelay":
			if (createOrReplace && OnDelay == null)
			{
				if (replacement == null)
				{
					OnDelay = new PropertyState<double>(this);
				}
				else
				{
					OnDelay = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = OnDelay;
			break;
		case "OffDelay":
			if (createOrReplace && OffDelay == null)
			{
				if (replacement == null)
				{
					OffDelay = new PropertyState<double>(this);
				}
				else
				{
					OffDelay = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = OffDelay;
			break;
		case "FirstInGroupFlag":
			if (createOrReplace && FirstInGroupFlag == null)
			{
				if (replacement == null)
				{
					FirstInGroupFlag = new BaseDataVariableState<bool>(this);
				}
				else
				{
					FirstInGroupFlag = (BaseDataVariableState<bool>)replacement;
				}
			}
			baseInstanceState = FirstInGroupFlag;
			break;
		case "FirstInGroup":
			if (createOrReplace && FirstInGroup == null)
			{
				if (replacement == null)
				{
					FirstInGroup = new AlarmGroupState(this);
				}
				else
				{
					FirstInGroup = (AlarmGroupState)replacement;
				}
			}
			baseInstanceState = FirstInGroup;
			break;
		case "LatchedState":
			if (createOrReplace && LatchedState == null)
			{
				if (replacement == null)
				{
					LatchedState = new TwoStateVariableState(this);
				}
				else
				{
					LatchedState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = LatchedState;
			break;
		case "ReAlarmTime":
			if (createOrReplace && ReAlarmTime == null)
			{
				if (replacement == null)
				{
					ReAlarmTime = new PropertyState<double>(this);
				}
				else
				{
					ReAlarmTime = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = ReAlarmTime;
			break;
		case "ReAlarmRepeatCount":
			if (createOrReplace && ReAlarmRepeatCount == null)
			{
				if (replacement == null)
				{
					ReAlarmRepeatCount = new BaseDataVariableState<short>(this);
				}
				else
				{
					ReAlarmRepeatCount = (BaseDataVariableState<short>)replacement;
				}
			}
			baseInstanceState = ReAlarmRepeatCount;
			break;
		case "Silence":
			if (createOrReplace && Silence == null)
			{
				if (replacement == null)
				{
					Silence = new MethodState(this);
				}
				else
				{
					Silence = (MethodState)replacement;
				}
			}
			baseInstanceState = Silence;
			break;
		case "Suppress":
			if (createOrReplace && Suppress == null)
			{
				if (replacement == null)
				{
					Suppress = new MethodState(this);
				}
				else
				{
					Suppress = (MethodState)replacement;
				}
			}
			baseInstanceState = Suppress;
			break;
		case "Unsuppress":
			if (createOrReplace && Unsuppress == null)
			{
				if (replacement == null)
				{
					Unsuppress = new MethodState(this);
				}
				else
				{
					Unsuppress = (MethodState)replacement;
				}
			}
			baseInstanceState = Unsuppress;
			break;
		case "RemoveFromService":
			if (createOrReplace && RemoveFromService == null)
			{
				if (replacement == null)
				{
					RemoveFromService = new MethodState(this);
				}
				else
				{
					RemoveFromService = (MethodState)replacement;
				}
			}
			baseInstanceState = RemoveFromService;
			break;
		case "PlaceInService":
			if (createOrReplace && PlaceInService == null)
			{
				if (replacement == null)
				{
					PlaceInService = new MethodState(this);
				}
				else
				{
					PlaceInService = (MethodState)replacement;
				}
			}
			baseInstanceState = PlaceInService;
			break;
		case "Reset":
			if (createOrReplace && Reset == null)
			{
				if (replacement == null)
				{
					Reset = new MethodState(this);
				}
				else
				{
					Reset = (MethodState)replacement;
				}
			}
			baseInstanceState = Reset;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	protected override void OnAfterCreate(ISystemContext context, NodeState node)
	{
		base.OnAfterCreate(context, node);
		if (ShelvingState != null)
		{
			if (ShelvingState.UnshelveTime != null)
			{
				ShelvingState.UnshelveTime.OnSimpleReadValue = OnReadUnshelveTime;
				ShelvingState.UnshelveTime.MinimumSamplingInterval = 1000.0;
			}
			ShelvingState.OneShotShelve.OnCallMethod = OnOneShotShelve;
			ShelvingState.OneShotShelve.OnReadExecutable = IsOneShotShelveExecutable;
			ShelvingState.OneShotShelve.OnReadUserExecutable = IsOneShotShelveExecutable;
			ShelvingState.TimedShelve.OnCall = OnTimedShelve;
			ShelvingState.TimedShelve.OnReadExecutable = IsTimedShelveExecutable;
			ShelvingState.TimedShelve.OnReadUserExecutable = IsTimedShelveExecutable;
			ShelvingState.Unshelve.OnCallMethod = OnUnshelve;
			ShelvingState.Unshelve.OnReadExecutable = IsUnshelveExecutable;
			ShelvingState.Unshelve.OnReadUserExecutable = IsUnshelveExecutable;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (m_unshelveTimer != null)
			{
				m_unshelveTimer.Dispose();
				m_unshelveTimer = null;
			}
			if (m_updateUnshelveTimer != null)
			{
				m_updateUnshelveTimer.Dispose();
				m_updateUnshelveTimer = null;
			}
		}
		base.Dispose(disposing);
	}

	public virtual void SetActiveEffectiveSubState(ISystemContext context, LocalizedText displayName, DateTime transitionTime)
	{
		if (ActiveState.EffectiveDisplayName != null)
		{
			ActiveState.EffectiveDisplayName.Value = displayName;
		}
		if (ActiveState.EffectiveTransitionTime != null)
		{
			if (transitionTime != DateTime.MinValue)
			{
				ActiveState.EffectiveTransitionTime.Value = transitionTime;
			}
			else
			{
				ActiveState.EffectiveTransitionTime.Value = DateTime.UtcNow;
			}
		}
	}

	public virtual void SetActiveState(ISystemContext context, bool active)
	{
		TranslationInfo translationInfo = null;
		if (active)
		{
			translationInfo = new TranslationInfo("ConditionStateActive", "en-US", "Active");
		}
		else
		{
			if (ShelvingState != null && m_oneShot)
			{
				SetShelvingState(context, shelved: false, oneShot: false, 0.0);
			}
			translationInfo = new TranslationInfo("ConditionStateInactive", "en-US", "Inactive");
		}
		ActiveState.Value = new LocalizedText(translationInfo);
		ActiveState.Id.Value = active;
		if (ActiveState.TransitionTime != null)
		{
			ActiveState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	public virtual void SetSuppressedState(ISystemContext context, bool suppressed)
	{
		if (SuppressedState == null)
		{
			return;
		}
		TranslationInfo translationInfo = null;
		if (suppressed)
		{
			SuppressedOrShelved.Value = true;
			translationInfo = new TranslationInfo("ConditionStateSuppressed", "en-US", "Suppressed");
		}
		else
		{
			if (ShelvingState == null || ShelvingState.CurrentState.Id.Value == ObjectIds.ShelvedStateMachineType_Unshelved)
			{
				SuppressedOrShelved.Value = false;
			}
			translationInfo = new TranslationInfo("ConditionStateUnsuppressed", "en-US", "Unsuppressed");
		}
		SuppressedState.Value = new LocalizedText(translationInfo);
		SuppressedState.Id.Value = suppressed;
		if (SuppressedState.TransitionTime != null)
		{
			SuppressedState.TransitionTime.Value = DateTime.UtcNow;
		}
		UpdateEffectiveState(context);
	}

	public virtual void SetShelvingState(ISystemContext context, bool shelved, bool oneShot, double shelvingTime)
	{
		if (ShelvingState == null)
		{
			return;
		}
		if (m_unshelveTimer != null)
		{
			m_unshelveTimer.Dispose();
			m_unshelveTimer = null;
		}
		if (m_updateUnshelveTimer != null)
		{
			m_updateUnshelveTimer.Dispose();
			m_updateUnshelveTimer = null;
		}
		m_unshelveTime = DateTime.MinValue;
		if (!shelved)
		{
			if (SuppressedState == null || !SuppressedState.Id.Value)
			{
				SuppressedOrShelved.Value = false;
			}
			ShelvingState.UnshelveTime.Value = 0.0;
			ShelvingState.CauseProcessingCompleted(context, 2947u);
		}
		else
		{
			SuppressedOrShelved.Value = true;
			m_oneShot = oneShot;
			double num = double.MaxValue;
			if (MaxTimeShelved != null && MaxTimeShelved.Value > 0.0)
			{
				num = MaxTimeShelved.Value;
			}
			double num2 = num;
			uint causeId = 2948u;
			if (!oneShot)
			{
				if (shelvingTime > 0.0 && shelvingTime < num2)
				{
					num2 = shelvingTime;
				}
				causeId = 2949u;
			}
			ShelvingState.UnshelveTime.Value = num2;
			m_unshelveTime = DateTime.UtcNow.AddMilliseconds((int)num2);
			m_updateUnshelveTimer = new Timer(OnUnshelveTimeUpdate, context, m_unshelveTimeUpdateRate, m_unshelveTimeUpdateRate);
			m_unshelveTimer = new Timer(OnTimerExpired, context, (int)num2, -1);
			ShelvingState.CauseProcessingCompleted(context, causeId);
		}
		UpdateEffectiveState(context);
	}

	protected override bool GetRetainState()
	{
		bool result = false;
		if (base.EnabledState.Id.Value)
		{
			result = base.GetRetainState();
			if (!IsBranch() && ActiveState.Id.Value)
			{
				result = true;
			}
		}
		return result;
	}

	public override MethodState FindMethod(ISystemContext context, NodeId methodId)
	{
		MethodState methodState = base.FindMethod(context, methodId);
		if (methodState == null && ShelvingState != null)
		{
			methodState = ShelvingState.FindMethod(context, methodId);
		}
		return methodState;
	}

	protected override void UpdateEffectiveState(ISystemContext context)
	{
		if (!base.EnabledState.Id.Value)
		{
			base.UpdateEffectiveState(context);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string locale = null;
		if (ActiveState.Value != null)
		{
			locale = ActiveState.Value.Locale;
			if (ActiveState.Id.Value)
			{
				if (ActiveState.EffectiveDisplayName != null && !LocalizedText.IsNullOrEmpty(ActiveState.EffectiveDisplayName.Value))
				{
					stringBuilder.Append(ActiveState.EffectiveDisplayName.Value);
				}
				else
				{
					stringBuilder.Append(ActiveState.Value);
				}
			}
			else
			{
				stringBuilder.Append(ActiveState.Value);
			}
		}
		LocalizedText localizedText = null;
		if (SuppressedState != null && SuppressedState.Id.Value)
		{
			localizedText = SuppressedState.Value;
		}
		if (ShelvingState != null && ShelvingState.CurrentState.Id.Value != ObjectIds.ShelvedStateMachineType_Unshelved)
		{
			localizedText = ShelvingState.CurrentState.Value;
		}
		if (localizedText != null)
		{
			stringBuilder.Append(" | ");
			stringBuilder.Append(localizedText);
		}
		LocalizedText localizedText2 = null;
		if (base.ConfirmedState != null && !base.ConfirmedState.Id.Value)
		{
			localizedText2 = base.ConfirmedState.Value;
		}
		if (base.AckedState != null && !base.AckedState.Id.Value)
		{
			localizedText2 = base.AckedState.Value;
		}
		if (localizedText2 != null)
		{
			stringBuilder.Append(" | ");
			stringBuilder.Append(localizedText2);
		}
		LocalizedText displayName = new LocalizedText(locale, stringBuilder.ToString());
		SetEffectiveSubState(context, displayName, DateTime.MinValue);
	}

	protected ServiceResult OnReadUnshelveTime(ISystemContext context, NodeState node, ref object value)
	{
		double num = 0.0;
		if (m_unshelveTime != DateTime.MinValue)
		{
			num = (m_unshelveTime - DateTime.UtcNow).TotalMilliseconds;
			if (num < 0.0)
			{
				m_unshelveTime = DateTime.MinValue;
			}
		}
		value = num;
		return ServiceResult.Good;
	}

	protected ServiceResult IsOneShotShelveExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = ShelvingState.IsCausePermitted(context, 2948u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnOneShotShelve(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		ServiceResult serviceResult = null;
		try
		{
			if (!base.EnabledState.Id.Value)
			{
				return serviceResult = 2157510656u;
			}
			if (!ShelvingState.IsCausePermitted(context, 2948u, checkUserAccessRights: false))
			{
				return serviceResult = 2161180672u;
			}
			if (OnShelve == null)
			{
				return serviceResult = 2151481344u;
			}
			serviceResult = OnShelve(context, this, shelving: true, oneShot: true, 0.0);
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
		}
		finally
		{
			if (base.AreEventsMonitored)
			{
				AuditConditionShelvingEventState auditConditionShelvingEventState = new AuditConditionShelvingEventState(null);
				TranslationInfo translationInfo = new TranslationInfo("AuditConditionOneShotShelve", "en-US", "The OneShotShelve method was called.");
				auditConditionShelvingEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
				auditConditionShelvingEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "SourceName", "Method/OneShotShelve", copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "ShelvingTime", null, copy: false);
				ReportEvent(context, auditConditionShelvingEventState);
			}
		}
		return serviceResult;
	}

	protected ServiceResult IsTimedShelveExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = ShelvingState.IsCausePermitted(context, 2949u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnTimedShelve(ISystemContext context, MethodState method, NodeId objectId, double shelvingTime)
	{
		ServiceResult serviceResult = null;
		try
		{
			if (!base.EnabledState.Id.Value)
			{
				return serviceResult = 2157510656u;
			}
			if (shelvingTime <= 0.0 || (MaxTimeShelved != null && shelvingTime > MaxTimeShelved.Value))
			{
				return serviceResult = 2161311744u;
			}
			if (!ShelvingState.IsCausePermitted(context, 2949u, checkUserAccessRights: false))
			{
				return serviceResult = 2161180672u;
			}
			if (OnShelve == null)
			{
				return serviceResult = 2151481344u;
			}
			serviceResult = OnShelve(context, this, shelving: true, oneShot: false, shelvingTime);
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
		}
		finally
		{
			if (base.AreEventsMonitored)
			{
				AuditConditionShelvingEventState auditConditionShelvingEventState = new AuditConditionShelvingEventState(null);
				TranslationInfo translationInfo = new TranslationInfo("AuditConditionTimedShelve", "en-US", "The TimedShelve method was called.");
				auditConditionShelvingEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
				auditConditionShelvingEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "SourceName", "Method/TimedShelve", copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "InputArguments", new object[1] { shelvingTime }, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "ShelvingTime", shelvingTime, copy: false);
				ReportEvent(context, auditConditionShelvingEventState);
			}
		}
		return serviceResult;
	}

	protected ServiceResult IsUnshelveExecutable(ISystemContext context, NodeState node, ref bool value)
	{
		value = ShelvingState.IsCausePermitted(context, 2947u, checkUserAccessRights: false);
		return ServiceResult.Good;
	}

	protected virtual ServiceResult OnUnshelve(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
	{
		ServiceResult serviceResult = null;
		try
		{
			if (!base.EnabledState.Id.Value)
			{
				return serviceResult = 2157510656u;
			}
			if (!ShelvingState.IsCausePermitted(context, 2947u, checkUserAccessRights: false))
			{
				return serviceResult = 2161246208u;
			}
			if (OnShelve == null)
			{
				return serviceResult = 2151481344u;
			}
			serviceResult = OnShelve(context, this, shelving: false, oneShot: false, 0.0);
			if (ServiceResult.IsGood(serviceResult))
			{
				ReportStateChange(context, ignoreDisabledState: false);
			}
		}
		finally
		{
			if (base.AreEventsMonitored)
			{
				AuditConditionShelvingEventState auditConditionShelvingEventState = new AuditConditionShelvingEventState(null);
				TranslationInfo translationInfo = new TranslationInfo("AuditConditionUnshelve", "en-US", "The Unshelve method was called.");
				auditConditionShelvingEventState.Initialize(context, this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(serviceResult), DateTime.UtcNow);
				auditConditionShelvingEventState.SetChildValue(context, "SourceNode", base.NodeId, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "SourceName", "Method/UnShelve", copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "MethodId", method.NodeId, copy: false);
				auditConditionShelvingEventState.SetChildValue(context, "ShelvingTime", null, copy: false);
				ReportEvent(context, auditConditionShelvingEventState);
			}
		}
		return serviceResult;
	}

	private void OnTimerExpired(object state)
	{
		try
		{
			if (OnTimedUnshelve != null)
			{
				OnTimedUnshelve((ISystemContext)state, this);
			}
			OnUnshelveTimeUpdate(state);
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Unexpected error unshelving alarm.");
		}
	}

	private void OnUnshelveTimeUpdate(object state)
	{
		try
		{
			ISystemContext context = (ISystemContext)state;
			object value = new object();
			OnReadUnshelveTime(context, null, ref value);
			double num = (double)value;
			if (num != ShelvingState.UnshelveTime.Value)
			{
				ShelvingState.UnshelveTime.Value = num;
				ClearChangeMasks(context, includeChildren: true);
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Unexpected error updating UnshelveTime.");
		}
	}
}
