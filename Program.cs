using System;

namespace sandpiles
{
    class Program
    {
        static Sandpile all3s = new Sandpile(new int[3, 3]
            {
                {3, 3, 3},
                {3, 3, 3},
                {3, 3, 3}
            });
        static Sandpile all1s = new Sandpile(new int[3, 3]
            {
                {-2, -2, -2},
                {-2, -2, -2},
                {-2, -2, -2}
            });

        static void Main(string[] args)
        {
            Console.WriteLine($"{all3s + all1s}");
            Console.WriteLine($"\n{all3s - all1s}");
            Console.WriteLine($"\n{all3s * (all1s * 2)}");
            //Console.WriteLine($"\n{all3s / (all1s * 2)}");

            if (all3s == all1s)
                Console.WriteLine("Equal :)");
            Console.ReadKey();
        }
    }

    public class Sandpile
    {
        public int Total
        {
            get
            {
                int total = 0;
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int x = 0; x < grid.GetLength(1); x++)
                    {
                        total += grid[y, x];
                    }
                }
                return total;
            }
        }

        private int[,] grid;

        public Sandpile(int[,] _grid)
        {
            grid = _grid;
        }

        public int this[int _y, int _x]
        {
            get
            {
                return grid[_y, _x];
            }
            set
            {
                grid[_y, _x] = value;
            }
        }

        public static bool operator ==(Sandpile _a, Sandpile _b)//TODO: make indefinitely scaleable
        {
            for (int y = 0; y < _a.grid.GetLength(0); y++)
            {
                for (int x = 0; x < _a.grid.GetLength(1); x++)
                {
                    if (_a[y, x] != _b[y, x])
                        return false;
                }
            }
            return true;
        }
        public static bool operator ==(Sandpile _a, int _b)//TODO: make indefinitely scaleable
        {
            for (int y = 0; y < _a.grid.GetLength(0); y++)
            {
                for (int x = 0; x < _a.grid.GetLength(1); x++)
                {
                    if (_a[y, x] != _b)
                        return false;
                }
            }
            return true;
        }

        public static bool operator !=(Sandpile _a, Sandpile _b)//TODO: make indefinitely scaleable
        {
            for (int y = 0; y < _a.grid.GetLength(0); y++)
            {
                for (int x = 0; x < _a.grid.GetLength(1); x++)
                {
                    if (_a[y, x] == _b[y, x])
                        return false;
                }
            }
            return true;
        }
        public static bool operator !=(Sandpile _a, int _b)//TODO: make indefinitely scaleable
        {
            for (int y = 0; y < _a.grid.GetLength(0); y++)
            {
                for (int x = 0; x < _a.grid.GetLength(1); x++)
                {
                    if (_a[y, x] == _b)
                        return false;
                }
            }
            return true;
        }

        public static Sandpile operator +(Sandpile _a, Sandpile _b) //TODO: make indefinitely scaleable
        {
            Sandpile final = new Sandpile(new int[3, 3]
            {
                { _a[0,0] + _b[0,0], _a[0,1] + _b[0,1], _a[0,2] + _b[0,2]},
                { _a[1,0] + _b[1,0], _a[1,1] + _b[1,1], _a[1,2] + _b[1,2]},
                { _a[2,0] + _b[2,0], _a[2,1] + _b[2,1], _a[2,2] + _b[2,2]}
            });
            return final.Topple();
        }
        public static Sandpile operator -(Sandpile _a, Sandpile _b) //TODO: make indefinitely scaleable
        {
            Sandpile final = new Sandpile(new int[3, 3]
            {
                { _a[0,0] - _b[0,0], _a[0,1] - _b[0,1], _a[0,2] - _b[0,2]},
                { _a[1,0] - _b[1,0], _a[1,1] - _b[1,1], _a[1,2] - _b[1,2]},
                { _a[2,0] - _b[2,0], _a[2,1] - _b[2,1], _a[2,2] - _b[2,2]}
            });
            return final.Topple();
        }

        public static Sandpile operator *(Sandpile _a, int _b) //TODO: make indefinitely scaleable
        {
            Sandpile final = new Sandpile(new int[3, 3]
            {
                { _a[0,0] * _b, _a[0,1] * _b, _a[0,2] * _b},
                { _a[1,0] * _b, _a[1,1] * _b, _a[1,2] * _b},
                { _a[2,0] * _b, _a[2,1] * _b, _a[2,2] * _b}
            });
            return final.Topple();
        }
        public static Sandpile operator *(Sandpile _a, Sandpile _b) //TODO: make indefinitely scaleable
        {
            Sandpile final = new Sandpile(new int[3, 3]
            {
                { _a[0,0] * _b[0,0], _a[0,1] * _b[0,1], _a[0,2] * _b[0,2]},
                { _a[1,0] * _b[1,0], _a[1,1] * _b[1,1], _a[1,2] * _b[1,2]},
                { _a[2,0] * _b[2,0], _a[2,1] * _b[2,1], _a[2,2] * _b[2,2]}
            });
            return final.Topple();
        }

        public static Sandpile operator /(Sandpile _a, Sandpile _b) //TODO: make indefinitely scaleable
        {
            Sandpile final = new Sandpile(new int[3, 3]
            {
                { _a[0,0] / _b[0,0], _a[0,1] / _b[0,1], _a[0,2] / _b[0,2]},
                { _a[1,0] / _b[1,0], _a[1,1] / _b[1,1], _a[1,2] / _b[1,2]},
                { _a[2,0] / _b[2,0], _a[2,1] / _b[2,1], _a[2,2] / _b[2,2]}
            });
            return final.Topple();
        }
        public static Sandpile operator /(Sandpile _a, int _b) //TODO: make indefinitely scaleable
        {
            Sandpile final = new Sandpile(new int[3, 3]
            {
                { _a[0,0] / _b, _a[0,1] / _b, _a[0,2] / _b},
                { _a[1,0] / _b, _a[1,1] / _b, _a[1,2] / _b},
                { _a[2,0] / _b, _a[2,1] / _b, _a[2,2] / _b}
            });
            return final.Topple();
        }

        public Sandpile SetToValue(int _a)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    grid[y, x] = _a;
                }
            }
            return this;
        }

        public Sandpile Topple()
        {
            #region Topple Corners
            if (grid[0, 0] >= 4 || grid[0, 0] <= -4)
                ToppleIndex(0, 0);
            if (grid[0, 2] >= 4 || grid[0, 2] <= -4)
                ToppleIndex(0, 2);
            if (grid[2, 0] >= 4 || grid[2, 0] <= -4)
                ToppleIndex(2, 0);
            if (grid[2, 2] >= 4 || grid[2, 2] <= -4)
                ToppleIndex(2, 2);
            #endregion  

            #region Topple Edges
            if (grid[0, 1] >= 4 || grid[0, 1] <= -4)
                ToppleIndex(0, 1);
            if (grid[1, 2] >= 4 || grid[1, 2] <= -4)
                ToppleIndex(1, 2);
            if (grid[1, 0] >= 4 || grid[1, 0] <= -4)
                ToppleIndex(1, 0);
            if (grid[2, 1] >= 4 || grid[2, 1] <= -4)
                ToppleIndex(2, 1);
            #endregion

            #region Topple Middle
            if (grid[1, 1] >= 4 || grid[1, 1] <= -4)
                ToppleIndex(1, 1);
            #endregion

            if (Topplable())
                Topple();
            return this;
        }
        public bool Topplable()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (grid[y, x] >= 4)
                        return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return $"{grid[0, 0]} {grid[0, 1]} {grid[0, 2]}\n{grid[1, 0]} {grid[1, 1]} {grid[1, 2]}\n{grid[2, 0]} {grid[2, 1]} {grid[2, 2]}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void ToppleIndex(int _y, int _x)
        {
            grid[_y, _x] -= Math.Sign(grid[_y, _x]) == 1 ? 4 : -4; //reduce current index

            int down = _y - 1;
            int up = _y + 1;
            int left = _x - 1;
            int right = _x + 1;

            if (down >= 0)
                grid[down, _x] += 1;
            if (up <= grid.GetLength(0) - 1)
                grid[up, _x] += 1;
            if (left >= 0)
                grid[_y, left] += 1;
            if (right <= grid.GetLength(1) - 1)
                grid[_y, right] += 1;
        }
    }

    public struct Vec2
    {
        public int x { get; }
        public int y { get; }

        public Vec2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

}
