#define CIBUILD_disabled
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("The AfterSolarSystem Mod")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("YWMKerman")]
[assembly: AssemblyTrademark("YWM_Studio")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("c44fc31a-d718-4d96-b789-91c4e9bfd950")]

#if CIBUILD
[assembly: AssemblyVersion("@MAJOR@.@MINOR@.@PATCH@.@BUILD@")]
[assembly: AssemblyFileVersion("@MAJOR@.@MINOR@.@PATCH@.@BUILD@")]
#else
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("114.514.191.9810")]
#endif

