using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using dlech.SshAgentLib;

namespace dlech.AgentWithRice
{
  public static class CommandLineArgs
  {
    private static string[] switchDelimeters = { "/", "--", "-" };

    public static AgentMode Mode { get; set; }
    public static string[] Files { get; set; }
    public static bool QuitAfterLoad { get; set; }

    static CommandLineArgs()
    {
      Mode = AgentMode.Auto;
      Files = new string[0];
      QuitAfterLoad = false;
    }

    public static void  Parse(string[] aArgs)
    {
      List<string> files = new List<string>();
      for (int i = 0; i < aArgs.Length; i++) {
        if (CheckIsSwitch(ref aArgs[i])) {
          switch (aArgs[i]) {
            case "c":
              if (aArgs.Length > i + 1) {
                try {
                  Process.Start(aArgs[i + 1]);
                } catch (Exception ex) {
                  Console.WriteLine(ex.Message);
                }
                i++;
              }
              break;
            case "m":
              if (aArgs.Length > i + 1) {
                var mode = aArgs[i + 1].ToLowerInvariant();
                switch (mode) {
                  case "server":
                    Mode = AgentMode.Server;
                    break;
                  case "client":
                    Mode = AgentMode.Client;
                    break;
                  case "auto":
                    Mode = AgentMode.Auto;
                    break;
                  default:
                    Console.WriteLine("Unknown mode: " + mode);
                    break;
                }
                i++;
              }
              break;
            case "mq":
            case "qm":
            case "q":
              QuitAfterLoad = true;
              if (aArgs[i].Contains("m")) {
                goto case "m";
              }
              break;
            default:
              Console.WriteLine("Unknown option: " + aArgs[i]);
              break;
          }
        } else {
          aArgs[i] = Environment.ExpandEnvironmentVariables(aArgs[i]);
          files.Add(Path.GetFullPath(aArgs[i]));
        }
      }
      Files = files.ToArray();
    }

    private static bool CheckIsSwitch(ref string aArg)
    {
      foreach (var delimeter in switchDelimeters) {
        if (aArg.StartsWith(delimeter, StringComparison.OrdinalIgnoreCase)) {
          aArg = aArg.Remove(0, delimeter.Length);
          return true;
        }
      }
      return false;
    }
  }
}
