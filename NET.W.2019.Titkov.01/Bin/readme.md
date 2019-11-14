## How to
### Build a multifile assembly
1. Compile "Test.cs" with `csc /t:module Test.cs` 
2. Compile "QuickSort.cs" with `csc /t:module QuickSort.cs` 
3. Compile "MergeSort.cs" with `csc /t:module MergeSort.cs` 
4. Compile "Program.cs" with `csc Program.cs /addmodule:Test.netmodule;QuickSort.netmodule;MergeSort.netmodule` 
  
### Sign
1. Generate key pair with `sn -k IvanTitkov.snk`
2. Compile "Program.cs" with `csc Program.cs /addmodule:Test.netmodule;QuickSort.netmodule;MergeSort.netmodule /keyfile:IvanTitkov.snk`
