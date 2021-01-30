using App.Tools;

const string defaultLine = "панки хой";
var caesarInput = args.Length == 0 ? defaultLine : args[0];
var vigenereInput = args.Length == 2 ? args[1] : defaultLine;

Provider provider = new CaesarProvider(caesarInput);
provider.Output();
System.Console.WriteLine("\n\n");
provider = new VigenereProvider(vigenereInput);
provider.Output();