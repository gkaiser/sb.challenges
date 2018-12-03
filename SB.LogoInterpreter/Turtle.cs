using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Drawing;

// https://youtu.be/i-k04yzfMpw?t=748
// https://en.wikipedia.org/wiki/Logo_(programming_language)
// http://cs.brown.edu/courses/bridge/1997/Resources/LogoTutorial.html

namespace SB.LogoInterpreter
{
  public class Turtle
  {
    public int X;
    public int Y;
    public Graphics Canvas;
    public List<string> SourceTokens;
    public bool IsPenDown = true;
    public bool IsHidden = false;
    public Bitmap Drawing = null;

    public static List<Command> CommandList;
    private int SourceTokenPosition;
    private string IntProgramSource;
    private int DrawAngle = 90;


    public class Command
    {
      public List<string> Names;
      public Type[] ArgumentTypes;
      public Delegate Delegate;

      public int ArgumentCount => this.ArgumentTypes.Length;

      public override string ToString()
      {
        return (this.Names == null || this.Names.Count == 0 ? "" : this.Names[0]);
      }
    }

    public Turtle(string src) : this(0, 0, src) { }

    public Turtle(int x, int y, string src)
    {
      this.X = x;
      this.Y = y;
      this.ProgramSource = src;
      this.Drawing = new Bitmap(500, 500);

      using (var g = Graphics.FromImage(this.Drawing))
        g.FillRectangle(Brushes.Purple, 0, 0, 500, 500);

        Turtle.CommandList = new List<Command>
      {
        new Command { Names = new List<string> { "fd", "forward" }, ArgumentTypes = new[] { typeof(int) }, Delegate = new Action<int>(this.MoveForward) },
        new Command { Names = new List<string> { "bk", "backward" }, ArgumentTypes = new[] { typeof(int) }, Delegate = new Action<int>(this.MoveBackward) },
        new Command { Names = new List<string> { "rt", "right" }, ArgumentTypes = new[] { typeof(int) }, Delegate = new Action<int>(this.MoveRight) },
        new Command { Names = new List<string> { "lt", "left" }, ArgumentTypes = new[] { typeof(int) }, Delegate = new Action<int>(this.MoveLeft) },
        new Command { Names = new List<string> { "cs", "clearscreen" }, ArgumentTypes = new Type[0], Delegate = new Action(this.ClearScreen) },
        new Command { Names = new List<string> { "pu", "penup" }, ArgumentTypes = new Type[0], Delegate = new Action(this.SetPenUp) },
        new Command { Names = new List<string> { "pd", "pendown" }, ArgumentTypes = new Type[0], Delegate = new Action(this.SetPenDown) },
        new Command { Names = new List<string> { "ht", "hideturtle" }, ArgumentTypes = new Type[0], Delegate = new Action(this.HideTurtle) },
        new Command { Names = new List<string> { "st", "showturtle" }, ArgumentTypes = new Type[0], Delegate = new Action(this.ShowTurtle) },
        new Command { Names = new List<string> { "home" }, ArgumentTypes = new Type[0], Delegate = new Action(this.MoveTurtleHome) },
        new Command { Names = new List<string> { "label" }, ArgumentTypes = new Type[0], Delegate = new Action(() => { }) },
        new Command { Names = new List<string> { "setxy" }, ArgumentTypes = new Type[0], Delegate = new Action(() => { }) },
      };
    }

    public string ProgramSource
    {
      get { return this.IntProgramSource; }
      set
      {
        this.IntProgramSource = value;

        this.SourceTokens = this.IntProgramSource.Split(' ').ToList();
        this.SourceTokenPosition = 0;
      }
    }

