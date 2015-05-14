# ManagedStackExplorer
Managed Stack Explorer provides call stack for .NET applications using managed code with thread local variables. The API as of now does not provide values for the local variables. When it is available we can update it. It is a single executable without any other dll's. It uses [Costura](https://github.com/Fody/Costura) to embed dll.

This is built using [Microsoft.Diagnostics.Runtime](https://www.nuget.org/packages/Microsoft.Diagnostics.Runtime/)  
 
The debug shim works specific to processor and would not be able to get callstacks if it is not. So x86 exe cannot get call-stacks of x64. That's reason for x86 and x64 specific exe's. There is no differenc in code other than how it is compiled.

 [Download 64Bit Version executable](https://github.com/naveensrinivasan/ManagedCallStack/releases/download/Alpha/ManagedCallStack-x64.zip)  
 [Download 32Bit Version executable](https://github.com/naveensrinivasan/ManagedCallStack/releases/download/Alpha/ManagedCallStack-x86.zip)

![Preview](screenshot.jpg)
