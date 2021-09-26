using SGP.Model.Entity.DTO;
using System;

namespace SGP.Model.Entity
{
    public static class CalcularDepreciacao
    {
       
        public static decimal CalcularValorAtualDoEquipamento(int idade)
        {
            EquipamentoDTO equipamento = new EquipamentoDTO
            {
                Idade = idade
            };
            var percentual = Convert.ToDecimal(equipamento.ClassificacaoDeAtivos.TaxaDeDepreciacao) / 100; // 0,2
            decimal vt = equipamento.ValorDeCompra * percentual; // 3200 * 0,2 = 640

           return equipamento.ValorAtual = equipamento.ValorDeCompra - (vt * equipamento.Idade);// 3200 - (640*3) = 1920
        }
    }
}
