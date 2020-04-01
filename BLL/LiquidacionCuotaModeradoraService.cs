using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;
        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            if (liquidacionCuotaModeradoraRepository.Buscar(liquidacionCuotaModeradora.NumeroLiquidacion) == null)
            {
                liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora);
                return $"Datos guardados";
            }
            return $"Error al guardar, numero de liquidacion {liquidacionCuotaModeradora.NumeroLiquidacion} ya esa registrada";
        }

        public List<LiquidacionCuotaModeradora> Consultar()
        {
            return liquidacionCuotaModeradoraRepository.Consultar();
        }

        public LiquidacionCuotaModeradora Buscar(string numeroLiquidacion)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora = liquidacionCuotaModeradoraRepository.Buscar(numeroLiquidacion);
            if (liquidacionCuotaModeradora != null)
            {
                return liquidacionCuotaModeradora;
            }
            return null;
        }

        public string Eliminar(string numeroLiquidacion)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora = liquidacionCuotaModeradoraRepository.Buscar(numeroLiquidacion);
            if (liquidacionCuotaModeradora != null)
            {
                liquidacionCuotaModeradoraRepository.Eliminar(liquidacionCuotaModeradora);
                return $"Liquidacion eliminada";
            }
            return $"Liquidacion numero {numeroLiquidacion} no existe";
        }

        public string Modificar(LiquidacionCuotaModeradora vieja, LiquidacionCuotaModeradora nueva)
        {

            if (vieja != null && nueva != null)
            {
                liquidacionCuotaModeradoraRepository.Modificar(vieja, nueva);
                return $"Liquidacion numero {nueva.NumeroLiquidacion} ha sido modificada satisfacatoriamente";
            }
            return $"La liquidacion numero {nueva.NumeroLiquidacion} no se encuentra registrada";

        }
    }
}