    public bool ProcessSource()
    {
      if (this.SourceTokenPosition >= this.SourceTokens.Count)
        return false;

      var cmdStr = this.SourceTokens[this.SourceTokenPosition];

      if (!this.IsValidCommand(cmdStr))
      {
        System.Diagnostics.Debug.WriteLine($"Invalid command \"{cmdStr}\"; bailing out.");
        return false;
      }

      var cmd = cmdStr.ToCommand();
      var args = new string[cmd.ArgumentCount];

      for (int j = 1; j <= args.Length; j++)
      {
        args[j - 1] = this.SourceTokens[this.SourceTokenPosition + j];
        this.SourceTokenPosition++;
      }

      System.Diagnostics.Debug.WriteLine($"Processing command \"{cmd}{(args.Length == 0 ? "" : $" {string.Join(" ", args)}")}\"...");

      if (cmd.Delegate is Action<int, int>)
        cmd.Delegate.DynamicInvoke(int.Parse(args[0]), int.Parse(args[1]));
      else if (cmd.Delegate is Action<int>)
        cmd.Delegate.DynamicInvoke(int.Parse(args[0]));
      else if (cmd.Delegate is Action)
        cmd.Delegate.DynamicInvoke();

      this.SourceTokenPosition++;

      return true;
    }

    private bool IsValidCommand(string cmd) => Turtle.CommandList.Any(c => c.Names.Contains(cmd.Trim().ToLower()));

    public void MoveForward(int u)
    {
      if (u == 0)
        return;

      var currPt = this.GetGraphicsPoint();

      this.CalculateNextPoint(u);

      var nextPt = this.GetGraphicsPoint();

      using (var g = Graphics.FromImage(this.Drawing))
        g.DrawLine(new Pen(Brushes.White, 4), currPt.X, currPt.Y, nextPt.X, nextPt.Y);
    }

    public void MoveBackward(int u)
    {
      if (u == 0)
        return;

      var currPt = this.GetGraphicsPoint();

      this.CalculateNextPoint(u * -1);

      var nextPt = this.GetGraphicsPoint();

      using (var g = Graphics.FromImage(this.Drawing))
        g.DrawLine(new Pen(Brushes.White, 4), currPt.X, currPt.Y, nextPt.X, nextPt.Y);
    }

    public void MoveRight(int d)
    {
      this.DrawAngle = (this.DrawAngle + (d * -1)) % 360;
    }

    public void MoveLeft(int d)
    {
      this.DrawAngle = (this.DrawAngle + (d * 1)) % 360;
    }

    public void ClearScreen() { }

    public void SetPenUp() { this.IsPenDown = false; }

    public void SetPenDown() { this.IsPenDown = true; }

    public void HideTurtle() { this.IsHidden = true; }

    public void ShowTurtle() { this.IsHidden = false; }

    public void MoveTurtleHome() { this.SetPosition(0, 0); }

    public void SetPosition(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    private void CalculateNextPoint(int dist)
    {
      var x0 = this.X;
      var y0 = this.Y;
      var x1 = x0 + (dist * Math.Cos(this.DrawAngle.ToRads()));
      var y1 = y0 + (dist * Math.Sin(this.DrawAngle.ToRads()));

      if (x1 > 250)
        x1 = -250 + (x1 % 250);
      if (x1 < -250)
        x1 = 250 - (x1 % 250);

      if (y1 > 250)
        y1 = -250 + (y1 % 250);
      if (y1 < -250)
        y1 = 250 - (y1 % 250);

      this.X = (int)x1;
      this.Y = (int)y1;

      System.Diagnostics.Debug.WriteLine($"CRT {{{x0}, {y0}}} ==> {{{this.X}, {this.Y}}}");
      System.Diagnostics.Debug.Assert(this.X >= -250 && this.X <= 250 && this.Y >= -250 && this.Y <= 250);

      return;
    }

    private Point GetGraphicsPoint()
    {
      var gfxX = 250 + this.X;
      var gfxY = (this.Y < 0 ? 250 + Math.Abs(500 - this.Y) : 250 - this.Y);

      System.Diagnostics.Debug.WriteLine($"GFX {{{this.X}, {this.Y}}} ==> {{{gfxX}, {gfxY}}}");

      return new Point(gfxX, gfxY);
    }

  }
}
