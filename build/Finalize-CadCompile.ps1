$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$utf8=New-Object Text.UTF8Encoding($false)
function ReadT([string]$r){[IO.File]::ReadAllText((Join-Path $root $r))}
function WriteT([string]$r,[string]$t){[IO.File]::WriteAllText((Join-Path $root $r),$t,$utf8)}
function ReplaceReq([string]$t,[string]$o,[string]$n,[string]$name){
  $c=([regex]::Matches($t,[regex]::Escape($o))).Count
  if($c -ne 1){throw "$name expected 1, found $c"}
  Write-Host "$name" -ForegroundColor Green
  $t.Replace($o,$n)
}
function SwapCaseOrder([string]$t,[string]$methodStart,[string]$methodEnd,[string]$baseLabel,[string]$derivedLabel,[string]$name){
  $s=$t.IndexOf($methodStart,[StringComparison]::Ordinal); if($s -lt 0){throw "$name method start missing"}
  $e=$t.IndexOf($methodEnd,$s+$methodStart.Length,[StringComparison]::Ordinal); if($e -lt 0){throw "$name method end missing"}
  $sec=$t.Substring($s,$e-$s)
  $b=$sec.IndexOf($baseLabel,[StringComparison]::Ordinal)
  $d=$sec.IndexOf($derivedLabel,[StringComparison]::Ordinal)
  if($b -lt 0 -or $d -lt 0){throw "$name labels missing base=$b derived=$d"}
  if($d -lt $b){Write-Host "$name already ordered" -ForegroundColor DarkGreen; return $t}
  $next=$sec.IndexOf("        case ",$d+$derivedLabel.Length,[StringComparison]::Ordinal)
  if($next -lt 0){$next=$sec.IndexOf("        default:",$d+$derivedLabel.Length,[StringComparison]::Ordinal)}
  if($next -lt 0){throw "$name next case missing"}
  $baseBlock=$sec.Substring($b,$d-$b)
  $derivedBlock=$sec.Substring($d,$next-$d)
  $newSec=$sec.Substring(0,$b)+$derivedBlock+$baseBlock+$sec.Substring($next)
  Write-Host "$name reordered" -ForegroundColor Green
  $t.Substring(0,$s)+$newSec+$t.Substring($e)
}

$rel='buCadCamRes/buCadCamResVer5/Marble/clsMarble.cs'
$t=ReadT $rel
$t=$t.Replace('buMarble.LangMarbleMessage','buClass.Apps.buMarble.LangMarbleMessage')
$t=$t.Replace('buMarble.LangMarbleCaptions','buClass.Apps.buMarble.LangMarbleCaptions')
WriteT $rel $t
Write-Host 'Marble language class fully qualified' -ForegroundColor Green

$rel='buCadCamRes/buCadCamResVer5/Profile/clsProfile.cs'
$t=ReadT $rel
$old=@'
            buEntity buEntity = (buEntity) null;
            buEntity.Copy(mirroredOP.EntityMultiXYPlane[index], ref buEntity);
            clsInit.cVector5.Mirror(BasePoint, MirrorPoint, planeMirror, ref buEntity);
            entitiesList.Entities.Add(buEntity);
'@
$new=@'
            buEntity mirroredFreeDrawEntity = (buEntity) null;
            buEntity.Copy(mirroredOP.EntityMultiXYPlane[index], ref mirroredFreeDrawEntity);
            clsInit.cVector5.Mirror(BasePoint, MirrorPoint, planeMirror, ref mirroredFreeDrawEntity);
            entitiesList.Entities.Add(mirroredFreeDrawEntity);
'@
$c=([regex]::Matches($t,[regex]::Escape($old))).Count
if($c -gt 0){$t=$t.Replace($old,$new); Write-Host "Profile remaining buEntity shadow blocks: $c" -ForegroundColor Green}
WriteT $rel $t

$rel='buCadCamRes/buCadCamResVer5/clsCommand.cs'
$t=ReadT $rel
$t=SwapCaseOrder $t '  public void CreateEntity(Entity refEntity, ref Entity Ent)' '  public void AddTempEntity(Entity Ent)' '        case Ellipse' '      case EllipticalArc' 'CreateEntity EllipticalArc before Ellipse'
# Normalize indentation marker in case the base case was rewritten with a guard by an earlier pass.
# The switch scanner searches the first occurrence of each label substring, so guards are preserved.
$t=SwapCaseOrder $t '  public void GetEntityInfo(Entity Ent, ref string sInfo)' '  public void' '        case RevolvedSurface' '        case ToroidalSurface' 'EntityInfo Toroidal before Revolved'
WriteT $rel $t

'FINAL CAD COMPILE ARTIFACT REPAIRS APPLIED' | Set-Content (Join-Path $root 'CAD_COMPILE_FINAL_REPORT.txt') -Encoding UTF8
