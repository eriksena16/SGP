using System;

namespace SGP.Model.Entity
{
    public static class CalcularTempoDeUso
    {
        public static int CalcularTempoDeUsoDoEquipamento(int idade)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.Idade = idade;
            idade = DateTime.Now.Year - equipamento.DataDeCompra.Year;
            if (DateTime.Now.Month >= equipamento.DataDeCompra.Month && DateTime.Now.Day >= equipamento.DataDeCompra.Day)
            {

                equipamento.ValorAtual = CalcularDepreciacao.CalcularValorAtualDoEquipamento(equipamento.Idade);
            }
            else
            {
                equipamento.Idade -= 1;
                equipamento.ValorAtual = CalcularDepreciacao.CalcularValorAtualDoEquipamento(equipamento.Idade);
            }
            return idade;
        }
    }
}
