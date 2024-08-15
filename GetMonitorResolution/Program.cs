using System.Management;

namespace GetMonitorResolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Will save your screen resolution value
            int screen_w = 0, screen_h = 0;

            // MOS.cs contains information about videocontroller(videocard).
            // Query returns Horizontal & Vertical resolution into variables.
            ManagementObjectSearcher mydisplayResolution =
                new ManagementObjectSearcher("SELECT CurrentHorizontalResolution, CurrentVerticalResolution FROM Win32_VideoController");

            // Variables of resolution also converting to int
            foreach (ManagementObject record in mydisplayResolution.Get())
            {
                screen_w = Convert.ToInt32(record["CurrentHorizontalResolution"]);
                screen_h = Convert.ToInt32(record["CurrentVerticalResolution"]);
            }

            // Displaying results of query
            Console.WriteLine("Your screen resolution is: " + screen_w + "x" + screen_h);

            // Waiting for user
            Console.ReadLine();
        }
    }
}
