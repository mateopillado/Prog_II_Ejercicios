
using RepositoryExample.Data;
using RepositoryExample.Domain;
using RepositoryExample.Services;

//ProductManager manager = new ProductManager();

////Create new product:
//var oProduct = new Product()
//{
//    Nombre = "PRODUCTO DE PRUEBA",
//    Stock = 2000,
//    Activo = true
//};
////if (manager.SaveProduct(oProduct))
//    Console.WriteLine("PRODUCTO CREADO EXISTOSAMENTE!");

////List all product of store:
//List<Product> lst = manager.GetProducts();
//if(lst.Count == 0)
//{
//    Console.WriteLine("Sin productos en la base de datos");

//}
//else
//{
//    foreach(var oProducto in lst)
//    {
//        Console.WriteLine(oProducto);
//    }
//}

////Delete product cod = 1:
//if (manager.DeleteProduct(1))
//    Console.WriteLine("PRODUCTO ACTUALIZADO CON DATOS DE BAJA!");


ProductManager manejador = new ProductManager();


Product pro1 = new Product();
pro1.Nombre = "Carne";
pro1.Stock = 10;
pro1.Codigo = 0;


//if (manejador.SaveProduct(pro1))
//{
//    Console.WriteLine("Guardado");
//}

//manejador.DeleteProduct(4);


Product pro2 = new Product();
pro2.Nombre = "aZUCAR";
pro2.Stock = 200;
pro2.Codigo = 1;
manejador.SaveProduct(pro2);


var lst = manejador.GetProducts();

foreach (Product item in lst)
{
    Console.WriteLine("Item");
    Console.WriteLine(item);
}
