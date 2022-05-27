namespace RaceTrack;

public partial class RaceGame
{
    public static char[][] Track1 =
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

    public static char[][] Track2 =
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

    
      public static char[][] TrackMenu =
    {
        "             ╔════════════════╗     ".ToCharArray(),
        " Play Again  ║  |          |  ║ Exit".ToCharArray(),
        "             ╚══════╗   ╔═════╝     ".ToCharArray(),
        "                    ║   ║           ".ToCharArray(),
    };

    static char[][][] Levels = { TrackMenu, Track1, Track2 };
}
