﻿#define CIBUILD_disabled
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("AfterSolarSystem Mod Installation Checker")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("YWM_Studio")]
[assembly: AssemblyProduct("AfterSolarSystem")]
[assembly: AssemblyCopyright("陈雪雯  Xuewen. Chen")]
[assembly: AssemblyTrademark("YWMKerman")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("c44fc31a-d718-4d96-b789-91c4e9bfd950")]

#if CIBUILD
[assembly: AssemblyVersion("@MAJOR@.@MINOR@.@PATCH@.@BUILD@")]
[assembly: AssemblyFileVersion("@MAJOR@.@MINOR@.@PATCH@.@BUILD@")]
#else
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("24.4.5.0")]
#endif

