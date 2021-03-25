using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class ShopListRoot
    {
        public ShopList shopList { get; set; }
    }

    class ShopList
    {
        public Seed[] seed { get; set; }
        public Food[] food { get; set; }
        public Animal[] animal { get; set; }
        public Farmshop[] farmshop { get; set; }
    }

    public class Seed
    {
        public int id { get; set; }
        public int money { get; set; }
    }

    public class Food
    {
        public int id { get; set; }
        public int money { get; set; }
    }

    public class Animal
    {
        public int id { get; set; }
        public int money { get; set; }
    }

    public class Farmshop
    {
        public int id { get; set; }
        public int money { get; set; }
    }
}
