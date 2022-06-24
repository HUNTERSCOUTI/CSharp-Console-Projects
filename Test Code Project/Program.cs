int[] arrayOfProdcuts = { 3, 6, 2, 5, 1 };

int lowestPriced = arrayOfProdcuts[0];
int placeOfLowest = -1;

for (int i = 0; i < arrayOfProdcuts.Length; i++)
{
    if (arrayOfProdcuts[i] < lowestPriced)
    {
        lowestPriced = arrayOfProdcuts[i];
        placeOfLowest = i;
    }
}

arrayOfProdcuts[placeOfLowest] = 0;

int cheapestProduct = -1;
for (int i = 0; i < 5; i++)
    cheapestProduct += arrayOfProdcuts[i];

Console.Write(cheapestProduct);



