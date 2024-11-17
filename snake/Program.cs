using snake;
Random rand = new Random();

Coord gridDimensions = new Coord(50, 20);
int SnakeX = rand.Next(1, gridDimensions.X-1);
int SnakeY = rand.Next(1, gridDimensions.Y-1);
Coord applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
Coord snakePos = new Coord(SnakeX,SnakeY);
int frameDelayMill = 100;
Direction movementDirection = Direction.Down;
int appNum = 0;
List<Coord> snakePosHistory = new List<Coord>();
int snakeLength = 0;
    while (true)
    {
        Console.Clear();
        snakePos.ApplyMovementDirection(movementDirection);

        for (int y = 0; y < gridDimensions.Y; y++)
        {
            for (int x = 0; x < gridDimensions.X; x++)
            {
                Coord currentCoord = new Coord(x, y);
                if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                {
                    Console.Write("■");
                }
                else if (applePos.Equals(currentCoord))
                {
                    Console.Write("@");
                }

                else if (x == 0 || x == gridDimensions.X - 1 || y == 0 || y == gridDimensions.Y - 1)
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
    



    if (snakePos.Equals(applePos))
    {
        snakeLength++;
        applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
        appNum++;
    }
    
    
    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
    if (snakePosHistory.Count > snakeLength)
    {
        snakePosHistory.RemoveAt(0);
    }

    Console.WriteLine("Count:" + appNum);
    DateTime time = DateTime.Now;

    while ((DateTime.Now - time).Milliseconds < frameDelayMill)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.W:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.S:
                    movementDirection = Direction.Down;
                    break;
                case ConsoleKey.D:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.A:
                    movementDirection = Direction.Left;
                    break;
            }
        }
    }
    
}
