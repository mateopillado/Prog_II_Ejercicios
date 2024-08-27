// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Repaso1w3; //polimorfismo, herencia

//object p = new Pack();
//object s = new Suelto();

//object[] productos = { p, s }; //nos permite hacer arreglos de distintos tipos de objetos

var pack = new Pack(); //hacemos un objeto pack  //el var funciona parecido al object
pack.Precio = 100;
pack.Cantidad = 2;
pack.Nombre = "mi pack";

var suelto = new Suelto();
suelto.Precio = 500;
suelto.Medida = 4;
suelto.Nombre = "Mi suelto";

Producto[] productos = {pack, suelto}; //array productos con 2 productos: pack y suelto 

double total = 0;
foreach (Producto p in productos)//dentro de la lista productos busca cualquier objeto. Producto no puede se rporque es abstracto
{
    Console.WriteLine(p.ToString());
    total += p.CalcularPrecio();
} 
//despues de recorrer todos los productos de mi arreglo y calcular el precio Mostrar el total
Console.WriteLine(total);
    
