namespace RaceGame;

public class Tracks
{

    public static readonly char[][] Track1 =
    {
        "╔═════════════════════════════════════════════════════════════════════════════════════════════════════════╗".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                                                     #                                                   ║".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                                                     |                                                   ║".ToCharArray(),
        "║                  ╔═══════════════════════════════════════════════════════════════════╗                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ║                                                                   ║                  ║".ToCharArray(),
        "║                  ╚═══════════════════════════════════════════════════════════════════╝                  ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "║                                                                                                         ║".ToCharArray(),
        "╚═════════════════════════════════════════════════════════════════════════════════════════════════════════╝".ToCharArray(),
    };

    public static readonly char[][] Track2 =
    {
        "╔═══════════════════════════════════════════════════════════════════════════╗".ToCharArray(),
        "║                                        |                                  ║".ToCharArray(),
        "║                                        |                                  ║".ToCharArray(),
        "║                                        |                                  ║".ToCharArray(),
        "║                                        |      ╔══╗                        ║".ToCharArray(),
        "║                                        #      ║║║║                        ║".ToCharArray(),
        "║                                        |      ╚══╝                        ║".ToCharArray(),
        "║                                        |                                  ║".ToCharArray(),
        "║                                        |                                  ║".ToCharArray(),
        "║                  ╔═════════════════════════════════════╗                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ║                                     ║                  ║".ToCharArray(),
        "║                  ╚═════════════════════════════════════╝                  ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "║                                                                           ║".ToCharArray(),
        "╚═══════════════════════════════════════════════════════════════════════════╝".ToCharArray(),
    };

    
      public static readonly char[][] TrackMenu =
    {
        "             ╔════════════════╗     ".ToCharArray(),
        " Play Again  ║  |          |  ║ Exit".ToCharArray(),
        "             ╚══════╗   ╔═════╝     ".ToCharArray(),
        "                    ║   ║           ".ToCharArray(),
    };

    public char[][][] Levels = { TrackMenu, Track1, Track2 };
}
