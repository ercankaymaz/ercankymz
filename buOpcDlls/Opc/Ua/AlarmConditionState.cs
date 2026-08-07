// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AlarmConditionState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

#nullable disable
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

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2915U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGgAAAEFsYXJtQ29uZGl0aW9uVHlwZUluc3RhbmNlAQBjCwEAYwtjCwAA/////y4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKQVAC4ARKQVAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKUVAC4ARKUVAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCmFQAuAESmFQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApxUALgBEpxUAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKgVAC4ARKgVAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCpFQAuAESpFQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCrFQAuAESrFQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKwVAC4ARKwVAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQBuKwAuAERuKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQBvKwAuAERvKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAnCMALgBEnCMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQCdIwAuAESdIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQCtFQAuAEStFQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQCeIwAvAQAjI54jAAAAFf////8BAQUAAAABACwjAAEAsiMBACwjAAEAuyMBACwjAAEAyCMBACwjAAEA0SMBACwjAAEA2iMBAAAAFWCJCgIAAAAAAAIAAABJZAEAnyMALgBEnyMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAKcjAC8BACojpyMAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAqCMALgBEqCMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQCpIwAvAQAqI6kjAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAKojAC4ARKojAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAKsjAC8BACojqyMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEArCMALgBErCMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCtIwAuAEStIwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAryMALwEARCOvIwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCuIwAvAQBDI64jAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCwIwAvAQBFI7AjAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAsSMALgBEsSMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCyIwAvAQAjI7IjAAAAFf////8BAQEAAAABACwjAQEAniMBAAAAFWCJCgIAAAAAAAIAAABJZAEAsyMALgBEsyMAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQDEIwAvAQCXI8QjAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAxSMALgBExSMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAyCMALwEAIyPIIwAAABX/////AQEBAAAAAQAsIwEBAJ4jBgAAABVgiQoCAAAAAAACAAAASWQBAMkjAC4ARMkjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAzCMALgBEzCMAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDNIwAuAETNIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAziMALgBEziMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQDPIwAuAETPIwAAFQMCAAAAZW4GAAAAQWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEA0CMALgBE0CMAABUDAgAAAGVuCAAAAEluYWN0aXZlABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASW5wdXROb2RlAQBwKwAuAERwKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU3VwcHJlc3NlZFN0YXRlAQDRIwAvAQAjI9EjAAAAFf////8BAQEAAAABACwjAQEAniMEAAAAFWCJCgIAAAAAAAIAAABJZAEA0iMALgBE0iMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDWIwAuAETWIwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBANgjAC4ARNgjAAAVAwIAAABlbgoAAABTdXBwcmVzc2VkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEA2SMALgBE2SMAABUDAgAAAGVuDAAAAFVuc3VwcHJlc3NlZAAV/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE91dE9mU2VydmljZVN0YXRlAQDzPwAvAQAjI/M/AAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEA9D8ALgBE9D8AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD4PwAuAET4PwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAPo/AC4ARPo/AAAVAwIAAABlbg4AAABPdXQgb2YgU2VydmljZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAPs/AC4ARPs/AAAVAwIAAABlbgoAAABJbiBTZXJ2aWNlABX/////AQH/////AAAAAARggAoBAAAAAAANAAAAU2hlbHZpbmdTdGF0ZQEA2iMALwEAcQvaIwAAAQAAAAEALCMBAQCeIwYAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEA2yMALwEAyArbIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBANwjAC4ARNwjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEA4CMALwEAzwrgIwAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAOEjAC4AROEjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEA5CMALgBE5CMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVW5zaGVsdmVUaW1lAQDlIwAuAETlIwAAAQAiAf////8BAf////8AAAAABGGCCgQAAAAAAAsAAABUaW1lZFNoZWx2ZQEA/SMALwEAhQv9IwAAAQEBAAAAAQD5CwABAFUrAQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAP4jAC4ARP4jAACWAQAAAAEAKgEBegAAAAwAAABTaGVsdmluZ1RpbWUBACIB/////wAAAAADAAAAAFUAAABJZiBub3QgMCwgdGhpcyBwYXJhbWV0ZXIgc3BlY2lmaWVzIGEgZml4ZWQgdGltZSBmb3Igd2hpY2ggdGhlIEFsYXJtIGlzIHRvIGJlIHNoZWx2ZWQuAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACAAAAFVuc2hlbHZlAQD7IwAvAQCDC/sjAAABAQEAAAABAPkLAAEAVSsAAAAABGGCCgQAAAAAAA0AAABPbmVTaG90U2hlbHZlAQD8IwAvAQCEC/wjAAABAQEAAAABAPkLAAEAVSsAAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQD/IwAuAET/IwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4VGltZVNoZWx2ZWQBAAAkAC4ARAAkAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAEF1ZGlibGVFbmFibGVkAQAFQAAuAEQFQAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQXVkaWJsZVNvdW5kAQAGQAAvAQBCRgZAAAABALM//////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFNpbGVuY2VTdGF0ZQEA/D8ALwEAIyP8PwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAP0/AC4ARP0/AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAAUAALgBEAUAAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQADQAAuAEQDQAAAFQMCAAAAZW4IAAAAU2lsZW5jZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAEQAAuAEQEQAAAFQMCAAAAZW4MAAAATm90IFNpbGVuY2VkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAT25EZWxheQEAC0AALgBEC0AAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2ZmRGVsYXkBAAxAAC4ARAxAAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEZpcnN0SW5Hcm91cEZsYWcBAA1AAC8APw1AAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAwAAABGaXJzdEluR3JvdXABAA5AAC8BABVADkAAAP////8AAAAAFWCJCgIAAAAAAAwAAABMYXRjaGVkU3RhdGUBAA5HAC8BACMjDkcAAAAV/////wEB/////wQAAAAVYIkKAgAAAAAAAgAAAElkAQAPRwAuAEQPRwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBABNHAC4ARBNHAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAFUcALgBEFUcAABUDAgAAAGVuBwAAAExhdGNoZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAWRwAuAEQWRwAAFQMCAAAAZW4JAAAAVW5sYXRjaGVkABX/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVBbGFybVRpbWUBABBAAC4ARBBAAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFJlQWxhcm1SZXBlYXRDb3VudAEAEUAALwA/EUAAAAAE/////wEB/////wAAAAAEYYIKBAAAAAAABwAAAFNpbGVuY2UBABJAAC8BABJAEkAAAAEBAQAAAAEA+QsAAQBaQwAAAAAEYYIKBAAAAAAACAAAAFN1cHByZXNzAQATQAAvAQATQBNAAAABAQEAAAABAPkLAAEASUMAAAAABGGCCgQAAAAAAAoAAABVbnN1cHByZXNzAQDMRQAvAQDMRcxFAAABAQEAAAABAPkLAAEASUMAAAAABGGCCgQAAAAAABEAAABSZW1vdmVGcm9tU2VydmljZQEAzUUALwEAzUXNRQAAAQEBAAAAAQD5CwABAGtDAAAAAARhggoEAAAAAAAOAAAAUGxhY2VJblNlcnZpY2UBAM5FAC8BAM5FzkUAAAEBAQAAAAEA+QsAAQBrQwAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQAXRwAvAQAXRxdHAAABAQEAAAABAPkLAAEApToAAAAA");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
    if (this.SuppressedState != null)
      this.SuppressedState.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFN1cHByZXNzZWRTdGF0ZQEA0SMALwEAIyPRIwAAABX/////AQEBAAAAAQAsIwEBAJ4jBAAAABVgiQoCAAAAAAACAAAASWQBANIjAC4ARNIjAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEA1iMALgBE1iMAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQDYIwAuAETYIwAAFQMCAAAAZW4KAAAAU3VwcHJlc3NlZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBANkjAC4ARNkjAAAVAwIAAABlbgwAAABVbnN1cHByZXNzZWQAFf////8BAf////8AAAAA");
    if (this.OutOfServiceState != null)
      this.OutOfServiceState.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAE91dE9mU2VydmljZVN0YXRlAQDzPwAvAQAjI/M/AAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEA9D8ALgBE9D8AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD4PwAuAET4PwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAPo/AC4ARPo/AAAVAwIAAABlbg4AAABPdXQgb2YgU2VydmljZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAPs/AC4ARPs/AAAVAwIAAABlbgoAAABJbiBTZXJ2aWNlABX/////AQH/////AAAAAA==");
    if (this.ShelvingState != null)
      this.ShelvingState.Initialize(context, "//////////8EYIAKAQAAAAAADQAAAFNoZWx2aW5nU3RhdGUBANojAC8BAHEL2iMAAAEAAAABACwjAQEAniMGAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANsjAC8BAMgK2yMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDcIwAuAETcIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BAOAjAC8BAM8K4CMAAAAV/////wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQDhIwAuAEThIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAOQjAC4AROQjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVuc2hlbHZlVGltZQEA5SMALgBE5SMAAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAALAAAAVGltZWRTaGVsdmUBAP0jAC8BAIUL/SMAAAEBAQAAAAEA+QsAAQBVKwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD+IwAuAET+IwAAlgEAAAABACoBAXoAAAAMAAAAU2hlbHZpbmdUaW1lAQAiAf////8AAAAAAwAAAABVAAAASWYgbm90IDAsIHRoaXMgcGFyYW1ldGVyIHNwZWNpZmllcyBhIGZpeGVkIHRpbWUgZm9yIHdoaWNoIHRoZSBBbGFybSBpcyB0byBiZSBzaGVsdmVkLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAgAAABVbnNoZWx2ZQEA+yMALwEAgwv7IwAAAQEBAAAAAQD5CwABAFUrAAAAAARhggoEAAAAAAANAAAAT25lU2hvdFNoZWx2ZQEA/CMALwEAhAv8IwAAAQEBAAAAAQD5CwABAFUrAAAAAA==");
    if (this.MaxTimeShelved != null)
      this.MaxTimeShelved.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAE1heFRpbWVTaGVsdmVkAQAAJAAuAEQAJAAAAQAiAf////8BAf////8AAAAA");
    if (this.AudibleEnabled != null)
      this.AudibleEnabled.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAEF1ZGlibGVFbmFibGVkAQAFQAAuAEQFQAAAAAH/////AQH/////AAAAAA==");
    if (this.AudibleSound != null)
      this.AudibleSound.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAEF1ZGlibGVTb3VuZAEABkAALwEAQkYGQAAAAQCzP/////8BAf////8AAAAA");
    if (this.SilenceState != null)
      this.SilenceState.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFNpbGVuY2VTdGF0ZQEA/D8ALwEAIyP8PwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAP0/AC4ARP0/AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAAUAALgBEAUAAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQADQAAuAEQDQAAAFQMCAAAAZW4IAAAAU2lsZW5jZWQAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAEQAAuAEQEQAAAFQMCAAAAZW4MAAAATm90IFNpbGVuY2VkABX/////AQH/////AAAAAA==");
    if (this.OnDelay != null)
      this.OnDelay.Initialize(context, "//////////8VYIkKAgAAAAAABwAAAE9uRGVsYXkBAAtAAC4ARAtAAAABACIB/////wEB/////wAAAAA=");
    if (this.OffDelay != null)
      this.OffDelay.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAE9mZkRlbGF5AQAMQAAuAEQMQAAAAQAiAf////8BAf////8AAAAA");
    if (this.FirstInGroupFlag != null)
      this.FirstInGroupFlag.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEZpcnN0SW5Hcm91cEZsYWcBAA1AAC8APw1AAAAAAf////8BAf////8AAAAA");
    if (this.FirstInGroup != null)
      this.FirstInGroup.Initialize(context, "//////////8EYIAKAQAAAAAADAAAAEZpcnN0SW5Hcm91cAEADkAALwEAFUAOQAAA/////wAAAAA=");
    if (this.LatchedState != null)
      this.LatchedState.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAExhdGNoZWRTdGF0ZQEADkcALwEAIyMORwAAABX/////AQH/////BAAAABVgiQoCAAAAAAACAAAASWQBAA9HAC4ARA9HAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAE0cALgBEE0cAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQAVRwAuAEQVRwAAFQMCAAAAZW4HAAAATGF0Y2hlZAAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBABZHAC4ARBZHAAAVAwIAAABlbgkAAABVbmxhdGNoZWQAFf////8BAf////8AAAAA");
    if (this.ReAlarmTime != null)
      this.ReAlarmTime.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAFJlQWxhcm1UaW1lAQAQQAAuAEQQQAAAAQAiAf////8BAf////8AAAAA");
    if (this.ReAlarmRepeatCount != null)
      this.ReAlarmRepeatCount.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAFJlQWxhcm1SZXBlYXRDb3VudAEAEUAALwA/EUAAAAAE/////wEB/////wAAAAA=");
    if (this.Silence != null)
      this.Silence.Initialize(context, "//////////8EYYIKBAAAAAAABwAAAFNpbGVuY2UBABJAAC8BABJAEkAAAAEBAQAAAAEA+QsAAQBaQwAAAAA=");
    if (this.Suppress != null)
      this.Suppress.Initialize(context, "//////////8EYYIKBAAAAAAACAAAAFN1cHByZXNzAQATQAAvAQATQBNAAAABAQEAAAABAPkLAAEASUMAAAAA");
    if (this.Unsuppress != null)
      this.Unsuppress.Initialize(context, "//////////8EYYIKBAAAAAAACgAAAFVuc3VwcHJlc3MBAMxFAC8BAMxFzEUAAAEBAQAAAAEA+QsAAQBJQwAAAAA=");
    if (this.RemoveFromService != null)
      this.RemoveFromService.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUZyb21TZXJ2aWNlAQDNRQAvAQDNRc1FAAABAQEAAAABAPkLAAEAa0MAAAAA");
    if (this.PlaceInService != null)
      this.PlaceInService.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFBsYWNlSW5TZXJ2aWNlAQDORQAvAQDORc5FAAABAQEAAAABAPkLAAEAa0MAAAAA");
    if (this.Reset == null)
      return;
    this.Reset.Initialize(context, "//////////8EYYIKBAAAAAAABQAAAFJlc2V0AQAXRwAvAQAXRxdHAAABAQEAAAABAPkLAAEApToAAAAA");
  }

  public TwoStateVariableState ActiveState
  {
    get => this.m_activeState;
    set
    {
      if (this.m_activeState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_activeState = value;
    }
  }

  public PropertyState<NodeId> InputNode
  {
    get => this.m_inputNode;
    set
    {
      if (this.m_inputNode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_inputNode = value;
    }
  }

  public TwoStateVariableState SuppressedState
  {
    get => this.m_suppressedState;
    set
    {
      if (this.m_suppressedState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_suppressedState = value;
    }
  }

  public TwoStateVariableState OutOfServiceState
  {
    get => this.m_outOfServiceState;
    set
    {
      if (this.m_outOfServiceState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_outOfServiceState = value;
    }
  }

  public ShelvedStateMachineState ShelvingState
  {
    get => this.m_shelvingState;
    set
    {
      if (this.m_shelvingState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_shelvingState = value;
    }
  }

  public PropertyState<bool> SuppressedOrShelved
  {
    get => this.m_suppressedOrShelved;
    set
    {
      if (this.m_suppressedOrShelved != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_suppressedOrShelved = value;
    }
  }

  public PropertyState<double> MaxTimeShelved
  {
    get => this.m_maxTimeShelved;
    set
    {
      if (this.m_maxTimeShelved != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxTimeShelved = value;
    }
  }

  public PropertyState<bool> AudibleEnabled
  {
    get => this.m_audibleEnabled;
    set
    {
      if (this.m_audibleEnabled != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_audibleEnabled = value;
    }
  }

  public AudioVariableState AudibleSound
  {
    get => this.m_audibleSound;
    set
    {
      if (this.m_audibleSound != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_audibleSound = value;
    }
  }

  public TwoStateVariableState SilenceState
  {
    get => this.m_silenceState;
    set
    {
      if (this.m_silenceState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_silenceState = value;
    }
  }

  public PropertyState<double> OnDelay
  {
    get => this.m_onDelay;
    set
    {
      if (this.m_onDelay != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_onDelay = value;
    }
  }

  public PropertyState<double> OffDelay
  {
    get => this.m_offDelay;
    set
    {
      if (this.m_offDelay != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_offDelay = value;
    }
  }

  public BaseDataVariableState<bool> FirstInGroupFlag
  {
    get => this.m_firstInGroupFlag;
    set
    {
      if (this.m_firstInGroupFlag != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_firstInGroupFlag = value;
    }
  }

  public AlarmGroupState FirstInGroup
  {
    get => this.m_firstInGroup;
    set
    {
      if (this.m_firstInGroup != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_firstInGroup = value;
    }
  }

  public TwoStateVariableState LatchedState
  {
    get => this.m_latchedState;
    set
    {
      if (this.m_latchedState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_latchedState = value;
    }
  }

  public PropertyState<double> ReAlarmTime
  {
    get => this.m_reAlarmTime;
    set
    {
      if (this.m_reAlarmTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_reAlarmTime = value;
    }
  }

  public BaseDataVariableState<short> ReAlarmRepeatCount
  {
    get => this.m_reAlarmRepeatCount;
    set
    {
      if (this.m_reAlarmRepeatCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_reAlarmRepeatCount = value;
    }
  }

  public MethodState Silence
  {
    get => this.m_silenceMethod;
    set
    {
      if (this.m_silenceMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_silenceMethod = value;
    }
  }

  public MethodState Suppress
  {
    get => this.m_suppressMethod;
    set
    {
      if (this.m_suppressMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_suppressMethod = value;
    }
  }

  public MethodState Unsuppress
  {
    get => this.m_unsuppressMethod;
    set
    {
      if (this.m_unsuppressMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_unsuppressMethod = value;
    }
  }

  public MethodState RemoveFromService
  {
    get => this.m_removeFromServiceMethod;
    set
    {
      if (this.m_removeFromServiceMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeFromServiceMethod = value;
    }
  }

  public MethodState PlaceInService
  {
    get => this.m_placeInServiceMethod;
    set
    {
      if (this.m_placeInServiceMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_placeInServiceMethod = value;
    }
  }

  public MethodState Reset
  {
    get => this.m_resetMethod;
    set
    {
      if (this.m_resetMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_resetMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_activeState != null)
      children.Add((BaseInstanceState) this.m_activeState);
    if (this.m_inputNode != null)
      children.Add((BaseInstanceState) this.m_inputNode);
    if (this.m_suppressedState != null)
      children.Add((BaseInstanceState) this.m_suppressedState);
    if (this.m_outOfServiceState != null)
      children.Add((BaseInstanceState) this.m_outOfServiceState);
    if (this.m_shelvingState != null)
      children.Add((BaseInstanceState) this.m_shelvingState);
    if (this.m_suppressedOrShelved != null)
      children.Add((BaseInstanceState) this.m_suppressedOrShelved);
    if (this.m_maxTimeShelved != null)
      children.Add((BaseInstanceState) this.m_maxTimeShelved);
    if (this.m_audibleEnabled != null)
      children.Add((BaseInstanceState) this.m_audibleEnabled);
    if (this.m_audibleSound != null)
      children.Add((BaseInstanceState) this.m_audibleSound);
    if (this.m_silenceState != null)
      children.Add((BaseInstanceState) this.m_silenceState);
    if (this.m_onDelay != null)
      children.Add((BaseInstanceState) this.m_onDelay);
    if (this.m_offDelay != null)
      children.Add((BaseInstanceState) this.m_offDelay);
    if (this.m_firstInGroupFlag != null)
      children.Add((BaseInstanceState) this.m_firstInGroupFlag);
    if (this.m_firstInGroup != null)
      children.Add((BaseInstanceState) this.m_firstInGroup);
    if (this.m_latchedState != null)
      children.Add((BaseInstanceState) this.m_latchedState);
    if (this.m_reAlarmTime != null)
      children.Add((BaseInstanceState) this.m_reAlarmTime);
    if (this.m_reAlarmRepeatCount != null)
      children.Add((BaseInstanceState) this.m_reAlarmRepeatCount);
    if (this.m_silenceMethod != null)
      children.Add((BaseInstanceState) this.m_silenceMethod);
    if (this.m_suppressMethod != null)
      children.Add((BaseInstanceState) this.m_suppressMethod);
    if (this.m_unsuppressMethod != null)
      children.Add((BaseInstanceState) this.m_unsuppressMethod);
    if (this.m_removeFromServiceMethod != null)
      children.Add((BaseInstanceState) this.m_removeFromServiceMethod);
    if (this.m_placeInServiceMethod != null)
      children.Add((BaseInstanceState) this.m_placeInServiceMethod);
    if (this.m_resetMethod != null)
      children.Add((BaseInstanceState) this.m_resetMethod);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 5:
          if (name == "Reset")
          {
            if (createOrReplace && this.Reset == null)
              this.Reset = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Reset;
            break;
          }
          break;
        case 7:
          switch (name[0])
          {
            case 'O':
              if (name == "OnDelay")
              {
                if (createOrReplace && this.OnDelay == null)
                  this.OnDelay = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.OnDelay;
                break;
              }
              break;
            case 'S':
              if (name == "Silence")
              {
                if (createOrReplace && this.Silence == null)
                  this.Silence = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Silence;
                break;
              }
              break;
          }
          break;
        case 8:
          switch (name[0])
          {
            case 'O':
              if (name == "OffDelay")
              {
                if (createOrReplace && this.OffDelay == null)
                  this.OffDelay = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.OffDelay;
                break;
              }
              break;
            case 'S':
              if (name == "Suppress")
              {
                if (createOrReplace && this.Suppress == null)
                  this.Suppress = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Suppress;
                break;
              }
              break;
          }
          break;
        case 9:
          if (name == "InputNode")
          {
            if (createOrReplace && this.InputNode == null)
              this.InputNode = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.InputNode;
            break;
          }
          break;
        case 10:
          if (name == "Unsuppress")
          {
            if (createOrReplace && this.Unsuppress == null)
              this.Unsuppress = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Unsuppress;
            break;
          }
          break;
        case 11:
          switch (name[0])
          {
            case 'A':
              if (name == "ActiveState")
              {
                if (createOrReplace && this.ActiveState == null)
                  this.ActiveState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ActiveState;
                break;
              }
              break;
            case 'R':
              if (name == "ReAlarmTime")
              {
                if (createOrReplace && this.ReAlarmTime == null)
                  this.ReAlarmTime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ReAlarmTime;
                break;
              }
              break;
          }
          break;
        case 12:
          switch (name[0])
          {
            case 'A':
              if (name == "AudibleSound")
              {
                if (createOrReplace && this.AudibleSound == null)
                  this.AudibleSound = replacement != null ? (AudioVariableState) replacement : new AudioVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AudibleSound;
                break;
              }
              break;
            case 'F':
              if (name == "FirstInGroup")
              {
                if (createOrReplace && this.FirstInGroup == null)
                  this.FirstInGroup = replacement != null ? (AlarmGroupState) replacement : new AlarmGroupState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.FirstInGroup;
                break;
              }
              break;
            case 'L':
              if (name == "LatchedState")
              {
                if (createOrReplace && this.LatchedState == null)
                  this.LatchedState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LatchedState;
                break;
              }
              break;
            case 'S':
              if (name == "SilenceState")
              {
                if (createOrReplace && this.SilenceState == null)
                  this.SilenceState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SilenceState;
                break;
              }
              break;
          }
          break;
        case 13:
          if (name == "ShelvingState")
          {
            if (createOrReplace && this.ShelvingState == null)
              this.ShelvingState = replacement != null ? (ShelvedStateMachineState) replacement : new ShelvedStateMachineState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ShelvingState;
            break;
          }
          break;
        case 14:
          switch (name[0])
          {
            case 'A':
              if (name == "AudibleEnabled")
              {
                if (createOrReplace && this.AudibleEnabled == null)
                  this.AudibleEnabled = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AudibleEnabled;
                break;
              }
              break;
            case 'M':
              if (name == "MaxTimeShelved")
              {
                if (createOrReplace && this.MaxTimeShelved == null)
                  this.MaxTimeShelved = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxTimeShelved;
                break;
              }
              break;
            case 'P':
              if (name == "PlaceInService")
              {
                if (createOrReplace && this.PlaceInService == null)
                  this.PlaceInService = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.PlaceInService;
                break;
              }
              break;
          }
          break;
        case 15:
          if (name == "SuppressedState")
          {
            if (createOrReplace && this.SuppressedState == null)
              this.SuppressedState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SuppressedState;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "FirstInGroupFlag")
          {
            if (createOrReplace && this.FirstInGroupFlag == null)
              this.FirstInGroupFlag = replacement != null ? (BaseDataVariableState<bool>) replacement : new BaseDataVariableState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.FirstInGroupFlag;
            break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'O':
              if (name == "OutOfServiceState")
              {
                if (createOrReplace && this.OutOfServiceState == null)
                  this.OutOfServiceState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.OutOfServiceState;
                break;
              }
              break;
            case 'R':
              if (name == "RemoveFromService")
              {
                if (createOrReplace && this.RemoveFromService == null)
                  this.RemoveFromService = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RemoveFromService;
                break;
              }
              break;
          }
          break;
        case 18:
          if (name == "ReAlarmRepeatCount")
          {
            if (createOrReplace && this.ReAlarmRepeatCount == null)
              this.ReAlarmRepeatCount = replacement != null ? (BaseDataVariableState<short>) replacement : new BaseDataVariableState<short>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ReAlarmRepeatCount;
            break;
          }
          break;
        case 19:
          if (name == "SuppressedOrShelved")
          {
            if (createOrReplace && this.SuppressedOrShelved == null)
              this.SuppressedOrShelved = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SuppressedOrShelved;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    if (this.ShelvingState == null)
      return;
    if (this.ShelvingState.UnshelveTime != null)
    {
      this.ShelvingState.UnshelveTime.OnSimpleReadValue = new NodeValueSimpleEventHandler(this.OnReadUnshelveTime);
      this.ShelvingState.UnshelveTime.MinimumSamplingInterval = 1000.0;
    }
    this.ShelvingState.OneShotShelve.OnCallMethod = new GenericMethodCalledEventHandler(this.OnOneShotShelve);
    this.ShelvingState.OneShotShelve.OnReadExecutable = new NodeAttributeEventHandler<bool>(this.IsOneShotShelveExecutable);
    this.ShelvingState.OneShotShelve.OnReadUserExecutable = new NodeAttributeEventHandler<bool>(this.IsOneShotShelveExecutable);
    this.ShelvingState.TimedShelve.OnCall = new TimedShelveMethodStateMethodCallHandler(this.OnTimedShelve);
    this.ShelvingState.TimedShelve.OnReadExecutable = new NodeAttributeEventHandler<bool>(this.IsTimedShelveExecutable);
    this.ShelvingState.TimedShelve.OnReadUserExecutable = new NodeAttributeEventHandler<bool>(this.IsTimedShelveExecutable);
    this.ShelvingState.Unshelve.OnCallMethod = new GenericMethodCalledEventHandler(this.OnUnshelve);
    this.ShelvingState.Unshelve.OnReadExecutable = new NodeAttributeEventHandler<bool>(this.IsUnshelveExecutable);
    this.ShelvingState.Unshelve.OnReadUserExecutable = new NodeAttributeEventHandler<bool>(this.IsUnshelveExecutable);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      if (this.m_unshelveTimer != null)
      {
        this.m_unshelveTimer.Dispose();
        this.m_unshelveTimer = (Timer) null;
      }
      if (this.m_updateUnshelveTimer != null)
      {
        this.m_updateUnshelveTimer.Dispose();
        this.m_updateUnshelveTimer = (Timer) null;
      }
    }
    base.Dispose(disposing);
  }

  public int UnshelveTimeUpdateRate
  {
    get => this.m_unshelveTimeUpdateRate;
    set => this.m_unshelveTimeUpdateRate = value;
  }

  public virtual void SetActiveEffectiveSubState(
    ISystemContext context,
    LocalizedText displayName,
    DateTime transitionTime)
  {
    if (this.ActiveState.EffectiveDisplayName != null)
      this.ActiveState.EffectiveDisplayName.Value = displayName;
    if (this.ActiveState.EffectiveTransitionTime == null)
      return;
    if (transitionTime != DateTime.MinValue)
      this.ActiveState.EffectiveTransitionTime.Value = transitionTime;
    else
      this.ActiveState.EffectiveTransitionTime.Value = DateTime.UtcNow;
  }

  public DateTime UnshelveTime => this.m_unshelveTime;

  public virtual void SetActiveState(ISystemContext context, bool active)
  {
    TranslationInfo translationInfo;
    if (active)
    {
      translationInfo = new TranslationInfo("ConditionStateActive", "en-US", "Active");
    }
    else
    {
      if (this.ShelvingState != null && this.m_oneShot)
        this.SetShelvingState(context, false, false, 0.0);
      translationInfo = new TranslationInfo("ConditionStateInactive", "en-US", "Inactive");
    }
    this.ActiveState.Value = new LocalizedText(translationInfo);
    this.ActiveState.Id.Value = active;
    if (this.ActiveState.TransitionTime != null)
      this.ActiveState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  public virtual void SetSuppressedState(ISystemContext context, bool suppressed)
  {
    if (this.SuppressedState == null)
      return;
    TranslationInfo translationInfo;
    if (suppressed)
    {
      this.SuppressedOrShelved.Value = true;
      translationInfo = new TranslationInfo("ConditionStateSuppressed", "en-US", "Suppressed");
    }
    else
    {
      if (this.ShelvingState == null || this.ShelvingState.CurrentState.Id.Value == (object) ObjectIds.ShelvedStateMachineType_Unshelved)
        this.SuppressedOrShelved.Value = false;
      translationInfo = new TranslationInfo("ConditionStateUnsuppressed", "en-US", "Unsuppressed");
    }
    this.SuppressedState.Value = new LocalizedText(translationInfo);
    this.SuppressedState.Id.Value = suppressed;
    if (this.SuppressedState.TransitionTime != null)
      this.SuppressedState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  public virtual void SetShelvingState(
    ISystemContext context,
    bool shelved,
    bool oneShot,
    double shelvingTime)
  {
    if (this.ShelvingState == null)
      return;
    if (this.m_unshelveTimer != null)
    {
      this.m_unshelveTimer.Dispose();
      this.m_unshelveTimer = (Timer) null;
    }
    if (this.m_updateUnshelveTimer != null)
    {
      this.m_updateUnshelveTimer.Dispose();
      this.m_updateUnshelveTimer = (Timer) null;
    }
    this.m_unshelveTime = DateTime.MinValue;
    if (!shelved)
    {
      if (this.SuppressedState == null || !this.SuppressedState.Id.Value)
        this.SuppressedOrShelved.Value = false;
      this.ShelvingState.UnshelveTime.Value = 0.0;
      this.ShelvingState.CauseProcessingCompleted(context, 2947U);
    }
    else
    {
      this.SuppressedOrShelved.Value = true;
      this.m_oneShot = oneShot;
      double maxValue = double.MaxValue;
      if (this.MaxTimeShelved != null && this.MaxTimeShelved.Value > 0.0)
        maxValue = this.MaxTimeShelved.Value;
      double dueTime = maxValue;
      uint causeId = 2948;
      if (!oneShot)
      {
        if (shelvingTime > 0.0 && shelvingTime < dueTime)
          dueTime = shelvingTime;
        causeId = 2949U;
      }
      this.ShelvingState.UnshelveTime.Value = dueTime;
      this.m_unshelveTime = DateTime.UtcNow.AddMilliseconds((double) (int) dueTime);
      this.m_updateUnshelveTimer = new Timer(new TimerCallback(this.OnUnshelveTimeUpdate), (object) context, this.m_unshelveTimeUpdateRate, this.m_unshelveTimeUpdateRate);
      this.m_unshelveTimer = new Timer(new TimerCallback(this.OnTimerExpired), (object) context, (int) dueTime, -1);
      this.ShelvingState.CauseProcessingCompleted(context, causeId);
    }
    this.UpdateEffectiveState(context);
  }

  protected override bool GetRetainState()
  {
    bool retainState = false;
    if (this.EnabledState.Id.Value)
    {
      retainState = base.GetRetainState();
      if (!this.IsBranch() && this.ActiveState.Id.Value)
        retainState = true;
    }
    return retainState;
  }

  public override MethodState FindMethod(ISystemContext context, NodeId methodId)
  {
    MethodState method = base.FindMethod(context, methodId);
    if (method == null && this.ShelvingState != null)
      method = this.ShelvingState.FindMethod(context, methodId);
    return method;
  }

  protected override void UpdateEffectiveState(ISystemContext context)
  {
    if (!this.EnabledState.Id.Value)
    {
      base.UpdateEffectiveState(context);
    }
    else
    {
      StringBuilder stringBuilder = new StringBuilder();
      string locale = (string) null;
      if (this.ActiveState.Value != (LocalizedText) null)
      {
        locale = this.ActiveState.Value.Locale;
        if (this.ActiveState.Id.Value)
        {
          if (this.ActiveState.EffectiveDisplayName != null && !LocalizedText.IsNullOrEmpty(this.ActiveState.EffectiveDisplayName.Value))
            stringBuilder.Append((object) this.ActiveState.EffectiveDisplayName.Value);
          else
            stringBuilder.Append((object) this.ActiveState.Value);
        }
        else
          stringBuilder.Append((object) this.ActiveState.Value);
      }
      LocalizedText localizedText1 = (LocalizedText) null;
      if (this.SuppressedState != null && this.SuppressedState.Id.Value)
        localizedText1 = this.SuppressedState.Value;
      if (this.ShelvingState != null && this.ShelvingState.CurrentState.Id.Value != (object) ObjectIds.ShelvedStateMachineType_Unshelved)
        localizedText1 = this.ShelvingState.CurrentState.Value;
      if (localizedText1 != (LocalizedText) null)
      {
        stringBuilder.Append(" | ");
        stringBuilder.Append((object) localizedText1);
      }
      LocalizedText localizedText2 = (LocalizedText) null;
      if (this.ConfirmedState != null && !this.ConfirmedState.Id.Value)
        localizedText2 = this.ConfirmedState.Value;
      if (this.AckedState != null && !this.AckedState.Id.Value)
        localizedText2 = this.AckedState.Value;
      if (localizedText2 != (LocalizedText) null)
      {
        stringBuilder.Append(" | ");
        stringBuilder.Append((object) localizedText2);
      }
      LocalizedText displayName = new LocalizedText(locale, stringBuilder.ToString());
      this.SetEffectiveSubState(context, displayName, DateTime.MinValue);
    }
  }

  protected ServiceResult OnReadUnshelveTime(
    ISystemContext context,
    NodeState node,
    ref object value)
  {
    double num = 0.0;
    if (this.m_unshelveTime != DateTime.MinValue)
    {
      num = (this.m_unshelveTime - DateTime.UtcNow).TotalMilliseconds;
      if (num < 0.0)
        this.m_unshelveTime = DateTime.MinValue;
    }
    value = (object) num;
    return ServiceResult.Good;
  }

  protected ServiceResult IsOneShotShelveExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.ShelvingState.IsCausePermitted(context, 2948U, false);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnOneShotShelve(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    ServiceResult status = (ServiceResult) null;
    try
    {
      if (!this.EnabledState.Id.Value)
        return status = (ServiceResult) 2157510656U /*0x80990000*/;
      if (!this.ShelvingState.IsCausePermitted(context, 2948U, false))
        return status = (ServiceResult) 2161180672U /*0x80D10000*/;
      if (this.OnShelve == null)
        return status = (ServiceResult) 2151481344U /*0x803D0000*/;
      status = this.OnShelve(context, this, true, true, 0.0);
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
    }
    finally
    {
      if (this.AreEventsMonitored)
      {
        AuditConditionShelvingEventState e = new AuditConditionShelvingEventState((NodeState) null);
        TranslationInfo translationInfo = new TranslationInfo("AuditConditionOneShotShelve", "en-US", "The OneShotShelve method was called.");
        e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
        e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/OneShotShelve", false);
        e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "ShelvingTime", (BaseInstanceState) null, false);
        this.ReportEvent(context, (IFilterTarget) e);
      }
    }
    return status;
  }

  protected ServiceResult IsTimedShelveExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.ShelvingState.IsCausePermitted(context, 2949U, false);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnTimedShelve(
    ISystemContext context,
    MethodState method,
    NodeId objectId,
    double shelvingTime)
  {
    ServiceResult status = (ServiceResult) null;
    try
    {
      if (!this.EnabledState.Id.Value)
        return status = (ServiceResult) 2157510656U /*0x80990000*/;
      if (shelvingTime <= 0.0 || this.MaxTimeShelved != null && shelvingTime > this.MaxTimeShelved.Value)
        return status = (ServiceResult) 2161311744U /*0x80D30000*/;
      if (!this.ShelvingState.IsCausePermitted(context, 2949U, false))
        return status = (ServiceResult) 2161180672U /*0x80D10000*/;
      if (this.OnShelve == null)
        return status = (ServiceResult) 2151481344U /*0x803D0000*/;
      status = this.OnShelve(context, this, true, false, shelvingTime);
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
    }
    finally
    {
      if (this.AreEventsMonitored)
      {
        AuditConditionShelvingEventState e = new AuditConditionShelvingEventState((NodeState) null);
        TranslationInfo translationInfo = new TranslationInfo("AuditConditionTimedShelve", "en-US", "The TimedShelve method was called.");
        e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
        e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/TimedShelve", false);
        e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "InputArguments", (object) new object[1]
        {
          (object) shelvingTime
        }, false);
        e.SetChildValue(context, (QualifiedName) "ShelvingTime", (object) shelvingTime, false);
        this.ReportEvent(context, (IFilterTarget) e);
      }
    }
    return status;
  }

  protected ServiceResult IsUnshelveExecutable(
    ISystemContext context,
    NodeState node,
    ref bool value)
  {
    value = this.ShelvingState.IsCausePermitted(context, 2947U, false);
    return ServiceResult.Good;
  }

  protected virtual ServiceResult OnUnshelve(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    ServiceResult status = (ServiceResult) null;
    try
    {
      if (!this.EnabledState.Id.Value)
        return status = (ServiceResult) 2157510656U /*0x80990000*/;
      if (!this.ShelvingState.IsCausePermitted(context, 2947U, false))
        return status = (ServiceResult) 2161246208U /*0x80D20000*/;
      if (this.OnShelve == null)
        return status = (ServiceResult) 2151481344U /*0x803D0000*/;
      status = this.OnShelve(context, this, false, false, 0.0);
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
    }
    finally
    {
      if (this.AreEventsMonitored)
      {
        AuditConditionShelvingEventState e = new AuditConditionShelvingEventState((NodeState) null);
        TranslationInfo translationInfo = new TranslationInfo("AuditConditionUnshelve", "en-US", "The Unshelve method was called.");
        e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
        e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/UnShelve", false);
        e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
        e.SetChildValue(context, (QualifiedName) "ShelvingTime", (BaseInstanceState) null, false);
        this.ReportEvent(context, (IFilterTarget) e);
      }
    }
    return status;
  }

  private void OnTimerExpired(object state)
  {
    try
    {
      if (this.OnTimedUnshelve != null)
      {
        ServiceResult serviceResult = this.OnTimedUnshelve((ISystemContext) state, this);
      }
      this.OnUnshelveTimeUpdate(state);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Unexpected error unshelving alarm.", objArray);
    }
  }

  private void OnUnshelveTimeUpdate(object state)
  {
    try
    {
      ISystemContext context = (ISystemContext) state;
      object obj = new object();
      this.OnReadUnshelveTime(context, (NodeState) null, ref obj);
      double num = (double) obj;
      if (num == this.ShelvingState.UnshelveTime.Value)
        return;
      this.ShelvingState.UnshelveTime.Value = num;
      this.ClearChangeMasks(context, true);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Unexpected error updating UnshelveTime.", objArray);
    }
  }
}
