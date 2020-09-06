using System.ComponentModel;

namespace ParavarejoApp.Models.ParavarejoLucroReal
{
    public enum LucroRealVariable
    {
        [Description("Nenhuma")]
        None,
        [Description("Preço de compra")]
        PreçoDeCompra,
        [Description("Crédito ICMS (-)")]
        CreditoICMS,
        [Description("Crédito PIS Cofins (-)")]
        CreditoPISCofins,
        [Description("Acréscimo IPI (+)")]
        AcrescimoIPI,
        [Description("Preço de custo")]
        PreçoDeCusto,
        [Description("Preço de venda")]
        PreçoDeVenda,
        [Description("Débito ICMS (-)")]
        DebitoICMS,
        [Description("Débito PIS Cofins (-)")]
        DebitoPISCofins,
        [Description("Lucro bruto")]
        LucroBruto
    }
}