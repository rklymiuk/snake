using snake;
Random rand = new Random();

Coord gridDimensions = new Coord(50, 20);
int SnakeX = rand.Next(1, gridDimensions.X-1);
int SnakeY = rand.Next(1, gridDimensions.Y-1);
Coord applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
Coord snakePos = new Coord(SnakeX,SnakeY);
int frameDelayMill = 100;

while (true)
{
    Console.Clear();
    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);
            if (snakePos.Equals(currentCoord))
            {
                Console.Write("■");
            }
            else if (applePos.Equals(currentCoord))
            {
                Console.Write("@");
            }
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    Thread.Sleep(frameDelayMill);
}