
const char block = '■';
const char empty = ' ';

string final = string.Empty;
string test = string.Empty;

int barLength = 20;

double maxHealth = 50;
double currentHealth = 40;

double tenpercent = maxHealth / 10;
double fivepercent = maxHealth / 10 / 2;

final += "[";

for (int i = 0; i < barLength; i++)
{
    if (currentHealth >= fivepercent)
        final += block;
    else
        final += empty;
    currentHealth -= fivepercent;
}

final += "]";
Console.WriteLine(final);








test += "[";
for (var i = 0; i < 20; ++i)
{
    if (i == 10)
        test += "c";
    else
    test += block;
}
test += "]";
Console.SetCursorPosition(0, 1);
Console.WriteLine(test);