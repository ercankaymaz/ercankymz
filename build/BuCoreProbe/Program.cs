using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

if(args.Length<2) return 2;
var input=Path.GetFullPath(args[0]); var output=Path.GetFullPath(args[1]);
var resolver=new DefaultAssemblyResolver(); resolver.AddSearchDirectory(Path.GetDirectoryName(input)!);
using var asm=AssemblyDefinition.ReadAssembly(input,new ReaderParameters{AssemblyResolver=resolver,InMemory=true});
var type=asm.MainModule.Types.First(t=>t.FullName=="buCore.buCamCalc");
var m=type.Methods.First(x=>x.Name=="CalculateGrindingContourSaw" && x.Parameters.Count==6);
using var w=new StreamWriter(output,false);
w.WriteLine($"METHOD {m.FullName} LOCALS={m.Body.Variables.Count} INS={m.Body.Instructions.Count}");
var ins=m.Body.Instructions;
var calls=ins.Select((x,i)=>(x,i)).Where(z=>z.x.Operand is MethodReference mr && mr.Name=="LineWithOrientationAngle").ToList();
w.WriteLine($"CALLS={calls.Count}");
foreach(var c in calls){
  w.WriteLine($"\n=== CALL INDEX {c.i} OFFSET IL_{c.x.Offset:X4} ===");
  for(int i=Math.Max(0,c.i-35);i<=Math.Min(ins.Count-1,c.i+5);i++){
    var x=ins[i];
    string op=x.Operand switch {
      VariableDefinition v => $"V_{v.Index}:{v.VariableType.FullName}",
      ParameterDefinition p => $"ARG_{p.Index}:{p.ParameterType.FullName}",
      MethodReference mr => mr.FullName,
      FieldReference fr => fr.FullName,
      Instruction ti => $"IL_{ti.Offset:X4}",
      Instruction[] arr => string.Join(",",arr.Select(a=>$"IL_{a.Offset:X4}")),
      null => "",
      _ => x.Operand.ToString() ?? ""
    };
    w.WriteLine($"{i,5} IL_{x.Offset:X4}: {x.OpCode,-12} {op}");
  }
}
Console.WriteLine($"WROTE {output} calls={calls.Count}");
return 0;
