using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradora
    {
        const decimal SALARIO = 877803;
       

        public string NumeroLiquidacion { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public decimal SalarioDevengado { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal CuotaModeradora { get; set; }
        public decimal CuotaModeradaReal { get; set; }
        public decimal Tarifa { get; set; }
        public string aplicaTope { get; set; }
        

        public decimal CalcularTarifa()
        {
            if (TipoAfiliacion.ToUpper().Equals("CONTRIBUTIVO"))
            {
                if (SalarioDevengado < SALARIO * 2)
                {
                    Tarifa = 0.15m;
                }
                else if (SalarioDevengado >= SALARIO * 2 && SalarioDevengado <= SALARIO * 5)
                {
                    Tarifa = 0.20m;
                }
                else
                {
                    Tarifa = 0.25m;
                }
            }else if (TipoAfiliacion.ToUpper().Equals("SUBSIDIADO"))
            {
                Tarifa = 0.05m;
            }
            return Tarifa;
        }

        public void CalcularCuotaModeradora()
        {
            aplicaTope = "No Aplica";
            if (TipoAfiliacion.ToUpper().Equals("CONTRIBUTIVO"))
            {
                CuotaModeradaReal = ValorServicio * CalcularTarifa();
                if (CuotaModeradaReal > 250000 && SalarioDevengado < SALARIO * 2)
                {
                    aplicaTope = "Aplica";
                    CuotaModeradora = 250000;
                }
                else if(CuotaModeradaReal > 900000 && SalarioDevengado >= SALARIO * 2 && SalarioDevengado <= SALARIO * 5)
                {
                    CuotaModeradora = 900000;
                    aplicaTope = "Aplica";
                }
                else if(CuotaModeradaReal > 1500000 )
                {
                    CuotaModeradora = 1500000;
                    aplicaTope = "Aplica";
                }
            }
            else if(TipoAfiliacion.ToUpper().Equals("SUBSIDIADO"))
            {
                CuotaModeradaReal = ValorServicio * CalcularTarifa();
                if(CuotaModeradaReal > 200000)
                {
                    CuotaModeradora = 200000;
                    aplicaTope = "Aplica";
                }
            }
        }
   


        public override string ToString()
        {
            return $"{NumeroLiquidacion}    {IdentificacionPaciente}   {TipoAfiliacion} {SalarioDevengado} {ValorServicio} {Tarifa}  {CuotaModeradora}  {aplicaTope} {CuotaModeradaReal}";
        }

    }
}
