string NombreKiosco = "Kiosco Siempre";
Console.Write("Ingrese el nombre del cajero: ");
string NombreCajero = Console.ReadLine();
Console.WriteLine();
Console.WriteLine($"{NombreKiosco}");
Console.WriteLine($"Bienvenido, {NombreCajero}. Caja abierta");
Console.WriteLine();

int CantidadProductos = 0;
decimal TotalVenta = 0;
decimal TotalDescuento = 0;
decimal TotalRecargo = 0;
decimal TotalNeto = 0;
decimal RecargoCredito = 0.15m;
decimal Descuento50000 = 0.1m;
decimal DescuentoEfectivo = 0.1m;
decimal Descuento20000 = 0.05m;
int decision = 1;
int medio = 0;
do
{

    Console.WriteLine("¿Qué desea hacer?\n1 - Cargar un producto\n2 - Cerrar la venta");
    decision = int.Parse(Console.ReadLine());

    switch (decision)
    {
        case 1:
        {
            CantidadProductos++;
            Console.Write("Ingrese el nombre de un producto: ");
            string NombreProducto = Console.ReadLine();
            Console.Write("Ingrese el precio del producto: ");
            decimal PrecioProducto = decimal.Parse(Console.ReadLine());
            TotalVenta += PrecioProducto;
            Console.WriteLine();
            Console.WriteLine($"Producto {NombreProducto} cargado con éxito.\nSubtotal de la venta: ${TotalVenta}");
            Console.WriteLine();
            break;
        }
        case 2:
        {
            if (TotalVenta > 50000)
            {
                TotalDescuento = TotalVenta * Descuento50000;
                TotalNeto = TotalVenta - TotalDescuento;
            }
            else if (TotalVenta > 20000)
            {
                TotalDescuento = TotalVenta * Descuento20000;
                TotalNeto = TotalVenta - TotalDescuento;
            }
            else
            {
                TotalNeto = TotalVenta;
            }

            do
            {
                Console.WriteLine();
                Console.WriteLine("Medio de pago:\n1 - Efectivo\n2 - Débito\n3 - Crédito");
                medio = int.Parse(Console.ReadLine());
                switch (medio)
                {
                    case 1:
                    {
                        TotalDescuento += TotalVenta * DescuentoEfectivo;
                        TotalNeto = TotalVenta - TotalDescuento;
                        break;
                    }
                    case 2:
                    {
                        TotalNeto = TotalVenta - TotalDescuento;
                        break;
                    }
                    case 3:
                    {
                        TotalRecargo = TotalVenta * RecargoCredito;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Opción no válida");
                        break;
                    }
                }
            } while (medio != 1 && medio != 2 && medio != 3);
            Console.WriteLine($"Carga finalizada por hoy.\nCantidad de productos: {CantidadProductos}\nSubtotal de la venta: ${TotalVenta}\nDescuentos obtenidos: (${TotalDescuento})\nRecargo: ${TotalRecargo}\nNeto a pagar: ${TotalNeto}");
            break;
        }
        default:
        {
            Console.WriteLine("Opción no válida");
            break;
        }
    }
} while (decision != 2);

Console.ReadKey();