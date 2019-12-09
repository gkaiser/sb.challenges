using System;
using System.Linq;

namespace AoC2019
{
  public enum ParameterMode
  {
    PositionMode = 0,
    ImmediateMode = 1,
  }

  public class IntcodeComputer
  {
    private int Input = 0;

    public IntcodeComputer(int input) { this.Input = input; }

    public void ProcessProgram(int[] prog)
    {
      for (int i = 0; i < prog.Length; /**/)
      {
        if (prog[i] == 99)
          break;

        //                       01234
        var ops = $"{prog[i + 0]:00000}";
        var op = int.Parse(ops.Substring(3));
        var m1 = (ops.Substring(2, 1) == "0" ? ParameterMode.PositionMode : ParameterMode.ImmediateMode);
        var m2 = (ops.Substring(1, 1) == "0" ? ParameterMode.PositionMode : ParameterMode.ImmediateMode);
        var m3 = (ops.Substring(0, 1) == "0" ? ParameterMode.PositionMode : ParameterMode.ImmediateMode);

        if (op == 1)
        {
          var p1 = (m1 == ParameterMode.PositionMode ? prog[prog[i + 1]] : prog[i + 1]);
          var p2 = (m2 == ParameterMode.PositionMode ? prog[prog[i + 2]] : prog[i + 2]);
          var p3 = prog[i + 3];

          prog[p3] = p1 + p2;
          i += 4;
        }
        else if (op == 2)
        {
          var p1 = (m1 == ParameterMode.PositionMode ? prog[prog[i + 1]] : prog[i + 1]);
          var p2 = (m2 == ParameterMode.PositionMode ? prog[prog[i + 2]] : prog[i + 2]);
          var p3 = prog[i + 3];

          prog[p3] = p1 * p2;
          i += 4;
        }
        else if (op == 3)
        {
          var p1 = prog[i + 1];

          prog[p1] = this.Input;
          i += 2;
        }
        else if (op == 4)
        {
          var p1 = (m1 == ParameterMode.PositionMode ? prog[prog[i + 1]] : prog[i + 1]);

          Console.WriteLine($"{p1}");
          i += 2;
        }
      }
    }

  }
}
