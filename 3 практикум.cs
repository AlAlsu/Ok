using System;

// Базовый класс для растений
abstract class Plant
{
    public string Name { get; set; }
    public string Variety { get; set; }
}
// Класс Яблоня, наследуется от растения
class AppleTree : Plant
{
    public AppleTree()
    {
        this.Name = "Яблоня";
    }
}
// Класс Смородина, наследуется от растения
class Currant : Plant
{
    public Currant()
    {
        this.Name = "Смородина";
    }
}
class Gardener
{
    public string Name { get; set; }
}

class PlantingPlants<G, P> where G : Gardener where P : Plant
{
    public PlantingPlants(G Gardener, P Plant)
    {
        this.Plant = Plant;
        this.Gardener = Gardener;
    }
    public G Gardener { get; set; }
    public P Plant { get; set; }
    public void ToPlant()
    {
        Console.WriteLine($"Садовник {this.Gardener.Name} посадил растение {this.Plant.Name}, сорта {this.Plant.Variety}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляр садовника
        var gardenerIvan = new Gardener { Name = "Иван" };
        // Создаем экземпляр яблони
        var appleTree = new AppleTree { Variety = "Антоновка" };

        var PlantingPlantsWithApple = new PlantingPlants<Gardener, AppleTree>(gardenerIvan, appleTree);
        PlantingPlantsWithApple.ToPlant();

        // Создаем экземпляр садовника
        var gardenerVasiliy = new Gardener { Name = "Василий" };
        // Создаем экземпляр смородины
        var currant = new Currant { Variety = "Черная" };

        var PlantingPlantsWithCurrant = new PlantingPlants<Gardener, Currant>(gardenerVasiliy, currant);
        PlantingPlantsWithCurrant.ToPlant();
    }
}
