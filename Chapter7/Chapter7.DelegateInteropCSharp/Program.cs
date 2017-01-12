using Microsoft.FSharp.Core;
using System.Diagnostics;

namespace Chapter7.DelegateInteropCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var proclist = Process.GetProcesses();
            int index_devenv = FuncInterop.GetRowIndex(proclist, FuncConvert.ToFSharpFunc((Process p) => p.ProcessName.Equals("explorer.exe")));
        }
    }
}
