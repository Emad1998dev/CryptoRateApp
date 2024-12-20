namespace CryptoRateApp.Models
{
    public class CryptoRate
    {
        public string CurrencyCode { get; set; } // کد ارز دیجیتال، مثل BTC
        public decimal USD { get; set; }        // نرخ در دلار آمریکا
        public decimal EUR { get; set; }        // نرخ در یورو
        public decimal BRL { get; set; }        // نرخ در رئال برزیل
        public decimal GBP { get; set; }        // نرخ در پوند بریتانیا
        public decimal AUD { get; set; }        // نرخ در دلار استرالیا
    }
}   
