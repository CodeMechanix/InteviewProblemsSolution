using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management;
using System.Runtime.InteropServices;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Build an options object for the remote connection
            // if you plan to connect to the remote
            // computer with a different user name
            // and password than the one you are currently using.
            // This example uses the default values.

            ConnectionOptions options =
                new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Username = "Administrator";
            options.Password = "Zertodata1!";

            // Make a connection to a remote computer.
            // Replace the "FullComputerName" section of the
            // string "\\\\FullComputerName\\root\\cimv2" with
            // the full computer name or IP address of the
            // remote computer.
            ManagementScope scope =
                new ManagementScope(
                    "\\\\10.171.18.163\\root\\cimv2", options);
            scope.Connect();

            //Query system for Operating System information
            //            ObjectQuery query = new ObjectQuery(
            //                "SELECT * FROM Win32_FileSpecification");

            string className = "Win32_FileSpecification";
//            string className = "CIM_DataFile";

            string Drive = "c:";
            string Path = "\\\\TestFiles\\\\";
            string FullName = "c:\\\\testfiles\\\\100kb.txt";

            //            ObjectQuery query =
            //                new ObjectQuery($"SELECT * FROM {className} Where Drive='{Drive}' AND Path='{Path}' AND  Name='{FullName}' ");


//            ManagementObjectSearcher searcher =
//                new ManagementObjectSearcher(scope, query);


//            ManagementObjectCollection queryCollection = searcher.Get();
//
//            foreach (ManagementBaseObject o in queryCollection)
//            {
//                PropertyDataCollection propertyDataCollection = o.Properties;
//
//               
//
//                foreach (var propertyData in propertyDataCollection)
//                {
//                     Debug.WriteLine($"{propertyData.Name} - {propertyData.Value}");
//                   
//                }
//               
//            }
        }

      
        [TestMethod]
        public void T4()
        {
            string _directoryPath = @"\\10.171.18.163\c$";
            string _userName = "Administrator";
            string _password = "Zertodata1!";
           

                using (new NetworkConnection.NetworkConnection(@"\\10.171.18.163", new NetworkCredential(_userName, _password)))
                {
                    string[] strings = Directory.GetFiles(_directoryPath);
                    foreach (string s in strings)
                    {
                        Debug.WriteLine(s);

                    }
                }

        
        }

        [TestMethod]
        public void StartService()
        {
            // Build an options object for the remote connection
            // if you plan to connect to the remote
            // computer with a different user name
            // and password than the one you are currently using.
            // This example uses the default values.

            ConnectionOptions options =  new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Username = "Administrator";
            options.Password = "Zertodata1!";

            // Make a connection to a remote computer.
            // Replace the "FullComputerName" section of the
            // string "\\\\FullComputerName\\root\\cimv2" with
            // the full computer name or IP address of the
            // remote computer.
            string FullComputerName = "10.171.18.163";
            ManagementScope scope =  new ManagementScope(  $"\\\\{FullComputerName}\\root\\cimv2", options);
            scope.Connect();

            //Query system for Operating System information
            //            ObjectQuery query = new ObjectQuery(
            //                "SELECT * FROM Win32_FileSpecification");

            //string className = "Win32_FileSpecification";
            //            string className = "CIM_DataFile";

           

            //            ObjectQuery query =
            //                new ObjectQuery($"SELECT * FROM {className} Where Drive='{Drive}' AND Path='{Path}' AND  Name='{FullName}' ");


            //            ManagementObjectSearcher searcher =
            //                new ManagementObjectSearcher(scope, query);


            //            ManagementObjectCollection queryCollection = searcher.Get();
            //
            //            foreach (ManagementBaseObject o in queryCollection)
            //            {
            //                PropertyDataCollection propertyDataCollection = o.Properties;
            //
            //               
            //
            //                foreach (var propertyData in propertyDataCollection)
            //                {
            //                     Debug.WriteLine($"{propertyData.Name} - {propertyData.Value}");
            //                   
            //                }
            //               
            //            }
        }

        public void CallMethod(ManagementScope scope)
        {
            try// Get the client's SMS_Client class.  
            {
                ManagementClass cls = new ManagementClass(scope.Path.Path, "sms_client", null);

                // Get current site code.  
                ManagementBaseObject outSiteParams = cls.InvokeMethod("GetAssignedSite", null, null);

                // Display current site code.  
                Console.WriteLine(outSiteParams["sSiteCode"].ToString());

                // Set up current site code as input parameter for SetAssignedSite.  
                ManagementBaseObject inParams = cls.GetMethodParameters("SetAssignedSite");
                inParams["sSiteCode"] = outSiteParams["sSiteCode"].ToString();

                // Assign the Site code.  
                ManagementBaseObject outMPParams = cls.InvokeMethod("SetAssignedSite", inParams, null);
            }
            catch (ManagementException e)
            {
                throw new Exception("Failed to execute method", e);
            }
        }


    }
}