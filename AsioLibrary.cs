using NAudio.Wave;
using System.Runtime.InteropServices;


public class AsioLibrary
{
    [UnmanagedCallersOnly(EntryPoint = "GetAsioDriverNames")]
    public static IntPtr GetAsioDriverNames()
    {
        try
        {
            var drivers = AsioOut.GetDriverNames();
            string result = string.Join("\n", drivers);

            // 文字列をネイティブメモリに格納
            IntPtr buffer = Marshal.StringToHGlobalAnsi(result);
            return buffer;
        }
        catch (Exception)
        {
            return IntPtr.Zero;
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "FreeMemory")]
    public static void FreeMemory(IntPtr ptr)
    {
        if (ptr != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}
