using Problema_1._5.Domain;
using Problema_1._5.Services;


var manejador = new AlmacenManager();


var formas = manejador.GetAllFormaPago();

Console.WriteLine("Formas de pago");
foreach (var forma in formas)
{
    Console.WriteLine(forma);
}


//var facturas = manejador.GetAllFacturas();
//foreach (var factura in facturas)
//{
//    Console.WriteLine(factura);
//}


//var articulo = new Articulo
//{
//    Nombre = "Pancito",
//    Precio = 30
//};

//manejador.InsertArticulo(articulo);


//var addForma = new FormaPago
//{
//    Nombre = "Cheque",
//    Recargo = 15
//};

//manejador.AddFormaPago(addForma);

var productos = manejador.GetAllProductos();
Console.WriteLine("Lista de Productos");

foreach (var item in productos)
{
    Console.WriteLine(item);
}

//manejador.DeleteArticulo(4);


//var dett = new DetalleFactura
//{
//    Id = 1,
//    Articulo_ = productos[0],
//    Cantidad = 3,
//    Precio = 10,
//};

//var lstDetalles = new List<DetalleFactura>();

//lstDetalles.Add(dett);

//var fac = new Factura
//{
//    Cliente = 1,
//    Fecha = DateTime.Now,
//    FormaPago = formas[0],
//    DetalleList = lstDetalles

//};

//Console.WriteLine(manejador.InsertFactura(fac));

