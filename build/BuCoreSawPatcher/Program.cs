using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

if(args.Length<3) return 2;
string input=Path.GetFullPath(args[0]), output=Path.GetFullPath(args[1]), report=Path.GetFullPath(args[2]);
Directory.CreateDirectory(Path.GetDirectoryName(output)!);Directory.CreateDirectory(Path.GetDirectoryName(report)!);
var resolver=new DefaultAssemblyResolver();resolver.AddSearchDirectory(Path.GetDirectoryName(input)!);
using var asm=AssemblyDefinition.ReadAssembly(input,new ReaderParameters{AssemblyResolver=resolver,InMemory=true});
var mod=asm.MainModule;
var type=mod.Types.First(t=>t.FullName=="buCore.buCamCalc");
var m=type.Methods.Single(x=>x.Name=="CalculateGrindingContourSaw"&&x.Parameters.Count==6);
NormalizeLocals(m.Body);
var ins=m.Body.Instructions;var il=m.Body.GetILProcessor();
var deg=ins.Select(x=>x.Operand).OfType<MethodReference>().First(x=>x.Name=="DegreeToRadian"&&x.Parameters.Count==1);
var cos=ins.Select(x=>x.Operand).OfType<MethodReference>().First(x=>x.DeclaringType.FullName=="System.Math"&&x.Name=="Cos");
var calls=ins.Where(x=>x.Operand is MethodReference mr&&mr.Name=="LineWithOrientationAngle").ToList();
int patched=0;
foreach(var call in calls){
 int ci=ins.IndexOf(call);if(ci<3||ins[ci-1].OpCode.Code is not (Code.Ldloca or Code.Ldloca_S)||ins[ci-2].OpCode.Code!=Code.Sub)continue;
 int subIndex=ci-2;VariableDefinition? angle=null;FieldReference? fieldA=null;
 for(int i=subIndex-1;i>=Math.Max(1,subIndex-30);--i){
   if(ins[i].Operand is FieldReference fr&&fr.DeclaringType.FullName=="buClass.OrientationAngle"&&fr.Name=="A"){
     angle=GetLocal(m.Body,ins[i-1]);if(angle!=null){fieldA=fr;break;}
   }
 }
 if(angle==null||fieldA==null)continue;
 var anchor=ins[subIndex];
 var a=il.Create(OpCodes.Ldloc,angle);var b=il.Create(OpCodes.Ldfld,fieldA);var c=il.Create(OpCodes.Call,deg);var d=il.Create(OpCodes.Call,cos);var e=il.Create(OpCodes.Div);
 il.InsertAfter(anchor,a);il.InsertAfter(a,b);il.InsertAfter(b,c);il.InsertAfter(c,d);il.InsertAfter(d,e);patched++;
}
if(patched!=4)throw new InvalidOperationException($"Expected exactly 4 tilted-saw raw projections, patched {patched}.");
m.Body.MaxStackSize+=2;
asm.Write(output,new WriterParameters{WriteSymbols=false});
File.WriteAllText(report,$"CalculateGrindingContourSaw patched call sites: {patched}{Environment.NewLine}Each raw (safe-Z) move is now divided by cos(A) before LineWithOrientationAngle.{Environment.NewLine}");
Console.WriteLine($"SAW_IL_PATCH_OK={patched}");
return 0;

static VariableDefinition? GetLocal(MethodBody body,Instruction i){
 if(i.Operand is VariableDefinition v)return v;
 return i.OpCode.Code switch{Code.Ldloc_0=>body.Variables[0],Code.Ldloc_1=>body.Variables[1],Code.Ldloc_2=>body.Variables[2],Code.Ldloc_3=>body.Variables[3],_=>null};
}
static void NormalizeLocals(MethodBody body){
 var v=body.Variables;
 foreach(var i in body.Instructions){switch(i.OpCode.Code){
  case Code.Ldloc_0:i.OpCode=OpCodes.Ldloc;i.Operand=v[0];break;case Code.Ldloc_1:i.OpCode=OpCodes.Ldloc;i.Operand=v[1];break;case Code.Ldloc_2:i.OpCode=OpCodes.Ldloc;i.Operand=v[2];break;case Code.Ldloc_3:i.OpCode=OpCodes.Ldloc;i.Operand=v[3];break;
  case Code.Stloc_0:i.OpCode=OpCodes.Stloc;i.Operand=v[0];break;case Code.Stloc_1:i.OpCode=OpCodes.Stloc;i.Operand=v[1];break;case Code.Stloc_2:i.OpCode=OpCodes.Stloc;i.Operand=v[2];break;case Code.Stloc_3:i.OpCode=OpCodes.Stloc;i.Operand=v[3];break;
 }}
}
