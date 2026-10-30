using Day3_TaNhuQuan.Models;

namespace Day3_TaNhuQuan.Datas
{
    public class SeedData
    {
        //Simulate database with some data
        public static List<Category> Categories =  new List<Category>(){
            new Category() { ID = 1, Name = "Iphone ku ki", Description = "Description 1" },
            new Category() { ID = 2, Name = "Android ba bi", Description = "Description 2" },
            new Category() { ID = 3, Name = "Mac mo bi", Description = "Description 3" },
        };
    }
}
