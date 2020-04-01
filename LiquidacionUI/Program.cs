using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace LiquidacionUI
{
    class Program
    {
        static void Main(string[] args)
        {
            LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
            
            int opcion;
            ConsoleKeyInfo continuar;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t### MENU PRINCIPAL ###");
                Console.WriteLine("\t\t\t[1] Registrar liquidacion");
                Console.WriteLine("\t\t\t[2] Visualizar liquidaciones");
                Console.WriteLine("\t\t\t[3] Eliminar una liquidacion");
                Console.WriteLine("\t\t\t[4] Actualizar una liquidacion");
                Console.WriteLine("\t\t\t[5] Salir");
                Console.Write("\t\t\tDigite opcion");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradora();
                        Console.WriteLine("Digite numero de liquidacion");
                        liquidacionCuotaModeradora.NumeroLiquidacion = Console.ReadLine();
                        Console.WriteLine("Digite numero Identidicacion");
                        liquidacionCuotaModeradora.IdentificacionPaciente = Console.ReadLine();
                        Console.WriteLine("Digite tipo Afiliacionn");
                        liquidacionCuotaModeradora.TipoAfiliacion = Console.ReadLine();

                        if (liquidacionCuotaModeradora.TipoAfiliacion.ToUpper().Equals("CONTRIBUTIVO"))
                        {
                            Console.WriteLine("Digite salario Devengado");
                            liquidacionCuotaModeradora.SalarioDevengado = Convert.ToDecimal(Console.ReadLine());
                        }
                        Console.WriteLine("Digite valor servicio");
                        liquidacionCuotaModeradora.ValorServicio = Convert.ToDecimal(Console.ReadLine());
                        liquidacionCuotaModeradora.CalcularCuotaModeradora();
                        string mensaje = liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora);
                        Console.WriteLine(mensaje);

                        break;
                    case 2:
                        // Console.WriteLine("# liquidacion" + "\t" + "Identificacion" + "\t" + "Tipo Afiliacion" + "\t" + "Salario Devengado" + "\t" + "Valor Servicio" + "\t" + "Tarifa" + "\t" + "Liquidacion real" + "\t" + "Tope"+ "\t" + "Cuota Moderadora");
                        Console.WriteLine("# liquidacion" + "\t" + "Identificacion" + "\t" + "Tipo Afiliacion" + "\t" + "Salario Devengado" + "\t" + "Valor Servicio" + "\t" + "Tarifa" + "\t"+"Liquidacion real"+ "  Tope  " + "   Cuota Moderadora");
                        foreach (var item in liquidacionCuotaModeradoraService.Consultar())
                        {
                            // Console.WriteLine(item.NumeroLiquidacion + "\t" + item.IdentificacionPaciente + "\t" + item.TipoAfiliacion + "\t\t" + item.SalarioDevengado + "\t\t" + item.ValorServicio + "\t\t\t" + item.Tarifa + "\t\t\t" + item.CuotaModeradaReal + "\t" + item.aplicaTope + "\t\t" + item.CuotaModeradora);
                            Console.WriteLine(item.ToString());
                        }
                break;
                    case 3:
                        Console.WriteLine("Digite numero de liquidacion a eliminar");
                        string numeroLiquidacion = Console.ReadLine();
                        string mensajeBorrado = liquidacionCuotaModeradoraService.Eliminar(numeroLiquidacion);
                        Console.WriteLine(mensajeBorrado);
                        Console.ReadKey();
                        break;
                    case 4:
                        LiquidacionCuotaModeradora liquidacionnueva = new LiquidacionCuotaModeradora();
                        LiquidacionCuotaModeradora liquidacionvieja = new LiquidacionCuotaModeradora();

                        Console.WriteLine("Digite numero de liquidacion a actualizar");
                        string numeroLiquidacionActualizar = Console.ReadLine();
                        Console.WriteLine("Digite nuevo valor servicio");
                        decimal valorServicio = Convert.ToDecimal(Console.ReadLine());
                        liquidacionvieja = liquidacionCuotaModeradoraService.Buscar(numeroLiquidacionActualizar);
                        if (liquidacionvieja != null){
                            liquidacionnueva.NumeroLiquidacion = liquidacionvieja.NumeroLiquidacion;
                            liquidacionnueva.IdentificacionPaciente = liquidacionvieja.IdentificacionPaciente;
                            liquidacionnueva.TipoAfiliacion = liquidacionvieja.TipoAfiliacion;
                            liquidacionnueva.SalarioDevengado = liquidacionvieja.SalarioDevengado;
                            liquidacionnueva.ValorServicio = valorServicio;
                            //liquidacionnueva.CuotaModeradora = liquidacionvieja.CuotaModeradora;
                            //liquidacionnueva.CuotaModeradaReal = liquidacionvieja.CuotaModeradaReal;
                            //liquidacionnueva.Tarifa = liquidacionvieja.Tarifa;
                            liquidacionnueva.CalcularCuotaModeradora();
                        }
                        string mensajeActualizar = liquidacionCuotaModeradoraService.Modificar(liquidacionvieja, liquidacionnueva);
                        Console.WriteLine(mensajeActualizar);
                        break;
                    case 5: Console.WriteLine("Sesion finalizada"); break;

                    default:
                        Console.WriteLine("Digite una opcion valida por favor");
                        break;
                }

                Console.WriteLine("Desea  continuar s/n");
                continuar = Console.ReadKey();
            } while (continuar.KeyChar == 'S' || continuar.KeyChar == 's');

        }
    }
}
