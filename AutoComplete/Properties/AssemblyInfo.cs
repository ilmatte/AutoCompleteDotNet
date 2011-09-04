using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web.UI;
using System;
using System.Security.Permissions;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: CLSCompliant(false)]
[assembly: AssemblyTitle("AutoComplete.Net")]
[assembly: AssemblyDescription(".Net wrapper around JQuery UI Autocomplete")]
[assembly: AssemblyCompany("IM Software")]
[assembly: AssemblyProduct("AutoComplete.Net")]
[assembly: AssemblyCopyright("IM Software ©  2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("dcc20507-4fb9-46af-8aa3-17b86e64cd7b")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.1.0")]
[assembly: AssemblyFileVersion("1.0.1.0")]

[assembly: TagPrefix("AutoComplete", "IM")]
[assembly: WebResource("AutoComplete.Scripts.IM.AutoComplete.js", "application/x-javascript")]
[assembly: WebResource("AutoComplete.Scripts.jquery.js", "application/x-javascript")]
[assembly: WebResource("AutoComplete.Scripts.jquery-ui.js", "application/x-javascript")]
[assembly: WebResource("AutoComplete.Style.jquery-ui.css", "text/css")]

// minimal permission to use this assembly, 
// it's better to set any other permissions only before the deploy.
// Note: Default permission available for local assembly are FullTrust (all)
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]