Stringen
========

"A rather handy customizable random key sequence generator. It also supports complex keys."

This is a C# version of Dec's 'keygen' in JS. https://github.com/declandewet/keygen

Example Usage
=============

The following code would produce this:
```
A86KJ-23079146722789
```
```cs
var op1 = new SimpleOptions();
op1.ElementLength = 5;
op1.Case = GenCase.Upper;
op1.Type = GenType.Alphanumeric;

var op2 = new SimpleOptions();
op2.ElementLength = 14;
op2.Type = GenType.Numeric;

var options = new ComplexOptions();
options.Seperator = "-";
options.ElementOptions = new SimpleOptions[] { op1, op2 };

Console.WriteLine(Generator.GenerateComplex(options));

Console.Read();
```
