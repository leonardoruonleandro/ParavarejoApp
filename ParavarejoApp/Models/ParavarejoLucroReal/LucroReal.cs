using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParavarejoApp.Models.ParavarejoLucroReal
{
    internal class LucroReal
    {
        public void CalculateLucroReal(List<LucroRealItem> items)
        {
            LucroRealItem preçoDeCompra = null;
            LucroRealItem creditoICMS = null;
            LucroRealItem creditoPISCofins = null;
            LucroRealItem acrescimoIPI = null;
            LucroRealItem preçoDeCusto = null;
            LucroRealItem preçoDeVenda = null;
            LucroRealItem debitoICMS = null;
            LucroRealItem debitoPISCofins = null;
            LucroRealItem lucroBruto = null;

            foreach (var item in items)
            {
                switch (item.Variable)
                {
                    case LucroRealVariable.PreçoDeCompra:
                        preçoDeCompra = item;
                        break;
                    case LucroRealVariable.CreditoICMS:
                        creditoICMS = item;
                        break;
                    case LucroRealVariable.CreditoPISCofins:
                        creditoPISCofins = item;
                        break;
                    case LucroRealVariable.AcrescimoIPI:
                        acrescimoIPI = item;
                        break;
                    case LucroRealVariable.PreçoDeCusto:
                        preçoDeCusto = item;
                        break;
                    case LucroRealVariable.PreçoDeVenda:
                        preçoDeVenda = item;
                        break;
                    case LucroRealVariable.DebitoICMS:
                        debitoICMS = item;
                        break;
                    case LucroRealVariable.DebitoPISCofins:
                        debitoPISCofins = item;
                        break;
                    case LucroRealVariable.LucroBruto:
                        lucroBruto = item;
                        break;
                    default:
                        throw new ArgumentException($"Variable '{item.Variable}' is not expected. Item: {item}");
                }
            }

            creditoICMS.CurrenceValue = preçoDeCompra.CurrenceValue * creditoICMS.PercentualValue / 100;
            creditoPISCofins.CurrenceValue = preçoDeCompra.CurrenceValue * creditoPISCofins.PercentualValue / 100;
            acrescimoIPI.CurrenceValue = preçoDeCompra.CurrenceValue * acrescimoIPI.PercentualValue / 100;
            preçoDeCusto.CurrenceValue = preçoDeCompra.CurrenceValue - creditoICMS.CurrenceValue - creditoPISCofins.CurrenceValue + acrescimoIPI.CurrenceValue;
            debitoICMS.CurrenceValue = preçoDeVenda.CurrenceValue * debitoICMS.PercentualValue / 100;
            debitoPISCofins.CurrenceValue = preçoDeVenda.CurrenceValue * debitoPISCofins.PercentualValue / 100;
            lucroBruto.CurrenceValue = preçoDeVenda.CurrenceValue - debitoICMS.CurrenceValue - debitoPISCofins.CurrenceValue - preçoDeCusto.CurrenceValue;
            lucroBruto.PercentualValue = lucroBruto.CurrenceValue / preçoDeVenda.CurrenceValue * 100;
            
        }

    }
}
