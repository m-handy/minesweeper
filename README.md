C# application which generates minesweeper field.

First I wrote two cycles - one for mines generation second for counting clues and filling empty fields. But than I realized it is not necessary and I decided to use only one cycle (printing not included).

I decited to create my own structure `point` which contains only coordinates and two methods which can determine if point is on given field mine or clue.

Input parameters are harcoded in `Program.cs` class, printing is done by static class `Printer`.

I chose C# because I was asked.

```bash
cd minesweeper
dotnet run
```