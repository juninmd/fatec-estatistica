using System;
using System.Linq;
using EstatisticaFatec.Core.Models;

namespace EstatisticaFatec.Core
{
    public static class InputCore
    {
        public static RequestMessage<BaseInputsEntity> Tratar(InputEntity inputEntity)
        {
            var listaInput = new RequestMessage<BaseInputsEntity>();
            try
            {
                var lista = inputEntity.MassaDados.Split(';').Select(decimal.Parse).ToList();
                listaInput.Content = new BaseInputsEntity
                {
                    InputValue = lista,
                    Rol = lista.OrderBy(q => q).ToList(),
                    Amostra = inputEntity.TipoInput == "amostra"
                };
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
