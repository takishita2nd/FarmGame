using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    public class Recipes
    {
        public Recipe[] recipe { get; set; }
    }

    public class Recipe
    {
        public int id { get; set; }
        public Material[] material { get; set; }
    }

    public class Material
    {
        public int id { get; set; }
        public int num { get; set; }
    }
}
