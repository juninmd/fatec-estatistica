using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models;

namespace EstatisticaFatec.Core
{
    public static class InputCore
    {
        public static RequestMessage<List<decimal>> Tratar(string massaDados)
        {
            var listaInput = new RequestMessage<List<decimal>>();
            try
            {
                listaInput.Content = massaDados.Split(';').Select(decimal.Parse).ToList();
            }
            catch (Exception ex)
            {
                listaInput.IsError = true;
                listaInput.DevMessage = ex.Message;
                listaInput.Message = "Os dados inputados estão inválidos, por favor verifique.";
            }
            return listaInput;
        }
    }
}
