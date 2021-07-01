//code from: https://codingvision.net/security/c-inject-a-dll-into-a-process-w-createremotethread?__cf_chl_jschl_tk__=2a3993b37e140fd5a7a8645192de1c1630e0c9d8-1599538870-0-ARKO-NPK2MtDXii4oSV2riphghPclQi-gQGRS3YVFXMaoIhdCV4hGkJZUIg05gNRFHBPN-4qsADv8RbunAs89nNiOG8TEb_e3HOGAKz2Czw5El5scw8BVxXe5UV6BZinKRz6YSkyl3IRvJdy7qenH3j5VgDrayJNYJ4qQFg2zLBCmbykwEAftoMfy9G-TrkVFLLxqoZ6XETPF-JBlffJu52BDEYA-FWR-AxIgHdyyTcXU3mkOKLlArP-aPGYlMuUal-7RQrB5pylKpbGt3ZiwAvnyHY84JZzHrHhu6PniGGYayxsI0zlO8FEtFeTpUA-vTQ6wjSeOYgWtNq3AT33hFgQ6MY82P28tW2711YYg2J_eU9ZWvdqpAEDC77DVWRqz3WOhW-UixuN4_ObXhfkLskEa6wbcNe_HpPUwEJAeRuA
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace injector
{
    public class BasicInject
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        // privileges
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        public static int Inject(string dllpath, string procname)
        {
            // the target process - I'm using a dummy process for this
            // if you don't have one, open Task Manager and choose wisely
            Process targetProcess = Process.GetProcessesByName(procname)[0];

            // geting the handle of the process - with required privileges
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

            // searching for the address of LoadLibraryA and storing it in a pointer
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            // name of the dll we want to inject
            string dllName = dllpath;

            // alocating some memory on the target process - enough to store the name of the dll
            // and storing its address in a pointer
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

            // writing the name of the dll there
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);

            // creating a thread that will call LoadLibraryA with allocMemAddress as argument
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            return 0;
        }
    }
}