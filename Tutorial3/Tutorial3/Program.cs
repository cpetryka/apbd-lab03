// See https://aka.ms/new-console-template for more information

using Tutorial3.Containers;
using Tutorial3.Containers.Impl;
using Tutorial3.Model;
using Tutorial3.Ships;

// =====================================================================================================
// CREATE CONTAINERS
// =====================================================================================================
var containers = new List<AbstractContainer>
{
    // =====> Stworzenie kontenera danego typu
    new LiquidContainer(20, 10, 10, 100, LiquidType.Standard),
    new LiquidContainer(20, 10, 10, 100, LiquidType.Hazardous),
    new GasContainer(20, 10, 10, 100, 0.5),
    new RefrigeratedContainer(20, 10, 10, 100, "bananas", 15)
};

Console.WriteLine("CONTAINERS:");

foreach (var container in containers)
{
    // =====> Załadowanie ładunku do danego kontenera
    container.Load(60);
    // =====> Wypisanie informacji o danym kontenerze
    Console.WriteLine(container);
}

// =====================================================================================================
// CREATE AND LOAD SHIPS
// =====================================================================================================
var ship = new ContainerShip(50, 10, 1000);

// =====> Załadowanie listy kontenerów na statek
ship.LoadContainers(containers);

var liquidContainer = new LiquidContainer(20, 10, 10, 100, LiquidType.Standard);
liquidContainer.Load(50);

// =====> Rozładowanie kontenera
liquidContainer.Unload();

// =====> Załadowanie kontenera na statek
ship.LoadContainer(liquidContainer);

// =====> Usunięcie kontenera ze statku
ship.UnloadContainer(liquidContainer);

// =====> Zastąpienie kontenera na statku o danym numerze innym kontenerem
ship.ReplaceContainer("KON-L-1", liquidContainer);

// =====> Wypisanie informacji o danym statku i jego ładunku
Console.WriteLine("SHIP:");
Console.WriteLine(ship);

// =====> Możliwość przeniesienie kontenera między dwoma statkami
var ship2 = new ContainerShip(50, 10, 1000);
ship.TransferContainer(ship2, "KON-L-3");

Console.WriteLine("SHIP 2:");
Console.WriteLine(ship2);