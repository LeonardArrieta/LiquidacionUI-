using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras;

        public LiquidacionCuotaModeradoraRepository()
        {
            liquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();
        }

        public void Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            liquidacionCuotaModeradoras.Add(liquidacionCuotaModeradora);
        }

        public List<LiquidacionCuotaModeradora> Consultar()
        {
            return liquidacionCuotaModeradoras;
        }

        public LiquidacionCuotaModeradora Buscar(string numeroLiquidacion)
        {
            foreach (var linea in liquidacionCuotaModeradoras)
            {
                if (linea.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    return linea;
                }
            }
            return null;
        }

        public void Eliminar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            liquidacionCuotaModeradoras.Remove(liquidacionCuotaModeradora);
        }


        public void Modificar(LiquidacionCuotaModeradora vieja, LiquidacionCuotaModeradora nueva)
        {
            liquidacionCuotaModeradoras.Remove(vieja);
            liquidacionCuotaModeradoras.Add(nueva);
        }
        //public void Modificar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        //{
        //    List<LiquidacionCuotaModeradora> lista = new List<LiquidacionCuotaModeradora>();
        //    lista = liquidacionCuotaModeradoras;
        //    //liquidacionCuotaModeradoras.Clear();
        //    foreach (var item in lista)
        //    {
        //        if (Compatible(item, liquidacionCuotaModeradora)==true)
        //        {
        //            Guardar(item);
        //        }
        //        else
        //        {
        //            Guardar(liquidacionCuotaModeradora);
        //        }
        //    }
        //}

        private bool Compatible(LiquidacionCuotaModeradora vieja, LiquidacionCuotaModeradora nueva)
        {
            return vieja.NumeroLiquidacion == nueva.NumeroLiquidacion
            && vieja.ValorServicio == nueva.ValorServicio;
        }
    }
}
