using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrack;

public partial class RaceGame
{
    /*
    Well, I'd say factor out console drawing into a separate class, 
    try to work out dumping stuff into a byte array and then rendering it in one write call
    Once that works, start using that for your logic in your main class
    But definitely factor it out into a module first, don't just dump it in 
    */

    public const char pWrite = '*';
    public const char wallV = '║'; // NOT USED CURRENTLY
    public const char wallH = '═'; // NOT USED CURRENTLY

    public static string WallsString =
        "╔═════════════════════════════════════════════════════════════════════════════════════════════════════════╗\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                                                    |                                                    ║\n" +
        "║                  ╔═══════════════════════════════════════════════════════════════════╗                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ║                                                                   ║                  ║\n" +
        "║                  ╚═══════════════════════════════════════════════════════════════════╝                  ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "║                                                                                                         ║\n" +
        "╚═════════════════════════════════════════════════════════════════════════════════════════════════════════╝";

    public static void 
}
