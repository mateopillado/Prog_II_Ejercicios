
using Problema_1._6.Domain;
using Problema_1._6.Repositories.Implementations;

ClienteRepository clientes = new ClienteRepository();

//Cliente oCliente = new Cliente();

//oCliente.Nombre = "federico";
//oCliente.Apellido = "ventanal";
//oCliente.Dni = "43934543";


//clientes.Save(oCliente);



//List<Cliente> list = clientes.GetAll();

//foreach (Cliente cliente in list)
//{
//    Console.WriteLine(cliente);
//}

TipoCuentaRepository tipos = new TipoCuentaRepository();
List<Tipo_Cuenta> list = tipos.GetAll();

foreach (Tipo_Cuenta tipo in list)
{
    Console.WriteLine(tipo);
}